using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;

namespace Report
{
    public partial class frmPayAccount : Common.frmReport
    {
        private int intIndex = -1;
        public frmPayAccount()
        {
            InitializeComponent();
            btnGraphi.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            TabPage.SendToBack();
            cbType.SetValue("按单据");
        }

        /// <summary>
        /// 设置格式
        /// </summary>
        protected override void SetGridFormat()
        {
            Common.frmSetGrid myGrid = new Common.frmSetGrid();
            if (gcReport.IsFocused == true)
                myGrid.gvSource = gvReport;
            if (gcStockIn.IsFocused == true)
                myGrid.gvSource = gvStockIn;
            if (gcPay.IsFocused == true)
                myGrid.gvSource = gvPay;
            if (gcStockBack.IsFocused == true)
                myGrid.gvSource = gvStockBack;

            myGrid.ShowDialog();
            myGrid.Dispose();
        }

        protected override int BindData()
        {
            base.BindData();
            //intIndex = -1;
            //AssignField();
            return 0;
        }

        protected override void AssignField()
        {
            DevExpress.XtraGrid.Views.Grid.GridView gvFormat = null;

            switch (intIndex)
            {
                case -1:
                    gvFormat = gvReport;
                    break;
                case 1:
                    gvFormat = gvStockIn;
                    break;
                case 2:
                    gvFormat = gvPay;
                    break;
                case 3:
                    gvFormat = gvStockBack;
                    break;
                case 4:
                    gvFormat = gvStockIn;
                    break;
                case 5:
                    gvFormat = gvPay;
                    break;
                case 6:
                    gvFormat = gvStockBack;
                    break;
            }

            DataLib.DataHelper myHelper = new DataLib.DataHelper();

            DataSet ds = myHelper.GetDs("select * from t_ReportField where F_Class = '" + ReportTag + "' and F_Tag = '" + intIndex.ToString() + "' order by F_Order");
            DataTable dtGroup = ds.Tables[0];
            if (ds.Tables[0].Rows.Count == 0) return;
            gvFormat.GroupSummary.Clear();

            foreach (GridColumn gc in gvFormat.Columns)
            {
                DataRow[] drTmp = dtGroup.Select("F_Field = '" + gc.FieldName + "'");
                if (drTmp.Length > 0)
                {
                    DataRow dr = drTmp[0];

                    gc.Caption = dr["F_Caption"].ToString();
                    gc.Width = Convert.ToInt32(dr["F_Width"]);
                    gc.Visible = Convert.ToBoolean(dr["F_Visible"]);
                    gc.VisibleIndex = Convert.ToInt32(dr["F_Order"]);

                    if (dr["F_Format"].ToString().Length > 0)
                    {
                        gc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        gc.DisplayFormat.FormatString = dr["F_Format"].ToString();
                    }

                    switch (dr["F_SumType"].ToString())
                    {
                        case "sum":
                            gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            break;
                        case "avg":
                            gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Average;
                            break;
                        case "count":
                            gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                            break;
                        case "max":
                            gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Max;
                            break;
                        case "min":
                            gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Min;
                            break;

                    }

                    if (dr["F_FootFormat"].ToString().Length > 0)
                        gc.SummaryItem.DisplayFormat = dr["F_FootFormat"].ToString();

                    if (Convert.ToBoolean(dr["F_Edit"]) == false)
                    {
                        //gc.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
                        gc.OptionsColumn.AllowFocus = false;
                        gc.OptionsColumn.AllowEdit = false;
                    }

                    if (Convert.ToBoolean(dr["F_Merge"]) == true)
                        gc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                    else
                        gc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;

                    gc.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    if (gc.FieldName == "Aid")
                    {
                        gc.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                        gc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    }

                    if (dr["F_GroupType"].ToString().Length > 0)
                    {
                        GridGroupSummaryItem Gi = new GridGroupSummaryItem();
                        switch (dr["F_GroupType"].ToString())
                        {
                            case "sum":
                                Gi.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                                break;
                            case "avg":
                                Gi.SummaryType = DevExpress.Data.SummaryItemType.Average;
                                break;
                            case "count":
                                Gi.SummaryType = DevExpress.Data.SummaryItemType.Count;
                                break;
                            case "max":
                                Gi.SummaryType = DevExpress.Data.SummaryItemType.Max;
                                break;
                            case "min":
                                Gi.SummaryType = DevExpress.Data.SummaryItemType.Min;
                                break;
                        }

                        Gi.FieldName = dr["F_Field"].ToString();
                        Gi.ShowInGroupColumnFooterName = dr["F_Field"].ToString();
                        Gi.DisplayFormat = dr["F_GroupFormat"].ToString();
                        //Gi.ShowInGroupColumnFooter = gc;
                        gvFormat.GroupSummary.Add(Gi);
                    }
                }
            }
        }


