using UFit.Domain.Abstractions;

namespace UFit.Domain.Workouts;
public class WorkoutErrors
{
    public readonly static Error NotFound = new(
        "Workout.NotFound", "Workout with given Id not found");
}
