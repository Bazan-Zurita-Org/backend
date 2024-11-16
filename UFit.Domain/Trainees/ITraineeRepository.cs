namespace UFit.Domain.Trainees;
public interface ITraineeRepository
{
    void Add(Trainee trainee);
    Task<Trainee?> FindById(Guid id);
    Task<Trainee?> GetByEmailAsync(string email);
}
