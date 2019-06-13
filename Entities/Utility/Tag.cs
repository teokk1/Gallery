using DAL.Entities.Intersections;
using System.Collections.Generic;

namespace DAL.Entities.Utility
{
	public class Tag : BaseEntity
	{
		public string Value { get; set; }

		public virtual ICollection<ProductTag> Products { get; set; }
	}
}