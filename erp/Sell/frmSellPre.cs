using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sell
{
    public partial class frmSellPre : Common.frmBill
    {
        public frmSellPre()
        {
            InitializeComponent();
            if (DataLib.SysVar.GetParmValue("F_N23")) bMultCheck = true;
            lupControl1.LookUpControl.Properties.AutoSearchColumnIndex = 2;
            lupControl1.LookUpControl.Properties.SortColumnIndex = 2;
            lupControl1.LookUpControl.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            lupControl3.LookUpControl.Properties.AutoSearchColumnIndex = 2;
            lupControl3.LookUpControl.Properties.SortColumnIndex = 2;
            lupControl3.LookUpControl.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            btnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnUnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
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
            lupControl5.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl5.LookUpDisplayField = "F_Name";
            lupControl5.LookUpKeyField = "F_ID";
            ds.Dispose();
        }

        private void frmStockOrder_Load(object sender, EventArgs e)
        {
           
        }

        private void frmSellPre_Shown(object sender, EventArgs e)
        {
            if (this.DesignMode == true) return;
            strBillFlag = "SR";
            strMTable = "t_SellPre";
            strMasterSQL = "select * from t_SellPre where F_BillID = @Value";

            strSlaverSQL = "select a.*,b.F_Name as F_ItemName,b.F_Spec,b.F_Color,b.F_Material,(select F_Name from t_Class where F_ID = b.F_Type) as F_Type ";
            strSlaverSQL = strSlaverSQL + "from t_SellPreDetail a,t_Item b ";
            strSlaverSQL = strSlaverSQL + "where a.F_ItemID = b.F_ID ";
            strSlaverSQL = strSlaverSQL + "and F_BillID = @Value";

            strSaveSlaverSQL = "select * from t_SellPreDetail where F_BillID = @Value";

            SetDropSource();

            if (strBillID == "")
                NewBill();
            else
                BindData();
        }

    }
}

