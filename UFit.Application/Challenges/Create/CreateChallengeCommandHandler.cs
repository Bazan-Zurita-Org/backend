using UFit.Application.Abstractions;
using UFit.Application.Abstractions.Messaging;
using UFit.Domain.Abstractions;
using UFit.Domain.Challenges;
using UFit.Domain.Shared;

namespace UFit.Application.Challenges.Create;
internal sealed class CreateChallengeCommandHandler : ICommandHandler<CreateChallengeCommand>
{
    private readonly IChallengeRepository _challengeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateChallengeCommandHandler(IChallengeRepository challengeRepository, IUnitOfWork unitOfWork)
    {
        _challengeRepository = challengeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateChallengeCommand request, CancellationToken cancellationToken)
    {
        var result = Challenge.Create(
            new Name(request.Challenge.Name),
            new Description(request.Challenge.Description),
            new Points(request.Challenge.Points),
            request.Challenge.StartDate,
            request.Challenge.EndDate,
            request.Challenge.Type);

        if (result.IsFailure)
        {
            return Result.Failure(ChallengeErrors.CantCreate);
        }

        _challengeRepository.Add(result.Value);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
