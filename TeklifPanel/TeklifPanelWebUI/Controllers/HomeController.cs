using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TeklifPanel.Data.Concrete.EfCore;

namespace TeklifPanelWebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}