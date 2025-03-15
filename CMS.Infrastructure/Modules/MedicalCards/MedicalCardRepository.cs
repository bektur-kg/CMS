using CMS.Application.Features.MedicalCards;
using CMS.Domain.Modules.MedicalCards;
using CMS.Infrastructure.DbContexts;
using CMS.Infrastructure.Services;

namespace CMS.Infrastructure.Modules.MedicalCards;

internal sealed class MedicalCardRepository(AppDbContext dbContext) 
    : Repository<MedicalCard>(dbContext), IMedicalCardRepository
{
}
