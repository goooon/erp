using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class frmBalanceType : BaseClass.frmBase
    {
        public frmBalanceType()
        {
            InitializeComponent();
        }

        private void BindData()
        {
            string strSQL = "select * from t_BalanceType";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            binMain.DataSource = ds.Tables[0].DefaultView;

            txtID.DataBindings.Add("EditValue", binMain, "F_ID");
            txtName.DataBindings.Add("EditValue", binMain, "F_Name");
            spMonth.DataBindings.Add("EditValue", binMain, "F_PayMonth");
            spDay.DataBindings.Add("EditValue", binMain, "F_PayDay");
            txtRemark.DataBindings.Add("EditValue", binMain, "F_Remark");
            rgOption.DataBindings.Add("EditValue", binMain, "F_Type");
            spValue.DataBindings.Add("EditValue", binMain, "F_Date");
        }

        /// <summary>
        /// 新增
        /// </summary>
        private void New()
        {
            DataRow dr = ((DataRowView)binMain.AddNew()).Row;
            dr["F_Type"] = 0;
        }

        /// <summary>
        /// 保存
        /// </summary>
        private void Save()
        {
            if (txtID.Text.Length == 0)
            {
                MessageBox.Show(this,"编号不能为空!!", "提示");
                txtID.Focus();
                return;
            }

            if (txtID.Text.Length == 0)
            {
                MessageBox.Show(this, "名称不能为空!!", "提示");
                txtID.Focus();
                return;
            }

            DataSet ds = ((DataView)binMain.DataSource).Table.DataSet;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.SaveData(ds, "select * from t_BalanceType") == 0)
            {
                MessageBox.Show(this, "数据保存成功!!", "提示");
                ds.AcceptChanges();
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void Del()
        {
            if (gvMain.FocusedRowHandle < 0) return;
            if (MessageBox.Show(this, "真的删除选定记录吗?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataRow dr = gvMain.GetDataRow(gvMain.FocusedRowHandle);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_BalanceType where F_ID = '" + dr["F_ID"].ToString() + "'") == 0)
                gvMain.DeleteRow(gvMain.FocusedRowHandle);
        }

        private void frmBalanceType_Shown(object sender, EventArgs e)
        {
            BindData();
        }

        private void tsClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            New();
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void tsDelRow_Click(object sender, EventArgs e)
        {
            Del();
        }

        private void rgOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rgOption.SelectedIndex == 3)
                spValue.Enabled = true;
            else
                spValue.Enabled = false;
        }
    }
}

