using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sell
{
    public partial class frmReSellPrice : Common.frmBill
    {
        public frmReSellPrice()
        {
            InitializeComponent();
            btnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnUnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        private void SetDropSource()
        {
            string strSQL = "select F_ID,F_Name from t_Client";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupControl1.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_ID";
            ds.Dispose();
        }

        private void frmStockOrder_Load(object sender, EventArgs e)
        {
          

        }

        protected override bool Save(DataSet dsMaster, DataSet dsSlaver, DataSet dsUpdateSlaver)
        {
            if (base.Save(dsMaster, dsSlaver, dsUpdateSlaver) == true)
            {
                btnNew.Enabled = false;
                btnCopy.Enabled = false;
                return true;
            }
            else
                return false;
        }

        protected override void CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            base.CellValueChanged(sender, e);
            object decPrice, decRate;
            if (e.Column.FieldName == "F_Rate" || e.Column.FieldName == "F_Price")   
            {
                decPrice = gvList.GetRowCellValue(e.RowHandle, "F_Price");
                decRate = gvList.GetRowCellValue(e.RowHandle, "F_Rate");

                if (decPrice == DBNull.Value)
                    decPrice = 0;

                if (decPrice == DBNull.Value)
                    decRate = 100;

                gvList.SetRowCellValue(e.RowHandle,"F_cPrice",(Convert.ToDecimal(decPrice) * (1 + Convert.ToDecimal(decRate)/100)));
                gvList.CloseEditor();
            }
        }

        protected override void CheckBill()
        {
            //base.CheckBill();
            if (MessageBox.Show(this, "真的要审核本单吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("update " + strMTable + " set F_ReCheck = 1,F_ReCheckMan = '" + DataLib.SysVar.strUName + "',F_ReCheckDate = '" + DataLib.SysVar.GetDate().ToString() + "' where F_BillID = '" + editControl1.GetValue().ToString() + "'") == 0)
                SetStatus(3);
        }

        protected override void UnCheckBill()
        {
            //base.UnCheckBill();
            /*
            if (TestCheckOut() == true)
            {
                MessageBox.Show(this, "该月已结帐，不能反审该月单据!!", "提示");
                return;
            }*/
            if (MessageBox.Show(this, "真的要反审核本单吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("update " + strMTable + " set F_ReCheck = 0,F_ReCheckMan = '',F_ReCheckDate = '1900-1-1' where F_BillID = '" + editControl1.GetValue().ToString() + "'") == 0)
            {
                SetStatus(2);
                btnNew.Enabled = false;
                btnCopy.Enabled = false;
                panelControl1.Enabled = false;
            }

        }

        private void frmReSellPrice_Shown(object sender, EventArgs e)
        {
            strBillFlag = "PC";
            strMTable = "t_SellPrice";
            strMasterSQL = "select * from t_SellPrice where F_BillID = @Value";

            strSlaverSQL = "select a.*,b.F_Name as F_ItemName,b.F_Spec ";
            strSlaverSQL = strSlaverSQL + "from t_SellPriceDetail a,t_Item b ";
            strSlaverSQL = strSlaverSQL + "where a.F_ItemID = b.F_ID ";
            strSlaverSQL = strSlaverSQL + "and F_BillID = @Value";

            strSaveSlaverSQL = "select * from t_SellPriceDetail where F_BillID = @Value";

            SetDropSource();

            if (strBillID == "")
                NewBill();
            else
                BindData();


            DataRow dr = ((DataRowView)binMaster.Current).Row;

            if (Convert.ToBoolean(dr["F_ReCheck"]) == true)
                SetStatus(3);
            else
                SetStatus(2);

            btnNew.Enabled = false;
            btnCopy.Enabled = false;
            panelControl1.Enabled = false;
        }
    }
}

