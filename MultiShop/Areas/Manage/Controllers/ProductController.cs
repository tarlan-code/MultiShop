using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DAL;
using MultiShop.Models;
using MultiShop.ViewModels;
using MultiShop.Utilies.Extensions;

namespace MultiShop.Areas.Manage.Controllers
{
	[Area(nameof(Manage))]
	public class ProductController : Controller
	{
		readonly AppDbContext _context;
		readonly IWebHostEnvironment _env;

		public ProductController(AppDbContext context, IWebHostEnvironment env)
		{
			_context = context;
			_env = env;
		}

		public IActionResult Index()
		{
			return View(_context.Products);
		}

		public IActionResult Create()
		{
			ViewBag.Categories = new SelectList(_context.Categories, nameof(Category.Id), nameof(Category.Name));
			ViewBag.Colors = new SelectList(_context.Colors, nameof(Category.Id), nameof(Category.Name));
			ViewBag.Sizes = new SelectList(_context.Sizes, nameof(Size.Id), nameof(Size.Name));
			ViewBag.Discounts = new SelectList(_context.Discounts, nameof(Discount.Id), nameof(Discount.Name));
			ViewBag.Infos = new SelectList(_context.ProductInfos, nameof(ProductInfo.Id), nameof(ProductInfo.Key));
			return View();
		}

		[HttpPost]
		public IActionResult Create(CreateProductVM prod)
		{
			var CoverImg = prod?.CoverImage;
			var OtherImgs = prod?.OtherImages;


			string result = CoverImg?.CheckValidate("image/", 300) ?? "";
			if (result.Length > 0) ModelState.AddModelError("Coverimg", result);

			if (OtherImgs is not null)
			{
				foreach (var img in OtherImgs)
				{
					result = img?.CheckValidate("image/", 300);
					if (result.Length > 0) ModelState.AddModelError("OtherImages", result);
				}
			}

			if (prod?.ColorIds is not null)
			{
				var colors = _context.Colors;
				foreach (int id in prod.ColorIds)
				{
					if (!colors.Any(c => c.Id == id)) ModelState.AddModelError("ColorIds", "Color id is wrong");
					break;
				}
			}

			if (prod?.SizeIds is not null)
			{
				var sizes = _context.Sizes;
				foreach (int id in prod.SizeIds)
				{
					if (!sizes.Any(s => s.Id == id)) ModelState.AddModelError("SizeIds", "Size id is wrong");
					break;
				}
			}


			if (prod?.DiscountId is not null)
			{
				if (!_context.Discounts.Any(d => d.Id == prod.DiscountId)) ModelState.AddModelError("DiscountId", "Discount id is wrong");

			}
			if (prod?.ProductInfoId is not null)
			{
				if (!_context.Discounts.Any(pi => pi.Id == prod.ProductInfoId)) ModelState.AddModelError("ProductInfoId", "Product Info id is wrong");

			}
			if (prod?.CategoryId is not null)
			{
				if (!_context.Categories.Any(c => c.Id == prod.CategoryId)) ModelState.AddModelError("DiscountId", "Caegory id is wrong");

			}




			if (!ModelState.IsValid)
			{
				ViewBag.Categories = new SelectList(_context.Categories, nameof(Category.Id), nameof(Category.Name));
				ViewBag.Colors = new SelectList(_context.Colors, nameof(Category.Id), nameof(Category.Name));
				ViewBag.Sizes = new SelectList(_context.Sizes, nameof(Size.Id), nameof(Size.Name));
				ViewBag.Discounts = new SelectList(_context.Discounts, nameof(Discount.Id), nameof(Discount.Name));
				ViewBag.Infos = new SelectList(_context.ProductInfos, nameof(ProductInfo.Id), nameof(ProductInfo.Key));
				return View();
			}
			var sizesdb = _context.Sizes.Where(s => prod.SizeIds.Contains(s.Id));
			var colorsdb = _context.Colors.Where(col => prod.ColorIds.Contains(col.Id));
			Product newProd = new Product
			{
				Name = prod.Name,
				Desc = prod.Desc,
				SellPrice= prod.SellPrice,
				CostPrice= prod.CostPrice,
				CategoryId = prod.CategoryId,
				DiscountId = prod.DiscountId,
				ProductInfoId= prod.ProductInfoId,
			};

			List<ProductImage> images = new List<ProductImage>();

			images.Add(new ProductImage { ImgUrl = CoverImg.SaveFile(Path.Combine(_env.WebRootPath, "assets", "img")), IsCover=true,Product = newProd,Alternative = CoverImg.FileName});

			if (OtherImgs is not null)
			{
				foreach (IFormFile item in OtherImgs)
				{
					images.Add(new ProductImage { ImgUrl = item.SaveFile(Path.Combine(_env.WebRootPath, "assets", "img")), IsCover = false, Product = newProd ,Alternative = item.FileName});
				}
			}

			newProd.ProductImages= images;

			_context.Products.Add(newProd);

			foreach (var item in colorsdb)
			{
				_context.ProductColors.Add(new ProductColor
				{
					Product = newProd,
					ColorId = item.Id
				});
			}

			foreach (var item in sizesdb)
			{
				_context.ProductSizes.Add(new ProductSize
				{
					Product = newProd,
					SizeiId = item.Id
				});
			}
			_context.SaveChanges();

			return RedirectToAction(nameof(Index));
		}
	}
}
