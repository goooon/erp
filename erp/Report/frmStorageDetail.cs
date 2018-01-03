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
    public partial class frmStorageDetail : Common.frmReport
    {
        public frmStorageDetail()
        {
            InitializeComponent();
        }

        protected override Hashtable GetParm()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            parm.Add("@sKind", cbType.Text);
            return parm;
        }

       
        private void frmStorageSum_Load(object sender, EventArgs e)
        {
            
            //this.dtValue = Convert.ToDateTime(deMonth.EditValue);
            //this.strItemType = cbType.Text;
        }

        private void sbRefresh_Click(object sender, EventArgs e)
        {

            
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}

