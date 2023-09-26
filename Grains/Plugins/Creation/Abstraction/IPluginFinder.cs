namespace Grains.Plugins.Creation.Abstraction;

public interface IPluginFinder
{
    Type FindPluginByName(string pluginName);
}