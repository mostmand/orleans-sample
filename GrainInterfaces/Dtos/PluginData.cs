namespace GrainInterfaces.Dtos;

[GenerateSerializer]
public class PluginData
{
    public PluginData(string data)
    {
        Data = data;
    }

    [Id(0)]
    public string Data { get; }
}