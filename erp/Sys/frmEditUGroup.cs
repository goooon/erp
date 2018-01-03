using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class frmEditUGroup : BaseClass.frmBase
    {
        public string strGroup = "";

        public frmEditUGroup()
        {
            InitializeComponent();
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text.Length == 0)
            {
                MessageBox.Show(this, "用户组不能为空!!");
                return;
            }

            int iFlag = 0;

            if (checkEdit1.Checked == true) iFlag = 1;

            string strSQL = "";
            if (strGroup == "")
                strSQL = string.Format("insert into t_UserGroup(F_Group,F_View,F_Salesman) values('{0}',{1},{2})", textEdit1.Text, 0, iFlag);
            else
                strSQL = string.Format("update t_UserGroup set F_Group = '{0}',F_Salesman = {1} where F_Group = '{2}'", textEdit1.Text, iFlag, strGroup);

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL(strSQL) == 0)
                this.DialogResult = DialogResult.OK;
        }
    }
}

