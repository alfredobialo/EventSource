namespace UserManagement.core.shared;

public class CmdResponse<T> : CmdResponse
{
    public T Data { get; set; }

    public static CmdResponse<T> Successful(T data, string message = "Success", int code = 200)
    {
        return new CmdResponse<T>()
        {
            Success = true,
            Data = data, Message = message ?? "Success", Code = code
        };
    }
    public static CmdResponse<T?> Failed(string message = "Request Failed", int code = 400)
    {
        return new CmdResponse<T?>()
        {
            Data = default(T), Message = message ?? "Failed", Code = code
        };
    }
}

public class ErrInfo
{
    public string Code { get; set; }
    public string Message { get; set; }
    public object Tag { get; set; }
}
