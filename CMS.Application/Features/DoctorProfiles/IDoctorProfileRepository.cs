using CMS.Application.Abstractions.Data;
using CMS.Domain.Modules.DoctorProfiles;

namespace CMS.Application.Features.DoctorProfiles;

public interface IDoctorProfileRepository : IRepository<DoctorProfile>
{
    Task<DoctorProfile?> GetByUserIdAsync(long userId, CancellationToken cancellationToken = default);
}