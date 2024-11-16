using UFit.Application.Abstractions.Messaging;

namespace UFit.Application.Workouts.GetRoutine;
public sealed record GetRoutineQuery(Guid TraineeId) : IQuery<RoutineResponse>;

