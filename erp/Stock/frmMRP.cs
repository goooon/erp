using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Localization;

namespace Stock
{
    public partial class frmMRP : BaseClass.frmBase
    {
        DataSet dsResult = null;
        DataTable dtOtherStore = null;

        public frmMRP()
        {
            InitializeComponent();
        }

        private void sbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sbNext_Click(object sender, EventArgs e)
        {
            switch (TabControl.SelectedTabPageIndex)
            {
                case 0:
                    TabControl.SelectedTabPage = PageSelect;
                    break;
                case 1:
                    if (rbSellOrder.Checked)
                    {
                        TabControl.SelectedTabPage = PageSellOrder;
                        ShowSellOrder(ucDate.dtStart, ucDate.dtEnd);
                        GetOrderDetail();
                    }
                    if (rbTask.Checked)
                    {
                        TabControl.SelectedTabPage = PageTask;
                        ShowTask(ucTask.dtStart, ucTask.dtEnd);
                        GetTaskDetail();
                    }
                    if (rbNeed.Checked)
                    {
                        TabControl.SelectedTabPage = PageNeed;
                        BindNeed();
                    }
                    break;
                case 2:
                    ExpandAll(((DataView)gcTmp.DataSource).Table.DataSet); 
                    TabControl.SelectedTabPage = PageResult;
                    break;
                case 3:
                    ExpandAll(((DataView)gcTaskTmp.DataSource).Table.DataSet); 
                    TabControl.SelectedTabPage = PageResult;
                    break;
                case 4:
                    ExpandAll(((DataView)gcItem.DataSource).Table.DataSet); 
                    TabControl.SelectedTabPage = PageResult;
                    break;
                case 5:
                    sbNext.Enabled = false;
                    break;
            }
            sbPre.Enabled = true;
        }

        private void sbPre_Click(object sender, EventArgs e)
        {
            switch (TabControl.SelectedTabPageIndex)
            {
                case 0:
                    sbPre.Enabled = false;
                    break;
                case 1:
                    TabControl.SelectedTabPage = PageWelcom;
                    break;
                case 2:
                    TabControl.SelectedTabPage = PageSelect;
                    break;
                case 3:
                    TabControl.SelectedTabPage = PageSelect;
                    break;
                case 4:
                    TabControl.SelectedTabPage = PageSelect;
                    break;
                case 5:
                    if (rbSellOrder.Checked == true)
                        TabControl.SelectedTabPage = PageSellOrder;

                    if (rbTask.Checked == true)
                        TabControl.SelectedTabPage = PageTask;

                    if (rbNeed.Checked == true)
                        TabControl.SelectedTabPage = PageNeed;
                    break;
            }

            sbNext.Enabled = true;
        }

        /// <summary>
        /// 按日期段提取客户订单资料
        /// </summary>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        private void ShowSellOrder(DateTime dtStart,DateTime dtEnd)
        {
            string strSQL = "select cast(0 as bit) as F_Select,a.F_BillID,a.F_Date,b.F_Name as F_Client,c.F_Name as F_Dept,d.F_Name as F_Opertor,a.F_SendDate,a.F_BillMan,a.F_CheckMan,a.F_CheckDate from t_SellOrder a left join t_Client b ";
            strSQL = strSQL + "on a.F_ClientID = b.F_ID left join t_Class c on a.F_DeptID = c.F_ID left join t_Emp d on a.F_Opertor = d.F_ID where F_Check = 1 and F_Date >= '"+dtStart.ToString()+"' and F_Date <= '"+dtEnd.ToString()+"'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gcSellOrderMain.DataSource = ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 提取生产任务单明细
        /// </summary>
        private void GetTaskDetail()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("exec sp_TaskTmp");
            gcTaskTmp.DataSource = ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 提取客户订单明细
        /// </summary>
        private void GetOrderDetail()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("exec sp_SellOrderTmp");
            gcTmp.DataSource = ds.Tables[0].DefaultView;
        }

        private void ucDate_RefreshDateChanged(object sender, EventArgs e)
        {
            ShowSellOrder(ucDate.dtStart,ucDate.dtEnd);
        }

