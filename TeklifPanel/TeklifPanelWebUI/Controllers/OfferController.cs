using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using TeklifPanel.Business.Abstract;
using TeklifPanel.Core;
using TeklifPanel.Entity;
using TeklifPanelWebUI.ViewModels;
using DinkToPdf;
using System.ComponentModel.Design;
using System.Security.Policy;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Identity;

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
        private readonly IConverter _pdfConverter;
        private readonly UserManager<User> _userManager;

        public OfferController(ICustomerService customerService, IProductService productService, ICategoryService categoryService, IContactPersonService contactPersonService, ICompanyService companyService, ICompanySettingsService companySettingsService, IOfferService offerService, IConverter pdfConverter, UserManager<User> userManager)
        {
            _customerService = customerService;
            _productService = productService;
            _categoryService = categoryService;
            _contactPersonService = contactPersonService;
            _companyService = companyService;
            _companySettingsService = companySettingsService;
            _offerService = offerService;
            _pdfConverter = pdfConverter;
            _userManager = userManager;
        }

        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> OfferList()
        {
            var companyId = HttpContext.Session.GetInt32("CompanyId") ?? default;
            var offerList = await _offerService.GetCompanyOffersAsync(companyId);
            return View(offerList);

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
        public async Task<IActionResult> SendMail(IFormFile pdfFile, int CustomerId, int OfferNumber, int ContactPersonId)
        {
            var companyId = HttpContext.Session.GetInt32("CompanyId") ?? default;
            var userId = HttpContext.Session.GetString("UserId") ?? default;

            var user = await _userManager.FindByIdAsync(userId);
            var company = await _companyService.GetByIdAsync(companyId);

            var companySettings = await _companySettingsService.GetAllCompanySettingsAsync(companyId);

            var customer = await _customerService.GetByIdAsync(CustomerId);

            var contactPerson = await _contactPersonService.GetByIdAsync(ContactPersonId);

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

            var pdf = Jobs.UploadPdf(pdfFile, Jobs.MakeUrl(customer.Name), companyId);

            var pdfSplit = pdf.Split("\\");
            var pdfUrl = pdfSplit[pdfSplit.Length - 1];

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
                Pdf = pdfUrl,
                Company = company,
                CompanyId = companyId,
                Customer = customer,
                User = user,
                DateOfOffer = DateTime.Now,
                UserId = user.Id,
                CustomerContact = contactPerson,
                OfferNumber = OfferNumber
            };

            var result = await _offerService.CreateAsync(offer);

            return View();
        }

        [HttpPost]
        public IActionResult DenemePdf()
        {

            var converter = new BasicConverter(new PdfTools());
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount=true,
                        HtmlContent = "<h1>Hello, PDF!</h1>",
                    }
                }
            };

            byte[] pdfBytes = converter.Convert(doc);

            var pdfFile = File(pdfBytes, "application/pdf", "example.pdf");


            return View();
        }

        [HttpPost]
        public IActionResult GeneratePdf(string htmlContent)
        {
            try
            {
                var globalSettings = new GlobalSettings
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait,
                    Margins = new MarginSettings { Top = 10, Bottom = 10, Left = 10, Right = 10 }
                };

                var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    HtmlContent = htmlContent,
                    WebSettings = { DefaultEncoding = "utf-8" },
                    HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Sayfa [page] / [toPage]", Line = true },
                    FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Sayfa [page] / [toPage]" }
                };

                var pdf = new HtmlToPdfDocument()
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };

                var pdfBytes = _pdfConverter.Convert(pdf);
                return File(pdfBytes, "application/pdf");
            }
            catch (Exception ex)
            {
                // Hata işleme kodları burada yer alabilir.
                return Content("Hata oluştu: " + ex.Message);
            }
        }
    }
}
