using Microsoft.EntityFrameworkCore;
using UFit.Application.Abstractions.Data;
using UFit.Application.Abstractions.Messaging;
using UFit.Domain.Abstractions;

namespace UFit.Application.Rankings.GetAll;
internal class GetAllRankingsQueryHandler : IQueryHandler<GetAllRankingsQuery, List<RankingsResponse>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllRankingsQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Result<List<RankingsResponse>>> Handle(GetAllRankingsQuery request, CancellationToken cancellationToken)
    {
        var trainees = await _applicationDbContext
            .Trainees
            .AsNoTracking()
            .OrderByDescending(trainee => trainee.Points)
            .Select(trainee => new RankingsResponse(
                trainee.Id,
                $"{trainee.Name.First} {trainee.Name.Last}",
                trainee.Points.Value))
            .ToListAsync();

        return trainees;
    }
}
