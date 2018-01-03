using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JXC
{
    public partial class frmReg : Form
    {
        public frmReg()
        {
            InitializeComponent();
            GetDeviceCode();
        }

        private void GetDeviceCode()
        {
            try
            {
                string[] s = DataLib.SysVar.GetMoc();
                txtCode.Text = s[1];
                
                //txtReg.Text = DataLib.SysVar.md5(s[1]);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "错误");
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            if (DataLib.SysVar.md5(txtCode.Text) == txtReg.Text)
            {
                DataLib.SysVar.WTRegedit("RegCode", txtReg.Text);
                DataLib.SysVar.bReg = true;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(this,"注册码不正确，请检查!","提示");
            }
        }
    }
}
