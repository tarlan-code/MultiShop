using Microsoft.AspNetCore.Mvc;

namespace MultiShop.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
