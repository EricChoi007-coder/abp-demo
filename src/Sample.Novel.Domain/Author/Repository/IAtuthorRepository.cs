using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace Sample.Novel.Domain.Author.Repository
{
    public interface IAtuthorRepository : IRepository<Entities.Author, Guid>
    {
    }
}
