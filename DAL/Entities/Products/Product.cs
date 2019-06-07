using System.Collections;
using System.Collections.Generic;
using DAL.Entities.Intersections;

namespace DAL.Entities.Products
{
	public abstract class Product : NamedEntity
	{
		public virtual ICollection<ProductTag> Tags { get; set; }
		public virtual ICollection<ProductMaterial> Materials { get; set; }
	}
}