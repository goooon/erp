using System;
using Excel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Storage
{
    public partial class frmCheck : Common.frmBill
    {
        public frmCheck()
        {
            InitializeComponent();
            if (DataLib.SysVar.GetParmValue("F_N27")) bMultCheck = true;
        }

        /// <summary>
        /// 从Excel导入数据
        /// </summary>
        protected void ImportExcel()
        {
            System.Data.DataTable dt = DataLib.sysClass.ImportExcel("Sheet1");
            if (dt == null) return;
            
            if (MessageBox.Show(this, "引入Excel资料需要一定时间，进行本操作吗?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            System.Data.DataTable dtSlaver = ((System.Data.DataView)binSlaver.DataSource).Table;

            if (MessageBox.Show(this, "是否清除盘点单现有数据?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataRow dr in dtSlaver.Rows)
                {
                    dr.Delete();
                }

            }

                BaseClass.frmFlag myFlag = new BaseClass.frmFlag();
                myFlag.label1.Text = "正在引入数据，请稍待......";
                myFlag.Show();
                myFlag.Update();
                try
                {

                   
                    string strID,strColor,strBatchNo,strUnit;

                    decimal dQty = 0;

                    try
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            strID = dr["物料编码"] == DBNull.Value ? "" : dr["物料编码"].ToString();
                            strColor = dr["颜色"] == DBNull.Value ? "" : dr["颜色"].ToString();
                            strBatchNo = dr["批号"] == DBNull.Value ? "" : dr["批号"].ToString();
                            strUnit = dr["单位"] == DBNull.Value ? "" : dr["单位"].ToString();
                            dQty = dr["实盘数"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["实盘数"]);

                            if (strID.Length == 0) continue;
                            DataRow drItem = FindItemRow(strID, lupControl1.GetValue().ToString(), strColor, strBatchNo, strUnit);
                            if (drItem == null) continue;
                            DataRow drNew = dtSlaver.NewRow();
                            drNew["F_ItemID"] = strID;
                            drNew["F_ItemName"] = dr["物料名称"];
                            drNew["F_Type"] = dr["物料类别"];
                            drNew["F_Spec"] = dr["规格"];
                            drNew["F_BatchNo"] = strBatchNo;
                            drNew["F_Color"] = strColor;
                            drNew["F_Unit"] = strUnit;
                            drNew["F_CheckQty"] = dr["实盘数"];
                            drNew["F_ComputerQty"] = drItem["F_Qty"];
                            drNew["F_Qty"] = dQty - Convert.ToDecimal(drItem["F_Qty"]);
                            drNew["F_Price"] = dr["成本价"];
                            drNew["F_Remark"] = dr["备注"];

                            dtSlaver.Rows.Add(drNew);
                        }

                    }
                    catch (Exception E)
                    {
                        MessageBox.Show(this, E.Message, "错误");
                    }
                }

                finally
                {
                    myFlag.Dispose();
                }
            

        }

        /// <summary>
        /// 取物料行
        /// </summary>
        /// <returns></returns>
        private DataRow FindItemRow(string strID,string strStorageID,string strColor,string strBatchNo,string strUnit)
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();

            DataSet ds = myHelper.GetDs("select top 1 b.F_ID,b.F_Name,b.F_Spec,b.F_Color,b.F_Brand,b.F_Material,isnull(a.F_Qty,0) as F_Qty from t_StorageQty a,t_Item b where a.F_ItemID = b.F_ID and a.F_ItemID = '" + strID + "' and isnull(a.F_StorageID,'') = '" + strStorageID + "' and isnull(a.F_Color,'') = '" + strColor + "' and isnull(a.F_BatchNo,'') = '" + strBatchNo + "' and isnull(a.F_Unit,'') = '" + strUnit + "'");

            if (ds.Tables[0].Rows.Count == 0)
            {
                ds = myHelper.GetDs("select a.F_ID,a.F_Name,a.F_Spec,a.F_Color,a.F_Brand,a.F_Material,b.F_Name as F_Unit,0 as F_Qty from t_Item a,t_Unit b where a.F_ID = b.F_ItemID and b.F_Main = 1 and a.F_ID = '" + strID + "'");
            }

            if (ds.Tables[0].Rows.Count == 0)
                return null;
            else
                return ds.Tables[0].Rows[0];
        }


        private void SetDropSource()
        {
            string strSQL = "select F_ID,F_Name from t_Storage";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupControl1.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_ID";
            ds.Dispose();

            strSQL = strSQL = "select F_ID,F_Name from t_Emp";
            ds = myHelper.GetDs(strSQL);
            lupControl2.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl2.LookUpDisplayField = "F_Name";
            lupControl2.LookUpKeyField = "F_ID";
            ds.Dispose();
        }

        private void frmStockOrder_Load(object sender, EventArgs e)
        {
           
        }

        protected override void CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            base.CellValueChanged(sender, e);
            if (e.Column.FieldName == "F_CheckQty")
            {
                decimal decCheckQty, decComputerQty, decPrice;
                DataRow dr = gvList.GetDataRow(e.RowHandle);
                if (dr["F_CheckQty"] == DBNull.Value)
                    decCheckQty = 0;
                else
                    decCheckQty = Convert.ToDecimal(dr["F_CheckQty"]);

                if (dr["F_ComputerQty"] == DBNull.Value)
                    decComputerQty = 0;
                else
                    decComputerQty = Convert.ToDecimal(dr["F_ComputerQty"]);

                if (dr["F_Price"] == DBNull.Value)
                    decPrice = 0;
                else
                    decPrice = Convert.ToDecimal(dr["F_Price"]);

                    dr.BeginEdit();
                dr["F_Qty"] = decCheckQty - decComputerQty;
                dr["F_Money"] = (decCheckQty - decComputerQty) * decPrice;
                dr.EndEdit();
                
            }

            //if (e.Column.FieldName == "F_ItemID")
            //{
            //    DataRow dr = gvList.GetDataRow(e.RowHandle);
            //    string strItemID = dr["F_ItemID"] == db
            //    FindItemRow
                
            //}
        }

        private void sbImport_Click(object sender, EventArgs e)
        {
            ImportStore();
        }

        /// <summary>
        /// 从库存导入数据
        /// </summary>
        private void ImportStore()
        {
            frmImportStore myImportStore = new frmImportStore();
            myImportStore.dtTable = ((DataView)binSlaver.DataSource).Table;
            myImportStore.ShowDialog();
            myImportStore.Dispose();
        }

        private void sbImportExcel_Click(object sender, EventArgs e)
        {
            if (lupControl1.GetValue() == DBNull.Value)
            {
                MessageBox.Show(this, "请先选择仓库！", "提示");
                lupControl1.Focus();
                return;
            }
            ImportExcel();
        }

        private void frmCheck_Shown(object sender, EventArgs e)
        {
            strBillFlag = "CK";
            strMTable = "t_Check";
            strMasterSQL = "select * from t_Check where F_BillID = @Value";

            strSlaverSQL = "select a.*,b.F_Name as F_ItemName,b.F_Spec,b.F_Brand,b.F_Material,(select F_Name from t_Class where F_ID = b.F_Type) as F_Type ";
            strSlaverSQL = strSlaverSQL + "from t_CheckDetail a,t_Item b ";
            strSlaverSQL = strSlaverSQL + "where a.F_ItemID = b.F_ID ";
            strSlaverSQL = strSlaverSQL + "and F_BillID = @Value";

            strSaveSlaverSQL = "select * from t_CheckDetail where F_BillID = @Value";

            SetDropSource();

            if (strBillID == "")
                NewBill();
            else
                BindData();
        }
    }
}

