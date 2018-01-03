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
    public partial class frmStockYearReport : Common.frmReport
    {
        public frmStockYearReport()
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
            myGraphi.ArgField = "F_Month";
            myGraphi.ValueField = "F_Money";
            myGraphi.TitleText = this.Text;
            myGraphi.ShowDialog();
            myGraphi.Dispose();
        }


        protected override Hashtable GetParm()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Date", Convert.ToDateTime(deMonth.EditValue));
            /*
            DataLib.JxcService.SqlParameter[] parm =
                    {     
                        new   DataLib.JxcService.SqlParameter()
                    };

            parm[0].ParameterName = "@Date";
            parm[0].SqlDbType = DataLib.JxcService.SqlDbType.DateTime;
            parm[0].Value = Convert.ToDateTime(deMonth.EditValue);
            */
            return parm;
        }

        private void frmStorageSum_Load(object sender, EventArgs e)
        {
            deMonth.EditValue = DateTime.Today;
            //this.dtValue = Convert.ToDateTime(deMonth.EditValue);
        }

        private void sbRefresh_Click(object sender, EventArgs e)
        {
            //this.dtValue = Convert.ToDateTime(deMonth.EditValue);
            this.BindData();
        }

    }
}

