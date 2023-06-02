using System;
using System.Linq;
using Scullery.Services;
using Scullery.Models;
using Npgsql;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddUserSecrets<Program>()
    .Build();

var conStrBuilder = new NpgsqlConnectionStringBuilder();
conStrBuilder.Password = config.GetValue<string>("Database:Password");
conStrBuilder.Host = config.GetValue<string>("Database:Server");
conStrBuilder.Username = config.GetValue<string>("Database:User");
conStrBuilder.Database = config.GetValue<string>("Database:Name");
var connectionString = config.GetValue<string>("Default:ConnectionString");
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddDbContext<CinemaCatalogingContext>(options => options.UseNpgsql(connectionString));
        services.AddSingleton<SculleryX>();
    })
    .Build();
var SculleryService = host.Services.GetService<SculleryX>();
var path = "/3/movie/788929?language=en-US";
SculleryService.FetchMovieDetailsTMDB(path);
await host.RunAsync();