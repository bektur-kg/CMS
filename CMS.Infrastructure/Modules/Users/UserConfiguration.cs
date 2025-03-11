using CMS.Domain.Modules.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CMS.Domain.Modules.Reviews;

namespace CMS.Infrastructure.Modules.Users;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder
            .HasIndex(u => u.Email)
            .IsUnique();

        builder
            .Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(UserAttributeConstants.FirstNameMaxLength);

        builder
            .Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(UserAttributeConstants.LastNameMaxLength);

        builder
            .Property(u => u.Patronymic)
            .IsRequired()
            .HasMaxLength(UserAttributeConstants.PatronymicMaxLength);

        builder
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(UserAttributeConstants.EmailMaxLength);
    }
}