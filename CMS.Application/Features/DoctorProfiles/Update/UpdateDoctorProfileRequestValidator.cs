using CMS.Domain.Modules.DoctorProfiles;
using FluentValidation;

namespace CMS.Application.Features.DoctorProfiles.Update;

public class UpdateDoctorProfileRequestValidator : AbstractValidator<UpdateDoctorProfileRequest>
{
    public UpdateDoctorProfileRequestValidator()
    {
        RuleFor(b => b.Bio)
            .MaximumLength(DoctorProfileAttributeConstants.BioMaxLength)
                .WithMessage($"Maximum bio length is {DoctorProfileAttributeConstants.BioMaxLength} long");

        RuleFor(b => b.SpecializationType)
            .IsInEnum().WithMessage($"Specialization type must be a valid value");
    }
}
