using Microsoft.AspNetCore.Mvc;
using TeklifPanel.Business.Abstract;
using TeklifPanel.Core;
using TeklifPanel.Entity;
using TeklifPanelWebUI.Models;

namespace TeklifPanelWebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CategoryList()
        {
            var companyId = HttpContext.Session.GetInt32("CompanyId") ?? default;
            var categoryList = await _categoryService.GetCategoriesAsync(companyId);
            return View(categoryList);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryModel categoryModel)
        {
            var companyId = HttpContext.Session.GetInt32("CompanyId") ?? default;
            if (ModelState.IsValid)
            {
                var category = new Category()
                {
                    Name = categoryModel.Name,
                    Details = categoryModel.Details,
                    CompanyId = companyId,
                    Url = Jobs.MakeUrl(categoryModel.Name)
                };
                var isCategoryAdd = await _categoryService.CreateAsync(category);
                if (isCategoryAdd)
                {
                    TempData["Message"] = $"'{category.Name}' adlı kategori eklendi";
                    return RedirectToAction("CategoryList");
                }
                TempData["Error"] = $"'{category.Name}' adlı kategori eklendi";
                return RedirectToAction("CategoryList");

            }
            TempData["Error"] = $"Eksik Bilgiler var!";
            return View();
        }

        public IActionResult UpdateCategory()
        {
            return View();
        }
    }
}
