// Krav 3 - Oppretter klassen ApplicationDbContext:
using Microsoft.EntityFrameworkCore;
using Gruppe20App.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



namespace Gruppe20App.Data
{
    // public class ApplicationDbContext : DbContext

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Organisasjon> Organisasjoner { get; set; }
        public DbSet<RollePerson> RollePersoner { get; set; }
    }
}
