using Model.Entities.Utility;

namespace Model.Entities.Intersections
{
	public class ProductTag : ProductIntersection
	{
		public int TagId { get; set; }
		public virtual Tag Tag { get; set; }
	}
}