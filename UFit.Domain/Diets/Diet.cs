using UFit.Domain.Abstractions;
using UFit.Domain.Shared;

namespace UFit.Domain.Diets;
public sealed class Diet : Entity
{
    private readonly List<Meal> _meals = new();
    private Diet(
        Guid id,
        Guid traineeId,
        Calories totalDailyCalories,
        DateTime startDate,
        DateTime endDate) : base(id)
    {
        TraineeId = traineeId;
        TotalDailyCalories = totalDailyCalories;
        StartDate = startDate;
        EndDate = endDate;
    }

    public Guid TraineeId { get; private set; }
    public Calories TotalDailyCalories { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public IReadOnlyList<Meal> Meals => _meals.ToList();

    public static Diet Create(Guid traineeId, Calories totalDailyCalories, DateTime startDate, DateTime endDate)
    {
        var diet = new Diet(Guid.NewGuid(), traineeId, totalDailyCalories, startDate, endDate);

        return diet;
    }

    public void AddMeal(MealType type, Calories calories)
    {
        _meals.Add(new Meal(Guid.NewGuid(), type, calories));
    }

    public void AddFoodItemToMeal(Guid mealId, Name name, Calories calories, Macronutrients macronutrients)
    {
        var meal = _meals.FirstOrDefault(meal => meal.Id == mealId);
        if (meal is null)
        {
            throw new InvalidOperationException("Meal not found");
        }

        meal.AddFoodItem(name, calories, macronutrients);
    }
}
