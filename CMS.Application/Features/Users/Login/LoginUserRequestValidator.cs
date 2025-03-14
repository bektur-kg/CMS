using CMS.Domain.Modules.Users;
using FluentValidation;

namespace CMS.Application.Features.Users.Login;

public class LoginUserRequestValidator : AbstractValidator<LoginUserRequest>
{
    private readonly IUserRepository _userRepository;

    public LoginUserRequestValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(UserAttributeConstants.PasswordMinLength)
                .WithMessage($"Minimum password length is {UserAttributeConstants.PasswordMinLength} long");

        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("Email is required")
            .MaximumLength(UserAttributeConstants.EmailMaxLength)
                .WithMessage($"Email has to be less than {UserAttributeConstants.EmailMaxLength} characters")
            .EmailAddress().WithMessage("Invalid email format")
            .MustAsync(DoesEmailExistAsync).WithMessage("User not found with this email");
    }

    private async Task<bool> DoesEmailExistAsync(string email, CancellationToken cancellationToken)
    {
        return await _userRepository.DoesEmailExistAsync(email, cancellationToken);
    }
}
