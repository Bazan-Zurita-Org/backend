using UFit.Domain.Workouts;

namespace UFit.Application.Workouts.Create;

public sealed record CreateWorkoutRequest(
    string Name,
    DateTime Date,
    string Goal,
    DifficultyLevel DifficultyLevel);