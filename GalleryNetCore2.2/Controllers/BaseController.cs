using DAL;
using Microsoft.AspNetCore.Mvc;

namespace GalleryNetCore2._2.Controllers
{
	public class BaseController : Controller
	{
		protected AppDbContext dbContext;

		public BaseController(AppDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
	}
}