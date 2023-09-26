using GrainInterfaces.Abstraction;
using GrainInterfaces.Dtos;
using GrainInterfaces.Plugins;
using GrainInterfaces.Plugins.ManualInput;

namespace Grains.Plugins;

[Plugin("ManualInput")]
public sealed class ManualInputPlugin : IManualInput, IPlugin<ManualInputConfiguration>
{
    public ValueTask<List<PluginData>> Process(List<PluginData> pluginInputs, ManualInputConfiguration pluginConfiguration)
    {
        return ValueTask.FromResult(new List<PluginData>
        {
            new(pluginConfiguration.InputData)
        });
    }
}