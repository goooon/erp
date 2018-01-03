using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class frmMultCheck : BaseClass.frmBase
    {
        public frmMultCheck()
        {
            InitializeComponent();
            BindCheckMan();
            DataBind(comboBoxEdit2.Text);
        }

        private void BindCheckMan()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select F_ID,F_Name from t_User");
            lookUpEdit2.Properties.DataSource = ds.Tables[0];
            lookUpEdit2.Properties.ValueMember = "F_ID";
            lookUpEdit2.Properties.DisplayMember = "F_Name";
        }

        private void DataBind(string sBillType)
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select a.*,b.F_Name as F_Man from t_MultCheck a,t_User b where a.F_CheckMan = b.F_ID and a.F_BillType = '"+sBillType+"'");
            gridCheck.DataSource = ds.Tables[0];
        }

        private void Add(object sender,EventArgs e)
        {
            if (comboBoxEdit1.SelectedIndex < 0)
            {
                MessageBox.Show(this,"请选择审核步骤!","提示");
                return;
            }

            if (lookUpEdit2.EditValue == DBNull.Value)
            {
                MessageBox.Show(this, "请选择审核人!", "提示");
                return;
            }

            if (comboBoxEdit3.SelectedIndex < 0)
            {
                MessageBox.Show(this, "请选择下一步!", "提示");
                return;
            }

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            string sSQL = string.Format("insert into t_MultCheck(F_BillType,F_CheckLevel,F_CheckMan,F_NextLevel) values('{0}',{1},'{2}',{3})",comboBoxEdit2.Text,comboBoxEdit1.Text,lookUpEdit2.EditValue,comboBoxEdit3.Text);
            if (myHelper.ExecuteSQL(sSQL) == 0)
            {
                DataBind(comboBoxEdit2.Text);
            }
        }

        private void Remove(object sender, EventArgs e)
        {
            if (viewCheck.FocusedRowHandle < 0) return;
            if (MessageBox.Show(this, "真的要移除选定的步骤吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataRow dr = viewCheck.GetDataRow(viewCheck.FocusedRowHandle);
            if (myHelper.ExecuteSQL("delete from t_MultCheck where Aid = "+dr["Aid"].ToString()) == 0)
            {
                DataBind(comboBoxEdit2.Text);
            }
        }

        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataBind(comboBoxEdit2.Text);
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxEdit3.Properties.Items.Clear();

            for (int i = Convert.ToInt32(comboBoxEdit1.Text) + 1; i <= 6; i++)
            {
                comboBoxEdit3.Properties.Items.Add(i.ToString());
            }

            comboBoxEdit3.Properties.Items.Add("-1");
        }
    }
}
