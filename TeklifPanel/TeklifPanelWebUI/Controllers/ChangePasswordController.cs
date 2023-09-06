using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeklifPanel.Entity;
using TeklifPanelWebUI.Models;

namespace TeklifPanelWebUI.Controllers
{
    public class ChangePasswordController : Controller
    {
        private readonly UserManager<User> _userManager;

        public ChangePasswordController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PasswordEdit()
        {
            var userId = HttpContext.Session.GetString("UserId");
            ChangePassword changePassword = new ChangePassword()
            {
                Id = userId
            };
            return View(changePassword);
        }
        [HttpPost]
        public async Task<IActionResult> PasswordEdit(ChangePassword changePassword)
        {
            
            var user = await _userManager.FindByIdAsync(changePassword.Id);
            var result = await _userManager.ChangePasswordAsync(user, changePassword.OldPassword, changePassword.NewPassword);
            if (result.Succeeded)
            {
                TempData["Message"] = "Şifreniz değiştirildi!";
                return View(new { changePassword.Id });
            }
            TempData["Hata"] = "Şifreniz değiştirilemedi!";
            return View(new { changePassword.Id });
        }
    }
}
