using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Report
{
    public partial class frmSupplierReport : Common.frmReport
    {
        public frmSupplierReport()
        {
            InitializeComponent();
            btnGraphi.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        /// <summary>
        /// Í¼±í
        /// </summary>
        protected override void Graphi()
        {
            if (gcReport.DataSource == null) return;
            DataTable dt = ((DataView)gcReport.DataSource).Table;

            Common.frmGraphi myGraphi = new Common.frmGraphi();
            myGraphi.dtGraphi = dt;
            myGraphi.ArgField = "F_Name";
            myGraphi.ValueField = "F_TotalMoney";
            myGraphi.TitleText = this.Text;
            myGraphi.ShowDialog();
            myGraphi.Dispose();
        }

        protected override void SelectIndexChange()
        {
            if (gvReport.FocusedRowHandle < 0)
            {
                strValue = "";
            }
            else
            {
                if (rgOption.SelectedIndex == 1)
                {
                    DataRow dr = gvReport.GetDataRow(gvReport.FocusedRowHandle);
                    strValue = dr["F_ID"].ToString();
                }
            }
            base.SelectIndexChange();
        }
    }
}

