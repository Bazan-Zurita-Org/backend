using Microsoft.EntityFrameworkCore;
using UFit.Application.Abstractions.Data;
using UFit.Application.Abstractions.Messaging;
using UFit.Domain.Abstractions;
using UFit.Domain.Diets;
using UFit.Domain.Trainees;

namespace UFit.Application.Diets.GetAllDiets;
internal class GetAllDietsQueryHandler(IApplicationDbContext context) 
    : IQueryHandler<GetAllDietsQuery, NutrionalResponse>
{
    public async Task<Result<NutrionalResponse>> Handle(GetAllDietsQuery request, CancellationToken cancellationToken)
    {
        var trainee = await context.Trainees.FirstOrDefaultAsync(trainee => trainee.Id == request.TraineeId);

        if (trainee is null) return Result.Failure<NutrionalResponse>(TraineeErrors.NotFound);


        var dietTrainee = context
            .DietTrainees
            .AsNoTracking()
            .Where(dt => dt.TraineeId == trainee.Id)
            .Join(
            context.Diets,
            dt => dt.DietId,
            d => d.Id,
            (dt, d) => new DietResponse(
                d.Id,
                d.Name.Value,
                d.Goal.Value,
                d.Calories,
                d.Proteins,
                d.Carbohydrates,
                d.Fats,
                d.Duration.Value,
                d.Meals.Select(meal => new MealResponse(
                    meal.Id, 
                    meal.Type, 
                    meal.ScheduleTime, 
                    meal.FoodItems.Select(food => new FoodResponse(
                        food.Id,
                        food.Name.Value,
                        food.Quantity.Value,
                        food.Macronutrients))
                    .ToList()))
                .ToList())
            ).ToList();

        return new NutrionalResponse(dietTrainee);
    }
}
