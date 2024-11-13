using UFit.Application.Abstractions;
using UFit.Application.Abstractions.Messaging;
using UFit.Domain.Abstractions;
using UFit.Domain.Challenges;
using UFit.Domain.Trainees;

namespace UFit.Application.Challenges.AssignTrainee;
internal sealed class AssignChallengeToTraineeCommandHandler : ICommandHandler<AssignChallengeToTraineeCommand>
{
    private readonly IChallengeRepository _challengeRepository;
    private readonly ITraineeRepository _traineeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AssignChallengeToTraineeCommandHandler(IUnitOfWork unitOfWork, ITraineeRepository traineeRepository, IChallengeRepository challengeRepository)
    {
        _unitOfWork = unitOfWork;
        _traineeRepository = traineeRepository;
        _challengeRepository = challengeRepository;
    }

    public async Task<Result> Handle(AssignChallengeToTraineeCommand request, CancellationToken cancellationToken)
    {
        var trainee = await _traineeRepository.FindById(request.ChallengeTrainee.TraineeId);

        if (trainee is null)
        {
            return Result.Failure(TraineeErrors.NotFound);
        }

        var challenge = await _challengeRepository.GetByIdAsync(request.ChallengeTrainee.ChallengeId);

        if (challenge is null)
        {
            return Result.Failure(ChallengeErrors.NotFound);
        }

        challenge.AddTraineeChallenge(trainee.Id);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
