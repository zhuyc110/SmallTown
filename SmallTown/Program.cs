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
    services.AddSingleton<ILevelDirector, LevelDirector>();
    services.AddSingleton<IPhysicsScene, PhysicsScene>();

    services.AddHostedService<GameTicker>();
    GameContext.Context =
        new GameContext { PhysicsScene = services.BuildServiceProvider().GetRequiredService<IPhysicsScene>() };
});

using var host = hostBuilder.Build();

host.Run();