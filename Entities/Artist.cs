using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
	public class Artist : NamedEntity
	{
		[Required(ErrorMessage = "Prezime je obavezno"), MinLength(1), MaxLength(300)]
		public string LastName { get; set; }

		public DateTime BirthDate { get; set; }
	}
}