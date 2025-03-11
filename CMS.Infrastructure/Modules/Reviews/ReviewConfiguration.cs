using CMS.Domain.Modules.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infrastructure.Modules.Reviews;

internal sealed class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => r.Id);

        builder.ToTable(r => r.HasCheckConstraint("CK_Review_Rating_Range", "Rating BETWEEN 0 AND 5"));

        builder
            .Property(r => r.Comment)
            .HasMaxLength(ReviewAttributeConstants.CommentMaxLength);

        builder
            .HasOne(r => r.Patient)
            .WithMany()
            .HasForeignKey(r => r.PatientId);

        builder
            .HasOne(r => r.Doctor)
            .WithMany()
            .HasForeignKey(r => r.DoctorId);
    }
}
