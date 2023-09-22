using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeklifPanel.Business.Abstract;
using TeklifPanel.Entity;
using TeklifPanelWebUI.Models;
using TeklifPanelWebUI.ViewModels;

namespace TeklifPanelWebUI.ViewComponents
{
    public class LeftMenuViewComponent : ViewComponent
    {
        private readonly ICompanyService _companyService;
        private readonly ICompanySettingsService _companySettingsService;
        private readonly UserManager<User> _userManager;

        public LeftMenuViewComponent(ICompanyService companyService, ICompanySettingsService companySettingsService, UserManager<User> userManager)
        {
            _companyService = companyService;
            _companySettingsService = companySettingsService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = HttpContext.Session.GetString("UserId");
            var companyId = HttpContext.Session.GetInt32("CompanyId") ?? default;

            var user = await _userManager.FindByIdAsync(userId);
            var company = await _companyService.GetByIdAsync(companyId);
            var companySettings = await _companySettingsService.GetAllCompanySettingsAsync(companyId);

            LeftMenuModel leftMenuModel = new LeftMenuModel()
            {
                CompanyId = companyId,
                UserName = user?.FirstName + " " + user?.LastName,
                Logo = companySettings.Where(c => c.Parameter == "Logo")?.FirstOrDefault().Value,
            };

            return View(leftMenuModel);
        }
    }
}
