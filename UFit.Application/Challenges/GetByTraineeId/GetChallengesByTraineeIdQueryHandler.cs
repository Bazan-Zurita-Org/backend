using Microsoft.EntityFrameworkCore;
using UFit.Application.Abstractions.Data;
using UFit.Application.Abstractions.Messaging;
using UFit.Domain.Abstractions;
using UFit.Domain.Trainees;

namespace UFit.Application.Challenges.GetByTraineeId;
internal class GetChallengesByTraineeIdQueryHandler(IApplicationDbContext context)
    : IQueryHandler<GetChallengesByTraineeIdQuery, List<ChallengeByTraineeResponse>>
{
    public async Task<Result<List<ChallengeByTraineeResponse>>> Handle(GetChallengesByTraineeIdQuery request, CancellationToken cancellationToken)
    {
        var trainee = await context.Trainees.FirstOrDefaultAsync(trainee => trainee.Id == request.TraineeId);

        if (trainee is null) return Result.Failure<List<ChallengeByTraineeResponse>>(TraineeErrors.NotFound);

        var traineeChallenges = await context
            .TraineeChallenges
            .AsNoTracking()
            .Where(tc => tc.TraineeId == trainee.Id)
            .Join(
                context.Challenges,
                tc => tc.ChallengeId,
                c => c.Id,
                (tc, c) => new ChallengeByTraineeResponse(
                    tc.Id,
                    tc.Status,
                    c.Id,
                    c.Name.Value,
                    c.Description.Value,
                    c.Rewards.Value,
                    c.StartDate,
                    c.EndDate,
                    c.Type))
            .ToListAsync(cancellationToken);

        return traineeChallenges;
    }
}
