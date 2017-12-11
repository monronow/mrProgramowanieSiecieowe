using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace klient
{
    class Program
    {
        static void Main(string[] args)
        {
           // Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
          //  Socket internalSocket;
            byte[] recBuffer = new byte[256];

           // serverSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1024));
           // serverSocket.Listen(1);
            clientSocket.Connect("127.0.0.1", 1024);
            // internalSocket = serverSocket.Accept();

            clientSocket.Send(ASCIIEncoding.ASCII.GetBytes("Hello world!"));
            clientSocket.Receive(recBuffer);
            Console.WriteLine(ASCIIEncoding.ASCII.GetString(recBuffer));

            Console.Read();
        }
    }
}