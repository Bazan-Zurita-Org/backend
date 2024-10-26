using UFit.Domain.Abstractions;
using UFit.Domain.Shared;

namespace UFit.Domain.Diets;
public sealed class Meal : Entity
{
    private readonly List<FoodItem> _foodItems = new();
    internal Meal(Guid id, MealType type, Calories calories) : base(id)
    {
        Type = type;
        Calories = calories;
    }

    public MealType Type { get; private set; }
    public Calories Calories { get; private set; }
    public IReadOnlyList<FoodItem> FoodItems => _foodItems.ToList();

    internal void AddFoodItem(Name name, Calories calories, Macronutrients macronutrients)
    {
        _foodItems.Add(new FoodItem(Guid.NewGuid(), name, calories, macronutrients));
    }

}
