using UFit.Application.Abstractions.Messaging;

namespace UFit.Application.Trainees.Create;
internal sealed record CreateTraineeCommand(CreateTraineeRequest Trainee) : ICommand<Guid>;
