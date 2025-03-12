using AutoMapper;
using CMS.Application.Features.Users.Register;
using CMS.Domain.Modules.Users;

namespace CMS.Application.Features.Users;

internal sealed class UserMappings : Profile
{
    public UserMappings()
    {
        CreateMap<RegisterUserRequest, User>();
    }
}
