using UFit.Application.Abstractions.Authentication;
using UFit.Application.Abstractions.Messaging;
using UFit.Domain.Abstractions;
using UFit.Domain.Trainees;

namespace UFit.Application.Trainees.Login;
internal class LoginCommandHandler : ICommandHandler<LoginCommand, LoginResponse>
{
    private readonly ITraineeRepository _traineeRepository;
    private readonly IJwtProvider _jwtProvider;

    public LoginCommandHandler(IJwtProvider jwtProvider, ITraineeRepository traineeRepository)
    {
        _jwtProvider = jwtProvider;
        _traineeRepository = traineeRepository;
    }

    public async Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var token = await _jwtProvider.GetJwtAsync(request.Email, request.Password);
        var trainee = await _traineeRepository.GetByEmailAsync(request.Email);

        if (trainee is null) return Result.Failure<LoginResponse>(TraineeErrors.NotFound);

        return new LoginResponse(trainee.Id.ToString(), token);
    }
}
