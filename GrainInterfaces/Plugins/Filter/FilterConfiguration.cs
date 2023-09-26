using GrainInterfaces.Dtos;

namespace GrainInterfaces.Plugins.Filter;

[GenerateSerializer]
public class FilterConfiguration : IPluginConfiguration
{
    [Id(0)]
    public FilterOperator Operator { get; }
    [Id(1)]
    public string RightHandSide { get; }

    public FilterConfiguration(FilterOperator @operator, string rightHandSide)
    {
        Operator = @operator;
        RightHandSide = rightHandSide;
    }
}