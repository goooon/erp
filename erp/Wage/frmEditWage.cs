using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Wage
{
    public partial class frmEditWage : Common.frmDialog
    {
        private string strSQL;
        public string strDate;
        public frmEditWage()
        {
            InitializeComponent();
            blnNew = true;
            strNoCopyField = "AID";
        }
        
        private void SetDropSource()
        {
            string strSQL = "select F_ID,F_Name from t_Item";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupItem.LookUpDataSource = ds.Tables[0].DefaultView;
            lupItem.LookUpDisplayField = "F_Name";
            lupItem.LookUpKeyField = "F_ID";
            ds.Dispose();

            strSQL = strSQL = "select F_ID,F_Name from t_Class where left(F_UPID,2) like '03%'";
            ds = myHelper.GetDs(strSQL);
            lupDept.LookUpDataSource = ds.Tables[0].DefaultView;
            lupDept.LookUpDisplayField = "F_Name";
            lupDept.LookUpKeyField = "F_ID";
            ds.Dispose();

        }
          
        /// <summary>
        /// 取最大工资录入号
        /// </summary>
        /// <returns></returns>
        private decimal GetMaxCode()
        {
            string strSQL = "select isnull(max(Aid),0)+1 as MaxID from t_WageInput";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            return Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
        }

        /// <summary>
        /// 重写新增方法
        /// </summary>
        public override void New()
        {
            base.New();
            strSQL = @"select a.*,b.F_Name as F_EmpName,c.F_Name as F_ItemName,
                        d.F_Name as F_DeptName,e.F_Name as F_ProcName
                        from t_WageInput a
                        left join t_Emp b
                        on a.F_EmpID = b.F_ID 
                        left join t_Item c
                        on a.F_ItemID = c.F_ID 
                        left join t_Class d
                        on a.F_DeptID = d.F_ID 
                        left join t_Process e
                        on a.F_ProcID = e.F_ID 
            where Aid = 0";
            if (blnBind == false)
               BindData();
            DataRow dr = ((DataRowView)binData.AddNew()).Row;
            dr.BeginEdit();
            dr["F_Time"] = DateTime.Today;
            dr["F_Date"] = strDate;
            dr["Aid"] = GetMaxCode();
            dr["F_Flag"] = 0;
            dr["F_Type"] = "计件";
            dr.EndEdit();
            //binData.EndEdit();
            dateControl1.Focus();
        }

        /// <summary>
        /// 编辑工资项目
        /// </summary>
        /// <param name="decID"></param>
        /// <param name="strDate"></param>
        public void Edit(decimal decID)
        {
            //base.Edit(strID);
            strSQL = @"select a.*,b.F_Name as F_EmpName,c.F_Name as F_ItemName,
                        d.F_Name as F_DeptName,e.F_Name as F_ProcName
                        from t_WageInput a
                        left join t_Emp b
                        on a.F_EmpID = b.F_ID 
                        left join t_Item c
                        on a.F_ItemID = c.F_ID 
                        left join t_Class d
                        on a.F_DeptID = d.F_ID 
                        left join t_Process e
                        on a.F_ProcID = e.F_ID 
                        where Aid = " + decID.ToString();
            BindData();
            
        }

        /// <summary>
        /// 重写数据绑定方法
        /// </summary>
        protected override void BindData()
        {

            strSaveSlaverSQL = "select * from t_WageInput where Aid = 0";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            ds.Tables[0].ColumnChanged += new DataColumnChangeEventHandler(ColumnChanged);
            binData.DataSource = ds.Tables[0].DefaultView;
            SetDropSource();
            base.BindData();
        }

        private void ColumnChanged(object Sender, DataColumnChangeEventArgs e)
        {
            //if (e.Column.ColumnName == "F_ProcID")
            //{
            //    DataRow drProcess = ((DataRowView)lupProcess.lupEdit.Properties.GetDataSourceRowByKeyValue(e.ProposedValue)).Row;
            //    DataRow dr = e.Row;
            //    dr.BeginEdit();
            //    dr["F_Price"] = drProcess["F_Price"];
            //    dr.EndEdit();
            //}

            if (e.Column.ColumnName == "F_ItemID" || e.Column.ColumnName == "F_DeptID" || e.Column.ColumnName == "F_ProcID")
            {
                object objItem = e.Row["F_ItemID"] == DBNull.Value ? "" : e.Row["F_ItemID"];
                object objDept = e.Row["F_DeptID"] == DBNull.Value ? "" : e.Row["F_DeptID"];
                object objProc = e.Row["F_ProcID"] == DBNull.Value ? "" : e.Row["F_ProcID"];

                e.Row.BeginEdit();
                e.Row["F_Price"] = GetWorkPrice(objItem.ToString(), objDept.ToString(), objProc.ToString());
                e.Row.EndEdit();
            }


            //根据数据及单价计算金额
            if (e.Column.ColumnName == "F_Qty" || e.Column.ColumnName == "F_Price")
            {
                decimal decQty = 0,decPrice = 0;
                DataRow dr = e.Row;
                if (dr["F_Qty"] == DBNull.Value)
                    decQty = 0;
                else
                    decQty = Convert.ToDecimal(dr["F_Qty"]);

                if (dr["F_Price"] == DBNull.Value) 
                    decPrice = 0;
                else
                    decPrice = Convert.ToDecimal(dr["F_Price"]);

                dr.BeginEdit();
                dr["F_Money"] = decQty * decPrice;
                dr.EndEdit();
                binData.EndEdit();
            }
        }

        private void ckOption_CheckedChanged(object sender, EventArgs e)
        {
            blnNew = ckOption.Checked;
        }

        private void lupDept_ValueChanged(object sender, EventArgs e)
        {
            if (lupDept.GetValue() == DBNull.Value) return;

            string strSQL = "select F_ID,F_Name from t_WorkGroup where F_DeptID = '" + lupDept.GetValue().ToString() + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupGroup.LookUpDataSource = ds.Tables[0].DefaultView;
            lupGroup.LookUpDisplayField = "F_Name";
            lupGroup.LookUpKeyField = "F_ID";
            ds.Dispose();

            strSQL = "select F_ID,F_Name from t_Emp where F_Type = '" + lupDept.GetValue().ToString() + "'";
            myHelper = new DataLib.DataHelper();
            ds = myHelper.GetDs(strSQL);
            lupEmp.LookUpDataSource = ds.Tables[0].DefaultView;
            lupEmp.LookUpDisplayField = "F_Name";
            lupEmp.LookUpKeyField = "F_ID";
            ds.Dispose();

            strSQL = strSQL = "select F_ID,F_Name from t_Process where F_DeptID = '" + lupDept.GetValue().ToString() + "'";
            ds = myHelper.GetDs(strSQL);
            lupProcess.LookUpDataSource = ds.Tables[0].DefaultView;
            lupProcess.LookUpDisplayField = "F_Name";
            lupProcess.LookUpKeyField = "F_ID";
            ds.Dispose();
        }

        private void lupProcess_ValueChanged(object sender, EventArgs e)
        {

        }

        private decimal GetWorkPrice(string sItemID, string sDeptID, string sProceID)
        {
            string strSQL = @"select isnull(F_WorkPrice,0) from t_ProductProcess a,t_ProductProcessDetail b
                                where a.F_BillID = b.F_BillID
                                and a.F_ItemID = '" + sItemID + @"'
                                and b.F_DeptID = '" + sDeptID + @"'
                                and b.F_ProcessID = '" + sProceID + "'";

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);

            if (ds.Tables[0].Rows.Count == 0) return 0;

            return Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
        }


    }
}

