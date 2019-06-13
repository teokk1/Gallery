
using Model.Entities.Products;
using System.Collections.Generic;
using System.Linq;

namespace GalleryNetCore2._2.API.DTO
{
	public class ProductDto
	{
		public int Id { get; set; }

		public string Type { get; set; }

		public string Image { get; set; }

		public float Width { get; set; }
		public float Height { get; set; }
		public float Depth { get; set; }

		public List<string> Tags { get; set; }
		public List<string> Materials { get; set; }

		void init_product_fields(Product p)
		{
			this.Id = p.Id;

			this.Image = p.Image?.Url;

			this.Width = p.Width;
			this.Height = p.Height;

			this.Tags = p.Tags?.Select(t => t.Tag.Value).ToList();
			this.Materials = p.Materials?.Select(t => t.Material.Name).ToList();
		}

		//public ProductDto(Painting p)
		//{
		//	this.Type = nameof(Painting);
		//	this.Depth = -1;

		//	init_product_fields(p);
		//}

		//public ProductDto(Sculpture s)
		//{
		//	this.Type = nameof(Sculpture);
		//	this.Depth = s.Depth;

		//	init_product_fields(s);
		//}

		public ProductDto(Product p)
		{
			this.Type = p is Sculpture ? nameof(Sculpture) : nameof(Painting);
			this.Depth = p is Sculpture s ? s.Depth : -1;

			init_product_fields(p);
		}
	}
}
