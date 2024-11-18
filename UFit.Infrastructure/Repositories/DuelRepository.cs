using UFit.Domain.Duels;

namespace UFit.Infrastructure.Repositories;
internal class DuelRepository(ApplicationDbContext context) : IDuelRepository
{
    public void Add(Duel duel)
    {
        context.Set<Duel>().Add(duel);
    }

    public async Task<Duel?> GetByIdAsync(Guid id)
    {
        return await context.Set<Duel>().FindAsync(id);
    }
}
