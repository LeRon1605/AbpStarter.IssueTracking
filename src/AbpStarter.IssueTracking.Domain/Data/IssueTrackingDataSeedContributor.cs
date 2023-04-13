using AbpStarter.IssueTracking.Buckets;
using AbpStarter.IssueTracking.Issues;
using AbpStarter.IssueTracking.Labels;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace AbpStarter.IssueTracking.Data;

public class IssueTrackingDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Bucket, Guid> _bucketRepository;
    private readonly IRepository<Issue, Guid> _issueRepository;
    private readonly IRepository<Label, Guid> _labelRepository;
    private readonly IGuidGenerator _guidGenerator;

    public IssueTrackingDataSeedContributor(
        IRepository<Bucket, Guid> bucketRepository,
        IRepository<Issue, Guid> issueRepository, 
        IRepository<Label, Guid> labelRepository, 
        IGuidGenerator guidGenerator
    )
    {
        _bucketRepository = bucketRepository;
        _issueRepository = issueRepository;
        _labelRepository = labelRepository;
        _guidGenerator = guidGenerator;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _bucketRepository.GetCountAsync() <= 0)
        {
            await SeedBucketAsync();
        }    

        if (await _labelRepository.GetCountAsync() <= 0)
        {
            await SeedLabelAsync();
        }
    }

    private async Task SeedUserAsync()
    {

    }

    private async Task SeedBucketAsync()
    {
        var buckets = new Bucket[]
        {
            new(_guidGenerator.Create()) { Name = "Abp_Starter" },
            new(_guidGenerator.Create()) { Name = "Net_Starter" },
        };

        await _bucketRepository.InsertManyAsync(buckets);
    }

    private async Task SeedLabelAsync()
    {
        var labels = new Label[]
        {
            new(_guidGenerator.Create()) { Text = "Warning", Color = "yellow" },
            new(_guidGenerator.Create()) { Text = "Error", Color = "red" }
        };

        await _labelRepository.InsertManyAsync(labels);
    }
}
