using CMS.Domain.Modules.DoctorProfiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infrastructure.Modules.DoctorProfiles;

internal sealed class DoctorProfileConfiguration : IEntityTypeConfiguration<DoctorProfile>
{
    public void Configure(EntityTypeBuilder<DoctorProfile> builder)
    {
        builder.HasKey(dp => dp.Id);

        builder
            .Property(dp => dp.Bio)
            .IsRequired()
            .HasMaxLength(DoctorProfileAttributeConstants.BioMaxLength);

        builder
            .HasOne(dp => dp.User)
            .WithOne()
            .HasForeignKey<DoctorProfile>(dp => dp.UserId);

        builder
            .HasMany(dp => dp.Qualifications)
            .WithOne(q => q.DoctorProfile)
            .HasForeignKey(q => q.DoctorProfileId);

        builder
            .HasMany(dp => dp.Appointments)
            .WithOne(a => a.DoctorProfile)
            .HasForeignKey(a => a.DoctorProfileId);

        builder
            .HasMany(dp => dp.TimeSlots)
            .WithOne(ts => ts.DoctorProfile)
            .HasForeignKey(ts => ts.DoctorProfileId);
    }
}
