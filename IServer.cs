using System.Net;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace Olimpo;

public interface IServer
{
    bool Running {  get; set; }

    Channels ConnectedChannels { get; }

    Subject<DataReceivedArgs> DataReceived { get; }

    Task Start(string address, int port);

    Task Start(IPAddress address, int port);

    void Stop();
}