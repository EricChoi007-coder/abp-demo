using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sample.Novel.Application.Contracts.Dtos.Author;
using Sample.Novel.Application.Contracts.Interfaces;
using Sample.Novel.Domain.Author.Entities;
using Sample.Novel.Domain.Author.Repository;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Sample.Novel.Application.Services
{
    public class AuthorAppService : ApplicationService, IAuthorAppService
    {
        private readonly IAtuthorRepository _authorRepository;

        public AuthorAppService(IAtuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        //映射文檔參照 https://docs.abp.io/en/abp/latest/API/Auto-API-Controllers 中的規則（如下）
 /*  ABP uses a naming convention while determining the HTTP method for a service method(action) :

Get: Used if the method name starts with 'GetList', 'GetAll' or 'Get'.
Put: Used if the method name starts with 'Put' or 'Update'.
Delete: Used if the method name starts with 'Delete' or 'Remove'.
Post: Used if the method name starts with 'Create', 'Add', 'Insert' or 'Post'.
Patch: Used if the method name starts with 'Patch'.
Otherwise, Post is used by default.*/
        public async Task CreateAsync(CreateAuthorInput input)
        {
            var author = ObjectMapper.Map<CreateAuthorInput, Author>(input);
            await _authorRepository.InsertAsync(author);
        }

        public async Task<AuthorDto> GetAsync(Guid id)
        {
            var author = await _authorRepository.GetAsync(id);
            return ObjectMapper.Map<Author, AuthorDto>(author);
        }

        public async Task<PagedResultDto<AuthorDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var count = await _authorRepository.CountAsync();
            var list = await _authorRepository.OrderBy(input.Sorting).PageBy(input).ToListAsync();

            return new PagedResultDto<AuthorDto>
            {
                TotalCount = count,
                Items = ObjectMapper.Map<List<Author>, List<AuthorDto>>(list)
            };
        }
    }
}
