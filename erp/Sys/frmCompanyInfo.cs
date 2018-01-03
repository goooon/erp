using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class frmCompanyInfo : Common.frmDialog
    {
        private string strSQL;
        public frmCompanyInfo()
        {
            InitializeComponent();
        }

        public override void Edit(string strID)
        {
            base.Edit(strID);
            if (Convert.ToBoolean(ckUse.EditValue) == true)
                ckUse.Visible = false;
            strSQL = "select * from t_CompanyInfo";
            BindData();
        }

        protected override void BindData()
        {
            strSaveSlaverSQL = strSQL;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            binData.DataSource = ds.Tables[0].DefaultView;

            picLogo.DataBindings.Add("EditValue",binData,"F_Pic");
            ckUse.DataBindings.Add("EditValue", binData, "F_Use");
            
            base.BindData();
            if (ds.Tables[0].Rows.Count > 0)
               if (Convert.ToBoolean(ds.Tables[0].Rows[0]["F_Use"]) == true) ckUse.Enabled = false;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            DataLib.SysVar.blnInit = Convert.ToBoolean(ckUse.EditValue);
        }
    }
}

