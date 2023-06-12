using BooksApp.DataTransferObjects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDisplayResponse> GetCategoriesForList();
    }
}
