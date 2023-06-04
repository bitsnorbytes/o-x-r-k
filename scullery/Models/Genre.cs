using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace Scullery.Models
{
    public class Genre
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [Column("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }
        public CinemaCatalogue Movies { get; set; }

    }
}