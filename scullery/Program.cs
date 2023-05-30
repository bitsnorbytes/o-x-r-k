using Microsoft.Extensions.Hosting;
using IHost host = Host.CreateDefaultBuilder(args).Build();
await host.RunAsync();
