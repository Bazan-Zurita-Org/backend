using UFit.Application.Abstractions;
using UFit.Application.Abstractions.Messaging;
using UFit.Domain.Abstractions;
using UFit.Domain.Duels;

namespace UFit.Application.Duels.Create;
internal class CreateDuelCommanHandler : ICommandHandler<CreateDuelCommand, Guid>
{
    private readonly IDuelRepository _duelRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDuelCommanHandler(IDuelRepository duelRepository, IUnitOfWork unitOfWork)
    {
        _duelRepository = duelRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateDuelCommand request, CancellationToken cancellationToken)
    {
        var result = Duel.Create(
            request.Duel.ChallengerId,
            request.Duel.OpponentId,
            request.Duel.ChallengeId,
            request.Duel.StartDate,
            request.Duel.EndDate,
            request.Duel.ChallengeText);

        _duelRepository.Add(result.Value);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result.Value.Id;
    }
}
