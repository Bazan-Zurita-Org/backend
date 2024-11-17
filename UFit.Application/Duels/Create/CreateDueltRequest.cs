namespace UFit.Application.Duels.Create;

public sealed record CreateDueltRequest(
    Guid ChallengerId,
    Guid OpponentId,
    Guid ChallengeId,
    DateTime StartDate,
    DateTime EndDate,
    string ChallengeText);