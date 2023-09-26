using GrainInterfaces;
using GrainInterfaces.Abstraction;
using GrainInterfaces.Dtos;
using GrainInterfaces.Plugins;
using Grains.Plugins.Creation.Abstraction;
using Microsoft.Extensions.Logging;

namespace Grains;

public sealed class ScenarioFlowManagerGrain : IScenarioFlowManager
{
    private readonly IGrainFactory _grainFactory;
    private readonly IPluginFinder _pluginFinder;
    private readonly ILogger<ScenarioFlowManagerGrain> _logger;

    public ScenarioFlowManagerGrain(IGrainFactory grainFactory, IPluginFinder pluginFinder, ILogger<ScenarioFlowManagerGrain> logger)
    {
        _grainFactory = grainFactory ?? throw new ArgumentNullException(nameof(grainFactory));
        _pluginFinder = pluginFinder ?? throw new ArgumentNullException(nameof(pluginFinder));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task RunScenario(ScenarioDesignDto scenarioDesign)
    {
        var inputData = new List<PluginData>();
        foreach (var pluginInfo in scenarioDesign.Plugins)
        {
            var pluginType = _pluginFinder.FindPluginByName(pluginInfo.PluginName);
            var pluginGrain = _grainFactory.GetGrain(pluginType, 0);
            
            _logger.LogInformation("Running plugin {PluginName}", pluginInfo.PluginName);
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (pluginGrain is not IPlugin plugin)
            {
                throw new Exception("Invalid plugin");
            }

            inputData = await plugin.Process(inputData, pluginInfo.PluginConfiguration);
        }
    }
}