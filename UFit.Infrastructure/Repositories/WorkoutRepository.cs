using UFit.Domain.Workouts;

namespace UFit.Infrastructure.Repositories;
internal class WorkoutRepository(ApplicationDbContext context) : IWorkoutRepository
{
    public void Add(Workout workout)
    {
        context.Workouts.Add(workout);
    }
}
