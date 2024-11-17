using Microsoft.EntityFrameworkCore;
using UFit.Application.Abstractions.Data;
using UFit.Application.Abstractions.Messaging;
using UFit.Domain.Abstractions;
using UFit.Domain.Challenges;

namespace UFit.Application.Challenges.GetTraineeChallenges;
internal class GetTraineeChallengesQueryHandler : IQueryHandler<GetTraineeChallengesQuery, GetTraineeChallengesResponse>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetTraineeChallengesQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Result<GetTraineeChallengesResponse>> Handle(GetTraineeChallengesQuery request, CancellationToken cancellationToken)
    {
        var individualChallenge = await _applicationDbContext.Challenges
            .Where(c => c.Type == ChallengeType.Individual)
            .OrderBy(c => Guid.NewGuid())
            .FirstOrDefaultAsync(cancellationToken);

        var groupChallenge = await _applicationDbContext.Challenges
            .Where(c => c.Type == ChallengeType.Duel)
            .OrderBy(c => Guid.NewGuid())
            .FirstOrDefaultAsync(cancellationToken);

        if (individualChallenge == null || groupChallenge == null)
        {
            return Result.Failure<GetTraineeChallengesResponse>(new Error("Challenges.Not Found", "No challenges found for the requested types."));
        }

        var response = new GetTraineeChallengesResponse(
            new List<ChallengeResponse>() {  new ChallengeResponse(
                individualChallenge.Id,
                individualChallenge.Name.Value,
                individualChallenge.Description.Value,
                individualChallenge.Rewards.Value,
                individualChallenge.StartDate,
                individualChallenge.EndDate,
                individualChallenge.Type),
            new ChallengeResponse(
                groupChallenge.Id,
                groupChallenge.Name.Value,
                groupChallenge.Description.Value,
                groupChallenge.Rewards.Value,
                groupChallenge.StartDate,
                groupChallenge.EndDate,
                groupChallenge.Type)
            }
        );

        return response;
    }
}
