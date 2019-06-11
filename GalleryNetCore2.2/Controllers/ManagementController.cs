using DAL;
using DAL.Entities.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GalleryNetCore2._2.Controllers
{
	[Route("manage")]
	public class ManagementController : BaseController
	{
		public ManagementController(AppDbContext dbContext) : base(dbContext)
		{
		}

		[Route("")]
		public IActionResult Index()
		{
			return View(dbContext.Products.ToList());
		}

		[HttpGet]
		[Route("create-painting")]
		public IActionResult create_painting_view()
		{
			return View("Create/CreatePainting");
		}

		[HttpGet]
		[Route("edit-painting/{id}")]
		public IActionResult edit_painting_view(int id) => View("Edit/EditProduct", dbContext.Products.Find(id));

		[HttpPost]
		public ActionResult create_painting(Painting painting, IFormFile file)
		{
			dbContext.Paintings.Add(painting);
			dbContext.SaveChanges();

			return Ok();

			//return file.FileName;
		}

		[HttpPost]
		public ActionResult set_image(int productId, IFormFile file)
		{
			//dbContext.Paintings.Add(painting);
			dbContext.SaveChanges();

			return Ok();

			//return file.FileName;
		}
	}
}