using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;

namespace Sell
{
    public partial class frmAcceptImport : BaseClass.frmBase
    {
        public string strValue;
        private string _BillTag = "";
        public DataTable dtDes;

        public frmAcceptImport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 单据标志
        /// </summary>
        protected string BillTag
        {
            get
            {
                if (_BillTag == "")
                    _BillTag = this.Name;
                return _BillTag;
            }
            set
            {
                _BillTag = value;
            }
        }

        /// <summary>
        /// 设置单据明细字段
        /// </summary>
        private void AssignField()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_ReportField where F_Class = '" + BillTag + "' and F_Tag = '0' order by F_Order");
            if (ds.Tables[0].Rows.Count == 0) return;
            gvMain.Columns.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                GridColumn gc = gvMain.Columns.AddField(dr["F_Field"].ToString());
                gc.Caption = dr["F_Caption"].ToString();
                gc.Width = Convert.ToInt32(dr["F_Width"]);
                gc.Visible = Convert.ToBoolean(dr["F_Visible"]);

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

        /// <summary>
        /// 保存字段格式
        /// </summary>
        private void SaveFieldFormat()
        {
            string strSumType = "";
            DataRow drColumn;
            bool blnFlag = false, blnTag = false;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_ReportField where F_Class = '" + BillTag + "' and F_Tag = '0' order by F_Order");

            if (ds.Tables[0].Rows.Count == 0)
                blnTag = false;
            else
                blnTag = true;

            foreach (GridColumn gc in gvMain.Columns)
            {
                string strField = gc.FieldName;
                string strCapiton = gc.Caption;
                int intWith = gc.Width;
                bool blnVisible = gc.Visible;
                if (blnTag == false)
                {
                    drColumn = ds.Tables[0].NewRow();
                    blnFlag = true;
                }
                else
                {
                    DataRow[] dr = ds.Tables[0].Select("F_Field = '" + strField + "'");
                    drColumn = dr[0];
                }
                drColumn["F_Class"] = BillTag;
                drColumn["F_Tag"] = "0";
                drColumn["F_Field"] = gc.FieldName;
                drColumn["F_Caption"] = strCapiton;
                drColumn["F_Width"] = intWith;
                drColumn["F_Visible"] = blnVisible;
                drColumn["F_Edit"] = 0;
                drColumn["F_Format"] = "";
                drColumn["F_FootFormat"] = "";
                drColumn["F_Order"] = gc.VisibleIndex;
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
                if (blnFlag == false)
                    drColumn.EndEdit();
                else
                    ds.Tables[0].Rows.Add(drColumn);
            }

            myHelper.SaveData(ds, "select * from t_ReportField where F_Class = '" + BillTag + "' and F_Tag = '0'");
        }

        private Hashtable GetParm3()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            parm.Add("@Value", strValue);
            /*
            DataLib.JxcService.SqlParameter[] parm =
                    {      
                       new   DataLib.JxcService.SqlParameter(),   
                       new   DataLib.JxcService.SqlParameter(),
                       new   DataLib.JxcService.SqlParameter()
                    };

            parm[0].ParameterName = "@Start";
            parm[0].SqlDbType = DataLib.JxcService.SqlDbType.DateTime;
            parm[0].Value = ucDate.dtStart;

            parm[1].ParameterName = "@End";
            parm[1].SqlDbType = DataLib.JxcService.SqlDbType.DateTime;
            parm[1].Value = ucDate.dtEnd;

            parm[2].ParameterName = "@Value";
            parm[2].SqlDbType = DataLib.JxcService.SqlDbType.VarChar;
            parm[2].Value = strValue;
            */
            return parm;
        }

