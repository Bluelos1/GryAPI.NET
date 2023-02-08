using System;
using GryAPI.NET.Models;
using Microsoft.EntityFrameworkCore;


namespace GryAPI.NET.Data
{
    public class GameAPIDbContext : DbContext
    {
        public GameAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; } 
    }
}

