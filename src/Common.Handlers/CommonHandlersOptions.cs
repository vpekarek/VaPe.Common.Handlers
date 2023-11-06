namespace VaPe.Common.Handlers;
public sealed class CommonHandlersOptions
{
    public bool UseEvents { get; set; } = true;
    public bool UseCommandQuery { get; set; } = true;
    public bool UseMessaging { get; set; } = true;
    public Type? EventDispatcher { get; set; }
}
