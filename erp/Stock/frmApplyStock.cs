using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Stock
{
    public partial class frmApplyStock : Common.frmBill
    {
        public bool blnFlag = false;
        private DataSet _dsGen = null;

        public frmApplyStock()
        {
            InitializeComponent();
            if (DataLib.SysVar.GetParmValue("F_N16")) bMultCheck = true;
            btnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnUnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barMemo.Caption = "Ctrl+B:条码录入;F2:供应商供货历史;F8:查询所有物料库存;F9:查询当前物料库存";
        }

        public frmApplyStock(DataSet dsGen)
        {
            InitializeComponent();
            _dsGen = dsGen;
            btnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnUnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barMemo.Caption = "Ctrl+B:条码录入;F2:供应商供货历史;F8:查询所有物料库存;F9:查询当前物料库存";
        }

        /// <summary>
        /// 根据MRP生成
        /// </summary>
        public void GenBill()
        {
            frmStockOrder_Load(null,null);
            blnFlag = true;

            DataTable dt = ((DataView)binSlaver.DataSource).Table;

            foreach (DataRow dr in dt.Rows)
            {
                dr.Delete();
            }

            foreach (DataRow dr in _dsGen.Tables[0].Rows)
            {
                DataRow drNew = dt.NewRow();
                drNew["F_ItemID"] = dr["F_ItemID"];
                drNew["F_ItemName"] = dr["F_ItemName"];
                drNew["F_Spec"] = dr["F_Spec"];
                drNew["F_Unit"] = dr["F_Unit"];
                drNew["F_Qty"] = dr["F_NeedQty"];
                drNew["F_SupplierID"] = dr["F_SupplierID"];
                dt.Rows.Add(drNew);
            }
        }

        /// <summary>
        /// 绑定下拉数据源
        /// </summary>
        private void SetDropSource()
        {
            //职员资料
            string strSQL = "select F_ID,F_Name from t_Emp";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupControl1.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_ID";
            ds.Dispose();

            //部门
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


        protected override void SlaverNewRow(object Sender, DataTableNewRowEventArgs e)
        {
            base.SlaverNewRow(Sender, e);
            DataRow dr = e.Row;
            dr.BeginEdit();
            dr["F_ApplyDate"] = DateTime.Today;
            dr["F_ReplyDate"] = DateTime.Today;
            dr.EndEdit();
        }

        private void frmApplyStock_Shown(object sender, EventArgs e)
        {
            if (this.DesignMode == false)
            {
                if (blnFlag == true) return;
                strBillFlag = "AS";
                strMTable = "t_ApplyStock";
                strMasterSQL = "select * from t_ApplyStock where F_BillID = @Value";

                strSlaverSQL = "select a.*,b.F_Name as F_ItemName,b.F_Spec,b.F_Brand,b.F_Material,(select F_Name from t_Class where F_ID = b.F_Type) as F_Type ";
                strSlaverSQL = strSlaverSQL + "from t_ApplyStockDetail a,t_Item b ";
                strSlaverSQL = strSlaverSQL + "where a.F_ItemID = b.F_ID ";
                strSlaverSQL = strSlaverSQL + "and F_BillID = @Value";

                strSaveSlaverSQL = "select * from t_ApplyStockDetail where F_BillID = @Value";

                SetDropSource();

                if (strBillID == "")
                    NewBill();
                else
                    BindData();

                if (_dsGen != null) GenBill();
            }
        }
    }
}

