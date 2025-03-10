using CMS.Domain.Modules.DoctorProfiles;
using CSharpFunctionalExtensions;

namespace CMS.Domain.Modules.TimeSlots;

public class TimeSlot : Entity
{
    public long DoctorProfileId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public bool IsBooked { get; set; }

    public DoctorProfile? DoctorProfile { get; set; }
}
