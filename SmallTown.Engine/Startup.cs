using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmallTown.Config;
using SmallTown.Engine.Resource;
using SmallTown.Function.Framework.GameObject;
using SmallTown.Function.Framework.World;
using SmallTown.Function.Global;
using SmallTown.Function.Physics;
using SmallTown.Function;
using SmallTown.Platform;
using SmallTown.Resource;
using System.IO.Abstractions;
using Microsoft.Extensions.Configuration;

namespace SmallTown.Engine
{
    public static class Startup
    {
        public static IHostBuilder RegisterEngine(this IHostBuilder hostBuilder, IConfiguration config)
        {
            hostBuilder.ConfigureServices(services =>
            {
                // DI injections
                services.AddSingleton<IFileSystem, FileSystem>();
                services.AddSingleton<IGameObjectManager, GameObjectManager>();
                services.AddSingleton<ISmallTownOutput, DefaultSmallTownOutput>();
                services.AddSingleton<ILevelDirector, LevelDirector>();
                services.AddSingleton<IPhysicsScene, PhysicsScene>();
                services.AddSingleton<IAssetManager, AssetManager>();
                services.AddSingleton<ILanguageService, LanguageService>();

                services.AddHostedService<GameTicker>();

                services.Configure<Settings>(config);

                var serviceProvider = services.BuildServiceProvider();
                GameContext.Context =
                    new GameContext
                    {
                        PhysicsScene = serviceProvider.GetRequiredService<IPhysicsScene>(),
                        AssetManager = serviceProvider.GetRequiredService<IAssetManager>()
                    };
            });

            return hostBuilder;
        }
    }
}
