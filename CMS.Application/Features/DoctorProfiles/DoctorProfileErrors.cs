using CMS.Application.Abstractions.Messaging;

namespace CMS.Application.Features.DoctorProfiles;

public static class DoctorProfileErrors
{
    public static readonly Error DoctorProfileNotFoundById = new("DoctorProfile.NotFoundById", "Doctor Profile by this id is not found");
}
