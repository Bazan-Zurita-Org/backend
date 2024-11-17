using UFit.Application.Abstractions.Messaging;

namespace UFit.Application.Rankings.GetAll;

public sealed record GetAllRankingsQuery() : IQuery<List<RankingsResponse>>;

public sealed record RankingsResponse(
    Guid TraineeId,
    string Name,
    int Points);
