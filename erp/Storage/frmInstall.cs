using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Storage
{
    public partial class frmInstall : Common.frmBill
    {
        public frmInstall()
        {
            InitializeComponent();
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
        }

        private void frmStockOrder_Load(object sender, EventArgs e)
        {
          
        }

        /// <summary>
        /// 将选定BOM单明细填入领料单中
        /// </summary>
        private int FillBom()
        {
            if (editControl6.GetValue() == DBNull.Value) return -1;
            string strItemID = editControl6.GetValue().ToString();
            string strSQL = @"select b.F_ID,b.F_Name,b.F_Spec,b.F_Color,b.F_Brand,b.F_Material,
                              a.F_Unit,b.F_StockPrice,b.F_StorageID,isnull(a.F_ActuQty,0) as F_ActuQty
                              from t_BomDetail a,t_Item b,t_Bom c
                              where a.F_ItemID = b.F_ID
                              and a.F_BillID = c.F_BillID
                              and c.F_ItemID = '" + strItemID + "'";

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsBomDetail = myHelper.GetDs(strSQL);

            DataTable dtBill = ((DataView)binSlaver.DataSource).Table;

            while (binSlaver.Count > 0)
            {
                binSlaver.RemoveCurrent();
            }
        
            foreach (DataRow dr in dsBomDetail.Tables[0].Rows)
            {
                DataRow drNew = dtBill.NewRow();
                drNew["F_ItemID"] = dr["F_ID"];
                drNew["F_ItemName"] = dr["F_Name"];
                drNew["F_Spec"] = dr["F_Spec"];
                drNew["F_Color"] = dr["F_Color"];
                drNew["F_Brand"] = dr["F_Brand"];
                drNew["F_Material"] = dr["F_Material"];
                drNew["F_Unit"] = dr["F_Unit"];
                drNew["F_Price"] = dr["F_StockPrice"];
                drNew["F_StorageID"] = dr["F_StorageID"];

                drNew["F_Qty"] = Convert.ToDecimal(dr["F_ActuQty"]) * Convert.ToDecimal(spinControl1.GetValue());
                dtBill.Rows.Add(drNew);
            }

            return 1;
        }

        public override void NewBill()
        {
            base.NewBill();
            DataRow dr = ((DataRowView)binMaster.Current).Row;
            dr["F_Type"] = "组装";
            dr["F_Qty"] = 1;
            editControl7.SetValue("");
            editControl8.SetValue("");
            binMaster.EndEdit();
        }

        private void sbSelItem_Click(object sender, EventArgs e)
        {
            Common.frmSelItem mySelItem = new Common.frmSelItem();
            mySelItem.intTag = 1;
            DataRow dr = null;
            if (mySelItem.ShowDialog() == DialogResult.OK)
            {

                if (mySelItem.TabControl.SelectedTabPageIndex == 0)
                {
                    if (mySelItem.gvMain.FocusedRowHandle >= 0)
                    {
                        dr = mySelItem.gvMain.GetDataRow(mySelItem.gvMain.FocusedRowHandle);
                        DataLib.sysClass myClass = new DataLib.sysClass();
                        DataRow drItem = myClass.FindItem(dr["F_ID"].ToString());
                        DataTable dt = ((DataView)binMaster.DataSource).Table;
                        DataRow drNew = dt.Rows[0];
                        drNew["F_ItemID"] = drItem["F_ID"];
                        editControl7.SetValue(drItem["F_Name"].ToString());
                        editControl8.SetValue(drItem["F_Spec"].ToString());
                        drNew["F_Unit"] = drItem["F_Unit"];
                        drNew["F_StorageID"] = drItem["F_StorageID"];
                        drNew["F_Color"] = drItem["F_Color"];
                        drNew["F_Grade"] = drItem["F_Grade"];
                        binMaster.EndEdit();
                    }
                }
                else
                {
                    if (mySelItem.gvStore.FocusedRowHandle >= 0)
                    {
                        dr = mySelItem.gvStore.GetDataRow(mySelItem.gvStore.FocusedRowHandle);
                        //DataLib.sysClass myClass = new DataLib.sysClass();
                        //DataRow drItem = myClass.FindItem(dr["F_ID"].ToString());
                        DataTable dt = ((DataView)binMaster.DataSource).Table;
                        DataRow drNew = dt.Rows[0];
                        drNew["F_ItemID"] = dr["F_ID"];
                        editControl7.SetValue(dr["F_Name"].ToString());
                        editControl8.SetValue(dr["F_Spec"].ToString());
                        drNew["F_Unit"] = dr["F_Unit"];
                        drNew["F_StorageID"] = dr["F_StorageID"];
                        drNew["F_BatchNo"] = dr["F_BatchNo"];
                        drNew["F_Color"] = dr["F_Color"];
                        drNew["F_Grade"] = dr["F_Grade"];
                        binMaster.EndEdit();
                    }
                }
            }
            mySelItem.Dispose();
        }

        private void sbExpand_Click(object sender, EventArgs e)
        {
            FillBom();
        }

        private void frmInstall_Shown(object sender, EventArgs e)
        {
            strBillFlag = "IT";
            strMTable = "t_Install";
            strMasterSQL = "select * from t_Install where F_BillID = @Value";

            strSlaverSQL = "select a.*,b.F_Name as F_ItemName,b.F_Spec,F_Material,b.F_Brand,(select F_Name from t_Class where F_ID = b.F_Type) as F_Type ";
            strSlaverSQL = strSlaverSQL + "from t_InstallDetail a,t_Item b ";
            strSlaverSQL = strSlaverSQL + "where a.F_ItemID = b.F_ID ";
            strSlaverSQL = strSlaverSQL + "and F_BillID = @Value";

            strSaveSlaverSQL = "select * from t_InstallDetail where F_BillID = @Value";

            SetDropSource();

            if (strBillID == "")
                NewBill();
            else
            {
                BindData();
                DataRow dr = ((DataRowView)binMaster.Current).Row;
                DataLib.sysClass myClass = new DataLib.sysClass();
                DataRow drItem = myClass.FindItem(dr["F_ItemID"].ToString());
                if (drItem != null)
                {
                    editControl7.SetValue(drItem["F_Name"].ToString());
                    editControl8.SetValue(drItem["F_Spec"].ToString());
                }
            }
        }

    }
}

