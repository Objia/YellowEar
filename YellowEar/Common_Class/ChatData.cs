using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YellowEar
{
    /// <summary>
    /// 单聊数据包
    /// </summary>
    [Serializable]
    public class ChatData
    {
        public string sender_macId;
        public byte[] rictTextData;
        public ChatData() { }
        public ChatData(string macId,byte[] richText)
        {
            sender_macId = macId;
            rictTextData = richText;
        }
    }

    /// <summary>
    /// 群聊数据包
    /// </summary>
    [Serializable]
    public class QunChatData
    {
        public string QunID;
        public string sender_macId;
        public byte[] richTextData;
        public QunChatData() { }
        public QunChatData(string qunID,string macId,byte[] richText)
        {
            QunID = qunID;
            sender_macId = macId;
            richTextData = richText;
        }
    }
}
