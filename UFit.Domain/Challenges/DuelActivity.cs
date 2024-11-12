using UFit.Domain.Abstractions;

namespace UFit.Domain.Challenges;
public sealed class DuelActivity : Entity
{
    internal DuelActivity(
        Guid id,
        Guid duelId,
        Guid traineeId,
        Score myProperty,
        DateTime date) : base(id)
    {
        DuelId = duelId;
        TraineeId = traineeId;
        MyProperty = myProperty;
        Date = date;
    }

    public Guid DuelId { get; private set; }
    public Guid TraineeId { get; private set; }
    public Score MyProperty { get; private set; }
    public DateTime Date { get; private set; }
}
