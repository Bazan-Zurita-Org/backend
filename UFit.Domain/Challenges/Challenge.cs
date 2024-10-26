using UFit.Domain.Abstractions;

namespace UFit.Domain.Challenges;

public sealed class Challenge : Entity
{
    private Challenge(Guid id) : base(id)
    {
    }
}
