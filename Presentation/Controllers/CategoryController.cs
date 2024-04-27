using BusinessLogic.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

    }
}
