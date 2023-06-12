using BooksApp.DataTransferObjects.Responses;
using BooksApp.Mvc.CacheTools;
using BooksApp.Mvc.Models;
using BooksApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;



namespace BooksApp.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService _bookService;
        private readonly IMemoryCache _memoryCache;
        public HomeController(ILogger<HomeController> logger, IBookService bookService, IMemoryCache memoryCache)
        {
            _logger = logger;
            _bookService = bookService;
            _memoryCache = memoryCache;
        }

        public IActionResult Index(int pageNo = 1, int? id = null)
        {
            IEnumerable<BookDisplayResponse> books = getBooksMemCacheOrDb(id);



            var bookPerPage = 4;
            var bookCount = books.Count();
            var totalPage = Math.Ceiling((decimal)bookCount / bookPerPage);

            var pagingInfo = new PagingInfo
            {
                CurrentPage = pageNo,
                ItemsPerPage = bookPerPage,
                TotalItems = bookCount
            };



            var paginatedBooks = books.OrderBy(c => c.Id)
                                          .Skip((pageNo - 1) * bookPerPage)
                                          .Take(bookPerPage)
                                          .ToList();

            var model = new PaginationBookViewModel
            {
                Books = paginatedBooks,
                PagingInfo = pagingInfo
            };



            return View(model);
        }

        private IEnumerable<BookDisplayResponse> getBooksMemCacheOrDb(int? id)
        {


            if (!_memoryCache.TryGetValue("allBooks", out CacheDataInfo cacheDataInfo))
            {
                var options = new MemoryCacheEntryOptions()
                                  .SetSlidingExpiration(TimeSpan.FromMinutes(1))
                                  .SetPriority(CacheItemPriority.Normal);

                cacheDataInfo = new CacheDataInfo
                {
                    CacheTime = DateTime.Now,
                    Books = _bookService.GetBookDisplayResponses()
                };

                _memoryCache.Set("allBooks", cacheDataInfo, options);
            }


            _logger.LogInformation($"{cacheDataInfo.CacheTime.ToLongTimeString()} anındaki cache'i görmektesiniz");
            return id == null ? cacheDataInfo.Books :
                                _bookService.GetBooksByCategory(id.Value);

        }

        [ResponseCache(Duration = 70, VaryByQueryKeys = new[] { "id" }, Location = ResponseCacheLocation.Client)]
        public IActionResult Privacy(int id)
        {
            ViewBag.Id = id;
            ViewBag.DateTime = DateTime.Now;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}


