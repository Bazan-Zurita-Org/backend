using UFit.Domain.Abstractions;
using UFit.Domain.Shared;

namespace UFit.Domain.Workouts;
public sealed class Workout : Entity
{
    private readonly List<WorkoutExercise> _workoutExercises = new();
    private Workout() { }
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
    public  IReadOnlyList<WorkoutExercise> WorkoutExercises => _workoutExercises.ToList();

    public static Result<Workout> Create(Name name, DateTime date, Goal goal, DifficultyLevel difficultyLevel)
    {
        var workout = new Workout(Guid.NewGuid(), name, date, goal, difficultyLevel, false);

        workout.RaiseDomainEvent(new WorkoutCreatedDomainEvent(workout.Id));

        return workout;
    }

    public void AddExerciseToWorkout(Guid exerciseId, Set sets, Rep reps)
    {
        _workoutExercises.Add(new WorkoutExercise(Id, exerciseId, sets, reps));
    }
    
}
