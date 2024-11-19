using MediatR;
using Microsoft.EntityFrameworkCore;
using UFit.Application.Abstractions;
using UFit.Application.Abstractions.Data;
using UFit.Domain.Trainees;
using UFit.Domain.Workouts;

namespace UFit.Application.Exercises.Create;

internal class TraineeCreatedDomainEventHandler(
    IApplicationDbContext context,
    WorkoutService workoutService,
    IUnitOfWork unitOfWork) 
    : INotificationHandler<TraineeCreatedDomainEvent>
{
    public async Task Handle(TraineeCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var trainee = await context.Trainees.FirstOrDefaultAsync(trainee => trainee.Id == notification.Id, cancellationToken);

        if (trainee is null) return;

        var workouts = await context.Workouts.Include(w => w.WorkoutExercises).ToListAsync(cancellationToken);

        var routines = workoutService.CreateRoutine(
            workouts,
            trainee.Measurements.Weight,
            trainee.Measurements.Height,
            trainee.Gender.Value,
            trainee.DateOfBirth,
            trainee.FitnessGoal.Value,
            trainee.TargetWeight.Value);

        List<WorkoutTrainee> routineTrainees = [];

        foreach (Workout workout in routines)
        {
            routineTrainees.Add(new WorkoutTrainee(
                workout.Id,
                trainee.Id,
                false));
        }

        await context.WorkoutTrainees.AddRangeAsync(routineTrainees);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
