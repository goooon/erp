using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class frmPsw : BaseClass.frmBase
    {
        public string strID;
        public frmPsw()
        {
            InitializeComponent();
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text != textEdit2.Text)
            {
                MessageBox.Show("校验新密码错!!", "提示");
                textEdit2.Focus();
                return;
            }

            if (textEdit1.Text.Length == 0)
            {
                if (MessageBox.Show(this, "你要将本用户密码设为空吗!!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    textEdit1.Focus();
                    return;
                }
            }
            string strSQL = "update t_User set F_Psw = '"+textEdit1.Text+"' where F_ID = '"+strID+"'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL(strSQL) == 0)
                Close();
        }
    }
}

