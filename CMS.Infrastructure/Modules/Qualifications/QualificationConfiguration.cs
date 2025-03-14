using CMS.Domain.Modules.Qualifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infrastructure.Modules.Qualifications;

internal sealed class QualificationConfiguration : IEntityTypeConfiguration<Qualification>
{
    public void Configure(EntityTypeBuilder<Qualification> builder)
    {
        builder.HasKey(q => q.Id);

        builder
            .Property(q => q.Name)
            .IsRequired()
            .HasMaxLength(QualificationAttributeConstants.NameMaxLength);

        builder
            .Property(q => q.Description)
            .HasMaxLength(QualificationAttributeConstants.DescriptionMaxLength);

        builder
            .Property(q => q.IssuingAuthority)
            .HasMaxLength(QualificationAttributeConstants.IssuingAuthorityMaxLength);

        builder
            .Property(q => q.Level)
            .IsRequired()
            .HasMaxLength(QualificationAttributeConstants.LevelMaxLength);

        builder
            .HasOne(q => q.DoctorProfile)
            .WithMany(d => d.Qualifications)
            .HasForeignKey(q => q.DoctorProfileId);
    }
}
