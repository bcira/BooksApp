using BooksApp.Infrastructure.Data;
using BooksApp.Infrastructure.Repositories;
using BooksApp.Services;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Mvc.Extensions
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddInjections(this IServiceCollection services, string connectionString)
        {

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserService, UserService>();
            
            services.AddDbContext<BookDbContext>(opt => opt.UseSqlServer(connectionString));

            return services;
        }
    }
}
