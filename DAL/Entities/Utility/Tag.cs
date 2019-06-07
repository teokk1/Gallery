using System.Collections.Generic;
using DAL.Entities.Intersections;

namespace DAL.Entities.Utility
{
	public class Tag : BaseEntity
	{
		public string Value { get; set; }

		public virtual ICollection<ProductTag> Products { get; set; }
	}
}