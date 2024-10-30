using UFit.Domain.Abstractions;

namespace UFit.Domain.Workouts;
public sealed class WorkoutExercise
{
    private WorkoutExercise() { }
    internal WorkoutExercise(
        Guid workoutId,
        Guid exerciseId,
        Set sets,
        Rep reps)
    {
        WorkoutId = workoutId;
        ExerciseId = exerciseId;
        Sets = sets;
        Reps = reps;
    }

    public Guid WorkoutId { get; private set; }
    public Guid ExerciseId { get; private set; }
    public Set Sets { get; private set; }
    public Rep Reps { get; private set; }
}
