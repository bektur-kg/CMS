using CMS.Domain.Modules.DoctorProfiles;

namespace CMS.Application.Features.DoctorProfiles.Update;

public record UpdateDoctorProfileRequest
{
    public string? Bio { get; set; }

    public SpecializationType? SpecializationType { get; set; }
}
