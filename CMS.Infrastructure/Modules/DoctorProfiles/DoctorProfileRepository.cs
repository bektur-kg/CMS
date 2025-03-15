using CMS.Application.Features.DoctorProfiles;
using CMS.Domain.Modules.DoctorProfiles;
using CMS.Infrastructure.DbContexts;
using CMS.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure.Modules.DoctorProfiles;

internal sealed class DoctorProfileRepository(AppDbContext dbContext)
    : Repository<DoctorProfile>(dbContext), IDoctorProfileRepository
{
    public Task<bool> DoesDoctorProfileExistAsync(long userId, CancellationToken cancellationToken = default)
    {
        return DbContext.DoctorProfiles.AnyAsync(dp => dp.UserId == userId, cancellationToken);
    }

    public Task<DoctorProfile?> GetByUserIdAsync(long userId, CancellationToken cancellationToken = default)
    {
        return DbContext.DoctorProfiles.FirstOrDefaultAsync(dp => dp.UserId == userId, cancellationToken);
    }

    public Task<List<DoctorProfile>> GetAllWithIncludeAndNoTracking(
        bool includeUser = false,
        bool includeQualifications = false,
        bool includeAppointments = false,
        bool includeTimeSlots = false,
        CancellationToken cancellationToken = default)
    {
        var query = DbContext.DoctorProfiles.AsNoTracking();

        if (includeUser) query = query.Include(dp => dp.User);
        if (includeQualifications) query = query.Include(dp => dp.Qualifications);
        if (includeAppointments) query = query.Include(dp => dp.Appointments);
        if (includeTimeSlots) query = query.Include(dp => dp.TimeSlots);

        return query.ToListAsync(cancellationToken);
    }

    public Task<DoctorProfile?> GetByIdWithInlcudeAndNoTrackingAsync(
        long doctorProfileId,
        bool includeUser = false,
        bool includeQualifications = false,
        bool includeAppointments = false,
        bool includeTimeSlots = false,
        CancellationToken cancellationToken = default)
    {
        var query = DbContext.DoctorProfiles.AsNoTracking();

        if (includeUser) query = query.Include(dp => dp.User);
        if (includeQualifications) query = query.Include(dp => dp.Qualifications);
        if (includeAppointments) query = query.Include(dp => dp.Appointments);
        if (includeTimeSlots) query = query.Include(dp => dp.TimeSlots);

        return query.FirstOrDefaultAsync(dp => dp.Id == doctorProfileId, cancellationToken);
    }
}