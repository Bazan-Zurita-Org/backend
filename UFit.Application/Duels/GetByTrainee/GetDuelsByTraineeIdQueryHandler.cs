using Microsoft.EntityFrameworkCore;
using UFit.Application.Abstractions.Data;
using UFit.Application.Abstractions.Messaging;
using UFit.Domain.Abstractions;

namespace UFit.Application.Duels.GetByTrainee;
internal class GetDuelsByTraineeIdQueryHandler(IApplicationDbContext context) 
    : IQueryHandler<GetDuelsByTraineeIdQuery, List<DueltResponse>>
{
    public async Task<Result<List<DueltResponse>>> Handle(GetDuelsByTraineeIdQuery request, CancellationToken cancellationToken)
    {
        var duels = await context.
            Duels.
            AsNoTracking().
            Where(duel => duel.OpponentId == request.TraineeId).
            Join(
            context.Trainees,
            (duel) => duel.ChallengerId,
            (trainee) => trainee.Id,
            (duel, trainee) => new DuelTraineeResult(
                trainee.Id,
                $"{trainee.Name.First} {trainee.Name.Last}",
                duel.Id,
                duel.ChallengeText!,
                duel.StartDate,
                duel.EndDate))
            .ToListAsync(cancellationToken);

        var duelsResponse = duels.Select(duelTrainee => new DueltResponse(
            duelTrainee.DuelId,
            duelTrainee.ChallengerName,
            duelTrainee.ChallengeText!,
            duelTrainee.StartDate,
            duelTrainee.EndDate)).ToList();

        return duelsResponse;
    }

    private record DuelTraineeResult(Guid TraineeId, string ChallengerName, Guid DuelId, string ChallengeText, DateTime StartDate, DateTime EndDate);
}
