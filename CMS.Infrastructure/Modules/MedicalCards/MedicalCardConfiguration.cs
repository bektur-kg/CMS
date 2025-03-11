using CMS.Domain.Modules.MedicalCards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infrastructure.Modules.MedicalCards;

internal sealed class MedicalCardConfiguration : IEntityTypeConfiguration<MedicalCard>
{
    public void Configure(EntityTypeBuilder<MedicalCard> builder)
    {
        builder.HasKey(mc => mc.Id);

        builder
            .Property(mc => mc.PatientNote)
            .IsRequired()
            .HasMaxLength(MedicalCardAttributeConstants.PatientNoteMaxLength);

        builder
            .HasMany(mc => mc.Appointments)
            .WithOne(a => a.MedicalCard)
            .HasForeignKey(a => a.MedicalCardId);

        builder
            .HasOne(mc => mc.User)
            .WithOne()
            .HasForeignKey<MedicalCard>(mc => mc.UserId);
    }
}
