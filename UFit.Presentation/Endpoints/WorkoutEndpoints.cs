using MediatR;
using UFit.Application.Workouts.Create;

namespace UFit.Presentation.Endpoints;

public static class WorkoutEndpoints
{
    public static void AddWorkoutEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/workouts", async (CreateWorkoutRequest request, ISender sender) =>
        {
            var command = new CreateWorkoutCommand(request);
            var result = await sender.Send(command);

            if (result.IsFailure)
            {
                return Results.BadRequest(result.Error);
            }

            return Results.Ok();
        });
    }
}
