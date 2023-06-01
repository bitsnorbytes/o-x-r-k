using System;
using System.Linq;
using Scullery.Data;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.local.json")
    .AddEnvironmentVariables()
    .Build();
var connectionString = config.GetValue<string>("Default:ConnectionString");
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddDbContext<CinemacatalogingContext>(options => options.UseNpgsql(connectionString));
    })
    .Build();
await host.RunAsync();