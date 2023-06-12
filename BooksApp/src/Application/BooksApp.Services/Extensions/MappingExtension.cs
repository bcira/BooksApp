using AutoMapper;
using BooksApp.DataTransferObjects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksApp.Entities;

namespace BooksApp.Services.Extensions
{
    public static class MappingExtension
    {

        public static T ConvertToDto<T>(this IEnumerable<Book> books, IMapper mapper)
        {
            return mapper.Map<T>(books);
        }
        public static IEnumerable<BookDisplayResponse> ConvertToDisplayResponses(this IEnumerable<Book> books, IMapper mapper)
        {
            return mapper.Map<IEnumerable<BookDisplayResponse>>(books);
        }

        public static IEnumerable<CategoryDisplayResponse> ConvertToDto(this IEnumerable<Category> categories, IMapper mapper)
        {
            return mapper.Map<IEnumerable<CategoryDisplayResponse>>(categories);
        }

    }
}
