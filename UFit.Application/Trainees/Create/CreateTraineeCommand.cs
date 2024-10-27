using UFit.Application.Abstractions.Messaging;

namespace UFit.Application.Trainees.Create;
public sealed record CreateTraineeCommand(CreateTraineeRequest Trainee) : ICommand<Guid>;
