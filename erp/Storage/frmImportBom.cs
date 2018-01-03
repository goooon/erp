using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Storage
{
    public partial class frmImportBom : BaseClass.frmBase
    {
        public DataTable dtBill;
        public frmImportBom()
        {
            InitializeComponent();
            BindBom();
        }

        /// <summary>
        /// 绑定到Bom产品
        /// </summary>
        private void BindBom()
        {
            string strSQL = @"select a.F_BillID,b.F_ID,b.F_Name,b.F_Spec,b.F_Brand,b.F_Color,c.F_Name as F_Unit 
                              from t_Bom a,t_Item b,
                              (select F_ItemID,F_Name from t_Unit where F_Main = 1) c
                              where a.F_ItemID = b.F_ID 
                              and a.F_ItemID = C.F_ItemID";

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsBom = myHelper.GetDs(strSQL);

            gcBom.DataSource = dsBom.Tables[0].DefaultView;

        }

        /// <summary>
        /// 将选定BOM单明细填入领料单中
        /// </summary>
        private int FillBom()
        {
            if (gvBom.FocusedRowHandle < 0) return 0;
            DataRow drBom = gvBom.GetDataRow(gvBom.FocusedRowHandle);
            string strSQL = @"select b.F_ID,b.F_Name,b.F_Spec,b.F_Color,b.F_Brand,b.F_Material,
                              a.F_Unit,b.F_StockPrice,b.F_StorageID,isnull(a.F_ActuQty,0) as F_ActuQty
                              from t_BomDetail a,t_Item b
                              where a.F_ItemID = b.F_ID
                              and a.F_BillID = '" + drBom["F_BillID"].ToString() + "'";


            dtBill.Rows.Clear();

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsBomDetail = myHelper.GetDs(strSQL);

            foreach (DataRow dr in dsBomDetail.Tables[0].Rows)
            {
                DataRow drNew =  dtBill.NewRow();
                drNew["F_ItemID"] = dr["F_ID"];
                drNew["F_ItemName"] = dr["F_Name"];
                drNew["F_Spec"] = dr["F_Spec"];
                drNew["F_Color"] = dr["F_Color"];
                drNew["F_Brand"] = dr["F_Brand"];
                drNew["F_Material"] = dr["F_Material"];
                drNew["F_Unit"] = dr["F_Unit"];
                drNew["F_Price"] = dr["F_StockPrice"];
                drNew["F_StorageID"] = dr["F_StorageID"];
                drNew["F_Qty"] = Convert.ToDecimal(dr["F_ActuQty"]) * spinEdit1.Value;
                dtBill.Rows.Add(drNew);
            }

            return 1;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (FillBom() > 0) this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
