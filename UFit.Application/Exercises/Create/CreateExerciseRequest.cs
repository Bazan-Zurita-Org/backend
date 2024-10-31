namespace UFit.Application.Exercises.Create;

public sealed record CreateExerciseRequest(
    string Name,
    int Sets,
    int Reps,
    TimeSpan RestTime,
    string Equipment,
    string MuscleGroup,
    string Instructions);
