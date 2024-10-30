using UFit.Domain.Abstractions;

namespace UFit.Domain.Trainees;
public class TraineeErrors
{
    public readonly static Error NotFound = new(
        "Trainee.NotFound", "Trainee with given Id was not found");
}
