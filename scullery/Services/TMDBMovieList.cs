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
    //     public bool adult { get; set; }
    //     public string? backdrop_path { get; set; }
    //     public int[]? genre_ids { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        // public string? media_type { get; set; }
        // public string? original_language { get; set; }
        // public string? overview { get; set; }
        // public float? popularity { get; set; }
        // public string? poster_path { get; set; }
        // public DateOnly? release_date { get; set; }
        // public string? title { get; set; }
        // public bool? video { get; set; }
        // public float? vote_average { get; set; }
        // public int? popularvote_countity { get; set; }
    }
}