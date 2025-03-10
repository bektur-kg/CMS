using CMS.Domain.Modules.Users;
using CSharpFunctionalExtensions;

namespace CMS.Domain.Modules.Reviews;

public class Review : Entity
{
    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public int Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime CreatedDate { get; set; }

    public User? Patient { get; set; }

    public User? Doctor { get; set; }
}