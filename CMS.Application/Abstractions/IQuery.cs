using MediatR;

namespace CMS.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<TResponse>;