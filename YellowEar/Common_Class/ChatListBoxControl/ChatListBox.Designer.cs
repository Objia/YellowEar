namespace YellowEar
{
    partial class ChatListBox
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cmsChatListFriend = new DSkin.Controls.DSkinContextMenuStrip();
            this.tsmiChatForm = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMarkname = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMoveToGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInfomation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInvisible = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteFriend = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsChatListGroup = new DSkin.Controls.DSkinContextMenuStrip();
            this.tsmiAddGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGroupRename = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiIsSmallHead = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRefreshList = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsChatListFriend.SuspendLayout();
            this.cmsChatListGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsChatListFriend
            // 
            this.cmsChatListFriend.Arrow = System.Drawing.Color.Black;
            this.cmsChatListFriend.Back = System.Drawing.Color.White;
            this.cmsChatListFriend.BackRadius = 4;
            this.cmsChatListFriend.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.cmsChatListFriend.CheckedImage = null;
            this.cmsChatListFriend.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cmsChatListFriend.Fore = System.Drawing.Color.Black;
            this.cmsChatListFriend.HoverFore = System.Drawing.Color.White;
            this.cmsChatListFriend.ItemAnamorphosis = true;
            this.cmsChatListFriend.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.cmsChatListFriend.ItemBorderShow = true;
            this.cmsChatListFriend.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.cmsChatListFriend.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.cmsChatListFriend.ItemRadius = 4;
            this.cmsChatListFriend.ItemRadiusStyle = DSkin.Common.RoundStyle.All;
            this.cmsChatListFriend.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiChatForm,
            this.tsmiMarkname,
            this.tsmiMoveToGroup,
            this.tsmiInfomation,
            this.tsmiInvisible,
            this.tsmiDeleteFriend});
            this.cmsChatListFriend.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.cmsChatListFriend.Name = "cmsChatListFriend";
            this.cmsChatListFriend.RadiusStyle = DSkin.Common.RoundStyle.All;
            this.cmsChatListFriend.ShowImageMargin = false;
            this.cmsChatListFriend.Size = new System.Drawing.Size(144, 148);
            this.cmsChatListFriend.SkinAllColor = true;
            this.cmsChatListFriend.TitleAnamorphosis = true;
            this.cmsChatListFriend.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.cmsChatListFriend.TitleRadius = 4;
            this.cmsChatListFriend.TitleRadiusStyle = DSkin.Common.RoundStyle.All;
            // 
            // tsmiChatForm
            // 
            this.tsmiChatForm.Name = "tsmiChatForm";
            this.tsmiChatForm.Size = new System.Drawing.Size(143, 24);
            this.tsmiChatForm.Text = "打开聊天窗口";
            // 
            // tsmiMarkname
            // 
            this.tsmiMarkname.Name = "tsmiMarkname";
            this.tsmiMarkname.Size = new System.Drawing.Size(143, 24);
            this.tsmiMarkname.Text = "修改备注";
            // 
            // tsmiMoveToGroup
            // 
            this.tsmiMoveToGroup.Name = "tsmiMoveToGroup";
            this.tsmiMoveToGroup.Size = new System.Drawing.Size(143, 24);
            this.tsmiMoveToGroup.Text = "移动到分组";
            // 
            // tsmiInfomation
            // 
            this.tsmiInfomation.Name = "tsmiInfomation";
            this.tsmiInfomation.Size = new System.Drawing.Size(143, 24);
            this.tsmiInfomation.Text = "查看好友信息";
            // 
            // tsmiInvisible
            // 
            this.tsmiInvisible.Name = "tsmiInvisible";
            this.tsmiInvisible.Size = new System.Drawing.Size(143, 24);
            this.tsmiInvisible.Text = "对他隐身";
            // 
            // tsmiDeleteFriend
            // 
            this.tsmiDeleteFriend.Name = "tsmiDeleteFriend";
            this.tsmiDeleteFriend.Size = new System.Drawing.Size(143, 24);
            this.tsmiDeleteFriend.Text = "删除好友";
            // 
            // cmsChatListGroup
            // 
            this.cmsChatListGroup.Arrow = System.Drawing.Color.Black;
            this.cmsChatListGroup.Back = System.Drawing.Color.White;
            this.cmsChatListGroup.BackRadius = 4;
            this.cmsChatListGroup.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.cmsChatListGroup.CheckedImage = null;
            this.cmsChatListGroup.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cmsChatListGroup.Fore = System.Drawing.Color.Black;
            this.cmsChatListGroup.HoverFore = System.Drawing.Color.White;
            this.cmsChatListGroup.ItemAnamorphosis = true;
            this.cmsChatListGroup.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.cmsChatListGroup.ItemBorderShow = true;
            this.cmsChatListGroup.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.cmsChatListGroup.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.cmsChatListGroup.ItemRadius = 4;
            this.cmsChatListGroup.ItemRadiusStyle = DSkin.Common.RoundStyle.All;
            this.cmsChatListGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddGroup,
            this.tsmiDeleteGroup,
            this.tsmiGroupRename,
            this.tsSeparator1,
            this.tsmiIsSmallHead,
            this.tsmiRefreshList});
            this.cmsChatListGroup.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.cmsChatListGroup.Name = "cmsChatListGroup";
            this.cmsChatListGroup.RadiusStyle = DSkin.Common.RoundStyle.All;
            this.cmsChatListGroup.ShowImageMargin = false;
            this.cmsChatListGroup.Size = new System.Drawing.Size(150, 130);
            this.cmsChatListGroup.SkinAllColor = true;
            this.cmsChatListGroup.TitleAnamorphosis = true;
            this.cmsChatListGroup.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.cmsChatListGroup.TitleRadius = 4;
            this.cmsChatListGroup.TitleRadiusStyle = DSkin.Common.RoundStyle.All;
            // 
            // tsmiAddGroup
            // 
            this.tsmiAddGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsmiAddGroup.Name = "tsmiAddGroup";
            this.tsmiAddGroup.Size = new System.Drawing.Size(149, 24);
            this.tsmiAddGroup.Text = "添加分组";
            // 
            // tsmiDeleteGroup
            // 
            this.tsmiDeleteGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsmiDeleteGroup.Name = "tsmiDeleteGroup";
            this.tsmiDeleteGroup.Size = new System.Drawing.Size(149, 24);
            this.tsmiDeleteGroup.Text = "删除分组";
            // 
            // tsmiGroupRename
            // 
            this.tsmiGroupRename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsmiGroupRename.Name = "tsmiGroupRename";
            this.tsmiGroupRename.Size = new System.Drawing.Size(149, 24);
            this.tsmiGroupRename.Text = "重命名";
            // 
            // tsSeparator1
            // 
            this.tsSeparator1.Name = "tsSeparator1";
            this.tsSeparator1.Size = new System.Drawing.Size(146, 6);
            // 
            // tsmiIsSmallHead
            // 
            this.tsmiIsSmallHead.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsmiIsSmallHead.Name = "tsmiIsSmallHead";
            this.tsmiIsSmallHead.Size = new System.Drawing.Size(149, 24);
            this.tsmiIsSmallHead.Text = "显示大/小头像";
            // 
            // tsmiRefreshList
            // 
            this.tsmiRefreshList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsmiRefreshList.Name = "tsmiRefreshList";
            this.tsmiRefreshList.Size = new System.Drawing.Size(149, 24);
            this.tsmiRefreshList.Text = "刷新好友列表";
            this.tsmiRefreshList.Click += tsmiRefreshList_Click;
            this.cmsChatListFriend.ResumeLayout(false);
            this.cmsChatListGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DSkin.Controls.DSkinContextMenuStrip cmsChatListFriend;
        private System.Windows.Forms.ToolStripMenuItem tsmiChatForm;
        private System.Windows.Forms.ToolStripMenuItem tsmiMarkname;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoveToGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmiInfomation;
        private System.Windows.Forms.ToolStripMenuItem tsmiInvisible;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteFriend;
        private DSkin.Controls.DSkinContextMenuStrip cmsChatListGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmiGroupRename;
        private System.Windows.Forms.ToolStripSeparator tsSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiIsSmallHead;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefreshList;
    }
}
