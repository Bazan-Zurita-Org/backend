using UFit.Domain.Abstractions;
using UFit.Domain.Shared;

namespace UFit.Domain.Rankings;
public sealed class Ranking : Entity
{
    private Ranking(Guid id, Guid traineeId, Points points, Rank rank) : base(id)
    {
        TraineeId = traineeId;
        Points = points;
        Rank = rank;
    }

    public Guid TraineeId { get; private set; }
    public Points Points { get; private set; }
    public Rank Rank { get; private set; }
}
