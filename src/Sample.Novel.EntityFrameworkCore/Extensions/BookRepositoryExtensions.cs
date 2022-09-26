using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Sample.Novel.Domain.Book.Entites;
using Sample.Novel.Domain.Book.Repository;
using Volo.Abp.Threading;

namespace Sample.Novel.EntityFrameworkCore.Extensions
{
    public static class BookRepositoryExtensions
    {
        public static Chapter FindChapterById(this IBookRepository repository, Guid id, bool include = true)
        {
            return AsyncHelper.RunSync(() => repository.FindChapterByIdAsync(id, include));
        }

        public static IQueryable<Book> IncludeDetails(this IQueryable<Book> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(book => book.Volumes)
                .ThenInclude(volume => volume.Chapters);
        }
    }
}
