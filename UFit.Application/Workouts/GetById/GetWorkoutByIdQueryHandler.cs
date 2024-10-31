using Microsoft.EntityFrameworkCore;
using UFit.Application.Abstractions.Data;
using UFit.Application.Abstractions.Messaging;
using UFit.Domain.Abstractions;
using UFit.Domain.Workouts;

namespace UFit.Application.Workouts.GetById;
internal class GetWorkoutByIdQueryHandler : IQueryHandler<GetWorkoutByIdQuery, GetWorkoutByIdResponse>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetWorkoutByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Result<GetWorkoutByIdResponse>> Handle(GetWorkoutByIdQuery request, CancellationToken cancellationToken)
    {
        var workout = await _applicationDbContext
            .Workouts
            .FirstOrDefaultAsync(w => w.Id == request.Id);

        if (workout is null)
        {
            return Result.Failure<GetWorkoutByIdResponse>(WorkoutErrors.NotFound);
        }

        return new GetWorkoutByIdResponse(
            workout.Id,
            workout.Name.Value,
            workout.Date,
            workout.Goal.Value,
            workout.DifficultyLevel,
            workout.IsCompleted);
    }
}
