using GrainInterfaces.Dtos;

namespace GrainInterfaces.Plugins.ManualInput;

[GenerateSerializer]
public class ManualInputConfiguration : IPluginConfiguration
{
    public ManualInputConfiguration(string inputData)
    {
        InputData = inputData;
    }

    [Id(0)]
    public string InputData { get; }
}