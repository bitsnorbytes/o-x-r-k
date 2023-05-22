namespace darkRoom.Models;
// Given the following Model representing the Supabase Database (Message.cs)
using Postgrest.Attributes;
using Postgrest.Models;

[Table("Genre")]
public class Genre : BaseModel
{
    [PrimaryKey("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("genre_id")]
    public int GenreId { get; set; }
}