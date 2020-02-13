using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using Skat;


namespace TCPServerAfgift
{
    class ServerService
    {
        private TcpClient connectionSocket;

        public ServerService(TcpClient connectionSocket)
        {
            this.connectionSocket = connectionSocket;
        }

        internal void DoIt()
        {
            Stream ns = connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;
            string firstMessage = "Indtast biltype - Elbil eller Personbil";
            string secondMessage = "Indtast Værdi";
            sw.WriteLine(firstMessage);
            string message = sr.ReadLine();
            string answer;

            while (!String.IsNullOrEmpty(message))
            {
                string parameter1 = message;
                sw.WriteLine(secondMessage);
                message = sr.ReadLine();
                double parameter = Convert.ToDouble(message);

                if (parameter1 == "elbil" || parameter1 == "Elbil")
                {
                    answer = Skat.Afgift.ElBilAfgift(parameter, parameter1).ToString(CultureInfo.CurrentCulture);
                    sw.WriteLine(answer);
                }
                else
                {
                    answer = Skat.Afgift.BilAfgift(parameter, parameter1).ToString(CultureInfo.CurrentCulture);
                    sw.WriteLine(answer);
                }

                sw.WriteLine(firstMessage);
                message = sr.ReadLine();
            }
        }
    }
}
