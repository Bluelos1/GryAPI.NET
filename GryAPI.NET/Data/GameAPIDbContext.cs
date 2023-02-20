using System;
using System.Configuration;
using GryAPI.NET.Models;
using Microsoft.EntityFrameworkCore;


namespace GryAPI.NET.Data
{
    public class GameAPIDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public GameAPIDbContext(DbContextOptions<GameAPIDbContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("GryApiDatabase"));
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

    }
}

