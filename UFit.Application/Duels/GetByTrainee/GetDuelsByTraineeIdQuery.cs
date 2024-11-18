using UFit.Application.Abstractions.Messaging;

namespace UFit.Application.Duels.GetByTrainee;
public sealed record GetDuelsByTraineeIdQuery(Guid TraineeId) : IQuery<List<DueltResponse>>;
    
public sealed record DueltResponse(
    Guid DuelId,
    string ChallengerName,
    string ChallengeText,
    DateTime StartDate,
    DateTime EndDate);