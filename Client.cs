using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;
using System.Text;

namespace ConsoleClient
{
    class Client
    {
        static Socket sk;
        static void Main(string[] args)
        {
            sk = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint lep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            try
            {
                sk.Connect(lep);
            }
            catch
            {
                Console.Write("Somthing Wrong.........");
                Main(args);
            }
            Console.Write("Enter Text : ");
            string text = Console.ReadLine();
            byte[] data = Encoding.ASCII.GetBytes(text);
            sk.Send(data);
            Console.Write("Data Sent!\r\n");
            Console.Write("Press any key to Continue.....");
            Console.Read();
            sk.Close();
        }
    }
}
