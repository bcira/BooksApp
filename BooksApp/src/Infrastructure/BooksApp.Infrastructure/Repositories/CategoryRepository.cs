using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BooksApp.Entities;
using BooksApp.Infrastructure.Data;

namespace BooksApp.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookDbContext bookDbContext;

        public CategoryRepository(BookDbContext bookDbContext)
        {
            this.bookDbContext = bookDbContext;
        }

        public async Task CreateAsync(Category entity)
        {
            await bookDbContext.Categories.AddAsync(entity);
            await bookDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletingCategory = await bookDbContext.Categories.FindAsync(id);
            bookDbContext.Categories.Remove(deletingCategory);
            await bookDbContext.SaveChangesAsync();

        }

        public Category? Get(int id)
        {
            return bookDbContext.Categories.FirstOrDefault(c => c.Id == id);
        }

        public IList<Category?> GetAll()
        {
            return bookDbContext.Categories.ToList();
        }

        public async Task<IList<Category?>> GetAllAsync()
        {
            return await bookDbContext.Categories.ToListAsync();
        }

        public IList<Category> GetAllWithPredicate(Expression<Func<Category, bool>> predicate)
        {
            return bookDbContext.Categories.Where(predicate).ToList();
        }

        public async Task<Category?> GetAsync(int id)
        {
            return await bookDbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<bool> IsExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Category entity)
        {
            bookDbContext.Categories.Update(entity);
            await bookDbContext.SaveChangesAsync();
        }

    }
}
