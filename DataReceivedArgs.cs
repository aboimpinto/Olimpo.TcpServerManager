namespace Olimpo;

public class DataReceivedArgs : IDisposable
{
    public string ChannelId { get; } = string.Empty;

    public string Message { get; } = string.Empty;

    public Channel Channel { get; }

    public DataReceivedArgs(string channelId, string message, Channel channel)
    {
        this.ChannelId = channelId;
        this.Message = message;
        this.Channel = channel;
    }

    public void Dispose()
    {
        this.Channel.Dispose();
    }
}