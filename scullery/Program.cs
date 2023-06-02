using System;
using System.Linq;
using Scullery.Services;
using Scullery.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.local.json", false, true)
    .AddEnvironmentVariables()
    .Build();
var connectionString = config.GetValue<string>("Default:ConnectionString");
var baseURL = config.GetValue<string>("TMDB:baseURL");
var TMDBBearerToken = config.GetValue<string>("TMDB:BearerToken");
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddDbContext<CinemaCatalogingContext>(options => options.UseNpgsql(connectionString));
        services.AddSingleton<SculleryX>();
    })
    .Build();
var SculleryService = host.Services.GetService<SculleryX>();
var path = "";
SculleryService.FetchMovieDetailsTMDB(path);
await host.RunAsync();