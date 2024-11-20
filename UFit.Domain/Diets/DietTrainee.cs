using UFit.Domain.Abstractions;

namespace UFit.Domain.Diets;
public sealed class DietTrainee
{
    private DietTrainee() { }
    public DietTrainee(Guid dietId, Guid traineeId, bool isCompleted)
    {
        DietId = dietId;
        TraineeId = traineeId;
        IsCompleted = isCompleted;
    }
    public Guid DietId { get; private set; }
    public Guid TraineeId { get; private set; }
    public bool IsCompleted { get; private set; }

    public Result CompleteDiet()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;

            return Result.Success();
        }

        return Result.Failure(new Error("DietTrainee.Completed", "Diet already completed"));
    }
}
