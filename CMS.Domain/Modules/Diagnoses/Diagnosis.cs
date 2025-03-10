using CMS.Domain.Modules.Visits;
using CSharpFunctionalExtensions;

namespace CMS.Domain.Modules.Diagnoses;

public class Diagnosis : Entity
{
    public long VisitId { get; set; }

    public required string Description { get; set; }

    public required string ICDCode { get; set; }

    public Visit? Visit { get; set; }
}
