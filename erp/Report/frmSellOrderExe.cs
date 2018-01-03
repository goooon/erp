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
    public partial class frmSellOrderExe : Common.frmReport
    {
        public frmSellOrderExe()
        {
            InitializeComponent();
        }

        protected override Hashtable GetParm()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            parm.Add("@Kind", cbKind.Text);
            if (DataLib.SysVar.strUGroup == "≥¨º∂”√ªß" && DataLib.SysVar.blnSaleMan == false)
                parm.Add("@BillMan", "");
            else
                parm.Add("@BillMan", DataLib.SysVar.strUID);

            return parm;
        }

        private void cbKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}

