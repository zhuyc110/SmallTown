using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmallTown.Engine.Function;
using SmallTown.Function;
using SmallTown.Game.Config;
using SmallTown.Game.Entity;
using SmallTown.Game.Event;
using SmallTown.Game.Person;
using SmallTown.Game.Person.Name;

namespace SmallTown.Game;

public static class Startup
{
    public static IHostBuilder RegisterGame(this IHostBuilder hostBuilder, IConfiguration config)
    {
        var gameConfig = new ConfigurationBuilder().AddJsonFile("settings.json").Build();

        hostBuilder.ConfigureServices(services =>
        {
            services.AddSingleton<IPersonalityManager, PersonalityManager>()
                .AddSingleton<IInitializable, IPersonalityManager>(config => config.GetService<IPersonalityManager>()!);
            services.AddSingleton<IInitializable, PropertyManager>();
            services.AddSingleton<IInitializable, RelationshipManager>();
            services.AddSingleton<IRoleManager, RoleManager>()
                .AddSingleton<IInitializable, IRoleManager>(config => config.GetService<IRoleManager>()!);
            services.AddSingleton<IInitializable, EntityManager>();
            services.AddSingleton<IInitializable, EventManager>();
            services.AddSingleton<INameManager, NameManager>()
                .AddSingleton<IInitializable, INameManager>(config => config.GetService<INameManager>()!);
            services.AddSingleton<IInitializable, PersonGenerator>();

            services.Configure<GameSettings>(gameConfig);
        });

        return hostBuilder;
    }
}
