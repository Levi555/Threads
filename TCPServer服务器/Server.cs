using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPServer服务器
{
    public class Server
    {
        public Socket _socket;
        //连接池
        public Conn[] conns;
        private int maxConn = 50;
        // 顺序获取连接池中首个没有已接收客户端的位置
        // 返回-1 ：代表conns存在而且每个成员在使用中，即连接池已满
        public int NewIndex()
        {
            if (conns == null) return -1;
            for (int i = 0; i < maxConn; i++)
            {
                if(conns[i] == null)
                {
                    conns[i] = new Conn();
                    return i;
                }
                else if(!conns[i].isUse)
                {
                    return i;
                }
            }
            return -1;
        }
        public Server()
        {

        }

        //开启服务器的方法
        public void Start(string host,int port) 
        {
            //创建连接池以及成员
            conns = new Conn[maxConn];
            for (int i = 0; i < maxConn; i++)
            {
                conns[i] = new Conn();
            }

            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //bind
            IPAddress ipaddress = IPAddress.Parse(host);
            EndPoint endPoint = new IPEndPoint(ipaddress, port);
            //开始监听
            _socket.Bind(endPoint);
            _socket.Listen(maxConn); //  监听的最大限制数

            //异步方式接收连接
            _socket.BeginAccept(AcceptCb, null);
            Console.WriteLine("服务器启动成功");
        }

        public void AcceptCb(IAsyncResult ar)
        {
            try
            {
               Socket clientSocket  = _socket.EndAccept(ar);
                int index = this.NewIndex();
                if(index < 0)
                {
                    clientSocket.Close();
                    Console.WriteLine("服务器连接已满");
                }
                else
                {
                    Conn conn = conns[index];
                    conn.Init(clientSocket);
                    string adr = conn.GetAddress();
                    Console.WriteLine("有客户端连接："+adr+" ,位于连接池中的ID :"+index);
                    conn._socket.BeginReceive(conn.readBuff, conn.bufCount, conn.BuffRemain(), SocketFlags.None, ReceiveCb, conn);
                    _socket.BeginAccept(AcceptCb, null); //再次调用循环
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ReceiveCb(IAsyncResult ar)
         {
             Conn conn=(Conn)ar.AsyncState;
            try
            {
                int length = conn._socket.EndReceive(ar);
                if (length <= 0)
                {
                    //Console.WriteLine(conn.GetAddress()+"与服务器断开连接");
                    conn.Close();
                    return;
                }
                string message = Encoding.UTF8.GetString(conn.readBuff, 0, length);
                Console.WriteLine($"收到{conn.GetAddress()}发来的数据: {message}");
                string meg = conn.GetAddress() + "发来消息 :" + message;
                byte[] bytes = Encoding.UTF8.GetBytes(meg);

                //广播消息
                for (int i = 0; i < conns.Length; i++)
                {
                    if (conns[i] == null) continue;
                    if (conns[i].isUse == false) continue;
                    conns[i]._socket.Send(bytes);
                    Console.WriteLine("服务器已分发数据至各正常连接的客户端");

                }
                // 继续接收数据
                conn._socket.BeginReceive(conn.readBuff, conn.bufCount, conn.BuffRemain(), SocketFlags.None, ReceiveCb, conn);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"收到{conn.GetAddress()}断开连接：{ex.Message}");
            }
        }
    }
}
