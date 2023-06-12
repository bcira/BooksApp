using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksApp.Entities;

namespace BooksApp.Infrastructure.Data
{
    public static class DbSeeding
    {
        public static void SeedDatabase(BookDbContext dbContext)
        {
            seedCategoryIfNoExists(dbContext);
            seedBookIfNotExists(dbContext);

        }

        private static void seedCategoryIfNoExists(BookDbContext dbContext)
        {
            if (!dbContext.Categories.Any())
            {
                var categories = new List<Category>() {
                 new() { Name="Yazılım"},
                 new() { Name="Tarih"},
                 new() { Name="Eğitim"},
                 new() { Name="Yabancı Dil"}



                };

                dbContext.Categories.AddRange(categories);
                dbContext.SaveChanges();
            }

        }

        private static void seedBookIfNotExists(BookDbContext dbContext)
        {
            if (!dbContext.Books.Any())
            {
                var books = new List<Book>()
                {
                    new(){ CategoryId=1, ImageUrl="https://www.pngwing.com/tr/free-png-npdtg", Name="Postgre SQL", Author= "Yasin TATAR" , Price=65   },
                    new(){ CategoryId=1, ImageUrl="https://www.pngwing.com/tr/free-png-npdtg", Name="Graph Theory", Author= "Narsingh DEO" , Price=55  },
                    new(){ CategoryId=1, ImageUrl="https://www.pngwing.com/tr/free-png-npdtg", Name="Data Science", Author= "G. S. COLLINS" , Price=85 }
                };
                dbContext.Books.AddRange();
                dbContext.SaveChanges();
            }
        }
    }
}
