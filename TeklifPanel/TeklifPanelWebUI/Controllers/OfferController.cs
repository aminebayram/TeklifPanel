using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
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
        private readonly IOfferService _offerService;

        public OfferController(ICustomerService customerService, IProductService productService, ICategoryService categoryService, IContactPersonService contactPersonService, ICompanyService companyService, ICompanySettingsService companySettingsService, IOfferService offerService)
        {
            _customerService = customerService;
            _productService = productService;
            _categoryService = categoryService;
            _contactPersonService = contactPersonService;
            _companyService = companyService;
            _companySettingsService = companySettingsService;
            _offerService = offerService;
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

        public async Task<IActionResult> OfferPreview(List<int> Amount, List<decimal> Discount, int CustomerId, List<int> Id, List<int> CategoryId, int ContactPersonId)
        {
            Random random = new Random();

            var companyId = HttpContext.Session.GetInt32("CompanyId") ?? default;
            var company = await _companyService.GetByIdAsync(companyId);

            var companySettings = await _companySettingsService.GetAllCompanySettingsAsync(companyId);

            var customer = await _customerService.GetByIdAsync(CustomerId);

            var contactPerson = await _contactPersonService.GetByIdAsync(ContactPersonId);

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
                CustomerContact = contactPerson,
                OrderNumber = random.Next(11111, 99999)
            };

            return View(offerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SendMail(IFormFile pdfFile, int CustomerId)
        {

            var companyId = HttpContext.Session.GetInt32("CompanyId") ?? default;
            var company = await _companyService.GetByIdAsync(companyId);

            var companySettings = await _companySettingsService.GetAllCompanySettingsAsync(companyId);

            var customer = await _customerService.GetByIdAsync(CustomerId);


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


            string sunucu = companySettingsViewModel.EmailServer;
            var port = companySettingsViewModel.EmailServerPort;
            string mail = companySettingsViewModel.EmailUsername;
            string sifre = companySettingsViewModel.EmailPassword;
            string aliciEmail = companySettingsViewModel.RecipientEmail;


            var fromAddress = new MailAddress(mail, "Teklif");
            var toAddress = new MailAddress(aliciEmail);

            var customerEmail = new MailAddress(customer.Email);


            SmtpClient smtp = new SmtpClient();
            try
            {
                smtp.Host = sunucu;
                smtp.Port = Convert.ToInt32(port);
                smtp.EnableSsl = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(mail, sifre);
            }
            catch
            {
                smtp.Host = sunucu;
                smtp.Port = Convert.ToInt32(port);
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(mail, sifre);
            }
            var message = new MailMessage(fromAddress, toAddress);
            var message2 = new MailMessage(fromAddress, customerEmail);

            var pdf = Jobs.UploadPdf(pdfFile, "resim", companyId);

            // PDF dosyasını ekleyin
            var attachment = new Attachment(pdf);

            message.Attachments.Add(attachment);
            message2.Attachments.Add(attachment);

            message.IsBodyHtml = true;
            {
                smtp.Send(message);
            }
            message2.IsBodyHtml = true;
            {
                smtp.Send(message2);
            }

            var offer = new Offer()
            {
                Pdf = pdf,

            };

            return View();
        }
    }
}
