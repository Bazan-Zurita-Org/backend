using UFit.Application.Abstractions.Messaging;

namespace UFit.Application.Trainees.GetAll;
public sealed record GetAllTraineesQuery() : IQuery<List<GetAllTraineesResponse>>;

public sealed record GetAllTraineesResponse(Guid Id, string Name);
