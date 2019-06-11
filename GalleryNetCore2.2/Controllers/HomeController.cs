using DAL;
using GalleryNetCore2._2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace GalleryNetCore2._2.Controllers
{
	public class HomeController : BaseController
	{
		public HomeController(AppDbContext dbContext) : base(dbContext)
		{
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Gallery()
		{
			return View(dbContext.Products.ToList());
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
