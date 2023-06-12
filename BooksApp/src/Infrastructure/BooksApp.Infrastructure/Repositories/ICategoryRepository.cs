using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksApp.Entities;

namespace BooksApp.Infrastructure.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
    }
}
