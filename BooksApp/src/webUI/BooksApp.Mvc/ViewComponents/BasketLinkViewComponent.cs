using BooksApp.Mvc.Extensions;
using BooksApp.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksApp.Mvc.ViewComponents
{
    public class BasketLinkViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var bookCollection = HttpContext.Session.GetJson<BookCollection>("basket");
            return View(bookCollection);
        }

    }
}
