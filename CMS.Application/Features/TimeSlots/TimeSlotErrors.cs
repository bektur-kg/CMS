using CMS.Application.Abstractions.Messaging;

namespace CMS.Application.Features.TimeSlots;

public static class TimeSlotErrors
{
    public static Error OverlappingTimeSlot => new("TimeSlot.Overlapping", "Time slot is overlapping with another time slot");
    public static Error TimeSlotNotFoundById => new("TimeSlot.NotFound", "Time slot is not found by this Id");
    public static Error TimeSlotAlreadyBooked => new("TimeSlot.Booked", "Time slot is already booked");

}
