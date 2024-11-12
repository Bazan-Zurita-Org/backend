using UFit.Domain.Abstractions;

namespace UFit.Domain.Duels;
public sealed class Duel : Entity
{
    private Duel() { }
    private Duel(
        Guid id,
        Guid challengerId,
        Guid opponentId,
        DateTime startDate,
        DateTime endDate,
        DuelStatus status,
        DuelType type,
        string? challengeText) : base(id)
    {
        ChallengerId = challengerId;
        OpponentId = opponentId;
        StartDate = startDate;
        EndDate = endDate;
        Status = status;
        Type = type;
        ChallengeText = challengeText;
    }

    public Guid ChallengerId { get; private set; }
    public Guid OpponentId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public DuelStatus Status { get; private set; }
    public DuelType Type { get; private set; }
    public string? ChallengeText { get; private set; }
}
