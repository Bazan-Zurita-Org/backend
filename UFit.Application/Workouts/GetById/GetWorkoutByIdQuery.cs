using UFit.Application.Abstractions.Messaging;

namespace UFit.Application.Workouts.GetById;
public sealed record GetWorkoutByIdQuery(Guid Id) : IQuery<GetWorkoutByIdResponse>;
