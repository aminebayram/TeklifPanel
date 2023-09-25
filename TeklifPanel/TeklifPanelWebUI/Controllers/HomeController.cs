using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TeklifPanel.Business.Abstract;
using TeklifPanel.Data.Concrete.EfCore;
using TeklifPanel.Entity;
using TeklifPanelWebUI.ViewModels;

namespace TeklifPanelWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly UserManager<User> _userManager;
        private readonly IOfferService _offerService;
        private readonly ILogService _logService;
        private readonly ICompanyService _companyService;

        public HomeController(ICustomerService customerService, UserManager<User> userManager, IOfferService offerService, ILogService logService, ICompanyService companyService)
        {
            _customerService = customerService;
            _userManager = userManager;
            _offerService = offerService;
            _logService = logService;
            _companyService = companyService;
        }

        public async Task<IActionResult> Index()
        {

            if (User.Identity.IsAuthenticated)
            {
                var companyId = HttpContext.Session.GetInt32("CompanyId") ?? default;
                var userId = HttpContext.Session.GetString("UserId");
                var offerList = await _offerService.GetCompanyOffersAsync(companyId) ?? new List<Offer>();
                var logList = await _logService.GetCompanyLogsAsync(companyId);
                var customerList = await _customerService.GetCompanyByCustomersAsync(companyId) ?? new List<Customer>();

                var user = await _userManager.FindByIdAsync(userId);

                if (user != null)
                {
                    var homeViewModel = new HomeViewModel()
                    {
                        Offers = offerList,
                        Logs = logList,
                        CustomerList = customerList.ToList()
                    };

                    return View(homeViewModel);
                }
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}