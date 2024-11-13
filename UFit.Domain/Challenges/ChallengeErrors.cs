using UFit.Domain.Abstractions;

namespace UFit.Domain.Challenges;
public static class ChallengeErrors
{
    public readonly static Error CantCreate = new Error(
        "Challenge", "Cant create challenge");

    public readonly static Error NotFound = new Error(
        "Challenge.NotFound", "Challenge with given Id was not found");
}
