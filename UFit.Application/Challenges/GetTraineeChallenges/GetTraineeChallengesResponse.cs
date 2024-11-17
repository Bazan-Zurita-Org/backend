using UFit.Domain.Challenges;

namespace UFit.Application.Challenges.GetTraineeChallenges;

public sealed record GetTraineeChallengesResponse(
    List<ChallengeResponse> Challenges);

public sealed record ChallengeResponse(
    Guid Id,
    string Name,
    string Description,
    int Points,
    DateTime StartDate,
    DateTime EndDate,
    ChallengeType Type
    );