namespace EventSource.EventBus
{
    /// <summary>
    /// Represent a Simple Message Broker
    /// </summary>
    public interface IMessageBroker
    {
        //
        IMessageReply AddMessage(IChannelInfo channelInfo, IMessage message);
    }
}