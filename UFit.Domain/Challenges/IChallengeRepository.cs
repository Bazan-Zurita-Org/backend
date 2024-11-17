namespace UFit.Domain.Challenges;
public interface IChallengeRepository
{
    void Add(Challenge challenge);
    Task<Challenge?> GetByIdAsync(Guid id);
    Task<Challenge?> GetByTraineeChallengeIdAsync(Guid traineeChallenge);
}
