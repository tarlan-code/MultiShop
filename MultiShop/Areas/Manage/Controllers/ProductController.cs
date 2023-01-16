using Microsoft.AspNetCore.Mvc;
using MultiShop.DAL;

namespace MultiShop.Areas.Manage.Controllers
{
    public class ProductController : Controller
    {
        readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Products);
        }
    }
}
