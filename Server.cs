using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ConsoleServer
{
    class Server
    {
        static byte[] Buffer { get; set; }
        static Socket sk;

        static void Main(string[] args)
        {
            sk = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sk.Bind(new IPEndPoint(0,1234));
            sk.Listen(100);

            Socket ac = sk.Accept();
            Buffer = new byte[ac.SendBufferSize];
            int br = ac.Receive(Buffer);
            byte[] fr = new byte[br];
            for(int i=0;i<br;i++)
            {
                fr[i] = Buffer[i];
            }
            string sd = Encoding.ASCII.GetString(fr);
            Console.Write(sd + "\n");
            Console.Read();
            sk.Close();
            ac.Close();
        }
    }
}
