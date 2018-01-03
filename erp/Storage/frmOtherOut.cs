using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Storage
{
    public partial class frmOtherOut : Common.frmBill
    {
        public string strSelectValue = "其它出库";

        public frmOtherOut()
        {
            InitializeComponent();
            if (DataLib.SysVar.GetParmValue("F_N30")) bMultCheck = true;
            strBillText = strSelectValue;
        }

        private void BindSupplier()
        {
            string strSQL = "select F_ID,F_Name from t_Supplier";
            if (strSelectValue == "委外领料出库" || strSelectValue == "委外退货出库")
                strSQL = "select F_ID,F_Name from t_OutSupplier";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupControl1.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_ID";
        }

        private void BindClient()
        {
            string strSQL = "select F_ID,F_Name from t_Client";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupControl1.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_ID";
        }

        private void SetDropSource()
        {
            string strSQL = "";
            strSQL = "select F_ID,F_Name from t_Class where left(F_UPID,2) like '03%'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupControl2.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl2.LookUpDisplayField = "F_Name";
            lupControl2.LookUpKeyField = "F_ID";
            ds.Dispose();

            if (strSelectValue == "销售发货出库")
                BindClient();
            else
                BindSupplier();

        }

        private void frmStockOrder_Load(object sender, EventArgs e)
        {
            if (strSelectValue == "生产领料出库" || strSelectValue == "生产补料出库")
            {
                lupControl1.Visible = false;
                lupControl1.Request = false;
            }
            this.Text = strSelectValue;
        }

        protected override void LoadBill()
        {
            if (DataLib.SysVar.GetParmValue("F_N44"))
            {
                //if (strSelectValue == "销售发货出库")
                if (lupControl1.Visible == true)
                {
                    if (lupControl1.GetValue() == DBNull.Value)
                    {
                        MessageBox.Show("请选择" + lupControl1.EditLabel + "!!", "提示");
                        lupControl1.Focus();
                        return;
                    }

                    if (lupControl1.GetValue() != DBNull.Value)
                        this.strValue = lupControl1.GetValue().ToString();
                    else
                        this.strValue = "";

                }
            }
            base.LoadBill();
        }


        public override void NewBill()
        {
            base.NewBill();
            DataRow dr = ((DataRowView)binMaster.Current).Row;
            dr["F_Flag"] = 1;
            dr["F_Type"] = strSelectValue;
            binMaster.EndEdit();
        }

        private void cbControl1_SelectIndexChange(object sender, EventArgs e)
        {
            this.sPrintTag = cbControl1.GetValue().ToString();
            this.Text = this.sPrintTag;
            strSelectValue = this.sPrintTag;
            lupControl1.Request = true;
            if (strSelectValue == "销售发货出库" || strSelectValue == "业务出库" || strSelectValue == "零售出库" || strSelectValue == "代理商出库")
            {
                BindClient();
                lupControl1.EditLabel = "客户:";
                //lupControl1.Visible = true;
            }
            else
            {
                BindSupplier();
                lupControl1.EditLabel = "供应商:";
                //lupControl1.Visible = false;
            }

            if (strSelectValue == "生产领料出库" || strSelectValue == "生产补料出库" || strSelectValue == "其它出库")
            {
                lupControl1.Request = false;
                lupControl1.Visible = false;
            }
            else
            {
                lupControl1.Visible = true;
                lupControl1.Request = true;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmImportBom myImportBom = new frmImportBom();
            myImportBom.dtBill = ((DataView)binSlaver.DataSource).Table;
            myImportBom.ShowDialog();
            myImportBom.Dispose();
        }

        private void frmOtherOut_Shown(object sender, EventArgs e)
        {
            lbTitle.Text = this.Text;
            strBillFlag = "OO";
            strMTable = "t_Other";
            strMasterSQL = "select * from t_Other where F_BillID = @Value";

            strSlaverSQL = "select a.*,b.F_Name as F_ItemName,b.F_Spec,b.F_Material,b.F_Brand,(select F_Name from t_Class where F_ID = b.F_Type) as F_Type ";
            strSlaverSQL = strSlaverSQL + "from t_OtherDetail a,t_Item b ";
            strSlaverSQL = strSlaverSQL + "where a.F_ItemID = b.F_ID ";
            strSlaverSQL = strSlaverSQL + "and F_BillID = @Value";

            strSaveSlaverSQL = "select * from t_OtherDetail where F_BillID = @Value";

            SetDropSource();

            if (strBillID == "")
                NewBill();
            else
                BindData();
        }
    }
}

