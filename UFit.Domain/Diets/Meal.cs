using UFit.Domain.Abstractions;
using UFit.Domain.Shared;

namespace UFit.Domain.Diets;
public sealed class Meal : Entity
{
    private readonly List<FoodItem> _foodItems = new List<FoodItem>();
    private Meal() { }
    internal Meal(Guid id, Guid dietId, MealType type, TimeSpan scheduleTime) : base(id)
    {
        DietId = dietId;
        Type = type;
        ScheduleTime = scheduleTime;
    }

    public Guid DietId { get; private set; }
    public MealType Type { get; private set; }
    public TimeSpan ScheduleTime { get; private set; }
    public IReadOnlyList<FoodItem> FoodItems => _foodItems.ToList();
}
