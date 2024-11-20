using UFit.Domain.Shared;

namespace UFit.Domain.Diets;
public class DietService
{
    public List<Diet> CreateDiet(
        List<Diet> allDiets,
        decimal weight,
        decimal height,
        string gender,
        DateOnly dateOfBirth,
        string fitnessGoal,
        decimal targetWeight)
    {
        // Calcular la edad del usuario
        var age = DateTime.Now.Year - dateOfBirth.Year;

        // Filtrar dietas basadas en el objetivo
        var goalDiets = fitnessGoal switch
        {
            "Aumentar masa muscular" => allDiets.Where(w => w.Goal == new Goal(fitnessGoal)),
            "Bajar nivel de grasa" => allDiets.Where(w => w.Goal == new Goal(fitnessGoal)),
            "Mejorar la resistencia física" => allDiets.Where(w => w.Goal == new Goal(fitnessGoal)),
            _ => throw new Exception("Invalid goal")
        };

        // Filtrar dietas basadas en el rango de calorías adecuado
        var bmi = CalculateBMI(weight, height);
        var caloricNeeds = CalculateCaloricNeeds(bmi, age, gender, fitnessGoal);
        var margin = 200; // Margen de flexibilidad para las calorías
        var suitableDiets = goalDiets.Where(d =>
            (d.Calories.Min - margin) <= caloricNeeds &&
            (d.Calories.Max + margin) >= caloricNeeds);

        // Ordenar dietas por proximidad a los requerimientos del usuario
        var sortedDiets = suitableDiets
            .OrderBy(d => Math.Abs((d.Calories.Min + d.Calories.Max) / 2 - caloricNeeds))
            .ToList();

        return sortedDiets;
    }

    private decimal CalculateBMI(decimal weight, decimal height)
    {
        if (height == 0) throw new ArgumentException("Height cannot be zero.");
        return weight / (height * height);
    }

    private int CalculateCaloricNeeds(decimal bmi, int age, string gender, string fitnessGoal)
    {
        int baseCalories = gender.ToLower() switch
        {
            "male" => 2500,
            "female" => 2000,
            "masculino" => 2500,
            "femenino" => 2000,
            _ => 2200
        };

        // Ajustar las calorías basadas en el objetivo
        return fitnessGoal switch
        {
            "Aumentar masa muscular" => (int)(baseCalories + 500),
            "Bajar nivel de grasa" => (int)(baseCalories - 500),
            "Mejorar la resistencia física" => baseCalories,
            _ => baseCalories
        };
    }
}
