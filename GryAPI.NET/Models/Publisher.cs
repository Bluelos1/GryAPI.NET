using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GryAPI.NET.Models
{
    [Table("publisher")]
    public class Publisher
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
        
        public int NumberOfEmployees { get; set; }

        public List<Game> Games { get; set; }

    }
}