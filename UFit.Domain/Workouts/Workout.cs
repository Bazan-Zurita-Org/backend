using UFit.Domain.Abstractions;
using UFit.Domain.Shared;

namespace UFit.Domain.Workouts;
public sealed class Workout : Entity
{
    private readonly List<Exercise> _exercises = new();
    private Workout(
        Guid id,
        Name name,
        DateTime date,
        Goal goal,
        DifficultyLevel difficultyLevel,
        bool isCompleted) : base(id)
    {
        Name = name;
        Date = date;
        Goal = goal;
        DifficultyLevel = difficultyLevel;
        IsCompleted = isCompleted;
    }

    public Name Name { get; private set; }
    public DateTime Date { get; private set; }
    public Goal Goal { get; private set; }
    public DifficultyLevel DifficultyLevel { get; private set; }
    public bool IsCompleted { get; private set; }
    public  IReadOnlyList<Exercise> Exercises => _exercises.ToList();

    public static Workout Create(Name name, DateTime date, Goal goal, DifficultyLevel difficultyLevel)
    {
        var workout = new Workout(Guid.NewGuid(), name, date, goal, difficultyLevel, false);

        workout.RaiseDomainEvent(new WorkoutCreatedDomainEvent(workout.Id));

        return workout;
    }

    public void AddExercise(
        Name name,
        Set sets,
        Rep reps,
        TimeSpan restTime,
        Equipment equipment,
        MuscleGroup muscleGroup,
        Instructions instructions)
    {
        _exercises.Add(new Exercise(
            Guid.NewGuid(),
            name,
            sets,
            reps,
            restTime,
            equipment,
            muscleGroup,
            instructions));
    }
}
