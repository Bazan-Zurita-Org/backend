using MediatR;
using UFit.Application.Workouts.AddExercise;
using UFit.Application.Workouts.Create;
using UFit.Application.Workouts.GetById;

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

            return Results.Created("GetWorkoutById", default);
        });

        app.MapGet("api/workouts/{id}", async (Guid id, ISender sender) =>
        {
            var query = new GetWorkoutByIdQuery(id);
            var result = await sender.Send(query);

            if (result.IsFailure)
            {
                return Results.BadRequest(result.Error);
            }

            return Results.Ok(result.Value);
        }).WithName("GetWorkoutById");

        app.MapPost("api/workouts/exercise", async (AddExerciseToWorkoutRequest request, ISender sender) =>
        {
            var command = new AddExerciseToWorkoutCommand(request);
            var result = await sender.Send(command);

            if (result.IsFailure)
            {
                return Results.BadRequest(result.Error);
            }

            return Results.Ok();
        });
    }
}
