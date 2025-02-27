using AsyncMvcApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace AsyncMvcApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
