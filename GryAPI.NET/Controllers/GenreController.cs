using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GryAPI.NET.Data;
using GryAPI.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace GryAPI.NET.Controllers
{
    [ApiController]
    [Route("api/genre")]
    public class GenreController : Controller
    {
        private readonly GenreAPIDbContext dbContext;

        public GenreController(GenreAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllGenres ()
        {
            return Ok(dbContext.Genres.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre(CreateGenre createGenre)
        {
            Genre genre = new Genre()
            {
                Id = Guid.NewGuid(),
                Name = createGenre.Name,
                AltName = createGenre.AltName
            };
            await dbContext.Genres.AddAsync(genre);
            await dbContext.SaveChangesAsync();
            return Ok(genre);
        }
    }
}