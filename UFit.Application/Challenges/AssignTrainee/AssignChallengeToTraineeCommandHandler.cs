using UFit.Application.Abstractions;
using UFit.Application.Abstractions.Messaging;
using UFit.Domain.Abstractions;
using UFit.Domain.Challenges;
using UFit.Domain.Trainees;

namespace UFit.Application.Challenges.AssignTrainee;
internal sealed class AssignChallengeToTraineeCommandHandler : ICommandHandler<AssignChallengeToTraineeCommand, Guid>
{
    private readonly IChallengeRepository _challengeRepository;
    private readonly ITraineeRepository _traineeRepository;
    private readonly ITraineeChallengeRepository _traineeChallengeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AssignChallengeToTraineeCommandHandler(IUnitOfWork unitOfWork, ITraineeRepository traineeRepository, IChallengeRepository challengeRepository, ITraineeChallengeRepository traineeChallengeRepository)
    {
        _unitOfWork = unitOfWork;
        _traineeRepository = traineeRepository;
        _challengeRepository = challengeRepository;
        _traineeChallengeRepository = traineeChallengeRepository;
    }

    public async Task<Result<Guid>> Handle(AssignChallengeToTraineeCommand request, CancellationToken cancellationToken)
    {
        var trainee = await _traineeRepository.FindById(request.ChallengeTrainee.TraineeId);

        if (trainee is null)
        {
            return Result.Failure<Guid>(TraineeErrors.NotFound);
        }

        var challenge = await _challengeRepository.GetByIdAsync(request.ChallengeTrainee.ChallengeId);

        if (challenge is null)
        {
            return Result.Failure<Guid>(ChallengeErrors.NotFound);
        }

        var traineeChallenge = challenge.AddTraineeChallenge(trainee.Id);

        _traineeChallengeRepository.Add(traineeChallenge);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return traineeChallenge.Id;
    }
}
