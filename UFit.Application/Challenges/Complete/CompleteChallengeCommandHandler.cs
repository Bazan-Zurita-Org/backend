using UFit.Application.Abstractions;
using UFit.Application.Abstractions.Messaging;
using UFit.Domain.Abstractions;
using UFit.Domain.Challenges;

namespace UFit.Application.Challenges.Complete;
internal class CompleteChallengeCommandHandler : ICommandHandler<CompleteChallengeCommand>
{
    private readonly IChallengeRepository _challengeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CompleteChallengeCommandHandler(IChallengeRepository challengeRepository, IUnitOfWork unitOfWork)
    {
        _challengeRepository = challengeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CompleteChallengeCommand request, CancellationToken cancellationToken)
    {
        var challenge = await _challengeRepository.GetByTraineeChallengeIdAsync(request.TraineeChallenge.TraineeChallengeId);

        if (challenge is null) return Result.Failure<Guid>(ChallengeErrors.NotFound);

        challenge.CompleteChallenge(request.TraineeChallenge.TraineeChallengeId);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
