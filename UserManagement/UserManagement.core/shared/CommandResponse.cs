namespace UserManagement.core.shared;

public class CommandResponse
{
    public bool Success { get; set; }
    public int Code { get; set; }
    public string Message { get; set; }
    public IList<ErrorInfo> Errors { get; set; } = new List<ErrorInfo>();

    public static CommandResponse Successful(string message = "Success", int code = 200)
    {
        return new CommandResponse()
        {
            Success = true,
            Message = message ?? "Success",
            Code = code
        };
    }

    public static CommandResponse Failure(string message = "Request Failed", int code = 400)
    {
        return new CommandResponse()
        {
            Success = false,
            Message = message ?? "Failed",
            Code = code
        };
    }
}

public class CommandResponse<T> : CommandResponse
{
    public T Data { get; set; }

    public static CommandResponse<T> Successful(T data, string message = "Success", int code = 200)
    {
        return new CommandResponse<T>()
        {
            Success = true,
            Data = data, Message = message ?? "Success", Code = code
        };
    }
    public static CommandResponse<T?> Failed(string message = "Request Failed", int code = 400)
    {
        return new CommandResponse<T?>()
        {
            Data = default(T), Message = message ?? "Failed", Code = code
        };
    }
}

public class ErrorInfo
{
    public string Code { get; set; }
    public string Message { get; set; }
    public object Tag { get; set; }
}
