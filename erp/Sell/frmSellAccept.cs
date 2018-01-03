using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sell
{
    public partial class frmSellAccept : Common.frmBill
    {
        public frmSellAccept()
        {
            InitializeComponent();
            if (DataLib.SysVar.GetParmValue("F_N25")) bMultCheck = true;
            blnBarCode = false;
            barMemo.Caption = "";
            this.btnLoadBill.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            this.btnAddRow.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnBalance.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        /// <summary>
        /// 重写新单方法
        /// </summary>
        public override void NewBill()
        {
            base.NewBill();
            DataRow dr = ((DataRowView)binMaster.Current).Row;
            dr["F_Kind"] = "应收款";
            dr["F_AcceptType"] = "现金";
            binMaster.EndEdit();
        }

        /// <summary>
        /// 调用记帐凭证
        /// </summary>
        /// <returns></returns>
        protected override bool GenBalance()
        {
            if (base.GenBalance() == false) return false;
            Finance.frmCertificate myCertificate = new Finance.frmCertificate();
            myCertificate.dtDes = ((DataView)binMaster.DataSource).Table;
            myCertificate.DataBind();
            myCertificate.GenCertificate(6);
            myCertificate.ShowDialog();
            myCertificate.Dispose();
            return true;
        }

        /// <summary>
        /// 调单
        /// </summary>
        protected override void LoadBill()
        {
            if (TestRight("调单") == false) return;
            if (lupControl1.GetValue() == DBNull.Value)
            {
                MessageBox.Show("请选择客户!!", "提示");
                lupControl1.Focus();
                return;
            }
            this.strValue = lupControl1.GetValue().ToString();

            frmAcceptImport myAcceptImport = new frmAcceptImport();
            myAcceptImport.dtDes = ((DataView)binSlaver.DataSource).Table;
            myAcceptImport.strValue = this.strValue;
            myAcceptImport.ShowDialog();
            myAcceptImport.Dispose();

            //base.LoadBill();
        }

        /// <summary>
        /// 下拉数据源绑定
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

            strSQL = "select * from t_assist where F_Type = '收付款方式'";
            ds = myHelper.GetDs(strSQL);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cbControl2.AddItem(dr["F_Name"]);
            }
            ds.Dispose();
        }

        /// <summary>
        /// 自动收款 
        /// </summary>
        private void Auto()
        {
            int intCnt = gvList.RowCount;
            for (int i = 0; i < intCnt; i++)
            {
                DataRow dr = gvList.GetDataRow(i);
                dr["F_ThisMoney"] = dr["F_NoMoney"];

                if (dr["F_Tag"].ToString() != "送货单" && dr["F_Tag"].ToString() != "期初")
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

        private void frmSellAccept_Load(object sender, EventArgs e)
        {
          
        }

        private void sbAuto_Click(object sender, EventArgs e)
        {
            Auto();
        }

        protected override void GridDbClick()
        {
            if (gvList.FocusedRowHandle < 0) return;
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            Sell.frmSellOut myStockIn = new Sell.frmSellOut();
            myStockIn.strBillID = dr["F_LinkBill"].ToString();
            myStockIn.ShowDialog();
            myStockIn.Dispose();
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


                if (dr["F_Tag"].ToString() != "送货单")
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
                if (dr["F_Tag"].ToString() != "送货单")
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

        private void frmSellAccept_Shown(object sender, EventArgs e)
        {
            strBillFlag = "SA";
            strMTable = "t_Accept";
            strMasterSQL = "select * from t_Accept where F_BillID = @Value";

            strSlaverSQL = "select *,";
            strSlaverSQL = strSlaverSQL + "(case F_Tag when '送货单' then F_BillMoney when '期初' then F_BillMoney else - F_BillMoney end) as F_BillMoney1,";
            strSlaverSQL = strSlaverSQL + "(case F_Tag when '送货单' then F_HasMoney when '期初' then F_HasMoney else - F_HasMoney end) as F_HasMoney1,";
            strSlaverSQL = strSlaverSQL + "(case F_Tag when '送货单' then F_NoMoney when '期初' then F_NoMoney else - F_NoMoney end) as F_NoMoney1,";
            strSlaverSQL = strSlaverSQL + "(case F_Tag when '送货单' then F_ThisMoney when '期初' then F_ThisMoney else - F_ThisMoney end) as F_ThisMoney1,";
            strSlaverSQL = strSlaverSQL + "(case F_Tag when '送货单' then F_DisMoney when '期初' then F_DisMoney else - F_DisMoney end) as F_DisMoney1 ";
            strSlaverSQL = strSlaverSQL + "from t_AcceptDetail where F_BillID = @Value ";

            strSaveSlaverSQL = "select * from t_AcceptDetail where F_BillID = @Value";

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

