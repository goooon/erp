using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class AreaCodeQueryForm : BaseClass.frmBase
    {
        public AreaCodeQueryForm()
        {
            InitializeComponent();
        }

        private void Query()
        {
            psService.PostCode s = new psService.PostCode();
            string[] sInfo = s.GetCityCode(winTextBox1.txtEdit.Text, winTextBox2.txtEdit.Text);
            if (sInfo.Length == 1)
            {
                editBox1.Text = "没有数据";
                return;
            }

            editBox1.Text = "邮政编码:" + sInfo[0] + "   区号:" + sInfo[1];
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (winTextBox1.txtEdit.Text == "")
            {
                MessageBox.Show("省份不能为空!","提示");
                winTextBox1.Focus();
                return;
            }

            if (winTextBox2.txtEdit.Text == "")
            {
                MessageBox.Show("城市不能为空!","提示");
                winTextBox2.Focus();
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
