using UFit.Application.Abstractions.Messaging;

namespace UFit.Application.Workouts.AddExercise;
public sealed record AddExerciseToWorkoutCommand(AddExerciseToWorkoutRequest ExerciseWorkout) : ICommand;
