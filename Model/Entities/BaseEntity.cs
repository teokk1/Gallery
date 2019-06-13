using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Entities
{
	public abstract class BaseEntity
	{
		[Key]
		public int Id { get; set; }

		public DateTime LastUpdate { get; set; }
	}

	public abstract class NamedEntity : BaseEntity
	{
		[Required(ErrorMessage = "Polje je obavezno"), MinLength(1), MaxLength(300)]
		public string Name { get; set; }
	}
}