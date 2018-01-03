using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPrinting.Localization;
using Common; 

namespace Wage
{
    public partial class frmMonthWage : BaseClass.frmBase
    {
        public frmMonthWage()
        {
            InitializeComponent();
            Common.XtraChinese p = new Common.XtraChinese();
            p.chineseXtraGrid(this.gcList);
        }

        /// <summary>
        /// 取相关月份
        /// </summary>
        /// <returns></returns>
        private string GetDate()
        {
            string strMonth = "0"+Convert.ToString(cbMonth.SelectedIndex + 1);
            if (strMonth.Length > 2)
                strMonth = strMonth.Substring(1);
            return spYear.Text+strMonth;
        }

        private void tbClose_Click(object sender, EventArgs e)
        {
            Close();
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
        /// 打印预览
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
            string strSQL = "";
            
            strSQL = @"select a.*,b.F_Name,b.F_Type,c.F_Name as F_TypeName from t_GenWage a
                       left join t_Emp b 
                       on a.F_EmpID = b.F_ID 
                       left join t_Class c
                       on b.F_Type = c.F_ID
                       where a.F_Month = '"+GetDate()+@"'
                       order by b.F_Type,a.F_EmpID";

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            this.gcList.DataSource = ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 设置可见工资列
        /// </summary>
        private void SetVisibleColumn()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_WageItem");   
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                GridColumn gc = this.gvList.Columns.ColumnByFieldName(dr["F_HideItem"].ToString());
                if (dr["F_Formula"].ToString() != "" || Convert.ToBoolean(dr["F_Visible"]) == false)
                    gc.Visible = false;
                else
                    gc.Visible = true;

                gc.Caption = dr["F_WageItem"].ToString();
                gc.Width = 52;
            }
        }

        private void frmWageInput_Load(object sender, EventArgs e)
        {
            spYear.Value = DateTime.Today.Year;
            cbMonth.SelectedIndex = DateTime.Today.Month - 1;
        }

        private void frmMonthWage_Shown(object sender, EventArgs e)
        {
            DataBind();
            DataLib.sysClass.LoadFormatFromDB(gvList, this.Name, 0);
            SetVisibleColumn();
        }

        /// <summary>
        /// 生成当月工资
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbGen_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this,"真的要生成本月工资吗,这将刷新当前结果,慎用!!","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                DataLib.DataHelper myHelper = new DataLib.DataHelper();
                string strSQL = "";
                if (ckOption.Checked == true)
                    strSQL = "sp_GenWage '"+GetDate()+"',2";
                else
                    strSQL = "sp_GenWage '"+GetDate()+"',1";
                if (myHelper.ExecuteSQL(strSQL) == 0)
                    DataBind();
            }
        }

        private void sbRefresh_Click(object sender, EventArgs e)
        {
            DataBind();
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        private void Save()
        {
            gvList.PostEditor();
            DataSet ds = ((DataView)this.gcList.DataSource).Table.DataSet;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            myHelper.SaveData(ds,"select * from t_GenWage where F_Month = '"+GetDate()+"'");
        }

        private void tbSave_Click(object sender, EventArgs e)
        {
            Save();
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

