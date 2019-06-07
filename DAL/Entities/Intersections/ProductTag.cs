using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities.Utility;

namespace DAL.Entities.Intersections
{
	public class ProductTag : ProductIntersection
	{
		public int TagId { get; set; }
		public virtual Tag Tag { get; set; }
	}
}