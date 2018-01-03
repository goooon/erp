using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class frmSysLog : Common.frmReport
    {
        public frmSysLog()
        {
            InitializeComponent();
            btnDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //btnFilter.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        protected override void DataDel()
        {
            base.DataDel();
            frmDelLog myDelLog = new frmDelLog();
            if (myDelLog.ShowDialog() == DialogResult.OK)
            {
                DataLib.DataHelper myHeler = new DataLib.DataHelper();
                if (myDelLog.ckAll.Checked == true)
                {
                    if (myHeler.ExecuteSQL("truncate table t_UserLog") == 0)
                        BindData();
                }
                else
                {
                    string strStart = myDelLog.deStart.EditValue.ToString() + " 00:00:00";
                    string strEnd = myDelLog.deEnd.EditValue.ToString() + " 23:59:59";
                    if (myHeler.ExecuteSQL("delete from t_UserLog where F_Time >= '" + strStart + "' and F_Time <='" + strEnd + "'") == 0)
                        BindData();
                }
            }
            myDelLog.Dispose();
        }
    }
}

