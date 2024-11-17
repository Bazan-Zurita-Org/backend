using MediatR;
using UFit.Application.Abstractions;
using UFit.Domain.Trainees;

namespace UFit.Application.Challenges.Complete;
internal class ChallengeCompletedEventHandler : INotificationHandler<ChallengeCompletedEvent>
{
    private readonly ITraineeRepository _traineeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChallengeCompletedEventHandler(ITraineeRepository traineeRepository, IUnitOfWork unitOfWork)
    {
        _traineeRepository = traineeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(ChallengeCompletedEvent notification, CancellationToken cancellationToken)
    {
        var trainee = await _traineeRepository.FindById(notification.TraineeId);

        if (trainee is null) return;

        trainee.AddPoints(notification.Points);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
