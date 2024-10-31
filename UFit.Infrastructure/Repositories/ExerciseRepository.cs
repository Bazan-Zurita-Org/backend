using UFit.Domain.Workouts;

namespace UFit.Infrastructure.Repositories;
internal class ExerciseRepository(ApplicationDbContext context) : IExerciseRepository
{
    public void Add(Exercise exercise)
    {
        context.Exercises.Add(exercise);
    }
}
