using CMS.Domain.Modules.Diagnoses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infrastructure.Modules.Diagnoses;

internal sealed class DiagnosisConfiguration : IEntityTypeConfiguration<Diagnosis>
{
    public void Configure(EntityTypeBuilder<Diagnosis> builder)
    {
        builder.HasKey(d => d.Id);

        builder
            .Property(d => d.Description)
            .IsRequired()
            .HasMaxLength(DiagnosesAttributeConstants.MaxDescriptionLength);

        builder
            .ToTable(d => d.HasCheckConstraint("CK_Diagnoses_IcdCode_Length", "LEN(IcdCode) BETWEEN 4 AND 7"));

        builder
            .Property(d => d.IcdCode)
            .IsRequired();

        builder
            .HasOne(d => d.Visit)
            .WithMany(v => v.Diagnoses)
            .HasForeignKey(d => d.VisitId);


    }
}
