namespace UFit.Domain.Workouts;
public interface IExerciseRepository
{
    void Add(Exercise exercise);
    Task<Exercise?> findById(Guid id);
}
