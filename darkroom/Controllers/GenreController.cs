using Microsoft.AspNetCore.Mvc;
using darkRoom.Models;
using darkRoom.Services;
namespace darkRoom.Controllers;


[ApiController]
[Route("[controller]")]
public class GenreController : ControllerBase
{
    private readonly GenreService _genreService;

    public GenreController(GenreService genreService) =>
        _genreService = genreService;
    // private static readonly string[] Summaries = new[]
    // {
    //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    // };

    // private readonly ILogger<WeatherForecastController> _logger;

    // public WeatherForecastController(ILogger<WeatherForecastController> logger)
    // {
    //     _logger = logger;
    // }

    [HttpGet(Name = "GetGenre")]
    public async Task<List<Genre>> Get() =>
        await _genreService.GetAsync();
}
