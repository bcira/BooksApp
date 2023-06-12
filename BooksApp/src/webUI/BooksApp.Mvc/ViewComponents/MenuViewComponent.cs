using Microsoft.AspNetCore.Mvc;
using BooksApp.Services;

namespace BooksApp.Mvc.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {

        private readonly ICategoryService categoryService;

        public MenuViewComponent(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = categoryService.GetCategoriesForList();
            return View(categories);
        }
    }
}
