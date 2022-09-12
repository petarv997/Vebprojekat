using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class ProjectContext : DbContext
    {
        public DbSet<Supermarket> supermarketi { get; set; }
        public DbSet<Red> redovi { get; set; }
        public DbSet<Skladiste> skladista { get; set; }
        public DbSet<Proizvod> proizvodi { get; set; }
        public DbSet<SProizvod> sproizvodi { get; set; }
        public ProjectContext(DbContextOptions options) : base(options)
        {

        }

    }
}