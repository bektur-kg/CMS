namespace CMS.Application.Features.DoctorProfiles.UpdateBio;

public record UpdateBioRequest
{
    public required string Bio { get; set; }
}
