using UFit.Application.Abstractions.Messaging;

namespace UFit.Application.Workouts.Create;
public sealed record CreateWorkoutCommand(CreateWorkoutRequest Workout) : ICommand;
