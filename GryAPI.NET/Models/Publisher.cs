using System.ComponentModel.DataAnnotations;

namespace GryAPI.NET.Models
{
    public class Publisher
    {
        [Key, Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
        
        public int NumberOfEmployees { get; set; }

        public List<Game> Games { get; set; }


    }
}