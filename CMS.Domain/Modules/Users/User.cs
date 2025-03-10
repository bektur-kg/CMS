using CMS.Domain.Modules.Reviews;
using CSharpFunctionalExtensions;

namespace CMS.Domain.Modules.Users;

public class User : Entity
{
    public required string FirstName { get; set; }
    
    public required string LastName { get; set; }

    public required string Patronymic { get; set; }

    public required string Email { get; set; }

    public required string PasswordHash { get; set; }

    public UserType UserType { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public List<Review> Reviews { get; set; } = [];
}
