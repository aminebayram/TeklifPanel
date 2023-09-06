using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeklifPanel.Entity;
using TeklifPanelWebUI.Models;

namespace TeklifPanelWebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public LoginController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginModel.Email);
                if (user == null)
                {
                    TempData["AlertMessage"] = "Kullanıcı adı ya da şifre hatalı!";
                    return RedirectToAction("Index");
                }
                var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, loginModel.RememberMe, false);
                if (result.Succeeded)
                {
                        HttpContext.Session.SetString("UserId", user.Id);
                        HttpContext.Session.SetInt32("CompanyId", user.CompanyId);

                    return RedirectToAction("Index", "Home");
                }
                TempData["AlertMessage"] = "Kullanıcı adı ya da şifre hatalı!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
