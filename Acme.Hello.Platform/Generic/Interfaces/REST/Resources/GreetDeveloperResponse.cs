namespace Acme.Hello.Platform.Generic.Interfaces.REST.Resources;

public record GreetDeveloperResponse(Guid? Id, string? FullName, string Message)
{
    public GreetDeveloperResponse(string message)
        : this(null, null, message) { }
}