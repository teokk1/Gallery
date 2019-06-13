using DAL;
using Microsoft.AspNetCore.Mvc;

namespace GalleryNetCore2._2.Controllers
{
	public abstract class BaseController : Controller
	{
		protected AppDbContext dbContext;

		protected BaseController(AppDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
	}
}