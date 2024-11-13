using UFit.Domain.Challenges;

namespace UFit.Application.Challenges.Create;

public sealed record CreateChallengeRequest(
    string Name,
    string Description,
    int Points,
    DateTime StartDate,
    DateTime EndDate,
    ChallengeType Type);