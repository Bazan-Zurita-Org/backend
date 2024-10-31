using UFit.Domain.Abstractions;

namespace UFit.Domain.Workouts;
public class ExerciseErrors
{
    public readonly static Error NotFound = new(
       "Exercise.NotFound", "Exercise with given Id not found");
}
