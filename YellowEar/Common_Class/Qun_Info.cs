using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YellowEar
{
    /// <summary>
    /// 本地存储群信息，比 Qun_Info_ToSend包含更多信息
    /// </summary>
    public class Qun_Info
    {
        public string QunID;
        public string QunName;
        public byte[] QunNotice;
        public string QunAdministrator;
        public DateTime CreateTime;
        public Dictionary<string, string> Member_macID_QunNickname;

        #region ,不参与传输的字段
        public string QunMarkName;
        public DateTime JoinTime;
        #endregion
    }
    /// <summary>
    /// 用于通信过程中存储群信息
    /// </summary>
    [Serializable]
    public class Qun_Info_ToSend
    {
        public string QunID;
        public string QunName;
        public byte[] QunNotice;
        public string QunAdministrator;
        public DateTime CreateTime;
        public Dictionary<string,string> Member_macID_QunNickname;

        public Qun_Info_ToSend(Qun_Info qun)
        {
            QunID = qun.QunID;
            QunName = qun.QunName;
            QunNotice = qun.QunNotice;
            QunAdministrator = qun.QunAdministrator;
            Member_macID_QunNickname = qun.Member_macID_QunNickname;
        }
    }
}
