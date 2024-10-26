using UFit.Domain.Abstractions;

namespace UFit.Domain.Workouts;
public sealed record WorkoutCreatedDomainEvent(Guid Id) : IDomainEvent;
