namespace GrainInterfaces.Dtos;

[GenerateSerializer]
public class PluginInfo
{
    [Id(0)]
    public string PluginName { get; }
    [Id(1)]
    public IPluginConfiguration PluginConfiguration { get; }

    public PluginInfo(string pluginName, IPluginConfiguration pluginConfiguration)
    {
        PluginName = pluginName;
        PluginConfiguration = pluginConfiguration;
    }
}