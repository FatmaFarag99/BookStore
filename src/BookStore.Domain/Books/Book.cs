namespace BookStore.Books
{
    using System;
    using Volo.Abp.Domain.Entities.Auditing;

    public class Book : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public decimal Price { get; set; }
        public Guid AuthorId { get; set; }

    }

}
