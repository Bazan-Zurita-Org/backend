using UFit.Domain.Abstractions;
using UFit.Domain.Shared;

namespace UFit.Domain.Challenges;

public sealed class Challenge : Entity
{
    private Challenge() { }
    private Challenge(
        Guid id,
        Name name,
        Description myProperty,
        Points rewards,
        DateTime startDate,
        DateTime endDate,
        ChallengeType type) : base(id)
    {
        Name = name;
        MyProperty = myProperty;
        Rewards = rewards;
        StartDate = startDate;
        EndDate = endDate;
        Type = type;
    }

    public Name Name { get; private set; }
    public Description MyProperty { get; private set; }
    public Points Rewards { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public ChallengeType Type { get; private set; }
}
