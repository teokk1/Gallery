using Model.Entities.Products;

namespace Model.Entities.Intersections
{
	public abstract class ProductIntersection
	{
		public int ProductId { get; set; }
		public virtual Product Product { get; set; }
	}
}