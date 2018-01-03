using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Report
{
    public partial class frmSequence : Common.frmReport
    {
        public frmSequence()
        {
            InitializeComponent();
            bNormal = true;
        }

        protected override Hashtable GetParm()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            parm.Add("@Value", txtItem.Text);
            /*
            DataLib.JxcService.SqlParameter[] parm =
                    {     
                       new   DataLib.JxcService.SqlParameter(),   
                       new   DataLib.JxcService.SqlParameter()
                    };

            parm[0].ParameterName = "@ItemID";
            parm[0].SqlDbType = DataLib.JxcService.SqlDbType.VarChar;
            parm[0].Value = txtItem.Text;

            parm[1].ParameterName = "@Date";
            parm[1].SqlDbType = DataLib.JxcService.SqlDbType.DateTime;
            parm[1].Value = Convert.ToDateTime(dtMonth.EditValue);
            */
            return parm;
        }

        private void sbRefresh_Click(object sender, EventArgs e)
        {
            if (txtItem.Text.Length == 0)
            {
                MessageBox.Show("请先选择物料!!", "提示");
                sbSelect.Focus();
                return;
            }
            BindData();
        }

        private void sbSelect_Click(object sender, EventArgs e)
        {
            DataRow dr;
            Common.frmSelItem mySelItem = new Common.frmSelItem();
            mySelItem.sbAdd.Visible = false;
            if (mySelItem.ShowDialog() == DialogResult.OK)
            {
                if (mySelItem.TabControl.SelectedTabPageIndex == 0)
                    dr = mySelItem.gvMain.GetDataRow(mySelItem.gvMain.FocusedRowHandle);
                else
                    dr = mySelItem.gvStore.GetDataRow(mySelItem.gvStore.FocusedRowHandle);

                txtItem.Text = dr["F_ID"].ToString();

            }
            mySelItem.Dispose();
        }

        private void frmSequence_Load(object sender, EventArgs e)
        {
           
        }

    }
}

