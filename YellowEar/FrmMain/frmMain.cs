using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using DSkin.DirectUI;

namespace YellowEar
{
    public partial class frmMain : Form
    {
        #region 无边框窗口移动和屏幕边缘磁性吸附功能 数据定义
        /// <summary>
        /// 取得当前线程编号（线程钩子需要用到）
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        private static extern int GetCurrentThreadId();

        [DllImport("user32.dll")]
        private static extern bool PtInRect(ref Rectangle r, Point p);

        //钩子类
        private MouseHook mouse_hook;
        /// <summary>
        /// 实现窗体屏幕边缘磁性吸附功能时，表示鼠标是否按下
        /// </summary>
        public bool isPnlTopMouseDown=false;
        #endregion

        //private List<Friend_Info> FriendCollection;
        private List<FrmChat> frmchatlist_main;//存储聊天窗口的列表
        private UdpSocket udpsoket_main;
        private SqliteHelper Sqlite;//用于操作数据库，需要传送给子窗口
        public Self_Info myselfinfo;//用于存储自己的信息
        private bool isTwinkle = false;//表示是否闪动图标和头像
        private bool icoState = true;//表示当前使用的图标

        public frmMain()
        {
            InitializeComponent();
            DatabaseInitial("db.sqlite");


            frmchatlist_main = new List<FrmChat>();
            udpsoket_main = new UdpSocket(udpsocket_DataArrive, new IPEndPoint(myselfinfo.Ip,myselfinfo.Port));

            //初始化自己的信息及好友列表
            duiTextBoxSign.Text = myselfinfo.Sign;
            lblNickName.Text = myselfinfo.NickName;
            chatlistFriends.frmmain = this;
            chatlistFriends.Sqlite = Sqlite;
            chatlistGroups.frmmain = this;
            chatlistGroups.Sqlite = Sqlite;
            chatlistFriends.InitialList(myselfinfo);
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            mouse_hook = new MouseHook(this);
            mouse_hook.Start();
            lblIP.Text = myselfinfo.Ip.ToString();

            //开始监听，并广播上线消息
            udpsoket_main.ListenActive = true;
            BroadcastMessage(Serializer.SerializeBinary(new Friend_Info(myselfinfo)), MessageCommandWord.Online, ChatType.One);
        }

        #region 无边框窗口移动和屏幕边缘磁性吸附功能 函数实现
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            mouse_hook.Stop();
        }
        private void picClose_MouseEnter(object sender, EventArgs e)
        {
            picClose.Image = Properties.Resources.closeHoverImage;
        }

