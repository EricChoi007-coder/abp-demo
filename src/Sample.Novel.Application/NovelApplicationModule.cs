using System;
using Sample.Novel.Application.Profiles;
using Sample.Novel.Domain;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Sample.Novel.Application
{
    [DependsOn(typeof(NovelDomainModule),
        typeof(AbpAutoMapperModule))]
    public class NovelApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AuthorProfile>(true);
            });
        }
    }
}
