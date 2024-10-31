using Microsoft.EntityFrameworkCore;
using UFit.Domain.Workouts;

namespace UFit.Infrastructure.Repositories;
internal class WorkoutRepository(ApplicationDbContext context) : IWorkoutRepository
{
    public void Add(Workout workout)
    {
        context.Workouts.Add(workout);
    }

    public async Task<Workout?> findById(Guid id)
    {
        return await context.Workouts.FirstOrDefaultAsync(w => w.Id == id);
    }
}
