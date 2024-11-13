using UFit.Domain.Abstractions;

namespace UFit.Domain.Challenges;
public sealed class TraineeChallenge : Entity
{
    private TraineeChallenge() { }
    internal TraineeChallenge(
        Guid id,
        Guid traineeId,
        Guid challengeId,
        ChallengeStatus status,
        DateTime? completionDate) : base(id)
    {
        TraineeId = traineeId;
        ChallengeId = challengeId;
        Status = status;
        CompletionDate = completionDate;
    }

    public Guid TraineeId { get; private set; }
    public Guid ChallengeId { get; private set; }
    public ChallengeStatus Status { get; private set; }
    public DateTime? CompletionDate { get; private set; }
}
