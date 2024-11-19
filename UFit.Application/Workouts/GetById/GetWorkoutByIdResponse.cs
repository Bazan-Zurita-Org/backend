using UFit.Application.Exercises.Create;
using UFit.Domain.Workouts;

namespace UFit.Application.Workouts.GetById;

public sealed record GetWorkoutByIdResponse(
    Guid Id,
    string Name,
    DateTime Date,
    string Goal,
    DifficultyLevel DifficultyLevel,
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