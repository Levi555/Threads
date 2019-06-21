using System;
using System.Net.Sockets;
namespace TCPServer服务器
{
    //用作在服务器端表示一个通过Accept（）连接的客户端对象类型
    //连接池中的成员类型
    public class Conn
    {
        public Socket _socket;
        //连接池中的一个成员是否已经用来接收 远程客户端
        //isUse为true：当前接收有连接的客户端； 为false：当前没有接收客户端
        public bool isUse;
        public int bufCount;

        //接收数据缓冲区大小
        public const int buff_size = 1024;
        public byte[] readBuff;
        public Conn()
        {
            readBuff = new byte[buff_size];
        }

        //初始化
        public void Init(Socket socket)
        {
            _socket = socket;
            isUse = true;
            bufCount = 0;
        }
        //缓冲剩余的字节数
        public int BuffRemain()
        {
            return buff_size - bufCount;
        }

        //获取客户端的IP地址和端口号
        public string GetAddress()
        {
            if (!isUse) return "无法获取地址";
            return _socket.RemoteEndPoint.ToString();
            //return _socket.LocalEndPoint.ToString();
        }

        public void Close()
        {
            if (!isUse) return;
            Console.WriteLine(GetAddress()+"与服务器断开连接 ");
            if(_socket!=null && _socket.Connected)
            {
                _socket.Shutdown(SocketShutdown.Both);
                System.Threading.Thread.Sleep(10);
                _socket.Close();
                isUse = false;
            }
            else
            {
                Console.WriteLine("关闭socket失败！");
            }
        }
    }
}
