using AbpStarter.IssueTracking.Labels;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;

namespace AbpStarter.IssueTracking.EntityConfiguration;

public static class LabelModelBuilderExtension
{
    public static void ConfigureLabel([NotNull] this ModelBuilder builder)
    {
        builder.Entity<Label>(entity =>
        {
            entity.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Labels");
            entity.ConfigureByConvention();

            entity.Property(x => x.Text)
                  .HasMaxLength(255)
                  .IsRequired();
            entity.Property(x => x.Color)
                  .HasMaxLength(124)
                  .IsRequired();

            entity.HasMany(x => x.Issues)
                  .WithOne(x => x.Label)
                  .HasForeignKey(x => x.LabelId);
        });
    }
}
