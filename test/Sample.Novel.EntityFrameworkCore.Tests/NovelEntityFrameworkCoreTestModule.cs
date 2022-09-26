using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Sample.Novel.TestBase;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;

namespace Sample.Novel.EntityFrameworkCore.Tests
{
    [DependsOn(
        typeof(AbpEntityFrameworkCoreSqliteModule),
        typeof(NovelTestBaseModule),
        typeof(NovelEntityFrameworkModule)
    )]
    public class NovelEntityFrameworkCoreTestModule : AbpModule
    {
        private SqliteConnection _sqliteConnection;

        private static SqliteConnection CreateDatabaseAndGetConnection()
        {
            //開啓 sqllite 内存虛擬數據庫 
            var connection = new SqliteConnection("Data Source=:memory:");
            //開啓虛擬數據庫鏈接（open-connection）-> 注意：需要在module生命周期結束時關閉内存數據庫sqllite鏈接
            connection.Open();
            //虛擬數據庫 模型建立（根據NovelDbContext結構建立）
            var options = new DbContextOptionsBuilder<NovelDbContext>()
                .UseSqlite(connection)
                .Options;
            //把虛擬數據庫建立的選項（options）傳入db-context進行虛擬數據庫context設定
            using var context = new NovelDbContext(options);
            context.GetService<IRelationalDatabaseCreator>().CreateTables(); //createTables()->内存數據庫中建立novel模型
            //返回虛擬内存數據庫connection
            return connection;
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            _sqliteConnection = CreateDatabaseAndGetConnection();

            context.Services.Configure<AbpDbContextOptions>(options =>
            {
                //配置虛擬數據庫 Sqllite
                options.Configure(configurationContext =>
                    configurationContext.DbContextOptions.UseSqlite(_sqliteConnection)
                );
            });
        }

        //module生命周期方法 module生命周期結束后調用
        public override void OnApplicationShutdown(ApplicationShutdownContext context)
        {
            // 關閉内存數據庫sqllite connection (之前在line 30 打開的sqllite database connection)
            _sqliteConnection.Dispose();
        }
    }
}
