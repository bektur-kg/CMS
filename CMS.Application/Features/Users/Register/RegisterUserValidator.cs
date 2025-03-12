using CMS.Domain.Modules.Users;
using FluentValidation;

namespace CMS.Application.Features.Users.Register;

public class RegisterUserValidator : AbstractValidator<RegisterUserRequest>
{
    private readonly IUserRepository _userRepository;

    public RegisterUserValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(UserAttributeConstants.PasswordMinLength)
                .WithMessage($"Minimum password length is {UserAttributeConstants.PasswordMinLength} long");

        RuleFor(u => u.FirstName)
            .NotEmpty().WithMessage("FirstName is required")
            .MaximumLength(UserAttributeConstants.FirstNameMaxLength)
                .WithMessage($"FirstName has to be less than {UserAttributeConstants.FirstNameMaxLength} characters");

        RuleFor(u => u.LastName)
            .NotEmpty().WithMessage("LastName is required")
            .MaximumLength(UserAttributeConstants.LastNameMaxLength)
                .WithMessage($"LastName has to be less than {UserAttributeConstants.LastNameMaxLength} characters");

        RuleFor(u => u.Patronymic)
            .NotEmpty().WithMessage("Patronymicis required")
            .MaximumLength(UserAttributeConstants.PatronymicMaxLength)
                .WithMessage($"Patronymic has to be less than {UserAttributeConstants.PatronymicMaxLength} characters");

        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("Email is required")
            .MaximumLength(UserAttributeConstants.EmailMaxLength)
                .WithMessage($"Email has to be less than {UserAttributeConstants.EmailMaxLength} characters")
            .EmailAddress().WithMessage("Invalid email format")
            .MustAsync(BeUniqueEmail).WithMessage("Email is already taken");
    }

    private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
    {
        return !await _userRepository.DoesEmailExistAsync(email, cancellationToken);
    }
}
