using BooksApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BooksApp.Entities;

namespace BooksApp.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {

        private readonly BookDbContext bookDbContext;

        public BookRepository(BookDbContext bookDbContext)
        {
            this.bookDbContext = bookDbContext;
        }

        public async Task CreateAsync(Book entity)
        {
            await bookDbContext.Books.AddAsync(entity);
            await bookDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deleting = await bookDbContext.Books.FindAsync(id);
            bookDbContext.Books.Remove(deleting);
            await bookDbContext.SaveChangesAsync();
        }

        public Book? Get(int id)
        {
            return bookDbContext.Books.SingleOrDefault(x => x.Id == id);
        }

        public IList<Book?> GetAll()
        {
            return bookDbContext.Books.AsNoTracking().ToList();
        }

        public async Task<IList<Book?>> GetAllAsync()
        {
            return await bookDbContext.Books.AsNoTracking().ToListAsync();
        }

        public IList<Book> GetAllWithPredicate(Expression<Func<Book, bool>> predicate)
        {
            return bookDbContext.Books.AsNoTracking().Where(predicate).ToList();
        }

        public async Task<Book?> GetAsync(int id)
        {
            return await bookDbContext.Books.AsNoTracking().FirstAsync(p => p.Id == id);
        }

        public IEnumerable<Book> GetBooksByCategory(int categoryId)
        {
            return bookDbContext.Books.AsNoTracking().Where(c => c.CategoryId == categoryId).AsEnumerable();
        }

        public async Task<IEnumerable<Book>> GetBooksByCategoryAsync(int categoryId)
        {
            return await bookDbContext.Books.AsNoTracking().Where(c => c.CategoryId == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByName(string name)
        {
            return await bookDbContext.Books.AsNoTracking().Where(b => b.Name.Contains(name)).ToListAsync();

        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await bookDbContext.Books.AnyAsync(c => c.Id == id);

        }

        public async Task UpdateAsync(Book entity)
        {
            bookDbContext.Books.Update(entity);
            await bookDbContext.SaveChangesAsync();
        }
    }
}
