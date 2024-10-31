using UFit.Domain.Workouts;

namespace UFit.Infrastructure.Repositories;
internal class ExerciseRepository(ApplicationDbContext context) : IExerciseRepository
{
    public void Add(Exercise exercise)
    {
        context.Exercises.Add(exercise);
    }

    public async Task<Exercise?> findById(Guid id)
    {
        return await context.Exercises.FindAsync(id);
    }
}
