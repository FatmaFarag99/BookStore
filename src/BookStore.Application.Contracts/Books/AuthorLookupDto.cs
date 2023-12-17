namespace BookStore.Books
{
    using System;
    using Volo.Abp.Application.Dtos;

    public class AuthorLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
