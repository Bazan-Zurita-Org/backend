using UFit.Domain.Challenges;

namespace UFit.Application.Challenges.AssignTrainee;

public sealed record AssignChallengeToTraineeRequest(
    Guid TraineeId,
    Guid ChallengeId,
    ChallengeStatus Status,
    DateTime CompletionDate);