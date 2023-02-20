using System;
namespace GryAPI.NET.Models
{
	public class UpdateGame
	{
        public string Title { get; set; }

        public string PublishYear { get; set; }

        public Guid PublisherId { get; set; }

        public Guid GenreId { get; set; }
		
	}
}

