using System.Reflection;
using GrainInterfaces.Abstraction;
using GrainInterfaces.Plugins;
using Grains.Plugins.Creation.Abstraction;

namespace Grains.Plugins.Creation;

public class PluginFinder : IPluginFinder
{
    private readonly IReadOnlyDictionary<string, Type> PluginTypeByName = FindAllPlugins();

    private static IReadOnlyDictionary<string, Type> FindAllPlugins()
    {
        var types = typeof(IAssemblyMarker).Assembly
            .DefinedTypes
            .Where(type => IsSuitable(type))
            .Select(x =>
            {
                try
                {
                    return new
                    {
                        PluginType = GetGrainInterfaceType(x),
                        PluginName = x.GetCustomAttribute<PluginAttribute>()!.PluginName
                    };
                }
                catch (NullReferenceException)
                {
                    throw;
                }
            });
                
        return types.ToDictionary(x => x.PluginName, x => x.PluginType);
    }

    private static Type GetGrainInterfaceType(Type type)
    {
        return type.GetInterfaces()
            .First(x => x.Namespace?.StartsWith("GrainInterfaces.Plugins") ?? false);
    }

    private static bool IsSuitable(TypeInfo type)
    {
        return type is {IsAbstract: false, IsInterface: false}
               && typeof(IGrain).IsAssignableFrom(type)
               && typeof(IPlugin).IsAssignableFrom(type);
    }

    public Type FindPluginByName(string pluginName)
    {
        return PluginTypeByName[pluginName];
    }
}