using UFit.Application.Abstractions.Messaging;

namespace UFit.Application.Challenges.GetTraineeChallenges;

public sealed record GetTraineeChallengesQuery(Guid TraineeId) : IQuery<GetTraineeChallengesResponse>;