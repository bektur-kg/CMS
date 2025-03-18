using CMS.Application.Abstractions.Data;
using CMS.Domain.Modules.TimeSlots;

namespace CMS.Application.Features.TimeSlots;

public interface ITimeSlotsRepository : IRepository<TimeSlot>
{
    Task<bool> IsOverlappingAsync(DateTime startTime, DateTime endTime);
}
