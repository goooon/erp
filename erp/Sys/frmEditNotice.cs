using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class frmEditNotice : Common.frmDialog
    {
        private string strSQL;
        public frmEditNotice()
        {
            InitializeComponent();
        }


        public override void New()
        {
            base.New();
            strSQL = "select * from t_Notice where Aid = 0";
            BindData();

            DataRow dr = ((DataRowView)binData.AddNew()).Row;
            dr.BeginEdit();
            dr["F_Date"] = DateTime.Now;
            dr.EndEdit();
            binData.EndEdit();
        }

        public override void Edit(string strID)
        {
            base.Edit(strID);
            strSQL = "select * from t_Notice where Aid = " + strID ;
            BindData();
        }

        protected override void BindData()
        {
            strSaveSlaverSQL = strSQL;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            binData.DataSource = ds.Tables[0].DefaultView;
            base.BindData();
            meTxt.DataBindings.Add("EditValue", binData, "F_Memo");
        }
    }
}

