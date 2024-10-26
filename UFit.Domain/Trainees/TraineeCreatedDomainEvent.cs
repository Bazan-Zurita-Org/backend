using UFit.Domain.Abstractions;

namespace UFit.Domain.Trainees;
public sealed record TraineeCreatedDomainEvent(Guid Id) : IDomainEvent;