using CMS.Domain.Modules.DoctorProfiles;
using CSharpFunctionalExtensions;

namespace CMS.Domain.Modules.Qualifications;

public class Qualification : Entity
{
    public required string Name { get; set; }

    public QualificationType QualificationType { get; set; }

    public string? IssuingAuthority { get; set; }

    public DateTime DateObtained { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public string? Description { get; set; }

    public required string Level { get; set; }

    public long DoctorProfileId { get; set; }

    public DoctorProfile? DoctorProfile { get; set; }
}
