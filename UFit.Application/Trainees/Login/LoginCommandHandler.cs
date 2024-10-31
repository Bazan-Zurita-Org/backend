using UFit.Application.Abstractions.Authentication;
using UFit.Application.Abstractions.Messaging;
using UFit.Domain.Abstractions;

namespace UFit.Application.Trainees.Login;
internal class LoginCommandHandler : ICommandHandler<LoginCommand, string>
{
    private readonly IJwtProvider _jwtProvider;

    public LoginCommandHandler(IJwtProvider jwtProvider)
    {
        _jwtProvider = jwtProvider;
    }

    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return await _jwtProvider.GetJwtAsync(request.Email, request.Password);
    }
}
