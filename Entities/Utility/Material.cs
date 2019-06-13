using System.Collections;
using System.Collections.Generic;
using DAL.Entities.Intersections;

namespace DAL.Entities.Utility
{
	public class Material : NamedEntity
	{
		public virtual ICollection<ProductMaterial> Products { get; set; }
	}
}
