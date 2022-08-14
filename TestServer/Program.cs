using System.Net.Sockets;

void WriteLine(string msg) => Console.WriteLine(msg);

int port = 8080;
TcpListener listener = new TcpListener(System.Net.IPAddress.Any, port);
WriteLine($"Start port:{port}");
listener.Start();
WriteLine($"Started");

var socket = listener.AcceptSocket();
WriteLine("Socket accepted");
byte[] buffer = new byte[1024];
var receivedBytes = socket.Receive(buffer);
try
{
    while (receivedBytes > 0)
    {
        string content = System.Text.Encoding.UTF8.GetString(buffer, 0, receivedBytes);
        Console.WriteLine($"receivedBytes:{receivedBytes},content:{content}");
        receivedBytes = socket.Receive(buffer);
    }
}
catch (System.Net.Sockets.SocketException socketException)
{
    WriteLine($"SocketException Occurred,exception:{socketException.Message}");
}
WriteLine("End of program");
