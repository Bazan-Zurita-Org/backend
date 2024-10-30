using UFit.Application.Abstractions;
using UFit.Application.Abstractions.Messaging;
using UFit.Domain.Abstractions;
using UFit.Domain.Workouts;

namespace UFit.Application.Workouts.Create;
internal class CreateWorkoutCommandHandler : ICommandHandler<CreateWorkoutCommand>
{
    private readonly IWorkoutRepository _workOutRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateWorkoutCommandHandler(IWorkoutRepository workOutRepository, IUnitOfWork unitOfWork)
    {
        _workOutRepository = workOutRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateWorkoutCommand request, CancellationToken cancellationToken)
    {
        var result = Workout.Create(
            new Domain.Shared.Name(request.Workout.Name),
            request.Workout.Date,
            new Goal(request.Workout.Goal),
            request.Workout.DifficultyLevel);

        _workOutRepository.Add(result.Value);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
