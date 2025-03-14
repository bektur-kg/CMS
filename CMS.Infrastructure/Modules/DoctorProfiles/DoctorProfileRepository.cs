using CMS.Application.Features.DoctorProfiles;
using CMS.Domain.Modules.DoctorProfiles;
using CMS.Infrastructure.DbContexts;
using CMS.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure.Modules.DoctorProfiles;

internal sealed class DoctorProfileRepository(AppDbContext dbContext)
    : Repository<DoctorProfile>(dbContext), IDoctorProfileRepository
{
    public Task<DoctorProfile?> GetByUserIdAsync(long userId, CancellationToken cancellationToken = default)
    {
        return DbContext.DoctorProfiles.FirstOrDefaultAsync(dp => dp.UserId == userId, cancellationToken);
    }
}