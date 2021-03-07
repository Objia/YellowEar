using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSkin.Controls;
using DSkin.DirectUI;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;
using System.IO;
using System.Data;
using System.Net;

namespace YellowEar
{
    public partial class ChatListBox : DSkinListBox
    {
        public frmMain frmmain;
        public ChatListBox()
        {
            InitializeComponent();
        }

        public ChatListBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// 用于操作数据库
        /// </summary>
        public SqliteHelper Sqlite { get; set; }

        /// <summary>
        /// 选中的好友项ID（没有选中项时为-1）
        /// </summary>
        public int ItemSelectedID = -1;
        /// <summary>
        /// 默认字体
        /// </summary>
        private Font _font = new Font("微软雅黑", 9.3F, FontStyle.Regular, GraphicsUnit.Point, (byte)134);

        /// <summary>
        /// 是否显示小头像
        /// </summary>
        private bool _isSmallHead = false;
        /// <summary>
        /// 是否显示小头像
        /// </summary>
        public bool IsSmallHead
        {
            get { return _isSmallHead; }
            set { _isSmallHead = value; }
        }

        /// <summary>
        /// 分组项鼠标进入时的背景色
        /// </summary>
        private Color _groupMouseEnterBackColor = Color.FromArgb(100, 170, 253, 211);
        public Color GroupMouseEnterBackColor
        {
            get { return _groupMouseEnterBackColor; }
            set { _groupMouseEnterBackColor = value; }
        }

        /// <summary>
        /// 分组项鼠标离开时的背景色
        /// </summary>
        private Color _groupMouseLeaveBackeColor = Color.FromArgb(10, 192, 255, 192);
        public Color GroupMouseLeaveBackColor
        {
            get { return _groupMouseLeaveBackeColor; }
            set { _groupMouseLeaveBackeColor = value; }
        }

        /// <summary>
        /// 好友项正常背景色
        /// </summary>
        private Color _itemNomalBackColor = Color.Transparent;
        public Color ItemNomalBackColor
        {
            get { return _itemNomalBackColor; }
            set { _itemNomalBackColor = value; }
        }

        /// <summary>
        /// 好友项鼠标移动时的背景色
        /// </summary>
        private Color _itemMouseEnterBackColor = Color.FromArgb(120, 252, 240, 193);
        public Color ItemMouseEnterBackColor
        {
            get { return _itemMouseEnterBackColor; }
            set { _itemMouseEnterBackColor = value; }
        }

        /// <summary>
        /// 好友项选中时的背景色
        /// </summary>
        private Color _itemSelectedBackColor = Color.FromArgb(255, 252, 240, 193);
        public Color ItemSelectedBackColor
        {
            get { return _itemSelectedBackColor; }
            set { _itemSelectedBackColor = value; }
        }


        /// <summary>
        /// ChatList项头像鼠标事件委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">存储了头像所在的父控件</param>
        public delegate void ChatListItemHeaderMouseEventHandler(object sender, ChatListItemHeaderMouseEventArgs e);
        /// <summary>
        /// ChatList项鼠标双击事件委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="es"></param>
        public delegate void ChatListItemClickEventHandler(object sender, ChatListItemClickEventArgs e, MouseEventArgs es);
        [Description("鼠标双击子项时发生"),Category("自定义")]
        public event ChatListItemClickEventHandler DoubleClickItem;
        [Description("鼠标进入子项头像时发生"), Category("自定义")]
        public event ChatListItemHeaderMouseEventHandler MouseEnterHeader;
        [Description("鼠标离开子项头像时发生"), Category("自定义")]
        public event ChatListItemHeaderMouseEventHandler MouseLeaveHeader;

