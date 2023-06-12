using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using BooksApp.Services;
using BooksApp.DataTransferObjects.Responses;
using BooksApp.Mvc.Models;
using BooksApp.Mvc.Extensions;

namespace BooksApp.Mvc.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly IBookService bookService;

        public ShoppingController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public IActionResult Index()
        {
            var bookCollection = getBookCollectionFromSession();
            return View(bookCollection);
        }

        public IActionResult AddBook(int id)
        {
            BookDisplayResponse selectedBook = bookService.GetBook(id);
            var bookItem = new BookItem { Book = selectedBook, Quantity = 1 };
            
            BookCollection bookCollection = getBookCollectionFromSession();
            bookCollection.AddNewBook(bookItem);
            saveToSession(bookCollection);

            return Json(new { message = $"{selectedBook.Name} Sepete eklendi" });
        }


        private BookCollection getBookCollectionFromSession()
        {
            return HttpContext.Session.GetJson<BookCollection>("basket") ?? new BookCollection();
        }


        private void saveToSession(BookCollection bookCollection)
        {

            HttpContext.Session.SetJson("basket", bookCollection);

        }
    }
}
