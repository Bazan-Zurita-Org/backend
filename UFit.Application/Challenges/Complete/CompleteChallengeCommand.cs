using UFit.Application.Abstractions.Messaging;

namespace UFit.Application.Challenges.Complete;
public sealed record CompleteChallengeCommand(CompleteChallengeRequest TraineeChallenge) : ICommand;

public sealed record CompleteChallengeRequest(
    Guid TraineeChallengeId);
