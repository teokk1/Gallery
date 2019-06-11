using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;

namespace GalleryNetCore2._2
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddDbContext<AppDbContext>(options => options.UseSqlServer(build_connection_string()));

			services.AddIdentity<User, IdentityRole>()
				.AddRoleManager<RoleManager<IdentityRole>>()
				.AddDefaultUI()
				.AddDefaultTokenProviders()
				.AddEntityFrameworkStores<AppDbContext>();

			services.Configure<IdentityOptions>(options =>
			{
				options.Password.RequireDigit = false;
				options.Password.RequiredLength = 1;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireLowercase = false;
			});

			services.AddAuthentication()
				.AddGoogle(googleOptions =>
				{
					googleOptions.ClientId = Configuration["GoogleSignInId"];
					googleOptions.ClientSecret = Configuration["GoogleSignInSecret"];
				});

			//services.AddDefaultIdentity<User>().AddDefaultUI(UIFramework.Bootstrap4).AddEntityFrameworkStores<AppDbContext>();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		}

		string build_connection_string()
		{
			var builder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("AzureDbConnection"))
			{
				UserID = Configuration["DbUsername"],
				Password = Configuration["DbPassword"],
			};

			return builder.ConnectionString;
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseBrowserLink();
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseAuthentication();

			app.UseMvc(routes =>
			{
				routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
				routes.MapRoute(name: "api/products", template: "{controller=ManagementApi}/{action=Index}");
			});
		}
	}
}