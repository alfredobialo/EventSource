using System.Collections.Generic;

namespace EventSource
{
    public class CommandResult
    {
        public  bool Success { get;  set; }
        public string Message { get; set; }
        public IList<string> Errors { get;  set; } = new List<string>();
        public bool HasErrors => Errors.Count > 0;

        public static CommandResult Successful()
        {
            return new CommandResult()
            {
                Success = true,
                Message = "Command Executed Successfully",
            };
        }
    }
}