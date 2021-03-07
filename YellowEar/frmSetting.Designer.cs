namespace YellowEar
{
    partial class frmSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetting));
            this.btnCancel = new DSkin.Controls.DSkinButton();
            this.btnOK = new DSkin.Controls.DSkinButton();
            this.lblIpPort = new DSkin.Controls.DSkinLabel();
            this.numPort = new DSkin.Controls.DSkinNumericUpDown();
            this.lblNickName = new DSkin.Controls.DSkinLabel();
            this.comIpList = new DSkin.Controls.DCSkinComboBox();
            this.basecontrolNickName = new DSkin.Controls.DSkinBaseControl();
            this.txtSign = new DSkin.DirectUI.DuiTextBox();
            this.lblSign = new DSkin.Controls.DSkinLabel();
            this.basecontrolSign = new DSkin.Controls.DSkinBaseControl();
            this.txtNickName = new DSkin.DirectUI.DuiTextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.AdaptImage = true;
            this.btnCancel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnCancel.ButtonBorderColor = System.Drawing.Color.Gray;
            this.btnCancel.ButtonBorderWidth = 1;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancel.HoverColor = System.Drawing.Color.Empty;
            this.btnCancel.HoverImage = null;
            this.btnCancel.IsPureColor = false;
            this.btnCancel.Location = new System.Drawing.Point(242, 334);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormalImage = null;
            this.btnCancel.PressColor = System.Drawing.Color.Empty;
            this.btnCancel.PressedImage = null;
            this.btnCancel.Radius = 10;
            this.btnCancel.ShowButtonBorder = true;
            this.btnCancel.Size = new System.Drawing.Size(66, 31);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.TextPadding = 0;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.AdaptImage = true;
            this.btnOK.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnOK.ButtonBorderColor = System.Drawing.Color.Gray;
            this.btnOK.ButtonBorderWidth = 1;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOK.HoverColor = System.Drawing.Color.Empty;
            this.btnOK.HoverImage = null;
            this.btnOK.IsPureColor = false;
            this.btnOK.Location = new System.Drawing.Point(352, 334);
            this.btnOK.Name = "btnOK";
            this.btnOK.NormalImage = null;
            this.btnOK.PressColor = System.Drawing.Color.Empty;
            this.btnOK.PressedImage = null;
            this.btnOK.Radius = 10;
            this.btnOK.ShowButtonBorder = true;
            this.btnOK.Size = new System.Drawing.Size(66, 31);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOK.TextPadding = 0;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblIpPort
            // 
            this.lblIpPort.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpPort.Location = new System.Drawing.Point(33, 67);
            this.lblIpPort.Name = "lblIpPort";
            this.lblIpPort.Size = new System.Drawing.Size(89, 19);
            this.lblIpPort.TabIndex = 2;
            this.lblIpPort.Text = "IP地址和端口:";
            // 
            // numPort
            // 
            this.numPort.BitmapCache = false;
            this.numPort.Borders.AllColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(169)))), ((int)(((byte)(254)))));
            this.numPort.Borders.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(169)))), ((int)(((byte)(254)))));
            this.numPort.Borders.LeftColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(169)))), ((int)(((byte)(254)))));
            this.numPort.Borders.RightColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(169)))), ((int)(((byte)(254)))));
            this.numPort.Borders.TopColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(169)))), ((int)(((byte)(254)))));
            this.numPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numPort.Location = new System.Drawing.Point(276, 65);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.RightBottom = ((System.Drawing.Image)(resources.GetObject("numPort.RightBottom")));
            this.numPort.Size = new System.Drawing.Size(76, 21);
            this.numPort.TabIndex = 4;
            this.numPort.ValueChanged += new System.EventHandler(this.numPort_ValueChanged);
            // 
            // lblNickName
            // 
            this.lblNickName.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNickName.Location = new System.Drawing.Point(57, 120);
            this.lblNickName.Name = "lblNickName";
            this.lblNickName.Size = new System.Drawing.Size(35, 19);
            this.lblNickName.TabIndex = 6;
            this.lblNickName.Text = "昵称:";
            // 
            // comIpList
            // 
            this.comIpList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comIpList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comIpList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comIpList.FormattingEnabled = true;
            this.comIpList.Location = new System.Drawing.Point(133, 65);
            this.comIpList.Name = "comIpList";
            this.comIpList.Size = new System.Drawing.Size(121, 23);
            this.comIpList.TabIndex = 5;
            this.comIpList.WaterText = "";
            this.comIpList.SelectedIndexChanged += new System.EventHandler(this.comIpList_SelectedIndexChanged);
            // 
            // basecontrolNickName
            // 
            this.basecontrolNickName.Borders.BottomColor = System.Drawing.Color.Transparent;
            this.basecontrolNickName.DUIControls.Add(this.txtNickName);
            this.basecontrolNickName.Location = new System.Drawing.Point(133, 120);
            this.basecontrolNickName.Name = "basecontrolNickName";
            this.basecontrolNickName.Size = new System.Drawing.Size(143, 19);
            this.basecontrolNickName.TabIndex = 7;
            this.basecontrolNickName.Text = "dSkinBaseControl1";
            // 
            // txtSign
            // 
            this.txtSign.AutoSize = false;
            this.txtSign.BackColor = System.Drawing.Color.Transparent;
            this.txtSign.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSign.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // 
            // 
            this.txtSign.InnerScrollBar.AutoSize = false;
            this.txtSign.InnerScrollBar.DesignModeCanMove = false;
            this.txtSign.InnerScrollBar.DesignModeCanResize = false;
            this.txtSign.InnerScrollBar.DesignModeCanSelect = false;
            this.txtSign.InnerScrollBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSign.InnerScrollBar.KeyChangeValue = false;
            this.txtSign.InnerScrollBar.Location = new System.Drawing.Point(275, 0);
            this.txtSign.InnerScrollBar.Name = "";
            this.txtSign.InnerScrollBar.ScrollBarPartitionWidth = new System.Windows.Forms.Padding(5);
            this.txtSign.InnerScrollBar.Size = new System.Drawing.Size(10, 19);
            this.txtSign.InnerScrollBar.SmallChange = 5;
            this.txtSign.InnerScrollBar.Visible = false;
            this.txtSign.Location = new System.Drawing.Point(0, 0);
            this.txtSign.Name = "txtSign";
            this.txtSign.Size = new System.Drawing.Size(285, 19);
            this.txtSign.TextChanged += new System.EventHandler(this.txtSign_TextChanged);
            // 
            // lblSign
            // 
            this.lblSign.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSign.Location = new System.Drawing.Point(48, 175);
            this.lblSign.Name = "lblSign";
            this.lblSign.Size = new System.Drawing.Size(62, 19);
            this.lblSign.TabIndex = 8;
            this.lblSign.Text = "个人签名:";
            // 
            // basecontrolSign
            // 
            this.basecontrolSign.Borders.BottomColor = System.Drawing.Color.Transparent;
            this.basecontrolSign.DUIControls.Add(this.txtSign);
            this.basecontrolSign.Location = new System.Drawing.Point(133, 175);
            this.basecontrolSign.Name = "basecontrolSign";
            this.basecontrolSign.Size = new System.Drawing.Size(285, 19);
            this.basecontrolSign.TabIndex = 9;
            this.basecontrolSign.Text = "dSkinBaseControl1";
            // 
            // txtNickName
            // 
            this.txtNickName.AutoSize = false;
            this.txtNickName.BackColor = System.Drawing.Color.Transparent;
            this.txtNickName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNickName.DesignModeCanMove = false;
            this.txtNickName.DesignModeCanResize = false;
            this.txtNickName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNickName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // 
            // 
            this.txtNickName.InnerScrollBar.AutoSize = false;
            this.txtNickName.InnerScrollBar.DesignModeCanMove = false;
            this.txtNickName.InnerScrollBar.DesignModeCanResize = false;
            this.txtNickName.InnerScrollBar.DesignModeCanSelect = false;
            this.txtNickName.InnerScrollBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNickName.InnerScrollBar.KeyChangeValue = false;
            this.txtNickName.InnerScrollBar.Location = new System.Drawing.Point(133, 0);
            this.txtNickName.InnerScrollBar.Name = "";
            this.txtNickName.InnerScrollBar.ScrollBarPartitionWidth = new System.Windows.Forms.Padding(5);
            this.txtNickName.InnerScrollBar.Size = new System.Drawing.Size(10, 19);
            this.txtNickName.InnerScrollBar.SmallChange = 5;
            this.txtNickName.InnerScrollBar.Visible = false;
            this.txtNickName.Location = new System.Drawing.Point(0, 0);
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(143, 19);
            this.txtNickName.TextChanged += new System.EventHandler(this.txtNickName_TextChanged);
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::YellowEar.Properties.Resources.frmChatBackgroupImage;
            this.CanResize = false;
            this.CaptionBackColors = new System.Drawing.Color[0];
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClientSize = new System.Drawing.Size(454, 394);
            this.Controls.Add(this.basecontrolSign);
            this.Controls.Add(this.lblSign);
            this.Controls.Add(this.basecontrolNickName);
            this.Controls.Add(this.lblNickName);
            this.Controls.Add(this.comIpList);
            this.Controls.Add(this.numPort);
            this.Controls.Add(this.lblIpPort);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IconRectangle = new System.Drawing.Rectangle(5, 5, 20, 20);
            this.IsLayeredWindowForm = false;
            this.Name = "frmSetting";
            this.Text = "  设置";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DSkin.Controls.DSkinButton btnCancel;
        private DSkin.Controls.DSkinButton btnOK;
        private DSkin.Controls.DSkinLabel lblIpPort;
        private DSkin.Controls.DSkinNumericUpDown numPort;
        private DSkin.Controls.DSkinLabel lblNickName;
        private DSkin.Controls.DCSkinComboBox comIpList;
        private DSkin.Controls.DSkinBaseControl basecontrolNickName;
        private DSkin.DirectUI.DuiTextBox txtSign;
        private DSkin.Controls.DSkinLabel lblSign;
        private DSkin.Controls.DSkinBaseControl basecontrolSign;
        private DSkin.DirectUI.DuiTextBox txtNickName;
    }
}