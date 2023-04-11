using AbpStarter.IssueTracking.Users;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;

namespace AbpStarter.IssueTracking.EntityConfiguration;

public static class UserModelBuilderExtensions
{
    public static void ConfigureUser([NotNull] this ModelBuilder builder)
    {
        builder.Entity<User>(entity =>
        {
            entity.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Issue_Users");
            entity.ConfigureByConvention();

            entity.Property(x => x.UserName)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName(nameof(User.UserName));
            entity.Property(x => x.Password)
                  .IsRequired()
                  .HasMaxLength(30)
                  .HasColumnName(nameof(User.Password));
            entity.HasIndex(x => x.UserName);

            entity.HasMany(x => x.Issues)
                  .WithOne(x => x.AssignedUser)
                  .HasForeignKey(x => x.AssignedUserId);

            entity.HasMany(x => x.Comments)
                  .WithOne(x => x.User)
                  .HasForeignKey(x => x.UserId);
        });
    }
}
