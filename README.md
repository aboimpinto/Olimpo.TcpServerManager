# Abstract

TcpServerManager is part of the Olimpo developer suite that contains several tools that were created to help developers.

This object is responsible for accept multiple tcp connections.


# How to use?
From the interface *IServer* se the command __Start()__ providing the *IPAddress.Any* if want to accept connection from any IPAddress and the listening port.

*Subscribe* for the *Subject<DataReceivedArgs> DataReceiced* to receive every message in text format. 