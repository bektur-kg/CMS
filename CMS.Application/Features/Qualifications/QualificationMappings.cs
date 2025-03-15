using AutoMapper;
using CMS.Application.CommonContracts;
using CMS.Application.Features.Qualifications.Add;
using CMS.Domain.Modules.Qualifications;

namespace CMS.Application.Features.Qualifications;

internal sealed class QualificationMappings : Profile
{
    public QualificationMappings()
    {
        CreateMap<AddQualificationRequest, Qualification>();

        CreateMap<Qualification, QualificationResponse>();
    }
}
