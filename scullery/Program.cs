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
async Task seedDatabaseAsSync()
{
    await AddGenreAsSync();
    await AddLanguageAsSync();
    await AddMoviesAsSync();
}
async Task AddGenreAsSync()
{
    var GenreList = await SculleryService.FetchGenreList();
    foreach (var _genre in GenreList.Genres)
    {
        await SculleryService.AddGenreAsSync(_genre);
    }
    await SculleryService.SaveChangesAsSync();
}
async Task AddLanguageAsSync()
{
    var TMDBLanguageConfiguration = await SculleryService.FetchLanguageConfigurationTMDB();
    foreach (var _language in TMDBLanguageConfiguration)
    {
        await SculleryService.AddLanguageAsSync(_language);
    }
    await SculleryService.SaveChangesAsSync();
}
async Task AddMoviesAsSync()
{
    var MovieIdList = await SculleryService.FetchProdListTMDB();
    var TMDBImageConfiguration = await SculleryService.FetchImageConfigurationTMDB();
    foreach (var Movie in MovieIdList.Items)
    {
        var MovieDetails = await SculleryService.FetchMovieDetailsTMDB(Movie.Id);
        await SculleryService.AddMovieAsSync(MovieDetails, Movie.GenreIds, Movie.MediaType, TMDBImageConfiguration.Images.BackdropSizes, TMDBImageConfiguration.Images.PosterSizes,TMDBImageConfiguration.Images.SecureBaseImageURL);
    }
    await SculleryService.SaveChangesAsSync();
}
if(args.Length == 0) {
    await AddMoviesAsSync();
} else {
    switch(args[0]) {
        case "SeedDb": 
        await seedDatabaseAsSync();
        break;
        case "SeedGenre": 
        await AddGenreAsSync();
        break;
        case "SeedLanguage":
        await AddLanguageAsSync();
        break;
        case "SeedMovie":
        await AddMoviesAsSync();
        break;
        default :
        Console.WriteLine("Cannot Recognize Argument. Use 'SeedDb' to seed entire Database");
        break;
    }
}

