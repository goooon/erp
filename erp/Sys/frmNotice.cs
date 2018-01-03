using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class frmNotice : Common.frmBaseList
    {
        public frmNotice()
        {
            InitializeComponent();
            splitContainer1.Panel1Collapsed = true;
            btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            strTable = "t_Notice";
            strKey = "Aid";
            strQuerySQL = "select * from t_Notice";
        }

        protected override void New()
        {
            
            base.New();
            frmEditNotice myEditNotice = new frmEditNotice();
            myEditNotice.New();
            if (myEditNotice.ShowDialog() == DialogResult.OK)
                BindData();
            myEditNotice.Dispose();
             
        }

        protected override void Edit()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            
            base.Edit();
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            frmEditNotice myEditNotice = new frmEditNotice();
            myEditNotice.Edit(dr["Aid"].ToString());
            if (myEditNotice.ShowDialog() == DialogResult.OK)
                BindData();
            myEditNotice.Dispose();
             
        }

        protected override void Del()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Del();
            if (MessageBox.Show(this, "真的要删除本记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_Notice where AID = " + dr["Aid"].ToString()) == 0)
                gvBase.DeleteRow(gvBase.FocusedRowHandle);    
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            FillTv("05",null);
        }
    }
}

