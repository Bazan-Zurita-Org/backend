namespace UFit.Domain.Duels;
public interface IDuelRepository
{
    void Add(Duel duel);
    Task<Duel?> GetByIdAsync(Guid id);
}
