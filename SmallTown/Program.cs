using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmallTown.Config;
using SmallTown.Extension;
using SmallTown.GameSystem;

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var settings = config.GetRequiredSection("World").Get<Settings>();

if (settings == null)
{
    throw new ArgumentNullException(nameof(settings));
}

var hostBuilder = Host.CreateDefaultBuilder(args);

hostBuilder.ConfigureServices(services =>
{
    // DI injections
    services.AddSingleton(settings);
    services.AddSingleton<IGameObjectManager, GameObjectManager>();
    services.AddSingleton<ISmallTownOutput, DefaultSmallTownOutput>();

    services.AddHostedService<World>();
});

using var host = hostBuilder.Build();

host.Run();