using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Infrastructure.Data
{
    public class BookDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
        }


    }
}
