using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSkin.Controls;
using DSkin.Forms;
using System.Net.NetworkInformation;

namespace YellowEar
{
    public partial class frmSetting : DSkinForm
    {
        private Self_Info myselfinfo;
        private Dictionary<int, string> iplist;
        private bool IPChanged = false;
        private bool PortChanged = false;
        private bool NickNameChanged = false;
        private bool SignChanged = true;
        public frmSetting(Self_Info self_Info)
        {
            InitializeComponent();
            myselfinfo = self_Info;
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            iplist = new Dictionary<int, string>();
            int ipselectedindex = -1;
            for(int i=0;i<myselfinfo.currentIPs.Count;i++)
            {
                iplist.Add(i, myselfinfo.currentIPs[i].Address.ToString());
                if(myselfinfo.currentIPs[i].Address.ToString()==myselfinfo.Ip.ToString())
                {
                    ipselectedindex = i;
                }
            }
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = iplist;
            comIpList.DataSource = bindingSource;
            comIpList.ValueMember = "Key";
            comIpList.DisplayMember = "Value";
            comIpList.SelectedIndex = ipselectedindex;

            numPort.Value = myselfinfo.Port;

            txtNickName.Text = myselfinfo.NickName;
            txtSign.Text = myselfinfo.Sign;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
                //只要一给this.DialogResult赋值，窗体就会隐藏并返回
                this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            
            if(IPChanged)
            {
                myselfinfo.Ip = myselfinfo.currentIPs[comIpList.SelectedIndex].Address;
            }
            if(PortChanged)
            {
                myselfinfo.Port = Convert.ToInt32(numPort.Value);
            }
            if(NickNameChanged)
            {
                myselfinfo.NickName = txtNickName.Text;
            }
            if(SignChanged)
            {
                myselfinfo.Sign = txtSign.Text;
            }
            if(IPChanged||PortChanged||NickNameChanged||SignChanged)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
            
        }

        private void comIpList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            IPChanged = true;
        }

        private void numPort_ValueChanged(object sender, EventArgs e)
        {
            
            PortChanged = true;
        }

        private void txtNickName_TextChanged(object sender, EventArgs e)
        {
            
            NickNameChanged = true;
        }

        private void txtSign_TextChanged(object sender, EventArgs e)
        {
            
            SignChanged = true;
        }
    }
}
