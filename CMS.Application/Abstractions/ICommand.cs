﻿using MediatR;

namespace CMS.Application.Abstractions;

public interface ICommand<TResponse> : IRequest<TResponse>;
