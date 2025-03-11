using CMS.Domain.Modules.Reviews;
using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;

namespace CMS.Domain.Modules.Users;

public class User : Entity
{
    [MaxLength(UserAttributeConstants.FirstNameMaxLength)]
    public required string FirstName { get; set; }

    [MaxLength(UserAttributeConstants.LastNameMaxLength)]
    public required string LastName { get; set; }

    [MaxLength(UserAttributeConstants.PatronymicMaxLength)]
    public required string Patronymic { get; set; }

    [EmailAddress, MaxLength(UserAttributeConstants.EmailMaxLength)]
    public required string Email { get; set; }

    public required string PasswordHash { get; set; }

    public UserType UserType { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
