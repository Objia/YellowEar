using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSkin.Forms;
using DSkin.Controls;
using DSkin.DirectUI;
using System.Threading;

namespace YellowEar
{
    /// <summary>
    /// 聊天窗体
    /// </summary>
    public partial class FrmChat : DSkinForm
    {
        /// <summary>
        /// 表情面板
        /// </summary>
        private DSkinToolStripDropDown emotion_panel;

        private UdpSocket udpsoket_main;
        private List<FrmChat> frmchatlist_main;
        private frmMain mainform;

        /// <summary>
        /// 是否回车键直接发送
        /// </summary>
        private bool EnterToSend = true;

        /// <summary>
        /// 创建一个聊天窗口
        /// </summary>
        /// <param name="socket">程序的udp通信对象</param>
        /// <param name="frmchatlist">已经打开的聊天窗口列表</param>
        /// <param name="friendcontorl">好友控件</param>
        /// <param name="main">程序主窗体</param>
        public FrmChat(UdpSocket socket, List<FrmChat> frmchatlist,DuiBaseControl friendcontorl,frmMain main)
        {
            InitializeComponent();

            emotion_panel = new DSkinToolStripDropDown();
            udpsoket_main = socket;
            frmchatlist_main = frmchatlist;
            Friend_Info friend = (Friend_Info)friendcontorl.Tag;
            picHeadImg.BackgroundImage = friend.HeadImg == null ? Properties.Resources.YellowEar : friend.HeadImg;
            lblNickName.Text = friend.NickName + (friend.MarkName == "" ? "" : "（" + friend.MarkName + "）");
            lblSign.Text = friend.Sign;
            this.Tag = friendcontorl;
            frmchatlist_main.Add(this);
            mainform = main;
        }

        private void dSkinSplitContainer1_CollapseClick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void tsbtnFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = this.rtfSend.Font;
            fontDialog.Color = this.rtfSend.ForeColor;
            if(fontDialog.ShowDialog()==DialogResult.OK)
            {
                this.rtfSend.Font = fontDialog.Font;
                this.rtfSend.ForeColor = fontDialog.Color;
            }
            fontDialog.Dispose();
        }

        /// <summary>
        /// 聊天窗口震动
        /// </summary>
        public void ShakeWindow()
        {
            Point pOld = this.Location;
            int radius = 3;//震动半径
            for (int n = 0; n < 3;n++)//旋转圈数
            {
                //右半圆逆时针,注意Y的正负与笛卡尔坐标y相反
                for(int i=-radius;i<=radius;i++)
                {
                    int x = Convert.ToInt32(Math.Sqrt(radius * radius - i * i));
                    int y = -i;
                    this.Location = new Point(pOld.X + x, pOld.Y + y);
                    Thread.Sleep(10);
                }
                //左半圆逆时针
                for(int j=radius;j>=-radius;j--)
                {
                    int x = -Convert.ToInt32(Math.Sqrt(radius * radius - j * j));
                    int y = -j;
                    this.Location = new Point(pOld.X + x, pOld.Y + y);
                    Thread.Sleep(10);
                }
            }
            this.Location = pOld;
        }

        private void FrmChat_Load(object sender, EventArgs e)
        {
            LoadEmotinosDropDown();
        }

