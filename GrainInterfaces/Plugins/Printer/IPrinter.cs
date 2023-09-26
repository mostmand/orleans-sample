using GrainInterfaces.Abstraction;

namespace GrainInterfaces.Plugins.Printer;

public interface IPrinter : IPlugin, IGrainWithIntegerKey
{
}