using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSkin.DirectUI;

namespace YellowEar
{
    /// <summary>
    /// ChatList项头像鼠标事件参数类型,存储了鼠标所在头像控件的父控件，即好友控件
    /// </summary>
    public class ChatListItemHeaderMouseEventArgs
    {
        public DuiBaseControl friendItem { get; set; }

        public ChatListItemHeaderMouseEventArgs(DuiBaseControl frienditem)
        {
            this.friendItem = frienditem;
        }
    }
    /// <summary>
    /// ChatList项鼠标双击事件参数类型
    /// </summary>
    public class ChatListItemClickEventArgs
    {
        /// <summary>
        /// ChatListBox中的好友项控件
        /// </summary>
        public DuiBaseControl Friend { get; set; }

        public ChatListItemClickEventArgs(DuiBaseControl friend)
        {
            this.Friend = friend;
        }

    }
}