        private void picClose_MouseLeave(object sender, EventArgs e)
        {
            picClose.Image = Properties.Resources.closeImage;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void picMin_MouseEnter(object sender, EventArgs e)
        {
            picMin.Image = Properties.Resources.minHoverImage;
        }

        private void picMin_MouseLeave(object sender, EventArgs e)
        {
            picMin.Image = Properties.Resources.minImage;
        }

        private void picMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timerHidden_Tick(object sender, EventArgs e)
        {
            Point mouseLocation = new Point(Cursor.Position.X, Cursor.Position.Y);
            Rectangle rectForm = new Rectangle(this.Left, this.Top, this.Left + this.Width, this.Top + this.Height);

            if(!PtInRect(ref rectForm, mouseLocation))
            {
                if(-5 < this.Top && this.Top < 5)
                {
                    this.Top = 5 - this.Height;
                }
                else if(5-this.Width<this.Left&&this.Left<5)
                {
                    this.Left = 5 - this.Width;
                }
                else if(Screen.PrimaryScreen.Bounds.Width-5<this.Right&&this.Right<Screen.PrimaryScreen.Bounds.Width+this.Width-5)
                {
                    this.Left = Screen.PrimaryScreen.Bounds.Width - 5;
                }
            }
            else
            {
                if(this.Top<0&&!isPnlTopMouseDown)
                {
                    this.Top = 0;
                }
                else if(this.Left<0&&!isPnlTopMouseDown)
                {
                    this.Left = 0;
                }
                else if(this.Right>Screen.PrimaryScreen.Bounds.Width&& !isPnlTopMouseDown)
                {
                    this.Left = Screen.PrimaryScreen.Bounds.Width-this.Width;
                }
            }
        }
        #endregion

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            //由于使用的钩子方法的无边框窗体，内部控件无法响应sizechanged事件，需要手动调用
            chatlistFriends.ChatListBox_SizeChanged(chatlistFriends, e);
            chatlistGroups.ChatListBox_SizeChanged(chatlistGroups, e);
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(udpsoket_main.ListenActive)
            {
                udpsoket_main.ListenActive = false;
            }
        }
        /// <summary>
        /// 点对点发送消息
        /// </summary>
        /// <param name="receiver">接收方</param>
        /// <param name="msgType">消息类型</param>
        /// <param name="cmdword">消息命令字</param>
        /// <param name="chattype">聊天类型</param>
        /// <param name="data">数据</param>
        public void SendMessage(Friend_Info receiver,MessageType msgType,MessageCommandWord cmdword,ChatType chattype, byte[] data)
        {
            MessageEx msg = new MessageEx(msgType, cmdword, chattype);      
            if (data==null||data.Length <= 1024)
            {//数据量小，一次发送完毕
                msg.Data = data;
                msg.sendType = MessageSendType.Single;
                BinaryFormatter serializer = new BinaryFormatter();
                using(MemoryStream memstream = new MemoryStream())
                {
                    serializer.Serialize(memstream, msg);
                    udpsoket_main.Send(receiver.Ip, receiver.Port, memstream.ToArray());
                }                
            }
            else
            {//数据量大，多次发送
                BinaryFormatter serializer = new BinaryFormatter();
                using(MemoryStream datastream=new MemoryStream(data))
                {
                    using(MemoryStream memstream = new MemoryStream())
                    {
                        msg.sendType = MessageSendType.Start;
                        msg.Data = Encoding.UTF8.GetBytes("");
                        serializer.Serialize(memstream, msg);
                        udpsoket_main.Send(receiver.Ip, receiver.Port, memstream.ToArray());
                    }

                    msg.sendType = MessageSendType.Sending;
                    int send_block_len = 1024;
                    long remain_len = datastream.Length;
                    while (remain_len > 0)
                    {
                        if (remain_len < send_block_len)
                        {
                            send_block_len = Convert.ToInt32(remain_len);
                        }
                        byte[] send_block_data = new byte[send_block_len];
                        datastream.Read(send_block_data,0, send_block_len);
                        remain_len -= send_block_len;
                        msg.Data = send_block_data;
                        using(MemoryStream memstream = new MemoryStream())
                        {
                            serializer.Serialize(memstream, msg);
                            udpsoket_main.Send(receiver.Ip, receiver.Port, memstream.ToArray());
                        }                        
                    }

                    using (MemoryStream memstream = new MemoryStream())
                    {
                        msg.sendType = MessageSendType.End;
                        msg.Data = Encoding.UTF8.GetBytes("");
                        serializer.Serialize(memstream, msg);
                        udpsoket_main.Send(receiver.Ip, receiver.Port, memstream.ToArray());
                    }
                }
            }
        }
        /// <summary>
        /// 广播消息
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="cmdword">消息命令字</param>
        /// <param name="chattype">聊天类型</param>
        /// <param name="msgType">消息类型，广播时这个字段均为command</param>
        public void BroadcastMessage(byte[] data, MessageCommandWord cmdword, ChatType chattype, MessageType msgType=MessageType.Command)
        {
            MessageEx msg = new MessageEx(msgType,cmdword,chattype);
            //获取广播地址
            byte[] mask = null;
            foreach (UnicastIPAddressInformation ipinfo in myselfinfo.currentIPs)
            {
                if (ipinfo.Address.ToString() == myselfinfo.Ip.ToString())
                {
                    mask = ipinfo.IPv4Mask.GetAddressBytes();
                    break;
                }
            }
            byte[] ip = myselfinfo.Ip.GetAddressBytes();
            for (int i = 0; i < ip.Length; i++)
            {
                ip[i] = (byte)(ip[i] | (~mask[i]));
            }
            IPAddress broadcastIP = new IPAddress(ip);

            if (data==null||data.Length <= 1024)
            {//数据量小，一次发送完毕
                msg.Data = data;
                msg.sendType = MessageSendType.Single;
                BinaryFormatter serializer = new BinaryFormatter();
                using (MemoryStream memstream = new MemoryStream())
                {
                    serializer.Serialize(memstream, msg);
                    udpsoket_main.Send(broadcastIP, myselfinfo.Port, memstream.ToArray());
                }
            }
            else
            {//数据量大，多次发送
                BinaryFormatter serializer = new BinaryFormatter();
                using (MemoryStream datastream = new MemoryStream(data))
                {
                    using (MemoryStream memstream = new MemoryStream())
                    {
                        msg.sendType = MessageSendType.Start;
                        msg.Data = Encoding.UTF8.GetBytes("");
                        serializer.Serialize(memstream, msg);
                        udpsoket_main.Send(broadcastIP, myselfinfo.Port, memstream.ToArray());
                    }

                    msg.sendType = MessageSendType.Sending;
                    int send_block_len = 1024;
                    long remain_len = datastream.Length;
                    while (remain_len > 0)
                    {
                        if (remain_len < send_block_len)
                        {
                            send_block_len = Convert.ToInt32(remain_len);
                        }
                        byte[] send_block_data = new byte[send_block_len];
                        datastream.Read(send_block_data, 0, send_block_len);
                        remain_len -= send_block_len;
                        msg.Data = send_block_data;
                        using (MemoryStream memstream = new MemoryStream())
                        {
                            serializer.Serialize(memstream, msg);
                            udpsoket_main.Send(broadcastIP, myselfinfo.Port, memstream.ToArray());
                        }
                    }

                    using (MemoryStream memstream = new MemoryStream())
                    {
                        msg.sendType = MessageSendType.End;
                        msg.Data = Encoding.UTF8.GetBytes("");
                        serializer.Serialize(memstream, msg);
                        udpsoket_main.Send(broadcastIP, myselfinfo.Port, memstream.ToArray());
                    }
                }
            }
            
        }

