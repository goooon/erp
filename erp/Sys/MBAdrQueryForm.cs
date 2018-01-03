using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class MBAdrQueryForm : BaseClass.frmBase
    {
        public MBAdrQueryForm()
        {
            InitializeComponent();
        }

        private void Query()
        {
            MBService.MobileCodeWS s = new Sys.MBService.MobileCodeWS();
            string sInfo = s.getMobileCodeInfo(winTextBox1.txtEdit.Text, "");
            editBox1.Text = sInfo;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (winTextBox1.txtEdit.Text == "")
            {
                MessageBox.Show("手机号码不能为空!","提示");
                winTextBox1.Focus();
                return;
            }
            label2.Visible = true;
            btnQuery.Enabled = false;
            this.Update();
            try
            {
                Query();
            }
            finally
            {
                label2.Visible = false;
                btnQuery.Enabled = true;
            }
        }
    }
}
