using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TCPServerAfgift
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener(IPAddress.Parse("127.0.0.1"), 6789);
            serverSocket.Start();

            while (true)
            {
                TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine("Server is Activated");
                ServerService service = new ServerService(connectionSocket);
                Task.Factory.StartNew(() => service.DoIt());
            }
        }
    }
}
