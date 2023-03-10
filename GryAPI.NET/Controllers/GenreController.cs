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
        private readonly GameAPIDbContext dbContext;

        public GenreController(GameAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllGenres ()
        {
            return Ok(dbContext.Genres.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetOneGenreById([FromRoute]Guid id)
        {
            var genre = await dbContext.Genres.FindAsync(id);

            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
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

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateGenre([FromRoute] Guid id, UpdateGenre updateGenre)
        {
            var genre = await dbContext.Genres.FindAsync(id);
            if (genre != null)
            {
                genre.Name = updateGenre.Name;
                genre.AltName = updateGenre.AltName;

                await dbContext.SaveChangesAsync();
                return Ok(genre);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteGenreById([FromRoute] Guid id)
        {
            var genre = await dbContext.Genres.FindAsync(id);

            if (genre != null)
            {
                dbContext.Remove(genre);
                await dbContext.SaveChangesAsync();
                return Ok(genre);
            }
            return NotFound();
        }
    }
}