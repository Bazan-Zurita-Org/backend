using UFit.Domain.Abstractions;
using UFit.Domain.Shared;

namespace UFit.Domain.Diets;
public sealed class FoodItem : Entity
{
    internal FoodItem(
        Guid id,
        Name name,
        Calories calories,
        Macronutrients macronutrients) : base(id)
    {
        Name = name;
        Calories = calories;
        Macronutrients = macronutrients;
    }

    public Name Name { get; private set; }
    public Calories Calories { get; private set; }
    public Macronutrients Macronutrients { get; private set; }
}
