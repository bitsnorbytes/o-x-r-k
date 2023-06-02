using System.ComponentModel.DataAnnotations.Schema;
namespace Scullery.Models
{
public class CinemaCatalogue
    {
        public int Id { get; set; }

        [Column("movie_id")]
        public int MovieId { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("is_adult")]
        public bool IsAdult { get; set; }

        [Column("backdrop_path")]
        public string BackdropPath { get; set; }
        
        [Column("poster_path")]
        public string PosterPath { get; set; }
        [Column("release_date")]
        public DateOnly ReleaseDate { get; set; }
        [Column("overview")]
        public string Overview { get; set; }
        [Column("original_title")]
        public string OriginalTitle { get; set; }
        [Column("original_language")]
        public string OriginalLanguage { get; set; }
        [Column("running_time_in_mins")]
        public string RunningTimeInMinutes { get; set; }
        public List<Genre> Genres { get; } = new();
        public List<MediaType> MediaTypes { get; } = new();
    }
}