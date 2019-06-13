using Model.Entities.Intersections;
using System.Collections.Generic;

namespace Model.Entities.Utility
{
	public class Material : NamedEntity
	{
		public virtual ICollection<ProductMaterial> Products { get; set; }
	}
}
