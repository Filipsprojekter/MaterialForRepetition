using System;
using System.IO;
using System.Net.Sockets;

namespace TCPClientAfgift
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient clientSocket = new TcpClient("localhost", 6789);
            Console.WriteLine("Client Starter");

            Stream ns = clientSocket.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            StreamReader sr = new StreamReader(ns);
            sw.AutoFlush = true;
            string message2 = sr.ReadLine();
            Console.WriteLine("Server : " + message2);
            while (true)
            {
               
                string message = Console.ReadLine();
                sw.WriteLine(message);

                message2 = sr.ReadLine();
                Console.WriteLine("Server : " + message2);
                
                message = Console.ReadLine();
                sw.WriteLine(message);

                message2 = sr.ReadLine();
                Console.WriteLine("Server : " + message2);
                message2 = sr.ReadLine();
                Console.WriteLine("Server : " + message2);
            }
        }
    }
}
