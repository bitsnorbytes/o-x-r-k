using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace Scullery.Models
{
public class CinemaCatalogue
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [Column("title")]
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [Column("adult")]
        [JsonPropertyName("adult")]
        public bool IsAdult { get; set; }
        [Column("secure_base_image_URL")]
        public string SecureBaseImageURL { get; set; }
        [Column("poster_sizes")]
        public List<string> PosterSizes { get; set; } = new List<string>();
        [Column("backdrop_sizes")]
        public List<string> BackdropSizes { get; set; } = new List<string>();
        [Column("backdrop_path")]
        [JsonPropertyName("backdrop_path")]
        public string BackdropPath { get; set; }
        [Column("poster_path")]
        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }
        [Column("release_date")]
        [JsonPropertyName("release_date")]
        public DateOnly ReleaseDate { get; set; }
        [Column("overview")]
        [JsonPropertyName("overview")]
        public string Overview { get; set; }
        [Column("original_title")]
        [JsonPropertyName("original_title")]
        public string OriginalTitle { get; set; }
        [Column("original_language")]
        [JsonPropertyName("original_language")]
        public string OriginalLanguage { get; set; }
        [Column("runtime")]
        [JsonPropertyName("runtime")]
        public int RunTimeInMinutes { get; set; }
        [Column("genre_ids")]
        public int[]? GenreIds { get; set; } 
        [Column("media_type")]
        public string? MediaType { get; set; } 
        [Column("imdb_id")]
        [JsonPropertyName("imdb_id")]
        public string imdbId { get; set; }
        
    }
}