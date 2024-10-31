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
            .AsNoTracking()
            .Where(w => w.Id == request.Id)
            .Select(workout => new GetWorkoutByIdResponse(
                workout.Id,
                workout.Name.Value,
                workout.Date,
                workout.Goal.Value,
                workout.DifficultyLevel,
                workout.IsCompleted,
                _applicationDbContext.WorkoutExercises
                .Where(we => we.WorkoutId == workout.Id)
                .Join(
                    _applicationDbContext.Exercises,
                    we => we.ExerciseId,
                    e => e.Id,
                    (we, e) => new ExerciseResponse(
                        e.Id,
                        e.Name.Value,
                        we.Sets.Value,
                        we.Reps.Value,
                        e.RestTime,
                        e.Equipment.Value,
                        e.MuscleGroup.Value,
                        e.Instructions.Value)).ToList()
                )
            )
            .FirstOrDefaultAsync();

        if (workout is null)
        {
            return Result.Failure<GetWorkoutByIdResponse>(WorkoutErrors.NotFound);
        }

        return workout;
    }
}
