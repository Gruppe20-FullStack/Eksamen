// Krav 3 - Oppretter klassen ApplicationDbContext:
using Microsoft.EntityFrameworkCore;
using Gruppe20App.Models;



namespace Gruppe20App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Organisasjon> Organisasjoner { get; set; }
        public DbSet<RollePerson> RollePersoner { get; set; }
    }
}
