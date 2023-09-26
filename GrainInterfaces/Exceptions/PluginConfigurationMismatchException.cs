using System.Runtime.Serialization;

namespace GrainInterfaces.Exceptions;

[Serializable]
public class PluginConfigurationMismatchException : Exception
{
    public PluginConfigurationMismatchException()
    {
    }

    protected PluginConfigurationMismatchException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public PluginConfigurationMismatchException(string? message) : base(message)
    {
    }

    public PluginConfigurationMismatchException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}