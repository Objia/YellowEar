namespace YellowEar
{
    partial class FrmChat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChat));
            this.pnlHeader = new DSkin.Controls.DSkinPanel();
            this.lblSign = new DSkin.Controls.DSkinLabel();
            this.lblNickName = new DSkin.Controls.DSkinLabel();
            this.picHeadImg = new DSkin.Controls.DSkinPictureBox();
            this.tsTopMenu = new DSkin.Controls.DSkinToolStrip();
            this.tssbtnAudio = new System.Windows.Forms.ToolStripSplitButton();
            this.tssbtnVideo = new System.Windows.Forms.ToolStripSplitButton();
            this.tssbtnFile = new System.Windows.Forms.ToolStripSplitButton();
            this.cmsSend = new DSkin.Controls.DSkinContextMenuStrip();
            this.tsmiEnterToSend = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAltEnterToSend = new System.Windows.Forms.ToolStripMenuItem();
            this.controlHost1 = new DSkin.Controls.ControlHost();
            this.splitcontainerBody = new DSkin.Controls.DSkinSplitContainer();
            this.splitcontainerChat = new DSkin.Controls.DSkinSplitContainer();
            this.rtfReceive = new DSkin.Controls.DSkinChatRichTextBox();
            this.rtfSend = new System.Windows.Forms.RichTextBox();
            this.tsMiddleMenu = new DSkin.Controls.DSkinToolStrip();
            this.tsbtnFont = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEmoj = new System.Windows.Forms.ToolStripButton();
            this.tsbtnShake = new System.Windows.Forms.ToolStripButton();
            this.tsbtnImage = new System.Windows.Forms.ToolStripButton();
            this.tsSplitbtnHistory = new System.Windows.Forms.ToolStripSplitButton();
            this.pnBottom = new DSkin.Controls.DSkinPanel();
            this.btnSend = new DSkin.Controls.DSkinButton();
            this.btnClose = new DSkin.Controls.DSkinButton();
            this.splitButton2 = new YellowEar.SplitButton(this.components);
            this.pnlHeader.SuspendLayout();
            this.tsTopMenu.SuspendLayout();
            this.cmsSend.SuspendLayout();
            this.controlHost1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitcontainerBody)).BeginInit();
            this.splitcontainerBody.Panel2.SuspendLayout();
            this.splitcontainerBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitcontainerChat)).BeginInit();
            this.splitcontainerChat.Panel1.SuspendLayout();
            this.splitcontainerChat.Panel2.SuspendLayout();
            this.splitcontainerChat.SuspendLayout();
            this.tsMiddleMenu.SuspendLayout();
            this.pnBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.lblSign);
            this.pnlHeader.Controls.Add(this.lblNickName);
            this.pnlHeader.Controls.Add(this.picHeadImg);
            this.pnlHeader.Location = new System.Drawing.Point(5, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(2);
            this.pnlHeader.RightBottom = ((System.Drawing.Image)(resources.GetObject("pnlHeader.RightBottom")));
            this.pnlHeader.Size = new System.Drawing.Size(187, 56);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSign
            // 
            this.lblSign.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSign.Location = new System.Drawing.Point(61, 33);
            this.lblSign.Name = "lblSign";
            this.lblSign.Size = new System.Drawing.Size(116, 18);
            this.lblSign.TabIndex = 2;
            this.lblSign.Text = "写下你的个人签名吧";
            // 
            // lblNickName
            // 
            this.lblNickName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNickName.Location = new System.Drawing.Point(61, 6);
            this.lblNickName.Name = "lblNickName";
            this.lblNickName.Size = new System.Drawing.Size(67, 24);
            this.lblNickName.TabIndex = 1;
            this.lblNickName.Text = "BatMan";
            // 
            // picHeadImg
            // 
            this.picHeadImg.BackgroundImage = global::YellowEar.Properties.Resources.YellowEar;
            this.picHeadImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picHeadImg.Dock = System.Windows.Forms.DockStyle.Left;
            this.picHeadImg.Image = null;
            this.picHeadImg.Images = new System.Drawing.Image[] {
        null};
            this.picHeadImg.Location = new System.Drawing.Point(2, 2);
            this.picHeadImg.Name = "picHeadImg";
            this.picHeadImg.Size = new System.Drawing.Size(52, 52);
            this.picHeadImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHeadImg.TabIndex = 0;
            this.picHeadImg.Text = "dSkinPictureBox1";
            // 
            // tsTopMenu
            // 
            this.tsTopMenu.Arrow = System.Drawing.Color.Black;
            this.tsTopMenu.Back = System.Drawing.Color.White;
            this.tsTopMenu.BackColor = System.Drawing.Color.Transparent;
            this.tsTopMenu.BackRadius = 4;
            this.tsTopMenu.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.tsTopMenu.Base = System.Drawing.Color.Transparent;
            this.tsTopMenu.BaseFore = System.Drawing.Color.Black;
            this.tsTopMenu.BaseForeAnamorphosis = false;
            this.tsTopMenu.BaseForeAnamorphosisBorder = 4;
            this.tsTopMenu.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.tsTopMenu.BaseForeOffset = new System.Drawing.Point(0, 0);
            this.tsTopMenu.BaseHoverFore = System.Drawing.Color.White;
            this.tsTopMenu.BaseItemAnamorphosis = true;
            this.tsTopMenu.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsTopMenu.BaseItemBorderShow = true;
            this.tsTopMenu.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("tsTopMenu.BaseItemDown")));
            this.tsTopMenu.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsTopMenu.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("tsTopMenu.BaseItemMouse")));
            this.tsTopMenu.BaseItemNorml = null;
            this.tsTopMenu.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsTopMenu.BaseItemRadius = 4;
            this.tsTopMenu.BaseItemRadiusStyle = DSkin.Common.RoundStyle.All;
            this.tsTopMenu.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsTopMenu.BindTabControl = null;
            this.tsTopMenu.CheckedImage = null;
            this.tsTopMenu.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.tsTopMenu.Fore = System.Drawing.Color.Black;
            this.tsTopMenu.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.tsTopMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsTopMenu.HoverFore = System.Drawing.Color.White;
            this.tsTopMenu.ItemAnamorphosis = false;
            this.tsTopMenu.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsTopMenu.ItemBorderShow = true;
            this.tsTopMenu.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsTopMenu.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsTopMenu.ItemRadius = 4;
            this.tsTopMenu.ItemRadiusStyle = DSkin.Common.RoundStyle.All;
            this.tsTopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssbtnAudio,
            this.tssbtnVideo,
            this.tssbtnFile});
            this.tsTopMenu.Location = new System.Drawing.Point(3, 64);
            this.tsTopMenu.Name = "tsTopMenu";
            this.tsTopMenu.RadiusStyle = DSkin.Common.RoundStyle.All;
            this.tsTopMenu.Size = new System.Drawing.Size(590, 35);
            this.tsTopMenu.SkinAllColor = true;
            this.tsTopMenu.TabIndex = 1;
            this.tsTopMenu.TitleAnamorphosis = false;
            this.tsTopMenu.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.tsTopMenu.TitleRadius = 4;
            this.tsTopMenu.TitleRadiusStyle = DSkin.Common.RoundStyle.All;
            // 
            // tssbtnAudio
            // 
            this.tssbtnAudio.AutoSize = false;
            this.tssbtnAudio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssbtnAudio.Image = ((System.Drawing.Image)(resources.GetObject("tssbtnAudio.Image")));
            this.tssbtnAudio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tssbtnAudio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbtnAudio.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tssbtnAudio.Name = "tssbtnAudio";
            this.tssbtnAudio.Size = new System.Drawing.Size(41, 32);
            this.tssbtnAudio.ToolTipText = "语音聊天";
            // 
            // tssbtnVideo
            // 
            this.tssbtnVideo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssbtnVideo.Image = ((System.Drawing.Image)(resources.GetObject("tssbtnVideo.Image")));
            this.tssbtnVideo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tssbtnVideo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbtnVideo.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.tssbtnVideo.Name = "tssbtnVideo";
            this.tssbtnVideo.Size = new System.Drawing.Size(41, 32);
            this.tssbtnVideo.ToolTipText = "视频聊天";
            // 
            // tssbtnFile
            // 
            this.tssbtnFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssbtnFile.Image = ((System.Drawing.Image)(resources.GetObject("tssbtnFile.Image")));
            this.tssbtnFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tssbtnFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbtnFile.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.tssbtnFile.Name = "tssbtnFile";
            this.tssbtnFile.Size = new System.Drawing.Size(41, 32);
            this.tssbtnFile.ToolTipText = "发送文件";
            // 
            // cmsSend
            // 
            this.cmsSend.Arrow = System.Drawing.Color.Black;
            this.cmsSend.AutoSize = false;
            this.cmsSend.Back = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(218)))), ((int)(((byte)(217)))));
            this.cmsSend.BackRadius = 4;
            this.cmsSend.Base = System.Drawing.Color.Transparent;
            this.cmsSend.CheckedImage = null;
            this.cmsSend.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cmsSend.DropShadowEnabled = false;
            this.cmsSend.Fore = System.Drawing.Color.Black;
            this.cmsSend.HoverFore = System.Drawing.Color.White;
            this.cmsSend.ItemAnamorphosis = true;
            this.cmsSend.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.cmsSend.ItemBorderShow = true;
            this.cmsSend.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.cmsSend.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.cmsSend.ItemRadius = 4;
            this.cmsSend.ItemRadiusStyle = DSkin.Common.RoundStyle.All;
            this.cmsSend.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEnterToSend,
            this.tsmiAltEnterToSend});
            this.cmsSend.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.cmsSend.Name = "cmsSend";
            this.cmsSend.RadiusStyle = DSkin.Common.RoundStyle.All;
            this.cmsSend.ShowImageMargin = false;
            this.cmsSend.Size = new System.Drawing.Size(160, 52);
            this.cmsSend.SkinAllColor = true;
            this.cmsSend.TitleAnamorphosis = true;
            this.cmsSend.TitleColor = System.Drawing.Color.Black;
            this.cmsSend.TitleRadius = 4;
            this.cmsSend.TitleRadiusStyle = DSkin.Common.RoundStyle.All;
            // 
            // tsmiEnterToSend
            // 
            this.tsmiEnterToSend.Name = "tsmiEnterToSend";
            this.tsmiEnterToSend.Size = new System.Drawing.Size(188, 24);
            this.tsmiEnterToSend.Text = "按Enter键发送";
            this.tsmiEnterToSend.Click += new System.EventHandler(this.tsmiEnterToSend_Click);
            // 
            // tsmiAltEnterToSend
            // 
            this.tsmiAltEnterToSend.Name = "tsmiAltEnterToSend";
            this.tsmiAltEnterToSend.Size = new System.Drawing.Size(188, 24);
            this.tsmiAltEnterToSend.Text = "按Ctrl+Enter键发送";
            this.tsmiAltEnterToSend.Click += new System.EventHandler(this.tsmiCtrlEnterToSend_Click);
            // 
            // controlHost1
            // 
            this.controlHost1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.controlHost1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.controlHost1.Controls.Add(this.splitcontainerBody);
            this.controlHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlHost1.Location = new System.Drawing.Point(3, 99);
            this.controlHost1.Name = "controlHost1";
            this.controlHost1.Size = new System.Drawing.Size(590, 382);
            this.controlHost1.TabIndex = 2;
            this.controlHost1.Text = "controlHost1";
            this.controlHost1.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            // 
            // splitcontainerBody
            // 
            this.splitcontainerBody.ArroColor = System.Drawing.Color.White;
            this.splitcontainerBody.ArroHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.splitcontainerBody.BackColor = System.Drawing.Color.Transparent;
            this.splitcontainerBody.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitcontainerBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitcontainerBody.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitcontainerBody.IsSplitterFixed = true;
            this.splitcontainerBody.LineBack = System.Drawing.Color.Transparent;
            this.splitcontainerBody.LineBack2 = System.Drawing.Color.Transparent;
            this.splitcontainerBody.Location = new System.Drawing.Point(0, 0);
            this.splitcontainerBody.Name = "splitcontainerBody";
            // 
            // splitcontainerBody.Panel1
            // 
            this.splitcontainerBody.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitcontainerBody.Panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitcontainerBody.Panel1.BackgroundImage")));
            this.splitcontainerBody.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitcontainerBody.Panel2
            // 
            this.splitcontainerBody.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitcontainerBody.Panel2.Controls.Add(this.splitcontainerChat);
            this.splitcontainerBody.Panel2.Controls.Add(this.pnBottom);
            this.splitcontainerBody.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitcontainerBody.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitcontainerBody.Size = new System.Drawing.Size(590, 382);
            this.splitcontainerBody.SplitterDistance = 150;
            this.splitcontainerBody.SplitterWidth = 5;
            this.splitcontainerBody.TabIndex = 4;
            this.splitcontainerBody.CollapseClick += new System.EventHandler(this.dSkinSplitContainer1_CollapseClick);
            // 
            // splitcontainerChat
            // 
            this.splitcontainerChat.CollapsePanel = DSkin.Controls.CollapsePanel.None;
            this.splitcontainerChat.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitcontainerChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitcontainerChat.LineBack = System.Drawing.SystemColors.Control;
            this.splitcontainerChat.LineBack2 = System.Drawing.SystemColors.Control;
            this.splitcontainerChat.Location = new System.Drawing.Point(0, 0);
            this.splitcontainerChat.Name = "splitcontainerChat";
            this.splitcontainerChat.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitcontainerChat.Panel1
            // 
            this.splitcontainerChat.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitcontainerChat.Panel1.Controls.Add(this.rtfReceive);
            this.splitcontainerChat.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitcontainerChat.Panel2
            // 
            this.splitcontainerChat.Panel2.Controls.Add(this.rtfSend);
            this.splitcontainerChat.Panel2.Controls.Add(this.tsMiddleMenu);
            this.splitcontainerChat.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitcontainerChat.Size = new System.Drawing.Size(435, 338);
            this.splitcontainerChat.SplitterDistance = 210;
            this.splitcontainerChat.SplitterWidth = 2;
            this.splitcontainerChat.TabIndex = 1;
            // 
            // rtfReceive
            // 
            this.rtfReceive.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtfReceive.ContextMenuMode = DSkin.Controls.ChatBoxContextMenuMode.None;
            this.rtfReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfReceive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtfReceive.Location = new System.Drawing.Point(0, 0);
            this.rtfReceive.Name = "rtfReceive";
            this.rtfReceive.PopoutImageWhenDoubleClick = false;
            this.rtfReceive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rtfReceive.SelectControl = null;
            this.rtfReceive.SelectControlIndex = 0;
            this.rtfReceive.SelectControlPoint = new System.Drawing.Point(0, 0);
            this.rtfReceive.Size = new System.Drawing.Size(435, 210);
            this.rtfReceive.TabIndex = 0;
            this.rtfReceive.Text = "";
            // 
            // rtfSend
            // 
            this.rtfSend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtfSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfSend.EnableAutoDragDrop = true;
            this.rtfSend.Location = new System.Drawing.Point(0, 27);
            this.rtfSend.Name = "rtfSend";
            this.rtfSend.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rtfSend.Size = new System.Drawing.Size(435, 99);
            this.rtfSend.TabIndex = 1;
            this.rtfSend.Text = "";
            // 
            // tsMiddleMenu
            // 
            this.tsMiddleMenu.Arrow = System.Drawing.Color.Black;
            this.tsMiddleMenu.Back = System.Drawing.SystemColors.Control;
            this.tsMiddleMenu.BackRadius = 4;
            this.tsMiddleMenu.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.tsMiddleMenu.Base = System.Drawing.Color.White;
            this.tsMiddleMenu.BaseFore = System.Drawing.Color.Black;
            this.tsMiddleMenu.BaseForeAnamorphosis = false;
            this.tsMiddleMenu.BaseForeAnamorphosisBorder = 4;
            this.tsMiddleMenu.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.tsMiddleMenu.BaseForeOffset = new System.Drawing.Point(0, 0);
            this.tsMiddleMenu.BaseHoverFore = System.Drawing.Color.White;
            this.tsMiddleMenu.BaseItemAnamorphosis = true;
            this.tsMiddleMenu.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsMiddleMenu.BaseItemBorderShow = true;
            this.tsMiddleMenu.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("tsMiddleMenu.BaseItemDown")));
            this.tsMiddleMenu.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsMiddleMenu.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("tsMiddleMenu.BaseItemMouse")));
            this.tsMiddleMenu.BaseItemNorml = null;
            this.tsMiddleMenu.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsMiddleMenu.BaseItemRadius = 4;
            this.tsMiddleMenu.BaseItemRadiusStyle = DSkin.Common.RoundStyle.All;
            this.tsMiddleMenu.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsMiddleMenu.BindTabControl = null;
            this.tsMiddleMenu.CheckedImage = null;
            this.tsMiddleMenu.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.tsMiddleMenu.Fore = System.Drawing.Color.Black;
            this.tsMiddleMenu.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.tsMiddleMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMiddleMenu.HoverFore = System.Drawing.Color.White;
            this.tsMiddleMenu.ItemAnamorphosis = true;
            this.tsMiddleMenu.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsMiddleMenu.ItemBorderShow = true;
            this.tsMiddleMenu.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsMiddleMenu.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsMiddleMenu.ItemRadius = 4;
            this.tsMiddleMenu.ItemRadiusStyle = DSkin.Common.RoundStyle.All;
            this.tsMiddleMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnFont,
            this.tsbtnEmoj,
            this.tsbtnShake,
            this.tsbtnImage,
            this.tsSplitbtnHistory});
            this.tsMiddleMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMiddleMenu.Name = "tsMiddleMenu";
            this.tsMiddleMenu.RadiusStyle = DSkin.Common.RoundStyle.All;
            this.tsMiddleMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsMiddleMenu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsMiddleMenu.Size = new System.Drawing.Size(435, 27);
            this.tsMiddleMenu.SkinAllColor = true;
            this.tsMiddleMenu.TabIndex = 0;
            this.tsMiddleMenu.Text = "dSkinToolStrip1";
            this.tsMiddleMenu.TitleAnamorphosis = true;
            this.tsMiddleMenu.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.tsMiddleMenu.TitleRadius = 4;
            this.tsMiddleMenu.TitleRadiusStyle = DSkin.Common.RoundStyle.All;
            // 
            // tsbtnFont
            // 
            this.tsbtnFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnFont.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnFont.Image")));
            this.tsbtnFont.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFont.Name = "tsbtnFont";
            this.tsbtnFont.Size = new System.Drawing.Size(24, 24);
            this.tsbtnFont.ToolTipText = "设置字体";
            this.tsbtnFont.Click += new System.EventHandler(this.tsbtnFont_Click);
            // 
            // tsbtnEmoj
            // 
            this.tsbtnEmoj.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnEmoj.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnEmoj.Image")));
            this.tsbtnEmoj.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnEmoj.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEmoj.Name = "tsbtnEmoj";
            this.tsbtnEmoj.Size = new System.Drawing.Size(24, 24);
            this.tsbtnEmoj.ToolTipText = "表情";
            this.tsbtnEmoj.Click += new System.EventHandler(this.tsbtnEmoj_Click);
            // 
            // tsbtnShake
            // 
            this.tsbtnShake.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnShake.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnShake.Image")));
            this.tsbtnShake.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnShake.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnShake.Name = "tsbtnShake";
            this.tsbtnShake.Size = new System.Drawing.Size(24, 24);
            this.tsbtnShake.ToolTipText = "发送窗口震动";
            this.tsbtnShake.Click += new System.EventHandler(this.tsbtnShake_Click);
            // 
            // tsbtnImage
            // 
            this.tsbtnImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnImage.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnImage.Image")));
            this.tsbtnImage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnImage.Name = "tsbtnImage";
            this.tsbtnImage.Size = new System.Drawing.Size(24, 24);
            this.tsbtnImage.ToolTipText = "发送图片";
            // 
            // tsSplitbtnHistory
            // 
            this.tsSplitbtnHistory.Image = ((System.Drawing.Image)(resources.GetObject("tsSplitbtnHistory.Image")));
            this.tsSplitbtnHistory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsSplitbtnHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSplitbtnHistory.Name = "tsSplitbtnHistory";
            this.tsSplitbtnHistory.Size = new System.Drawing.Size(105, 24);
            this.tsSplitbtnHistory.Text = "消息记录";
            // 
            // pnBottom
            // 
            this.pnBottom.BackColor = System.Drawing.Color.Transparent;
            this.pnBottom.Controls.Add(this.btnSend);
            this.pnBottom.Controls.Add(this.splitButton2);
            this.pnBottom.Controls.Add(this.btnClose);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 338);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.RightBottom = ((System.Drawing.Image)(resources.GetObject("pnBottom.RightBottom")));
            this.pnBottom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pnBottom.Size = new System.Drawing.Size(435, 44);
            this.pnBottom.TabIndex = 0;
            this.pnBottom.Text = "dSkinPanel1";
            // 
            // btnSend
            // 
            this.btnSend.AdaptImage = true;
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSend.ButtonBorderColor = System.Drawing.Color.Gray;
            this.btnSend.ButtonBorderWidth = 1;
            this.btnSend.ContextMenuStrip = this.cmsSend;
            this.btnSend.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSend.HoverColor = System.Drawing.Color.Empty;
            this.btnSend.HoverImage = null;
            this.btnSend.IsPureColor = false;
            this.btnSend.Location = new System.Drawing.Point(325, 6);
            this.btnSend.Name = "btnSend";
            this.btnSend.NormalImage = null;
            this.btnSend.PressColor = System.Drawing.Color.Empty;
            this.btnSend.PressedImage = null;
            this.btnSend.Radius = 10;
            this.btnSend.ShowButtonBorder = true;
            this.btnSend.Size = new System.Drawing.Size(80, 28);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "发送";
            this.btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSend.TextPadding = 0;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClose
            // 
            this.btnClose.AdaptImage = true;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClose.ButtonBorderColor = System.Drawing.Color.Gray;
            this.btnClose.ButtonBorderWidth = 1;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.HoverColor = System.Drawing.Color.Empty;
            this.btnClose.HoverImage = null;
            this.btnClose.IsPureColor = false;
            this.btnClose.Location = new System.Drawing.Point(201, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.NormalImage = null;
            this.btnClose.PressColor = System.Drawing.Color.Empty;
            this.btnClose.PressedImage = null;
            this.btnClose.Radius = 10;
            this.btnClose.ShowButtonBorder = true;
            this.btnClose.Size = new System.Drawing.Size(80, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关闭";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.TextPadding = 0;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // splitButton2
            // 
            this.splitButton2.AutoSize = true;
            this.splitButton2.ContextMenuStrip = this.cmsSend;
            this.splitButton2.Location = new System.Drawing.Point(75, 10);
            this.splitButton2.Name = "splitButton2";
            this.splitButton2.Size = new System.Drawing.Size(90, 23);
            this.splitButton2.SplitMenuStrip = this.cmsSend;
            this.splitButton2.TabIndex = 2;
            this.splitButton2.Text = "splitButton2";
            this.splitButton2.UseVisualStyleBackColor = true;
            this.splitButton2.Visible = false;
            // 
            // FrmChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::YellowEar.Properties.Resources.frmChatBackgroupImage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BorderColor = System.Drawing.Color.Lavender;
            this.CaptionHeight = 60;
            this.ClientSize = new System.Drawing.Size(597, 485);
            this.CloseBox.HoverImage = global::YellowEar.Properties.Resources.sysbtn_close_hover;
            this.CloseBox.NormalImage = global::YellowEar.Properties.Resources.sysbtn_close_normal;
            this.CloseBox.PressImage = global::YellowEar.Properties.Resources.sysbtn_close_down;
            this.Controls.Add(this.controlHost1);
            this.Controls.Add(this.tsTopMenu);
            this.Controls.Add(this.pnlHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaxBox.HoverImage = global::YellowEar.Properties.Resources.sysbtn_max_hover;
            this.MaxBox.NormalImage = global::YellowEar.Properties.Resources.sysbtn_max_normal;
            this.MaxBox.PressImage = global::YellowEar.Properties.Resources.sysbtn_max_down;
            this.MinBox.HoverImage = global::YellowEar.Properties.Resources.sysbtn_min_hover;
            this.MinBox.NormalImage = global::YellowEar.Properties.Resources.sysbtn_min_normal;
            this.MinBox.PressImage = global::YellowEar.Properties.Resources.sysbtn_min_down;
            this.MinimumSize = new System.Drawing.Size(520, 420);
            this.Name = "FrmChat";
            this.NormalBox.HoverImage = global::YellowEar.Properties.Resources.sysbtn_restore_hover;
            this.NormalBox.NormalImage = global::YellowEar.Properties.Resources.sysbtn_restore_normal;
            this.NormalBox.PressImage = global::YellowEar.Properties.Resources.sysbtn_restore_down;
            this.Padding = new System.Windows.Forms.Padding(-1, 4, 0, 0);
            this.ShowShadow = true;
            this.Text = "";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmChat_FormClosed);
            this.Load += new System.EventHandler(this.FrmChat_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tsTopMenu.ResumeLayout(false);
            this.tsTopMenu.PerformLayout();
            this.cmsSend.ResumeLayout(false);
            this.controlHost1.ResumeLayout(false);
            this.splitcontainerBody.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitcontainerBody)).EndInit();
            this.splitcontainerBody.ResumeLayout(false);
            this.splitcontainerChat.Panel1.ResumeLayout(false);
            this.splitcontainerChat.Panel2.ResumeLayout(false);
            this.splitcontainerChat.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitcontainerChat)).EndInit();
            this.splitcontainerChat.ResumeLayout(false);
            this.tsMiddleMenu.ResumeLayout(false);
            this.tsMiddleMenu.PerformLayout();
            this.pnBottom.ResumeLayout(false);
            this.pnBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DSkin.Controls.DSkinPanel pnlHeader;
        private DSkin.Controls.DSkinToolStrip tsTopMenu;
        private System.Windows.Forms.ToolStripSplitButton tssbtnAudio;
        private System.Windows.Forms.ToolStripSplitButton tssbtnVideo;
        private System.Windows.Forms.ToolStripSplitButton tssbtnFile;
        private DSkin.Controls.DSkinContextMenuStrip cmsSend;
        private System.Windows.Forms.ToolStripMenuItem tsmiEnterToSend;
        private System.Windows.Forms.ToolStripMenuItem tsmiAltEnterToSend;
        private DSkin.Controls.DSkinPictureBox picHeadImg;
        private DSkin.Controls.ControlHost controlHost1;
        private DSkin.Controls.DSkinSplitContainer splitcontainerBody;
        private DSkin.Controls.DSkinSplitContainer splitcontainerChat;
        public DSkin.Controls.DSkinChatRichTextBox rtfReceive;
        private DSkin.Controls.DSkinToolStrip tsMiddleMenu;
        private DSkin.Controls.DSkinPanel pnBottom;
        private SplitButton splitButton2;
        private DSkin.Controls.DSkinButton btnSend;
        private DSkin.Controls.DSkinButton btnClose;
        private DSkin.Controls.DSkinLabel lblSign;
        private DSkin.Controls.DSkinLabel lblNickName;
        private System.Windows.Forms.ToolStripButton tsbtnFont;
        private System.Windows.Forms.ToolStripButton tsbtnEmoj;
        private System.Windows.Forms.ToolStripButton tsbtnShake;
        private System.Windows.Forms.ToolStripButton tsbtnImage;
        private System.Windows.Forms.ToolStripSplitButton tsSplitbtnHistory;
        public System.Windows.Forms.RichTextBox rtfSend;
    }
}