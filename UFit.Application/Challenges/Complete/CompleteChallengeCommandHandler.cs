using MediatR;
using UFit.Application.Abstractions;
using UFit.Application.Abstractions.Messaging;
using UFit.Domain.Abstractions;
using UFit.Domain.Challenges;
using UFit.Domain.Trainees;

namespace UFit.Application.Challenges.Complete;
internal class CompleteChallengeCommandHandler : ICommandHandler<CompleteChallengeCommand>
{
    private readonly IChallengeRepository _challengeRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPublisher _publisher;

    public CompleteChallengeCommandHandler(IChallengeRepository challengeRepository, IUnitOfWork unitOfWork, IPublisher publisher)
    {
        _challengeRepository = challengeRepository;
        _unitOfWork = unitOfWork;
        _publisher = publisher;
    }

    public async Task<Result> Handle(CompleteChallengeCommand request, CancellationToken cancellationToken)
    {
        var challenge = await _challengeRepository.GetByTraineeChallengeIdAsync(request.TraineeChallenge.TraineeChallengeId);

        if (challenge is null) return Result.Failure<Guid>(ChallengeErrors.NotFound);

        var traineeChallenge = challenge.TraineeChallenges.FirstOrDefault(tc => tc.Id == request.TraineeChallenge.TraineeChallengeId);

        if (traineeChallenge is null) return Result.Failure<Guid>(TraineeErrors.NotFound);

        challenge.CompleteChallenge(request.TraineeChallenge.TraineeChallengeId);

        await _unitOfWork.SaveChangesAsync();

        await _publisher.Publish(
            new ChallengeCompletedEvent(traineeChallenge.TraineeId, challenge.Rewards.Value),
            cancellationToken);

        return Result.Success();
    }
}
