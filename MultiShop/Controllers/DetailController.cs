using Microsoft.AspNetCore.Mvc;

namespace MultiShop.Controllers
{
    public class DetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
