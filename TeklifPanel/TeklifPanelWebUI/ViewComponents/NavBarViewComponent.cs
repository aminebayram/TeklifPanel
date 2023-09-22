using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeklifPanel.Entity;
using TeklifPanelWebUI.Models;

namespace TeklifPanelWebUI.ViewComponents
{
    public class NavBarViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;

        public NavBarViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = HttpContext.Session.GetString("UserId");

            var user = await _userManager.FindByIdAsync(userId);
            var navbarModel = new NavBarModel();
            navbarModel.UserName = user?.FirstName + " " + user?.LastName;
            return View(navbarModel);
        }
    }
}
