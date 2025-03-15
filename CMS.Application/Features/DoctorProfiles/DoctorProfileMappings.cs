using AutoMapper;
using CMS.Application.Features.DoctorProfiles.GetAll;
using CMS.Application.Features.DoctorProfiles.GetDetailedById;
using CMS.Application.Features.DoctorProfiles.Update;
using CMS.Domain.Modules.DoctorProfiles;

namespace CMS.Application.Features.DoctorProfiles;

internal sealed class DoctorProfileMappings : Profile
{
    public DoctorProfileMappings()
    {
        CreateMap<DoctorProfile, GetDoctorProfileResponse>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
            .ForMember(dest => dest.Patronymic, opt => opt.MapFrom(src => src.User.Patronymic))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.User.CreatedAt))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.User.UpdatedAt));

        CreateMap<DoctorProfile, GetDetailedDoctorProfileResponse>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
            .ForMember(dest => dest.Patronymic, opt => opt.MapFrom(src => src.User.Patronymic))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.User.CreatedAt))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.User.UpdatedAt));

        CreateMap<UpdateDoctorProfileRequest, DoctorProfile>()
            .ForMember(dest => dest.Bio, opt => opt.Condition(src => src.Bio != null))
            .ForMember(dest => dest.SpecializationType, opt => opt.Condition(src => src.SpecializationType.HasValue));
    }
}