        protected override void SaveFieldFormat()
        {
            string strSumType = "";
            DataRow drColumn;

            DevExpress.XtraGrid.Views.Grid.GridView gvFormat = null;

            switch (intIndex)
            {
                case -1:
                    gvFormat = gvReport;
                    break;
                case 1:
                    gvFormat = gvStockIn;
                    break;
                case 2:
                    gvFormat = gvPay;
                    break;
                case 3:
                    gvFormat = gvStockBack;
                    break;
                case 4:
                    gvFormat = gvStockIn;
                    break;
                case 5:
                    gvFormat = gvPay;
                    break;
                case 6:
                    gvFormat = gvStockBack;
                    break;
            }


            DataLib.DataHelper myHelper = new DataLib.DataHelper();

            DataSet ds = myHelper.GetDs("select * from t_ReportField where F_Class = '" + ReportTag + "' and F_Tag = '" + intIndex.ToString() + "'");
            foreach (GridColumn gc in gvFormat.Columns)
            {
                string strField = gc.FieldName;
                string strCapiton = gc.Caption;
                int intWith = gc.Width;
                bool blnVisible = gc.Visible;

                drColumn = ds.Tables[0].NewRow();

                drColumn["F_Class"] = ReportTag;
                drColumn["F_Tag"] = intIndex;
                drColumn["F_Field"] = gc.FieldName;
                drColumn["F_Caption"] = strCapiton;
                drColumn["F_Width"] = intWith;
                drColumn["F_Visible"] = blnVisible;
                drColumn["F_Edit"] = 0;
                drColumn["F_Format"] = gc.DisplayFormat.FormatString;
                drColumn["F_FootFormat"] = gc.SummaryItem.DisplayFormat;
                drColumn["F_Order"] = gc.VisibleIndex;
                if (gc.OptionsColumn.AllowMerge == DevExpress.Utils.DefaultBoolean.True)
                    drColumn["F_Merge"] = true;
                else
                    drColumn["F_Merge"] = false;
                strSumType = "";
                switch (gc.SummaryItem.SummaryType)
                {
                    case DevExpress.Data.SummaryItemType.Sum:
                        strSumType = "sum";
                        break;
                    case DevExpress.Data.SummaryItemType.Average:
                        strSumType = "avg";
                        break;
                    case DevExpress.Data.SummaryItemType.Count:
                        strSumType = "count";
                        break;
                    case DevExpress.Data.SummaryItemType.Max:
                        strSumType = "max";
                        break;
                    case DevExpress.Data.SummaryItemType.Min:
                        strSumType = "min";
                        break;
                }
                drColumn["F_SumType"] = strSumType;

                GridGroupSummaryItem Gi = GetGroupType(strField);
                if (Gi != null)
                {
                    strSumType = "";
                    switch (Gi.SummaryType)
                    {
                        case DevExpress.Data.SummaryItemType.Sum:
                            strSumType = "sum";
                            break;
                        case DevExpress.Data.SummaryItemType.Average:
                            strSumType = "avg";
                            break;
                        case DevExpress.Data.SummaryItemType.Count:
                            strSumType = "count";
                            break;
                        case DevExpress.Data.SummaryItemType.Max:
                            strSumType = "max";
                            break;
                        case DevExpress.Data.SummaryItemType.Min:
                            strSumType = "min";
                            break;
                    }
                    drColumn["F_GroupType"] = strSumType;
                    drColumn["F_GroupFormat"] = Gi.DisplayFormat;
                }

                ds.Tables[0].Rows.Add(drColumn);
            }

            myHelper.ExecuteSQL("delete from t_ReportField where F_Class = '" + ReportTag + "' and F_Tag = '" + intIndex.ToString() + "'");
            myHelper.SaveData(ds, "select * from t_ReportField where F_Class = '" + ReportTag + "' and F_Tag = '" + intIndex.ToString() + "'");
        }


