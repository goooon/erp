using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Report
{
    public partial class frmOpertorReport : Common.frmReport
    {
        public frmOpertorReport()
        {
            InitializeComponent();
            btnGraphi.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        protected override Hashtable GetParm()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            if (DataLib.SysVar.strUGroup == "超级用户" && DataLib.SysVar.blnSaleMan == false)
                parm.Add("@BillMan", "");
            else
                parm.Add("@BillMan", DataLib.SysVar.strUID);

            return parm;
        }

        protected override Hashtable GetParm1()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            parm.Add("@Value", strValue);
            if (DataLib.SysVar.strUGroup == "超级用户" && DataLib.SysVar.blnSaleMan == false)
                parm.Add("@BillMan", "");
            else
                parm.Add("@BillMan", DataLib.SysVar.strUID);
            return parm;
        }

        /// <summary>
        /// 图表
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

