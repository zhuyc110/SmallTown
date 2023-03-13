using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmallTown.Config;
using SmallTown.Function;
using SmallTown.Function.Framework.GameObject;
using SmallTown.Function.Framework.World;
using SmallTown.Function.Global;
using SmallTown.Function.Physics;
using SmallTown.Platform;
using SmallTown.Resource;
using System.IO.Abstractions;

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
    services.AddSingleton<IFileSystem, FileSystem>();
    services.AddSingleton(settings);
    services.AddSingleton<IGameObjectManager, GameObjectManager>();
    services.AddSingleton<ISmallTownOutput, DefaultSmallTownOutput>();
    services.AddSingleton<ILevelDirector, LevelDirector>();
    services.AddSingleton<IPhysicsScene, PhysicsScene>();
    services.AddSingleton<IAssetManager, AssetManager>();

    services.AddHostedService<GameTicker>();

    var serviceProvider = services.BuildServiceProvider();
    GameContext.Context =
        new GameContext
        {
            PhysicsScene = serviceProvider.GetRequiredService<IPhysicsScene>(),
            AssetManager = serviceProvider.GetRequiredService<IAssetManager>()
        };
});

using var host = hostBuilder.Build();

await host.RunAsync();