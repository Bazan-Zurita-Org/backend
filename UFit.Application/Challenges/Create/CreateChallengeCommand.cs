using UFit.Application.Abstractions.Messaging;

namespace UFit.Application.Challenges.Create;

public sealed record CreateChallengeCommand(CreateChallengeRequest Challenge) : ICommand;
