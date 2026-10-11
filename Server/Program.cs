using System.Net;
using System.Net.Sockets;
using System.Text;

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


        while (true)
        {
            var client = listener.Accept();

            clients.Add(client);

            Console.WriteLine($"{listener.RemoteEndPoint} connected ....");

            Task.Run(() =>
            {
                var buffer  = new byte[1024];
                var len = 0;
                var msj = string.Empty;

                while (true)
                {
                    len = client.Receive(buffer);
                    
                    msj = Encoding.Default.GetString(buffer, 0, len);

                    Console.WriteLine($"{listener.RemoteEndPoint} msj: {msj}");

                    if(msj =="ayqa")
                    {
                        client.Shutdown(SocketShutdown.Both);
                    }

                    foreach (var c in clients)
                    {
                        if (c != client)
                            c.Send(Encoding.Default.GetBytes(msj));
                    }

                }

            });



        }


    }
}
