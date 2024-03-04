using System.Net;
using System.Net.Sockets;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;

namespace Olimpo;

public class Server : IServer
{
    private TcpListener _listener;

    public bool Running { get; set; }

    public Channels ConnectedChannels { get; private set; }

    public Subject<DataReceivedArgs> DataReceived { get; }

    public Server()
    {
        this.ConnectedChannels = new Channels(this);

        this.DataReceived = new Subject<DataReceivedArgs>();
    }

    public async Task Start(string address, int port)
    {
        await this.Start(IPAddress.Parse(address), port);
    }

    public async Task Start(IPAddress address, int port)
    {
        this._listener = new TcpListener(address, port);

        try
        {
            this._listener.Start();
            this.Running = true;

            while(this.Running)
            {
                var client = await this._listener.AcceptTcpClientAsync();
                ThreadPool.QueueUserWorkItem(this.CreateChannel, client);
            }
        }
        catch(SocketException)
        {
            throw;
        }
        catch(ChannelRegistrationException)
        {
            throw;
        }
    }

    public void Stop()
    {
        this._listener.Stop();
        this.Running = false;
    }

    private void CreateChannel(object obj)
    {
        new Channel(this).Open((TcpClient)obj);
    }
}