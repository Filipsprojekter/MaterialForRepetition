using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpReciever
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient UDPServer = new UdpClient(7001);
            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 7001);

            while (true)
            {
                Byte[] recieveBytes = UDPServer.Receive(ref remoteIpEndPoint);
                string recievedData = Encoding.ASCII.GetString(recieveBytes);
                string[] data = recievedData.Split("\n");
                
                foreach (var s in data)
                {
                    Console.WriteLine(s);
                }




            }
        }
    }
}
