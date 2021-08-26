using System.Collections.Generic;

namespace EventSource.EventBus.core
{
    public class MessageReply : IMessageReply
    {
        internal MessageReply(IChannelInfo channelInfo, bool success, IReadOnlyList<string> errors): this(channelInfo,success)
        {
            Errors = errors;
        }

        internal MessageReply(IChannelInfo channelInfo, bool success)
        {
            ChannelInfo = channelInfo;
            Success = success;
            Errors = new List<string>();
        }

        public static IMessageReply SuccessReply(IChannelInfo channelInfo) => new MessageReply(channelInfo, true);

        public IChannelInfo ChannelInfo { get; }
        public bool Success { get; }
        public IReadOnlyList<string> Errors { get; }

        public static IMessageReply FailureReply(IChannelInfo channelInfo, IReadOnlyList<string> errors)=> new MessageReply(channelInfo, false, errors);
        
    }
}