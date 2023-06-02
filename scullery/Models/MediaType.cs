using System.ComponentModel.DataAnnotations.Schema;
namespace Scullery.Models
{

    public class MediaType
    {
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("genre_id")]
        public int MediaTypeId { get; set; }
        public CinemaCatalogue Movies { get; set; }
    }
}