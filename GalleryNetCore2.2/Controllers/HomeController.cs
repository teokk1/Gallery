using DAL;
using GalleryNetCore2._2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities.Products;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GalleryNetCore2._2.Controllers
{
	public class HomeController : BaseController
	{
		public HomeController(AppDbContext dbContext) : base(dbContext)
		{
		}

		public List<Product> random_products(int count) => dbContext.Products.Include(p => p.Image).Include(p => p.Artist).OrderBy(q => Guid.NewGuid()).Take(count).ToList();

		public IActionResult Index()
		{
			return View(random_products(3));
		}

		public IActionResult Gallery()
		{
			return RedirectToRoute("gallery");
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
