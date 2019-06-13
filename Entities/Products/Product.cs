using DAL.Entities.Intersections;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.Products
{
	public abstract class Product : NamedEntity
	{
		[ForeignKey("ArtistId")]
		public int? ArtistId { get; set; }
		public virtual Artist Artist { get; set; }

		public DateTime CreationDateTime { get; set; }

		public virtual ICollection<ProductTag> Tags { get; set; }
		public virtual ICollection<ProductMaterial> Materials { get; set; }

		public virtual Image Image { get; set; }

		[Range(0, 999, ErrorMessage = "Dimenzije moraju biti između 0 i 999")]
		public float Width { get; set; }

		[Range(0, 999, ErrorMessage = "Dimenzije moraju biti između 0 i 999")]
		public float Height { get; set; }
	}
}