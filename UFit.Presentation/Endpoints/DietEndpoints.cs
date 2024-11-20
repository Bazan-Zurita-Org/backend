using MediatR;
using UFit.Application.Diets.GetAllDiets;

namespace UFit.Presentation.Endpoints;

public static class DietEndpoints
{
    public static void AddDietEntpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/diets/trainee/{id}", async (Guid id, ISender sender) =>
        {
            var query = new GetAllDietsQuery(id);
            var result = await sender.Send(query);

            return Results.Ok(result.Value);
        });
    }
}
