using Microsoft.EntityFrameworkCore;
namespace Scullery.Models
{
    public class CinemaCatalogingContext : DbContext
    {
        public CinemaCatalogingContext(DbContextOptions<CinemaCatalogingContext> options)
            : base(options)
        {}
        public DbSet<CinemaCatalogue> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
    }
}