using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksApp.Entities;

namespace BooksApp.Infrastructure.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        public IEnumerable<Book> GetBooksByCategory(int categoryId);

        public Task<IEnumerable<Book>> GetBooksByCategoryAsync(int categoryId);

        public Task<IEnumerable<Book>> GetBooksByName(string name);


    }
}
