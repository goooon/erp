using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class frmWakeNotice : BaseClass.frmBase
    {
        public frmWakeNotice()
        {
            InitializeComponent();
            BindNotice();
        }

        private void BindNotice()
        {
            string strSQL = "select * from t_Notice where F_Date >= '"+ucDate.dtStart.ToString()+"' and F_Date <= '"+ucDate.dtEnd.ToString()+"'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gridNotice.DataSource = ds.Tables[0];
        }

        private void viewNotice_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = viewNotice.GetDataRow(e.FocusedRowHandle);
            memoEdit1.Text = dr["F_Memo"].ToString();
        }

        private void ucDate_RefreshDateChanged(object sender, EventArgs e)
        {
            BindNotice();
        }
    }
}
