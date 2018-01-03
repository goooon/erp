using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sell
{
    public partial class frmEditClientFee : Common.frmDialog
    {
        private string strSQL;
        public frmEditClientFee()
        {
            InitializeComponent();
            blnNew = true;
            strNoCopyField = "Aid";
        }

        private void SetDropSource()
        {
            string strSQL = "select F_ID,F_Name from t_Client";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsType = myHelper.GetDs(strSQL);
            lupControl1.LookUpDataSource = dsType.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_ID";
        }

        public override void New()
        {
            base.New();
            strSQL = "select * from t_ClientFee where Aid = 0";
            if (blnBind == false)
                BindData();
            DataRow dr = ((DataRowView)binData.AddNew()).Row;
            dr.BeginEdit();
            //dr["F_ID"] = GetMaxCode("客户资料", "t_Client");
            //dr["F_Type"] = strType;
            dr["F_Date"] = DataLib.SysVar.GetDate();
            //dr["F_Builder"] = DataLib.SysVar.strUName;
            dr.EndEdit();
            binData.EndEdit();
            editControl1.Focus();
        }

        public override void Edit(string strID)
        {
            //ckOption.Checked = false;
            base.Edit(strID);
            strSQL = "select * from t_ClientFee where Aid = " + strID;
            BindData();
        }

        protected override void BindData()
        {
            strSaveSlaverSQL = strSQL;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            binData.DataSource = ds.Tables[0].DefaultView;
            SetDropSource();
            base.BindData();
        }
    }
}
