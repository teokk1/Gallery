using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
	public abstract class BaseEntity
	{
		[Key]
		public int Id { get; set; }

		public DateTime LastUpdate { get; set; }
	}

	public abstract class NamedEntity : BaseEntity
	{
		[Required, MinLength(1), MaxLength(300)]
		public string Name { get; set; }
	}
}