        private void DataBind()
        {
            string strSQL = "";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            strSQL = "select isnull(F_QcMoney,0) - isnull(F_QCHasMoney,0) as F_Money from t_Client where F_ID = '" + strValue + "'";
            DataSet ds = myHelper.GetDs(strSQL);
            if (Convert.ToDecimal(ds.Tables[0].Rows[0]["F_Money"]) > 0)
            {

                strSQL = "select '期初' as F_Tag,'期初' as F_BillID,'1900-1-1' as F_Date,F_QcMoney as F_TotalMoney,F_QCHasMoney as F_AcceptMoney,";
                strSQL = strSQL + "isnull(F_QcMoney,0) - isnull(F_QCHasMoney,0) as F_NoAccept,Cast(0 as Bit) as F_Select from t_Client where F_ID = @Value and isnull(F_QcMoney,0) - isnull(F_QCHasMoney,0) > 0";
                strSQL = strSQL + " union all ";
            }
            else
                strSQL = "";

            strSQL = strSQL + "select '送货单' as F_Tag,F_BillID,F_Date,isnull(F_Money,0)+isnull(F_OtherMoney,0) as F_TotalMoney,";
            strSQL = strSQL + "F_AcceptMoney,isnull(F_Money,0)+isnull(F_OtherMoney,0) - isnull(F_AcceptMoney,0) as F_NoAccept,";
            strSQL = strSQL + "Cast(0 as Bit) as F_Select ";
            strSQL = strSQL + "from t_SellOut where F_Check = 1 and isnull(F_Money,0)+isnull(F_OtherMoney,0) - isnull(F_AcceptMoney,0) <> 0 ";
            strSQL = strSQL + "and F_AcceptDate >= @Start and F_AcceptDate <= @End and F_ClientID = @Value";
            strSQL = strSQL + " union all ";
            strSQL = strSQL + "select '退货单',F_BillID,F_Date,isnull(F_Money,0)+isnull(F_OtherMoney,0),"; 
            strSQL = strSQL + "F_AcceptMoney,isnull(F_Money,0)+isnull(F_OtherMoney,0) - isnull(F_AcceptMoney,0) as F_NoAccept,";
            strSQL = strSQL + "Cast(0 as Bit) as F_Select ";
            strSQL = strSQL + "from t_SellBack ";
            strSQL = strSQL + "where F_Check = 1 and isnull(F_Money,0)+isnull(F_OtherMoney,0) - isnull(F_AcceptMoney,0) <> 0 ";
            strSQL = strSQL + "and F_AcceptDate >= @Start and F_AcceptDate <= @End and F_ClientID = @Value ";
            strSQL = strSQL + "and F_Kind = '退款转应收款'";

            ds = myHelper.GetOtherDs(strSQL, GetParm3());
            gcMain.DataSource = ds.Tables[0].DefaultView;
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPayImport_Shown(object sender, EventArgs e)
        {
            DataBind();
            AssignField();
        }

        private void frmAcceptImport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
            {
                Common.frmSetGrid myGrid = new Common.frmSetGrid();
                myGrid.gvSource = gvMain;
                myGrid.ShowDialog();
                myGrid.Dispose();
            }


            if (e.KeyCode == Keys.F5)
                SaveFieldFormat();
        }

        private void Import()
        {
            dtDes.Rows.Clear();
            int intCnt = gvMain.RowCount;
            for (int i = 0; i < intCnt; i++)
            {
                DataRow dr = gvMain.GetDataRow(i);
                if (Convert.ToBoolean(dr["F_Select"]) == false) continue;
                DataRow drNew = dtDes.NewRow();
                drNew["AID"] = i + 1;
                drNew["F_Tag"] = dr["F_Tag"];
                drNew["F_LinkBill"] = dr["F_BillID"];
                drNew["F_Date"] = dr["F_Date"];
                drNew["F_BillMoney"] = dr["F_TotalMoney"];
                drNew["F_HasMoney"] = dr["F_AcceptMoney"];
                drNew["F_NoMoney"] = dr["F_NoAccept"];
                drNew["F_Flag"] = false;

                if (dr["F_Tag"].ToString() == "送货单" || dr["F_Tag"].ToString() == "期初")
                {
                    drNew["F_BillMoney1"] = dr["F_TotalMoney"];
                    drNew["F_HasMoney1"] = dr["F_AcceptMoney"];
                    drNew["F_NoMoney1"] = dr["F_NoAccept"];
                }
                else
                {
                    if (dr["F_TotalMoney"] != DBNull.Value)
                        drNew["F_BillMoney1"] = -Convert.ToDecimal(dr["F_TotalMoney"]);
                    if (dr["F_AcceptMoney"] != DBNull.Value)
                        drNew["F_HasMoney1"] = -Convert.ToDecimal(dr["F_AcceptMoney"]);
                    if (dr["F_NoAccept"] != DBNull.Value)
                        drNew["F_NoMoney1"] = -Convert.ToDecimal(dr["F_NoAccept"]);
                } 

                dtDes.Rows.Add(drNew);
            }
        }

        private void ckAll_CheckedChanged(object sender, EventArgs e)
        {
            int intCnt = gvMain.RowCount;
            for (int i = 0; i < intCnt; i++)
            {
                gvMain.SetRowCellValue(i, "F_Select", ckAll.Checked);
            }
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            Import();
            this.DialogResult = DialogResult.OK;
        }

        private void ucDate_RefreshDateChanged(object sender, EventArgs e)
        {
            DataBind();
        }
    }
}

