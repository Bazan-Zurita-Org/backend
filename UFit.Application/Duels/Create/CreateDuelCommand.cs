using UFit.Application.Abstractions.Messaging;

namespace UFit.Application.Duels.Create;
public sealed record CreateDuelCommand(CreateDueltRequest Duel) : ICommand<Guid>;
