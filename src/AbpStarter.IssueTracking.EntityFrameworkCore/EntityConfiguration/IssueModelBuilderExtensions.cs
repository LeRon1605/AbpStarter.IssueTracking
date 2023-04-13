using AbpStarter.IssueTracking.Issues;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;

namespace AbpStarter.IssueTracking.EntityConfiguration;

public static class IssueModelBuilderExtensions
{
    public static void ConfigureIssue([NotNull] this ModelBuilder builder)
    {
        builder.Entity<Issue>(entity =>
        {
            entity.ConfigureByConvention();

            entity.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Issues");

            entity.Property(x => x.Text)
                  .HasMaxLength(255)
                  .IsRequired();
            entity.Property(x => x.IsClosed)
                  .IsRequired()
                  .HasDefaultValue(false);
            entity.Property(x => x.CloseReason)
                  .IsRequired(false);
            entity.Property(x => x.AssignedUserId)
                  .IsRequired(false);
            entity.Property(x => x.RepositoryId)
                  .IsRequired();
            entity.Property(x => x.CreatorId)
                  .IsRequired();

            entity.HasMany(x => x.Comments)
                  .WithOne(x => x.Issue)
                  .HasForeignKey(x => x.IssueId);
            entity.HasMany(x => x.Labels)
                  .WithOne(x => x.Issue)
                  .HasForeignKey(x => x.IssueId);
            entity.HasOne(x => x.CreatedBy)
                  .WithMany()
                  .HasForeignKey(x => x.CreatorId);
            entity.HasOne(x => x.AssignedUser)
                  .WithMany()
                  .HasForeignKey(X => X.AssignedUserId);
        });

        builder.Entity<Comment>(entity =>
        {
            entity.ConfigureByConvention();

            entity.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Comments");

            entity.Property(x => x.Text)
                  .HasMaxLength(255)
                  .IsRequired();
            entity.HasOne(x => x.User)
                  .WithMany()
                  .HasForeignKey(x => x.UserId);
        });

        builder.Entity<IssueLabel>(entity =>
        {
            entity.ConfigureByConvention();

            entity.HasKey(x => new { x.IssueId, x.LabelId });
        });
    }    
}
