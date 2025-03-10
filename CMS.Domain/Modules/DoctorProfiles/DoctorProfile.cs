using CMS.Domain.Modules.Appointments;
using CMS.Domain.Modules.Qualifications;
using CMS.Domain.Modules.TimeSlots;
using CMS.Domain.Modules.Users;
using CSharpFunctionalExtensions;

namespace CMS.Domain.Modules.DoctorProfiles;

public class DoctorProfile : Entity
{
    public long UserId { get; set; }

    public SpecializationType SpecializationType { get; set; }

    public required string Bio { get; set; }

    public User? User { get; set; }

    public List<Qualification> Qualifications { get; set; } = [];

    public List<Appointment> Appointments { get; set; } = [];

    public List<TimeSlot> TimeSlots { get; set; } = [];
}
