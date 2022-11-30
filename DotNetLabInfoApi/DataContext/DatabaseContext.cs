using DotNetLabInfoApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetLabInfoApi.DataContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> context) : base(context)
        {
        }
        public DbSet<Functionary> Functionary { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}
