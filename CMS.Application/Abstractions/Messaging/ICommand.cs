using MediatR;

namespace CMS.Application.Abstractions.Messaging;

public interface ICommand<TResponse> : IRequest<TResponse>;
