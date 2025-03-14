using CMS.Domain.Modules.Appointments;
using CMS.Domain.Modules.Users;
using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;

namespace CMS.Domain.Modules.MedicalCards;

public class MedicalCard : Entity
{
    public long UserId { get; set; }

    [MaxLength(MedicalCardAttributeConstants.PatientNoteMaxLength)]
    public required string PatientNote { get; set; }

    public User? User { get; set; }

    public List<Appointment> Appointments { get; set; } = [];
}