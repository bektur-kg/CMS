using CMS.Application.Features.TimeSlots;
using CMS.Domain.Modules.TimeSlots;
using CMS.Infrastructure.DbContexts;
using CMS.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure.Modules.TimeSlots;

internal sealed class TimeSlotsRepository(AppDbContext dbContext) : Repository<TimeSlot>(dbContext), ITimeSlotsRepository
{
    public Task<bool> IsOverlappingAsync(DateTime startTime, DateTime endTime)
    {
        return DbContext.TimeSlots
            .AnyAsync(timeSlot => timeSlot.StartTime < endTime && timeSlot.EndTime >= startTime);
    }
}
