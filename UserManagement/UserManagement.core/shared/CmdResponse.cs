namespace UserManagement.core.shared;

public class CmdResponse
{
    public bool Success { get; set; }
    public int Code { get; set; }
    public string Message { get; set; }
    public IList<ErrInfo> Errors { get; set; } = new List<ErrInfo>();

    public static CmdResponse Successful(string message = "Success", int code = 200)
    {
        return new CmdResponse()
        {
            Success = true,
            Message = message ?? "Success",
            Code = code
        };
    }

    public static CmdResponse Failure(string message = "Request Failed", int code = 400)
    {
        return new CmdResponse()
        {
            Success = false,
            Message = message ?? "Failed",
            Code = code
        };
    }
}
