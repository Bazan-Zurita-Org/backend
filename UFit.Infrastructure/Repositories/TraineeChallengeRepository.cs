using UFit.Domain.Challenges;

namespace UFit.Infrastructure.Repositories;
internal class TraineeChallengeRepository(ApplicationDbContext context) : ITraineeChallengeRepository
{
    public void Add(TraineeChallenge traineeChallenge)
    {
        context.Set<TraineeChallenge>().Add(traineeChallenge);
    }
}
