using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPrinting.Localization; 

namespace Wage
{
    public partial class frmWageQuery : BaseClass.frmBase
    {
        public frmWageQuery()
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
            int intMonth = cbMonth.SelectedIndex + 1;
            string strSQL = "sp_CalWage " + spYear.Text + "," + intMonth.ToString();
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            this.gcList.DataSource = ds.Tables[0].DefaultView;
        }


        private void frmWageInput_Load(object sender, EventArgs e)
        {
            spYear.Value = DateTime.Today.Year;
            cbMonth.SelectedIndex = DateTime.Today.Month - 1;
        }

        private void frmMonthWage_Shown(object sender, EventArgs e)
        {
            DataBind();
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
                int intMonth = cbMonth.SelectedIndex + 1;
                strSQL = "s_CalWage " + spYear.Text + ","+intMonth.ToString();
                if (myHelper.ExecuteSQL(strSQL) == 0)
                    DataBind();
            }
        }

        private void sbRefresh_Click(object sender, EventArgs e)
        {
            DataBind();
        }

    }
}

