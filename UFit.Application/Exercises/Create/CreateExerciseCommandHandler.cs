using UFit.Application.Abstractions;
using UFit.Application.Abstractions.Messaging;
using UFit.Domain.Abstractions;
using UFit.Domain.Workouts;

namespace UFit.Application.Exercises.Create;
internal class CreateExerciseCommandHandler : ICommandHandler<CreateExerciseCommand>
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateExerciseCommandHandler(IExerciseRepository exerciseRepository, IUnitOfWork unitOfWork)
    {
        _exerciseRepository = exerciseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
    {
        var result = Exercise.Create(
            new Domain.Shared.Name(request.Exercise.Name),
            new Set(request.Exercise.Sets),
            new Rep(request.Exercise.Reps),
            request.Exercise.RestTime,
            new Equipment(request.Exercise.Equipment),
            new MuscleGroup(request.Exercise.MuscleGroup),
            new Instructions(request.Exercise.Instructions));

        _exerciseRepository.Add(result.Value);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
