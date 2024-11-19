using UFit.Domain.Abstractions;

namespace UFit.Domain.Workouts;
public sealed class WorkoutTrainee
{
    private WorkoutTrainee() { }
    public WorkoutTrainee(
        Guid workoutId,
        Guid traineeId,
        bool isCompleted)
    {
        WorkoutId = workoutId;
        TraineeId = traineeId;
        IsCompleted = isCompleted;
    }

    public Guid WorkoutId { get; private set; }
    public Guid TraineeId { get; private set; }
    public bool IsCompleted { get; private set; }

    public Result CompleteWorkout()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;

            return Result.Success();
        }
       
        return Result.Failure(new Error("WorkoutTrainee.Completed", "Workout already completed"));
    }
}