        /// <summary>
        /// 初始化好友列表，主要是添加“未分组好友”和“自己”两个分组和一个“自己”好友项,这三个项是固定位置
        /// 如果数据库中存在好友信息，则添加好友项，数据库中的好友项均为离线状态
        /// </summary>
        /// <param name="self"></param>
        public void InitialList(Self_Info self)
        {
            //添加“未分组好”分组项
            string _gpName = "    未分组好友" + string.Format("{0}/{1}", 0, 0);
            DuiLabel groupLabel = CreateDuiLabel(_gpName, _font, new Size(this.Width, 25), new Point(0, 0), false);
            groupLabel.TextRenderMode = TextRenderingHint.AntiAliasGridFit;
            groupLabel.TextAlign = ContentAlignment.TopLeft;
            groupLabel.Font = new Font("微软雅黑", 9.3F);
            groupLabel.BackgroundImageLayout = ImageLayout.None;
            groupLabel.BackColor = GroupMouseLeaveBackColor;
            groupLabel.BackgroundImage = Properties.Resources.groupbackimage_close;
            groupLabel.Name = this.Items.Count.ToString();//使用id号当名称，既确保了唯一性，也方便获取id号
            groupLabel.MouseClick += GroupMouseClick;
            groupLabel.MouseEnter += GroupMouseEnter;
            groupLabel.MouseLeave += GroupMouseLeave;
            groupLabel.ContextMenuStrip = cmsChatListGroup;
            GroupInformation _gpInfo = new GroupInformation();
            _gpInfo.GroupName = "未分组好友";
            _gpInfo.ItemsCount = 0;
            _gpInfo.OnLineCount = 0;
            _gpInfo.OpenOrClose = false;
            groupLabel.Tag = _gpInfo;
            this.Items.Add(groupLabel);

            //添加“自己”分组项
            _gpName = "    自己" + string.Format("{0}/{1}", 1, 1);
            groupLabel = CreateDuiLabel(_gpName, _font, new Size(this.Width, 25), new Point(0, 0), false);
            groupLabel.TextRenderMode = TextRenderingHint.AntiAliasGridFit;
            groupLabel.TextAlign = ContentAlignment.TopLeft;
            groupLabel.Font = new Font("微软雅黑", 9.3F);
            groupLabel.BackgroundImageLayout = ImageLayout.None;
            groupLabel.BackColor = GroupMouseLeaveBackColor;
            groupLabel.BackgroundImage = Properties.Resources.groupbackimage_close;
            groupLabel.Name = this.Items.Count.ToString();//使用id号当名称，既确保了唯一性，也方便获取id号
            groupLabel.MouseClick += GroupMouseClick;
            groupLabel.MouseEnter += GroupMouseEnter;
            groupLabel.MouseLeave += GroupMouseLeave;
            groupLabel.ContextMenuStrip = cmsChatListGroup;
            _gpInfo = new GroupInformation();
            _gpInfo.GroupName = "自己";
            _gpInfo.ItemsCount = 1;
            _gpInfo.OnLineCount = 1;
            _gpInfo.OpenOrClose = false;
            groupLabel.Tag = _gpInfo;
            this.Items.Add(groupLabel);

            //添加“自己”好友项
            DuiLabel lblName;
            if(self.MarkName=="")
            {
                lblName = IsSmallHead
                    ? CreateDuiLabel(string.Format("{0}", self.NickName), _font,
                    new Size(this.Width - 55, 20), new Point(40, 8), false)
                    : CreateDuiLabel(string.Format("{0}", self.NickName), _font,
                    new Size(this.Width - 85, 20), new Point(55, 8), false);
            }
            else
            {
                lblName = IsSmallHead
                    ? CreateDuiLabel(string.Format("{0}  ({1})", self.NickName, self.MarkName), _font,
                    new Size(this.Width - 55, 20), new Point(40, 8), false)
                    : CreateDuiLabel(string.Format("{0}  ({1})", self.NickName, self.MarkName), _font,
                    new Size(this.Width - 85, 20), new Point(55, 8), false);
            }

            DuiLabel lblSign = IsSmallHead
                ? CreateDuiLabel(self.Sign, _font, new Size(this.Width - 55, 20), new Point(40, 30), false)
                : CreateDuiLabel(self.Sign, _font, new Size(this.Width - 85, 20), new Point(55, 30), false);
            lblSign.ForeColor = Color.FromArgb(60, 60, 60);

            DuiPictureBox picHead = CreateDuiPictureBox(self.HeadImg == null ? Properties.Resources.YellowEar : self.HeadImg,
                self.State,
                ImageLayout.Stretch, Cursors.Default,
                IsSmallHead ? new Size(25, 25) : new Size(45, 45),
                new Point(5, 5), true);
            picHead.BackColor = Color.White;
            DuiBaseControl item = new DuiBaseControl();
            item.Tag = self;
            item.BackColor = ItemNomalBackColor;
            item.Size = new Size(this.Width-10, IsSmallHead ? 30 : 55);
            item.MouseClick += FriendItemMouseClick;
            item.MouseDoubleClick += FriendItemMouseDoubleClick;
            item.MouseEnter += FriendItemMouseEnter;
            item.MouseLeave += FriendItemMouseLeave;
            item.ContextMenuStrip = cmsChatListFriend;
            item.Controls.Add(picHead);
            item.Controls.Add(lblName);
            item.Controls.Add(lblSign);
            item.Name = this.Items.Count.ToString();
            item.Visible=false;
            this.Items.Add(item);


            //添加数据库中已经存在的分组（自己和未分组好友两个分组是默认的，不存数据库）
            string sqlstr1 = "SELECT * FROM Groups";
            DataTable group_result = Sqlite.ExecuteDataTable(sqlstr1, null);
            if(group_result!=null && group_result.Rows.Count>0)
            {
                for(int i=0;i<group_result.Rows.Count;i++)
                {
                    GroupInformation group_in_database = new GroupInformation((string)group_result.Rows[i][1], (string)group_result.Rows[i][2]);
                    AddGroup(group_in_database);
                }
            }
            //添加数据库中已经存在的好友
            string sqlstr2 = "SELECT * FROM Friends";
            DataTable result = Sqlite.ExecuteDataTable(sqlstr2, null);
            if (result!=null&&result.Rows.Count>0)
            {
                for(int i=0;i<result.Rows.Count;i++)
                {
                    Friend_Info friend_in_database = new Friend_Info();
                    friend_in_database.MacId = result.Rows[i][1]==DBNull.Value?null:(string)result.Rows[i][1];
                    friend_in_database.MarkName = result.Rows[i][2]==DBNull.Value?null :(string)result.Rows[i][2];
                    friend_in_database.NickName = result.Rows[i][3]==DBNull.Value?null:(string)result.Rows[i][3];
                    friend_in_database.Sign = result.Rows[i][4]==DBNull.Value?null:(string)result.Rows[i][4];
                    if(result.Rows[i][5]!=DBNull.Value)
                    {
                        friend_in_database.HeadImg = (Bitmap)Image.FromStream(new MemoryStream((byte[])result.Rows[i][5]));
                    }
                    else
                    {
                        friend_in_database.HeadImg = null;
                    }
                    friend_in_database.Ip = result.Rows[i][6]==DBNull.Value?null:IPAddress.Parse((string)result.Rows[i][6]);
                    friend_in_database.Port = result.Rows[i][7]==DBNull.Value?-1:Convert.ToInt32(result.Rows[i][7]);
                    friend_in_database.GroupId = result.Rows[i][8]==DBNull.Value? null : (string)result.Rows[i][8];
                    friend_in_database.State = FriendState.Offline;
                    AddChatItem(friend_in_database);
                }
            }
        }

