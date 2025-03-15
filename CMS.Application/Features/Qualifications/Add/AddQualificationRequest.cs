using CMS.Domain.Modules.Qualifications;

namespace CMS.Application.Features.Qualifications.Add;

public record AddQualificationRequest
{
    public required string Name { get; set; }

    public required QualificationType QualificationType { get; set; }

    public string? IssuingAuthority { get; set; }

    public DateTime DateObtained { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public string? Description { get; set; }

    public required string Level { get; set; }
}
