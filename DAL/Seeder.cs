using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Entities.Products;
using Model.Entities.Utility;

namespace DAL
{
	public static class Seeder
	{
		public static void seed(ModelBuilder modelBuilder)
		{
			seed_roles(modelBuilder);
			seed_materials(modelBuilder);
			seed_tags(modelBuilder);
			seed_artists(modelBuilder);
			seed_products(modelBuilder);
		}

		static void seed_roles(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole("Admin"));
			modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole("GalleryManager"));
		}

		static void seed_materials(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Material>().HasData(new Material { Id = -1, Name = "Bakar" });
			modelBuilder.Entity<Material>().HasData(new Material { Id = -2, Name = "Ćelik" });
			modelBuilder.Entity<Material>().HasData(new Material { Id = -3, Name = "Drvo" });
		}

		static void seed_tags(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Tag>().HasData(new Tag { Id = -1, Value = "Apstraktno" });
			modelBuilder.Entity<Tag>().HasData(new Tag { Id = -2, Value = "Realistično" });
		}

		static void seed_artists(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Artist>().HasData(new Artist { Id = -1, Name = "Nikola", LastName = "Brcic" });
		}

		static void seed_products(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Painting>().HasData(new Painting { Id = -1, ArtistId = -1, Name = "Untitled 1", Height = 2.0f, Width = 1.3f });
			modelBuilder.Entity<Sculpture>().HasData(new Sculpture { Id = -2, ArtistId = -1, Name = "Lopata", Height = 2.0f, Width = 1.3f });
		}
	}
}