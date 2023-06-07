using System.Text.Json.Serialization;
namespace Scullery.Services
{

    public class TMDBGenreList
    {
        [JsonPropertyName("genres")]
        public List<TMDBGenre> Genres { get; set; } = new List<TMDBGenre>();
    }
   public class TMDBGenre
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }

    }
}