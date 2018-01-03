using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sell
{
    public partial class frmSellBack : Common.frmBill
    {
        public frmSellBack()
        {
            InitializeComponent();
            if (DataLib.SysVar.GetParmValue("F_N26")) bMultCheck = true;
            btnBalance.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        /// <summary>
        /// 重写新单方法
        /// </summary>
        public override void NewBill()
        {
            base.NewBill();
            DataRow dr = ((DataRowView)binMaster.Current).Row;
            dr["F_Kind"] = "退现款给客户";
            dr["F_AcceptDate"] = DateTime.Today;
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
            myCertificate.GenCertificate(5);
            myCertificate.ShowDialog();
            myCertificate.Dispose();
            return true;
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
            string strSQL = "select F_ID,F_Name from t_Client";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupControl1.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_ID";
            ds.Dispose();

            strSQL = "select F_ID,F_Name from t_BalanceType";
            ds = myHelper.GetDs(strSQL);
            lupControl2.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl2.LookUpDisplayField = "F_Name";
            lupControl2.LookUpKeyField = "F_ID";
            ds.Dispose();
        }

        private void frmStockOrder_Load(object sender, EventArgs e)
        {
          
        }

        private void frmSellBack_Shown(object sender, EventArgs e)
        {
            strBillFlag = "ST";
            strMTable = "t_SellBack";
            strMasterSQL = "select * from t_SellBack where F_BillID = @Value";

            strSlaverSQL = "select a.*,b.F_Name as F_ItemName,b.F_Spec,b.F_Brand,b.F_Material,(select F_Name from t_Class where F_ID = b.F_Type) as F_Type ";
            strSlaverSQL = strSlaverSQL + "from t_SellBackDetail a,t_Item b ";
            strSlaverSQL = strSlaverSQL + "where a.F_ItemID = b.F_ID ";
            strSlaverSQL = strSlaverSQL + "and F_BillID = @Value";

            strSaveSlaverSQL = "select * from t_SellBackDetail where F_BillID = @Value";

            SetDropSource();

            if (strBillID == "")
                NewBill();
            else
                BindData();
        }

    }
}

