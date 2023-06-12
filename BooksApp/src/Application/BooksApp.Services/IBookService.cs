using System;
using System.Collections.Generic;
using System.Linq;

using BooksApp.DataTransferObjects.Requests;
using BooksApp.DataTransferObjects.Responses;

namespace BooksApp.Services
{
    public interface IBookService
    {
        Task CreateNewBookAsync(CreateNewBookRequest createNewBookRequest);
        Task<int> CreateBookAndReturnIdAsync(CreateNewBookRequest createNewBookRequest);

        BookDisplayResponse GetBook(int id);

        Task<UpdateBookRequest> GetBookForUpdate(int id);

        IEnumerable<BookDisplayResponse> GetBookDisplayResponses();
        IEnumerable<BookDisplayResponse> GetBooksByCategory(int categoryId);

        Task<IEnumerable<BookDisplayResponse>> SearchByName(string name);

        Task UpdateBook(UpdateBookRequest updateBookRequest);
        Task<bool> BookIsExists(int bookId);
        Task DeleteAsync(int id);


    }
}
