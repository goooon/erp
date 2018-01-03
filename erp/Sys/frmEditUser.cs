using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class frmEditUser : BaseClass.frmBase
    {
        private string strSaveSQL;
        public frmEditUser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 用户组
        /// </summary>
        private void SetDropSource()
        {
            string strSQL = "select F_Group from t_UserGroup";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lookUpEdit1.Properties.DataSource = ds.Tables[0].DefaultView;
            lookUpEdit1.Properties.DisplayMember = "F_Group";
            lookUpEdit1.Properties.ValueMember = "F_Group";
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        public void DataBind(string strID)
        {
            SetDropSource();
            string strSQL = "select * from t_User where F_ID = '"+strID+"'";
            strSaveSQL = strSQL;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (ds == null) return;
            binUser.DataSource = ds.Tables[0].DefaultView;
            textEdit1.DataBindings.Add("EditValue", binUser, "F_ID");
            textEdit2.DataBindings.Add("EditValue", binUser, "F_Name");
            lookUpEdit1.DataBindings.Add("EditValue", binUser, "F_Group");
            if (strID == "")
            {
                DataRow dr = ((DataRowView)binUser.AddNew()).Row;
                dr["F_Psw"] = "";
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            binUser.EndEdit();

            if (textEdit1.Text.Length == 0)
            {
                MessageBox.Show("用户代码不能为空!!","提示");
                textEdit1.Focus();
                return;
            }

            if (textEdit2.Text.Length == 0)
            {
                MessageBox.Show("用户名称不能为空!!", "提示");
                textEdit2.Focus();
                return;
            }

            if (lookUpEdit1.Text.Length == 0)
            {
                MessageBox.Show("用户组不能为空!!", "提示");
                lookUpEdit1.Focus();
                return;
            }

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = ((DataView)binUser.DataSource).Table.DataSet;
            if (myHelper.SaveData(ds,strSaveSQL) == 0)
                this.DialogResult = DialogResult.OK;
        }
    }
}

