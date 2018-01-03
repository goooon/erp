using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Stock
{
    public partial class frmStockPay : Common.frmBill
    {
        public frmStockPay()
        {
            InitializeComponent();
            if (DataLib.SysVar.GetParmValue("F_N19")) bMultCheck = true;
            blnBarCode = false;
            barMemo.Caption = "";
            this.btnLoadBill.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            this.btnAddRow.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnBalance.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        protected override bool GenBalance()
        {
            if (base.GenBalance() == false) return false;
            Finance.frmCertificate myCertificate = new Finance.frmCertificate();
            myCertificate.dtDes = ((DataView)binMaster.DataSource).Table;
            myCertificate.DataBind();
            myCertificate.GenCertificate(3);
            myCertificate.ShowDialog();
            myCertificate.Dispose();
            return true;
        }

        public override void NewBill()
        {
            base.NewBill();
            DataRow dr = ((DataRowView)binMaster.Current).Row;
            dr["F_Kind"] = "应付款";
            dr["F_PayType"] = "现金";
            binMaster.EndEdit();
        }

        protected override void LoadBill()
        {
            if (TestRight("调单") == false) return;
            if (lupControl1.GetValue() == DBNull.Value)
            {
                MessageBox.Show("请选择供应商!!", "提示");
                lupControl1.Focus();
                return;
            }
            this.strValue = lupControl1.GetValue().ToString();
            frmPayImport myPayImport = new frmPayImport();
            myPayImport.dtDes = ((DataView)binSlaver.DataSource).Table;
            myPayImport.strValue = this.strValue;
            myPayImport.ShowDialog();
            myPayImport.Dispose();
            //base.LoadBill();
        }

        protected override void GridDbClick()
        {
            if (gvList.FocusedRowHandle < 0) return;
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            Stock.frmStockIn myStockIn = new Stock.frmStockIn();
            myStockIn.strBillID = dr["F_LinkBill"].ToString();
            myStockIn.ShowDialog();
            myStockIn.Dispose();
        }

        private void SetDropSource()
        {
            string strSQL = "select F_ID,F_Name from t_Supplier";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupControl1.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_ID";
            ds.Dispose();

            strSQL = "select * from t_assist where F_Type = '收付款方式'";
            ds = myHelper.GetDs(strSQL);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cbControl2.AddItem(dr["F_Name"]);
            }
            ds.Dispose();

        }

        private void frmStockOrder_Load(object sender, EventArgs e)
        {
          
        }


        /// <summary>
        /// 自动付款 
        /// </summary>
        private void Auto()
        {
            /*
            int intCnt = gvList.RowCount;
            for (int i = 0; i < intCnt; i++)
            {
                DataRow dr = gvList.GetDataRow(i);
                dr["F_ThisMoney"] = dr["F_NoMoney"];
                dr["F_Flag"] = true;
                dr.EndEdit();
            }
            */
            int intCnt = gvList.RowCount;
            for (int i = 0; i < intCnt; i++)
            {
                DataRow dr = gvList.GetDataRow(i);
                dr["F_ThisMoney"] = dr["F_NoMoney"];
                if (dr["F_Tag"].ToString() != "采购进货" && dr["F_Tag"].ToString() != "期初")
                    dr["F_ThisMoney1"] = -Convert.ToDecimal(dr["F_NoMoney"]);
                else
                    dr["F_ThisMoney1"] = dr["F_NoMoney"];
                dr["F_Flag"] = true;
                dr.EndEdit();
            }
            gvList.UpdateTotalSummary();
            DataRow drMaster = ((DataRowView)binMaster.Current).Row;
            drMaster.BeginEdit();
            drMaster["F_Money"] = gvList.Columns["F_ThisMoney1"].SummaryItem.SummaryValue;
            drMaster.EndEdit();
        }


        protected override void CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            base.CellValueChanging(sender, e);
            if (e.Column.FieldName == "F_Flag")
            {
                DataRow dr = gvList.GetDataRow(e.RowHandle);
                dr.BeginEdit();
                if (Convert.ToBoolean(e.Value) == true)
                    dr["F_ThisMoney"] = gvList.GetRowCellValue(e.RowHandle, "F_NoMoney");
                else
                    dr["F_ThisMoney"] = 0;
                dr.EndEdit();
                gvList.PostEditor();
            }
        }

        protected override void CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            base.CellValueChanged(sender, e);
            
            if (e.Column.FieldName == "F_ThisMoney")
            {
                gvList.BeginDataUpdate();
                DataRow dr = gvList.GetDataRow(e.RowHandle);
                dr.BeginEdit();

                if (e.Value == DBNull.Value)
                    dr["F_Flag"] = false;
                else
                    if (Convert.ToDecimal(e.Value) == 0)
                        dr["F_Flag"] = false;
                    else
                        dr["F_Flag"] = true;

                if (dr["F_Tag"].ToString() != "采购进货")
                {
                    if (e.Value == DBNull.Value)
                        dr["F_ThisMoney1"] = 0;
                    else
                        dr["F_ThisMoney1"] = -Convert.ToDecimal(e.Value);
                }
                else
                    dr["F_ThisMoney1"] = e.Value;
                dr.EndEdit();
                gvList.EndDataUpdate();
            }

            if (e.Column.FieldName == "F_DisMoney")
            {
                gvList.BeginDataUpdate();
                DataRow dr = gvList.GetDataRow(e.RowHandle);
                dr.BeginEdit();
                if (dr["F_Tag"].ToString() != "采购进货")
                {
                    if (e.Value == DBNull.Value)
                        dr["F_DisMoney1"] = 0;
                    else
                        dr["F_DisMoney1"] = -Convert.ToDecimal(e.Value);
                }
                else
                    dr["F_DisMoney1"] = e.Value;
                dr.EndEdit();
                gvList.EndDataUpdate();
            }
        }

        private void sbAuto_Click(object sender, EventArgs e)
        {
            Auto();
        }

        private void frmStockPay_Shown(object sender, EventArgs e)
        {
            strBillFlag = "SP";
            strMTable = "t_Pay";
            strMasterSQL = "select * from t_Pay where F_BillID = @Value";

            strSlaverSQL = "select *,";
            strSlaverSQL = strSlaverSQL + "(case F_Tag when '采购进货' then F_BillMoney when '期初' then F_BillMoney else - F_BillMoney end) as F_BillMoney1,";
            strSlaverSQL = strSlaverSQL + "(case F_Tag when '采购进货' then F_HasMoney when '期初' then F_HasMoney  else - F_HasMoney end) as F_HasMoney1,";
            strSlaverSQL = strSlaverSQL + "(case F_Tag when '采购进货' then F_NoMoney when '期初' then F_NoMoney else - F_NoMoney end) as F_NoMoney1,";
            strSlaverSQL = strSlaverSQL + "(case F_Tag when '采购进货' then F_ThisMoney when '期初' then F_ThisMoney else - F_ThisMoney end) as F_ThisMoney1,";
            strSlaverSQL = strSlaverSQL + "(case F_Tag when '采购进货' then F_DisMoney when '期初' then F_DisMoney else - F_DisMoney end) as F_DisMoney1 ";
            strSlaverSQL = strSlaverSQL + "from t_PayDetail where F_BillID = @Value ";

            strSaveSlaverSQL = "select * from t_PayDetail where F_BillID = @Value";

            SetDropSource();

            if (strBillID == "")
                NewBill();
            else
                BindData();

            gvList.Columns.ColumnByFieldName("F_BillMoney").SummaryItem.FieldName = "F_BillMoney1";
            gvList.Columns.ColumnByFieldName("F_HasMoney").SummaryItem.FieldName = "F_HasMoney1";
            gvList.Columns.ColumnByFieldName("F_NoMoney").SummaryItem.FieldName = "F_NoMoney1";
            gvList.Columns.ColumnByFieldName("F_ThisMoney").SummaryItem.FieldName = "F_ThisMoney1";
            gvList.Columns.ColumnByFieldName("F_DisMoney").SummaryItem.FieldName = "F_DisMoney1";
        }

    }
}

