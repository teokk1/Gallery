using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities.Products;

namespace DAL.Entities.Intersections
{
	public abstract class ProductIntersection
	{
		public int ProductId { get; set; }
		public virtual Product Product { get; set; }
	}
}