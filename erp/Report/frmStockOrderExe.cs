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
    public partial class frmStockOrderExe : Common.frmReport
    {
        public frmStockOrderExe()
        {
            InitializeComponent();
        }

        protected override Hashtable GetParm()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            parm.Add("@Kind", cbKind.Text);
            return parm;
        }

        private void cbKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}

