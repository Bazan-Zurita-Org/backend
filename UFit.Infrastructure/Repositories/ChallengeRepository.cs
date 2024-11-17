using Microsoft.EntityFrameworkCore;
using UFit.Domain.Challenges;

namespace UFit.Infrastructure.Repositories;

internal class ChallengeRepository(ApplicationDbContext context) : IChallengeRepository
{
    public void Add(Challenge challenge)
    {
        context.Set<Challenge>().Add(challenge);
    }

    public async Task<Challenge?> GetByIdAsync(Guid id)
    {
        return await context.Set<Challenge>().Include(c => c.TraineeChallenges).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Challenge?> GetByTraineeChallengeIdAsync(Guid traineeChallenge)
    {
        return await context.Set<Challenge>()
            .Include(challenge => challenge.TraineeChallenges)
            .Where(challenge => challenge.TraineeChallenges.Any(tc => tc.Id == traineeChallenge))
            .FirstOrDefaultAsync();
    }
}
