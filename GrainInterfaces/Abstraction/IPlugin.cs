using GrainInterfaces.Dtos;
using GrainInterfaces.Exceptions;

namespace GrainInterfaces.Abstraction;

public interface IPlugin
{
    ValueTask<List<PluginData>> Process(List<PluginData> pluginInputs, IPluginConfiguration pluginConfiguration);
}

public interface IPlugin<in TPluginConfiguration> : IPlugin where TPluginConfiguration : IPluginConfiguration
{
    ValueTask<List<PluginData>> Process(List<PluginData> pluginInputs, TPluginConfiguration pluginConfiguration);
    
    ValueTask<List<PluginData>> IPlugin.Process(List<PluginData> pluginInputs, IPluginConfiguration pluginConfiguration)
    {
        if (pluginConfiguration is not TPluginConfiguration childPluginConfiguration)
        {
            throw new PluginConfigurationMismatchException();
        }

        return Process(pluginInputs, childPluginConfiguration);
    }
}