using UFit.Domain.Trainees;

namespace UFit.Infrastructure.Repositories;
internal class TraineeRepository(ApplicationDbContext context) : ITraineeRepository
{
    public void Add(Trainee trainee)
    {
        context.Add(trainee);
    }

    public async Task<Trainee?> FindById(Guid id)
    {
        return await context.Set<Trainee>().FindAsync(id);
    }
}
