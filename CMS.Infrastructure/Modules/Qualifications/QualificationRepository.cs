using CMS.Application.Features.Qualifications;
using CMS.Domain.Modules.Qualifications;
using CMS.Infrastructure.DbContexts;
using CMS.Infrastructure.Services;

namespace CMS.Infrastructure.Modules.Qualifications;

internal sealed class QualificationRepository(AppDbContext dbContext) 
    : Repository<Qualification>(dbContext), IQualificationRepository
{
}
