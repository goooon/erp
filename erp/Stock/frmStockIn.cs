using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Stock
{
    public partial class frmStockIn : Common.frmBill
    {
        public frmStockIn()
        {
            InitializeComponent();
            if (DataLib.SysVar.GetParmValue("F_N18")) bMultCheck = true;
            lupControl1.LookUpControl.Properties.AutoSearchColumnIndex = 2;
            lupControl1.LookUpControl.Properties.SortColumnIndex = 2;
            lupControl1.LookUpControl.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            btnBalance.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnUnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barMemo.Caption = "Ctrl+B:条码录入;F2:供应商供货历史";
        }

        protected override void LoadBill()
        {
            if (DataLib.SysVar.GetParmValue("F_N44"))
            {
                if (lupControl1.GetValue() == DBNull.Value)
                {
                    MessageBox.Show("请选择供应商!!", "提示");
                    lupControl1.Focus();
                    return;
                }
                this.strValue = lupControl1.GetValue().ToString();
            }
            base.LoadBill();
        }

        private bool CheckRate(DataTable dt)
        {

            decimal decRate = DataLib.SysVar.GetDecParmValue("F_C3");
            if (decRate == 0) return true;

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["F_LinkBill"] == DBNull.Value) return true;
                DataLib.DataHelper myHelper = new DataLib.DataHelper();
                DataSet ds = myHelper.GetDs("select isnull(F_Qty,0) as F_Qty from t_StockOrderDetail where F_BillID = '"+dr["F_LinkBill"].ToString()+"' and Aid = "+dr["PAid"].ToString());
                if (ds.Tables[0].Rows[0][0] == DBNull.Value) return true;

                decimal decQty = Convert.ToDecimal(dr["F_Qty"]) - Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
                if ((decQty / Convert.ToDecimal(ds.Tables[0].Rows[0][0])) * 100 > 5)
                {
                    MessageBox.Show(this, "物料[" + dr["F_ItemID"].ToString() + "]超过了订单数的" + decRate.ToString()+"%!", "提示");
                    return false;
                }

                return true;
            }
            return false;

        }

        protected override bool SavePre()
        {
            if (base.SavePre() == false) return false;

            DataTable dt = ((DataView)binSlaver.DataSource).Table;

            return CheckRate(dt);

        }

        protected override bool GenBalance()
        {
            if (base.GenBalance() == false) return false;
            Finance.frmCertificate myCertificate = new Finance.frmCertificate();
            myCertificate.dtDes = ((DataView)binMaster.DataSource).Table;
            myCertificate.DataBind();
            myCertificate.GenCertificate(1);
            myCertificate.ShowDialog();
            myCertificate.Dispose();
            return true;
        }

        public override void NewBill()
        {
            base.NewBill();
            DataRow dr = ((DataRowView)binMaster.Current).Row;
            dr["F_StockTime"] = DateTime.Today;
            dr["F_PayDate"] = DateTime.Today;
            binMaster.EndEdit();
        }

        private void SetDropSource()
        {
            string strSQL = "select F_ID,F_Name,dbo.fn_GetPy(F_Name) as F_Spell from t_Supplier";
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

            strSQL = strSQL = "select F_ID,F_Name from t_Class where left(F_UPID,2) like '03%'";
            ds = myHelper.GetDs(strSQL);
            lupControl2.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl2.LookUpDisplayField = "F_Name";
            lupControl2.LookUpKeyField = "F_ID";
            ds.Dispose();

            strSQL = strSQL = "select F_ID,F_Name from t_Emp";
            ds = myHelper.GetDs(strSQL);
            lupControl3.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl3.LookUpDisplayField = "F_Name";
            lupControl3.LookUpKeyField = "F_ID";
            ds.Dispose();
        }

        private void frmStockOrder_Load(object sender, EventArgs e)
        {
          
        }

        private void frmStockIn_KeyDown(object sender, KeyEventArgs e)
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


        private void frmStockIn_Shown(object sender, EventArgs e)
        {
            strBillFlag = "SI";
            strMTable = "t_StockIn";
            strMasterSQL = "select * from t_StockIn where F_BillID = @Value";

            strSlaverSQL = "select a.*,b.F_Name as F_ItemName,b.F_Spec,b.F_Brand,b.F_Material,(select F_Name from t_Class where F_ID = b.F_Type) as F_Type ";
            strSlaverSQL = strSlaverSQL + "from t_StockInDetail a,t_Item b ";
            strSlaverSQL = strSlaverSQL + "where a.F_ItemID = b.F_ID ";
            strSlaverSQL = strSlaverSQL + "and F_BillID = @Value";

            strSaveSlaverSQL = "select * from t_StockInDetail where F_BillID = @Value";

            SetDropSource();

            if (strBillID == "")
                NewBill();
            else
                BindData();
        }

    }
}

