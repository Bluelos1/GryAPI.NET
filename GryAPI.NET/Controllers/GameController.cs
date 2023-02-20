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

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetOneGameById([FromRoute]Guid id)
        {
            var game = await dbContext.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame([FromBody]CreateGame createGame)
        {
            var game = new Game
            {
                Title = createGame.Title,
                PublishYear = createGame.PublishYear,
                GenreId = createGame.GenreId,
                PublisherId = createGame.PublisherId
            };

            dbContext.Games.Add(game);
            dbContext.SaveChanges();

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
                game.PublisherId = updateGame.PublisherId;
                game.GenreId = updateGame.GenreId;

                await dbContext.SaveChangesAsync();
                return Ok(game);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task <IActionResult> DeleteGame([FromRoute] Guid id)
        {
                var game = await dbContext.Games.FindAsync(id);

            if (game != null)
            {
                dbContext.Remove(game);
                await dbContext.SaveChangesAsync();
                return Ok(game);
            }
            return NotFound();
        }
    }
}