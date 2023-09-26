using GrainInterfaces.Abstraction;
using GrainInterfaces.Dtos;
using GrainInterfaces.Plugins;
using GrainInterfaces.Plugins.Filter;

namespace Grains.Plugins;

[Plugin("Filter")]
public sealed class FilterPlugin : IFilter, IPlugin<FilterConfiguration>
{
    public ValueTask<List<PluginData>> Process(List<PluginData> pluginInputs, FilterConfiguration pluginConfiguration)
    {
        if (pluginInputs.Count != 1)
        {
            throw new Exception("Invalid input");
        }

        var pluginData = pluginInputs.First();
        return ValueTask.FromResult(new List<PluginData>
        {
            new(Filter(pluginData.Data, pluginConfiguration) ? "filter matched" : "filter didn't match")
        });
    }

    private static bool Filter(string arg, FilterConfiguration filterConfiguration)
    {
        switch (filterConfiguration.Operator)
        {
            case FilterOperator.Equals:
                return arg.Equals(filterConfiguration.RightHandSide, StringComparison.InvariantCulture);
            case FilterOperator.Contains:
                return arg.Contains(filterConfiguration.RightHandSide);
            default:
                throw new NotSupportedException();
        }
    }
}