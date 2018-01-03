using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;

namespace JXC
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // DevExpress.XtraBars.Localization.BarLocalizer.Active = new DevExpress.LocalizationCHS.XtraBarsLocalizer();
           // DevExpress.XtraBars.Localization.BarLocalizer.Active = new DevExpress.LocalizationCHS.XtraBarsLocalizer();
           // DevExpress.XtraCharts.Localization.ChartLocalizer.Active = new DevExpress.LocalizationCHS.XtraChartsLocalizer();
           // DevExpress.XtraEditors.Controls.Localizer.Active = new DevExpress.LocalizationCHS.XtraEditorsLocalizer();
           // DevExpress.XtraGrid.Localization.GridLocalizer.Active = new DevExpress.LocalizationCHS.XtraGridLocalizer();
           // //DevExpress.XtraLayout.Localization.LayoutLocalizer.Active = new DevExpress.LocalizationCHS.XtraLayoutLocalizer();
           // DevExpress.XtraNavBar.NavBarLocalizer.Active = new DevExpress.LocalizationCHS.XtraNavBarLocalizer();
           // DevExpress.XtraPivotGrid.Localization.PivotGridLocalizer.Active = new DevExpress.LocalizationCHS.XtraPivotGridLocalizer();
           // DevExpress.XtraPrinting.Localization.PreviewLocalizer.Active = new DevExpress.LocalizationCHS.XtraPrintingLocalizer();
           // DevExpress.XtraReports.Localization.ReportLocalizer.Active = new DevExpress.LocalizationCHS.XtraReportsLocalizer();
           // DevExpress.XtraScheduler.Localization.SchedulerLocalizer.Active = new DevExpress.LocalizationCHS.XtraSchedulerLocalizer();
           // DevExpress.XtraTreeList.Localization.TreeListLocalizer.Active = new DevExpress.LocalizationCHS.XtraTreeListLocalizer();
           //// DevExpress.XtraVerticalGrid.Localization.VGridLocalizer.Active = new DevExpress.LocalizationCHS.XtraVerticalGridLocalizer();


            DevExpress.XtraBars.Localization.BarLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraBarsLocalizationCHS();
            //DevExpress.XtraCharts.Localization.ChartLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraChartsLocalizationCHS();
            DevExpress.XtraEditors.Controls.Localizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraEditorsLocalizationCHS();
            DevExpress.XtraGrid.Localization.GridLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraGridLocalizationCHS();
            DevExpress.XtraLayout.Localization.LayoutLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraLayoutLocalizationCHS();
            DevExpress.XtraNavBar.NavBarLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraNavBarLocalizationCHS();
            //DevExpress.XtraPivotGrid.Localization.PivotGridLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraPivotGridLocalizationCHS();
            DevExpress.XtraPrinting.Localization.PreviewLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraPrintingLocalizationCHS();
            DevExpress.XtraReports.Localization.ReportLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraReportsLocalizationCHS();
            //DevExpress.XtraRichTextEdit.Localization.XtraRichTextEditLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraRichTextEditLocalizationCHS();
            //DevExpress.XtraScheduler.Localization.SchedulerLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraSchedulerLocalizationCHS();
            //DevExpress.XtraScheduler.Localization.SchedulerExtensionsLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraSchedulerExtensionsLocalizationCHS();
            //DevExpress.XtraSpellChecker.Localization.SpellCheckerLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraSpellCheckerLocalizationCHS();
            //DevExpress.XtraTreeList.Localization.TreeListLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraTreeListLocalizationCHS();
            //DevExpress.XtraVerticalGrid.Localization.VGridLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraVerticalGridLocalizationCHS();
            //DevExpress.XtraWizard.Localization.WizardLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraWizardLocalizationCHS();



            //Process.Start(Application.StartupPath + "\\AutoUpdate.exe");


            //string strHide = DataLib.SysVar.IniReadValue("Database", "HideServerForm", "C:\\Set.INI");

            //string strType = DataLib.SysVar.IniReadValue("Database", "ReportType", "C:\\Set.INI");

            //if (strType != "")
            //{
            //    DataLib.SysVar.iReportType = Convert.ToInt32(strType);
            //}

            //string sReg = "";
            //if (DataLib.SysVar.IsRegeditExit("RegCode") == true)
            //{
            //    sReg = DataLib.SysVar.GetRegistData("RegCode");
            //}

           // string[] s = DataLib.SysVar.GetMoc();
           // string sMac = s[1];

            //if (DataLib.SysVar.md5(sMac) != sReg)
            //{
            //    frmReg R = new frmReg();
            //    if (R.ShowDialog() != DialogResult.OK)
            //    {
            //        R.Dispose();
            //        Application.Exit();
            //        return;
            //    }
            //    R.Dispose();
            //}
            //else
            //{
            //    DataLib.SysVar.bReg = true;
            //}

            //DataLib.SysVar.bReg = true;

            //frmConnect myConnect = new frmConnect();

            //if (strHide == "1")
            //{
            //    try
            //    {
            //       // myConnect.frmConnect_Load(null, null);
            //        myConnect.sbOK_Click(null, null);
            //    }
            //    catch (Exception E)
            //    {
            //        DataLib.SysVar.IniWriteValue("Database", "HideServerForm", "0", "C:\\Set.INI");
            //        MessageBox.Show(E.Message, "错误");
            //        return;
            //    }
            //}
            //else
            //{
                //if (myConnect.ShowDialog() != DialogResult.OK)
                //{
                //    myConnect.Dispose();
                //    Application.Exit();
                //    return;
                //}
            //}
           // myConnect.Dispose();
            /*
            frmAccount myAccount = new frmAccount();
            if (myAccount.ShowDialog() != DialogResult.OK)
            {
                myAccount.Dispose();
                Application.Exit();
                return;
            }
            myAccount.Dispose();
            */
            frmLogin myLogin = new frmLogin();
            if (myLogin.ShowDialog() != DialogResult.OK)
            {
                myLogin.Dispose();
                Application.Exit();
                return;
            }
            myLogin.Dispose();

            //if (DataLib.SysVar.bReg == false)
            //{
            //    DataLib.DataHelper myHelper = new DataLib.DataHelper();
            //    DataSet ds = myHelper.GetDs("exec sp_TestBillCount 50");
            //    if (Convert.ToInt32(ds.Tables[0].Rows[0][0]) == 1)
            //    {
            //        MessageBox.Show("本系统试用期已到，请与供应商联系！" + (char)13 + (char)10 + "电话:15800429620 联系人:张先生", "提示");
            //        Application.Exit();
            //        return;
            //    }
            //}

            //DataLib.SysVar.blnDesignForm = true;
            //Application.Run(new UserDesignForm.DesignForm());
            Application.Run(new frmMain());
        }
    }
}