using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList.Nodes;

namespace JXC
{
    public partial class frmBack : BaseClass.frmBase
    {
        public JXC.frmMain myApp;

        public frmBack()
        {  
            InitializeComponent();
            ListWake.ItemHeight = 16;
            ListWake.DrawMode = DrawMode.OwnerDrawFixed;
            try
            {
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                lbFindBill.Parent = pcTop;
                lbFindBill.Location = new Point(lbFindBill.Left, 55);
                FillReport(1);

                if (DataLib.SysVar.GetParmValue("F_N12") == true)
                {
                    timer1.Interval = (int)DataLib.SysVar.GetDecParmValue("F_C4") * 60 * 1000;
                    timer1.Enabled = true;
                    timer1_Tick(null, null);
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message,"错误");
            }
        }

        /// <summary>
        /// 来电显示
        /// </summary>
        private void ListenTel()
        {
            Phone.Modem modem = new Phone.Modem();
            modem.Ring += new EventHandler<Phone.RingEventArgs>(modem_Ring);
            try
            {
                modem.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void modem_Ring(object sender, Phone.RingEventArgs e)
        {
            //edtTel.txtEdit.Text = e.PhoneNumber;
            string sSQL = string.Format("insert into t_DispTel(F_Date,F_Tel) values('{0}','{1}')", DateTime.Now, e.PhoneNumber);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();

            if (myHelper.ExecuteSQL(sSQL) == 0)
            {
                //edtTel.txtEdit.Text = e.PhoneNumber;

                sSQL = "select top 1 F_ID from t_Client where F_Tel = '"+e.PhoneNumber+"'";
                DataTable dt = myHelper.GetDs(sSQL).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    Base.frmEditClient myEditClient = new Base.frmEditClient();
                    myEditClient.Edit(dt.Rows[0]["F_ID"].ToString());
                    myEditClient.ShowDialog();
                    myEditClient.Dispose();
                }
            }
        }

        /// <summary>
        /// 向报表列表添加项目
        /// </summary>
        /// <param name="objItem"></param>
        private void AddItem(object objItem)
        {
            ImageListBoxItem Litem = new ImageListBoxItem();
            Litem.ImageIndex = 0;
            Litem.Value = objItem;
            ReportList.Items.Add(Litem);
        }

        /// <summary>
        /// 测试用户组权限
        /// </summary>
        /// <param name="strModule"></param>
        /// <returns></returns>
        private bool TestUse(string strModule)
        {
            if (DataLib.SysVar.strUGroup == "超级用户") return true;
            string strSQL = @"select F_Enable from t_RightDetail
                            where F_Class = '" + strModule + @"'
                            and F_Name = '可用'
                            and F_Group = '"+DataLib.SysVar.strUGroup+"'";

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (ds.Tables[0].Rows.Count == 0) return false;

            return Convert.ToBoolean(ds.Tables[0].Rows[0][0]);
        }

        /// <summary>
        /// 没有审核的单据
        /// </summary>
        private void BillNoCheck()
        {
            DataSet ds = null;
            if (ListWake.Items.Count > 0)
               ListWake.Items.Clear();

            DataLib.DataHelper myHelper = new DataLib.DataHelper();

            if (TestUse("frmApplyStockList") == true)
            {
                ds = myHelper.GetDs("select F_BillID from t_ApplyStock where isnull(F_Check,0) = 0 and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("你有" + ds.Tables[0].Rows.Count.ToString() + "张申购单未审核!");
            }

            if (TestUse("frmStockOrderList") == true)
            {
                ds = myHelper.GetDs("select F_BillID from t_StockOrder where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("你有" + ds.Tables[0].Rows.Count.ToString() + "张采购订单未审核!");
            }

            //if (TestUse("frmStockInList") == true)
            //{
                ds = myHelper.GetDs("select F_BillID from t_StockIn where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("你有" + ds.Tables[0].Rows.Count.ToString() + "张采购进货单未审核!");
            //}

            if (TestUse("frmStockPayList") == true)
            {
                ds = myHelper.GetDs("select F_BillID from t_Pay where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("你有" + ds.Tables[0].Rows.Count.ToString() + "张采购付款单未审核!");
            }

            //if (TestUse("frmStockBackList") == true)
            //{
                ds = myHelper.GetDs("select F_BillID from t_StockBack where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("你有" + ds.Tables[0].Rows.Count.ToString() + "张采购退货单未审核!");
            //}

            if (TestUse("frmSellOrderList") == true)
            {
                if (DataLib.SysVar.strUGroup == "超级用户")
                    ds = myHelper.GetDs("select F_BillID from t_SellOrder where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0"); 
                else
                    ds = myHelper.GetDs("select F_BillID from t_SellOrder where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                    //ds = myHelper.GetDs("select F_BillID from t_SellOrder where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0 and (F_BillMan = '" + DataLib.SysVar.strUName + "' or F_BillMan = '超级用户')");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("你有" + ds.Tables[0].Rows.Count.ToString() + "张客户订单未审核!");
            }

            if (TestUse("frmSellPreList") == true)
            {
                if (DataLib.SysVar.strUGroup == "超级用户")
                    ds = myHelper.GetDs("select F_BillID from t_SellPre where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0 ");
                else
                    ds = myHelper.GetDs("select F_BillID from t_SellPre where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0 ");
                    //ds = myHelper.GetDs("select F_BillID from t_SellPre where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0 and (F_BillMan = '" + DataLib.SysVar.strUName + "' or F_BillMan = '超级用户')");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("你有" + ds.Tables[0].Rows.Count.ToString() + "张发货通知单未审核!");
            }

            //if (TestUse("frmSellOutList") == true)
            //{
                if (DataLib.SysVar.strUGroup == "超级用户")
                    ds = myHelper.GetDs("select F_BillID from t_SellOut where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                else
                    ds = myHelper.GetDs("select F_BillID from t_SellOut where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0"); 
                   //ds = myHelper.GetDs("select F_BillID from t_SellOut where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0 and (F_BillMan = '" + DataLib.SysVar.strUName + "' or F_BillMan = '超级用户')");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("你有" + ds.Tables[0].Rows.Count.ToString() + "张发货单未审核!");
            //}

            if (TestUse("frmSellAcceptList") == true)
            {
                if (DataLib.SysVar.strUGroup == "超级用户")
                    ds = myHelper.GetDs("select F_BillID from t_Accept where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                else
                    ds = myHelper.GetDs("select F_BillID from t_Accept where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0"); 
                    //ds = myHelper.GetDs("select F_BillID from t_Accept where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0 and (F_BillMan = '" + DataLib.SysVar.strUName + "' or F_BillMan = '超级用户')");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("你有" + ds.Tables[0].Rows.Count.ToString() + "张销售收款单未审核!");
            }

            //if (TestUse("frmSellBackList") == true)
            //{
                if (DataLib.SysVar.strUGroup == "超级用户")
                    ds = myHelper.GetDs("select F_BillID from t_SellBack where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                else
                    ds = myHelper.GetDs("select F_BillID from t_SellBack where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                    //ds = myHelper.GetDs("select F_BillID from t_SellBack where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0 and (F_BillMan = '" + DataLib.SysVar.strUName + "' or F_BillMan = '超级用户')");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("你有" + ds.Tables[0].Rows.Count.ToString() + "张销售退货单未审核!");
            //}

            //if (TestUse("frmCheckList") == true)
            //{
                ds = myHelper.GetDs("select F_BillID from t_Check where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("你有" + ds.Tables[0].Rows.Count.ToString() + "张盘点单未审核!");
            //}

            //if (TestUse("frmExchangeList") == true)
            //{
                ds = myHelper.GetDs("select F_BillID from t_Exchange where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("你有" + ds.Tables[0].Rows.Count.ToString() + "调拔单未审核!");
            //}

            //if (TestUse("frmInstallList") == true)
            //{
                ds = myHelper.GetDs("select F_BillID from t_Install where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("你有" + ds.Tables[0].Rows.Count.ToString() + "拆装单未审核!");
            //}

            //if (TestUse("frmOtherInList") == true)
            //{
                ds = myHelper.GetDs("select F_BillID from t_Other where isnull(F_Check,0) = 0 and isnull(F_Flag,0) = 0  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("你有" + ds.Tables[0].Rows.Count.ToString() + "其它进仓单未审核!");
            //}

            //if (TestUse("frmOtherOutList") == true)
            //{
                ds = myHelper.GetDs("select F_BillID from t_Other where isnull(F_Check,0) = 0 and isnull(F_Flag,0) = 1  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("你有" + ds.Tables[0].Rows.Count.ToString() + "其它出仓单未审核!");
            //}

            if (TestUse("frmProductPlanList") == true)
            {
                ds = myHelper.GetDs("select F_BillID from t_ProductPlan where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("你有" + ds.Tables[0].Rows.Count.ToString() + "生产计划单未审核!");
            }

            if (TestUse("frmTaskList") == true)
            {
                ds = myHelper.GetDs("select F_BillID from t_Task where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("你有" + ds.Tables[0].Rows.Count.ToString() + "生产任务单未审核!");
            }

            //if (TestUse("frmDrawGoodsList") == true)
            //{
                ds = myHelper.GetDs("select F_BillID from t_DrawGoods where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("你有" + ds.Tables[0].Rows.Count.ToString() + "领料单未审核!");
            //}

            //if (TestUse("frmBackGoodsList") == true)
            //{
                ds = myHelper.GetDs("select F_BillID from t_BackGoods where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("你有" + ds.Tables[0].Rows.Count.ToString() + "退料单未审核!");
            //}

            //if (TestUse("frmProductInList") == true)
            //{
                ds = myHelper.GetDs("select F_BillID from t_ProductIn where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("你有" + ds.Tables[0].Rows.Count.ToString() + "产品进仓单未审核!");
            //}

            decimal decDay1 = DataLib.SysVar.GetDecParmValue("F_C5");
            decimal decDay2 = DataLib.SysVar.GetDecParmValue("F_C6");

            string strSQL = "";

            if (decDay1 > 0)
            {
                strSQL = @"select F_BillID from t_SellOrder
                      where isnull(F_Check,0) =  1 and isnull(F_Finish,0) = 0 and isnull(F_CutOff,0) = 0 and datediff(day,getdate(),F_SendDate) <= " + decDay1.ToString() + @"
                      and datediff(day,getdate(),F_SendDate) >= 0 ";

                ds = myHelper.GetDs(strSQL);
                if (ds.Tables[0].Rows.Count > 0)
                   ListWake.Items.Add("你有" + ds.Tables[0].Rows.Count.ToString() + "客户订单准备发货!");
            }


            if (decDay2 > 0)
            {
                strSQL = @"select F_BillID from t_StockOrder
                      where isnull(F_Check,0) =  1 and isnull(F_Finish,0) = 0 and isnull(F_CutOff,0) = 0 and datediff(day,getdate(),F_StockTime) <= " + decDay2.ToString() + @"
                      and datediff(day,getdate(),F_StockTime) >= 0 ";

                ds = myHelper.GetDs(strSQL);
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("你有" + ds.Tables[0].Rows.Count.ToString() + "采购订单准备追货!");
            }

            //if (TestUse("frmStockInList") == true)
            //{
                strSQL = @"select F_BillID from t_StockIn
                      where isnull(F_Check,0) =  1 and isnull(F_Finish,0) = 0 and isnull(F_CutOff,0) = 0";

                ds = myHelper.GetDs(strSQL);
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("你有" + ds.Tables[0].Rows.Count.ToString() + "采购进仓单准备验货进仓!");
           // }
            
            //if (TestUse("frmSellOutList") == true)
            //{
                strSQL = @"select F_BillID from t_SellOut
                      where isnull(F_Check,0) =  1 and isnull(F_Finish,0) = 0 and isnull(F_CutOff,0) = 0";

                ds = myHelper.GetDs(strSQL);
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("你有" + ds.Tables[0].Rows.Count.ToString() + "销售单准备点货出仓!");
            //}

                strSQL = @"select b.F_ItemID as F_count
                            from t_Cast a,t_CastDetail b
                            where a.F_ID = b.F_ID
                            and DATEDIFF(day,getdate(),a.F_End) <= "+DataLib.SysVar.GetIntParmValue("F_C7").ToString()+@"
                            and DATEDIFF(day,getdate(),a.F_End) > 0";
                
                ds = myHelper.GetDs(strSQL);
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("有" + ds.Tables[0].Rows.Count.ToString() + "种产品证书准备过期!");

                strSQL = @"select b.F_ItemID as F_count
                            from t_Cast a,t_CastDetail b
                            where a.F_ID = b.F_ID
                            and DATEDIFF(day,getdate(),a.F_End) < 0";

                ds = myHelper.GetDs(strSQL);
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("有" + ds.Tables[0].Rows.Count.ToString() + "种产品证书已过期!");
        }

        /// <summary>
        /// 按模块向报表列表添加项目
        /// </summary>
        /// <param name="intFlag"></param>
        private void FillReport(int intFlag)
        {
            TabControl.SelectedTabPageIndex = intFlag - 1;
            ReportList.Items.Clear();

            if (intFlag == 12) intFlag = 13;

            switch (intFlag)
            {
                case 1:
                    AddItem("采购订单执行情况表");
                    AddItem("供应商供货报表");
                    AddItem("货品采购报表");
                    AddItem("采购年报表");
                    AddItem("应付款报表");
                    AddItem("应付款帐薄");
                    AddItem("应付帐龄分析");
                    break;
                case 2:
                    AddItem("客户订单执行情况表");
                    AddItem("客户销售报表");
                    AddItem("业务员销售报表");
                    AddItem("货品销售报表");
                    AddItem("货品销售利润表");
                    AddItem("销售年报表");
                    AddItem("地区销售报表");
                    AddItem("应收款报表");
                    AddItem("应收款帐薄");
                    AddItem("应收帐龄分析");
                    break;
                case 3:
                    AddItem("实时库存");
                    AddItem("业务库存");
                    AddItem("库存报警报表");
                    AddItem("物料进销存汇总表");
                    AddItem("物料进销存明细表");
                    AddItem("结帐数据查询");
                    AddItem("仓库流水帐");
                    break;
                case 4:
                    AddItem("任务单执行情况表");
                    AddItem("物料领料情况表");
                    AddItem("生产跟踪表");
                    AddItem("生产成本核算");
                    AddItem("生产日报表");
                    break;
                case 5:
                    AddItem("外加工单执行情况表");
                    AddItem("外加工费用报表");
                    AddItem("外加工领料情况表");
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    AddItem("总分类帐");
                    AddItem("明细分类帐");
                    AddItem("日记帐");
                    AddItem("多栏式明细帐");
                    AddItem("科目汇总表");
                    AddItem("试算平衡表");
                    AddItem("利润表");
                    AddItem("资产负债表");
                    AddItem("损益表");
                    //AddItem("自定义财务报表");
                    AddItem("固定资产清单");
                    AddItem("固定资产折旧表");
                    break;
                case 10:
                    AddItem("出纳结帐报表");
                    break;
                case 11:
                    AddItem("固定资产清单");
                    AddItem("固定资产折旧表");
                    AddItem("固定资产累计折旧表");
                    AddItem("累计工作量查询");
                    break;
                case 12:
                    AddItem("实时库存");
                    AddItem("业务库存");
                    AddItem("库存报警报表");
                    AddItem("物料进销存汇总表");
                    AddItem("物料进销存明细表");
                    AddItem("结帐数据查询");
                    AddItem("仓库流水帐");
                    break;
                case 13:
                    AddItem("刷卡记录");
                    AddItem("请假登记");
                    AddItem("出差登记");
                    AddItem("手工补卡");
                    AddItem("调休补班");
                    AddItem("考勤日报表");
                    AddItem("考勤汇总表");
                    AddItem("未刷卡人员名单");
                    break;
                case 14:   //设备管理
                    AddItem("设备维护报表");
                    break;
            }

        }


        private void navBar_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            switch (e.Group.Caption)
            {
                case "采购管理":
                    FillReport(1);
                    break;
                case "销售管理":
                    FillReport(2);
                    break;
                case "仓库管理":
                    if (DataLib.SysVar.blnStorageFlag == true)
                        FillReport(3);
                    else
                        FillReport(11);
                    break;
                case "生产管理":
                    FillReport(4);
                    break;
                case "委外加工":
                    FillReport(5);
                    break;
                case "工资管理":
                    FillReport(6);
                    break;
                case "系统设置":
                    FillReport(7);
                    break;
                case "基本资料":
                    FillReport(8);
                    break;
                case "财务管理":
                    FillReport(9);
                    break;
                case "出纳管理":
                    FillReport(10);
                    break;
                case "固定资产":
                    FillReport(11);
                    break;
                case "人事管理":
                    FillReport(12);
                    break;
                case "设备管理":
                    FillReport(14);
                    break;
                case "OA系统":
                    Process.Start(@"C:\Program Files\Internet Explorer\IEXPLORE.EXE",DataLib.SysVar.GetObjParmValue("F_OAAdr").ToString());
                    //NaviOA();
                    break;
            }
        }

        private void NaviOA()
        {
            //TabControl.SelectedTabPageIndex = 14;
            //Uri u = new Uri(DataLib.SysVar.GetObjParmValue("F_OAAdr").ToString());
            //wbBrowse.Url = u;
            //wbBrowse.Refresh(WebBrowserRefreshOption.Completely);
        }

        private void btnApplyStock_Click(object sender, EventArgs e)
        {
            myApp.ShowForm((sender as Button).Text);
        }

        private void navBar_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            myApp.ShowForm(e.Link.Caption);     
        }

        private void ReportList_Click(object sender, EventArgs e)
        {
            if (ReportList.SelectedIndex == -1) return;
            myApp.ShowForm(ReportList.SelectedValue.ToString());
        }

        private void lbStore_Click(object sender, EventArgs e)
        {
            myApp.ShowForm(lbStore.Text);
        }

        private void lbFindBill_Click(object sender, EventArgs e)
        {
            myApp.ShowForm("业务查找");
        }

        private void frmBack_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            if (DataLib.SysVar.GetParmValue("F_N13") == true)
            {
                ListenTel();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread ThreadWake = new Thread(new ThreadStart(BillNoCheck));

            ThreadWake.Start();
        }

        private void ListWake_DoubleClick(object sender, EventArgs e)
        {

            string strItem = ListWake.SelectedItem.ToString();

            Sys.frmWakeCenter myWakeCenter = new Sys.frmWakeCenter();

            bool bFlag = false;

            if (strItem.Contains("申购单") == true && TestUse("frmApplyStockList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 0;
                myWakeCenter.xtraTabControl2.SelectedTabPageIndex = 0;
                bFlag = true;
            }

            if (strItem.Contains("采购订单准备追货") == true && TestUse("frmStockOrderList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 0;
                myWakeCenter.xtraTabControl2.SelectedTabPageIndex = 5;
                bFlag = true;
            }

            if (strItem.Contains("采购订单未审核") == true && TestUse("frmStockOrderList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 0;
                myWakeCenter.xtraTabControl2.SelectedTabPageIndex = 1;
                bFlag = true;
            }

            if (strItem.Contains("采购进货单") == true && TestUse("frmStockInList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 0;
                myWakeCenter.xtraTabControl2.SelectedTabPageIndex = 2;
                bFlag = true;
            }

            if (strItem.Contains("采购付款") == true && TestUse("frmStockPayList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 0;
                myWakeCenter.xtraTabControl2.SelectedTabPageIndex = 3;
                bFlag = true;
            }

            if (strItem.Contains("采购退货单") == true && TestUse("frmStockBackList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 0;
                myWakeCenter.xtraTabControl2.SelectedTabPageIndex = 4;
                bFlag = true;
            }

            if (strItem.Contains("询价单") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 1;
                myWakeCenter.xtraTabControl3.SelectedTabPageIndex = 0;
                bFlag = true;
            }

            if (strItem.Contains("报价单") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 1;
                myWakeCenter.xtraTabControl3.SelectedTabPageIndex = 1;
                bFlag = true;
            }


            if (strItem.Contains("客户订单准备发货") == true && TestUse("frmSellOrderList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 1;
                myWakeCenter.xtraTabControl3.SelectedTabPageIndex = 7;
                bFlag = true;
            }

            if (strItem.Contains("客户订单未审核") == true && TestUse("frmSellOrderList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 1;
                myWakeCenter.xtraTabControl3.SelectedTabPageIndex = 2;
                bFlag = true;
            }


            if (strItem.Contains("发货通知单") == true && TestUse("frmSellPreList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 1;
                myWakeCenter.xtraTabControl3.SelectedTabPageIndex = 3;
                bFlag = true;
            }

            if (strItem.Contains("发货单") == true && TestUse("frmSellOutList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 1;
                myWakeCenter.xtraTabControl3.SelectedTabPageIndex = 4;
                bFlag = true;
            }

            if (strItem.Contains("销售收款单") == true && TestUse("frmSellAcceptList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 1;
                myWakeCenter.xtraTabControl3.SelectedTabPageIndex = 5;
                bFlag = true;
            }

            if (strItem.Contains("销售退货单") == true && TestUse("frmSellBackList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 1;
                myWakeCenter.xtraTabControl3.SelectedTabPageIndex = 6;
                bFlag = true;
            }

            if (strItem.Contains("盘点单") == true && TestUse("frmCheckList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 2;
                myWakeCenter.xtraTabControl4.SelectedTabPageIndex = 0;
                bFlag = true;
            }

            if (strItem.Contains("调拔单") == true && TestUse("frmExchangeList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 2;
                myWakeCenter.xtraTabControl4.SelectedTabPageIndex = 1;
                bFlag = true;
            }

            if (strItem.Contains("拆装单") == true && TestUse("frmInstallList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 2;
                myWakeCenter.xtraTabControl4.SelectedTabPageIndex = 2;
                bFlag = true;
            }

            if (strItem.Contains("其它进仓单") == true && TestUse("frmOtherInList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 2;
                myWakeCenter.xtraTabControl4.SelectedTabPageIndex = 3;
                bFlag = true;
            }

            if (strItem.Contains("其它出仓单") == true && TestUse("frmOtherOutList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 2;
                myWakeCenter.xtraTabControl4.SelectedTabPageIndex = 4;
                bFlag = true;
            }

            if (strItem.Contains("生产计划") == true && TestUse("frmProductPlanList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 2;
                myWakeCenter.xtraTabControl5.SelectedTabPageIndex = 0;
                bFlag = true;
            }


            if (strItem.Contains("生产任务") == true && TestUse("frmTaskList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 2;
                myWakeCenter.xtraTabControl5.SelectedTabPageIndex = 1;
                bFlag = true;
            }

            if (strItem.Contains("生产状况") == true && TestUse("frmProductStatusList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 2;
                myWakeCenter.xtraTabControl5.SelectedTabPageIndex = 2;
                bFlag = true;
            }

            if (strItem.Contains("领料单") == true && TestUse("frmDrawGoodsList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 2;
                myWakeCenter.xtraTabControl5.SelectedTabPageIndex = 3;
                bFlag = true;
            }

            if (strItem.Contains("补料单") == true && TestUse("frmPatchGoodsList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 2;
                myWakeCenter.xtraTabControl5.SelectedTabPageIndex = 4;
                bFlag = true;
            }

            if (strItem.Contains("退料单") == true && TestUse("frmBackGoodsList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 2;
                myWakeCenter.xtraTabControl5.SelectedTabPageIndex = 5;
                bFlag = true;
            }

            if (strItem.Contains("产品进仓单") == true && TestUse("frmProductInList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 2;
                myWakeCenter.xtraTabControl5.SelectedTabPageIndex = 6;
                bFlag = true;
            }

            if (strItem.Contains("证书准备过期") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 6;
                bFlag = true;
            }

            if (strItem.Contains("证书已过期") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 7;
                bFlag = true;
            }


            if (bFlag == false)
                myWakeCenter.Dispose();
            else
            {
                myWakeCenter.ShowDialog();
                myWakeCenter.Dispose();
            }
        }

        private void lbMessage_Click(object sender, EventArgs e)
        {
            myApp.ShowForm(lbMessage.Text);
        }

        private void lbOper_Click(object sender, EventArgs e)
        {
            myApp.ShowForm(lbOper.Text);
        }

        private void ListWake_DrawItem(object sender, DrawItemEventArgs e)
        {
         
        }

        private void ListWake_MouseDown(object sender, MouseEventArgs e)
        {

           
        }

    }
}

