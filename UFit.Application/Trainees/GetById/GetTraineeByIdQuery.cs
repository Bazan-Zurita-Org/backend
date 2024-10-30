using UFit.Application.Abstractions.Messaging;

namespace UFit.Application.Trainees.GetById;

public sealed record GetTraineeByIdQuery(Guid Id) : IQuery<TraineeResponse>;
