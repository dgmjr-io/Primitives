namespace Dgmjr.Primitives.Tests;
using static Microsoft.Extensions.Logging.LogLevel;

public static partial class LoggerExtensions
{
    [LoggerMessage(Information, "{PrimitiveType} original value: \"{OriginalValue}\"")]
    public static partial void LogOriginalValue(this ILogger logger, Type primitiveType, string originalValue);
}
