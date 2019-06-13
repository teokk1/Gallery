using DAL;
using Model.Entities;
using Model.Entities.Products;
using Model.Entities.Utility;
using System.Collections.Generic;
using System.Linq;

namespace GalleryNetCore2._2.Models
{
	public class ManageModel
	{
		public List<Product> Products { get; set; }
		public List<Artist> Artists { get; set; }
		public List<Material> Materials { get; set; }
		public List<Tag> Tags { get; set; }

		public ManageModel(AppDbContext dbContext)
		{
			Products = dbContext.Products.ToList();
			Artists = dbContext.Artists.ToList();
			Materials = dbContext.Materials.ToList();
			Tags = dbContext.Tags.ToList();
		}
	}
}
