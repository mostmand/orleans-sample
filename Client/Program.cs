using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using GrainInterfaces;
using GrainInterfaces.Dtos;
using GrainInterfaces.Plugins.Filter;
using GrainInterfaces.Plugins.ManualInput;
using GrainInterfaces.Plugins.Printer;

IHostBuilder builder = Host.CreateDefaultBuilder(args)
    .UseOrleansClient(client =>
    {
        client.UseLocalhostClustering();
    })
    .ConfigureLogging(logging => logging.AddConsole())
    .UseConsoleLifetime();

using IHost host = builder.Build();
await host.StartAsync();

IClusterClient client = host.Services.GetRequiredService<IClusterClient>();

var scenarioFlowManager = client.GetGrain<IScenarioFlowManager>(0);

var pluginsInfo = new List<PluginInfo>
{
    new("ManualInput", new ManualInputConfiguration("asghar")),
    new("Filter", new FilterConfiguration(FilterOperator.Contains, "asd")),
    new("Printer", new PrinterConfiguration())
};
var scenarioDesign = new ScenarioDesignDto(pluginsInfo);

await scenarioFlowManager.RunScenario(scenarioDesign);

Console.WriteLine("Press any key to exit...");

Console.ReadKey();

await host.StopAsync();