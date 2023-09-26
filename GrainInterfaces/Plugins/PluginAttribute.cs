namespace GrainInterfaces.Plugins;

public class PluginAttribute : Attribute
{
    public PluginAttribute(string pluginName)
    {
        PluginName = pluginName;
    }

    public string PluginName { get; }
}