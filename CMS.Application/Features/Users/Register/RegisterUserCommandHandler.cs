using AutoMapper;
using CMS.Application.Abstractions.Authentication;
using CMS.Application.Abstractions.Data;
using CMS.Application.Abstractions.Messaging;
using CMS.Application.Features.DoctorProfiles;
using CMS.Application.Features.MedicalCards;
using CMS.Domain.Modules.DoctorProfiles;
using CMS.Domain.Modules.MedicalCards;
using CMS.Domain.Modules.Users;
using CSharpFunctionalExtensions;

namespace CMS.Application.Features.Users.Register;

internal sealed class RegisterUserCommandHandler
    (
        IUserRepository userRepository,
        IPasswordManager passwordManager,
        IDoctorProfileRepository doctorProfileRepository,
        IMedicalCardRepository medicalCardRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork
    ) 
    : ICommandHandler<RegisterUserCommand, UnitResult<Error>>
{
    public async Task<UnitResult<Error>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request.Data);

        var passwordHash = passwordManager.Hash(request.Data.Password);

        user.PasswordHash = passwordHash;
        user.CreatedAt = DateTime.UtcNow;

        if (request.Data.UserType == UserType.Doctor)
        {
            var doctorProfile = new DoctorProfile
            { 
                Bio = string.Empty,
                User = user,
            };

            doctorProfileRepository.Add(doctorProfile);
        }

        if (request.Data.UserType == UserType.Patient)
        {
            var medicalCard = new MedicalCard
            {
                PatientNote = string.Empty, 
                User = user
            };

            medicalCardRepository.Add(medicalCard);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return UnitResult.Success<Error>();
    }
}
