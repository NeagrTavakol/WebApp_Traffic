using Microsoft.EntityFrameworkCore;
using WebApp_Traffic.Models;

namespace WebApp_Traffic.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Traffic> Traffics { get; set; }
    }
}



