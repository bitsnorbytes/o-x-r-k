using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace Scullery.Models
{
    public class Genre
    {
        [Column("Id")]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [Column("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [Key]
        [Column("genre_id")]
        public int GenreId { get; set; }
    }
}