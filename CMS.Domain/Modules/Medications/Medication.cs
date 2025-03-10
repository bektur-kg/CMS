using CMS.Domain.Modules.Visits;
using CSharpFunctionalExtensions;

namespace CMS.Domain.Modules.Medications;

public class Medication : Entity
{
    public long VisitId { get; set; }

    public required string Name { get; set; }

    public required string Dosage { get; set; }

    public required string Duration { get; set; }

    public Visit? Visit { get; set; }
}