        /// <summary>
        /// 打印DataSet
        /// </summary>
        /// <returns></returns>
        protected override DataSet GetPrintDS()
        {
            DataTable dt1 = ((DataView)gcReport.DataSource).Table.Copy();
            DataTable dt2 = ((DataView)gcStockIn.DataSource).Table.Copy();
            DataTable dt3 = ((DataView)gcPay.DataSource).Table.Copy();
            DataTable dt4 = ((DataView)gcStockBack.DataSource).Table.Copy();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt1);
            ds.Tables.Add(dt2);
            ds.Tables.Add(dt3);
            ds.Tables.Add(dt4);
            return ds;
        }

        /// <summary>
        /// 图表
        /// </summary>
        protected override void Graphi()
        {
            if (gcReport.DataSource == null) return;
            DataTable dt = ((DataView)gcReport.DataSource).Table;

            Common.frmGraphi myGraphi = new Common.frmGraphi();
            myGraphi.dtGraphi = dt;
            myGraphi.ArgField = "F_Name";
            myGraphi.ValueField = "F_Rest";
            myGraphi.TitleText = this.Text;
            myGraphi.ShowDialog();
            myGraphi.Dispose();
        }


        protected override void SelectIndexChange()
        {
            if (gvReport.FocusedRowHandle < 0)
            {
                strValue = "";
            }
            else
            {
                if (rgOption.SelectedIndex == 1)
                {
                    DataRow dr = gvReport.GetDataRow(gvReport.FocusedRowHandle);
                    strValue = dr["F_SupplierID"].ToString();
                }
            }
            base.SelectIndexChange();
        }

        protected override void FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            base.FocusedRowChanged(sender, e);

            if (gvReport.FocusedRowHandle < 0) return;
            DataRow dr = gvReport.GetDataRow(gvReport.FocusedRowHandle);