        /// <summary>
        /// 添加订单明细
        /// </summary>
        private void AddOrderDetail()
        {
            string strSQL;
            DataTable dt = ((DataView)gcTmp.DataSource).Table;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            int intCnt = gvSellOrderMain.RowCount;
            for (int i = 0; i < intCnt; i++)
            {
                DataRow dr = gvSellOrderMain.GetDataRow(i);
                if (Convert.ToBoolean(dr["F_Select"]) == false) continue;
                string strBill = dr["F_BillID"].ToString();
                strSQL = "select F_BillID,AID,F_ItemID,b.F_Name as F_ItemName,b.F_Spec,a.F_Unit,a.F_Qty,0 as F_EvaQty,a.F_Qty as F_NeedQty ";
                strSQL = strSQL + "from t_SellOrderDetail a,t_Item b ";
                strSQL = strSQL + "where a.F_ItemID = b.F_ID ";
                strSQL = strSQL + "and F_BillID = '" + strBill + "'";
                DataSet ds = myHelper.GetDs(strSQL);
                foreach (DataRow drItem in ds.Tables[0].Rows)
                {
                    DataRow[] drTmp = dt.Select("(F_BillID = '" + drItem["F_BillID"].ToString() + "') and AID = " + drItem["AID"].ToString());
                    if (drTmp.Length > 0) continue;
                    DataRow drNew = dt.NewRow();
                    drNew["F_Select"] = false;
                    drNew["F_BillID"] = drItem["F_BillID"];
                    drNew["AID"] = drItem["AID"];
                    drNew["F_ItemID"] = drItem["F_ItemID"];
                    drNew["F_ItemName"] = drItem["F_ItemName"];
                    drNew["F_Spec"] = drItem["F_Spec"];
                    drNew["F_Unit"] = drItem["F_Unit"];
                    drNew["F_Qty"] = drItem["F_Qty"];
                    drNew["F_EvaQty"] = drItem["F_EvaQty"];
                    drNew["F_NeedQty"] = drItem["F_NeedQty"];
                    dt.Rows.Add(drNew);
                }
            }
        }

        /// <summary>
        /// 添加生产任务单明细
        /// </summary>
        private void AddTaskDetail()
        {
            string strSQL;

            DataTable dt = ((DataView)gcTaskTmp.DataSource).Table;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();

            int intCnt = gvTaskMain.RowCount;
            for (int i = 0; i < intCnt; i++)
            {
                DataRow dr = gvTaskMain.GetDataRow(i);
                if (Convert.ToBoolean(dr["F_Select"]) == false) continue;
                string strBill = dr["F_BillID"].ToString();
                strSQL = "select F_BillID,Aid,F_ItemID,b.F_Name as F_ItemName,b.F_Spec,a.F_Unit,a.F_Qty ";
                strSQL = strSQL + "from t_TaskGoods a,t_Item b ";
                strSQL = strSQL + "where a.F_ItemID = b.F_ID ";
                strSQL = strSQL + "and F_BillID = '" + strBill + "'";
                DataSet ds = myHelper.GetDs(strSQL);
                foreach (DataRow drItem in ds.Tables[0].Rows)
                {
                    DataRow[] drTmp = dt.Select("(F_BillID = '" + drItem["F_BillID"].ToString() + "') and (Aid = " + drItem["Aid"].ToString()+")");
                    if (drTmp.Length > 0) continue;
                    DataRow drNew = dt.NewRow();
                    drNew["F_Select"] = false;
                    drNew["F_BillID"] = drItem["F_BillID"];
                    drNew["Aid"] = drItem["Aid"];
                    drNew["F_ItemID"] = drItem["F_ItemID"];
                    drNew["F_ItemName"] = drItem["F_ItemName"];
                    drNew["F_Spec"] = drItem["F_Spec"];
                    drNew["F_Unit"] = drItem["F_Unit"];
                    drNew["F_Qty"] = drItem["F_Qty"];
                    dt.Rows.Add(drNew);
                }
            }
        }

        /// <summary>
        /// 自定义
        /// </summary>
        private void BindNeed()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("exec sp_NeedTmp");
            gcItem.DataSource = ds.Tables[0].DefaultView;
        }

        private void sbAdd_Click(object sender, EventArgs e)
        {
            AddOrderDetail();
        }

