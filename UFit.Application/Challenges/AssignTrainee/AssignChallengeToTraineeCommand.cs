using UFit.Application.Abstractions.Messaging;

namespace UFit.Application.Challenges.AssignTrainee;
public sealed record AssignChallengeToTraineeCommand(AssignChallengeToTraineeRequest ChallengeTrainee) : ICommand<Guid>;
