namespace UFit.Domain.Workouts;
public sealed class WorkoutService
{
    public List<Workout> CreateRoutineAsync(
        List<Workout> allWorkouts,
        decimal weight,
        string gender,
        DateOnly dateOfBirth,
        string fitnessGoal,
        decimal targetWeight)
    {
        var age = DateTime.Now.Year - dateOfBirth.Year;

        var goalWorkouts = fitnessGoal switch
        {
            "Aumentar masa muscular" => allWorkouts.Where(w => w.Goal == new Shared.Goal(fitnessGoal)),
            "Bajar nivel de grasa" => allWorkouts.Where(w => w.Goal == new Shared.Goal(fitnessGoal)),
            "Mejorar la resistencia física" => allWorkouts.Where(w => w.Goal == new Shared.Goal(fitnessGoal)),
            _ => throw new Exception("Invalid goal")
        };

        var workoutsByDifficulty = goalWorkouts
            .Where(w => w.DifficultyLevel <= GetDifficultyLevel(weight, targetWeight, fitnessGoal, gender, age))
            .ToList();


        return workoutsByDifficulty;
    }

    // TODO generate algorithm to get the difficulty level
    private static DifficultyLevel GetDifficultyLevel(decimal weight, decimal targetWeight, string fitnessGoal, string gender, int age)
    {
        //if (fitnessGoal == "Aumentar masa muscular" && weight < targetWeight) return DifficultyLevel.Intermediate;
        //if (fitnessGoal == "Bajar nivel de grasa" && weight > targetWeight) return DifficultyLevel.Intermediate;
        return DifficultyLevel.Advanced;
    }

}
