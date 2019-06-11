using DAL.Entities;
using DAL.Entities.Intersections;
using DAL.Entities.Products;
using DAL.Entities.Utility;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
	public class AppDbContext : IdentityDbContext<User>
	{
		public DbSet<Artist> Artists { get; set; }

		public DbSet<Product> Products { get; set; }

		public DbSet<Painting> Paintings { get; set; }
		public DbSet<Sculpture> Sculptures { get; set; }

		//public DbSet<Image> Images { get; set; }

		public DbSet<Material> Materials { get; set; }
		public DbSet<Tag> Tags { get; set; }

		public DbSet<ProductMaterial> ProductMaterials { get; set; }
		public DbSet<ProductTag> ProductTags { get; set; }

		public AppDbContext(DbContextOptions options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			init_intersection_tables(modelBuilder);

			Seeder.seed(modelBuilder);
		}

		void init_intersection_tables(ModelBuilder modelBuilder)
		{
			init_product_material_intersection(modelBuilder);
			init_product_tag_intersection(modelBuilder);
		}

		void init_product_material_intersection(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ProductMaterial>().HasKey(pm => new { pm.ProductId, pm.MaterialId });
			modelBuilder.Entity<ProductMaterial>().HasOne(pm => pm.Product).WithMany(p => p.Materials).HasForeignKey(m => m.ProductId);
			modelBuilder.Entity<ProductMaterial>().HasOne(pm => pm.Material).WithMany(m => m.Products).HasForeignKey(p => p.MaterialId);
		}

		void init_product_tag_intersection(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ProductTag>().HasKey(pt => new { pt.ProductId, pt.TagId });
			modelBuilder.Entity<ProductTag>().HasOne(pt => pt.Product).WithMany(p => p.Tags).HasForeignKey(t => t.ProductId);
			modelBuilder.Entity<ProductTag>().HasOne(pt => pt.Tag).WithMany(t => t.Products).HasForeignKey(p => p.TagId);
		}
	}
}