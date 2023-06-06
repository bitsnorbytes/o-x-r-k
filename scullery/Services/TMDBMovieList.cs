using System.Text.Json.Serialization;
namespace Scullery.Services
{

    public class TMDBMovieList
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("items")]
        public MovieSummary[]? Items { get; set; }
        [JsonPropertyName("items_count")]
        public int ItemsCount { get; set; }
        [JsonPropertyName("iso_639_1")]
        public string? LanguageCode { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
    public class MovieSummary
     {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}