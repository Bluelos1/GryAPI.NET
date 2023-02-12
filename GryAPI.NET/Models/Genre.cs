using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GryAPI.NET.Models
{
	[Table("genre")]
	public class Genre
	{
		[Key, Required]
		public Guid Id { get; set; }
		[Required]
		public string Name { get; set; }

		public string AltName { get; set; }

		public List<Game> Games { get; set; }

		public Genre()
		{
		}
	}
}

