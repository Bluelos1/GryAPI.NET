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
    }
}