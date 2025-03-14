using MediatR;

namespace CMS.Application.Abstractions.Messaging;

public interface ICommandHandler<TCommand, TResponse>
    : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>;