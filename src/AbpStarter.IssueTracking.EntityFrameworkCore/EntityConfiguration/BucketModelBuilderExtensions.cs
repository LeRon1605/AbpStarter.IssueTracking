using AbpStarter.IssueTracking.Buckets;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;

namespace AbpStarter.IssueTracking.EntityConfiguration;

public static class BucketModelBuilderExtensions
{
    public static void ConfigureBucket([NotNull] this ModelBuilder builder)
    {
        builder.Entity<Bucket>(entity =>
        {
            entity.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Buckets");
            entity.ConfigureByConvention();

            entity.Property(x => x.Name)
                  .HasMaxLength(255)
                  .IsRequired();
        });
    }
}
