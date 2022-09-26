using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sample.Novel.Domain.Author.Entities;
using Shouldly;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Xunit;

namespace Sample.Novel.EntityFrameworkCore.Tests.UnitTests
{
    public class AuthorRepositoryTests : NovelEntityFrameworkCoreTestBase
    {
        //DI 注入 EF Repository
        private readonly IRepository<Author, Guid> _auhorReposity;
        //ABP 可以生成連續的GUID主鍵，使用IGuidGenerator
        private readonly IGuidGenerator _guidGenerator;

        public AuthorRepositoryTests()
        {
            _auhorReposity = GetRequiredService<IRepository<Author, Guid>>();
            _guidGenerator = GetRequiredService<IGuidGenerator>();
        }

        [Fact]
        public async Task Should_Insert_A_Valid_Author()
        {
            //數據庫插入測試
            var result = await _auhorReposity.InsertAsync(new Author(
                _guidGenerator.Create(), "张家老三", "不知名小说作家"));
            
            result.Id.ShouldNotBe(default);
        }

        [Fact]
        public async Task Should_Get_List_Of_Author()
        {
            //數據庫搜索測試
            var result = await _auhorReposity.GetListAsync();
            result.Count.ShouldBeGreaterThan(0);
        }
    }
}
