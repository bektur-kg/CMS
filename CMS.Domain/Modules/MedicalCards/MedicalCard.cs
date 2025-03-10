using CMS.Domain.Modules.Appointments;
using CMS.Domain.Modules.Users;
using CSharpFunctionalExtensions;

namespace CMS.Domain.Modules.MedicalCards;

public class MedicalCard : Entity
{
    public long UserId { get; set; }

    public required string PatientNotes { get; set; }

    public User? User { get; set; }

    public List<Appointment> Appointments { get; set; } = [];
}
