using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class frmDataExport : BaseClass.frmBase
    {
        private string strPath = Application.StartupPath + "\\Data\\";
        public frmDataExport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 压缩数据
        /// </summary>
        private void Compress()
        {
            System.Diagnostics.Process ProData = new System.Diagnostics.Process();
            ProData.StartInfo.FileName = "Winrar.exe";
            ProData.StartInfo.CreateNoWindow = true;
            string strFile = '"' + txtFile.Text + '"';
            ProData.StartInfo.Arguments = " m -ep " + strFile + " " + strPath + "*.*";

            ProData.Start();
            if (ProData.HasExited)
            {
                int iExitCode = ProData.ExitCode;
                if (iExitCode != 0)
                {
                    MessageBox.Show("压缩文件错误，错误号:" + iExitCode.ToString(), "错误");
                }
            }

        }

        /// <summary>
        /// 导出数据子方法
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="strFile"></param>
        private void Export(string strSQL,string strFile)
        {
            DataSet dsTmp = null;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            dsTmp = myHelper.GetDs(strSQL);
            dsTmp.Tables[0].WriteXml(strPath + strFile + ".xml", XmlWriteMode.WriteSchema);
            dsTmp.Dispose();
        }

        /// <summary>
        /// 判断指定项是否选中
        /// </summary>
        /// <param name="strItem"></param>
        /// <returns></returns>
        private bool TestItemImport(string strItem)
        {
            return checkedListBox1.GetItemChecked(checkedListBox1.Items.IndexOf(strItem));
        }

        /// <summary>
        /// 导出数据入口
        /// </summary>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        private void DataExport(DateTime dtStart,DateTime dtEnd)
        {
            string strSQL = "";

            progressBar.Maximum = checkedListBox1.CheckedItems.Count + 1;
            progressBar.Minimum = 0;
            progressBar.Value = 0;
            ckBase.Enabled = false;
            ckOperation.Enabled = false;
            sbExport.Enabled = false;
            sbSelect.Enabled = false;

            if (Directory.Exists(strPath) == true)
            {
                Directory.Delete(strPath, true);
            }

            Directory.CreateDirectory(strPath);
            StreamWriter sw = File.CreateText(strPath + "t_SQL.txt");



            try
            {

                if (TestItemImport("辅助资料") == true) sw.WriteLine("delete from t_Assist");
                if (TestItemImport("公司信息") == true) sw.WriteLine("delete from t_CompanyInfo");
                if (TestItemImport("用户组资料") == true) sw.WriteLine("delete from t_UserGroup");
                if (TestItemImport("用户资料") == true) sw.WriteLine("delete from t_User");
                if (TestItemImport("权限资料") == true)
                {
                    sw.WriteLine("delete from t_Right");
                    sw.WriteLine("delete from t_RightDetail");
                    sw.WriteLine("delete from t_DetailRight");
                }
                if (TestItemImport("供应商资料") == true) sw.WriteLine("delete from t_Supplier");
                if (TestItemImport("客户资料") == true) sw.WriteLine("delete from t_Client");
                if (TestItemImport("职员资料") == true) sw.WriteLine("delete from t_Emp");
                if (TestItemImport("物料资料") == true)
                {
                    sw.WriteLine("delete from t_Item");
                    sw.WriteLine("delete from t_Unit");
                }
                if (TestItemImport("仓库资料") == true) sw.WriteLine("delete from t_Storage");
                if (TestItemImport("工序资料") == true) sw.WriteLine("delete from t_Process");
                if (TestItemImport("工组资料") == true) sw.WriteLine("delete from t_WorkGroup");
                if (TestItemImport("工艺流程资料") == true) sw.WriteLine("delete from t_Craftwork");
                if (TestItemImport("产品工序规划资料") == true) sw.WriteLine("delete from t_ProductProcess");
                if (TestItemImport("BOM资料") == true) sw.WriteLine("delete from t_Bom");
                if (TestItemImport("货运公司资料") == true) sw.WriteLine("delete from t_CarryCompany");
                if (TestItemImport("外加工厂商资料") == true) sw.WriteLine("delete from t_OutSupplier");
                if (TestItemImport("系统类别资料") == true) sw.WriteLine("delete from t_Class");
                //sw.WriteLine("delete from t_ReportField");
                sw.WriteLine("delete from t_Report");

                if (TestItemImport("辅助资料") == true)
                {
                    lbFlag.Text = "正在引出辅助资料......";
                    lbFlag.Update();
                    strSQL = "select * from t_Assist";
                    Export(strSQL, "t_Assist");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("公司信息") == true)
                {
                    lbFlag.Text = "正在引出公司信息......";
                    lbFlag.Update();
                    strSQL = "select * from t_CompanyInfo";
                    Export(strSQL, "t_CompanyInfo");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("用户组资料") == true)
                {
                    lbFlag.Text = "正在引出用户组资料......";
                    lbFlag.Update();
                    strSQL = "select * from t_UserGroup";
                    Export(strSQL, "t_UserGroup");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("用户资料") == true)
                {
                    lbFlag.Text = "正在引出用户资料......";
                    lbFlag.Update();
                    strSQL = "select * from t_User";
                    Export(strSQL, "t_User");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("权限资料") == true)
                {
                    lbFlag.Text = "正在引出权限资料......";
                    lbFlag.Update();
                    strSQL = "select * from t_Right";
                    Export(strSQL, "t_Right");

                    strSQL = "select * from t_RightDetail";
                    Export(strSQL, "t_RightDetail");

                    strSQL = "select * from t_DetailRight";
                    Export(strSQL, "t_DetailRight");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("供应商资料") == true)
                {
                    lbFlag.Text = "正在引出供应商资料......";
                    lbFlag.Update();
                    strSQL = "select * from t_Supplier";
                    Export(strSQL, "t_Supplier");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("客户资料") == true)
                {
                    lbFlag.Text = "正在引出客户资料......";
                    lbFlag.Update();
                    strSQL = "select * from t_Client";
                    Export(strSQL, "t_Client");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("职员资料") == true)
                {
                    lbFlag.Text = "正在引出职员资料......";
                    lbFlag.Update();
                    strSQL = "select * from t_Emp";
                    Export(strSQL, "t_Emp");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("物料资料") == true)
                {
                    lbFlag.Text = "正在引出物料资料......";
                    lbFlag.Update();
                    strSQL = "select * from t_Item";
                    Export(strSQL, "t_Item");

                    strSQL = "select * from t_Unit";
                    Export(strSQL, "t_Unit");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("仓库资料") == true)
                {
                    lbFlag.Text = "正在引出仓库资料......";
                    lbFlag.Update();
                    strSQL = "select * from t_Storage";
                    Export(strSQL, "t_Storage");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("工组资料") == true)
                {
                    lbFlag.Text = "正在引出工组资料......";
                    lbFlag.Update();
                    strSQL = "select * from t_WorkGroup";
                    Export(strSQL, "t_WorkGroup");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("工序资料") == true)
                {
                    lbFlag.Text = "正在引出工序资料......";
                    lbFlag.Update();
                    strSQL = "select * from t_Process";
                    Export(strSQL, "t_Process");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("工艺流程资料") == true)
                {
                    lbFlag.Text = "正在引出工艺流程资料......";
                    lbFlag.Update();
                    strSQL = "select * from t_Craftwork";
                    Export(strSQL, "t_Craftwork");

                    strSQL = "select * from t_CraftworkDetail";
                    Export(strSQL, "t_CraftworkDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("产品工序规划资料") == true)
                {
                    lbFlag.Text = "正在引出产品工序规划资料......";
                    lbFlag.Update();
                    strSQL = "select * from t_ProductProcess";
                    Export(strSQL, "t_ProductProcess");

                    strSQL = "select * from t_ProductProcessDetail";
                    Export(strSQL, "t_ProductProcessDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("外加工厂商资料") == true)
                {
                    lbFlag.Text = "正在引出外加工厂商资料......";
                    lbFlag.Update();
                    strSQL = "select * from t_OutSupplier";
                    Export(strSQL, "t_OutSupplier");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("BOM资料") == true)
                {
                    lbFlag.Text = "正在引出BOM资料......";
                    lbFlag.Update();
                    strSQL = "select * from t_Bom";
                    Export(strSQL, "t_Bom");

                    strSQL = "select * from t_BomDetail";
                    Export(strSQL, "t_BomDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("货运公司资料") == true)
                {
                    lbFlag.Text = "正在引出货运公司资料......";
                    lbFlag.Update();
                    strSQL = "select * from t_CarryCompany";
                    Export(strSQL, "t_CarryCompany");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("系统类别资料") == true)
                {
                    lbFlag.Text = "正在引出系统类别资料......";
                    lbFlag.Update();
                    strSQL = "select * from t_Class";
                    Export(strSQL, "t_Class");
                    progressBar.Value = progressBar.Value + 1;
                }


                if (TestItemImport("申购单") == true) sw.WriteLine("delete from t_ApplyStock where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("采购订单") == true) sw.WriteLine("delete from t_StockOrder where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("采购进货单") == true) sw.WriteLine("delete from t_StockIn where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("采购付款单") == true) sw.WriteLine("delete from t_Pay where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("采购退货单") == true) sw.WriteLine("delete from t_StockBack where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("询价单") == true) sw.WriteLine("delete from t_AskPrice where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("报价单") == true) sw.WriteLine("delete from t_SellPrice where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("客户订单") == true) sw.WriteLine("delete from t_SellOrder where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("发货通知单") == true) sw.WriteLine("delete from t_SellPre where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("发货单") == true) sw.WriteLine("delete from t_SellOut where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("收款单") == true) sw.WriteLine("delete from t_Accept where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("销售退货单") == true) sw.WriteLine("delete from t_SellBack where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("盘点单") == true) sw.WriteLine("delete from t_Check where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("调拔单") == true) sw.WriteLine("delete from t_Exchange where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("折装单") == true) sw.WriteLine("delete from t_Install where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("其它进出仓单") == true) sw.WriteLine("delete from t_Other where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("生产计划单") == true) sw.WriteLine("delete from t_ProductPlan where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("生产任务单") == true) sw.WriteLine("delete from t_Task where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("生产状况表") == true) sw.WriteLine("delete from t_ProductStatus where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("领料单") == true) sw.WriteLine("delete from t_DrawGoods where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("补料单") == true) sw.WriteLine("delete from t_PatchGoods where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("退料单") == true) sw.WriteLine("delete from t_BackGoods where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("产品进仓单") == true) sw.WriteLine("delete from t_ProductIn where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("委外加工单") == true) sw.WriteLine("delete from t_OutBill where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("委外领料单") == true) sw.WriteLine("delete from t_OutDrawGoods where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("委外退料单") == true) sw.WriteLine("delete from t_OutBackGoods where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("委外入仓单") == true) sw.WriteLine("delete from t_OutInStore where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("委外退货单") == true) sw.WriteLine("delete from t_OutBackStore where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("委外付款单") == true) sw.WriteLine("delete from t_OutPay where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");

                if (TestItemImport("申购单") == true)
                {
                    lbFlag.Text = "正在引出申购单......";
                    lbFlag.Update();
                    //申购单
                    strSQL = "select * from t_ApplyStock where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_ApplyStock");

                    strSQL = "select b.* from t_ApplyStock a,t_ApplyStockDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_ApplyStockDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("采购订单") == true)
                {
                    lbFlag.Text = "正在引出采购订单......";
                    lbFlag.Update();

                    //采购订单
                    strSQL = "select * from t_StockOrder where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_StockOrder");

                    strSQL = "select b.* from t_StockOrder a,t_StockOrderDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_StockOrderDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("采购进货单") == true)
                {
                    lbFlag.Text = "正在引出采购进货单......";
                    lbFlag.Update();

                    //采购进货单
                    strSQL = "select * from t_StockIn where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_StockIn");

                    strSQL = "select b.* from t_StockIn a,t_StockInDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_StockInDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("采购付款单") == true)
                {
                    lbFlag.Text = "正在引出采购付款单......";
                    lbFlag.Update();

                    //采购付款单
                    strSQL = "select * from t_Pay where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_Pay");

                    strSQL = "select b.* from t_Pay a,t_PayDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_PayDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("采购退货单") == true)
                {
                    lbFlag.Text = "正在引出采购退货单......";
                    lbFlag.Update();

                    //采购退货
                    strSQL = "select * from t_StockBack where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_StockBack");

                    strSQL = "select b.* from t_StockBack a,t_StockBackDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_StockBackDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("询价单") == true)
                {
                    lbFlag.Text = "正在引出询价单......";
                    lbFlag.Update();

                    //询价单
                    strSQL = "select * from t_AskPrice where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_AskPrice");

                    strSQL = "select b.* from t_AskPrice a,t_AskPriceDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_AskPriceDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("报价单") == true)
                {
                    lbFlag.Text = "正在引出报价单......";
                    lbFlag.Update();

                    //报价单
                    strSQL = "select * from t_SellPrice where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_SellPrice");

                    strSQL = "select b.* from t_SellPrice a,t_SellPriceDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_SellPriceDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("客户订单") == true)
                {
                    lbFlag.Text = "正在引出客户订单......";
                    lbFlag.Update();

                    //客户订单
                    strSQL = "select * from t_SellOrder where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_SellOrder");

                    strSQL = "select b.* from t_SellOrder a,t_SellOrderDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_SellOrderDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("发货通知单") == true)
                {
                    lbFlag.Text = "正在引出发货通知单......";
                    lbFlag.Update();

                    //发货通知单
                    strSQL = "select * from t_SellPre where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_SellPre");

                    strSQL = "select b.* from t_SellPre a,t_SellPreDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_SellPreDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("发货单") == true)
                {
                    lbFlag.Text = "正在引出发货单......";
                    lbFlag.Update();

                    //发货单
                    strSQL = "select * from t_SellOut where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_SellOut");

                    strSQL = "select b.* from t_SellOut a,t_SellOutDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_SellOutDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("收款单") == true)
                {
                    lbFlag.Text = "正在引出收款单......";
                    lbFlag.Update();

                    //收款单
                    strSQL = "select * from t_Accept where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_Accept");

                    strSQL = "select b.* from t_Accept a,t_AcceptDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_AcceptDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("销售退货单") == true)
                {
                    lbFlag.Text = "正在引出销售退货......";
                    lbFlag.Update();

                    //销售退货
                    strSQL = "select * from t_SellBack where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_SellBack");

                    strSQL = "select b.* from t_SellBack a,t_SellBackDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_SellBackDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("盘点单") == true)
                {
                    lbFlag.Text = "正在引出盘点单......";
                    lbFlag.Update();

                    //盘点单
                    strSQL = "select * from t_Check where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_Check");

                    strSQL = "select b.* from t_Check a,t_CheckDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_CheckDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("调拔单") == true)
                {
                    lbFlag.Text = "正在引出调拔单......";
                    lbFlag.Update();

                    //调拔单
                    strSQL = "select * from t_Exchange where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_Exchange");

                    strSQL = "select b.* from t_Exchange a,t_ExchangeDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_ExchangeDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("折装单") == true)
                {
                    lbFlag.Text = "正在引出拆装单......";
                    lbFlag.Update();

                    //折装单
                    strSQL = "select * from t_Install where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_Install");

                    strSQL = "select b.* from t_Install a,t_InstallDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_InstallDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("其它进出仓单") == true)
                {
                    lbFlag.Text = "正在引出其它进出仓单......";
                    lbFlag.Update();

                    //其它进出仓单
                    strSQL = "select * from t_Other where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_Other");

                    strSQL = "select b.* from t_Other a,t_OtherDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OtherDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("生产计划单") == true)
                {
                    lbFlag.Text = "正在引出生产计划单......";
                    lbFlag.Update();

                    //生产计划单
                    strSQL = "select * from t_ProductPlan where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_ProductPlan");

                    strSQL = "select b.* from t_ProductPlan a,t_ProductPlanDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_ProductPlanDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("生产任务单") == true)
                {
                    lbFlag.Text = "正在引出生产任务单......";
                    lbFlag.Update();

                    //生产任务单
                    strSQL = "select * from t_Task where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_Task");

                    strSQL = "select b.* from t_Task a,t_TaskGoods b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_TaskGoods");

                    strSQL = "select b.* from t_Task a,t_TaskHalf b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_TaskHalf");

                    strSQL = "select b.* from t_Task a,t_TaskItem b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_TaskItem");

                    strSQL = "select b.* from t_Task a,t_TaskDept b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_TaskDept");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("生产状况表") == true)
                {
                    lbFlag.Text = "正在引出生产状况表......";
                    lbFlag.Update();

                    //生产状况表
                    strSQL = "select * from t_ProductStatus where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_ProductStatus");

                    strSQL = "select b.* from t_ProductStatus a,t_ProductStatusDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_ProductStatusDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("领料单") == true)
                {
                    lbFlag.Text = "正在引出领料单......";
                    lbFlag.Update();

                    //领料单
                    strSQL = "select * from t_DrawGoods where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_DrawGoods");

                    strSQL = "select b.* from t_DrawGoods a,t_DrawGoodsDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_DrawGoodsDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("补料单") == true)
                {
                    lbFlag.Text = "正在引出补料单......";
                    lbFlag.Update();

                    //补料单
                    strSQL = "select * from t_PatchGoods where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_PatchGoods");

                    strSQL = "select b.* from t_PatchGoods a,t_PatchGoodsDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_PatchGoodsDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("退料单") == true)
                {
                    lbFlag.Text = "正在引出退料单......";
                    lbFlag.Update();

                    //退料单
                    strSQL = "select * from t_BackGoods where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_BackGoods");

                    strSQL = "select b.* from t_BackGoods a,t_BackGoodsDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_BackGoodsDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("产品进仓单") == true)
                {
                    lbFlag.Text = "正在引出产品进仓单......";
                    lbFlag.Update();

                    //产品进仓单
                    strSQL = "select * from t_ProductIn where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_ProductIn");

                    strSQL = "select b.* from t_ProductIn a,t_ProductInDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_ProductInDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("委外加工单") == true)
                {
                    lbFlag.Text = "正在引出委外加工单......";
                    lbFlag.Update();

                    //委外加工单
                    strSQL = "select * from t_OutBill where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OutBill");

                    strSQL = "select b.* from t_OutBill a,t_OutBillDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OutBillDetail");

                    strSQL = "select b.* from t_OutBill a,t_OutBillItem b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OutBillItem");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("委外领料单") == true)
                {
                    lbFlag.Text = "正在引出委外领料单......";
                    lbFlag.Update();

                    //委外领料单
                    strSQL = "select * from t_OutDrawGoods where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OutDrawGoods");

                    strSQL = "select b.* from t_OutDrawGoods a,t_OutDrawGoodsDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OutDrawGoodsDetail");

                    lbFlag.Text = "正在引出委外退料单......";
                    lbFlag.Update();
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("委外退料单") == true)
                {
                    //委外退料单
                    strSQL = "select * from t_OutBackGoods where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OutBackGoods");

                    strSQL = "select b.* from t_OutBackGoods a,t_OutBackGoodsDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OutBackGoodsDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("委外入仓单") == true)
                {
                    lbFlag.Text = "正在引出委外入仓单......";
                    lbFlag.Update();

                    //委外入仓单
                    strSQL = "select * from t_OutInStore where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OutInStore");

                    strSQL = "select b.* from t_OutInStore a,t_OutInStoreDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OutInStoreDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("委外退货单") == true)
                {
                    lbFlag.Text = "正在引出委外退货单......";
                    lbFlag.Update();

                    //委外退货单
                    strSQL = "select * from t_OutBackStore where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OutBackStore");

                    strSQL = "select b.* from t_OutBackStore a,t_OutBackStoreDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OutBackStoreDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("委外付款单") == true)
                {
                    //委外付款单
                    strSQL = "select * from t_OutPay where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OutPay");

                    strSQL = "select b.* from t_OutPay a,t_OutPayDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OutPayDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                ////报表字段格式
                //strSQL = "select * from t_ReportField";
                //Export(strSQL, "t_ReportField");

                //报表格式
                strSQL = "select * from t_Report";
                Export(strSQL, "t_Report");

                progressBar.Value = progressBar.Value + 1;

                sw.Dispose();
                Compress();

                lbFlag.Text = "数据引出成功!!";
                lbFlag.Update();
                MessageBox.Show("数据引出成功!!", "提示");
            }
            finally
            {
                //sw.Dispose();
                sbExport.Enabled = true;
                ckBase.Enabled = true;
                ckOperation.Enabled = true;
                sbSelect.Enabled = true;
            }
        }

        private void sbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sbExport_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("请至少选择一种导出资料(基本资料或业务资料)!!", "提示");
                return;
            }

            if (txtFile.Text.Length == 0)
            {
                MessageBox.Show("请选择存放文件！！", "提示");
                sbSelect.Focus();
                return;
            }

            if (MessageBox.Show(this, "数据引出可能进行比较长的一段时间，你确定要进行此操作吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            DataExport(ucDate.dtStart,ucDate.dtEnd);
        }

        private void sbSelect_Click(object sender, EventArgs e)
        {
            if (FileDlg.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = FileDlg.FileName;
            }
        }

        private void ckBase_CheckedChanged(object sender, EventArgs e)
        {
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("辅助资料"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("公司信息"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("用户组资料"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("用户资料"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("权限资料"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("供应商资料"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("客户资料"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("职员资料"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("物料资料"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("仓库资料"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("工组资料"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("工序资料"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("工艺流程资料"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("产品工序规划资料"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("外加工厂商资料"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("BOM资料"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("货运公司资料"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("系统类别资料"), ckBase.Checked);

        }

        private void ckOperation_CheckedChanged(object sender, EventArgs e)
        {
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("申购单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("采购订单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("采购进货单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("采购付款单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("采购退货单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("询价单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("报价单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("客户订单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("发货通知单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("发货单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("收款单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("销售退货单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("盘点单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("调拔单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("折装单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("其它进出仓单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("申购单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("生产计划单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("生产任务单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("生产状况表"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("领料单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("补料单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("退料单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("产品进仓单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("委外加工单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("委外领料单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("委外退料单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("委外入仓单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("委外退货单"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("委外付款单"), ckOperation.Checked);
        }

        private void frmDataExport_Shown(object sender, EventArgs e)
        {
            ckBase_CheckedChanged(null,null);
            ckOperation_CheckedChanged(null, null);
        }
        
    }
}

