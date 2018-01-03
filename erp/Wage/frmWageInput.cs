using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Localization;
using Common; 

namespace Wage
{
    public partial class frmWageInput : BaseClass.frmBase
    {
        public frmWageInput()
        {
            InitializeComponent();
            Common.XtraChinese p = new Common.XtraChinese();
            p.chineseXtraGrid(this.gcList);
        }

        private void tbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 取得相应月份
        /// </summary>
        /// <returns></returns>
        private string GetDate()
        {
            string strMonth = "0"+Convert.ToString(cbMonth.SelectedIndex + 1);
            if (strMonth.Length > 2)
                strMonth = strMonth.Substring(1);
            return spYear.Text+strMonth;
        }

        /// <summary>
        /// 新增工资
        /// </summary>
        private void New()
        {
            frmEditWage myEditWage = new frmEditWage();
            myEditWage.strDate = GetDate();
            myEditWage.New();
            if (myEditWage.ShowDialog() == DialogResult.OK)
                DataBind();
            myEditWage.Dispose();
        }

        /// <summary>
        /// 编辑工资
        /// </summary>
        private void Edit()
        {
            if (gvList.FocusedRowHandle < 0) return;
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            frmEditWage myEditWage = new frmEditWage();
            myEditWage.ckOption.Checked = false;
            myEditWage.strDate = GetDate();
            myEditWage.Edit(Convert.ToDecimal(dr["Aid"]));
            if (myEditWage.ShowDialog() == DialogResult.OK)
                DataBind();
            myEditWage.Dispose();
        }

        /// <summary>
        /// 删除工资资料
        /// </summary>
        private void Del()
        {
            if (gvList.FocusedRowHandle < 0) return;
            if (MessageBox.Show(this, "真的要删除本记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_WageInput where Aid = " + dr["Aid"].ToString() + " and F_Date = '" + dr["F_Date"].ToString() + "' and F_Flag = 0") == 0)
                gvList.DeleteRow(gvList.FocusedRowHandle);

        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPrint_Click(object sender, EventArgs e)
        {
            PreviewLocalizer plZer = new Common.XtraChinese.DxperienceXtraPrintingLocalizationCHS();
            DataLib.sysClass myClass = new DataLib.sysClass();
            myClass.DoPrint(this.Text, plZer, this.printingSystem);
        }

        /// <summary>
        /// 预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPreview_Click(object sender, EventArgs e)
        {
            PreviewLocalizer plZer = new Common.XtraChinese.DxperienceXtraPrintingLocalizationCHS();
            DataLib.sysClass myClass = new DataLib.sysClass();
            myClass.DoPreview(this.Text, plZer, this.printingSystem);
        }

        /// <summary>
        /// 引出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbExport_Click(object sender, EventArgs e)
        {
            string strFile = DataLib.sysClass.ShowSaveFileDialog("Excel 文件", "Excel 文件|*.Xls");
            if (strFile != "")
                gvList.ExportToExcelOld(strFile);
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBind()
        {
            int intMonth = cbMonth.SelectedIndex + 1;
            string strMonth = "0" + intMonth.ToString();
            
            if (strMonth.Length == 3) strMonth = strMonth.Substring(1,2);
            
            string strSQL = "";
            strSQL = @"select a.F_Type,a.AID,a.F_Date,Convert(varchar(10),a.F_Time,120) as F_Time,a.F_EmpID,b.F_Name as F_EmpName,
                        a.F_ItemID,c.F_Name as F_ItemName,a.F_DeptID,d.F_Name as F_DeptName,a.F_ProcID,
                        e.F_Name as F_ProcName,a.F_Qty,a.F_Price,(a.F_Qty * a.F_Price) as F_Money,a.F_Remark 
                        from t_WageInput a
                        left join t_Emp b
                        on a.F_EmpID = b.F_ID 
                        left join t_Item c
                        on a.F_ItemID = c.F_ID 
                        left join t_Class d
                        on a.F_DeptID = d.F_ID 
                        left join t_Process e
                        on a.F_ProcID = e.F_ID 
                        where a.F_Flag = 0 
                        and   a.F_Date = '" + spYear.Text + strMonth + "'";

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            this.gcList.DataSource = ds.Tables[0].DefaultView;
            DataLib.sysClass.LoadFormatFromDB(gvList, this.Name, 0);
        }

        private void frmWageInput_Load(object sender, EventArgs e)
        {
            spYear.Value = DateTime.Today.Year;
            cbMonth.SelectedIndex = DateTime.Today.Month - 1;
        }

        private void tbAdd_Click(object sender, EventArgs e)
        {
            New();
        }

        private void tbEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void tbDel_Click(object sender, EventArgs e)
        {
            Del();
        }

        private void frmWageInput_Shown(object sender, EventArgs e)
        {
            DataBind();
        }

        private void sbRefresh_Click(object sender, EventArgs e)
        {
            DataBind();
        }

        private void gvList_DoubleClick(object sender, EventArgs e)
        {
            Edit();
        }

        private void gcList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7 && DataLib.SysVar.strUGroup == "超级用户")
            {
                frmSetGrid myGrid = new frmSetGrid();
                myGrid.gvSource = gvList;
                myGrid.ShowDialog();
                myGrid.Dispose();
            }

            if (e.KeyCode == Keys.F5 && DataLib.SysVar.strUGroup == "超级用户")
            {
                DataLib.sysClass.SaveGridToDB(gvList, this.Name, 0);
            }

        }
    }
}

