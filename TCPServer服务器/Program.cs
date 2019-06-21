using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace TCPServer服务器
{
    class Program
    {
        static void Main(string[] args)
        {

            /*同步
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //IPAddress ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0]; //10.135.57.30
            IPAddress ip = IPAddress.Parse("10.135.57.30");
            EndPoint point = new IPEndPoint(ip, 7788);
            serverSocket.Bind(point);
            serverSocket.Listen(0); // 0代表不限客户端连接数
            Console.WriteLine("服务器启动成功，开始监听...");
            while (true)
            {
                Socket clientSocket=serverSocket.Accept();
                Console.WriteLine("连接成功");
                string str = "请问需要什么服务？";
                clientSocket.Send(Encoding.UTF8.GetBytes(str));

                byte[] data = new byte[1024];
                int length = clientSocket.Receive(data);
                string strReceived = Encoding.UTF8.GetString(data, 0, length);
                Console.WriteLine("来自客户端："+strReceived);
                }              
                */

            //异步              
            Server server = new Server();
            string hostlocal = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
            Console.WriteLine($"本地IP地址为：{hostlocal}");
            server.Start(hostlocal, 7788);
            while (true)
            {
                string str = Console.ReadLine();
                switch (str)
                {
                    case "quit":
                    return;
                }
                    
            }

        }
    }
}
