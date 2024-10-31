using Microsoft.EntityFrameworkCore;
using UFit.Application.Abstractions.Data;
using UFit.Application.Abstractions.Messaging;
using UFit.Application.Workouts.GetById;
using UFit.Domain.Abstractions;

namespace UFit.Application.Exercises.GetAll;
internal class GetAllExerciseQueryHandler : IQueryHandler<GetAllExerciseQuery, List<ExerciseResponse>>
{
    private readonly IApplicationDbContext _applicationDdContext;

    public GetAllExerciseQueryHandler(IApplicationDbContext applicationDdContext)
    {
        _applicationDdContext = applicationDdContext;
    }

    public async Task<Result<List<ExerciseResponse>>> Handle(GetAllExerciseQuery request, CancellationToken cancellationToken)
    {
        var exercises = await _applicationDdContext
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

        return exercises;
    }
}
