﻿using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(GalleryNetCore2._2.Areas.Identity.IdentityHostingStartup))]
namespace GalleryNetCore2._2.Areas.Identity
{
	public class IdentityHostingStartup : IHostingStartup
	{
		public void Configure(IWebHostBuilder builder)
		{
			builder.ConfigureServices((context, services) =>
			{
			});
		}
	}
}