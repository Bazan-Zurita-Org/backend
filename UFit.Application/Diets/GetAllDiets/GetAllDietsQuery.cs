using UFit.Application.Abstractions.Messaging;
using UFit.Domain.Diets;

namespace UFit.Application.Diets.GetAllDiets;
public sealed record GetAllDietsQuery(Guid TraineeId) : IQuery<NutrionalResponse>;


public sealed record NutrionalResponse(
    List<DietResponse> NutrionalPlan);

public sealed record DietResponse(
    Guid Id,
    string Name,
    string Goal,
    Calories Calories,
    Protein Proteins,
    Carbohydrate Carbohydrates,
    Fat Fats,
    int Duration,
    List<MealResponse> Meals);

public sealed record MealResponse(
    Guid Id,
    MealType Type,
    TimeSpan ScheduleTime,
    List<FoodResponse> Food);


public sealed record FoodResponse(
    Guid Id,
    string Name,
    string Quantity,
    Macronutrients Macronutrients);