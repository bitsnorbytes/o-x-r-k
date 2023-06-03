using System;
using System.Linq;
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
var connectionString = configurationRoot.GetValue<string>("Default:ConnectionString");
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddDbContext<CinemaCatalogingContext>(options => options.UseNpgsql(connectionString));
        services.AddSingleton<IConfiguration>(configurationRoot);
        services.AddSingleton<SculleryX>();
    })
    .Build();
var SculleryService = host.Services.GetService<SculleryX>();
var path = "/4/movie/788929";
var prodlistpath = "/4/list/8253714";
SculleryService.FetchProdListTMDB(prodlistpath);
await host.RunAsync();