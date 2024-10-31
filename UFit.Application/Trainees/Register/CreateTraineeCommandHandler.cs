using UFit.Application.Abstractions;
using UFit.Application.Abstractions.Authentication;
using UFit.Application.Abstractions.Messaging;
using UFit.Domain.Abstractions;
using UFit.Domain.Trainees;

namespace UFit.Application.Trainees.Register;
internal sealed class CreateTraineeCommandHandler : ICommandHandler<CreateTraineeCommand, Guid>
{
    private readonly ITraineeRepository _traineeRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationService _authenticationService;

    public CreateTraineeCommandHandler(ITraineeRepository traineeRepository, IUnitOfWork unitOfWork, IAuthenticationService authenticationService)
    {
        _traineeRepository = traineeRepository;
        _unitOfWork = unitOfWork;
        _authenticationService = authenticationService;
    }

    public async Task<Result<Guid>> Handle(CreateTraineeCommand request, CancellationToken cancellationToken)
    {
        var identityId = await _authenticationService.RegisterAsync(request.Trainee.Email, request.Trainee.Password);

        var result = Trainee.Create(
            new Name(request.Trainee.FirstName, request.Trainee.LastName),
            new Measurements(request.Trainee.Height, request.Trainee.Weight),
            new Gender(request.Trainee.Gender),
            request.Trainee.DateOfBirth,
            new Email(request.Trainee.Email),
            new Phone(request.Trainee.Phone),
            new FitnessGoal(request.Trainee.FitnessGoal),
            new TargetWeight(request.Trainee.TargetWeigth),
            identityId);

        _traineeRepository.Add(result.Value);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result.Value.Id;
    }
}