        /// <summary>
        /// 将表情图片加载到DSkinToolStripDropDown控件上
        /// </summary>
        private void LoadEmotinosDropDown()
        {
            lock(emotion_panel)
            {
                emotion_panel.ImageScalingSize = new Size(18, 18);
                emotion_panel.LayoutStyle = ToolStripLayoutStyle.Table;
                ((TableLayoutSettings)emotion_panel.LayoutSettings).ColumnCount = 10;
                for(int i=0;i<30;i++)
                {
                    emotion_panel.Items.Add(null, 
                        Properties.Resources.ResourceManager.GetObject("Face_" + i.ToString()) as Bitmap, 
                        Emotion_Click)
                        .ToolTipText=GetEmotionName(i);
                }
            }
        }
        /// <summary>
        /// 获取表情的提示名称
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private string GetEmotionName(int index)
        {
            string str=null;
            switch (index)
            {
                case 0:
                    str = "微笑";
                    break;
                case 1:
                    str = "发愁";
                    break;
                case 2:
                    str = "喜欢";
                    break;
                case 3:
                    str = "大笑";
                    break;
                case 4:
                    str = "不开心";
                    break;
                case 5:
                    str = "偷笑";
                    break;
                case 6:
                    str = "撇嘴";
                    break;
                case 7:
                    str = "晕";
                    break;
                case 8:
                    str = "讪笑";
                    break;
                case 9:
                    str = "鄙视";
                    break;
                case 10:
                    str = "委屈";
                    break;
                case 11:
                    str = "撅嘴";
                    break;
                case 12:
                    str = "可怜";
                    break;
                case 13:
                    str = "菜刀";
                    break;
                case 14:
                    str = "米饭";
                    break;
                case 15:
                    str = "猪头";
                    break;
                case 16:
                    str = "玫瑰";
                    break;
                case 17:
                    str = "爱心";
                    break;
                case 18:
                    str = "匕首";
                    break;
                case 19:
                    str = "大便";
                    break;
                case 20:
                    str = "晚安";
                    break;
                case 21:
                    str = "太阳";
                    break;
                case 22:
                    str = "拥抱";
                    break;
                case 23:
                    str = "赞赏";
                    break;
                case 24:
                    str = "不赞赏";
                    break;
                case 25:
                    str = "握手";
                    break;
                case 26:
                    str = "胜利";
                    break;
                case 27:
                    str = "佩服";
                    break;
                case 28:
                    str = "小指";
                    break;
                case 29:
                    str = "OK";
                    break;
                default:
                    break;

            }
            return str;

        }
        /// <summary>
        /// 表情点击事件处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Emotion_Click(object sender,EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            if(item!=null)
            {
                //this.rtfSend.rtf
                //this.rtfSend.InsertImage(item.Image);
                //this.rtfSend.Focus();
            }
        }

        private void tsbtnEmoj_Click(object sender, EventArgs e)
        {
            Point pt = splitcontainerChat.Panel2.PointToScreen(new Point(tsMiddleMenu.Location.X, tsMiddleMenu.Location.Y));
            emotion_panel.Show(pt.X, pt.Y - 80);
        }

        private void FrmChat_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmchatlist_main.Remove(this);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //检查是不是由rtfSend控件的回车键引发的
            if (e.GetType()!=typeof(KeyEventArgs))
            {
                if(((MouseEventArgs)e).Button==MouseButtons.Right)
                {
                    return;
                }
            }
            ChatData chatData = new ChatData(mainform.myselfinfo.MacId, Encoding.UTF8.GetBytes(rtfSend.Rtf));
            mainform.SendMessage(
                (Friend_Info)(((DuiBaseControl)this.Tag).Tag),
                MessageType.RichText,
                MessageCommandWord.None,
                ChatType.One,
                Serializer.SerializeBinary(chatData));

            rtfReceive.SelectionStart = rtfReceive.TextLength;
            rtfReceive.SelectionAlignment = HorizontalAlignment.Right;
            rtfReceive.AppendRichText(
                "自己" + DateTime.Now.ToString("(M月d日HH:mm)"),
                new Font("Microsoft YaHei UI", 9.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, (byte)(134)),
                Color.FromArgb(199, 54, 18));
            rtfReceive.AppendText(Environment.NewLine);

            //Dictionary<uint, Image> imags = rtfSend.GetContent().ForeignImageDictionary;
            rtfSend.SelectionAlignment = HorizontalAlignment.Right;
            uint start_len = Convert.ToUInt32(rtfReceive.TextLength);
            if (rtfSend.Rtf!="")
            {
                rtfReceive.AppendRtf(rtfSend.Rtf);
            }
            
            rtfSend.SaveFile(Environment.CurrentDirectory + @"/temp.rtf", RichTextBoxStreamType.RichText);
            rtfSend.SelectionAlignment = HorizontalAlignment.Left;
            rtfSend.Clear();

            //foreach (KeyValuePair<uint,Image> item in imags)
            //{
            //    rtfReceive.InsertImage(item.Value,Convert.ToInt32(item.Key + start_len));
            //}
            rtfReceive.AppendText(Environment.NewLine);
            rtfReceive.ScrollToCaret();
            rtfReceive.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void rtfSend_KeyDown(object sender, KeyEventArgs e)
        {
            if(EnterToSend)
            {
                if(e.KeyCode==Keys.Enter&e.Modifiers==Keys.None)
                {
                    e.Handled = true;
                    btnSend_Click(sender, e);
                }
                if(e.Modifiers==Keys.Control&&e.KeyCode==Keys.Enter)                    
                {
                    e.Handled = true;
                    rtfSend.AppendText(Environment.NewLine);
                }
            }
            else
            {
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    btnSend_Click(sender, e);
                }
            }

            //if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
            //{
            //    if (rtfSend.CanPaste(DataFormats.GetFormat(DataFormats.Bitmap)))
            //    {
            //        rtfSend.Paste();
            //    }
            //}
        }

        private void tsmiEnterToSend_Click(object sender, EventArgs e)
        {
            EnterToSend = true;
        }

        private void tsmiCtrlEnterToSend_Click(object sender, EventArgs e)
        {
            EnterToSend = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbtnShake_Click(object sender, EventArgs e)
        {
            ShakeWindow();

            ChatData chatData = new ChatData(mainform.myselfinfo.MacId, null);
            mainform.SendMessage((Friend_Info)(((DuiBaseControl)this.Tag).Tag),
                MessageType.RichText, 
                MessageCommandWord.WindowShake, 
                ChatType.One,
                Serializer.SerializeBinary(chatData));
        }

    }
}
