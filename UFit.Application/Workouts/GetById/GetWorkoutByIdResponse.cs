using UFit.Domain.Workouts;

namespace UFit.Application.Workouts.GetById;

public sealed record GetWorkoutByIdResponse(
    Guid Id,
    string Name,
    DateTime Date,
    string Goal,
    DifficultyLevel DifficultyLevel,
    bool IsCompleted);
