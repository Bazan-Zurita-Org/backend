using MediatR;
using UFit.Application.Rankings.GetAll;

namespace UFit.Presentation.Endpoints;

public static class RankingEndpoints
{
    public static void AddRankingEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/rankings", async (ISender sender) =>
        {
            var query = new GetAllRankingsQuery();
            var result = await sender.Send(query);

            return Results.Ok(result.Value);
        });
    }
}