        /// <summary>
        /// 在好友列表中添加一个分组,此函数不（列表项第一个分组和最后一个分组固定为“未分组好友”和“自己”，新添加的好友在中间）
        /// </summary>
        /// <param name="gpName">分组名称</param>
        /// <param name="itemsCount">组内总人数</param>
        /// <param name="open_close">展开或收缩</param>
        /// <param name="onlineCount">在线人数</param>
        /// <returns>返回创建的分组信息</returns>
        private GroupInformation AddGroup(string gpName)
        {
            string _gpName = "    " + gpName + string.Format("{0}/{1}", 0, 0);
            DuiLabel groupLabel = CreateDuiLabel(_gpName, _font, new Size(this.Width, 25), new Point(0, 0), false);
            groupLabel.TextRenderMode = TextRenderingHint.AntiAliasGridFit;
            groupLabel.TextAlign = ContentAlignment.TopLeft;
            groupLabel.Font = new Font("微软雅黑", 9.3F);
            groupLabel.BackgroundImageLayout = ImageLayout.None;
            groupLabel.BackColor = GroupMouseLeaveBackColor;
            groupLabel.BackgroundImage = Properties.Resources.groupbackimage_close;
            groupLabel.MouseClick += GroupMouseClick;
            groupLabel.MouseEnter += GroupMouseEnter;
            groupLabel.MouseLeave += GroupMouseLeave;
            groupLabel.ContextMenuStrip = cmsChatListGroup;
            int insertIndex = this.Items.Count - 2;
            groupLabel.Name = insertIndex.ToString();//使用索引号当名称，既确保了唯一性，也方便获取索引号
            GroupInformation _gpInfo = new GroupInformation();
            _gpInfo.GroupName = gpName;
            _gpInfo.ItemsCount = 0;
            _gpInfo.OnLineCount = 0;
            _gpInfo.OpenOrClose = false;
            groupLabel.Tag = _gpInfo;
            this.Items.Insert(insertIndex, groupLabel);
            for(int i=insertIndex+1;i<this.Items.Count;i++)
            {
                this.Items[i].Name = i.ToString();
            }
            this.LayoutContent();
            return _gpInfo;
        }
        /// <summary>
        /// 从分组类中创建分组，与另一个重载函数的区别在于该函数会创建指定groupID的分组,创建数据库已有的分组时用此函数
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        private void AddGroup(GroupInformation group)
        {
            string _gpName = "    " + group.GroupName + string.Format("{0}/{1}", 0, 0);
            DuiLabel groupLabel = CreateDuiLabel(_gpName, _font, new Size(this.Width, 25), new Point(0, 0), false);
            groupLabel.TextRenderMode = TextRenderingHint.AntiAliasGridFit;
            groupLabel.TextAlign = ContentAlignment.TopLeft;
            groupLabel.Font = new Font("微软雅黑", 9.3F);
            groupLabel.BackgroundImageLayout = ImageLayout.None;
            groupLabel.BackColor = GroupMouseLeaveBackColor;
            groupLabel.BackgroundImage = Properties.Resources.groupbackimage_close;
            groupLabel.MouseClick += GroupMouseClick;
            groupLabel.MouseEnter += GroupMouseEnter;
            groupLabel.MouseLeave += GroupMouseLeave;
            groupLabel.ContextMenuStrip = cmsChatListGroup;
            int insertIndex = this.Items.Count - 2;
            groupLabel.Name = insertIndex.ToString();//使用索引号当名称，既确保了唯一性，也方便获取索引号
            groupLabel.Tag = group;
            this.Items.Insert(insertIndex, groupLabel);
            for (int i = insertIndex + 1; i < this.Items.Count; i++)
            {
                this.Items[i].Name = i.ToString();
            }
            this.LayoutContent();
        }
        /// <summary>
        /// 创建一个好友项控件,如未指定分组，则固定添加到未分组好友中的最后一个位置
        /// </summary>
        /// <param name="friend">好友信息类</param>
        /// <returns></returns>
        public void AddChatItem(Friend_Info friend)
        {
            DuiLabel lblName;
            if(friend.MarkName=="")
            {
                lblName = IsSmallHead
                    ? CreateDuiLabel(string.Format("{0}", friend.NickName), _font,
                    new Size(this.Width - 55, 20), new Point(40, 8), false)
                    : CreateDuiLabel(string.Format("{0}", friend.NickName), _font,
                    new Size(this.Width - 85, 20), new Point(55, 8), false);
            }
            else
            {
                lblName = IsSmallHead
                    ? CreateDuiLabel(string.Format("{0}  ({1})", friend.NickName, friend.MarkName), _font,
                    new Size(this.Width - 55, 20), new Point(40, 8), false)
                    : CreateDuiLabel(string.Format("{0}  ({1})", friend.NickName, friend.MarkName), _font,
                    new Size(this.Width - 85, 20), new Point(55, 8), false);
            }

            DuiLabel lblSign = IsSmallHead
                ? CreateDuiLabel(friend.Sign, _font, new Size(this.Width - 55, 20), new Point(40, 30), false)
                : CreateDuiLabel(friend.Sign, _font, new Size(this.Width - 85, 20), new Point(55, 30), false);
            lblSign.ForeColor = Color.FromArgb(60, 60, 60);

            DuiPictureBox picHead = CreateDuiPictureBox(friend.HeadImg == null ? Properties.Resources.YellowEar : friend.HeadImg,
                friend.State,
                ImageLayout.Stretch, Cursors.Default,
                IsSmallHead ? new Size(25, 25) : new Size(45, 45),
                new Point(5, 5), true);
            picHead.BackColor = Color.White;

            //容器
            DuiBaseControl chatitem = new DuiBaseControl();
            chatitem.Tag = friend;
            chatitem.BackColor = ItemNomalBackColor;
            chatitem.Size = new Size(this.Width-10, IsSmallHead ? 30 : 55);
            chatitem.MouseClick += FriendItemMouseClick;
            chatitem.MouseDoubleClick += FriendItemMouseDoubleClick;
            chatitem.MouseEnter += FriendItemMouseEnter;
            chatitem.MouseLeave += FriendItemMouseLeave;
            chatitem.ContextMenuStrip = cmsChatListFriend;
            chatitem.Controls.Add(picHead);
            chatitem.Controls.Add(lblName);
            chatitem.Controls.Add(lblSign);
            chatitem.Visible = false;
            //以下代码主要是在添加好友时判断将好友添加到哪个分组
            bool addFlag = false;
            if(friend.GroupId!=null)
            {
                int groupIndex = -1;
                foreach(var item in this.Items)
                {
                    if(item.GetType()==typeof(DuiLabel))
                    {
                        if(friend.GroupId == ((GroupInformation)(((DuiLabel)item).Tag)).GroupID)
                        {
                            groupIndex = Convert.ToInt32(((DuiLabel)item).Name);
                        }
                    }
                }
                if(groupIndex>0)
                {
                    int insertIndex = ((GroupInformation)(((DuiLabel)Items[groupIndex]).Tag)).ItemsCount + groupIndex+1;
                    chatitem.Name = insertIndex.ToString();
                    this.Items.Insert(insertIndex, chatitem);
                    for (int i = insertIndex + 1; i < this.Items.Count; i++)
                    {
                        this.Items[i].Name = i.ToString();
                    }
                    addFlag = true;
                }
            }
            if(addFlag==false)
            {
                int insertIndex= ((GroupInformation)(((DuiLabel)Items[0]).Tag)).ItemsCount + 1;
                chatitem.Name = insertIndex.ToString();
                this.Items.Insert(insertIndex, chatitem);
                for (int i = insertIndex + 1; i < this.Items.Count; i++)
                {
                    this.Items[i].Name = i.ToString();
                }
            }

            UpdateGroupCount();
            this.LayoutContent();
        }
        /// <summary>
        /// 创建一个DuiLabel控件
        /// </summary>
        /// <param name="text">控件显示文本</param>
        /// <param name="font">文本字体</param>
        /// <param name="size">控件大小</param>
        /// <param name="location">控件位置</param>
        /// <param name="isEvent">是否响应鼠标的Enter和Leave事件</param>
        /// <returns>返回创建的控件</returns>
        private DuiLabel CreateDuiLabel(string text,Font font,Size size,Point location,bool isEvent)
        {
            DuiLabel duilabel = new DuiLabel();
            duilabel.Text = text;
            duilabel.Font = font;
            duilabel.Size = size;
            duilabel.Location = location;
            duilabel.TextRenderMode = TextRenderingHint.AntiAliasGridFit;
            if(isEvent)
            {
                duilabel.MouseEnter += ControlMouseEnter;
                duilabel.MouseLeave += ControlMouseLeave;
            }
            return duilabel;
        }
        /// <summary>
        /// 鼠标进入控件时高亮显示边框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlMouseEnter(object sender,MouseEventArgs e)
        {
            ((DuiBaseControl)sender).Borders.AllColor = Color.FromArgb(40, Color.Black);
        }
        /// <summary>
        /// 鼠标离开控件时不显示边框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlMouseLeave(object sender,EventArgs e)
        {
            ((DuiBaseControl)sender).Borders.AllColor = Color.Transparent;
        }
        /// <summary>
        /// 分组项鼠标点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupMouseClick(object sender,DuiMouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            {
                GroupInformation _gpInfo = (GroupInformation)((DuiLabel)sender).Tag;
                int id = Convert.ToInt32(((DuiLabel)sender).Name);
                if (_gpInfo.OpenOrClose == true)
                {
                    _gpInfo.OpenOrClose = false;
                    ((DuiLabel)sender).Tag = _gpInfo;
                    ((DuiLabel)sender).BackgroundImage = Properties.Resources.groupbackimage_close;
                    for (int i = id + 1; i <= id + _gpInfo.ItemsCount; i++)
                    {
                        try
                        {
                            this.Items[i].Visible = false;
                        }
                        catch
                        { }
                    }
                }
                else
                {
                    _gpInfo.OpenOrClose = true;
                    ((DuiLabel)sender).Tag = _gpInfo;
                    ((DuiLabel)sender).BackgroundImage = Properties.Resources.groupbackimage_open;
                    for (int i = id + 1; i <= id + _gpInfo.ItemsCount; i++)
                    {
                        try
                        {
                            this.Items[i].Visible = true;
                        }
                        catch
                        { }
                    }
                }
                this.LayoutContent();
            }
        }
        /// <summary>
        /// 分组项鼠标进入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupMouseEnter(object sender,MouseEventArgs e)
        {
            ((DuiLabel)sender).BackColor = GroupMouseEnterBackColor;
        }
        /// <summary>
        /// 分组项鼠标离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupMouseLeave(object sender, EventArgs e)
        {
            ((DuiLabel)sender).BackColor = GroupMouseLeaveBackColor;
        }
        /// <summary>
        /// 创建一个DuiPictureBox控件
        /// </summary>
        /// <param name="bitmap">控件背景图片</param>
        /// <param name="layout">控件背景图片布局样式</param>
        /// <param name="cursor">鼠标滑过控件的指针样式</param>
        /// <param name="size">控件大小</param>
        /// <param name="location">控件位置</param>
        /// <param name="isEvent">鼠标滑过控件时是否有Enter和Leave事件</param>
        /// <returns>返回创建的控件</returns>
        private DuiPictureBox CreateDuiPictureBox(Bitmap bitmap,FriendState state, ImageLayout layout,Cursor cursor,Size size,Point location,bool isEvent)
        {
            DuiPictureBox picturebox = new DuiPictureBox();
            picturebox.BackColor = Color.Transparent;
            picturebox.BackgroundImage = bitmap;
            picturebox.BackgroundImageLayout = layout;           
            switch (state)
            {
                case FriendState.Busy:
                    {
                        picturebox.Image = Properties.Resources.busy;
                       
                        break;
                    }
                case FriendState.Leave:
                    {
                        picturebox.Image = Properties.Resources.leave;
                        break;
                    }
                case FriendState.Offline:
                    {
                        picturebox.Image = null;
                        picturebox.BackgroundImage = Properties.Resources.YellowEar_Offline;
                        break;
                    }
                case FriendState.Online:
                    {
                        picturebox.Image = null;
                        break;
                    }
                default:
                    break;
            }
            picturebox.SizeMode = PictureBoxSizeMode.Zoom;
            picturebox.Cursor = cursor;
            picturebox.Size = size;
            picturebox.Location = location;
            if(isEvent)
            {
                picturebox.MouseEnter += FriendHeadControl_OnMouseEnter;
                picturebox.MouseLeave += FriendHeadControl_OnMouseLeave;
            }
            return picturebox;
        }
        /// <summary>
        /// 触发鼠标进入头像事件时，调用自定义事件委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void FriendHeadControl_OnMouseEnter(object sender,MouseEventArgs e)
        {
            if(MouseEnterHeader!=null)
            {
                MouseEnterHeader(this, new ChatListItemHeaderMouseEventArgs((DuiBaseControl)(((DuiBaseControl)sender).Parent)));
            }
        }
        /// <summary>
        /// 触发鼠标离开头像事件时，调用自定义事件委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void FriendHeadControl_OnMouseLeave(object sender,EventArgs e)
        {
            if(MouseLeaveHeader!=null)
            {
                MouseLeaveHeader(this, new ChatListItemHeaderMouseEventArgs((DuiBaseControl)((DuiBaseControl)sender).Parent));
            }
        }
        /// <summary>
        /// 好友项点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FriendItemMouseClick(object sender,MouseEventArgs e)
        {
            //当前已经存在选中好友项，先恢复选中好友项外观
            if(ItemSelectedID>0)
            {
                this.Items[ItemSelectedID].BackColor = ItemNomalBackColor;
                if(IsSmallHead)
                {
                    this.Items[ItemSelectedID].Height = 30;
                    this.Items[ItemSelectedID].Controls[0].Size = new Size(25, 25);//头像
                    this.Items[ItemSelectedID].Controls[1].Location = new Point(40, 8);//名称
                    this.Items[ItemSelectedID].Controls[2].Location = new Point(40, 30);//个人签名
                }
            }
            ItemSelectedID = Convert.ToInt32(((DuiBaseControl)sender).Name);
            this.Items[ItemSelectedID].BackColor = ItemSelectedBackColor;
            if(IsSmallHead)
            {
                this.Items[ItemSelectedID].Height = 55;
                this.Items[ItemSelectedID].Controls[0].Size = new Size(45, 45);//头像
                this.Items[ItemSelectedID].Controls[1].Location = new Point(60, 8);//名称
                this.Items[ItemSelectedID].Controls[2].Location = new Point(60, 30);//个人签名
            }
            this.LayoutContent();
        }
        /// <summary>
        /// 好友项双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FriendItemMouseDoubleClick(object sender,MouseEventArgs e)
        {
            if(DoubleClickItem!=null)
            {
                //确保点击的不是自己列表好友项
                if (((DuiBaseControl)sender).Tag.GetType() != typeof(Self_Info))
                {
                    DoubleClickItem(sender, new ChatListItemClickEventArgs((DuiBaseControl)sender), e);
                }    
            }
        }
        /// <summary>
        /// 好友项鼠标进入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FriendItemMouseEnter(object sender,MouseEventArgs e)
        {
            if(ItemSelectedID!=Convert.ToInt32(((DuiBaseControl)sender).Name))
            {
                ((DuiBaseControl)sender).BackColor = ItemMouseEnterBackColor;
            }
        }
        /// <summary>
        /// 好友项鼠标离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FriendItemMouseLeave(object sender,EventArgs e)
        {
            if (ItemSelectedID != Convert.ToInt32(((DuiBaseControl)sender).Name))
            {
                ((DuiBaseControl)sender).BackColor = ItemNomalBackColor;
            }
        }
        /// <summary>
        /// ChatListBox控件改变大小时，相应改变内部控件大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ChatListBox_SizeChanged(object sender,EventArgs e)
        {
            foreach (DuiBaseControl item in this.Items)
            {
                item.Width = this.Width - 10;
            }
            this.LayoutContent();
        }

        /// <summary>
        /// 更新好友列表信息，并存到数据库,会根据情况相应更改所在分组信息
        /// </summary>
        /// <param name="chatitem">现在好友列表中需要更新信息的项</param>
        /// <param name="friendinfo">需要写入好友项的最新的信息</param>
        public void UpdateFriendInformation_InListAndDatabase(DuiBaseControl chatitem, Friend_Info friendinfo)
        {
            #region 更新好友列表信息和分组信息
            Friend_Info chatItemInfo = (Friend_Info)chatitem.Tag;
            chatItemInfo.HeadImg = friendinfo.HeadImg;
            ((DuiPictureBox)chatitem.Controls[0]).Image = chatItemInfo.HeadImg==null?Properties.Resources.YellowEar: chatItemInfo.HeadImg;
            if(friendinfo.State!=FriendState.None)
            {
                chatItemInfo.State = friendinfo.State;
                switch(chatItemInfo.State)
                {
                    case FriendState.Busy:
                        {
                            ((DuiPictureBox)chatitem.Controls[0]).Image = Properties.Resources.busy;
                            break;
                        }
                    case FriendState.Leave:
                        {
                            ((DuiPictureBox)chatitem.Controls[0]).Image = Properties.Resources.leave;
                            break;
                        }
                    case FriendState.Offline:
                        {
                            ((DuiPictureBox)chatitem.Controls[0]).Image = null;
                            ((DuiPictureBox)chatitem.Controls[0]).BackgroundImage = Properties.Resources.YellowEar_Offline;                     
                            break;
                        }
                    case FriendState.Online:
                        {
                            ((DuiPictureBox)chatitem.Controls[0]).Image = null;
                            ((DuiPictureBox)chatitem.Controls[0]).BackgroundImage = (friendinfo.HeadImg == null) ? Properties.Resources.YellowEar:friendinfo.HeadImg;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            if(friendinfo.NickName!=null)
            {
                chatItemInfo.NickName = friendinfo.NickName;
                if(chatItemInfo.MarkName==""||chatItemInfo.MarkName==null)
                {
                    ((DuiLabel)chatitem.Controls[1]).Text = string.Format("{0}", chatItemInfo.NickName);
                }
                else
                {
                    ((DuiLabel)chatitem.Controls[1]).Text = string.Format("{0}  ({1})", chatItemInfo.NickName, chatItemInfo.MarkName);
                }
            }
            if(friendinfo.Sign!=null&&friendinfo.Sign!="")
            {
                chatItemInfo.Sign = friendinfo.Sign;
                ((DuiLabel)chatitem.Controls[2]).Text = chatItemInfo.Sign;
            }
            if(chatItemInfo.Ip.ToString()!=friendinfo.Ip.ToString())
            {
                chatItemInfo.Ip = friendinfo.Ip;
            }
            if(chatItemInfo.Port!=friendinfo.Port)
            {
                chatItemInfo.Port = friendinfo.Port;
            }
            chatitem.Tag = chatItemInfo;
            this.LayoutContent();
            #endregion

            #region 更新数据库信息
            Dictionary<string, object> update_info = new Dictionary<string, object>();
            update_info.Add("MarkName", chatItemInfo.MarkName);
            update_info.Add("NickName", chatItemInfo.NickName);
            update_info.Add("Sign", chatItemInfo.Sign);
            if(chatItemInfo.HeadImg!=null)
            {
                MemoryStream ms = new MemoryStream();
                chatItemInfo.HeadImg.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                update_info.Add("HeadImg", ms.GetBuffer());
            }
            else
            {
                update_info.Add("HeadImg", null);
            }
            update_info.Add("Ip", chatItemInfo.Ip.ToString());
            update_info.Add("Port", chatItemInfo.Port);
            update_info.Add("GroupId", chatItemInfo.GroupId);
            KeyValuePair<string, object> where_condition = new KeyValuePair<string, object>("MacId", chatItemInfo.MacId);
            try
            {
                Sqlite.Update("Friends", update_info, where_condition);
            }
            catch(Exception e)
            {
                MessageBox.Show("错误位置：UpdateFriendInformation_InListAndDatabase()。" + e.Message);
            }
            #endregion
        }
        /// <summary>
        /// 添加好友到列表，并查询数据库，如果数据库中没有此好友，则添加到数据库
        /// </summary>
        /// <param name="friend"></param>
        public void AddFriend_InListAndDatabase(Friend_Info friend)
        {
            string sql = "SELECT GroupId FROM Friends WHERE MacId=@id";
            DataTable result = Sqlite.ExecuteDataTable(sql, new object[] { friend.MacId });
            if(result.Rows.Count>0)
            {
                friend.GroupId = (string)result.Rows[0][0];
                Friend_Info.UpdateFrindIntoDatabase(Sqlite, friend);
            }
            else
            {
                Friend_Info.InsertFriendIntoDatabase(Sqlite, friend);
            }
            AddChatItem(friend);

        }

        /// <summary>
        /// 在添加好友分组到列表和数据库
        /// </summary>
        /// <param name="gpName"></param>
        public void AddGroup_InListAdnDatabase(string gpName)
        {
            GroupInformation group = AddGroup(gpName);
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("_id", null);
            data.Add("GroupId", group.GroupID);
            data.Add("groupName", group.GroupName);
            try
            {
                Sqlite.Insert("Groups", data);
            }
            catch(Exception e)
            {
                MessageBox.Show("错误位置：AddGroup_InListAdnDatabase()。" + e.Message);
            }
        }

        /// <summary>
        /// 更新好友分组信息到列表和数据库(暂时只支持更改分组名称)
        /// </summary>
        /// <param name="group">需要更新信息的分组控件</param>
        /// <param name="nametochanged">新的名称</param>
        public void UpdateGroupInformatin_InListAndDatabase(DuiLabel group,string nametochanged)
        {
            GroupInformation gpInfo = (GroupInformation)group.Tag;
            gpInfo.GroupName = nametochanged;
            group.Text= "    "+ gpInfo.GroupName + string.Format("{0}/{1}", gpInfo.OnLineCount, gpInfo.ItemsCount);

            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("GroupName", gpInfo.GroupName);
            KeyValuePair<string, object> where = new KeyValuePair<string, object>("GroupId", gpInfo.GroupID);
            Sqlite.Update("Groups", data, where);
        }


        /// <summary>
        /// 当添加或移动好友时，重新计算分组人数
        /// </summary>
        private void UpdateGroupCount()
        {
            int i = 0;
            while(i<this.Items.Count)
            {
                int j = i+1;
                while(Items[j].GetType()==typeof(DuiBaseControl))
                {
                    j++;
                    if(j>=this.Items.Count)
                    {
                        break;
                    }
                }
                GroupInformation group = (GroupInformation)((DuiLabel)Items[i]).Tag;
                group.ItemsCount = j - i - 1;
                group.OnLineCount = j - i - 1;
                ((DuiLabel)Items[i]).Tag = group;
                ((DuiLabel)Items[i]).Text= "    " + group.GroupName + string.Format("{0}/{1}", group.OnLineCount, group.ItemsCount);
                i = j;
            }
        }

        /// <summary>
        /// 在好友列表中查找指定好友
        /// </summary>
        /// <param name="friend_macid"></param>
        /// <returns>若没有，则返回Null</returns>
        public DuiBaseControl FindFriend(string friend_macid)
        {
            foreach(var item in this.Items)
            {
                if(item.GetType()==typeof(DuiBaseControl))
                {
                    Friend_Info info = (Friend_Info)(((DuiBaseControl)item).Tag);
                    if (info.MacId==friend_macid)
                    {
                        return (DuiBaseControl)item;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 切换大小头像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiIsSmallHead_Click(object sender, EventArgs e)
        {
            _isSmallHead = (!_isSmallHead);
            foreach (var item in this.Items)
            {
                if (item.GetType() == typeof(DuiBaseControl))
                {
                    ((DuiBaseControl)item).Controls[0].Size = _isSmallHead ? new Size(25, 25) : new Size(45, 45);
                    ((DuiBaseControl)item).Controls[1].Size = _isSmallHead ? new Size(this.Width - 55, 20) : new Size(this.Width - 85, 20);
                    ((DuiBaseControl)item).Controls[1].Location = _isSmallHead ? new Point(40, 8) : new Point(55, 8);
                    ((DuiBaseControl)item).Controls[2].Size = _isSmallHead ? new Size(this.Width - 55, 20) : new Size(this.Width - 85, 20);
                    ((DuiBaseControl)item).Controls[2].Location = _isSmallHead ? new Point(40, 30) : new Point(55, 30);
                    ((DuiBaseControl)item).Size = new Size(this.Width - 10, _isSmallHead ? 30 : 55);
                }
            }
            this.LayoutContent();
        }

        private void tsmiRefreshList_Click(object sender,EventArgs e)
        {
            frmmain.BroadcastMessage(Serializer.SerializeBinary(new Friend_Info(frmmain.myselfinfo)), MessageCommandWord.Refresh, ChatType.One);
        }
    }
}
