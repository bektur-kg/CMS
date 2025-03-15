using AutoMapper;
using CMS.Application.CommonContracts;
using CMS.Domain.Modules.TimeSlots;

namespace CMS.Application.Features.TimeSlots;

internal sealed class TimeSlotMappings : Profile
{
    public TimeSlotMappings()
    {
        CreateMap<TimeSlot, TimeSlotResponse>();
    }
}
