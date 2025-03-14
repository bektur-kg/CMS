using MediatR;

namespace CMS.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<TResponse>;