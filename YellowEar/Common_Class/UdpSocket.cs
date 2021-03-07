using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace YellowEar
{
    public class UdpSocket
    {
        /// <summary>
        /// 用于udp通信的对象
        /// </summary>
        private UdpClient udp_socket = new UdpClient();
        /// <summary>
        /// 接收线程
        /// </summary>
        private Thread thd_for_Receive;
        /// <summary>
        /// udp 监听端口
        /// </summary>
        public IPEndPoint IpAndPort { get; set; }
        private bool _listenActive = false;
        /// <summary>
        /// 监听是否激活
        /// </summary>
        public bool ListenActive
        {
            get { return _listenActive; }
            set
            {
                _listenActive = value;
                if(_listenActive)
                {
                    StartListen();
                }
                else
                {
                    TerminateListen();
                }
            }
        }

        public delegate void DataArrivalEventHandler(byte[] data, IPAddress ip, int port);
        public event DataArrivalEventHandler DataArrival;

        public UdpSocket(DataArrivalEventHandler DataArrivalFunctioin,IPEndPoint iPEndPoint)
        {
            DataArrival += DataArrivalFunctioin;
            IpAndPort = iPEndPoint;
        }
        /// <summary>
        /// 开始监听
        /// </summary>
        private void StartListen()
        {
            if(udp_socket!=null)
            {
                udp_socket.Close();
            }
            udp_socket = new UdpClient(IpAndPort);
            udp_socket.Client.ReceiveBufferSize = 5 * 1024 * 1024;//设置upd接收缓冲区为5M，防止数据包太多，而程序处理速度不够导致数据包丢失

            try
            {
                thd_for_Receive = new Thread(new ThreadStart(ReceiveData));
                thd_for_Receive.Start();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        /// <summary>
        /// 准备接收udp数据
        /// </summary>
        private void ReceiveData()
        {
            IPEndPoint remotePoint = new IPEndPoint(IPAddress.Any, 0);
            while(ListenActive)
            {
                try
                {
                    byte[] data = udp_socket.Receive(ref remotePoint);
                    if(DataArrival!=null)
                    {
                        DataArrival(data, remotePoint.Address, remotePoint.Port);
                    }
                    Thread.Sleep(0);
                }
                catch { }//如果不捕获异常，当调用abort时会抛出异常
            }
        }
        /// <summary>
        /// 终止监听
        /// </summary>
        private void TerminateListen()
        {
            if(udp_socket!=null)
            {
                udp_socket.Close();
            }
            if(thd_for_Receive!=null)
            {
                Thread.Sleep(30);
                thd_for_Receive.Abort();
            }
        }
        /// <summary>
        /// 发送udp数据
        /// </summary>
        /// <param name="remoteIP">远程目标主机地址</param>
        /// <param name="remotePort">远程目标主机端口</param>
        /// <param name="data">要发送的数据</param>
        public void Send(IPAddress remoteIP,int remotePort,byte[] data)
        {
            try
            {
                udp_socket.Send(data, data.Length, new IPEndPoint(remoteIP, remotePort));
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
