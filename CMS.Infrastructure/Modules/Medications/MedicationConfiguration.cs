using CMS.Domain.Modules.Medications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infrastructure.Modules.Medications;

internal sealed class MedicationConfiguration : IEntityTypeConfiguration<Medication>
{
    public void Configure(EntityTypeBuilder<Medication> builder)
    {
        builder.HasKey(m => m.Id);

        builder
            .Property(m => m.Dosage)
            .IsRequired()
            .HasMaxLength(MedicationAttributeConstants.DosageMaxLength);

        builder
            .Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(MedicationAttributeConstants.NameMaxLength);

        builder
            .Property(m => m.Duration)
            .IsRequired()
            .HasMaxLength(MedicationAttributeConstants.DurationMaxLength);

        builder
            .HasOne(m => m.Visit)
            .WithMany(v => v.Medications)
            .HasForeignKey(m => m.VisitId);
    }
}
