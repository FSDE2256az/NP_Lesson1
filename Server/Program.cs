using System.Net;
using System.Net.Sockets;

namespace Server;



/*
 
Server qurmaq ucun lazim olanlar: 

1. Os => Operation System ( Emeliyyat sistemi )
2. Web Service => Apacke, Ngix, ( Linus, IOS ), IIS ( Windows ) 
3. Translator => C# ,Java, Php, C++
 
 
*/

public class Program
{
    static void Main(string[] args)
    {
        var listener = new Socket(
            AddressFamily.InterNetwork,
            SocketType.Stream,
            ProtocolType.Tcp
        );

        var clients = new List<Socket>();

        var ip = IPAddress.Parse("127.0.0.1");

        var port = 8005;

        // EndPoint => 127.0.0.1:8005

        var ep = new IPEndPoint(ip, port);

        listener.Bind(ep);
        
        var backlog = 1;

        listener.Listen(backlog);

        Console.WriteLine($"Listener listen on {listener.RemoteEndPoint}");




    }
}
