using UFit.Application.Abstractions;
using UFit.Application.Abstractions.Messaging;
using UFit.Domain.Abstractions;
using UFit.Domain.Workouts;

namespace UFit.Application.Workouts.AddExercise;
internal class AddExerciseToWorkoutCommandHandler : ICommandHandler<AddExerciseToWorkoutCommand>
{
    private readonly IWorkoutRepository _workoutRepository;
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddExerciseToWorkoutCommandHandler(IWorkoutRepository workoutRepository, IUnitOfWork unitOfWork, IExerciseRepository exerciseRepository)
    {
        _workoutRepository = workoutRepository;
        _unitOfWork = unitOfWork;
        _exerciseRepository = exerciseRepository;
    }

    public async Task<Result> Handle(AddExerciseToWorkoutCommand request, CancellationToken cancellationToken)
    {
        var workout = await _workoutRepository.findById(request.ExerciseWorkout.WorkoutId);

        if (workout is null)
        {
            return Result.Failure(WorkoutErrors.NotFound);
        }

        var exercise = await _exerciseRepository.findById(request.ExerciseWorkout.ExerciseId);

        if (exercise is null)
        {
            return Result.Failure(ExerciseErrors.NotFound);
        }

        workout.AddExerciseToWorkout(exercise.Id, new Set(request.ExerciseWorkout.Sets), new Rep(request.ExerciseWorkout.Reps));

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
