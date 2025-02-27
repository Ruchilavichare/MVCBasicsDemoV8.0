using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Models;


namespace MVC_CRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Add DbSet for each model
        public DbSet<User> Users { get; set; }
    }
}
