using Microsoft.AspNetCore.Mvc;
using TeklifPanel.Business.Abstract;
using TeklifPanel.Core;
using TeklifPanel.Entity;
using TeklifPanelWebUI.ViewModels;

namespace TeklifPanelWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICompanyService _companyService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICompanyService companyService, ICategoryService categoryService)
        {
            _productService = productService;
            _companyService = companyService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ProductList(int id)
        {
            var companyId = HttpContext.Session.GetInt32("CompanyId") ?? default;
            ViewBag.Categories = await _categoryService.GetCategoriesAsync(companyId);

            if (id == 0)
            {
                var productList = await _productService.GetCompanyProductsAsync(companyId);
                return View(productList);
            }

            var productsByCategory = await _productService.GetProductsByCategoryAsync(companyId, id);
            return View(productsByCategory);
        }
        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            var companyId = HttpContext.Session.GetInt32("CompanyId") ?? default;
            ViewBag.Categories = await _categoryService.GetCategoriesAsync(companyId);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductViewModel productViewModel, List<IFormFile> images)
        {
            var companyId = HttpContext.Session.GetInt32("CompanyId") ?? default;
            ViewBag.Categories = await _categoryService.GetCategoriesAsync(companyId);
            var url = Jobs.MakeUrl(productViewModel.Name);
            if (ModelState.IsValid)
            {
                var product = new Product()
                {
                    BuyPrice = productViewModel?.BuyPrice,
                    Code = productViewModel?.Code,
                    Detail = productViewModel?.Detail,
                    IsActive = productViewModel.IsActive,
                    Name = productViewModel?.Name,
                    SellPrice = productViewModel?.SellPrice,
                    Stock = productViewModel.Stock,
                    CompanyId = companyId,
                    CategoryId = productViewModel.CategoryId,
                    Url = url
                };
                var isCreateProduct = await _productService.CreateAsync(product);
                if (isCreateProduct)
                {
                    var id = product.Id;
                    foreach (var image in images)
                    {
                        product.ProductImages.Add(new ProductImage()
                        {
                            Name = productViewModel.Name,
                            Url = Jobs.UploadImage(image, url, companyId),
                            ProductId = id
                        });
                    }
                    var result = await _productService.UpdateAsync(product);
                    TempData["Message"] = $"'{product.Name}' adlı ürün eklendi";
                    return RedirectToAction("ProductList");
                }
                TempData["Error"] = "Ürün Eklenemedi!";
                return RedirectToAction("ProductList");
            }
            TempData["Error"] = "Eksik bilgi var!";
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return View(product);
        }
    }
}

