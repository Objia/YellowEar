using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YellowEar
{
    /// <summary>
    /// 消息类型定义
    /// </summary>
    [Serializable]
    public class MessageEx
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        public string MsgID;
        /// <summary>
        /// 消息类型
        /// </summary>
        public MessageType msgType;
        /// <summary>
        /// 消息命令字
        /// </summary>
        public MessageCommandWord msgCmdWord;
        /// <summary>
        /// 聊天类型
        /// </summary>
        public ChatType chatType;
        /// <summary>
        /// 数据发送方式（单次发送或多次发送）
        /// </summary>
        public MessageSendType sendType;
        /// <summary>
        /// 消息携带的数据
        /// </summary>
        public byte[] Data;

        public MessageEx(MessageType msgtype,MessageCommandWord msgcmdword,ChatType chattype)
        {
            MsgID = Guid.NewGuid().ToString();
            msgType = msgtype;
            msgCmdWord = msgcmdword;
            chatType = chattype;
        }
    }
}
