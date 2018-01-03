using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class frmDelLog : BaseClass.frmBase
    {
        public frmDelLog()
        {
            InitializeComponent();
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDelLog_Load(object sender, EventArgs e)
        {
            deStart.EditValue = DateTime.Today.ToShortDateString();
            deEnd.EditValue = DateTime.Today.ToShortDateString();
        }

        private void sbDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "真的要删除本期日志资料吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            this.DialogResult = DialogResult.OK;
        }

        private void ckAll_CheckedChanged(object sender, EventArgs e)
        {
            deStart.Enabled = (ckAll.Checked == false);
            deEnd.Enabled = (ckAll.Checked == false);
        }
    }
}

