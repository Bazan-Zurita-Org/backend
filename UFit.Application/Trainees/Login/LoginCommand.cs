using UFit.Application.Abstractions.Messaging;

namespace UFit.Application.Trainees.Login;
public sealed record LoginCommand(string Email, string Password) : ICommand<LoginResponse>;

public sealed record LoginResponse(
    string Id,
    string Token);