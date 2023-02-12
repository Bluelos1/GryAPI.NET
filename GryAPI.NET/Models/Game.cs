using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GryAPI.NET.Models
{
	[Table("game")]
	public class Game
	{
		[Key,Required]
		public Guid Id { get; set; }
		[Required]
		public string Title { get; set; }

		public string PublishYear { get; set; }

		public int PublisherId { get; set; }

        public Publisher Publisher { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }





		public Game()
		{
		}
	}
}

