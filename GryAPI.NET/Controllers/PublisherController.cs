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
    [Route("api/publisher")]
    public class PublisherController : Controller
    {
        private readonly PublisherAPIDbContext dbContext;

        public PublisherController(PublisherAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPublishers()
        {
            return Ok(await dbContext.Publishers.ToListAsync());
        }

        [HttpGet]
        [Route("{guid:id}")]
        public async Task<IActionResult> GetOnePublisherById([FromRoute] Guid id)
        {
            var publisher = await dbContext.Publishers.FindAsync(id);

            if (publisher == null)
            {
                return NotFound();
            }
            return Ok(publisher);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePublisher(CreatePublisher createPublisher)
        {
            Publisher publisher = new Publisher()
            {
                Id = Guid.NewGuid(),
                Name = createPublisher.Name,
                Country = createPublisher.Country,
                NumberOfEmployees = createPublisher.NumberOfEmployees
            };
            await dbContext.Publishers.AddAsync(publisher);
            await dbContext.SaveChangesAsync();
            return Ok(publisher);
        }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdatePublisher([FromRoute] Guid id, UpdatePublisher updatePublisher)
        {
            var publisher = await dbContext.Publishers.FindAsync(id);
            if (publisher != null)
            {
                publisher.Name = updatePublisher.Name;
                publisher.Country = updatePublisher.Country;
                publisher.NumberOfEmployees = updatePublisher.NumberOfEmployees;

                await dbContext.SaveChangesAsync();
                return Ok(publisher);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeletePublisher([FromRoute] Guid id)
        {
            var publisher = await dbContext.Publishers.FindAsync(id);

            if (publisher != null)
            {
                dbContext.Remove(publisher);
                await dbContext.SaveChangesAsync();
                return Ok(publisher);
            }
            return NotFound();
        }
    }
}