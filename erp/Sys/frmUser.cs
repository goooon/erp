using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class frmUser : BaseClass.frmBase
    {
        public frmUser()
        {
            InitializeComponent();
        }

        private void DataBind()
        {
            string strSQL = "";
            if (DataLib.SysVar.strUGroup != "超级用户")
            {
                strSQL = "select *,(case isnull(F_Login,0) when 0 then '离线' else '在线' end) as F_Flag from t_User where F_ID = '" + DataLib.SysVar.strUID + "'";
            }
            else
            {
                strSQL = "select *,(case isnull(F_Login,0) when 0 then '离线' else '在线' end) as F_Flag from t_User";
            }

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (ds == null) return;
            gcMain.DataSource = ds.Tables[0].DefaultView;

        }

        private void sbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        private void sbAdd_Click(object sender, EventArgs e)
        {
            DataLib.sysClass myClass = new DataLib.sysClass();
            if (myClass.TestRight("frmEditUser") == false) return;
            frmEditUser myEditUser = new frmEditUser();
            myEditUser.DataBind("");
            if (myEditUser.ShowDialog() == DialogResult.OK)
                DataBind();
            myEditUser.Dispose();
        }

        private void sbEdit_Click(object sender, EventArgs e)
        {
            DataLib.sysClass myClass = new DataLib.sysClass();
            if (myClass.TestRight("frmEditUser") == false) return;
            if (gvMain.FocusedRowHandle < 0) return;
            DataRow dr = gvMain.GetDataRow(gvMain.FocusedRowHandle);
            frmEditUser myEditUser = new frmEditUser();
            myEditUser.DataBind(dr["F_ID"].ToString());
            if (myEditUser.ShowDialog() == DialogResult.OK)
                DataBind();
            myEditUser.Dispose();
        }

        private void sbDel_Click(object sender, EventArgs e)
        {
            DataLib.sysClass myClass = new DataLib.sysClass();
            if (myClass.TestRight("frmEditUser") == false) return;
            if (gvMain.FocusedRowHandle < 0) return;
            if (MessageBox.Show(this, "真的要删除选定用户吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_User where F_ID = '" + gvMain.GetRowCellValue(gvMain.FocusedRowHandle, "F_ID").ToString() + "'") == 0)
               gvMain.DeleteRow(gvMain.FocusedRowHandle);
        }

        private void sbPsw_Click(object sender, EventArgs e)
        {
            if (gvMain.FocusedRowHandle < 0) return;
            string strID = gvMain.GetRowCellValue(gvMain.FocusedRowHandle, "F_ID").ToString();
            string strName = gvMain.GetRowCellValue(gvMain.FocusedRowHandle, "F_Name").ToString();
            frmPsw myPsw = new frmPsw();
            myPsw.lbUser.Text = strID + "(" + strName + ")";
            myPsw.strID = strID;
            myPsw.ShowDialog();
            myPsw.Dispose();
        }
    }
}

