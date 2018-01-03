using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Stock
{
    public partial class frmSupplierHistoryReport : Common.frmReport
    {
        public string strSupplierID = "";
        public frmSupplierHistoryReport()
        {
            InitializeComponent();
        }

        protected override Hashtable GetParm()
        {

            Hashtable parm = new Hashtable();
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            parm.Add("@SupplierID", strSupplierID);
            //return base.GetParm2();
            /*
            DataLib.JxcService.SqlParameter[] parm =
                    {     
                       new   DataLib.JxcService.SqlParameter(),   
                       new   DataLib.JxcService.SqlParameter(),
                       new   DataLib.JxcService.SqlParameter()
                    };

            parm[0].ParameterName = "@Start";
            parm[0].SqlDbType = DataLib.JxcService.SqlDbType.DateTime;
            parm[0].Value = ucDate.dtStart;

            parm[1].ParameterName = "@End";
            parm[1].SqlDbType = DataLib.JxcService.SqlDbType.DateTime;
            parm[1].Value = ucDate.dtEnd;

            parm[2].ParameterName = "@ClientID";
            parm[2].SqlDbType = DataLib.JxcService.SqlDbType.VarChar;
            parm[2].Value = strClientID;
            */
            return parm;
        }
    }
}