        /// <summary>
        /// 群发消息
        /// </summary>
        private void SendGroupMessage()
        {

        }

        private delegate void DataArrival_UI(byte[] data, IPAddress ip, int port);
        /// <summary>
        /// 接收数据的处理函数
        /// </summary>
        /// <param name="data"></param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        private void udpsocket_DataArrive(byte[] data, IPAddress ip, int port)
        {
            DataArrival_UI outdelegate = new DataArrival_UI(frmMain_DataArrive);
            this.BeginInvoke(outdelegate, new object[] { data, ip, port });
        }
        /// <summary>
        /// 消息接收和分发函数
        /// </summary>
        /// <param name="data"></param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        private void frmMain_DataArrive(byte[] data,IPAddress ip,int port)
        {
            try
            {
                BinaryFormatter deserializer = new BinaryFormatter();
                MessageEx msg = deserializer.Deserialize(new MemoryStream(data)) as MessageEx;
                switch(msg.chatType)
                {
                    case ChatType.One:
                        {
                            switch (msg.msgType)
                            {
                                case MessageType.Command:
                                    {
                                        Get_One_Command_msg(msg);
                                        break;
                                    }
                                case MessageType.File:
                                    {
                                        Get_One_File_msg(msg);
                                        break;
                                    }
                                case MessageType.RichText:
                                    {
                                        Get_One_RichText_msg(msg);
                                        break;
                                    }
                                case MessageType.None:
                                    {
                                        break;
                                    }
                                default:
                                    {
                                        break;
                                    }
                            }
                            break;
                        }
                    case ChatType.Qun:
                        {
                            break;
                        }
                    default:
                        break;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        /// <summary>
        /// 收到单聊消息的处理函数
        /// </summary>
        /// <param name="data"></param>
        private void Get_One_Command_msg(MessageEx msg)
        {
            try
            {
                switch (msg.msgCmdWord)
                {
                    //收到Online和Refresh消息后的动作基本一样，区分两个消息的目的是可以在Online消息中添加好友上线提醒
                    //收到OnlineBace和RefreshBack消息后的动作也基本一样，区分两个消息的目的是可以在OnlineBack消息中添加好友收到我上线的提醒
                    case MessageCommandWord.Online:
                        {
                            //接收刷新好友列表消息或好友上线消息后，回发一条back消息，并检查好友列表是否包含该好友，没有则添加，有则更新信息，并存数据库
                            //但是此消息可以生成好友上线消息提醒
                            Friend_Info friend = (Friend_Info)Serializer.DeSerializeBinary(msg.Data);
                            //检查是否是自己的广播包
                            if (friend.MacId != myselfinfo.MacId)
                            {
                                //检索该好友是否已经在好友列表中，在则更新好友列表和数据库，不在则插入好友列表和更新数据库
                                bool exist = false;
                                for (int i = 0; i < chatlistFriends.Items.Count - 1; i++)
                                {
                                    if (chatlistFriends.Items[i].GetType() == typeof(DuiBaseControl))
                                    {
                                        if (((Friend_Info)((chatlistFriends.Items[i] as DuiBaseControl).Tag)).MacId == friend.MacId)
                                        {
                                            exist = true;
                                            chatlistFriends.UpdateFriendInformation_InListAndDatabase((DuiBaseControl)(chatlistFriends.Items[i]), friend);
                                            break;
                                        }
                                    }
                                }
                                if (exist == false)
                                {
                                    chatlistFriends.AddFriend_InListAndDatabase(friend);
                                }
                                SendMessage(friend,
                                MessageType.Command,
                                MessageCommandWord.OnlineBack,
                                ChatType.One,
                                Serializer.SerializeBinary(new Friend_Info(myselfinfo)));
                            }
                            break;
                        }
                    case MessageCommandWord.OnlineBack:
                        {
                            Friend_Info friend = (Friend_Info)Serializer.DeSerializeBinary(msg.Data);
                            //检索该好友是否已经在好友列表中，在则更新好友列表和数据库，不在则插入好友列表和更新数据库
                            bool exist = false;
                            for (int i = 0; i < chatlistFriends.Items.Count - 1; i++)
                            {
                                if (chatlistFriends.Items[i].GetType() == typeof(DuiBaseControl))
                                {
                                    if (((Friend_Info)((chatlistFriends.Items[i] as DuiBaseControl).Tag)).MacId == friend.MacId)
                                    {
                                        exist = true;
                                        chatlistFriends.UpdateFriendInformation_InListAndDatabase((DuiBaseControl)(chatlistFriends.Items[i]), friend);
                                        break;
                                    }
                                }
                            }
                            if (exist == false)
                            {
                                chatlistFriends.AddFriend_InListAndDatabase(friend);
                            }
                            break;
                        }
                    case MessageCommandWord.Refresh:
                        {
                            //接收刷新好友列表消息或好友上线消息后，回发一条back消息，并检查好友列表是否包含该好友，没有则添加，有则更新信息，并存数据库
                            //从功能上来讲，收到userlist消息后的动作完全包含了收到logined和updatestate消息后的动作，之所以仍然分开处理，则是为了能够单独生成上线和更新状态的消息提醒                        
                            Friend_Info friend = (Friend_Info)Serializer.DeSerializeBinary(msg.Data);
                           if(friend.MacId!=myselfinfo.MacId)
                            {
                                bool exist = false;
                                for (int i = 0; i < chatlistFriends.Items.Count - 1; i++)
                                {
                                    if (chatlistFriends.Items[i].GetType() == typeof(DuiBaseControl))
                                    {
                                        if (((Friend_Info)((chatlistFriends.Items[i] as DuiBaseControl).Tag)).MacId == friend.MacId)
                                        {
                                            exist = true;
                                            chatlistFriends.UpdateFriendInformation_InListAndDatabase((DuiBaseControl)(chatlistFriends.Items[i]), friend);
                                            break;
                                        }
                                    }
                                }
                                if (exist == false)
                                {
                                    chatlistFriends.AddFriend_InListAndDatabase(friend);
                                }
                                SendMessage(friend,
                                MessageType.Command,
                                MessageCommandWord.RefreshBack,
                                ChatType.One,
                                Serializer.SerializeBinary(new Friend_Info(myselfinfo)));
                            }
                            break;
                        }
                    case MessageCommandWord.RefreshBack:
                        {
                            Friend_Info friend = (Friend_Info)Serializer.DeSerializeBinary(msg.Data);
                            //检索该好友是否已经在好友列表中，在则更新好友列表和数据库，不在则插入好友列表和更新数据库
                            bool exist = false;
                            for (int i = 0; i < chatlistFriends.Items.Count - 1; i++)
                            {
                                if (chatlistFriends.Items[i].GetType() == typeof(DuiBaseControl))
                                {
                                    if (((Friend_Info)((chatlistFriends.Items[i] as DuiBaseControl).Tag)).MacId == friend.MacId)
                                    {
                                        exist = true;
                                        chatlistFriends.UpdateFriendInformation_InListAndDatabase((DuiBaseControl)(chatlistFriends.Items[i]), friend);
                                        break;
                                    }
                                }
                            }                          
                            if (exist == false)
                            {
                                chatlistFriends.AddFriend_InListAndDatabase(friend);
                            }
                            break;
                        }
                    case MessageCommandWord.UpdateInfo:
                        {
                            //接收好友更新状态消息后，更改好友状态信息，并存数据库
                            Friend_Info friend = (Friend_Info)Serializer.DeSerializeBinary(msg.Data);
                            if (friend.MacId != myselfinfo.MacId)
                            {
                                bool exist = false;
                                for (int i = 0; i < chatlistFriends.Items.Count - 1; i++)
                                {
                                    if (chatlistFriends.Items[i].GetType() == typeof(DuiBaseControl))
                                    {
                                        if (((Friend_Info)((chatlistFriends.Items[i] as DuiBaseControl).Tag)).MacId == friend.MacId)
                                        {
                                            exist = true;
                                            chatlistFriends.UpdateFriendInformation_InListAndDatabase((DuiBaseControl)(chatlistFriends.Items[i]), friend);
                                            break;
                                        }
                                    }
                                }
                                if (exist == false)
                                {
                                    chatlistFriends.AddFriend_InListAndDatabase(friend);
                                }
                            }
                            break;
                        }
                    case MessageCommandWord.Offline:
                        {
                            //接收好友下线消息后，删除好友
                            Friend_Info friend = (Friend_Info)Serializer.DeSerializeBinary(msg.Data);
                            if (friend.MacId != myselfinfo.MacId)
                            {
                                bool exist = false;
                                for(int i=0;i< chatlistFriends.Items.Count-1;i++)
                                {
                                    if (chatlistFriends.Items[i].GetType() == typeof(DuiBaseControl))
                                    {
                                        if (((Friend_Info)((chatlistFriends.Items[i] as DuiBaseControl).Tag)).MacId == friend.MacId)
                                        {
                                            exist = true;
                                            chatlistFriends.UpdateFriendInformation_InListAndDatabase((DuiBaseControl)(chatlistFriends.Items[i]), friend);
                                            break;
                                        }
                                    }
                                }
                                if (exist == false)
                                {
                                    chatlistFriends.AddFriend_InListAndDatabase(friend);
                                }
                            }
                            break;
                        }
                    case MessageCommandWord.Heartbeat:
                        {
                            //接收好友back消息后，并检查好友列表是否包含该好友，没有则添加，有则更新信息，并存数据库
                            break;
                        }
                    case MessageCommandWord.QunInvite:
                        {
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }
        private void Get_One_File_msg(MessageEx msg)
        { }
        private void Get_One_RichText_msg(MessageEx msg)
        {
            try
            {
                switch(msg.sendType)
                {
                    case MessageSendType.Single:
                        {
                            ChatData singlechatdata = Serializer.DeSerializeBinary(msg.Data) as ChatData;
                            FrmChat frmChat = FindChatForm(singlechatdata.sender_macId);
                            if(frmChat==null)
                            {
                                DuiBaseControl chatitem = chatlistFriends.FindFriend(singlechatdata.sender_macId);
                                if(chatitem==null)
                                {
                                    MessageBox.Show("一个未检测到的好友给你发送消息，程序无法处理，请刷新你的好友列表");
                                    return;
                                }
                                frmChat = new FrmChat(udpsoket_main, frmchatlist_main, chatitem,this);
                                frmChat.Show();
                            }
                            frmChat.rtfReceive.SelectionStart = frmChat.rtfReceive.TextLength;
                            //frmChat.rtfReceive.AppendRichText(ContentAlignment, font, color);                            
                            Friend_Info info = (Friend_Info)(((DuiBaseControl)(frmChat.Tag)).Tag);
                            if(info.MarkName==null||info.MarkName=="")
                            {
                                frmChat.rtfReceive.AppendRichText(
                                    info.NickName + "   " + DateTime.Now.ToString("(M月d日HH:mm)"),
                                    new Font("Microsoft YaHei UI", 9.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, (byte)(134)),
                                    Color.FromName("HotTrack"));
                            }
                            else
                            {
                                frmChat.rtfReceive.AppendText(string.Format("{0}({1})", new object[] { info.NickName, info.MarkName }) + "   " + DateTime.Now.ToString());
                            }
                            frmChat.rtfReceive.AppendText(Environment.NewLine);
                            frmChat.rtfReceive.SelectedRtf = Encoding.UTF8.GetString(singlechatdata.rictTextData);
                            frmChat.rtfReceive.AppendText(Environment.NewLine);
                            frmChat.rtfReceive.ScrollToCaret();
                            frmChat.Activate();
                            break;
                        }
                    case MessageSendType.Start:
                        {
                            FileStream fs = null;
                            try
                            {
                                fs = File.Create(Environment.CurrentDirectory + @"\" + msg.MsgID + ".msg");
                            }
                            finally
                            {
                                fs.Close();
                            }
                            break;
                        }
                    case MessageSendType.Sending:
                        {
                            FileStream fs = null;
                            try
                            {
                                fs = File.OpenWrite(Environment.CurrentDirectory + @"\" + msg.MsgID + ".msg");
                                fs.Seek(0, SeekOrigin.End);
                                fs.Write(msg.Data,0, msg.Data.Length);
                            }
                            finally
                            {
                                fs.Close();
                            }
                            break;
                        }
                    case MessageSendType.End:
                        {
                            FileStream fs = null;
                            try
                            {                                
                                fs = File.OpenRead(Environment.CurrentDirectory + @"\" + msg.MsgID + ".msg");
                                fs.Seek(0, SeekOrigin.Begin);
                                byte[] fsdata = new byte[Convert.ToInt32(fs.Length)];
                                fs.Read(fsdata, 0, Convert.ToInt32(fs.Length));
                                ChatData chatdata = Serializer.DeSerializeBinary(fsdata) as ChatData;
                                

                                FrmChat frmChat = FindChatForm(chatdata.sender_macId);
                                if (frmChat == null)
                                {
                                    DuiBaseControl chatitem = chatlistFriends.FindFriend(chatdata.sender_macId);
                                    if (chatitem == null)
                                    {
                                        MessageBox.Show("一个未检测到的好友给你发送消息，程序无法处理，请刷新你的好友列表");
                                        return;
                                    }
                                    frmChat = new FrmChat(udpsoket_main, frmchatlist_main, chatitem,this);
                                    frmChat.Show();
                                }
                                frmChat.rtfReceive.SelectionStart = frmChat.rtfReceive.TextLength;
                                //frmChat.rtfReceive.AppendRichText(ContentAlignment, font, color);
                                frmChat.rtfReceive.AppendText(Environment.NewLine);
                                Friend_Info info = (Friend_Info)(((DuiBaseControl)(frmChat.Tag)).Tag);
                                if (info.MarkName == null || info.MarkName == "")
                                {
                                    frmChat.rtfReceive.AppendRichText(
                                    info.NickName + "   " + DateTime.Now.ToString("(M月d日HH:mm)"),
                                    new Font("Microsoft YaHei UI", 9.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, (byte)(134)),
                                    Color.FromName("HotTrack"));
                                }
                                else
                                {
                                    frmChat.rtfReceive.AppendText(string.Format("{0}({1})", new object[] { info.NickName, info.MarkName }));
                                }
                                frmChat.rtfReceive.AppendText(Environment.NewLine);
                                frmChat.rtfReceive.SelectedRtf = Encoding.UTF8.GetString(chatdata.rictTextData);
                                frmChat.rtfReceive.ScrollToCaret();
                                frmChat.Activate();
                            }
                            finally
                            {
                                fs.Close();
                            }

                            File.Delete(Environment.CurrentDirectory + @"\" + msg.MsgID + ".msg");
                            break;
                        }
                    default:
                        break;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("错误位置：Get_One_RichText_msg()。" + e.Message);
            }
        }
  
        /// <summary>
        /// 初始化数据库，包括self表信息
        /// </summary>
        /// <param name="dataFileName"></param>
        private void DatabaseInitial(string dataFileName)
        {
            SqliteHelper.DbConStr = dataFileName;
            Sqlite = new SqliteHelper();
            myselfinfo = new Self_Info();
            myselfinfo.NickNameChanged += frmMain_NickNameChanged;
            myselfinfo.SignChanged += frmMain_SignChanged;
            myselfinfo.HeadImgChanged += frmMain_HeadImgChanged;
            myselfinfo.StateChanged+=frmMain_StateChanged;
            myselfinfo.IpChanged += frmMain_IpChanged;
            myselfinfo.PortChanged += frmMain_PortChanged;

            //检查并创建数据库
            if (File.Exists(Environment.CurrentDirectory + @"\"+dataFileName) == false)
            {
                try
                {
                    Sqlite.CreateDb(Environment.CurrentDirectory + @"\"+ dataFileName);
                    string sql;
                    sql = "CREATE TABLE Self (" +
                        "_id INTEGER PRIMARY KEY AUTOINCREMENT," +
                        "MacId TEXT," +
                        "NickName TEXT," +
                        "Sign TEXT," +
                        "HeadImg blob," +
                        "Ip TEXT," +
                        "Port integer," +
                        "Qun_IDlist blob)";
                    Sqlite.ExecuteNonQuery(sql, null);
                    sql = "CREATE TABLE Friends (" +
                        "_id INTEGER PRIMARY KEY AUTOINCREMENT," +
                        "MacId TEXT," +
                        "MarkName TEXT," +
                        "NickName TEXT," +
                        "Sign TEXT," +
                        "HeadImg blob," +
                        "Ip TEXT," +
                        "Port integer," +
                        "GroupId TEXT)";
                    Sqlite.ExecuteNonQuery(sql, null);
                    sql = "CREATE TABLE Chat (" +
                        "_id INTEGER PRIMARY KEY AUTOINCREMENT," +
                        "MacId TEXT," +
                        "ChatDate TEXT," +
                        "ChatContent blob)";
                    Sqlite.ExecuteNonQuery(sql, null);
                    sql = "CREATE TABLE Friend_Qun (" +
                        "_id INTEGER PRIMARY KEY AUTOINCREMENT," +
                        "MacId TEXT," +
                        "QunID INTEGER," +
                        "JoinTime TEXT)";
                    Sqlite.ExecuteNonQuery(sql, null);
                    sql = "CREATE TABLE Quns (" +
                        "_id INTEGER PRIMARY KEY AUTOINCREMENT," +
                        "QunID integer," +
                        "QunName TEXT," +
                        "CreateTime TEXT)";
                    Sqlite.ExecuteNonQuery(sql, null);
                    sql = "CREATE TABLE Groups (" +
                        "_id INTEGER PRIMARY KEY AUTOINCREMENT," +
                        "GroupId integer," +
                        "GroupName TEXT)";
                    Sqlite.ExecuteNonQuery(sql, null);


                    Dictionary<string, object> data = new Dictionary<string, object>();
                    data.Add("_id", null);
                    data.Add("MacId", myselfinfo.MacId);
                    data.Add("NickName", myselfinfo.NickName);
                    data.Add("Sign", myselfinfo.Sign);
                    if(myselfinfo.HeadImg!=null)
                    {
                        MemoryStream memImg = new MemoryStream();
                        myselfinfo.HeadImg.Save(memImg, System.Drawing.Imaging.ImageFormat.Png);
                        data.Add("HeadImg", memImg.GetBuffer());
                    }
                    else
                    {                        
                        data.Add("HeadImg", null);
                    }                    
                    data.Add("Ip", myselfinfo.Ip.ToString());
                    data.Add("Port", myselfinfo.Port);
                    if(myselfinfo.Qun_IDlist==null)
                    {
                        data.Add("Qun_IDlist", null);
                    }
                    else
                    {
                        MemoryStream memlist = new MemoryStream();
                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(memlist, myselfinfo.Qun_IDlist);
                        data.Add("Qun_IDlist", memlist.GetBuffer());
                    }
                    Sqlite.Insert("Self", data);
                }
                catch (Exception e)
                {
                    MessageBox.Show("创建数据库失败。"+e.Message);
                }
            }
            else
            {
                try
                {
                    Self_Info_InDatabase self_Info_InDatabase = Self_Info_InDatabase.QuerySelfInfo(Sqlite);
                    if(self_Info_InDatabase.MacId!=myselfinfo.MacId)
                    {
                        Self_Info_InDatabase.UpdateSelfInfo(Sqlite,myselfinfo);
                    }
                    else
                    {
                        myselfinfo.NickName = self_Info_InDatabase.NickName;
                        myselfinfo.Sign = self_Info_InDatabase.Sign;
                        myselfinfo.Port = self_Info_InDatabase.Port;
                        if(self_Info_InDatabase.HeadImg!=null)
                        {
                            myselfinfo.HeadImg = self_Info_InDatabase.HeadImg;
                        }
                        if(self_Info_InDatabase.Qun_IDlist!=null)
                        {
                            myselfinfo.Qun_IDlist = self_Info_InDatabase.Qun_IDlist;
                        }
                        if (self_Info_InDatabase.Ip.ToString() != myselfinfo.Ip.ToString())
                        {
                            bool flag = false;
                            foreach (UnicastIPAddressInformation item in myselfinfo.currentIPs)
                            {
                                if (item.Address.ToString() == self_Info_InDatabase.Ip.ToString())
                                {
                                    myselfinfo.Ip = self_Info_InDatabase.Ip;
                                    flag = true;
                                }
                            }
                            if(flag)
                            {
                                Dictionary<string, object> data = new Dictionary<string, object>();
                                data.Add("Ip", myselfinfo.Ip.ToString());                               
                                KeyValuePair<string, object> where = new KeyValuePair<string, object>("_id", 1);
                                Sqlite.Update("Self", data, where);
                            }
                        }
                            
                    }
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show("错误位置：DatabaseInitial()。"+e.Message);
                }
            }
            return;
        }

        private void chatlistFriends_DoubleClickItem(object sender, ChatListItemClickEventArgs e, MouseEventArgs es)
        {
            FrmChat frmChat = FindChatForm(((Friend_Info)(e.Friend.Tag)).MacId);
            if (frmChat == null)
            {
                frmChat = new FrmChat(udpsoket_main, frmchatlist_main, e.Friend, this);
                frmChat.Show();
                frmChat.rtfSend.Focus();
            }
            else
            {
                frmChat.Activate();
                frmChat.rtfSend.Focus();
            }
        }
        /// <summary>
        /// 在已打开的聊天窗口中检索指定好友的窗口
        /// </summary>
        /// <param name="friend_macid"></param>
        /// <returns></returns>
        private FrmChat FindChatForm(string friend_macid)
        {
            foreach(FrmChat item in frmchatlist_main)
            {
                if(((Friend_Info)(((DuiBaseControl)item.Tag).Tag)).MacId==friend_macid)
                {
                    return item;
                }
            }
            return null;
        }
        #region 个人信息更改事件处理函数

        /// <summary>
        /// myselfinfo中Nickname发生变化时触发的事件处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="nickname"></param>
        private void frmMain_NickNameChanged(object sender,string nickname)
        {
            lblNickName.Text = nickname;
            ((DuiLabel)(chatlistFriends.Items[chatlistFriends.Items.Count - 1].Controls[1])).Text = string.Format("{0}  ({1})", ((Self_Info)sender).NickName, ((Self_Info)sender).MarkName);
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("NickName", nickname);
            KeyValuePair<string, object> where = new KeyValuePair<string, object>("MacId", myselfinfo.MacId);
            Sqlite.Update("Self", data, where);
        }

        /// <summary>
        /// myselfinfo中Sign发生变化时触发的事件处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="sign"></param>
        private void frmMain_SignChanged(object sender,string sign)
        {
            duiTextBoxSign.Text = sign;
            ((DuiLabel)(chatlistFriends.Items[chatlistFriends.Items.Count - 1].Controls[2])).Text = sign;
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("Sign", sign);
            KeyValuePair<string, object> where = new KeyValuePair<string, object>("MacId", myselfinfo.MacId);
            Sqlite.Update("Self", data, where);
        }

        /// <summary>
        /// myselfinfo中Headimg发生变化时触发的事件处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="headimg"></param>
        private void frmMain_HeadImgChanged(object sender,Bitmap headimg)
        {
            picHeader.BackgroundImage = headimg;
            ((DuiPictureBox)(chatlistFriends.Items[chatlistFriends.Items.Count - 1].Controls[0])).BackgroundImage = headimg;
            Dictionary<string, object> data = new Dictionary<string, object>();
            if (headimg != null)
            {
                MemoryStream memImg = new MemoryStream();
                myselfinfo.HeadImg.Save(memImg, System.Drawing.Imaging.ImageFormat.Png);
                data.Add("HeadImg", memImg.GetBuffer());
            }
            else
            {
                data.Add("HeadImg", null);
            }
            KeyValuePair<string, object> where = new KeyValuePair<string, object>("MacId", myselfinfo.MacId);
            Sqlite.Update("Self", data, where);
        }

        /// <summary>
        /// myselfinfo中State发生变化时触发的事件处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="state"></param>
        private void frmMain_StateChanged(object sender,FriendState state)
        {
            switch(state)
            {
                case FriendState.Busy:
                    {
                        picHeader.Image= Properties.Resources.busy;
                        ((DuiPictureBox)(chatlistFriends.Items[chatlistFriends.Items.Count - 1].Controls[0])).Image = Properties.Resources.busy;

                        break;
                    }
                case FriendState.Leave:
                    {
                        picHeader.Image = Properties.Resources.leave;
                        ((DuiPictureBox)(chatlistFriends.Items[chatlistFriends.Items.Count - 1].Controls[0])).Image = Properties.Resources.leave;
                        break;
                    }
                case FriendState.Offline:
                    {
                        picHeader.BackgroundImage = Properties.Resources.YellowEar_Offline;
                        picHeader.Image = null;
                        ((DuiPictureBox)(chatlistFriends.Items[chatlistFriends.Items.Count - 1].Controls[0])).BackgroundImage = Properties.Resources.YellowEar_Offline;
                        ((DuiPictureBox)(chatlistFriends.Items[chatlistFriends.Items.Count - 1].Controls[0])).Image = null;
                        break;
                    }
                case FriendState.Online:
                    {
                        picHeader.BackgroundImage = ((Self_Info)sender).HeadImg;
                        picHeader.Image = null;
                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// myselfinfo中Ip发生变化时触发的事件处理函数
        /// </summary>
        private void frmMain_IpChanged(object sender,IPAddress ip)
        {
            lblIP.Text = ip.ToString();
            if(udpsoket_main!=null)
            {
                if(udpsoket_main.ListenActive==true)
                {
                    udpsoket_main.ListenActive = false;//关闭套接字
                }
                udpsoket_main.IpAndPort.Address = ip;//修改IP
                udpsoket_main.ListenActive = true;//重新开始监听
            }
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("Ip", ip.ToString());
            KeyValuePair<string, object> where = new KeyValuePair<string, object>("MacId", myselfinfo.MacId);
            Sqlite.Update("Self", data, where);
        }
        /// <summary>
        /// myselfinfo中Port发生变化时触发的事件处理函数
        /// </summary>
        private void frmMain_PortChanged(object sender,int port)
        {
            if (udpsoket_main != null)
            {
                if (udpsoket_main.ListenActive == true)
                {
                    udpsoket_main.ListenActive = false;//关闭套接字
                }
                udpsoket_main.IpAndPort.Port = port;//修改Port
                udpsoket_main.ListenActive = true;//重新开始监听
            }
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("Port", port);
            KeyValuePair<string, object> where = new KeyValuePair<string, object>("MacId", myselfinfo.MacId);
            Sqlite.Update("Self", data, where);
        }
        #endregion

        private void picHeader_DoubleClick(object sender, EventArgs e)
        {
            frmSetting frmSetting = new frmSetting(myselfinfo);
            if (frmSetting.ShowDialog() == DialogResult.OK)
            {
                frmSetting.Dispose();
                BroadcastMessage(Serializer.SerializeBinary(new Friend_Info(myselfinfo)), MessageCommandWord.UpdateInfo, ChatType.One);
            }
            else
            {
                frmSetting.Dispose();
            }
        }

        /// <summary>
        /// 托盘双击事件处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(this.WindowState==FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.Activate();
                this.ShowInTaskbar = true;
            }
            else
            {
                this.Activate();
            }
        }

        private void tsmiSetting_Click(object sender, EventArgs e)
        {
            frmSetting frmSetting = new frmSetting(myselfinfo);
            if (frmSetting.ShowDialog() == DialogResult.OK)
            {
                frmSetting.Dispose();
                BroadcastMessage(Serializer.SerializeBinary(new Friend_Info(myselfinfo)), MessageCommandWord.UpdateInfo, ChatType.One);
            }
            else
            {
                frmSetting.Dispose();
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            foreach(FrmChat item in frmchatlist_main)
            {
                item.Close();
            }
            this.Close();
        }

        private void picMin_MouseHover(object sender, EventArgs e)
        {
            tooltip1.Show("最小化", (Control)sender);
        }

        private void picClose_MouseHover(object sender, EventArgs e)
        {
            tooltip1.Show("最小化到托盘", (Control)sender);
        }

        private void tsmiOpenCloseHeadImgTwinkle_Click(object sender, EventArgs e)
        {
            if(isTwinkle==false)
            {
                isTwinkle = true;
                timerIconTwinkle.Enabled = true;
                timerIconTwinkle.Start();
                tsmiOpenCloseHeadImgTwinkle.Text = "关闭头像闪动";
                //notifyIcon1.ShowBalloonTip(5000, "提示", "闪烁效果打开", ToolTipIcon.Info);
            }
            else
            {
                isTwinkle = false;
                timerIconTwinkle.Stop();
                notifyIcon1.Icon = Properties.Resources.黄耳32;
                timerIconTwinkle.Enabled = false;
                tsmiOpenCloseHeadImgTwinkle.Text = "打开头像闪动";
                //notifyIcon1.ShowBalloonTip(5000, "提示", "闪烁效果关闭", ToolTipIcon.Info);
            }
        }

        /// <summary>
        /// 图标闪烁的定时器事件处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerIconTwinkle_Tick(object sender, EventArgs e)
        {
            if(icoState)
            {
                notifyIcon1.Icon = Properties.Resources.黄耳32_blank;
            }
            else
            {
                notifyIcon1.Icon = Properties.Resources.黄耳32;
            }
            icoState = !icoState;
        }
    }
}
