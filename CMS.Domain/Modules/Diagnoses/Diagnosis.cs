using CMS.Domain.Modules.Visits;
using CMS.Infrastructure.Modules.Diagnoses;
using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;

namespace CMS.Domain.Modules.Diagnoses;

public class Diagnosis : Entity
{
    public long VisitId { get; set; }

    [MaxLength(DiagnosesAttributeConstants.MaxDescriptionLength)]
    public required string Description { get; set; }

    [StringLength(DiagnosesAttributeConstants.MaxIcdCodeLength, MinimumLength = DiagnosesAttributeConstants.MinIcdCodeLength)]
    public required string IcdCode { get; set; }

    public Visit? Visit { get; set; }
}
