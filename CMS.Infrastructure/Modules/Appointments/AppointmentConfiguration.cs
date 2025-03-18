using CMS.Domain.Modules.Appointments;
using CMS.Domain.Modules.TimeSlots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infrastructure.Modules.Appointments;

internal sealed class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(a => a.Id);

        builder
            .Property(a => a.Reason)
            .IsRequired()
            .HasMaxLength(AppointmentAttributeConstants.ReasonMaxLength);

        builder
            .HasOne(a => a.MedicalCard)
            .WithMany(mc => mc.Appointments)
            .HasForeignKey(a => a.MedicalCardId);

        builder
            .HasOne(a => a.DoctorProfile)
            .WithMany(dp => dp.Appointments)
            .HasForeignKey(a => a.DoctorProfileId);

        builder
            .HasOne(a => a.Visit)
            .WithOne(v => v.Appointment)
            .HasForeignKey<Appointment>(a => a.VisitId);

        builder
            .HasOne(a => a.TimeSlot)
            .WithOne()
            .HasForeignKey<Appointment>(a => a.TimeSlotId);
    }
}
