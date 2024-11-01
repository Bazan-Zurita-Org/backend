using Microsoft.EntityFrameworkCore;
using UFit.Application.Abstractions.Cache;
using UFit.Application.Abstractions.Data;
using UFit.Application.Abstractions.Messaging;
using UFit.Application.Workouts.GetById;
using UFit.Domain.Abstractions;

namespace UFit.Application.Exercises.GetAll;
internal class GetAllExerciseQueryHandler : IQueryHandler<GetAllExerciseQuery, List<ExerciseResponse>>
{
    private readonly IApplicationDbContext _applicationDdContext;
    private readonly ICacheService _cacheService;

    public GetAllExerciseQueryHandler(IApplicationDbContext applicationDdContext, ICacheService cacheService)
    {
        _applicationDdContext = applicationDdContext;
        _cacheService = cacheService;
    }

    public async Task<Result<List<ExerciseResponse>>> Handle(GetAllExerciseQuery request, CancellationToken cancellationToken)
    {
        var key = "exercises";

        List<ExerciseResponse> exercises = [];

        var exercisesCached = await _cacheService.GetAsync<List<ExerciseResponse>>(key, cancellationToken);

        if (exercisesCached == null)
        {
            exercises = await _applicationDdContext
            .Exercises
            .AsNoTracking()
            .Select(exercise => new ExerciseResponse(
                exercise.Id,
                exercise.Name.Value,
                exercise.Sets.Value,
                exercise.Reps.Value,
                exercise.RestTime,
                exercise.Equipment.Value,
                exercise.MuscleGroup.Value,
                exercise.Instructions.Value))
            .ToListAsync();

            await _cacheService.SetAsync(key, exercises);

            return exercises;
        }

        return exercisesCached;
    }
}
