using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Olimpo;

public static class TcpServerHostBuilder
{
    public static IHostBuilder RegisterTcpServer(this IHostBuilder builder)
        {
            builder.ConfigureServices((hostContext, services) => 
            {
                services.AddSingleton<IServer, Server>();
            });

            return builder;
        }   
}