using UFit.Application.Abstractions.Messaging;

namespace UFit.Application.Duels.Accept;
public sealed record AcceptDuelCommand(Guid DuelId) : ICommand;
