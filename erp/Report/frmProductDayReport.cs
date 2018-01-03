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
    public partial class frmProductDayReport : Common.frmReport
    {
        public frmProductDayReport()
        {
            InitializeComponent();
            lbTitle.BringToFront();
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

