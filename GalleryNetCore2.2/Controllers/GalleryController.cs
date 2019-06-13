using DAL;
using GalleryNetCore2._2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Model.Entities;
using Model.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GalleryNetCore2._2.Controllers
{
	public class GalleryController : BaseController
	{
		public GalleryController(AppDbContext dbContext) : base(dbContext)
		{
		}

		IIncludableQueryable<Product, Artist> db_set()
		{
			return dbContext.Products.Include(p => p.Image).Include(p => p.Artist);
		}

		public IActionResult Index()
		{
			return View(db_set().ToList());
		}

		[HttpPost]
		//[AllowAnonymous]
		public ActionResult Search(ProductFilterModel filter)
		{
			var query = db_set().AsQueryable();

			query = filter_name(query, filter.Name);
			query = filter_artist(query, filter.Name);
			query = filter_tags(query, filter.Tags);
			query = filter_materials(query, filter.Tags);

			return PartialView("Partial/_GalleryPartial", query.ToList());
		}

		IQueryable<Product> filter_name(IQueryable<Product> query, string name) => filter(query, name);
		IQueryable<Product> filter_artist(IQueryable<Product> query, string artist) => filter(query, artist);

		IQueryable<Product> filter(IQueryable<Product> query, string s) => valid_field(s) ? query.Where(p => contains(p.Name, s)) : query;

		bool valid_field(string field) => string.IsNullOrWhiteSpace(field) == false;
		bool contains(string source, string contained) => source.Contains(contained, StringComparison.CurrentCultureIgnoreCase);

		IQueryable<Product> filter_tags(IQueryable<Product> query, string tagString)
		{
			return filter_multiple(query, split(tagString), (p, l) => p.Tags.Any(t => l.Contains(t.Tag.Value)));
		}

		IQueryable<Product> filter_materials(IQueryable<Product> query, string materialString)
		{
			return filter_multiple(query, split(materialString), (p, l) => p.Materials.Any(t => l.Contains(t.Material.Name)));
		}

		IQueryable<Product> filter_multiple(IQueryable<Product> query, List<string> list, Func<Product, List<string>, bool> func)
		{
			return list?.Count > 0 ? query.Where(p => func(p, list)) : query;
		}

		List<string> split(string s) => s?.Split(' ', ',').Where(valid_field).ToList();
	}
}