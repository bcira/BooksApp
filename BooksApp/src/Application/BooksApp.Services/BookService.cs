
using AutoMapper;
using BooksApp.DataTransferObjects.Requests;
using BooksApp.DataTransferObjects.Responses;
using BooksApp.Entities;
using BooksApp.Infrastructure.Repositories;
using BooksApp.Services.Extensions;

namespace BooksApp.Services
{
    public class BookService : IBookService
    {

        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public BookDisplayResponse GetBook(int id)
        {
            var book = _repository.Get(id);
            return _mapper.Map<BookDisplayResponse>(book);
        }

        public IEnumerable<BookDisplayResponse> GetBookDisplayResponses()
        {
            var books = _repository.GetAll();
            var responses = books.ConvertToDisplayResponses(_mapper);
            return responses;
        }

        public IEnumerable<BookDisplayResponse> GetBooksByCategory(int categoryId)
        {
            var books = _repository.GetBooksByCategory(categoryId);
            var response = books.ConvertToDisplayResponses(_mapper);
            return response;

        }

        public async Task CreateNewBookAsync(CreateNewBookRequest createNewBookRequest)
        {
            var book = _mapper.Map<Book>(createNewBookRequest);
            await _repository.CreateAsync(book);
        }

        public async Task UpdateBook(UpdateBookRequest updateBookRequest)
        {
            var book = _mapper.Map<Book>(updateBookRequest);
            await _repository.UpdateAsync(book);

        }

        public async Task<bool> BookIsExists(int bookId)
        {
            return await _repository.IsExistsAsync(bookId);

        }

        public async Task<UpdateBookRequest> GetBookForUpdate(int id)
        {
            var book = await _repository.GetAsync(id);
            return _mapper.Map<UpdateBookRequest>(book);

        }

        public Task<UpdateBookRequest> GetBookForUpdateAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookDisplayResponse>> SearchByName(string name)
        {
            var books = await _repository.GetBooksByName(name);
            return books.ConvertToDisplayResponses(_mapper);
        }

        public async Task<int> CreateBookAndReturnIdAsync(CreateNewBookRequest createBookRequest)
        {
            var book = _mapper.Map<Book>(createBookRequest);
            await _repository.CreateAsync(book);
            return book.Id;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);

        }









    }
}

