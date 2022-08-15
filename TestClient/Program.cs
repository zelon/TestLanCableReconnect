using System.Net.Sockets;

void WriteLine(string msg)
{
    Console.WriteLine($"{System.DateTime.Now.ToString()}: {msg}");
}

string hostname = "localhost";
if (args.Length > 0)
{
    hostname = args[0];
}
int port = 8080;
WriteLine($"Connecting to {hostname}:{port}");
TcpClient tcpClient = new TcpClient(hostname, port);
WriteLine($"Connected");

byte[] buffer = new byte[1024];
int index = 0;
try
{
    while (true)
    {
        string content = $"{index}";
        WriteLine($"Sending {content}");
        buffer = System.Text.Encoding.UTF8.GetBytes(content);
        tcpClient.GetStream().Write(buffer, 0, buffer.Length);
        System.Threading.Thread.Sleep(1000);
        ++index;
    }
}
catch (SocketException socketException)
{
    WriteLine($"SocketException Occurred,exception:{socketException.Message}");
}

WriteLine("End of send");
