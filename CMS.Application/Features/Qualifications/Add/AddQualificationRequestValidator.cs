using CMS.Domain.Modules.Qualifications;
using FluentValidation;

namespace CMS.Application.Features.Qualifications.Add;

public class AddQualificationRequestValidator : AbstractValidator<AddQualificationRequest>
{
    public AddQualificationRequestValidator()
    {
        RuleFor(q => q.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(QualificationAttributeConstants.NameMaxLength)
                .WithMessage($"Maximum qualification name length is {QualificationAttributeConstants.NameMaxLength} long");

        RuleFor(q => q.IssuingAuthority)
            .MaximumLength(QualificationAttributeConstants.IssuingAuthorityMaxLength)
                .WithMessage($"Maximum issuing authority length is {QualificationAttributeConstants.IssuingAuthorityMaxLength} long");

        RuleFor(q => q.Description)
            .MaximumLength(QualificationAttributeConstants.DescriptionMaxLength)
                .WithMessage($"Maximum qualification description length is {QualificationAttributeConstants.DescriptionMaxLength} long");

        RuleFor(q => q.Level)
            .NotEmpty().WithMessage("Qualification level is required")
            .MaximumLength(QualificationAttributeConstants.LevelMaxLength)
                .WithMessage($"Maximum qualification level length is {QualificationAttributeConstants.LevelMaxLength} long");

        RuleFor(q => q.DateObtained)
            .NotEmpty().WithMessage("Qualification obtained date is required")
            .LessThan(DateTime.Now)
                .WithMessage($"Qualification obtained date must be in the past");

        RuleFor(q => q.ExpiryDate)
            .GreaterThan(q => q.DateObtained)
                .WithMessage($"Qualification expiry date must be greater than it's obtained date");

        RuleFor(q => q.QualificationType)
            .NotEmpty().WithMessage("Qualification type is required")
            .IsInEnum().WithMessage($"Qualification type must be a valid value");
    }
}
