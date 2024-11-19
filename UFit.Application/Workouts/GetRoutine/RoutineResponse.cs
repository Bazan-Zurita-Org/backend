using UFit.Application.Workouts.GetById;
using UFit.Domain.Workouts;

namespace UFit.Application.Workouts.GetRoutine;

public sealed record RoutineResponse(List<GetTraineeWorkoutsResponse> Routine);

public sealed record GetTraineeWorkoutsResponse(
    Guid Id,
    string Name,
    DateTime Date,
    string Goal,
    DifficultyLevel DifficultyLevel,
    bool IsCompleted,
    List<ExerciseResponse> Exercises);


public sealed record ExerciseResponse(
    Guid Id,
    string Name,
    int Sets,
    int Reps,
    TimeSpan RestTime,
    string Equipment,
    string MuscleGroup,
    string Instructions);