using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.Design;
using TeklifPanel.Business.Abstract;
using TeklifPanel.Core;
using TeklifPanel.Entity;
using TeklifPanelWebUI.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace TeklifPanelWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICompanyService _companyService;
        private readonly ICategoryService _categoryService;
        private readonly IImageService _imageService;

        public ProductController(IProductService productService, ICompanyService companyService, ICategoryService categoryService, IImageService imageService)
        {
            _productService = productService;
            _companyService = companyService;
            _categoryService = categoryService;
            _imageService = imageService;
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
                    foreach (var image in images)
                    {
                        product.ProductImages.Add(new ProductImage()
                        {
                            Name = productViewModel.Name,
                            Url = Jobs.UploadImage(image, url, companyId),
                            ProductId = product.Id
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
            var companyId = HttpContext.Session.GetInt32("CompanyId") ?? default;
            ViewBag.Categories = await _categoryService.GetCategoriesAsync(companyId);
            var product = await _productService.GetProductByIdAsync(id);
            var productViewModel = new ProductViewModel()
            {
                BuyPrice = product.BuyPrice,
                CategoryId = product.CategoryId,
                Code = product.Code,
                Detail = product.Detail,
                IsActive = product.IsActive,
                Name = product.Name,
                SellPrice = product.SellPrice,
                Stock = product.Stock,
                Id = id,
                ProductImages = product.ProductImages,
                CompanyId = companyId,
            };
            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductViewModel productViewModel, List<IFormFile> images)
        {
            var companyId = HttpContext.Session.GetInt32("CompanyId") ?? default;
            ViewBag.Categories = await _categoryService.GetCategoriesAsync(companyId);
            var url = Jobs.MakeUrl(productViewModel.Name);
            if (ModelState.IsValid)
            {
                var product = new Product()
                {
                    CompanyId = companyId,
                    Id = productViewModel.Id,
                    BuyPrice = productViewModel.BuyPrice,
                    SellPrice = productViewModel.SellPrice,
                    Stock = productViewModel.Stock,
                    Code = productViewModel.Code,
                    Detail = productViewModel.Detail,
                    IsActive = productViewModel.IsActive,
                    CategoryId = productViewModel.CategoryId,
                    Name = productViewModel.Name,
                };

                if (images != null && images.Count() > 0)
                {
                    foreach (var image in images)
                    {
                        product.ProductImages.Add(new ProductImage()
                        {
                            Name = productViewModel.Name,
                            Url = Jobs.UploadImage(image, url, companyId),
                            ProductId = product.Id
                        });
                    }
                }
                var updateProduct = await _productService.UpdateAsync(product);
                if (updateProduct)
                {
                    TempData["Message"] = $"'{product.Name}' adlı ürün güncelledi";
                    return RedirectToAction("UpdateProduct");
                }
                TempData["Error"] = $"'{product.Name}' adlı ürün güncellenirken bir hata oluştu";
                return View(productViewModel);
            }
            TempData["Error"] = "Eksik bilgi var!";
            return View(productViewModel);
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var isDeleteProduct = await _productService.DeleteProductAsync(id);
            var status = isDeleteProduct ? 200 : 400;
            return Json(new { status = status });
        }

        public async Task<IActionResult> DeleteProductImage(int id)
        {
            var image = await _imageService.GetByIdAsync(id);
            if (image == null)
            {
                return View();
            }
            var isDeletedImage = await _imageService.DeleteAsync(image);
            if (isDeletedImage)
            {
                TempData["Message"] = "Resim silindi";
                return RedirectToAction("ProductList");
            }
            TempData["Error"] = "Resim silinemedi";
            return RedirectToAction("ProductList");
        }

    }
}

