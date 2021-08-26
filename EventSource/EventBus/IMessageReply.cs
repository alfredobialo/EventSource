using System.Collections.Generic;

namespace EventSource.EventBus
{
    public interface IMessageReply
    { 
        IChannelInfo ChannelInfo { get; }
        public bool Success { get; }
        public IReadOnlyList<string> Errors { get; }
    }
}