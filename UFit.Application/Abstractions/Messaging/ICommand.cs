using MediatR;
using UFit.Domain.Abstractions;

namespace UFit.Application.Abstractions.Messaging;


public interface ICommand : IRequest<Result>, ICommandBase
{
  
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, ICommandBase
{

}

public interface ICommandBase { }