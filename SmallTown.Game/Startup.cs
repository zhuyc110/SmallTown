using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmallTown.Game.Person;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTown.Game;

public static class Startup
{
    public static IHostBuilder RegisterGame(this IHostBuilder hostBuilder, IConfiguration config)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddSingleton<PersonalityManager>();
        });

        return hostBuilder;
    }
}
