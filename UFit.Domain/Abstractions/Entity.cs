namespace UFit.Domain.Abstractions;
public abstract class Entity
{
    public Guid Id { get; private set; }
    private readonly List<IDomainEvent> _domainEvents = new();
    protected Entity(Guid id)
    {
        Id = id;
    }
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.ToList();

    public void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvent()
    {
        _domainEvents.Clear();
    }
}
