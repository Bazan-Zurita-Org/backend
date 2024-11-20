using MediatR;
using Microsoft.AspNetCore.Routing;
using UFit.Application.Challenges.GetByTraineeId;
using UFit.Application.Challenges.GetTraineeChallenges;
using UFit.Application.Duels.GetByTrainee;
using UFit.Application.Trainees.GetAll;
using UFit.Application.Trainees.GetById;
using UFit.Application.Trainees.Login;
using UFit.Application.Trainees.Register;
using UFit.Application.Workouts.GetRoutine;

namespace UFit.Presentation.Endpoints;

public static class TraineeEndpoints
{
    public static void AddTraineeApi(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/trainees", async (CreateTraineeRequest request, ISender sender) =>
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

        app.MapPost("api/login", async (LoginCommand request, ISender sender) =>
        {
            var command = new LoginCommand(request.Email, request.Password);
            var result = await sender.Send(command);

            if (result.IsFailure)
            {
                return Results.BadRequest(result.Error);
            }

            return Results.Ok(result.Value);
        });

        app.MapGet("api/trainees/{id}", async (Guid id, ISender sender) =>
        {
            var query = new GetTraineeByIdQuery(id);
            var result = await sender.Send(query);

            if (result.IsFailure)
            {
                return Results.BadRequest(result.Error);
            }

            return Results.Ok(result.Value);
        }).WithName("GetTraineeById");

        app.MapGet("api/trainees/{id}/routine", async (Guid id, ISender sender) =>
        {
            var query = new GetRoutineQuery(id);
            var result = await sender.Send(query);

            return Results.Ok(result.Value);
        });

        app.MapGet("api/trainees/{id}/challenges", async (Guid id, ISender sender) =>
        {
            var query = new GetTraineeChallengesQuery(id);
            var result = await sender.Send(query);

            return Results.Ok(result.Value);
        });

        app.MapGet("api/trainees/{id}/challenges/accepted", async (Guid id, ISender sender) =>
        {
            var query = new GetChallengesByTraineeIdQuery(id);
            var result = await sender.Send(query);

            return Results.Ok(result.Value);
        });

        app.MapGet("api/trainees", async (ISender sender) =>
        {
            var query = new GetAllTraineesQuery();
            var result = await sender.Send(query);

            return result.Value;
        });

        app.MapGet("api/trainees/{id}/duels", async (Guid id, ISender sender) =>
        {
            var query = new GetDuelsByTraineeIdQuery(id);
            var result = await sender.Send(query);

            if (result.IsFailure) return Results.NotFound(result.Error);

            return Results.Ok(result.Value);
        });
    }
}
