using System.ComponentModel.DataAnnotations;

namespace DAL.Entities.Products
{
	public class Sculpture : Product
	{
		[Range(0, 999, ErrorMessage = "Dimenzije moraju biti između 0 i 999")]
		public float Depth { get; set; }
	}
}