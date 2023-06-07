using System.Text.Json.Serialization;
namespace Scullery.Services
{

    public class TMDBConfiguration
    {
        [JsonPropertyName("images")]
        public TMDBImage Images { get; set; }
        [JsonPropertyName("change_keys")]
        public List<string> ChangeKeys { get; set; } = new List<string>();
    }
   public class TMDBImage
    {
        [JsonPropertyName("base_url")]
        public string? BaseURL { get; set; }
        [JsonPropertyName("secure_base_url")]
        public string? SecureBaseImageURL { get; set; }
        [JsonPropertyName("backdrop_sizes")]
        public List<string> BackdropSizes  { get; set; } = new List<string>();
         [JsonPropertyName("logo_sizes")]
        public List<string> LogoSizes  { get; set; } = new List<string>();
         [JsonPropertyName("poster_sizes")]
        public List<string> PosterSizes  { get; set; } = new List<string>();
         [JsonPropertyName("profile_sizes")]
        public List<string> ProfileSizes  { get; set; } = new List<string>();
         [JsonPropertyName("still_sizes")]
        public List<string> StillSizes  { get; set; } = new List<string>();

    }
}