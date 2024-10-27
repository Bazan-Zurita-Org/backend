using MediatR;
using UFit.Domain.Abstractions;

namespace UFit.Application.Abstractions.Messaging;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
