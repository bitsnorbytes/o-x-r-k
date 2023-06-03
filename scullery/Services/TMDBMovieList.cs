namespace Scullery.Services {

public class TMDBMovieList {
    public string? created_by { get; set; }
    public string? description { get; set; }
    public int favorite_count { get; set; }
    public int id { get; set; }
    public TMDBMovie[] items { get; set; }
    public int item_count { get; set; }
    public string? iso_639_1 { get; set; }
    public string? name { get; set; }
    public string? poster_path { get; set; }
}
public class TMDBMovie {
    public bool adult { get; set; }
    public string backdrop_path { get; set; }
    public int[] genre_ids { get; set; }
    public int id { get; set; }
    public string media_type { get; set; }
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
}