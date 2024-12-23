﻿using Microsoft.EntityFrameworkCore;
using UFit.Application.Abstractions.Data;
using UFit.Application.Abstractions.Messaging;
using UFit.Application.Workouts.GetById;
using UFit.Domain.Abstractions;
using UFit.Domain.Trainees;
using UFit.Domain.Workouts;

namespace UFit.Application.Workouts.GetRoutine;
internal sealed class GetRoutineQueryHandler : IQueryHandler<GetRoutineQuery, RoutineResponse>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly WorkoutService _workoutService;

    public GetRoutineQueryHandler(IApplicationDbContext applicationDbContext, WorkoutService workoutService)
    {
        _applicationDbContext = applicationDbContext;
        _workoutService = workoutService;
    }

    public async Task<Result<RoutineResponse>> Handle(GetRoutineQuery request, CancellationToken cancellationToken)
    {
        var trainee = await _applicationDbContext.Trainees.FirstOrDefaultAsync(t => t.Id == request.TraineeId);

        if (trainee is null) return Result.Failure<RoutineResponse>(TraineeErrors.NotFound);

        var workoutsTrainee = _applicationDbContext.WorkoutTrainees.Where(wt => wt.TraineeId == trainee.Id);

        var workoutsResponse = workoutsTrainee
            .Join(
            _applicationDbContext.Workouts,
            (wt) => wt.WorkoutId,
            (workout) => workout.Id,
            (wt, workout) => new GetTraineeWorkoutsResponse(
                workout.Id,
                workout.Name.Value,
                workout.Date,
                workout.Goal.Value,
                workout.DifficultyLevel,
                wt.IsCompleted,
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
                        e.Instructions.Value)).ToList()))
            .ToList();

        var response = new RoutineResponse(workoutsResponse);

        return response;
    }
}
