using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YellowEar
{
    /// <summary>
    /// ChatList控件中的分组类型
    /// </summary>
    public class GroupInformation
    {
        /// <summary>
        /// 好友分组的唯一ID标识号
        /// </summary>
        public string GroupID { get; set; }
        /// <summary>
        /// 好友分组名称
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// 分组内好友总数
        /// </summary>
        public int ItemsCount { get; set; }
        /// <summary>
        /// 分组内在线人数
        /// </summary>
        public int OnLineCount { get; set; }
        /// <summary>
        /// 展开收缩状态，true为展开，false为收缩
        /// </summary>
        public bool OpenOrClose { get; set; }

        public GroupInformation(string Id, string name)
        {
            GroupID = Id;
            GroupName = name;
        }
        public GroupInformation()
        {
            GroupID = Guid.NewGuid().ToString();
            GroupName = "未命名";
        }
    }
}
