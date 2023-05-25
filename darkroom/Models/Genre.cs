using Postgrest.Attributes;
using Postgrest.Models;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace darkRoom.Models;


[Table("Genre")]
public class Genre : BaseModel
{
    [PrimaryKey("id",false)]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("genre_id")]
    public int GenreId { get; set; }
}