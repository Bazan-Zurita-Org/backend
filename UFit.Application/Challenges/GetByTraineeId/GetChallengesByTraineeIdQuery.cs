using UFit.Application.Abstractions.Messaging;
using UFit.Domain.Challenges;

namespace UFit.Application.Challenges.GetByTraineeId;

public sealed record GetChallengesByTraineeIdQuery(Guid TraineeId) : IQuery<List<ChallengeByTraineeResponse>>;

public sealed record ChallengeByTraineeResponse(
    Guid TraineeChallengeId,
    ChallengeStatus Status,
    Guid ChallengeId,
    string Name,
    string Description,
    int Rewards,
    DateTime StartDate,
    DateTime EndDate,
    ChallengeType Type);