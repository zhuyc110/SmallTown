using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmallTown.Engine.Function;
using SmallTown.Game.Person;

namespace SmallTown.Game;

public static class Startup
{
    public static IHostBuilder RegisterGame(this IHostBuilder hostBuilder, IConfiguration config)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddSingleton<IInitializable, PersonalityManager>();
            services.AddSingleton<IInitializable, PropertyManager>();
        });

        return hostBuilder;
    }
}
