using System.Collections;
using UFit.Domain.Abstractions;
using UFit.Domain.Shared;

namespace UFit.Domain.Challenges;

public sealed class Challenge : Entity
{
    private readonly List<TraineeChallenge> _traineeChallenges = new List<TraineeChallenge>();
    private Challenge() { }
    private Challenge(
        Guid id,
        Name name,
        Description description,
        Points rewards,
        DateTime startDate,
        DateTime endDate,
        ChallengeType type) : base(id)
    {
        Name = name;
        Description = description;
        Rewards = rewards;
        StartDate = startDate;
        EndDate = endDate;
        Type = type;
    }

    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Points Rewards { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public ChallengeType Type { get; private set; }
    public IReadOnlyList<TraineeChallenge> TraineeChallenges => _traineeChallenges.ToList();

    public static Result<Challenge> Create(
        Name name,
        Description description,
        Points rewards,
        DateTime start,
        DateTime end,
        ChallengeType type)
    {
        var challenge = new Challenge(Guid.NewGuid(), name, description, rewards, start, end, type);

        return challenge;
    }

    public TraineeChallenge AddTraineeChallenge(Guid traineeId)
    {
        var traineeChanllenge = new TraineeChallenge(Guid.NewGuid(), traineeId, Id, ChallengeStatus.Pending, null);
        _traineeChallenges.Add(traineeChanllenge);

        return traineeChanllenge;
    }

    public void CompleteChallenge(Guid traineeChallengeId)
    {
        var traineeChallenge = _traineeChallenges.FirstOrDefault(tc => tc.Id == traineeChallengeId);

        if (traineeChallenge is null) return;

        traineeChallenge.CompleteChallenge();
    }
}
