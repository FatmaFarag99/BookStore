namespace BookStore
{
    using BookStore.Books;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Volo.Abp.Application.Dtos;
    using Volo.Abp.Application.Services;

    public interface IBookAppService :
        ICrudAppService<
        BookDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateBookDto>
    {
        Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync();

    }
}
