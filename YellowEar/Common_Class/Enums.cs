using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace YellowEar
{
    public enum MessageType
    {
        None,
        Command,
        RichText,
        File
    }
    public enum MessageCommandWord
    {
        None,
        Online,
        OnlineBack,
        Refresh,
        RefreshBack,
        UpdateInfo,
        Heartbeat,
        WindowShake,
        Offline,
        QunInvite,
        QunEnter,
        QunRefresh,
        QunRefreshBack,
        QunInfoUpdate,
        QunDelete,
        QunQuit

    }
    public enum ChatType
    {
        None,
        One,
        Qun
    }
    public enum MessageSendType
    {
        None,
        Single,
        Start,
        Sending,
        End
    }
    public enum FriendState
    {
        None,
        Online,
        Leave,
        Busy,
        Offline
    }
}