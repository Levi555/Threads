using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace TCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Socket tcpclient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress iPAddress = IPAddress.Parse("10.211.55.3");
            EndPoint endPoint = new IPEndPoint(iPAddress, 7788);
            tcpclient.Connect(endPoint);

            byte[] data = new byte[1024];
            int length = tcpclient.Receive(data);
            string stringRecived = Encoding.UTF8.GetString(data, 0, length);
            Console.WriteLine($"从服务器端接收到了消息：{stringRecived}");

            string message = Console.ReadLine();
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            tcpclient.Send(bytes);
            */
            //var ip = Dns.Resolve(Dns.GetHostName()).AddressList[0];
            var ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
            Console.WriteLine(ip);
            string localhost = Dns.GetHostName();
            Console.WriteLine($"主机名称：{localhost}");

            //IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            //TcpConnectionInformation[] connections=properties.GetActiveTcpConnections();
            //foreach (var item in connections)
            //{
            //    Console.WriteLine($"本机端口地址：{item.LocalEndPoint}");
            //    Console.WriteLine($"远程端口地址：{item.RemoteEndPoint}");
            //    Console.WriteLine($"状态：{item .State}");
            //}

            //获取编码格式
            foreach (var en in Encoding.GetEncodings())
            {
                Console.Write($"{en.GetEncoding().HeaderName}  ");
            }
            Console.ReadKey();
        }
    }
}
