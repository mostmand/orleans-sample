using GrainInterfaces.Abstraction;
using GrainInterfaces.Dtos;
using GrainInterfaces.Plugins;
using GrainInterfaces.Plugins.Printer;
using Microsoft.Extensions.Logging;

namespace Grains.Plugins;

[Plugin("Printer")]
public sealed class PrinterPlugin : IPrinter, IPlugin<PrinterConfiguration>
{
    private readonly ILogger<PrinterPlugin> _logger;

    public PrinterPlugin(ILogger<PrinterPlugin> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public ValueTask<List<PluginData>> Process(List<PluginData> pluginInputs, PrinterConfiguration pluginConfiguration)
    {
        if (pluginInputs.Count != 1)
        {
            throw new Exception("Invalid input");
        }

        var data = pluginInputs.First().Data;

        _logger.LogInformation("Data is {Data}", data);

        return ValueTask.FromResult(new List<PluginData>());
    }
}