using System;
namespace GryAPI.NET.Models
{
	public class CreateGame 
	{
        public string Title { get; set; }

        public string PublishYear { get; set; }

        public Publisher Publisher { get; set; }

        public Genre Genre { get; set; }

        public CreateGame()
		{
		}
	}
}

