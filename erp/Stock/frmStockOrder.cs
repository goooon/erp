using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Stock
{
    public partial class frmStockOrder : Common.frmBill
    {
        public frmStockOrder()
        {
            InitializeComponent();
            if (DataLib.SysVar.GetParmValue("F_N17")) bMultCheck = true;
            lupControl1.LookUpControl.Properties.AutoSearchColumnIndex = 2;
            lupControl1.LookUpControl.Properties.SortColumnIndex = 2;
            lupControl1.LookUpControl.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            btnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnUnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barMemo.Caption = "Ctrl+B:条码录入;F2:供应商供货历史";
        }

        protected override void LoadBill()
        {
            if (this.DesignMode == false)
            {
                if (DataLib.SysVar.GetParmValue("F_N44"))
                {
                    if (lupControl1.GetValue() == DBNull.Value)
                    {
                        MessageBox.Show("请选择供应商!!", "提示");
                        lupControl1.Focus();
                        return;
                    }
                    this.blnSlaverFlag = true;
                    this.strValue = lupControl1.GetValue().ToString();
                }
                base.LoadBill();
            }
        }

        private void SetDropSource()
        {
            DataSet ds;
            string strSQL;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            strSQL = "select F_ID,F_Name,dbo.fn_GetPy(F_Name) as F_Spell from t_Supplier";
            ds = myHelper.GetDs(strSQL);
            lupControl1.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_ID";
            ds.Dispose();

            strSQL = strSQL = "select F_ID,F_Name from t_Class where left(F_UPID,2) like '03%'";
            ds = myHelper.GetDs(strSQL);
            lupControl2.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl2.LookUpDisplayField = "F_Name";
            lupControl2.LookUpKeyField = "F_ID";
            ds.Dispose();
        }

        private void frmStockOrder_Load(object sender, EventArgs e)
        {
           
        }

        private void frmStockOrder_KeyDown(object sender, KeyEventArgs e)
        {
            //供应商供货历史
            if (e.KeyCode == Keys.F2)
            {
                if (lupControl1.GetValue() == DBNull.Value)
                {
                    MessageBox.Show(this, "请先选择供应商!!", "提示");
                    return;
                }

                frmSupplierHistoryReport mySupplierHistoryReport = new frmSupplierHistoryReport();
                mySupplierHistoryReport.strSupplierID = lupControl1.GetValue().ToString();
                mySupplierHistoryReport.ShowDialog();
                mySupplierHistoryReport.Dispose();
            }
        }

        private void frmStockOrder_Shown(object sender, EventArgs e)
        {
            if (this.DesignMode == false)
            {
                strBillFlag = "CD";
                strMTable = "t_StockOrder";
                strMasterSQL = "select * from t_StockOrder where F_BillID = @Value";

                strSlaverSQL = "select a.*,b.F_Name as F_ItemName,b.F_Spec,b.F_Material,(select F_Name from t_Class where F_ID = b.F_Type) as F_Type ";
                strSlaverSQL = strSlaverSQL + "from t_StockOrderDetail a,t_Item b ";
                strSlaverSQL = strSlaverSQL + "where a.F_ItemID = b.F_ID ";
                strSlaverSQL = strSlaverSQL + "and F_BillID = @Value";

                strSaveSlaverSQL = "select * from t_StockOrderDetail where F_BillID = @Value";

                SetDropSource();

                if (strBillID == "")
                    NewBill();
                else
                    BindData();
            }
        }

    }
}

