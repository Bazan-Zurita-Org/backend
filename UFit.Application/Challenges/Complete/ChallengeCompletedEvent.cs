using MediatR;

namespace UFit.Application.Challenges.Complete;
public sealed record ChallengeCompletedEvent(Guid TraineeId, int Points) : INotification;
