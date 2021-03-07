using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace YellowEar
{
    /// <summary>
    /// 存储自己的信息，Friend_Info好友信息类多一些不需要传输的信息
    /// </summary>
    public class Self_Info
    {
        public delegate void NickNameChangedHandler(object sender, string nickname);
        public event NickNameChangedHandler NickNameChanged;

        public delegate void SignChangedHandler(object sender, string sign);
        public event SignChangedHandler SignChanged;

        public delegate void HeadImgChangedHandler(object sender, Bitmap HeadImg);
        public event HeadImgChangedHandler HeadImgChanged;

        public delegate void StateChangedHandler(object sender, FriendState State);
        public event StateChangedHandler StateChanged;

        public delegate void IPChangedHandler(object sender,IPAddress ip);
        public event IPChangedHandler IpChanged;

        public delegate void PortChangedHandler(object sender, int port);
        public event PortChangedHandler PortChanged;

        /// <summary>
        /// 用户mac地址，无服务器时当唯一标识号使用
        /// </summary>
        public string MacId { get; set; }

        private string _nickname;
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName 
        { 
            get{ return _nickname;} 
            set
            {
                if(_nickname!=value)
                {
                    _nickname = value;
                    if(NickNameChanged!=null)
                    {
                        NickNameChanged(this, _nickname);
                    }
                }
            }
        }

        /// <summary>
        /// 备注名称
        /// </summary>
        public string MarkName { get; set; }

        private string _sign;
        /// <summary>
        /// 个人签名
        /// </summary>
        public string Sign 
        { 
            get{ return _sign;} 
            set
            {
                if(_sign!=value)
                {
                    _sign = value;
                    if(SignChanged!=null)
                    {
                        SignChanged(this, _sign);
                    }                    
                }
            }
        }

        private Bitmap _headimg;
        /// <summary>
        /// 个人头像
        /// </summary>
        public Bitmap HeadImg 
        { 
            get{ return _headimg;} 
            set
            {
                if(_headimg!=value)
                {
                    _headimg = value;
                    if(HeadImgChanged!=null)
                    {
                        HeadImgChanged(this, _headimg);
                    }                    
                }
            }
        }

        private FriendState _state = FriendState.None;
        /// <summary>
        /// 用户状态,有无服务器时均使用
        /// </summary>
        public FriendState State 
        { 
            get { return _state; } 
            set
            {
                if(_state!=value)
                {
                    _state = value;
                    if(StateChanged!=null)
                    {
                        StateChanged(this, _state);
                    }                    
                }
            }
        }

        private IPAddress _ip;
        /// <summary>
        /// 用户IP地址，无服务器时使用
        /// </summary>
        public IPAddress Ip 
        { 
            get{ return _ip;} 
            set
            {
                if(_ip!=value)
                {
                    _ip = value;
                    if(IpChanged!=null)
                    {
                        IpChanged(this,_ip);
                    }
                }
            } 
        }

        private int _port = 0;
        /// <summary>
        /// 用户端口号，无服务器时使用
        /// </summary>
        public int Port 
        { 
            get{ return _port;} 
            set
            {
                if(_port!=value)
                {
                    _port = value;
                    if(PortChanged!=null)
                    {
                        PortChanged(this,_port);
                    }
                }
            }
        }

        public List<string> Qun_IDlist;//自己所在的群组列表
        public List<UnicastIPAddressInformation> currentIPs;//当前主机所有活动的IP信息列表
        //public int IpIndex;//当前使用的ip在currentIPs中的索引
        
        public Self_Info()
        {
            MacId = GetMacUid();
            NickName = Environment.UserName;
            MarkName = "自己";
            Sign = "写下你的个人签名吧";
            HeadImg = null;
            State = FriendState.Online;
            Port = 19870;
            currentIPs = GetIpListInfo();
            Ip = currentIPs[0].Address;
            Qun_IDlist = null;

        }
        /// 获取mac地址
        /// </summary>
        /// <returns></returns>
        private string GetMacUid()
        {
            List<string> macs = new List<string>();
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())//遍历所有网络接口（即网卡）
            {
                if (ni.OperationalStatus == OperationalStatus.Up && ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    macs.Add(ni.GetPhysicalAddress().ToString());
                }
            }
            return macs[0];
        }
        /// <summary>
        /// 获取正在使用的ip地址信息列表
        /// </summary>
        /// <returns></returns>
        public static List<UnicastIPAddressInformation> GetIpListInfo()
        {
            List<UnicastIPAddressInformation> _iplist = new List<UnicastIPAddressInformation>();
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())//遍历所有网络接口（即网卡）
            {
                if (ni.OperationalStatus == OperationalStatus.Up && (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet || ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211))
                {
                    foreach (UnicastIPAddressInformation end in ni.GetIPProperties().UnicastAddresses)//遍历以太网卡上所有IP地址
                    {
                        if (end.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)//IPv4
                        {
                            _iplist.Add(end);
                        }
                    }
                }
            }
            return _iplist;
        }

    }

    /// <summary>
    /// 好友信息类，用于在通信或本地记录中存储好友信息
    /// </summary>
    [Serializable]
    public class Friend_Info
    {
        /// <summary>
        /// 用户mac地址，无服务器时当唯一标识号使用
        /// </summary>
        public string MacId { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 备注名称
        /// </summary>
        public string MarkName { get; set; }
        /// <summary>
        /// 个人签名
        /// </summary>
        public string Sign { get; set; }
        /// <summary>
        /// 个人头像
        /// </summary>
        public Bitmap HeadImg { get; set; }
        /// <summary>
        /// 用户状态,有无服务器时均使用
        /// </summary>
        public FriendState State { get; set; }
        /// <summary>
        /// 用户IP地址，无服务器时使用
        /// </summary>
        public IPAddress Ip { get; set; }
        /// <summary>
        /// 用户端口号，无服务器时使用
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 属于哪个好友分组
        /// </summary>
        public string GroupId { get; set; }

        public Friend_Info(Self_Info friend)
        {
            MacId = friend.MacId;
            MarkName = "";
            NickName = friend.NickName;
            Sign = friend.Sign;
            HeadImg = friend.HeadImg;
            State = friend.State;
            Ip = friend.Ip;
            Port = friend.Port;
        }
        public Friend_Info() 
        {
            NickName = "";
            MarkName = "";
            Sign = "";
            HeadImg = null;
            State = FriendState.None;
            Ip = null;
            Port = -1;
        }

        /// <summary>
        /// 在数据库中添加好友项
        /// </summary>
        /// <param name="friend"></param>
        public static void InsertFriendIntoDatabase(SqliteHelper sqlite,Friend_Info friend)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("_id", null);
            data.Add("MacId", friend.MacId);
            data.Add("MarkName", friend.MarkName);
            data.Add("NickName", friend.NickName);
            data.Add("Sign", friend.Sign);
            if (friend.HeadImg != null)
            {
                MemoryStream memImg = new MemoryStream();
                friend.HeadImg.Save(memImg, System.Drawing.Imaging.ImageFormat.Png);
                data.Add("HeadImg", memImg.GetBuffer());
            }
            else
            {
                data.Add("HeadImg", null);
            }
            data.Add("Ip", friend.Ip.ToString());
            data.Add("Port", friend.Port);
            data.Add("GroupId", friend.GroupId);
            sqlite.Insert("Friends", data);
        }

        /// <summary>
        /// 在数据库中更新好友项
        /// </summary>
        /// <param name="friend"></param>
        public static void UpdateFrindIntoDatabase(SqliteHelper sqlite,Friend_Info friend)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            KeyValuePair<string, object> where = new KeyValuePair<string, object>("MacId", friend.MacId);
            data.Add("MarkName", friend.MarkName);
            data.Add("NickName", friend.NickName);
            data.Add("Sign", friend.Sign);
            if (friend.HeadImg != null)
            {
                MemoryStream memImg = new MemoryStream();
                friend.HeadImg.Save(memImg, System.Drawing.Imaging.ImageFormat.Png);
                data.Add("HeadImg", memImg.GetBuffer());
            }
            else
            {
                data.Add("HeadImg", null);
            }
            data.Add("Ip", friend.Ip.ToString());
            data.Add("Port", friend.Port);
            data.Add("GroupId", friend.GroupId);
            sqlite.Update("Friends", data, where);
        }

    }

    /// <summary>
    /// 与数据库中self表内容对应，用于读写self表时预存self表信息
    /// </summary>
    public class Self_Info_InDatabase
    {
        /// <summary>
        /// 用户mac地址，无服务器时当唯一标识号使用
        /// </summary>
        public string MacId { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 个人签名
        /// </summary>
        public string Sign { get; set; }
        /// <summary>
        /// 个人头像
        /// </summary>
        public Bitmap HeadImg { get; set; }       
        /// <summary>
        /// 用户IP地址，无服务器时使用
        /// </summary>
        public IPAddress Ip { get; set; }
        /// <summary>
        /// 用户端口号，无服务器时使用
        /// </summary>
        public int Port { get; set; }

        public List<string> Qun_IDlist;//自己所在的群组列表

        /// <summary>
        /// 从数据库中查询出self表信息
        /// </summary>
        /// <param name="Sqlite"></param>
        /// <returns></returns>
        public static Self_Info_InDatabase QuerySelfInfo(SqliteHelper Sqlite)
        {
            Self_Info_InDatabase myself_indatabase = new Self_Info_InDatabase();
            try
            {
                string sql = "select * from Self limit 0,1";
                DataTable result = Sqlite.ExecuteDataTable(sql, null);
                myself_indatabase.MacId = (string)result.Rows[0][1];
                myself_indatabase.NickName = (string)result.Rows[0][2];
                myself_indatabase.Sign = (string)result.Rows[0][3];
                if(result.Rows[0][4]!=DBNull.Value)
                {
                    myself_indatabase.HeadImg = (Bitmap)Image.FromStream(new MemoryStream((byte[])result.Rows[0][4]));
                }
                else
                {
                    myself_indatabase.HeadImg = null;
                }
                myself_indatabase.Ip = IPAddress.Parse(Convert.ToString(result.Rows[0][5]));
                myself_indatabase.Port = Convert.ToInt32(result.Rows[0][6]);
                BinaryFormatter binaryFormatter = new BinaryFormatter();   
                if(result.Rows[0][7]!=DBNull.Value)
                {
                    myself_indatabase.Qun_IDlist = (List<string>)binaryFormatter.Deserialize(new MemoryStream(((byte[])result.Rows[0][7])));
                }
                else
                {
                    myself_indatabase.Qun_IDlist = null;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("错误位置：Self_Info_InDatabase.QuerySelfInfo()。" + e.Message);
            }
            return myself_indatabase;
        }
        /// <summary>
        /// 重写数据库中self表的全部信息
        /// </summary>
        /// <param name="sqlite"></param>
        /// <param name="self_Info"></param>
        public static void UpdateSelfInfo(SqliteHelper sqlite,Self_Info self_Info)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("MacId", self_Info.MacId);
            data.Add("NickName", self_Info.NickName);
            data.Add("Sign", self_Info.Sign);
            if (self_Info.HeadImg !=null)
            {
                MemoryStream memImg = new MemoryStream();
                self_Info.HeadImg.Save(memImg, System.Drawing.Imaging.ImageFormat.Png);
                data.Add("HeadImg", memImg.GetBuffer());
            }
            else
            {                
                data.Add("HeadImg", null);
            }
            data.Add("Ip", self_Info.Ip.ToString());
            data.Add("Port", self_Info.Port);
            if (self_Info.Qun_IDlist == null)
            {
                data.Add("Qun_IDlist", null);
            }
            else
            {
                MemoryStream memlist = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memlist, self_Info.Qun_IDlist);
                data.Add("Qun_IDlist", memlist.GetBuffer());
            }
            KeyValuePair<string, object> where = new KeyValuePair<string, object>("_id", 1);
            sqlite.Update("Self", data, where);
        }
    }
}
