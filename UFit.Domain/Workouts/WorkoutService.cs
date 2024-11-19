namespace UFit.Domain.Workouts;
public sealed class WorkoutService
{
    public List<Workout> CreateRoutine(
        List<Workout> allWorkouts,
        decimal weight,
        decimal heigth,
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

        var difficultyLevel = GetDifficultyLevel(weight, heigth, targetWeight, fitnessGoal, gender, age);

        var workoutsByDifficulty = goalWorkouts
            .Where(w => w.DifficultyLevel <= difficultyLevel)
            .ToList();

        return workoutsByDifficulty;
    }

    private static DifficultyLevel GetDifficultyLevel(decimal weight, decimal height, decimal targetWeight, string fitnessGoal, string gender, int age)
    {
        // Calcular el índice de masa corporal (IMC)
        decimal bmi = CalculateBMI(weight, height);

        // Determinar el nivel de actividad física
        var activityLevel = GetActivityLevel(age);

        // Ajustar el nivel de dificultad según el objetivo de acondicionamiento físico
        return fitnessGoal switch
        {
            "Aumentar masa muscular" => (bmi < 18.5m || activityLevel == "Bajo") ? DifficultyLevel.Beginner : DifficultyLevel.Intermediate,
            "Bajar nivel de grasa" => (bmi >= 25m || activityLevel == "Bajo") ? DifficultyLevel.Beginner : DifficultyLevel.Intermediate,
            "Mejorar la resistencia física" => (activityLevel == "Bajo") ? DifficultyLevel.Beginner : DifficultyLevel.Intermediate,
            _ => DifficultyLevel.Advanced
        };
    }

    private static decimal CalculateBMI(decimal weight, decimal height)
    {
        return weight / (height * height);
    }

    private static string GetActivityLevel(int age)
    {
        // Nivel de actividad basado en la edad
        if (age <= 30) return "Alto";
        if (age <= 50) return "Medio";
        return "Bajo";
    }
}
