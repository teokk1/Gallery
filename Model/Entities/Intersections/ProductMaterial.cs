using Model.Entities.Utility;

namespace Model.Entities.Intersections
{
	public class ProductMaterial : ProductIntersection
	{
		public int MaterialId { get; set; }
		public virtual Material Material { get; set; }
	}
}