namespace CMS.Application.CommonContracts;

public record TimeSlotResponse
{
    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public bool IsBooked { get; set; }
}
