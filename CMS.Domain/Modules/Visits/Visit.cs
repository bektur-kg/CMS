using CMS.Domain.Modules.Appointments;
using CMS.Domain.Modules.Diagnoses;
using CMS.Domain.Modules.Medications;
using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;

namespace CMS.Domain.Modules.Visits;

public class Visit : Entity
{
    public DateTime VisitedAt { get; set; }

    [MaxLength(VisitAttributeConstants.NotesMaxLength)]
    public required string Notes { get; set; }

    public long AppointmentId { get; set; }

    public Appointment? Appointment { get; set; }

    public List<Diagnosis> Diagnoses { get; set; } = [];

    public List<Medication> Medications { get; set; } = [];
}