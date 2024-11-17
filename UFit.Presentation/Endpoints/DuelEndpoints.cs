using MediatR;
using UFit.Application.Duels.Create;

namespace UFit.Presentation.Endpoints;

public static class DuelEndpoints
{
    public static void AddDuelEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/duels", async (CreateDueltRequest request, ISender sender) =>
        {
            var command = new CreateDuelCommand(request);
            var result = await sender.Send(command);

            if (result.IsFailure)
            {
                return Results.BadRequest(result.Error);
            }

            return Results.Created();
        });
    }
}
