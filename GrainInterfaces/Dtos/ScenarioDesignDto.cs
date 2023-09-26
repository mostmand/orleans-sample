namespace GrainInterfaces.Dtos;

[GenerateSerializer]
public class ScenarioDesignDto
{
    public ScenarioDesignDto(List<PluginInfo> plugins)
    {
        Plugins = plugins;
    }

    [Id(0)]
    public List<PluginInfo> Plugins { get; }
}