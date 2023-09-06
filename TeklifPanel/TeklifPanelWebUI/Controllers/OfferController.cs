using Microsoft.AspNetCore.Mvc;

namespace TeklifPanelWebUI.Controllers
{
    public class OfferController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OfferList()
        {
            return View();
        }
        public IActionResult AddOffer()
        {
            return View();
        }
    }
}
