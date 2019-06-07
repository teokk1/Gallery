using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
	public abstract class BaseEntity
	{
		public int Id { get; set; }
	}

	public abstract class NamedEntity : BaseEntity
	{
		public string Name { get; set; }
	}
}