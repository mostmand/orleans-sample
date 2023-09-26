using GrainInterfaces.Dtos;

namespace GrainInterfaces;

public interface IScenarioFlowManager : IGrainWithIntegerKey
{
    Task RunScenario(ScenarioDesignDto scenarioDesign);
}