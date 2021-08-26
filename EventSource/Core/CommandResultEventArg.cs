using System;

namespace EventSource.Core
{
    public class CommandResultEventArg : EventArgs
    {
        public CommandResultEventArg(CommandResult result, CreatedDataInfo dataInfo)
        {
            Result = result;
            DataInfo = dataInfo;
        }

        public CommandResult Result { get; private set; }
        public CreatedDataInfo DataInfo { get; private set; }

        public class CreatedDataInfo
        {
            public string Id { get; internal set; }
            public object Data{ get; internal set; }
            public string DataType { get; internal set; }
        }
    }
}