namespace BugStore.Responses;

public abstract class Response
{
    protected Response(object? data, bool success, string message)
    {
        Data = data;
        Success = success;
        Message = message;
    }

    public object? Data { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
}
