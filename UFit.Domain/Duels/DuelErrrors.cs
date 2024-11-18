using UFit.Domain.Abstractions;

namespace UFit.Domain.Duels;
public static class DuelErrrors
{
    public static readonly Error NotFound = new(
        "Duel.NotFound", "Duel with given Id was not found");
}
