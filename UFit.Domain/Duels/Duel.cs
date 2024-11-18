using UFit.Domain.Abstractions;

namespace UFit.Domain.Duels;
public sealed class Duel : Entity
{
    private Duel() { }
    private Duel(
        Guid id,
        Guid challengerId,
        Guid opponentId,
        Guid challengeId,
        DateTime startDate,
        DateTime endDate,
        DuelStatus status,
        DuelType type,
        string? challengeText) : base(id)
    {
        ChallengerId = challengerId;
        OpponentId = opponentId;
        ChallengeId = challengeId;
        StartDate = startDate;
        EndDate = endDate;
        Status = status;
        Type = type;
        ChallengeText = challengeText;
    }

    public Guid ChallengerId { get; private set; }
    public Guid OpponentId { get; private set; }
    public Guid ChallengeId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public DuelStatus Status { get; private set; }
    public DuelType Type { get; private set; }
    public string? ChallengeText { get; private set; }

    public static Result<Duel> Create(
        Guid challengerId,
        Guid opponentId,
        Guid challengeId,
        DateTime startDate,
        DateTime endDate,
        string challengeText)
    {
        var duel = new Duel(Guid.NewGuid(), challengerId, opponentId, challengeId, startDate, endDate, DuelStatus.Pending, DuelType.Exercise, challengeText);

        return duel;
    }

    public void Accept()
    {
        Status = DuelStatus.Accepted;
    }
}
