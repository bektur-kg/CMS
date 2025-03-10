using CMS.Domain.Modules.Appointments;
using CMS.Domain.Modules.Diagnoses;
using CMS.Domain.Modules.Medications;
using CSharpFunctionalExtensions;

namespace CMS.Domain.Modules.Visits;

public class Visit : Entity
{
    public long AppointmentId { get; set; }

    public DateTime VisitDate { get; set; }

    public required string Notes { get; set; }

    public Appointment? Appointment { get; set; }

    public List<Diagnosis> Diagnoses { get; set; } = [];

    public List<Medication> Medications { get; set; } = [];
}