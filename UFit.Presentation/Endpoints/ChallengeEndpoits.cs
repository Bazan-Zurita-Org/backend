using MediatR;
using UFit.Application.Challenges.AssignTrainee;
using UFit.Application.Challenges.Complete;

namespace UFit.Presentation.Endpoints;

public static class ChallengeEndpoits
{
    public static void AddChallengeEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/challenges/assign", async (AssignChallengeToTraineeRequest request, ISender sender) =>
        {
            var command = new AssignChallengeToTraineeCommand(request);
            var result = await sender.Send(command);

            if (result.IsFailure)
            {
                return Results.BadRequest(result.Error);
            }

            return Results.Ok(result.Value);
        });

        app.MapPost("api/challenges/complete", async (CompleteChallengeRequest request, ISender sender) =>
        {
            var command = new CompleteChallengeCommand(request);
            var result = await sender.Send(command);

            if (result.IsFailure)
            {
                return Results.BadRequest(result.Error);
            }

            return Results.Ok();
        });
    }
}
