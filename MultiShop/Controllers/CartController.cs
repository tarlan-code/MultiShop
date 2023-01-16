using Microsoft.AspNetCore.Mvc;

namespace MultiShop.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
