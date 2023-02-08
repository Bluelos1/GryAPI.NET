using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GryAPI.NET.Data;
using GryAPI.NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GryAPI.NET.Controllers
{
    [ApiController]
    [Route("api/game")]
    public class GameController : Controller
    {
        private readonly GameAPIDbContext dbContext;

        public GameController(GameAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            return Ok(await dbContext.Games.ToListAsync());
             
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame(CreateGame createGame)
        {
            Game game = new Game()
            {
                Id = Guid.NewGuid(),
                Title = createGame.Title,
                PublishYear = createGame.PublishYear,
                Publisher = createGame.Publisher,
                Genre = createGame.Genre
            };
            await dbContext.Games.AddAsync(game);
            await dbContext.SaveChangesAsync();
            return Ok(game);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateGame([FromRoute] Guid id, UpdateGame updateGame)
        {
            var game = await dbContext.Games.FindAsync(id);
            if (game != null)
            {
                game.Title = updateGame.Title;
                game.PublishYear = updateGame.PublishYear;
                game.Publisher = updateGame.Publisher;
                game.Genre = updateGame.Genre;

                await dbContext.SaveChangesAsync();
                return Ok(game);
            }

            return NotFound();
        }
    }
}