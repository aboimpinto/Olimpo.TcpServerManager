using System.Net.Sockets;

namespace Olimpo;

public static class TcpClientExtensions
{
    public static bool IsClientDisconnected(this TcpClient client)
    {
        return client.Client.Available == 0 && client.Client.Poll(1, SelectMode.SelectRead);
    }
}