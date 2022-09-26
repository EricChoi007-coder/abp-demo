using System;
using System.Collections.Generic;
using System.Text;
using Sample.Novel.Domain.Category.Entities;
using Sample.Novel.Domain.Category.Repository;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Sample.Novel.EntityFrameworkCore.Repositories
{
    public class CategoryRepository : EfCoreRepository<NovelDbContext, Category, Guid>, ICategoryRepository
    {
        public CategoryRepository(IDbContextProvider<NovelDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
