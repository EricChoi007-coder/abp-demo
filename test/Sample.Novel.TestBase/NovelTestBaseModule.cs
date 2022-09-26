using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Sample.Novel.Domain;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;

namespace Sample.Novel.TestBase
{
    [DependsOn(typeof(AbpAutofacModule),
        typeof(AbpTestBaseModule),
        typeof(NovelDomainModule))]
    public class NovelTestBaseModule : AbpModule
    {
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            AsyncHelper.RunSync(async () =>
            {
                //為每個測試單元（unite test）劃分測試scope，目的是讓測試單元數據相互不影響
                using var scope = context.ServiceProvider.CreateScope();
                //執行Domain Layer 中的seeder文件進行内存數據庫sqllite中初始數據插入
                await scope.ServiceProvider.GetRequiredService<IDataSeeder>().SeedAsync();
            });
        }
    }
}
