namespace BookStore.Authors
{
    using BookStore.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
    using Volo.Abp.EntityFrameworkCore;

    public class EfCoreAuthorRepository
    : EfCoreRepository<BookStoreDbContext, Author, Guid>,
        IAuthorRepository
    {
        public EfCoreAuthorRepository(
            IDbContextProvider<BookStoreDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<Author> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(author => author.Name == name);
        }

        public async Task<List<Author>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    author => author.Name.Contains(filter)
                 )
.OrderBy(CreateOrderByExpression(sorting))
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
        private Expression<Func<Author, object>> CreateOrderByExpression(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(Author), "x");
            var property = Expression.Property(parameter, propertyName);
            var conversion = Expression.Convert(property, typeof(object));

            return Expression.Lambda<Func<Author, object>>(conversion, parameter);
        }

    }
}