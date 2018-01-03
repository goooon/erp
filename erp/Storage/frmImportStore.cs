using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Storage
{
    public partial class frmImportStore : BaseClass.frmBase
    {
        public DataTable dtTable = null;
        public frmImportStore()
        {
            InitializeComponent();
            SetDropSource();
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 设置下拉数据源
        /// </summary>
        private void SetDropSource()
        {
            string strSQL = "select F_ID,F_Name from t_Storage";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupControl1.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_ID";
            ds.Dispose();

            strSQL = "select F_ID,F_Name from t_Class where F_UPID like '04%' or F_UPID like '11%'";
            myHelper = new DataLib.DataHelper();
            ds = myHelper.GetDs(strSQL);
            lupControl2.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl2.LookUpDisplayField = "F_Name";
            lupControl2.LookUpKeyField = "F_ID";
            ds.Dispose();
        }

        /// <summary>
        /// 物料导入方法
        /// </summary>
        private void Import()
        {
            string strStore,strKind,strType,strSQL;
            if (lupControl1.GetValue() == null)
                strStore = "";
            else
                strStore = lupControl1.GetValue().ToString();

            if (cbControl1.GetValue() == null)
                strKind = "";
            else
                strKind = cbControl1.GetValue().ToString();

            if (lupControl2.GetValue() == null)
                strType = "";
            else
                strType = lupControl2.GetValue().ToString();

            strSQL = "select b.F_ID,b.F_Name,b.F_Spec,a.F_Unit,b.F_Brand,b.F_Color,b.F_Material,a.F_BatchNo,b.F_Price,a.F_Qty from t_StorageQty a, t_Item b ";
            strSQL = strSQL + " where a.F_ItemID = b.F_ID ";
            if (strStore != "")
               strSQL = strSQL + " and a.F_StorageID = '"+strStore+"'";
            if (strKind != "")
               strSQL = strSQL + " and b.F_Kind = '"+strKind+"'";
            if (strType != "")
               strSQL = strSQL + " and b.F_Type = '"+strType+"'";

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (MessageBox.Show(this, "是否清除盘点单现有数据?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    dr.Delete();
                }

            }
            //dtTable.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DataRow drNew = dtTable.NewRow();
                drNew["F_ItemID"] = dr["F_ID"];
                drNew["F_ItemName"] = dr["F_Name"];
                drNew["F_Spec"] = dr["F_Spec"];
                drNew["F_Unit"] = dr["F_Unit"];
                drNew["F_Brand"] = dr["F_Brand"];
                drNew["F_Color"] = dr["F_Color"];
                drNew["F_Material"] = dr["F_Material"];
                drNew["F_BatchNo"] = dr["F_BatchNo"];
                drNew["F_Price"] = dr["F_Price"];
                drNew["F_ComputerQty"] = dr["F_Qty"];
                dtTable.Rows.Add(drNew);
            }

        }

        private void sbImport_Click(object sender, EventArgs e)
        {
            Import();
            Close();
        }
    }
}
