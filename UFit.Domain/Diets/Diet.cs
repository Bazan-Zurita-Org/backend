using UFit.Domain.Abstractions;
using UFit.Domain.Shared;

namespace UFit.Domain.Diets;
public sealed class Diet : Entity
{
    private readonly List<Meal> _meals = new();
    private Diet() { }
    private Diet(
        Guid id,
        Name name,
        Goal goal,
        Calories calories,
        Protein proteins,
        Carbohydrate carbohydrates,
        Fat fats,
        Duration duration) : base(id)
    {
        Name = name;
        Goal = goal;
        Calories = calories;
        Proteins = proteins;
        Carbohydrates = carbohydrates;
        Fats = fats;
        Duration = duration;
    }

    public Name Name { get; private set; }
    public Goal Goal { get; private set; }
    public Calories Calories { get; private set; }
    public Protein Proteins { get; private set; }
    public Carbohydrate Carbohydrates { get; private set; }
    public Fat Fats { get; private set; }
    public Duration Duration { get; private set; }
    public IReadOnlyList<Meal> Meals => _meals.ToList();

}
