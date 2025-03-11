using CMS.Domain.Modules.Visits;
using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;

namespace CMS.Domain.Modules.Medications;

public class Medication : Entity
{
    public long VisitId { get; set; }

    [MaxLength(MedicationAttributeConstants.NameMaxLength)]
    public required string Name { get; set; }

    [MaxLength(MedicationAttributeConstants.DosageMaxLength)]
    public required string Dosage { get; set; }

    [MaxLength(MedicationAttributeConstants.DurationMaxLength)]
    public required string Duration { get; set; }

    public Visit? Visit { get; set; }
}

