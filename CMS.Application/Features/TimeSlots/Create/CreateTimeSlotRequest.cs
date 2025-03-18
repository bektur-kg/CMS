namespace CMS.Application.Features.TimeSlots.Create;

public record CreateTimeSlotRequest
{
    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }
}
