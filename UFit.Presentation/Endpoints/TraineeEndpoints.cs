using MediatR;
using Microsoft.AspNetCore.Routing;
using UFit.Application.Trainees.GetById;
using UFit.Application.Trainees.Register;

namespace UFit.Presentation.Endpoints;

public static class TraineeEndpoints
{
    public static void AddTraineeApi(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/trainees", async (CreateTraineeRequest request, ISender sender) =>
        {
            var command = new CreateTraineeCommand(request);
            var result = await sender.Send(command);

            if (result.IsFailure)
            {
                return Results.BadRequest(result.Error);
            }
            
            return Results.CreatedAtRoute(
                "GetTraineeById",
                new { Id = result.Value },
                result.Value);
        });

        app.MapGet("/api/trainees/{id}", async (Guid id, ISender sender) =>
        {
            var query = new GetTraineeByIdQuery(id);
            var result = await sender.Send(query);

            if (result.IsFailure)
            {
                return Results.BadRequest(result.Error);
            }

            return Results.Ok(result.Value);
        }).WithName("GetTraineeById");
    }
}
