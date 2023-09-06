using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeklifPanel.Business.Abstract;
using TeklifPanel.Business.Concrete;
using TeklifPanel.Core;
using TeklifPanel.Entity;
using TeklifPanelWebUI.Models;
using TeklifPanelWebUI.ViewModels;

namespace TeklifPanelWebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;

        public AdminController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UserList()
        {
            var companyId = HttpContext.Session.GetInt32("CompanyId");
            var userList = await _userManager.Users.Where(u => u.CompanyId == companyId).ToListAsync();
            return View(userList);
        }
        [HttpGet]
        public IActionResult UserCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserCreate(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    Email = userModel.Email,
                };

                user.UserName = Jobs.MakeUserName(userModel.FirstName) + "-" + Jobs.MakeUserName(userModel.LastName);
                user.CompanyId = HttpContext.Session.GetInt32("CompanyId").HasValue ? HttpContext.Session.GetInt32("CompanyId").Value : default;

                if (user.CompanyId == default)
                {
                    return View();
                }

                var result = await _userManager.CreateAsync(user, userModel.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                }

                return RedirectToAction("UserList");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserEdit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            UserModel userModel = new UserModel()
            {
                Id = id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            };
            return View(userModel);
        }
        [HttpPost]
        public async Task<IActionResult> UserEdit(UserModel userModel)
        {
            if (userModel != null)
            {
                var user = await _userManager.FindByIdAsync(userModel.Id);
                user.FirstName = userModel.FirstName;
                user.LastName = userModel.LastName;
                user.Email = userModel.Email;

                user.UserName = Jobs.MakeUserName(userModel.FirstName) + "-" + Jobs.MakeUserName(userModel.LastName);

                var userUpdate = await _userManager.UpdateAsync(user);
                if (userUpdate.Succeeded)
                {
                    if (!String.IsNullOrWhiteSpace(userModel.Password))
                    {
                        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                        var result = await _userManager.ResetPasswordAsync(user, token, userModel.Password);

                        if (result.Succeeded)
                        {
                            TempData["Message"] = $"{userModel.FirstName} {userModel.LastName} adlı kullanıcı güncellendi!";
                            return View(userModel);
                        }
                    }

                    TempData["Message"] = $"{userModel.FirstName} {userModel.LastName} adlı kullanıcı güncellendi!";
                    return View(userModel);
                }
            }

            TempData["Error"] = "Bir hata oluştu!";
            return RedirectToAction("UserList");
        }

        public async Task<IActionResult> UserDelete(string id)
        {
            if (!String.IsNullOrWhiteSpace(id))
            {
                User user = await _userManager.FindByIdAsync(id);


                if (user == null)
                {
                    TempData["Error"] = "Kullanıcı bulunamadı!";
                    return RedirectToAction("UserList");
                }

                var reslt = await _userManager.DeleteAsync(user);
                if (reslt.Succeeded)
                {
                    TempData["Message"] = $"{user.FirstName} {user.LastName} adlı kullanıcı silindi!";
                    return RedirectToAction("UserList");
                }
            }

            TempData["Error"] = "Kullanıcı silinemedi!";
            return RedirectToAction("UserList");
        }

    }
}
