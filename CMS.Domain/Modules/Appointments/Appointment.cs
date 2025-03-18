using CMS.Domain.Modules.DoctorProfiles;
using CMS.Domain.Modules.MedicalCards;
using CMS.Domain.Modules.TimeSlots;
using CMS.Domain.Modules.Visits;
using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;

namespace CMS.Domain.Modules.Appointments;

public class Appointment : Entity
{
    public long MedicalCardId { get; set; }

    public long? DoctorProfileId { get; set; }

    public long? TimeSlotId { get; set; }

    public long? VisitId { get; set; }

    public AppointmentStatusType AppointmentStatusType { get; set; }

    [MaxLength(AppointmentAttributeConstants.ReasonMaxLength)]
    public required string Reason { get; set; }

    public MedicalCard? MedicalCard { get; set; }

    public DoctorProfile? DoctorProfile { get; set; }

    public Visit? Visit { get; set; }

    public TimeSlot? TimeSlot { get; set; }
}