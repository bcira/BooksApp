using BooksApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using BooksApp.DataTransferObjects.Requests;

namespace BooksApp.Mvc.Controllers
{
   /// <summary>
   /// [Authorize(Roles = "Admin, Customer")]
   /// </summary>
    public class BooksController : Controller
    {
        
        private readonly IBookService bookService;
        private readonly ICategoryService categoryService;

        public BooksController(IBookService bookService, ICategoryService categoryService)
        {
            this.bookService = bookService;
            this.categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var books = bookService.GetBookDisplayResponses();
            return View(books);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = getCategoriesForSelectList();
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(CreateNewBookRequest request)
        {
            if (ModelState.IsValid)
            {
                await bookService.CreateNewBookAsync(request);
                return RedirectToAction(nameof(Index));
            }


            ViewBag.Categories = getCategoriesForSelectList();
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Categories = getCategoriesForSelectList();
            var book = await bookService.GetBookForUpdate(id);

            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateBookRequest updateBookRequest)
        {
            if (await bookService.BookIsExists(id))
            {
                if (ModelState.IsValid)
                {
                    await bookService.UpdateBook(updateBookRequest);
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Categories = getCategoriesForSelectList();
                return View();
            }
            return NotFound();
        }


        private IEnumerable<SelectListItem> getCategoriesForSelectList()
        {
            var categories = categoryService.GetCategoriesForList().Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }).ToList();
            
            return categories;
        }
    }
}
