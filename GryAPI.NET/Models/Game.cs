using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GryAPI.NET.Models
{
	[Table("game")]
	public class Game
	{
		[Key,Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
		[Required]
		public string Title { get; set; }

		public string PublishYear { get; set; }

		[ForeignKey("Genre")]
        public Guid GenreId { get; set; }

        public Genre Genre { get; set; }

        [ForeignKey("Publisher")]
        public Guid PublisherId { get; set; }

		public Publisher Publisher { get; set; }
       
    }
}

