using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
namespace Scullery.Models
{
    [Index(nameof(iso639Code), IsUnique = true)]
   public class Language
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("iso_639_1")]
        [JsonPropertyName("iso_639_1")]
        public string iso639Code { get; set; }
        [Column("english_name")]
        [JsonPropertyName("english_name")]
        public string? EnglishName { get; set; }
        [Column("name")]
        [JsonPropertyName("name")]
        public string? Name { get; set; }

    }
}