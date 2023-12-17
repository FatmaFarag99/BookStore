namespace BookStore.Books
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Volo.Abp.Application.Dtos;

    public class BookDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public decimal Price { get; set; }

        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }

    }

}
