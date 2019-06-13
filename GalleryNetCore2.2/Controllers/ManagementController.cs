using DAL;
using GalleryNetCore2._2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Entities.Products;
using Model.Entities.Utility;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryNetCore2._2.Controllers
{
	[Route("manage")]
	[Authorize(Roles = "Admin,GalleryManager")]
	public class ManagementController : BaseController
	{
		IHostingEnvironment hostingEnvironment;

		public ManagementController(AppDbContext dbContext, IHostingEnvironment hostingEnvironment) : base(dbContext)
		{
			this.hostingEnvironment = hostingEnvironment;
		}

		[Route("")]
		public IActionResult Index() => View(new ManageModel(dbContext));

		[HttpPost("delete-product/{id}")]
		public IActionResult delete_product(int id) => delete_entity(id, dbContext.Products);

		[HttpPost("delete-artist/{id}")]
		public IActionResult delete_artist(int id) => delete_entity(id, dbContext.Artists);

		[HttpPost("delete-material/{id}")]
		public IActionResult delete_material(int id) => delete_entity(id, dbContext.Materials);

		[HttpPost("delete-tag/{id}")]
		public IActionResult delete_tag(int id) => delete_entity(id, dbContext.Tags);

		public IActionResult delete_entity<T>(int id, DbSet<T> set) where T : class
		{
			var entity = set.Find(id);

			if (entity == null)
				return RedirectToAction(nameof(Index));

			dbContext.Entry(entity).State = EntityState.Deleted;
			dbContext.SaveChanges();

			return RedirectToAction(nameof(Index));
		}

		[HttpGet("edit-product/{id}")]
		public IActionResult edit_product_view(int id)
		{
			fill_artist_dropdown_list();
			return View("Edit/EditProduct", dbContext.Products.Find(id));
		}

		[HttpGet("edit-artist/{id}")]
		public IActionResult edit_artist_view(int id)
		{
			return View("Edit/EditArtist", dbContext.Artists.Find(id));
		}

		[HttpGet("edit-material/{id}")]
		public IActionResult edit_material_view(int id)
		{
			return View("Edit/EditMaterial", dbContext.Materials.Find(id));
		}

		[HttpGet("edit-tag/{id}")]
		public IActionResult edit_tag_view(int id)
		{
			return View("Edit/EditTag", dbContext.Tags.Find(id));
		}

		[HttpPost("edit-product/{id}")]
		public Task<IActionResult> edit_product(int id) => edit_entity(id, dbContext.Products, "Edit/EditProduct");

		[HttpPost("edit-artist/{id}")]
		public Task<IActionResult> edit_artist(int id) => edit_entity(id, dbContext.Artists, "Edit/EditArtist");

		[HttpPost("edit-material/{id}")]
		public Task<IActionResult> edit_material(int id) => edit_entity(id, dbContext.Materials, "Edit/EditMaterial");

		[HttpPost("edit-tag/{id}")]
		public Task<IActionResult> edit_tag(int id) => edit_entity(id, dbContext.Tags, "Edit/EditTag");

		public async Task<IActionResult> edit_entity<T>(int id, DbSet<T> set, string view) where T : class
		{
			var entity = set.Find(id);

			if (entity == null)
				return View(view);

			if (await TryUpdateModelAsync(entity) == false)
				return View(view, entity);

			dbContext.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

		[HttpGet("create-product")]
		public IActionResult create_product_view(int id)
		{
			fill_artist_dropdown_list();
			return View("Create/CreateProduct", dbContext.Products.Find(id));
		}

		[HttpGet("create-artist")]
		public IActionResult create_artist_view(int id)
		{
			return View("Create/CreateArtist", dbContext.Artists.Find(id));
		}

		[HttpGet("create-material")]
		public IActionResult create_material_view(int id)
		{
			return View("Create/CreateMaterial", dbContext.Materials.Find(id));
		}

		[HttpGet("create-tag")]
		public IActionResult create_tag_view(int id)
		{
			return View("Create/CreateTag", dbContext.Tags.Find(id));
		}

		[HttpPost("create-product")]
		public IActionResult create_product(Product model) => create_entity(dbContext.Products, model, nameof(Index));

		[HttpPost("create-artist")]
		public IActionResult create_artist(Artist model) => create_entity(dbContext.Artists, model, nameof(Index));

		[HttpPost("create-material")]
		public IActionResult create_material(Material model) => create_entity(dbContext.Materials, model, nameof(Index));

		[HttpPost("create-tag")]
		public IActionResult create_tag(Tag model) => create_entity(dbContext.Tags, model, nameof(Index));

		public IActionResult create_entity<T>(DbSet<T> set, T entity, string view) where T : class
		{
			set.Add(entity);
			dbContext.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public async Task<ActionResult<string>> set_imageAsync(int productId, IFormFile file)
		{
			var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
			Directory.CreateDirectory(uploads);

			if (file.Length > 0)
			{
				//var fileName = Guid.NewGuid() + file.FileName.Split('.').Last();
				var fileName = file.FileName;
				var filePath = Path.Combine(uploads, fileName);
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					await file.CopyToAsync(fileStream);
				}

				var image = new Image { Url = $"/uploads/{fileName}" };
				dbContext.Images.Add(image);

				var product = dbContext.Products.Find(productId);
				if (product != null)
					product.Image = image;

				dbContext.SaveChanges();
			}

			return file.Name;
		}

		private void fill_artist_dropdown_list() => ViewBag.PossibleArtists = dbContext.Artists.Select(a => new SelectListItem { Value = $"{a.Id}", Text = a.Name + a.LastName });
		private void fill_material_dropdown_list() => ViewBag.PossibleMaterials = dbContext.Materials.Select(m => new SelectListItem { Value = $"{m.Id}", Text = m.Name });
		private void fill_tag_dropdown_list() => ViewBag.PossibleTags = dbContext.Tags.Select(t => new SelectListItem { Value = $"{t.Id}", Text = t.Value });
	}
}