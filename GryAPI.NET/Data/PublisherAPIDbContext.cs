using System;
using GryAPI.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace GryAPI.NET.Data
{
    public class PublisherAPIDbContext : DbContext
    {
        public PublisherAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Publisher> Publishers { get; set; }
    }
}

