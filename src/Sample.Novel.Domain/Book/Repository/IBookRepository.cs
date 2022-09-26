using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Sample.Novel.Domain.Book.Entites;
using Volo.Abp.Domain.Repositories;

namespace Sample.Novel.Domain.Book.Repository
{
    public interface IBookRepository : IRepository<Entites.Book, Guid>
    {
        Task<Chapter> FindChapterByIdAsync(Guid id, bool include = true,
            CancellationToken cancellationToken = default);
    }
}
