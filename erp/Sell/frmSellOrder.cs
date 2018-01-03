using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sell
{
    public partial class frmSellOrder : Common.frmBill
    {
        private decimal decTaxRate = Convert.ToDecimal(17.0);
        public frmSellOrder()
        {
            InitializeComponent();
            if (DataLib.SysVar.GetParmValue("F_N22")) bMultCheck = true;
            lupControl1.LookUpControl.Properties.AutoSearchColumnIndex = 2;
            lupControl1.LookUpControl.Properties.SortColumnIndex = 2;
            lupControl1.LookUpControl.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            lupControl3.LookUpControl.Properties.AutoSearchColumnIndex = 2;
            lupControl3.LookUpControl.Properties.SortColumnIndex = 2;
            lupControl3.LookUpControl.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            btnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnUnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barMemo.Caption = "Ctrl+B:条码录入;F2:客户销售历史;F3:业务员销售历史;F10:查看产品附件;F11:查看本单附件";
        }

        /// <summary>
        /// 重写新增方法
        /// </summary>
        public override void NewBill()
        {
            base.NewBill();
            DataRow dr = ((DataRowView)binMaster.Current).Row;
            dr["F_Type"] = "销售发货出库";
            binMaster.EndEdit();
        }

   
        /// <summary>
        /// 调单
        /// </summary>
        protected override void LoadBill()
        {
            if (DataLib.SysVar.GetParmValue("F_N44"))
            {
                if (lupControl1.GetValue() == DBNull.Value)
                {
                    MessageBox.Show("请选择客户!!", "提示");
                    lupControl1.Focus();
                    return;
                }
                this.strValue = lupControl1.GetValue().ToString();
            }
            base.LoadBill();
        }

        /// <summary>
        /// 绑定下拉数据源
        /// </summary>
        private void SetDropSource()
        {
            string strSQL = "select F_ID,F_Name,dbo.fn_GetPy(F_Name) as F_Spell from t_Client";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
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

            strSQL = strSQL = "select F_ID,F_Name,dbo.fn_GetPy(F_Name) as F_Spell from t_Emp where isnull(F_Opertor,0) = 1";
            ds = myHelper.GetDs(strSQL);
            lupControl3.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl3.LookUpDisplayField = "F_Name";
            lupControl3.LookUpKeyField = "F_ID";
            ds.Dispose();

            strSQL = strSQL = "select F_ID,F_Name from t_CarryCompany";
            ds = myHelper.GetDs(strSQL);
            lupControl4.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl4.LookUpDisplayField = "F_Name";
            lupControl4.LookUpKeyField = "F_ID";
            ds.Dispose();

            strSQL = "select F_ID,F_Name from t_BalanceType";
            ds = myHelper.GetDs(strSQL);
            lupControl5.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl5.LookUpDisplayField = "F_Name";
            lupControl5.LookUpKeyField = "F_ID";
            ds.Dispose();

            decTaxRate = DataLib.SysVar.GetDecParmValue("F_C2");    //从参数表读取税率
        }

        protected override void ColumnChanged(object Sender, DataColumnChangeEventArgs e)
        {
            base.ColumnChanged(Sender, e);
            if (e.Column.ColumnName == "F_ItemID")
            {
                if (DataLib.SysVar.GetParmValue("F_N14") == true)
                {
                    SetOnePrice(e.ProposedValue.ToString());
                }
            }
        }

        protected override void CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            base.CellValueChanged(sender, e);
            if (e.Column.FieldName == "F_ItemID")
            {
                if (DataLib.SysVar.GetParmValue("F_N14") == true)
                {
                    SetOnePrice(e.Value.ToString());
                }
            }
        }

        private void SetOnePrice(string sItemID)
        {
            binMaster.EndEdit();
            DataRow drMaster = ((DataRowView)binMaster.Current).Row;
            DataRow drSlaver = ((DataRowView)binSlaver.Current).Row;
            drSlaver.BeginEdit();
            drSlaver["F_Price"] = DataLib.sysClass.GetSellPrice(drMaster["F_ClientID"].ToString(), sItemID);
            drSlaver.EndEdit();
            binSlaver.EndEdit();

        }

        private void SetAllPrice(string sClientID)
        {
            DataTable dt = ((DataView)binSlaver.DataSource).Table;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["F_ItemID"] == DBNull.Value) continue;
                dr.BeginEdit();
                dr["F_Price"] = DataLib.sysClass.GetSellPrice(sClientID, dr["F_ItemID"].ToString());
                dr.EndEdit();
            }
        }

        protected override void SlaverNewRow(object Sender, DataTableNewRowEventArgs e)
        {
            base.SlaverNewRow(Sender, e);
            DataTable dt = e.Row.Table;
            DataRow dr = e.Row;
            if (dt.Columns.Contains("F_TaxRate") != false)           //增行时默认税率
                dr["F_TaxRate"] = decTaxRate;
            
        }

        protected override void MasterColumnChanged(object Sender, DataColumnChangeEventArgs e)
        {
            base.MasterColumnChanged(Sender, e);
            if (e.Column.ColumnName == "F_ClientID")
            {
                DataLib.DataHelper myHelper = new DataLib.DataHelper();
                DataSet ds = myHelper.GetDs("select * from t_Client where F_ID = '"+e.ProposedValue.ToString()+"'");
                e.Row.BeginEdit();
                e.Row["F_LinkMan"] = ds.Tables[0].Rows[0]["F_LinkMan"].ToString();
                e.Row["F_LinkTel"] = ds.Tables[0].Rows[0]["F_Tel"].ToString();
                e.Row["F_Opertor"] = ds.Tables[0].Rows[0]["F_Opertor"].ToString();
                e.Row["F_CarryCompany"] = ds.Tables[0].Rows[0]["F_CarryCompany"].ToString();
                e.Row["F_CheckFlag"] = 0;
                e.Row.EndEdit();

                if (DataLib.SysVar.GetParmValue("F_N14") == true)
                {
                    SetAllPrice(e.ProposedValue.ToString());
                }
            }
        }

        private void frmStockOrder_Load(object sender, EventArgs e)
        {
          
        }

        private void frmSellOrder_KeyDown(object sender, KeyEventArgs e)
        {
            //客户销售历史
            if (e.KeyCode == Keys.F2)
            {
                if (lupControl1.GetValue() == DBNull.Value)
                {
                    MessageBox.Show(this, "请先选择客户!!", "提示");
                    return;
                }
                frmClientHistoryReport myClientHistoryReport = new frmClientHistoryReport();
                myClientHistoryReport.strClientID = lupControl1.GetValue().ToString();
                myClientHistoryReport.ShowDialog();
                myClientHistoryReport.Dispose();
            }

            //业务员销售历史
            if (e.KeyCode == Keys.F3)
            {
                if (lupControl3.GetValue() == DBNull.Value)
                {
                    MessageBox.Show(this, "请先选择业务员!!", "提示");
                    return;
                }
                frmEmpHistoryReport myEmpHistoryReport = new frmEmpHistoryReport();
                myEmpHistoryReport.strEmpID = lupControl3.GetValue().ToString();
                myEmpHistoryReport.ShowDialog();
                myEmpHistoryReport.Dispose();
            }

            //查看产品附件
            if (e.KeyCode == Keys.F10)
            {
                if (binSlaver.Position < 0) return;
                DataRow dr = ((DataRowView)binSlaver.Current).Row;
                Common.frmViewFile myViewFile = new Common.frmViewFile();
                myViewFile.sItemID = dr["F_ItemID"].ToString();
                myViewFile.sItemName = dr["F_ItemName"].ToString();
                myViewFile.ShowDialog();
                myViewFile.Dispose();
            }

            if (e.KeyCode == Keys.F11)
            {
                sbLoad_Click(null, null);
            }
        }

        private void sbFile_Click(object sender, EventArgs e)
        {
            //SaveOrOpenFile(1);
        }

        private void sbLoad_Click(object sender, EventArgs e)
        {
            frmStockOrderAnnex myStockOrderAnnex = new frmStockOrderAnnex();
            myStockOrderAnnex.binSource = binMaster;
            myStockOrderAnnex.ShowDialog();
            myStockOrderAnnex.Dispose();
            //SaveOrOpenFile(0);
        }

        private void frmSellOrder_Shown(object sender, EventArgs e)
        {
            if (this.DesignMode == true) return;
            strBillFlag = "SO";
            strMTable = "t_SellOrder";
            strMasterSQL = "select * from t_SellOrder where F_BillID = @Value";

            strSlaverSQL = "select a.*,b.F_Name as F_ItemName,b.F_Spec,b.F_Brand,b.F_Material,(select F_Name from t_Class where F_ID = b.F_Type) as F_Type ";
            strSlaverSQL = strSlaverSQL + "from t_SellOrderDetail a,t_Item b ";
            strSlaverSQL = strSlaverSQL + "where a.F_ItemID = b.F_ID ";
            strSlaverSQL = strSlaverSQL + "and F_BillID = @Value";

            strSaveSlaverSQL = "select * from t_SellOrderDetail where F_BillID = @Value";

            SetDropSource();

            if (strBillID == "")
                NewBill();
            else
                BindData();
        }

    }
}

