using CMS.Domain.Modules.DoctorProfiles;
using FluentValidation;

namespace CMS.Application.Features.DoctorProfiles.UpdateBio;

public class UpdateBioRequestValidator : AbstractValidator<UpdateBioRequest>
{
    public UpdateBioRequestValidator()
    {
        RuleFor(b => b.Bio)
            .NotEmpty().WithMessage("Password is required")
            .MaximumLength(DoctorProfileAttributeConstants.BioMaxLength)
                .WithMessage($"Maximum bio length is {DoctorProfileAttributeConstants.BioMaxLength} long");
    }
}
