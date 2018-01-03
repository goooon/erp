using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;

namespace Report
{
    public partial class frmAcceptAccount : Common.frmReport
    {
        private int intIndex = -1;
        public frmAcceptAccount()
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
            if (gcSellOut.IsFocused == true)
                myGrid.gvSource = gvSellOut;
            if (gcAccept.IsFocused == true)
                myGrid.gvSource = gvAccept;
            if (gcSellBack.IsFocused == true)
                myGrid.gvSource = gvSellBack;

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
                    gvFormat = gvSellOut;
                    break;
                case 2:
                    gvFormat = gvAccept;
                    break;
                case 3:
                    gvFormat = gvSellBack;
                    break;
                case 4:
                    gvFormat = gvSellOut;
                    break;
                case 5:
                    gvFormat = gvAccept;
                    break;
                case 6:
                    gvFormat = gvSellBack;
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
                    gvFormat = gvSellOut;
                    break;
                case 2:
                    gvFormat = gvAccept;
                    break;
                case 3:
                    gvFormat = gvSellBack;
                    break;
                case 4:
                    gvFormat = gvSellOut;
                    break;
                case 5:
                    gvFormat = gvAccept;
                    break;
                case 6:
                    gvFormat = gvSellBack;
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
            DataTable dt2 = ((DataView)gcSellOut.DataSource).Table.Copy();
            DataTable dt3 = ((DataView)gcAccept.DataSource).Table.Copy();
            DataTable dt4 = ((DataView)gcSellBack.DataSource).Table.Copy();
            dt1.TableName = "dt1";
            dt2.TableName = "dt2";
            dt3.TableName = "dt3";
            dt4.TableName = "dt4";
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
            if (gvReport.FocusedRowHandle < 0) return;
            if (rgOption.SelectedIndex == 1)
            {
                DataRow dr = gvReport.GetDataRow(gvReport.FocusedRowHandle);
                strValue = dr["F_SupplierID"].ToString();
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
                GetSellOut(dr["F_ID"].ToString());
                DataLib.sysClass.LoadFormatFromDB(gvSellOut, ReportTag, 1);
                //intIndex = 1;
                //AssignField();
                GetAccept(dr["F_ID"].ToString());
                DataLib.sysClass.LoadFormatFromDB(gvAccept, ReportTag, 2);
                //intIndex = 2;
                //AssignField();
                GetSellBack(dr["F_ID"].ToString());
                DataLib.sysClass.LoadFormatFromDB(gvSellBack, ReportTag, 3);
                //intIndex = 3;
                //AssignField();
            }
            else
            {
                BindSellOutDetail(dr["F_ID"].ToString());
                DataLib.sysClass.LoadFormatFromDB(gvSellOut, ReportTag, 4);
               // intIndex = 4;
               // AssignField();
                BindAcceptDetail(dr["F_ID"].ToString());
                DataLib.sysClass.LoadFormatFromDB(gvAccept, ReportTag, 5);
               // intIndex = 5;
               // AssignField();
                BindSellBackDetail(dr["F_ID"].ToString());
                DataLib.sysClass.LoadFormatFromDB(gvSellBack, ReportTag, 6);
               // intIndex = 6;
               // AssignField();
            }
        }

      
        /// <summary>
        /// 销售出货
        /// </summary>
        private void GetSellOut(string strID)
        {
            string strSQL = "";
            strSQL = "select a.F_BillID,a.F_Date,b.F_Name as F_ClientName,";
            strSQL = strSQL + "c.F_Name as F_DeptName,d.F_Name as F_EmpName,";
            strSQL = strSQL + "a.F_Money,a.F_OtherMoney,a.F_BillMan,a.F_CheckMan,a.F_CheckDate ";
            strSQL = strSQL + "from t_SellOut a ";
            strSQL = strSQL + "left join t_Client b ";
            strSQL = strSQL + "on a.F_ClientID = b.F_ID ";
            strSQL = strSQL + "left join t_Class c ";
            strSQL = strSQL + "on a.F_DeptID = c.F_ID ";
            strSQL = strSQL + "left join t_Emp d ";
            strSQL = strSQL + "on a.F_Opertor = d.F_ID ";
            strSQL = strSQL + "where isnull(a.F_Check,0) = 1 ";
            strSQL = strSQL + "and a.F_Date >= '"+ucDate.dtStart.ToString()+"'";
            strSQL = strSQL + "and a.F_Date <= '" + ucDate.dtEnd.ToString() + "'";
            strSQL = strSQL + "and a.F_ClientID = '" + strID + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gvSellOut.Columns.Clear();
            gcSellOut.DataSource = ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 销售发货明细
        /// </summary>
        private void BindSellOutDetail(string strID)
        {
            string strSQL = "";
            strSQL = "select a.*,c.F_Name,c.F_Spec,c.F_Brand,c.F_Material ";
            strSQL = strSQL + "from t_SellOutDetail a ";
            strSQL = strSQL + "left join t_SellOut b ";
            strSQL = strSQL + "on a.F_BillID = b.F_BillID ";
            strSQL = strSQL + "left join t_Item c ";
            strSQL = strSQL + "on a.F_ItemID = c.F_ID ";
            strSQL = strSQL + "where b.F_ClientID = '" + strID + "'";
            strSQL = strSQL + " and b.F_Check = 1 ";
            DataLib.DataHelper myHelper = new DataLib.DataHelper(); 
            DataSet ds = myHelper.GetDs(strSQL);
            gvSellOut.Columns.Clear();
            gcSellOut.DataSource = ds.Tables[0].DefaultView;
        }


        /// <summary>
        /// 销售收款
        /// </summary>
        private void GetAccept(string strID)
        {
            string strSQL = "";
            strSQL = "select a.F_BillID,a.F_Date,b.F_Name as F_ClientName,";
            strSQL = strSQL + "a.F_AcceptType,a.F_Kind,a.F_Money,a.F_DisMoney,";
            strSQL = strSQL + "a.F_BillMan,a.F_CheckMan,a.F_CheckDate ";
            strSQL = strSQL + "from t_Accept a ";
            strSQL = strSQL + "left join t_Client b ";
            strSQL = strSQL + "on a.F_ClientID = b.F_ID ";
            strSQL = strSQL + "where isnull(a.F_Check,0) = 1 ";
            strSQL = strSQL + "and a.F_Date >= '" + ucDate.dtStart.ToString() + "'";
            strSQL = strSQL + "and a.F_Date <= '" + ucDate.dtEnd.ToString() + "'";
            strSQL = strSQL + "and a.F_ClientID = '" + strID + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gvAccept.Columns.Clear();
            gcAccept.DataSource = ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 销售收款明细
        /// </summary>
        private void BindAcceptDetail(string strID)
        {
            string strSQL = "";
            strSQL = "select a.* from t_AcceptDetail a,t_Accept b where a.F_BillID = b.F_BillID and b.F_ClientID = '" + strID + "' and b.F_Check = 1";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gvAccept.Columns.Clear();
            gcAccept.DataSource = ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 销售退货
        /// </summary>
        private void GetSellBack(string strID)
        {
            string strSQL = "";
            strSQL = "select a.F_BillID,a.F_Date,b.F_Name as F_ClientName,";
            strSQL = strSQL + "a.F_Kind,a.F_Reason,";
            strSQL = strSQL + "a.F_Money,a.F_OtherMoney,a.F_BillMan,a.F_CheckMan,a.F_CheckDate ";
            strSQL = strSQL + "from t_SellBack a ";
            strSQL = strSQL + "left join t_Client b ";
            strSQL = strSQL + "on a.F_ClientID = b.F_ID ";
            strSQL = strSQL + "where a.F_Date >= '" + ucDate.dtStart.ToString() + "'";
            strSQL = strSQL + "and a.F_Date <= '" + ucDate.dtEnd.ToString() + "'";
            strSQL = strSQL + "and a.F_ClientID = '" + strID + "'";
            strSQL = strSQL + "and a.F_Kind = '退现款给客户'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gvSellBack.Columns.Clear();
            gcSellBack.DataSource = ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 销售退货明细
        /// </summary>
        private void BindSellBackDetail(string strID)
        {
            string strSQL = "";
            strSQL = "select a.*,c.F_Name,c.F_Spec,c.F_Brand,c.F_Material ";
            strSQL = strSQL + "from t_SellBackDetail a ";
            strSQL = strSQL + "left join t_SellBack b ";
            strSQL = strSQL + "on a.F_BillID = b.F_BillID ";
            strSQL = strSQL + "left join t_Item c ";
            strSQL = strSQL + "on a.F_ItemID = c.F_ID ";
            strSQL = strSQL + "where b.F_ClientID = '" + strID + "'";
            strSQL = strSQL + " and b.F_Check = 1 ";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gvSellBack.Columns.Clear();
            gcSellBack.DataSource = ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 打开销售单
        /// </summary>
        private void ShowSellOut()
        {
            if (gvSellOut.FocusedRowHandle < 0) return;
            DataRow dr = gvSellOut.GetDataRow(gvSellOut.FocusedRowHandle);
            Sell.frmSellOut mySellOut = new Sell.frmSellOut();
            mySellOut.strBillID = dr["F_BillID"].ToString();
            mySellOut.ShowDialog();
            mySellOut.Dispose();
        }

        /// <summary>
        /// 打开收款单
        /// </summary>
        private void ShowAccept()
        {
            if (gvAccept.FocusedRowHandle < 0) return;
            DataRow dr = gvAccept.GetDataRow(gvAccept.FocusedRowHandle);
            Sell.frmSellAccept mySellAccept = new Sell.frmSellAccept();
            mySellAccept.strBillID = dr["F_BillID"].ToString();
            mySellAccept.ShowDialog();
            mySellAccept.Dispose();
        }

        /// <summary>
        /// 打开退货单
        /// </summary>
        private void ShowSellBack()
        {
            if (gvSellBack.FocusedRowHandle < 0) return;
            DataRow dr = gvSellBack.GetDataRow(gvSellBack.FocusedRowHandle);
            Sell.frmSellBack mySellBack = new Sell.frmSellBack();
            mySellBack.strBillID = dr["F_BillID"].ToString();
            mySellBack.ShowDialog();
            mySellBack.Dispose();
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

            if (MessageBox.Show(this,"本报表导出将会在C:\\ExportFile路径下产生4个Excel文件,确定进行数据导出吗?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No) return;

            if (Directory.Exists("C:\\ExportFile") == true)
            {
                Directory.Delete("C:\\ExportFile", true);
            }

            Directory.CreateDirectory("C:\\ExportFile");
            //string strFile = DataLib.sysClass.ShowSaveFileDialog("Excel 文件", "Excel 文件|*.Xls");
            //if (strFile != "")
            //{
                gvReport.ExportToExcelOld("C:\\ExportFile\\客户收款汇总.xls");
                gvSellOut.ExportToExcelOld("C:\\ExportFile\\销售.xls");
                gvAccept.ExportToExcelOld("C:\\ExportFile\\收款.xls");
                gvSellBack.ExportToExcelOld("C:\\ExportFile\\退货.xls");
            //}

              string path = @"C:\ExportFile";
              System.Diagnostics.Process.Start("explorer.exe", path); 
        }

        private void gvStockIn_DoubleClick(object sender, EventArgs e)
        {
            ShowSellOut();
        }

        private void gvPay_DoubleClick(object sender, EventArgs e)
        {
            ShowAccept();
        }

        private void gvStockBack_DoubleClick(object sender, EventArgs e)
        {
            ShowSellBack();
        }

        private void cbType_SelectIndexChange(object sender, EventArgs e)
        {
            BindData();
            FocusedRowChanged(null, null);
        }

        private void frmAcceptAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && DataLib.SysVar.strUGroup == "超级用户")
            {
                if (cbType.GetValue() == "按单据")
                {
                    
                    //intIndex = 1;
                    DataLib.sysClass.SaveGridToDB(gvSellOut, ReportTag, 1);
                    DataLib.sysClass.SaveGridToDB(gvAccept, ReportTag, 2);
                    DataLib.sysClass.SaveGridToDB(gvSellBack, ReportTag, 3);
                    //SaveFieldFormat();
                    //intIndex = 2;
                    //SaveFieldFormat();
                    //intIndex = 3;
                    //SaveFieldFormat();
                }
                else
                {
                    DataLib.sysClass.SaveGridToDB(gvSellOut, ReportTag, 4);
                    DataLib.sysClass.SaveGridToDB(gvAccept, ReportTag, 5);
                    DataLib.sysClass.SaveGridToDB(gvSellBack, ReportTag, 6);
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

