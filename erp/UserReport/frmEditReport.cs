using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UserReport
{
    public partial class frmEditReport : BaseClass.frmBase
    {
        public bool pFlag = false;
        public string strName;
        public frmEditReport()
        {
            InitializeComponent();
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("报表名称不能为空!!","提示");
                txtName.Focus();
                return;
            }

            if (cbType.Text.Length == 0)
            {
                MessageBox.Show("报表名称不能为空!!", "提示");
                cbType.Focus();
                return;
            }
            DataLib.DataHelper myHelper = new DataLib.DataHelper();

            if (pFlag == false)
                strSQL = "insert into t_UserReport(F_Name,F_Type) values('" + txtName.Text + "','" + cbType.Text + "')";
            else
                strSQL = "update t_UserReport set F_Name = '"+txtName.Text+"',F_Type = '"+cbType.Text+"' where F_Name = '"+strName+"'";

                if (myHelper.ExecuteSQL(strSQL) == 0)
                    this.DialogResult = DialogResult.OK;
        }

        private void frmEditReport_Load(object sender, EventArgs e)
        {

        }
    }
}

