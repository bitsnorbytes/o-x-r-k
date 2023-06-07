using Scullery.Services;
using Scullery.Models;
using Npgsql;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


IConfiguration configurationRoot = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddUserSecrets<Program>()
    .Build();
var conStrBuilder = new NpgsqlConnectionStringBuilder();
conStrBuilder.Password = configurationRoot.GetValue<string>("Database:Password");
conStrBuilder.Host = configurationRoot.GetValue<string>("Database:Server");
conStrBuilder.Username = configurationRoot.GetValue<string>("Database:User");
conStrBuilder.Database = configurationRoot.GetValue<string>("Database:Name");
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddDbContext<CinemaCatalogingContext>(options => options.UseNpgsql(conStrBuilder.ConnectionString));
        services.AddSingleton<IConfiguration>(configurationRoot);
        services.AddScoped<SculleryX>();
    })
    .Build();
var SculleryService = host.Services.GetService<SculleryX>();
var GenreList = await SculleryService.FetchGenreList("/3/genre/movie/list");
var MovieIdList = await SculleryService.FetchProdListTMDB("/3/list/8253714");
foreach (var Genre in GenreList.Genres)
{
    await SculleryService.SeedGenre(Genre);
}

foreach (var Movie in MovieIdList.Items)
{
    var MovieDetails = await SculleryService.FetchMovieDetailsTMDB("/3/movie/" + Movie.Id);
    await SculleryService.SeedMovie(MovieDetails, Movie.GenreIds, Movie.MediaType);
}
await host.RunAsync();
