namespace YellowEar
{
    partial class frmMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.picMin = new System.Windows.Forms.PictureBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.pnlHeader = new DSkin.Controls.DSkinPanel();
            this.lblIP = new DSkin.Controls.DSkinLabel();
            this.dSkinBaseControl1 = new DSkin.Controls.DSkinBaseControl();
            this.duiTextBoxSign = new DSkin.DirectUI.DuiTextBox();
            this.lblNickName = new DSkin.Controls.DSkinLabel();
            this.picHeader = new DSkin.Controls.DSkinPictureBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.tabBody = new System.Windows.Forms.TabControl();
            this.tabFriends = new System.Windows.Forms.TabPage();
            this.tabGroups = new System.Windows.Forms.TabPage();
            this.timerHidden = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsNotify = new DSkin.Controls.DSkinContextMenuStrip();
            this.tsmiBusy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLeave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenCloseSound = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenCloseHeadImgTwinkle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tooltip1 = new DSkin.Controls.DSkinToolTip(this.components);
            this.timerIconTwinkle = new System.Windows.Forms.Timer(this.components);
            this.chatlistFriends = new YellowEar.ChatListBox(this.components);
            this.chatlistGroups = new YellowEar.ChatListBox(this.components);
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.tabBody.SuspendLayout();
            this.tabFriends.SuspendLayout();
            this.tabGroups.SuspendLayout();
            this.cmsNotify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chatlistFriends)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chatlistGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackgroundImage = global::YellowEar.Properties.Resources.pnlTopImage;
            this.pnlTop.Controls.Add(this.picIcon);
            this.pnlTop.Controls.Add(this.picMin);
            this.pnlTop.Controls.Add(this.picClose);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(285, 19);
            this.pnlTop.TabIndex = 0;
            // 
            // picIcon
            // 
            this.picIcon.BackColor = System.Drawing.Color.Transparent;
            this.picIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.picIcon.Image = ((System.Drawing.Image)(resources.GetObject("picIcon.Image")));
            this.picIcon.Location = new System.Drawing.Point(0, 0);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(19, 19);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIcon.TabIndex = 2;
            this.picIcon.TabStop = false;
            // 
            // picMin
            // 
            this.picMin.Dock = System.Windows.Forms.DockStyle.Right;
            this.picMin.Image = global::YellowEar.Properties.Resources.minImage;
            this.picMin.Location = new System.Drawing.Point(232, 0);
            this.picMin.Name = "picMin";
            this.picMin.Size = new System.Drawing.Size(26, 19);
            this.picMin.TabIndex = 1;
            this.picMin.TabStop = false;
            this.picMin.Click += new System.EventHandler(this.picMin_Click);
            this.picMin.MouseEnter += new System.EventHandler(this.picMin_MouseEnter);
            this.picMin.MouseLeave += new System.EventHandler(this.picMin_MouseLeave);
            this.picMin.MouseHover += new System.EventHandler(this.picMin_MouseHover);
            // 
            // picClose
            // 
            this.picClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.picClose.Image = global::YellowEar.Properties.Resources.closeImage;
            this.picClose.Location = new System.Drawing.Point(258, 0);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(27, 19);
            this.picClose.TabIndex = 0;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            this.picClose.MouseEnter += new System.EventHandler(this.picClose_MouseEnter);
            this.picClose.MouseLeave += new System.EventHandler(this.picClose_MouseLeave);
            this.picClose.MouseHover += new System.EventHandler(this.picClose_MouseHover);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.BackgroundImage = global::YellowEar.Properties.Resources.pnlHeaderImage;
            this.pnlHeader.Controls.Add(this.lblIP);
            this.pnlHeader.Controls.Add(this.dSkinBaseControl1);
            this.pnlHeader.Controls.Add(this.lblNickName);
            this.pnlHeader.Controls.Add(this.picHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 19);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.RightBottom = ((System.Drawing.Image)(resources.GetObject("pnlHeader.RightBottom")));
            this.pnlHeader.Size = new System.Drawing.Size(285, 115);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblIP
            // 
            this.lblIP.Location = new System.Drawing.Point(101, 58);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(51, 14);
            this.lblIP.TabIndex = 3;
            this.lblIP.Text = "127.0.0.1";
            // 
            // dSkinBaseControl1
            // 
            this.dSkinBaseControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dSkinBaseControl1.DUIControls.Add(this.duiTextBoxSign);
            this.dSkinBaseControl1.Location = new System.Drawing.Point(0, 78);
            this.dSkinBaseControl1.Name = "dSkinBaseControl1";
            this.dSkinBaseControl1.Size = new System.Drawing.Size(285, 37);
            this.dSkinBaseControl1.TabIndex = 2;
            this.dSkinBaseControl1.Text = "dSkinBaseControl1";
            // 
            // duiTextBoxSign
            // 
            this.duiTextBoxSign.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.duiTextBoxSign.AutoHeight = true;
            this.duiTextBoxSign.AutoSize = false;
            this.duiTextBoxSign.BackColor = System.Drawing.Color.Transparent;
            this.duiTextBoxSign.Controls.Add(this.duiTextBoxSign.InnerScrollBar);
            this.duiTextBoxSign.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.duiTextBoxSign.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duiTextBoxSign.Location = new System.Drawing.Point(15, 9);
            this.duiTextBoxSign.Multiline = true;
            this.duiTextBoxSign.Name = "duiTextBoxSign";
            this.duiTextBoxSign.ShowScrollBar = false;
            this.duiTextBoxSign.Size = new System.Drawing.Size(255, 17);
            this.duiTextBoxSign.Text = "个人签名";
            this.duiTextBoxSign.TextRenderMode = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // 
            // lblNickName
            // 
            this.lblNickName.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNickName.Location = new System.Drawing.Point(101, 26);
            this.lblNickName.Name = "lblNickName";
            this.lblNickName.Size = new System.Drawing.Size(97, 28);
            this.lblNickName.TabIndex = 1;
            this.lblNickName.Text = "nickname";
            // 
            // picHeader
            // 
            this.picHeader.Image = global::YellowEar.Properties.Resources.YellowEar;
            this.picHeader.Images = new System.Drawing.Image[] {
        ((System.Drawing.Image)(global::YellowEar.Properties.Resources.YellowEar))};
            this.picHeader.Location = new System.Drawing.Point(23, 15);
            this.picHeader.Name = "picHeader";
            this.picHeader.Size = new System.Drawing.Size(60, 60);
            this.picHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHeader.TabIndex = 0;
            this.picHeader.Text = "dSkinPictureBox1";
            this.picHeader.DoubleClick += new System.EventHandler(this.picHeader_DoubleClick);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackgroundImage = global::YellowEar.Properties.Resources.pnlBottomImage;
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 538);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(285, 47);
            this.pnlBottom.TabIndex = 2;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.tabBody);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 134);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(285, 404);
            this.pnlBody.TabIndex = 3;
            // 
            // tabBody
            // 
            this.tabBody.Controls.Add(this.tabFriends);
            this.tabBody.Controls.Add(this.tabGroups);
            this.tabBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabBody.Location = new System.Drawing.Point(0, 0);
            this.tabBody.Name = "tabBody";
            this.tabBody.SelectedIndex = 0;
            this.tabBody.Size = new System.Drawing.Size(285, 404);
            this.tabBody.TabIndex = 0;
            // 
            // tabFriends
            // 
            this.tabFriends.Controls.Add(this.chatlistFriends);
            this.tabFriends.Location = new System.Drawing.Point(4, 22);
            this.tabFriends.Name = "tabFriends";
            this.tabFriends.Padding = new System.Windows.Forms.Padding(3);
            this.tabFriends.Size = new System.Drawing.Size(277, 378);
            this.tabFriends.TabIndex = 0;
            this.tabFriends.Text = "联系人";
            this.tabFriends.UseVisualStyleBackColor = true;
            // 
            // tabGroups
            // 
            this.tabGroups.Controls.Add(this.chatlistGroups);
            this.tabGroups.Location = new System.Drawing.Point(4, 22);
            this.tabGroups.Name = "tabGroups";
            this.tabGroups.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroups.Size = new System.Drawing.Size(277, 378);
            this.tabGroups.TabIndex = 1;
            this.tabGroups.Text = "群聊";
            this.tabGroups.UseVisualStyleBackColor = true;
            // 
            // timerHidden
            // 
            this.timerHidden.Enabled = true;
            this.timerHidden.Tick += new System.EventHandler(this.timerHidden_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.cmsNotify;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "YE\r\n声音：开启\r\n消息提示框：关闭\r\n会话框消息：任务栏头像是否闪动";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // cmsNotify
            // 
            this.cmsNotify.Arrow = System.Drawing.Color.Black;
            this.cmsNotify.Back = System.Drawing.Color.White;
            this.cmsNotify.BackRadius = 4;
            this.cmsNotify.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.cmsNotify.CheckedImage = null;
            this.cmsNotify.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cmsNotify.Fore = System.Drawing.Color.Black;
            this.cmsNotify.HoverFore = System.Drawing.Color.White;
            this.cmsNotify.ItemAnamorphosis = true;
            this.cmsNotify.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.cmsNotify.ItemBorderShow = true;
            this.cmsNotify.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.cmsNotify.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.cmsNotify.ItemRadius = 4;
            this.cmsNotify.ItemRadiusStyle = DSkin.Common.RoundStyle.All;
            this.cmsNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBusy,
            this.tsmiLeave,
            this.tsmiOpenCloseSound,
            this.tsmiOpenCloseHeadImgTwinkle,
            this.tsmiSetting,
            this.tsmiExit});
            this.cmsNotify.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.cmsNotify.Name = "cmsNotify";
            this.cmsNotify.RadiusStyle = DSkin.Common.RoundStyle.All;
            this.cmsNotify.Size = new System.Drawing.Size(169, 148);
            this.cmsNotify.SkinAllColor = true;
            this.cmsNotify.TitleAnamorphosis = true;
            this.cmsNotify.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.cmsNotify.TitleRadius = 4;
            this.cmsNotify.TitleRadiusStyle = DSkin.Common.RoundStyle.All;
            // 
            // tsmiBusy
            // 
            this.tsmiBusy.Name = "tsmiBusy";
            this.tsmiBusy.Size = new System.Drawing.Size(168, 24);
            this.tsmiBusy.Text = "忙碌";
            // 
            // tsmiLeave
            // 
            this.tsmiLeave.Name = "tsmiLeave";
            this.tsmiLeave.Size = new System.Drawing.Size(168, 24);
            this.tsmiLeave.Text = "离开";
            // 
            // tsmiOpenCloseSound
            // 
            this.tsmiOpenCloseSound.Name = "tsmiOpenCloseSound";
            this.tsmiOpenCloseSound.Size = new System.Drawing.Size(168, 24);
            this.tsmiOpenCloseSound.Text = "关闭声音";
            // 
            // tsmiOpenCloseHeadImgTwinkle
            // 
            this.tsmiOpenCloseHeadImgTwinkle.Name = "tsmiOpenCloseHeadImgTwinkle";
            this.tsmiOpenCloseHeadImgTwinkle.Size = new System.Drawing.Size(168, 24);
            this.tsmiOpenCloseHeadImgTwinkle.Text = "打开头像闪动";
            this.tsmiOpenCloseHeadImgTwinkle.Click += new System.EventHandler(this.tsmiOpenCloseHeadImgTwinkle_Click);
            // 
            // tsmiSetting
            // 
            this.tsmiSetting.Name = "tsmiSetting";
            this.tsmiSetting.Size = new System.Drawing.Size(168, 24);
            this.tsmiSetting.Text = "设置";
            this.tsmiSetting.Click += new System.EventHandler(this.tsmiSetting_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(168, 24);
            this.tsmiExit.Text = "退出程序";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tooltip1
            // 
            this.tooltip1.AutoPopDelay = 5000;
            this.tooltip1.InitialDelay = 500;
            this.tooltip1.OwnerDraw = true;
            this.tooltip1.ReshowDelay = 800;
            this.tooltip1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // timerIconTwinkle
            // 
            this.timerIconTwinkle.Interval = 500;
            this.timerIconTwinkle.Tick += new System.EventHandler(this.timerIconTwinkle_Tick);
            // 
            // chatlistFriends
            // 
            this.chatlistFriends.BackColor = System.Drawing.Color.Transparent;
            this.chatlistFriends.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatlistFriends.GroupMouseEnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(170)))), ((int)(((byte)(253)))), ((int)(((byte)(211)))));
            this.chatlistFriends.GroupMouseLeaveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chatlistFriends.IsSmallHead = false;
            this.chatlistFriends.ItemMouseEnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(252)))), ((int)(((byte)(240)))), ((int)(((byte)(193)))));
            this.chatlistFriends.ItemNomalBackColor = System.Drawing.Color.Transparent;
            this.chatlistFriends.ItemSelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(240)))), ((int)(((byte)(193)))));
            this.chatlistFriends.Location = new System.Drawing.Point(3, 3);
            this.chatlistFriends.Name = "chatlistFriends";
            this.chatlistFriends.ScrollBarWidth = 12;
            this.chatlistFriends.Size = new System.Drawing.Size(271, 372);
            this.chatlistFriends.Sqlite = null;
            this.chatlistFriends.TabIndex = 0;
            this.chatlistFriends.Value = 0D;
            this.chatlistFriends.DoubleClickItem += new YellowEar.ChatListBox.ChatListItemClickEventHandler(this.chatlistFriends_DoubleClickItem);
            // 
            // chatlistGroups
            // 
            this.chatlistGroups.BackColor = System.Drawing.Color.Transparent;
            this.chatlistGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatlistGroups.GroupMouseEnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(170)))), ((int)(((byte)(253)))), ((int)(((byte)(211)))));
            this.chatlistGroups.GroupMouseLeaveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chatlistGroups.IsSmallHead = false;
            this.chatlistGroups.ItemMouseEnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(252)))), ((int)(((byte)(240)))), ((int)(((byte)(193)))));
            this.chatlistGroups.ItemNomalBackColor = System.Drawing.Color.Transparent;
            this.chatlistGroups.ItemSelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(240)))), ((int)(((byte)(193)))));
            this.chatlistGroups.Location = new System.Drawing.Point(3, 3);
            this.chatlistGroups.Name = "chatlistGroups";
            this.chatlistGroups.ScrollBarWidth = 12;
            this.chatlistGroups.Size = new System.Drawing.Size(271, 372);
            this.chatlistGroups.Sqlite = null;
            this.chatlistGroups.TabIndex = 0;
            this.chatlistGroups.Value = 0D;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(285, 585);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(285, 585);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.tabBody.ResumeLayout(false);
            this.tabFriends.ResumeLayout(false);
            this.tabGroups.ResumeLayout(false);
            this.cmsNotify.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chatlistFriends)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chatlistGroups)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.PictureBox picMin;
        private System.Windows.Forms.PictureBox picClose;
        private DSkin.Controls.DSkinPanel pnlHeader;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.TabControl tabBody;
        private System.Windows.Forms.TabPage tabFriends;
        private System.Windows.Forms.TabPage tabGroups;
        private System.Windows.Forms.Timer timerHidden;
        private DSkin.Controls.DSkinPictureBox picHeader;
        private ChatListBox chatlistFriends;
        private ChatListBox chatlistGroups;
        private DSkin.Controls.DSkinLabel lblNickName;
        private DSkin.Controls.DSkinBaseControl dSkinBaseControl1;
        private DSkin.DirectUI.DuiTextBox duiTextBoxSign;
        private DSkin.Controls.DSkinLabel lblIP;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private DSkin.Controls.DSkinContextMenuStrip cmsNotify;
        private System.Windows.Forms.ToolStripMenuItem tsmiBusy;
        private System.Windows.Forms.ToolStripMenuItem tsmiLeave;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenCloseSound;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenCloseHeadImgTwinkle;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetting;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private DSkin.Controls.DSkinToolTip tooltip1;
        private System.Windows.Forms.Timer timerIconTwinkle;
    }
}

