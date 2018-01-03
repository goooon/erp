using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sell
{
    public partial class frmSellPrice : Common.frmBill
    {
        private decimal decTaxRate = Convert.ToDecimal(17.0);
        public frmSellPrice()
        {
            InitializeComponent();
            if (DataLib.SysVar.GetParmValue("F_N21")) bMultCheck = true;
            btnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnUnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        /// <summary>
        /// 绑定下拉数据源
        /// </summary>
        private void SetDropSource()
        {
            string strSQL = "select F_ID,F_Name from t_Client";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupControl1.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_ID";
            ds.Dispose();

            strSQL = "select F_ID,F_Name from t_BalanceType";
            ds = myHelper.GetDs(strSQL);
            lupControl4.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl4.LookUpDisplayField = "F_Name";
            lupControl4.LookUpKeyField = "F_ID";
            ds.Dispose();

            strSQL = "select F_ID,F_Name from t_Assist where F_Type = '送货方式'";
            ds = myHelper.GetDs(strSQL);
            lupControl2.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl2.LookUpDisplayField = "F_Name";
            lupControl2.LookUpKeyField = "F_ID";
            ds.Dispose();

            decTaxRate = DataLib.SysVar.GetDecParmValue("F_C2");
        }

        /// <summary>
        /// 新增单据
        /// </summary>
        public override void NewBill()
        {
            base.NewBill();
            DataRow dr = ((DataRowView)binMaster.Current).Row;
            dr["F_ReCheck"] = false;
            dr["F_ReCheckMan"] = "";
            dr["F_ReCheckDate"] = Convert.ToDateTime("1900-1-1");
            binMaster.EndEdit();
        }

        private void frmStockOrder_Load(object sender, EventArgs e)
        {
           
        }

        protected override void CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            base.CellValueChanged(sender, e);
            if (e.Column.FieldName == "F_Price")
            {
                DataRow dr = gvList.GetDataRow(e.RowHandle);
                dr["F_cPrice"] = e.Value;
            }
        }

        protected override void SlaverNewRow(object Sender, DataTableNewRowEventArgs e)
        {
            base.SlaverNewRow(Sender, e);
            DataTable dt = e.Row.Table;
            e.Row["F_Rate"] = 100;
              if (dt.Columns.Contains("F_TaxRate") != false)   //默认税率
                  e.Row["F_TaxRate"] = decTaxRate;

        }

        private void frmSellPrice_Shown(object sender, EventArgs e)
        {
            if (this.DesignMode == true) return;
            strBillFlag = "PC";
            strMTable = "t_SellPrice";
            strMasterSQL = "select * from t_SellPrice where F_BillID = @Value";

            strSlaverSQL = "select a.*,b.F_Name as F_ItemName,b.F_Spec,b.F_Brand,b.F_Material ";
            strSlaverSQL = strSlaverSQL + "from t_SellPriceDetail a,t_Item b ";
            strSlaverSQL = strSlaverSQL + "where a.F_ItemID = b.F_ID ";
            strSlaverSQL = strSlaverSQL + "and F_BillID = @Value";

            strSaveSlaverSQL = "select * from t_SellPriceDetail where F_BillID = @Value";

            SetDropSource();

            if (strBillID == "")
                NewBill();
            else
                BindData();
        }

    }
}

