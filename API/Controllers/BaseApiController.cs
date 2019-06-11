using DAL;
using Microsoft.AspNetCore.Mvc;

namespace API
{
	[AP]
	public class BaseController : Controller
	{
		protected AppDbContext dbContext;

		public BaseController(AppDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
	}
}