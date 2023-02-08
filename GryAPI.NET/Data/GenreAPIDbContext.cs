using System;
using GryAPI.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace GryAPI.NET.Data
{
	public class GenreAPIDbContext : DbContext
	{
        public GenreAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Genre> Genres { get; set; }
    }
}

