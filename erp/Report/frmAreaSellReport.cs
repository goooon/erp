using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Report
{
    public partial class frmAreaSellReport : Common.frmReport
    {
        public frmAreaSellReport()
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
            myGraphi.ValueField = "F_Money";
            myGraphi.TitleText = this.Text;
            myGraphi.ShowDialog();
            myGraphi.Dispose();
        }

    }
}

