using UFit.Application.Abstractions.Messaging;

namespace UFit.Application.Trainees.Register;
public sealed record CreateTraineeCommand(CreateTraineeRequest Trainee) : ICommand<Guid>;
