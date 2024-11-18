using Microsoft.EntityFrameworkCore;
using UFit.Application.Abstractions.Data;
using UFit.Application.Abstractions.Messaging;
using UFit.Domain.Abstractions;
using UFit.Domain.Duels;
using UFit.Domain.Trainees;

namespace UFit.Application.Duels.GetByTrainee;
internal class GetDuelsByTraineeIdQueryHandler(IApplicationDbContext context) 
    : IQueryHandler<GetDuelsByTraineeIdQuery, List<DueltResponse>>
{
    public async Task<Result<List<DueltResponse>>> Handle(GetDuelsByTraineeIdQuery request, CancellationToken cancellationToken)
    {
        var duels = context.Duels.Where(duel => duel.OpponentId == request.TraineeId);

        if (duels is null) return Result.Failure<List<DueltResponse>>(DuelErrrors.NotFound);

        var trainee = await context.Trainees.FindAsync(request.TraineeId);

        if (trainee is null) return Result.Failure<List<DueltResponse>>(TraineeErrors.NotFound);

        var duelsResponse = await duels.Select(duel => new DueltResponse(
            duel.Id,
            $"{trainee.Name.First} {trainee.Name.Last}",
            duel.ChallengeText!,
            duel.StartDate,
            duel.EndDate)).ToListAsync();

        return duelsResponse;
    }
}
