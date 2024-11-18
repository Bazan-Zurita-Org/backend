using UFit.Application.Abstractions;
using UFit.Application.Abstractions.Messaging;
using UFit.Domain.Abstractions;
using UFit.Domain.Duels;

namespace UFit.Application.Duels.Accept;
internal sealed class AcceptDuelCommandHandler : ICommandHandler<AcceptDuelCommand>
{
    private readonly IDuelRepository _duelRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AcceptDuelCommandHandler(IDuelRepository duelRepository, IUnitOfWork unitOfWork)
    {
        _duelRepository = duelRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(AcceptDuelCommand request, CancellationToken cancellationToken)
    {
        var duel = await _duelRepository.GetByIdAsync(request.DuelId);

        if (duel is null) return Result.Failure(DuelErrrors.NotFound);

        duel.Accept();

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
