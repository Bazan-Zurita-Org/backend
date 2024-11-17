using Microsoft.EntityFrameworkCore;
using UFit.Application.Abstractions.Data;
using UFit.Application.Abstractions.Messaging;
using UFit.Domain.Abstractions;

namespace UFit.Application.Trainees.GetAll;
internal class GetAllTraineesQueryHandler : IQueryHandler<GetAllTraineesQuery, List<GetAllTraineesResponse>>
{
    private readonly IApplicationDbContext context;

    public GetAllTraineesQueryHandler(IApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<Result<List<GetAllTraineesResponse>>> Handle(GetAllTraineesQuery request, CancellationToken cancellationToken)
    {
        return await context.Trainees
            .Select(trainee => new GetAllTraineesResponse(trainee.Id, $"{trainee.Name.First} {trainee.Name.Last}"))
            .ToListAsync();
    }
}
