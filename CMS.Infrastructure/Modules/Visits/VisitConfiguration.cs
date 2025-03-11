using CMS.Domain.Modules.Appointments;
using CMS.Domain.Modules.Visits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infrastructure.Modules.Visits;

internal sealed class VisitConfiguration : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {
        builder.HasKey(v => v.Id);

        builder
            .Property(v => v.Notes)
            .IsRequired()
            .HasMaxLength(VisitAttributeConstants.NotesMaxLength);

        builder
            .HasOne(v => v.Appointment)
            .WithOne(a => a.Visit)
            .HasForeignKey<Appointment>(a => a.VisitId);

        builder
            .HasMany(v => v.Diagnoses)
            .WithOne(d => d.Visit)
            .HasForeignKey(d => d.VisitId);

        builder
            .HasMany(v => v.Medications)
            .WithOne(d => d.Visit)
            .HasForeignKey (d => d.VisitId);
    }
}
