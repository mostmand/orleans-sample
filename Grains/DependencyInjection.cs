using Grains.Plugins.Creation;
using Grains.Plugins.Creation.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace Grains;

public static class DependencyInjection
{
    public static IServiceCollection AddGrainsServices(this IServiceCollection services)
    {
        services.AddSingleton<IPluginFinder, PluginFinder>();
        
        return services;
    }
}