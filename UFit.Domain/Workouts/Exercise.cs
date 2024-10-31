using UFit.Domain.Abstractions;
using UFit.Domain.Shared;

namespace UFit.Domain.Workouts;
public sealed class Exercise : Entity
{
    private Exercise() { }
    internal Exercise(
        Guid id,
        Name name,
        Set sets,
        Rep reps,
        TimeSpan restTime,
        Equipment equipment,
        MuscleGroup muscleGroup,
        Instructions instructions) : base(id)
    {
        Name = name;
        Sets = sets;
        Reps = reps;
        RestTime = restTime;
        Equipment = equipment;
        MuscleGroup = muscleGroup;
        Instructions = instructions;
    }

    public Name Name { get; private set; }
    public Set Sets { get; private set; }
    public Rep Reps { get; private set; }
    public TimeSpan RestTime { get; private set; }
    public Equipment Equipment { get; private set; }
    public MuscleGroup MuscleGroup { get; private set; }
    public Instructions Instructions { get; private set; }

    public static Result<Exercise> Create(
        Name name,
        Set sets,
        Rep reps,
        TimeSpan restTime,
        Equipment equipment,
        MuscleGroup muscleGroup,
        Instructions instructions)
    {
        var exercise = new Exercise(Guid.NewGuid(), name, sets, reps, restTime, equipment, muscleGroup, instructions);

        return exercise;
    }
}
