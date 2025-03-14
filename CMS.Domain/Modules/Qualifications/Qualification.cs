using CMS.Domain.Modules.DoctorProfiles;
using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;

namespace CMS.Domain.Modules.Qualifications;

public class Qualification : Entity
{
    [MaxLength(QualificationAttributeConstants.NameMaxLength)]
    public required string Name { get; set; }

    public QualificationType QualificationType { get; set; }

    [MaxLength(QualificationAttributeConstants.IssuingAuthorityMaxLength)]
    public string? IssuingAuthority { get; set; }

    public DateTime DateObtained { get; set; }

    public DateTime? ExpiryDate { get; set; }

    [MaxLength(QualificationAttributeConstants.DescriptionMaxLength)]
    public string? Description { get; set; }

    [MaxLength(QualificationAttributeConstants.LevelMaxLength)]
    public required string Level { get; set; }

    public long DoctorProfileId { get; set; }

    public DoctorProfile? DoctorProfile { get; set; }
}
