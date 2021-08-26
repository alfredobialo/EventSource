using System.Collections.Generic;
using EventSource.EventBus.core;

namespace EventSource.EventBus
{
    public class MessageBroker : IMessageBroker
    {
        private Dictionary<string, IList<IMessage>> _messages = new Dictionary<string, IList<IMessage>>();

        public MessageBroker()
        {
        }

        public IMessageReply AddMessage(IChannelInfo channelInfo, IMessage message)
        {
            // simple Implementation
            if (_messages.ContainsKey(channelInfo.Key))
            {
                var list = _messages[channelInfo.Key] ?? new List<IMessage>();
                list.Add(message);
                return MessageReply.SuccessReply(channelInfo);
            }
            // add new ChannelInfo with Message
            bool added = _addNewChannelInfo(channelInfo, message);

            return MessageReply.FailureReply(channelInfo, new List<string>() {"Error Story data"});
        }

        private bool _addNewChannelInfo(IChannelInfo channelInfo, IMessage message)
        {
            throw new System.NotImplementedException();
        }
    }
}