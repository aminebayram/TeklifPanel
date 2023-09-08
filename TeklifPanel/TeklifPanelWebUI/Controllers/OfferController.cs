using Microsoft.AspNetCore.Mvc;
using TeklifPanel.Business.Abstract;
using TeklifPanelWebUI.ViewModels;

namespace TeklifPanelWebUI.Controllers
{
    public class OfferController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IContactPersonService _contactPersonService;

        public OfferController(ICustomerService customerService, IProductService productService, ICategoryService categoryService, IContactPersonService contactPersonService)
        {
            _customerService = customerService;
            _productService = productService;
            _categoryService = categoryService;
            _contactPersonService = contactPersonService;
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
                    Code = product.Code,
                    Name = product.Name,
                    SellPrice = product.SellPrice,
                    Detail = product.Detail,
                    Stock = product.Stock,
                    Discount = customer.Discount,
                    Images = product.ProductImages.Select(p => p.Url).ToList(),
                    CompanyId = product.CompanyId,
                   CategoryName = category.Name
                });

            }

            return View(productViewModel);
        }

        public IActionResult OfferPreview()
        {
            return View();
        }
    }
}