        private void sbRemove_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvTmp.RowCount; i++)
            {
                if (Convert.ToBoolean(gvTmp.GetRowCellValue(i, "F_Select")) == false) continue;
                gvTmp.DeleteRow(i);
            }
        }

        private void cbSelAll1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < gvSellOrderMain.RowCount; i++)
            {
                gvSellOrderMain.SetRowCellValue(i, "F_Select", cbSelAll1.Checked);
            }
        }

        private void cbSelAll2_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < gvTmp.RowCount; i++)
            {
                gvTmp.SetRowCellValue(i, "F_Select", cbSelAll2.Checked);
            }
        }

        private void sbAddRow_Click(object sender, EventArgs e)
        {
            gvItem.AddNewRow();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            gvItem.DeleteRow(gvItem.FocusedRowHandle);
            SetAutoID();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            int i = gvItem.RowCount;
            while (true)
            {
                gvItem.DeleteRow(i);
                i = gvItem.RowCount;
                if (i == 0) break;
            }
        }

        private void ItemButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Common.frmSelItem mySelItem = new Common.frmSelItem();
            mySelItem.intTag = 1;
            if (mySelItem.ShowDialog() == DialogResult.OK)
            {
                DataRow dr = mySelItem.gvMain.GetDataRow(mySelItem.gvMain.FocusedRowHandle);
                DataRow drDes = gvItem.GetDataRow(gvItem.FocusedRowHandle);
                drDes.BeginEdit();
                drDes["F_ItemID"] = dr["F_ID"];
                drDes["F_ItemName"] = dr["F_Name"];
                drDes["F_Spec"] = dr["F_Spec"];
                drDes["F_Unit"] = dr["F_Unit"];
                drDes["F_Qty"] = 1;
                drDes.EndEdit();
                gvItem.UpdateCurrentRow();
            }
            mySelItem.Dispose();
        }

        private void gvItem_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvItem.SetRowCellValue(e.RowHandle, "Aid", gvItem.RowCount);
        }

        /// <summary>
        /// 设置序号
        /// </summary>
        private void SetAutoID()
        {
            int intCnt = gvItem.RowCount;
            gvItem.BeginUpdate();
            for (int i = 0; i < intCnt; i++)
            {
                gvItem.SetRowCellValue(i, "Aid", i + 1);
            }
            gvItem.EndUpdate();
        }

        /// <summary>
        /// 任务单查询
        /// </summary>
        private void ShowTask(DateTime dtStart, DateTime dtEnd)
        {
            string strSQL = "select cast(0 as bit) as F_Select,* from t_Task  where F_Check = 1 and F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            //ds.Tables[0].Columns["F_Select"].ReadOnly = false;
            gcTaskMain.DataSource = ds.Tables[0].DefaultView;
        }

        private void ExpandAll(DataSet dsSource)
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            dtOtherStore = myHelper.GetDs("select * from v_ItemOtherStore").Tables[0];
            dsResult = myHelper.GetDs("exec sp_mrpResult");
            gcResult.DataSource = dsResult.Tables[0].DefaultView;
            foreach(DataRow dr in dsSource.Tables[0].Rows)
            {
                Expand(dr["F_ItemID"].ToString(),Convert.ToDecimal(dr["F_Qty"]));
            }
        }

         /// <summary>
        /// 根据BOM展开
        /// </summary>
        private void Expand(string strItemID,decimal decQty)
        {
            string strSQL;
            decimal decMQty = 0;
           
            strSQL = @"select c.F_ID,c.F_Name,c.F_Spec,b.F_Unit,b.F_Qty,b.F_Waste,b.F_ActuQty,c.F_Price,c.F_SupplierID,
                       (select SUM(F_Qty) from t_StorageQty
                        where F_ItemID = c.F_ID
                        group by F_ItemID) as F_StoreQty
            from t_Bom a,t_BomDetail b,t_Item c 
            where a.F_BillID = b.F_BillID 
            and b.F_ItemID = c.F_ID 
            and a.F_ItemID = '" + strItemID + "'";

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            DataRow drNew = null;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DataRow[] drFind = dsResult.Tables[0].Select("F_ItemID = '"+dr["F_ID"].ToString()+"'");
                if (drFind.Length > 0)
                {
                  if (dr["F_ActuQty"] != DBNull.Value)
                     drFind[0]["F_Qty"] = Convert.ToDecimal(drFind[0]["F_Qty"]) + decQty * Convert.ToDecimal(dr["F_ActuQty"]);
                }
                else
                {
                    drNew = dsResult.Tables[0].NewRow();
                    drNew["F_ItemID"] = dr["F_ID"];
                    drNew["F_ItemName"] = dr["F_Name"];
                    drNew["F_Spec"] = dr["F_Spec"];
                    drNew["F_Unit"] = dr["F_Unit"];
                    drNew["F_StoreQty"] = dr["F_StoreQty"];
                    drNew["F_SupplierID"] = dr["F_SupplierID"];
                    DataRow[] drStore = (dtOtherStore.Select("F_ItemID = '" + dr["F_ID"].ToString() + "'"));
                    if (drStore.Length > 0)
                    {
                        drNew["F_StockQty"] = drStore[0]["F_StockQty"];
                        drNew["F_TaskQty"] = drStore[0]["F_TaskQty"];
                    }
                    if (dr["F_ActuQty"] == DBNull.Value)
                       drNew["F_Qty"] = 0;
                    else
                       drNew["F_Qty"] = decQty * Convert.ToDecimal(dr["F_ActuQty"]);

                    dsResult.Tables[0].Rows.Add(drNew);
                }
                Expand(dr["F_ID"].ToString(),decMQty);  
            }
             
        }

        /// <summary>
        /// 转申购单
        /// </summary>
        private void GenStockApply()
        {
            if (MessageBox.Show(this,"真的要将生成的结果转成申购单吗?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Stock.frmApplyStock myApplyStock = new Stock.frmApplyStock(((DataView)gcResult.DataSource).Table.DataSet);
                 myApplyStock.ShowDialog();
                 myApplyStock.Dispose();      
            }
        }

        private void sbGen_Click(object sender, EventArgs e)
        {
            GenStockApply();
        }

        private void ucTask_RefreshDateChanged(object sender, EventArgs e)
        {
            ShowTask(ucTask.dtStart,ucTask.dtEnd);
        }

        private void sbAddTask_Click(object sender, EventArgs e)
        {
            AddTaskDetail();
        }

        private void ckStock_CheckedChanged(object sender, EventArgs e)
        {
            gvResult.Columns.ColumnByFieldName("F_StockQty").Visible = ckStock.Checked;
            SetResultQty();
        }

        private void ckTask_CheckedChanged(object sender, EventArgs e)
        {
            gvResult.Columns.ColumnByFieldName("F_TaskQty").Visible = ckTask.Checked;
            SetResultQty();
        }

        /// <summary>
        /// MRP结果数据处理
        /// </summary>
        private void SetResultQty()
        {
            object decStockQty, decTaskQty, decQty, decStoreQty;
            decimal decResult = 0;
            int intCnt = gvResult.RowCount;
            for (int i = 0; i < intCnt; i++)
            {
                decStoreQty = gvResult.GetRowCellValue(i, "F_StoreQty");
                decStockQty = gvResult.GetRowCellValue(i, "F_StockQty");
                decTaskQty = gvResult.GetRowCellValue(i, "F_TaskQty");
                decQty = gvResult.GetRowCellValue(i, "F_Qty");

                if (decStoreQty == DBNull.Value) decStoreQty = 0;
                if (decStockQty == DBNull.Value) decStockQty = 0;
                if (decTaskQty == DBNull.Value) decTaskQty = 0;
                if (decQty == DBNull.Value) decQty = 0;

                decResult = Convert.ToDecimal(decQty);

                if (ckStock.Checked == true)
                {
                    decResult = decResult + Convert.ToDecimal(decStockQty);
                }

                if (ckTask.Checked == true)
                {
                    decResult = decResult - Convert.ToDecimal(decTaskQty);
                }

                if (Convert.ToDecimal(decResult) - Convert.ToDecimal(decStoreQty) > 0) 
                    decResult = Convert.ToDecimal(decResult) - Convert.ToDecimal(decStoreQty);
                else
                    decResult = 0;

                gvResult.SetRowCellValue(i, "F_NeedQty", decResult);
            }
        }

        private void TabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == PageResult)
            {
                gvResult.Columns.ColumnByFieldName("F_StockQty").Visible = ckStock.Checked;
                gvResult.Columns.ColumnByFieldName("F_TaskQty").Visible = ckTask.Checked;
                SetResultQty();
            }
        }

        private void ckNewZero_CheckedChanged(object sender, EventArgs e)
        {
            DataView dv = ((DataView)gcTmp.DataSource);
            if (ckNewZero.Checked == true)
                dv.RowFilter = "F_NeedQty <> 0";
            else
                dv.RowFilter = "";
        }

        /// <summary>
        /// 取得可用库存
        /// </summary>
        private void GetEvaQty()
        {

        }

        private void sbPrint_Click(object sender, EventArgs e)
        {
            this.printingSystem.Links[0].PrintDlg();
        }

        private void sbPreview_Click(object sender, EventArgs e)
        {
            PreviewLocalizer.Active = new Common.XtraChinese.DxperienceXtraPrintingLocalizationCHS();
            this.printingSystem.Links[0].ShowPreview();
        }

        private void sbExport_Click(object sender, EventArgs e)
        {
            string strFile = DataLib.sysClass.ShowSaveFileDialog("Excel 文件", "Excel 文件|*.Xls");
            if (strFile != "")
                gvResult.ExportToExcelOld(strFile);
        }

    }
}

