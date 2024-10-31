namespace UFit.Application.Workouts.AddExercise;

public sealed record AddExerciseToWorkoutRequest(
    Guid WorkoutId,
    Guid ExerciseId,
    int Sets,
    int Reps);