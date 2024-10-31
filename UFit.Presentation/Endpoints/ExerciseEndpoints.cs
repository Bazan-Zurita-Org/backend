using MediatR;
using UFit.Application.Exercises.Create;

namespace UFit.Presentation.Endpoints;

public static class ExerciseEndpoints
{
    public static void AddExerciseEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/exercises", async (CreateExerciseRequest request, ISender sender) =>
        {
            var command = new CreateExerciseCommand(request);
            var result = await sender.Send(command);

            if (result.IsFailure)
            {
                return Results.BadRequest(result.Error);
            }

            return Results.Ok();
        });
    }
}
