using System.Text.Json;
using System.Text.Json.Serialization;
namespace Scullery.Services {

public class TMDBMovieList {


    [JsonPropertyName("created_by")]
    public Creator CreatorInfo { get; set; }
    public string? description { get; set; }
    public int favorite_count { get; set; }
    public int id { get; set; }
    public List<TMDBMovie>? items { get; set; }
    public int item_count { get; set; }
    public string? iso_639_1 { get; set; }
    public string? name { get; set; }
    public string? poster_path { get; set; }
}
public class TMDBMovie {
    public bool adult { get; set; }
    public string? backdrop_path { get; set; }
    public int[]? genre_ids { get; set; }
    public int id { get; set; }
    public string? media_type { get; set; }
    public string? original_language { get; set; }
    public string? overview { get; set; }
    public float? popularity { get; set; }
    public string? poster_path { get; set; }
    public DateOnly? release_date { get; set; }
    public string? title { get; set; }
    public bool? video { get; set; }
    public float? vote_average { get; set; }
    public int? popularvote_countity { get; set; }
}
public class Creator {
    [JsonPropertyName("gravatar_hash")]
    public string? GravatarHash { get; set; }
    [JsonPropertyName("id")]
    public string? Id { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
     [JsonPropertyName("username")]
    public string? UserName { get; set; }
}
public class DefaultStringConverter : JsonConverter<string>
{
    public override string Read(
        ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var jsonDoc = JsonDocument.ParseValue(ref reader))
        {
            return jsonDoc.RootElement.GetRawText();
        }
    }

    public override void Write(
        Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
}