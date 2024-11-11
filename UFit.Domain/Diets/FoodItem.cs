using UFit.Domain.Abstractions;
using UFit.Domain.Shared;

namespace UFit.Domain.Diets;
public sealed class FoodItem : Entity
{
    private FoodItem() { }
    internal FoodItem(
        Guid id,
        Guid mealId,
        Name name,
        Macronutrients macronutrients,
        Quantity quantity) : base(id)
    {
        MealId = mealId;
        Name = name;
        Macronutrients = macronutrients;
        Quantity = quantity;
    }

    public Guid MealId { get; private set; }
    public Name Name { get; private set; }
    public Macronutrients Macronutrients { get; private set; }
    public Quantity Quantity { get; private set; }

}