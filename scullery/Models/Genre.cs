using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
namespace Scullery.Models
{
   public class Genre
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string? Name { get; set; }

    }
}