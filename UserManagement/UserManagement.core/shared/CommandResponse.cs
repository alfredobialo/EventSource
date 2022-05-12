namespace UserManagement.core.shared;

public class CommandResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public IList<ErrorInfo> Errors { get; set; } = new List<ErrorInfo>();

    public static CommandResponse Successful(string message = "Success", int code = 200)
    {
        return new CommandResponse()
        {
            Success = true,
            Message = message ?? "Success"
        };
    }public static CommandResponse Failure(string message = "Request Failed", int code = 400)
    {
        return new CommandResponse()
        {
            Success = false,
            Message = message ?? "Failed"
        };
    }
}

public class ErrorInfo
{
    public string Code { get; set; }
    public string Message { get; set; }
    public object Tag { get; set; }
}
