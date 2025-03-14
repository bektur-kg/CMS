using CMS.Application.Abstractions.Data;
using CMS.Domain.Modules.MedicalCards;

namespace CMS.Application.Features.MedicalCards;

public interface IMedicalCardRepository : IRepository<MedicalCard>
{
}
