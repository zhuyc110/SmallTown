using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using SmallTown.Engine;
using SmallTown.Game;

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

if (config == null)
{
    throw new ArgumentNullException(nameof(config));
}

var hostBuilder = Host.CreateDefaultBuilder(args);

hostBuilder.RegisterEngine(config)
    .RegisterGame(config);

using var host = hostBuilder.Build();

await host.RunAsync();