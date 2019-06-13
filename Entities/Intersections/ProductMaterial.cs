using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities.Products;
using DAL.Entities.Utility;

namespace DAL.Entities.Intersections
{
	public class ProductMaterial : ProductIntersection
	{
		public int MaterialId { get; set; }
		public virtual Material Material { get; set; }
	}
}