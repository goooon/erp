using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPrinting.Localization; 

namespace UserReport
{
    public partial class frmReportEx : BaseClass.frmBase
    {
        public string strQuerySQL = "";
        public string strName;

        public frmReportEx()
        {
            InitializeComponent();
            Common.XtraChinese p = new Common.XtraChinese();
            p.chineseXtraGrid(this.gcReport);
        }

        private void tbExit_Click(object sender, EventArgs e)
        {
            Close();
        }


        /// <summary>
        /// 设置单据明细字段
        /// </summary>
        private void AssignField()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_UserField where F_Report = '" + strName + "' order by F_Order");
            DataTable dtGroup = ds.Tables[0];
            if (ds.Tables[0].Rows.Count == 0) return;

            foreach (GridColumn gc in gvReport.Columns)
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

                    if (Convert.ToBoolean(dr["F_Merge"]) == true)
                        gc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                    else
                        gc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;

                    if (dr["F_FootFormat"].ToString().Length > 0)
                        gc.SummaryItem.DisplayFormat = dr["F_FootFormat"].ToString();

                    if (Convert.ToBoolean(dr["F_Edit"]) == false)
                    {
                        //gc.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
                        gc.OptionsColumn.AllowFocus = false;
                        gc.OptionsColumn.AllowEdit = false;
                    }
                    gc.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    if (gc.FieldName == "Aid")
                    {
                        gc.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                        gc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    }

                }
            }
        }

        /// <summary>
        /// 保存字段格式
        /// </summary>
        private void SaveFieldFormat()
        {
            string strSumType = "";
            DataRow drColumn;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();

            DataSet ds = myHelper.GetDs("select * from t_UserField where F_Report = '" + strName + "'");
            foreach (GridColumn gc in gvReport.Columns)
            {
                string strField = gc.FieldName;
                string strCapiton = gc.Caption;
                int intWith = gc.Width;
                bool blnVisible = gc.Visible;

                drColumn = ds.Tables[0].NewRow();

                drColumn["F_Report"] = strName;
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
                ds.Tables[0].Rows.Add(drColumn);
            }

            myHelper.ExecuteSQL("delete from t_UserField where F_Report = '" + strName + "'");
            myHelper.SaveData(ds, "select * from t_UserField where F_Report = '" + strName + "'");
        }



        /// <summary>
        /// 报表参数
        /// </summary>
        /// <returns></returns>
        private Hashtable GetParm()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            /*
            DataLib.JxcService.SqlParameter[] parm =
                    {     
                        new   DataLib.JxcService.SqlParameter(),
                        new   DataLib.JxcService.SqlParameter()
                    };

            parm[0].ParameterName = "@Start";
            parm[0].SqlDbType = DataLib.JxcService.SqlDbType.DateTime;
            parm[0].Value = ucDate.dtStart;

            parm[1].ParameterName = "@End";
            parm[1].SqlDbType = DataLib.JxcService.SqlDbType.DateTime;
            parm[1].Value = ucDate.dtEnd;
            */
            return parm;
        }

        /// <summary>
        /// 设置SQL语句
        /// </summary>
        private void SetSQL()
        {
            gvReport.Columns.Clear();
            DataLib.DataHelper myHelper = new DataLib.DataHelper();

            DataSet ds = myHelper.GetDs("select * from t_UserReport where F_Name = '" + strName + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["F_SQL"] != Convert.DBNull)
                {
                    strQuerySQL = ds.Tables[0].Rows[0]["F_SQL"].ToString();
                    DataBind();
                }
            }
            ds.Dispose();
        }

        private int DataBind()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetOtherDs(strQuerySQL, GetParm());
            if (ds == null) return -1;
            gcReport.DataSource = ds.Tables[0].DefaultView;
            AssignField();
            return 0;
        }

        private void tbExport_Click(object sender, EventArgs e)
        {
            string strFile = DataLib.sysClass.ShowSaveFileDialog("Excel 文件", "Excel 文件|*.Xls");
            if (strFile != "")
                gvReport.ExportToExcelOld(strFile);
        }

        private void tbPrint_Click(object sender, EventArgs e)
        {
            PreviewLocalizer plZer = new Common.XtraChinese.DxperienceXtraPrintingLocalizationCHS();
            DataLib.sysClass myClass = new DataLib.sysClass();
            myClass.DoPrint(this.Text, plZer, this.printingSystem);
        }

        private void tbPreview_Click(object sender, EventArgs e)
        {
            PreviewLocalizer plZer = new Common.XtraChinese.DxperienceXtraPrintingLocalizationCHS();
            DataLib.sysClass myClass = new DataLib.sysClass();
            myClass.DoPreview(this.Text, plZer, this.printingSystem);
        }

        private void tbSet_Click(object sender, EventArgs e)
        {
            Common.frmSetGrid myGrid = new Common.frmSetGrid();
            myGrid.gvSource = gvReport;
            myGrid.ShowDialog();
            myGrid.Dispose();
        }

        private void ucDate_RefreshDateChanged(object sender, EventArgs e)
        {
            DataBind();
        }

        private void frmReportEx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.F9)
            {
                 Common.frmSQL mySQL = new Common.frmSQL();
                 mySQL.MeSQL.Text = strQuerySQL;
                 if (mySQL.ShowDialog() == DialogResult.OK)
                 {
                     strQuerySQL = mySQL.MeSQL.Text;
                     if (DataBind() == 0)
                     {
                         DataLib.DataHelper myHelper = new DataLib.DataHelper();
                         string strSQL = "select * from t_UserReport where F_Name = '" + strName + "'";
                         DataSet ds = myHelper.GetDs(strSQL);
                         ds.Tables[0].Rows[0]["F_SQL"] = strQuerySQL;
                         myHelper.SaveData(ds, strSQL);
                     }
                 }
                 mySQL.Dispose();
            }

            if (e.KeyCode == Keys.F5)
                SaveFieldFormat();

            if (e.KeyCode == Keys.F7)
                tbSet_Click(null, null);

        }

        private void frmReportEx_Load(object sender, EventArgs e)
        {
            SetSQL();
        }
    }
}