            if (cbType.GetValue() == "按单据")
            {
                GetStockIn(dr["F_ID"].ToString());
                DataLib.sysClass.LoadFormatFromDB(gvStockIn, ReportTag, 1);
                //intIndex = 1;
                //AssignField();
                GetPay(dr["F_ID"].ToString());
                DataLib.sysClass.LoadFormatFromDB(gvPay, ReportTag, 2);
                //intIndex = 2;
                //AssignField();
                GetStockBack(dr["F_ID"].ToString());
                DataLib.sysClass.LoadFormatFromDB(gvStockBack, ReportTag, 3);
                //intIndex = 3;
                //AssignField();
            }
            else
            {
                BindStockInDetail(dr["F_ID"].ToString());
                DataLib.sysClass.LoadFormatFromDB(gvStockIn, ReportTag, 4);
                // intIndex = 4;
                // AssignField();
                BindStockPayDetail(dr["F_ID"].ToString());
                DataLib.sysClass.LoadFormatFromDB(gvPay, ReportTag, 5);
                // intIndex = 5;
                // AssignField();
                BindStockBackDetail(dr["F_ID"].ToString());
                DataLib.sysClass.LoadFormatFromDB(gvStockBack, ReportTag, 6);
                // intIndex = 6;
                // AssignField();
            }
        }

        /// <summary>
        /// 采购进货
        /// </summary>
        private void GetStockIn(string strID)
        {
            string strSQL = "";
            strSQL = "select a.F_BillID,a.F_Date,b.F_Name as F_SupplierName,";
            strSQL = strSQL + "a.F_StockTime,c.F_Name as F_DeptName,d.F_Name as F_EmpName,";
            strSQL = strSQL + "a.F_Money,a.F_OtherMoney,a.F_BillMan,a.F_CheckMan,a.F_CheckDate ";
            strSQL = strSQL + "from t_StockIn a ";
            strSQL = strSQL + "left join t_Supplier b ";
            strSQL = strSQL + "on a.F_SupplierID = b.F_ID ";
            strSQL = strSQL + "left join t_Class c ";
            strSQL = strSQL + "on a.F_DeptID = c.F_ID ";
            strSQL = strSQL + "left join t_Emp d ";
            strSQL = strSQL + "on a.F_StockMan = d.F_ID ";
            strSQL = strSQL + "where isnull(a.F_Check,0) = 1 ";
            strSQL = strSQL + "and a.F_Date >= '"+ucDate.dtStart.ToString()+"'";
            strSQL = strSQL + "and a.F_Date <= '" + ucDate.dtEnd.ToString() + "'";
            strSQL = strSQL + "and a.F_SupplierID = '" + strID + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gvStockIn.Columns.Clear();
            gcStockIn.DataSource = ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 采购进货明细
        /// </summary>
        private void BindStockInDetail(string strID)
        {
            string strSQL = "";
            strSQL = "select a.*,c.F_Name,c.F_Spec,c.F_Brand,c.F_Material ";
            strSQL = strSQL + "from t_StockInDetail a ";
            strSQL = strSQL + "left join t_StockIn b ";
            strSQL = strSQL + "on a.F_BillID = b.F_BillID ";
            strSQL = strSQL + "left join t_Item c ";
            strSQL = strSQL + "on a.F_ItemID = c.F_ID ";
            strSQL = strSQL + "where b.F_SupplierID = '" + strID + "'";
            strSQL = strSQL + "and b.F_Check = 1 ";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gvStockIn.Columns.Clear();
            gcStockIn.DataSource = ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 采购付款
        /// </summary>
        private void GetPay(string strID)
        {
            string strSQL = "";
            strSQL = "select a.F_BillID,a.F_Date,b.F_Name as F_SupplierName,";
            strSQL = strSQL + "a.F_PayType,a.F_Kind,a.F_Money,a.F_DisMoney,";
            strSQL = strSQL + "a.F_BillMan,a.F_CheckMan,a.F_CheckDate ";
            strSQL = strSQL + "from t_Pay a ";
            strSQL = strSQL + "left join t_Supplier b ";
            strSQL = strSQL + "on a.F_SupplierID = b.F_ID ";
            strSQL = strSQL + "where isnull(a.F_Check,0) = 1 ";
            strSQL = strSQL + "and a.F_Date >= '" + ucDate.dtStart.ToString() + "'";
            strSQL = strSQL + "and a.F_Date <= '" + ucDate.dtEnd.ToString() + "'";
            strSQL = strSQL + "and a.F_SupplierID = '" + strID + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gvPay.Columns.Clear();
            gcPay.DataSource = ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 销售收款明细
        /// </summary>
        private void BindStockPayDetail(string strID)
        {
            string strSQL = "";
            strSQL = "select a.* from t_PayDetail a,t_Pay b where a.F_BillID = b.F_BillID and F_SupplierID = '" + strID + "' and b.F_Check = 1";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gvPay.Columns.Clear();
            gcPay.DataSource = ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 采购退货
        /// </summary>
        private void GetStockBack(string strID)
        {
            string strSQL = "";
            strSQL = "select a.F_BillID,a.F_Date,b.F_Name as F_SupplierName,";
            strSQL = strSQL + "a.F_Kind,a.F_Reason,";
            strSQL = strSQL + "a.F_Money,a.F_OtherMoney,a.F_BillMan,a.F_CheckMan,a.F_CheckDate ";
            strSQL = strSQL + "from t_StockBack a ";
            strSQL = strSQL + "left join t_Supplier b ";
            strSQL = strSQL + "on a.F_SupplierID = b.F_ID ";
            strSQL = strSQL + "where a.F_Date >= '" + ucDate.dtStart.ToString() + "'";
            strSQL = strSQL + "and a.F_Date <= '" + ucDate.dtEnd.ToString() + "'";
            strSQL = strSQL + "and a.F_SupplierID = '" + strID + "'";
            strSQL = strSQL + "and a.F_Kind = '供应商退现款'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gvStockBack.Columns.Clear();
            gcStockBack.DataSource = ds.Tables[0].DefaultView;
        } 

        /// <summary>
        /// 销售退货明细
        /// </summary>
        private void BindStockBackDetail(string strID)
        {
            string strSQL = "";
            strSQL = "select a.*,c.F_Name,c.F_Spec,c.F_Brand,c.F_Material ";
            strSQL = strSQL + "from t_StockBackDetail a ";
            strSQL = strSQL + "left join t_StockBack b ";
            strSQL = strSQL + "on a.F_BillID = b.F_BillID ";
            strSQL = strSQL + "left join t_Item c ";
            strSQL = strSQL + "on a.F_ItemID = c.F_ID ";
            strSQL = strSQL + "where b.F_SupplierID = '" + strID + "'";
            strSQL = strSQL + "and b.F_Check = 1 ";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gvStockBack.Columns.Clear();
            gcStockBack.DataSource = ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 打开进货单
        /// </summary>
        private void ShowStockIn()
        {
            if (gvStockIn.FocusedRowHandle < 0) return;
            DataRow dr = gvStockIn.GetDataRow(gvStockIn.FocusedRowHandle);
            Stock.frmStockIn myStockIn = new Stock.frmStockIn();
            myStockIn.strBillID = dr["F_BillID"].ToString();
            myStockIn.ShowDialog();
            myStockIn.Dispose();
        }

        /// <summary>
        /// 打开付款单
        /// </summary>
        private void ShowPay()
        {
            if (gvPay.FocusedRowHandle < 0) return;
            DataRow dr = gvPay.GetDataRow(gvPay.FocusedRowHandle);
            Stock.frmStockPay myStockPay = new Stock.frmStockPay();
            myStockPay.strBillID = dr["F_BillID"].ToString();
            myStockPay.ShowDialog();
            myStockPay.Dispose();
        }

        /// <summary>
        /// 打开退货单
        /// </summary>
        private void ShowStockBack()
        {
            if (gvStockBack.FocusedRowHandle < 0) return;
            DataRow dr = gvStockBack.GetDataRow(gvStockBack.FocusedRowHandle);
            Stock.frmStockBack myStockBack = new Stock.frmStockBack();
            myStockBack.strBillID = dr["F_BillID"].ToString();
            myStockBack.ShowDialog();
            myStockBack.Dispose();
        }

        protected override void Export()
        {
            if (DataLib.SysVar.strUGroup != "超级用户")
            {
                DataLib.DataHelper myHelper = new DataLib.DataHelper();
                DataSet ds = myHelper.GetDs("select F_Export from t_UserGroup where F_Group = '" + DataLib.SysVar.strUGroup + "'");
                if (Convert.ToBoolean(ds.Tables[0].Rows[0][0]) == false)
                {
                    MessageBox.Show(this, "你没有权限!", "提示");
                    return;
                }
            }
            
            if (MessageBox.Show(this, "本报表导出将会在C:\\ExportFile路径下产生4个Excel文件,确定进行数据导出吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            
            if (Directory.Exists("C:\\ExportFile") == true)
            {
                Directory.Delete("C:\\ExportFile",true);
            }

            Directory.CreateDirectory("C:\\ExportFile");
            
            gvReport.ExportToExcelOld("C:\\ExportFile\\客户收款汇总.xls");

            gvStockIn.ExportToExcelOld("C:\\ExportFile\\采购单.xls");
            gvPay.ExportToExcelOld("C:\\ExportFile\\付款.xls");
            gvStockBack.ExportToExcelOld("C:\\ExportFile\\采购退货.xls");

            string path = @"C:\ExportFile";
            System.Diagnostics.Process.Start("explorer.exe", path); 
        }

        //protected override PRINT

        private void gvStockIn_DoubleClick(object sender, EventArgs e)
        {
            ShowStockIn();
        }

        private void gvPay_DoubleClick(object sender, EventArgs e)
        {
            ShowPay();
        }

        private void gvStockBack_DoubleClick(object sender, EventArgs e)
        {
            ShowStockBack();
        }


        private void cbType_SelectIndexChange(object sender, EventArgs e)
        {
            BindData();
            FocusedRowChanged(null, null);
        }

        private void frmPayAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && DataLib.SysVar.strUGroup == "超级用户")
            {


                if (cbType.GetValue() == "按单据")
                {

                    //intIndex = 1;
                    DataLib.sysClass.SaveGridToDB(gvStockIn, ReportTag, 1);
                    DataLib.sysClass.SaveGridToDB(gvPay, ReportTag, 2);
                    DataLib.sysClass.SaveGridToDB(gvStockBack, ReportTag, 3);
                    //SaveFieldFormat();
                    //intIndex = 2;
                    //SaveFieldFormat();
                    //intIndex = 3;
                    //SaveFieldFormat();
                }
                else
                {
                    DataLib.sysClass.SaveGridToDB(gvStockIn, ReportTag, 4);
                    DataLib.sysClass.SaveGridToDB(gvPay, ReportTag, 5);
                    DataLib.sysClass.SaveGridToDB(gvStockBack, ReportTag, 6);
                    //intIndex = 4;
                    //SaveFieldFormat();
                    //intIndex = 5;
                    //SaveFieldFormat();
                    //intIndex = 6;
                    //SaveFieldFormat();
                }

            }
        }
    }
}

