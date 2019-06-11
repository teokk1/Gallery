using DAL;
using DAL.Entities.Products;
using GalleryNetCore2._2.API.DTO;
using GalleryNetCore2._2.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryNetCore2._2.API.ApiControllers
{
	[Route("api/manage")]
	[ApiController]
	public class ManagementApiController : BaseController
	{
		public ManagementApiController(AppDbContext dbContext) : base(dbContext)
		{
		}

		[HttpGet("products")]
		public List<ProductDto> get() => dbContext.Products.Select(p => new ProductDto(p)).ToList();

		[HttpGet("products/{id}")]
		public ProductDto get(int id) => new ProductDto(dbContext.Products.Find(id));

		[HttpPost("create-product")]
		[Authorize(Roles = "Admin,Manager")]
		public ActionResult<ProductDto> create([FromBody] Product product)
		{
			if (ModelState.IsValid == false)
				return BadRequest(ModelState);

			//TODO materials, tags, paintings, sculptures
			dbContext.Products.Add(product);
			dbContext.SaveChanges();

			return get(product.Id);
		}

		[HttpPut("products/update/{id}")]
		[Authorize(Roles = "Admin,Manager")]
		public async Task<ActionResult<ProductDto>> update(int id, [FromBody] JObject productModel)
		{
			var product = dbContext.Products.Find(id);

			if (product != null)
			{
				product.LastUpdate = DateTime.Now;

				if (ModelState.IsValid && await TryUpdateModelAsync(product, "", new ObjectSourceValueProvider(productModel)))
				{
					dbContext.SaveChanges();
					return get(id);
				}
			}
			else
				ModelState.AddModelError("id", "Invalid client ID");

			return BadRequest(ModelState);
		}

		[Authorize(Roles = "Admin")]
		[HttpDelete("delete/{id}")]
		public IActionResult delete(int id)
		{
			var product = dbContext.Products.Find(id);
			if (product != null)
			{
				dbContext.Entry(product).State = EntityState.Deleted;
				dbContext.SaveChanges();
				return Ok();
			}

			return BadRequest(new { error = $"Couldn't delete {id}" });
		}
	}

	public class ObjectSourceValueProvider : IValueProvider
	{
		readonly JObject obj;

		public ObjectSourceValueProvider(JObject obj) => this.obj = obj;

		public bool ContainsPrefix(string prefix) => obj.Properties().Any(p => p.Name == prefix);

		public ValueProviderResult GetValue(string key)
		{
			var prop = obj.Properties().FirstOrDefault(p => p.Name.ToLower() == key?.ToLower());
			return prop == null ? ValueProviderResult.None : new ValueProviderResult(prop.Value.ToString());
		}
	}
}
