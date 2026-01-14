namespace SanaShop.API.DTOs
{
    public record ErrorDetails(
        int StatusCode,
        string Message,
        string TraceIdentifier,
        string? InnerException = null,
        string? Source = null,
        string? StackTrace = null
    );
}
