using Microsoft.AspNetCore.Mvc;
using TeklifPanel.Business.Abstract;
using TeklifPanel.Core;
using TeklifPanel.Entity;
using TeklifPanelWebUI.ViewModels;

namespace TeklifPanelWebUI.Controllers
{
    public class OfferController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IContactPersonService _contactPersonService;
        private readonly ICompanyService _companyService;
        private readonly ICompanySettingsService _companySettingsService;

        public OfferController(ICustomerService customerService, IProductService productService, ICategoryService categoryService, IContactPersonService contactPersonService, ICompanyService companyService, ICompanySettingsService companySettingsService)
        {
            _customerService = customerService;
            _productService = productService;
            _categoryService = categoryService;
            _contactPersonService = contactPersonService;
            _companyService = companyService;
            _companySettingsService = companySettingsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OfferList()
        {
            return View();

        }
        public async Task<IActionResult> AddOffer()
        {
            var companyId = HttpContext.Session.GetInt32("CompanyId") ?? default;
            var customerList = await _customerService.GetCompanyByCustomersAsync(companyId);
            ViewBag.Company = await _companyService.GetCompanyByIdAsync(companyId);
            ViewBag.Categories = await _categoryService.GetCategoriesAsync(companyId);
            return View(customerList);
        }

        [HttpGet]
        public async Task<IActionResult> ContactPersons(int id)
        {
            var companyId = HttpContext.Session.GetInt32("CompanyId") ?? default;

            var customerContactPersons = await _contactPersonService.GetCustomerContacts(companyId, id);
            return View(customerContactPersons);

        }

        public async Task<IActionResult> GetProducts(int id, int customerId)
        {
            var companyId = HttpContext.Session.GetInt32("CompanyId") ?? default;
            var productList = await _productService.GetProductsByCategoryAsync(companyId, id);
            var customer = await _customerService.GetByIdAsync(customerId);
            var category = await _categoryService.GetByIdAsync(id);

            var productViewModel = new List<ProductViewModel>();
            foreach (var product in productList)
            {
                productViewModel.Add(new ProductViewModel()
                {
                    Id = product.Id,
                    Code = product?.Code,
                    Name = product?.Name,
                    SellPrice = product?.SellPrice,
                    Detail = product?.Detail,
                    Stock = product.Stock,
                    Discount = customer?.Discount,
                    Images = product?.ProductImages.Select(p => p.Url).ToList(),
                    CompanyId = product.CompanyId,
                    CategoryName = category?.Name
                });

            }

            return View(productViewModel);
        }

        public async Task<IActionResult> OfferPreview(List<int> Amount, List<decimal> Discount, int CustomerId, List<int> Id, List<int> CategoryId)
        {
            var companyId = HttpContext.Session.GetInt32("CompanyId") ?? default;
            var company = await _companyService.GetByIdAsync(companyId);

            var companySettings = await _companySettingsService.GetAllCompanySettingsAsync(companyId);

            var customer = await _customerService.GetByIdAsync(CustomerId);

            var selectecProductList = new List<ProductViewModel>();
            for (int i = 0; i < Id.Count(); i++)
            {
                var selectedProduct = await _productService.GetProductByIdAsync(Id[i]);
                var selectedCategory = await _categoryService.GetByIdAsync(CategoryId[i]);
                selectecProductList.Add(new ProductViewModel()
                {
                    Id = selectedProduct.Id,
                    Code = selectedProduct?.Code,
                    Name = selectedProduct?.Name,
                    SellPrice = selectedProduct?.SellPrice,
                    Amount = Amount[i],
                    Discount = Discount[i],
                    KDV = selectedCategory.KDV,
                });
            }
            
            CompanySettingsViewModel companySettingsViewModel = new CompanySettingsViewModel()
            {
                Id = companyId,
                EmailAddress = company?.Email,
                RecipientEmail = companySettings.Where(c => c.Parameter == "AliciEmail")?.FirstOrDefault().Value,
                EmailServerPort = companySettings.Where(c => c.Parameter == "EmailSunucuPort")?.FirstOrDefault().Value,
                EmailServer = companySettings.Where(c => c.Parameter == "EmailSunucu")?.FirstOrDefault().Value,
                EmailUsername = companySettings.Where(c => c.Parameter == "EmailKullaniciAdi")?.FirstOrDefault().Value,
                EmailPassword = companySettings.Where(c => c.Parameter == "EmailParola")?.FirstOrDefault().Value,
                Logo = companySettings.Where(c => c.Parameter == "Logo")?.FirstOrDefault().Value,
                Logo2 = companySettings.Where(c => c.Parameter == "Logo2")?.FirstOrDefault().Value,
                PhoneNumber = companySettings.Where(c => c.Parameter == "TelNo")?.FirstOrDefault().Value,
                FaxNumber = companySettings.Where(c => c.Parameter == "FaxNo")?.FirstOrDefault().Value,
                Address = companySettings.Where(c => c.Parameter == "Adres")?.FirstOrDefault().Value,
            };

            var offerViewModel = new OfferViewModel()
            {
                CompanySettingsViewModel = companySettingsViewModel,
                DateOfOffer = DateTime.Now.ToShortTimeString(),
                ProductsViewModel = selectecProductList,
                Company = company,
                Customer = customer,
            };

            return View(offerViewModel);
        }

        [HttpPost]
        public IActionResult SendMail(IFormFile pdfFile, string screenshot)
        {
            var companyId = HttpContext.Session.GetInt32("CompanyId") ?? default;

            Jobs.UploadImage(pdfFile, "denemePdf", companyId);
            return View();
        }
    }
}
