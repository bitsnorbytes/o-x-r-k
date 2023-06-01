using Microsoft.EntityFrameworkCore;
using Postgrest.Attributes;
namespace Scullery.Data {
public class CinemacatalogingContext : DbContext
{
    public CinemacatalogingContext(DbContextOptions<CinemacatalogingContext> options)
        : base(options)
    {
    }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
}

public class Movie
{
    public int Id { get; set; }
    [Column("movie_id")]

    public int MovieId { get; set; }
    [Column("name")]
    public string Name { get; set; }

    public List<Genre> Genres { get; } = new();
}

public class Genre
{
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
     [Column("genre_id")]
    public int GenreId { get; set; }
    public Movie Movie { get; set; }
}
}
