using CMS.Application.Abstractions.Data;
using CMS.Domain.Modules.DoctorProfiles;

namespace CMS.Application.Features.DoctorProfiles;

public interface IDoctorProfileRepository : IRepository<DoctorProfile>
{
    Task<DoctorProfile?> GetByUserIdAsync(long userId, CancellationToken cancellationToken = default);

    Task<DoctorProfile?> GetByIdWithInlcudeAndNoTrackingAsync(
        long doctorProfileId,
        bool includeUser = false,
        bool includeQualifications = false,
        bool includeAppointments = false,
        bool includeTimeSlots = false,
        CancellationToken cancellationToken = default);

    Task<List<DoctorProfile>> GetAllWithIncludeAndNoTracking(
        bool includeUser = false,
        bool includeQualifications = false,
        bool includeAppointments = false,
        bool includeTimeSlots = false,
        CancellationToken cancellationToken = default);

    Task<bool> DoesDoctorProfileExistAsync(long userId, CancellationToken cancellationToken = default);
}