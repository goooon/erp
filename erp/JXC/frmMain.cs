using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace JXC
{
    public partial class frmMain : BaseClass.frmBase
    {
        public frmMain()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "DiamondBlue.ssk";
            //if (DataLib.SysVar.bReg == false)
            //   this.Text = this.Text + "--试用版";
            //else
                this.Text = this.Text + "--正式版";
        }

        /// <summary>
        /// 测试财务系统是否启用
        /// </summary>
        private bool TestcwInit()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select F_cwInit from t_CompanyInfo");
            if (Convert.ToBoolean(ds.Tables[0].Rows[0][0]) == false)
            {
                MessageBox.Show("请选启用财务系统！", "提示");
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// 测试权限
        /// </summary>
        /// <returns></returns>
        private bool TestRight(string strClass)
        {
            if (DataLib.SysVar.strUGroup== "超级用户") return true;
            string strSQL = "select * from t_RightDetail where F_Group = '" + DataLib.SysVar.strUGroup + "' and F_Class = '" + strClass + "' and F_Name = '可用' and F_Enable = 1";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("对不起，你无权限!!", "提示");
                return false;
            }
            else
                return true;
        }

        private void SetStatus()
        {
            StatusBar.VisibleLinks[1].Caption = "用户:" + DataLib.SysVar.strUName;
            StatusBar.VisibleLinks[2].Caption = "日期:" + DataLib.SysVar.GetDate().ToShortDateString();
            barButtonItem95.Caption = "帐套:" + DataLib.SysVar.strAccount;
        }

        /// <summary>
        /// 重新登录　
        /// </summary>
        private void ReLogin()
        {
            frmLogin myLogin = new frmLogin();
            if (myLogin.ShowDialog() == DialogResult.OK)
                SetStatus();
            myLogin.Dispose();

            frmMain_Shown(null, null);


            foreach (Form myForm in this.MdiChildren)
            {
                if (myForm.Name == "frmBack")
                {
                    myForm.Dispose();
                }
            }

            ShowBack();

           
        }
        
        /// <summary>
        /// 打开导航图
        /// </summary>
        private void ShowBack()
        {

            foreach (Form myForm in this.MdiChildren)
            {
                if (myForm.Name == "frmBack")
                {
                    myForm.Activate();
                    return;
                }
            }

            //todo zhihe
            frmBack myBack = new frmBack();
            myBack.myApp = this;
            myBack.MdiParent = this;
            myBack.Show();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                SetLinkEvent();
                ShowBack();
                SetStatus();
                SetIniStatus();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "错误");
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, "真的退出本系统吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                e.Cancel = true;
            else
            {
                DataLib.DataHelper myHelper = new DataLib.DataHelper();
                myHelper.ExecuteSQL("update t_User set F_Login = 0 where F_ID = '" + DataLib.SysVar.strUID + "'");
            }
        }

        private void bExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }


        public void ShowForm(string strFlag)
        {
            switch (strFlag)
            {
                case "公司信息":
                    if (IsOpenAs("frmCompanyInfo") == false)
                    {
                        Sys.frmCompanyInfo myCompany = new Sys.frmCompanyInfo();
                        myCompany.Edit("");
                        if (myCompany.ShowDialog() == DialogResult.OK)
                            SetIniStatus();
                        myCompany.Dispose();
                    }
                    break;
                case "系统参数":
                    if (IsOpenAs("frmParm") == false)
                    {
                        Sys.frmParm myParm = new Sys.frmParm();
                        myParm.ShowDialog();
                        myParm.Dispose();
                        DataLib.SysVar.intIndex = DataLib.SysVar.GetIntParmValue("F_C1");
                    }
                    break;
                case "自定义报表":
                    if (IsOpenAs("frmUserReport") == false)
                    {
                        UserReport.frmUserReport myUserReport = new UserReport.frmUserReport();
                        myUserReport.MdiParent = this;
                        myUserReport.Show();
                    }
                    break;
                case "用户组管理":
                    if (IsOpenAs("frmUGroup") == false)
                    {
                        Sys.frmRight myRight = new Sys.frmRight();
                        myRight.ShowDialog();
                        myRight.Dispose();
                    }
                    /*
                    if (IsOpenAs("frmUGroup") == false)
                    {
                        Sys.frmUGroup myUGroup = new Sys.frmUGroup();
                        myUGroup.MdiParent = this;
                        myUGroup.Show();
                    }
                     */ 
                    break;
                case "用户管理":
                    if (IsOpenAs("frmUser") == false)
                    {
                        Sys.frmUser myUser = new Sys.frmUser();
                        myUser.ShowDialog();
                        myUser.Dispose();
                    }
                    break;
                case "用户明细权限":
                    if (IsOpenAs("frmRightDetail") == false)
                    {
                        Sys.frmRightDetail myRightDetail = new Sys.frmRightDetail();
                        myRightDetail.ShowDialog();
                        myRightDetail.Dispose();
                    }
                    break;
                case "系统日志":
                    if (IsOpenAs("frmSysLog") == false)
                    {
                        Sys.frmSysLog mySysLog = new Sys.frmSysLog();
                        mySysLog.MdiParent = this;
                        mySysLog.Show();
                    }
                    break;
                case "公告管理":
                    if (IsOpenAs("frmNotice") == false)
                    {
                        Sys.frmNotice myNotice = new Sys.frmNotice();
                        myNotice.MdiParent = this;
                        myNotice.Show();
                    }
                    break;
                case "数据引出":
                    if (IsOpenAs("frmDataExport") == false)
                    {
                        Sys.frmDataExport myDataExport = new Sys.frmDataExport();
                        myDataExport.ShowDialog();
                        myDataExport.Dispose();
                    }
                    break;
                case "数据引入":
                    if (IsOpenAs("frmDataImport") == false)
                    {
                        Sys.frmDataImport myDataImport = new Sys.frmDataImport();
                        myDataImport.ShowDialog();
                        myDataImport.Dispose();
                    }
                    break;
                case "数据清除":
                    if (IsOpenAs("frmClearData") == false)
                    {
                        Sys.frmClearData myClearData = new Sys.frmClearData();
                        myClearData.ShowDialog();
                        myClearData.Dispose();
                        SetIniStatus();
                    }
                    break;
                case "系统编码规则":
                    if (IsOpenAs("frmBillCode") == false)
                    {
                        Sys.frmBillCode myBillCode = new Sys.frmBillCode();
                        myBillCode.MdiParent = this;
                        myBillCode.Show();
                    }
                    break;
                case "重新登录":   
                    ReLogin();
                    break;
                case "库存重算":
                    if (IsOpenAs("frmStoreReCal") == false)
                    {
                        Sys.frmStoreReCal myStoreReCal = new Sys.frmStoreReCal();
                        myStoreReCal.ShowDialog();
                        myStoreReCal.Dispose();
                    }
                    break;
                case "系统提醒":
                    if (IsOpenAs("frmWakeCenter") == false)
                    {
                        Sys.frmWakeCenter myWakeCenter = new Sys.frmWakeCenter();
                        myWakeCenter.MdiParent = this;
                        myWakeCenter.Show();
                    }
                    break;

           ////////////基本资料/////////////////

                case "供应商资料":
                    if (IsOpenAs("frmSupplier") == false)
                    {
                        Base.frmSupplier mySupplier = new Base.frmSupplier();
                        mySupplier.MdiParent = this;
                        mySupplier.Show();
                    }
                    break;
                case "客户资料":
                    if (IsOpenAs("frmClient") == false)
                    {
                        Base.frmClient myClient = new Base.frmClient();
                        myClient.MdiParent = this;
                        myClient.Show();
                    }
                    break;
                case "职员资料":
                    if (IsOpenAs("frmEmp") == false)
                    {
                        Base.frmEmp myEmp = new Base.frmEmp();
                        myEmp.MdiParent = this;
                        myEmp.Show();
                    }
                    break;
                case "物料资料":
                    if (IsOpenAs("frmItem") == false)
                    {
                        Base.frmItem myItem = new Base.frmItem();
                        myItem.MdiParent = this;
                        myItem.Show();
                    }
                    break;
                case "产品资料":
                    if (IsOpenAs("frmProduct") == false)
                    {
                        Base.frmProduct myProduct = new Base.frmProduct();
                        myProduct.MdiParent = this;
                        myProduct.Show();
                    }
                    break;
                case "仓库资料":
                    if (IsOpenAs("frmStorage") == false)
                    {
                        Base.frmStorage myStorage = new Base.frmStorage();
                        myStorage.MdiParent = this;
                        myStorage.Show();
                    }
                    break;
                case "厂别资料":
                    if (IsOpenAs("frmFactory") == false)
                    {
                        Base.frmFactory myFactory = new Base.frmFactory();
                        myFactory.MdiParent = this;
                        myFactory.Show();
                    }
                    break;
                case "工组资料":
                    if (IsOpenAs("frmWorkGroup") == false)
                    {
                        Base.frmWorkGroup myWorkGroup = new Base.frmWorkGroup();
                        myWorkGroup.MdiParent = this;
                        myWorkGroup.Show();
                    }
                    break;
                case "工序资料":
                    if (IsOpenAs("frmProcess") == false)
                    {
                        Base.frmProcess myProcess = new Base.frmProcess();
                        myProcess.MdiParent = this;
                        myProcess.Show();
                    }
                    break;
                case "货运公司资料":
                    if (IsOpenAs("frmCarryCompany") == false)
                    {
                        Base.frmCarryCompany myCarryCompany = new Base.frmCarryCompany();
                        myCarryCompany.MdiParent = this;
                        myCarryCompany.Show();
                    }
                    break;
                case "外加工厂商":
                    if (IsOpenAs("frmOutSupplier") == false)
                    {
                        Base.frmOutSupplier myOutSupplier = new Base.frmOutSupplier();
                        myOutSupplier.MdiParent = this;
                        myOutSupplier.Show();
                    }
                    break;
                case "工艺流程":
                    if (IsOpenAs("frmCraftwork") == false)
                    {
                        Base.frmCraftwork myCraftwork = new Base.frmCraftwork();
                        myCraftwork.MdiParent = this;
                        myCraftwork.Show();
                    }
                    break;
                case "产品工序规划":
                    if (IsOpenAs("frmProductProcess") == false)
                    {
                        Base.frmProductProcessList myProductProcessList = new Base.frmProductProcessList();
                        myProductProcessList.MdiParent = this;
                        myProductProcessList.Show();
                    }
                    break;
                case "结算方式":
                    if (IsOpenAs("frmBalanceType") == false)
                    {
                        Sys.frmBalanceType myBalanceType = new Sys.frmBalanceType();
                        myBalanceType.ShowDialog();
                        myBalanceType.Dispose();
                    }
                    break;
                case "产品证书":
                    if (IsOpenAs("frmCertificate") == false)
                    {
                        Base.frmCast myCertificate = new Base.frmCast();
                        myCertificate.MdiParent = this;
                        myCertificate.Show();
                    }
                    break;
                    
                case "辅助资料":
                    if (IsOpenAs("frmAssistBase") == false)
                    {
                        Base.frmAssistBase myAssist = new Base.frmAssistBase();
                        myAssist.MdiParent = this;
                        myAssist.Show();
                    }
                    break;

          //////////进销存/////////////////

                case "采购报价":
                    if (IsOpenAs("frmStockPrice") == false)
                    {
                        Base.frmStockPrice myStockPrice = new Base.frmStockPrice();
                        myStockPrice.MdiParent = this;
                        myStockPrice.Show();
                    }
                    break;
                case "申购单":   
                    if (IsOpenAs("frmApplyStockList") == false)
                    {
                        Stock.frmApplyStockList myApplyStockList = new Stock.frmApplyStockList();
                        myApplyStockList.MdiParent = this;
                        myApplyStockList.Show();
                    }
                    break;
                case "采购订单":    
                    if (IsOpenAs("frmStockOrderList") == false)
                    {
                        Stock.frmStockOrderList myStockOrderList = new Stock.frmStockOrderList();
                        myStockOrderList.MdiParent = this;
                        myStockOrderList.Show();
                    }
                    break;
                case "采购进货":   
                    if (IsOpenAs("frmStockInList") == false)
                    {
                        Stock.frmStockInList myStockInList = new Stock.frmStockInList();
                        myStockInList.MdiParent = this;
                        myStockInList.Show();
                    }
                    break;
                case "采购付款":    
                    if (IsOpenAs("frmStockPayList") == false)
                    {
                        Stock.frmStockPayList myStockPayList = new Stock.frmStockPayList();
                        myStockPayList.MdiParent = this;
                        myStockPayList.Show();
                    }
                    break;
                case "采购退货":  
                    if (IsOpenAs("frmStockBackList") == false)
                    {
                        Stock.frmStockBackList myStockBackList = new Stock.frmStockBackList();
                        myStockBackList.MdiParent = this;
                        myStockBackList.Show();
                    }
                    break;
                case "销售定价":
                    if (IsOpenAs("frmReSellPriceList") == false)
                    {
                        Sell.frmReSellPriceList myReSellPriceList = new Sell.frmReSellPriceList();
                        myReSellPriceList.MdiParent = this;
                        myReSellPriceList.Show();
                    }
                    break;
                case "询价单":
                    if (IsOpenAs("frmAskPriceList") == false)
                    {
                        Sell.frmAskPriceList myAskPriceList = new Sell.frmAskPriceList();
                        myAskPriceList.MdiParent = this;
                        myAskPriceList.Show();
                    }
                    break;
                case "报价单":   
                    if (IsOpenAs("frmSellPriceList") == false)
                    {
                        Sell.frmSellPriceList mySellPriceList = new Sell.frmSellPriceList();
                        mySellPriceList.MdiParent = this;
                        mySellPriceList.Show();
                    }
                    break;
                case "客户订单":   
                    if (IsOpenAs("frmSellOrderList") == false)
                    {
                        Sell.frmSellOrderList mySellOrderList = new Sell.frmSellOrderList();
                        mySellOrderList.MdiParent = this;
                        mySellOrderList.Show();
                    }
                    break;
                case "发货通知单":  
                    if (IsOpenAs("frmSellPreList") == false)
                    {
                        Sell.frmSellPreList mySellPreList = new Sell.frmSellPreList();
                        mySellPreList.MdiParent = this;
                        mySellPreList.Show();
                    }
                    break;
                case "销售单": 
                    if (IsOpenAs("frmSellOutList") == false)
                    {
                        Sell.frmSellOutList mySellOutList = new Sell.frmSellOutList();
                        mySellOutList.MdiParent = this;
                        mySellOutList.Show();
                    }
                    break;
                case "收款单":
                    if (IsOpenAs("frmSellAcceptList") == false)
                    {
                        Sell.frmSellAcceptList mySellAcceptList = new Sell.frmSellAcceptList();
                        mySellAcceptList.MdiParent = this;
                        mySellAcceptList.Show();
                    }
                    break;
                case "客户费用":
                    if (IsOpenAs("frmClientFee") == false)
                    {
                        Sell.frmClientFee myClientFee = new Sell.frmClientFee();
                        myClientFee.MdiParent = this;
                        myClientFee.Show();
                    }
                    break;
                case "销售退货":  
                    if (IsOpenAs("frmSellBackList") == false)
                    {
                        Sell.frmSellBackList mySellBackList = new Sell.frmSellBackList();
                        mySellBackList.MdiParent = this;
                        mySellBackList.Show();
                    }
                    break;
                case "盘点单":   
                    if (IsOpenAs("frmCheckList") == false)
                    {
                        Storage.frmCheckList mySellCheckList = new Storage.frmCheckList();
                        mySellCheckList.MdiParent = this;
                        mySellCheckList.Show();
                    }
                    break;
                case "调拔单":    
                    if (IsOpenAs("frmExchangeList") == false)
                    {
                        Storage.frmExchangeList myExchangeList = new Storage.frmExchangeList();
                        myExchangeList.MdiParent = this;
                        myExchangeList.Show();
                    }
                    break;
                case "拆装单":   
                    if (IsOpenAs("frmInstallList") == false)
                    {
                        Storage.frmInstallList myInstallList = new Storage.frmInstallList();
                        myInstallList.MdiParent = this;
                        myInstallList.Show();
                    }
                    break;
                case "其它进仓单":    
                    if (IsOpenAs("frmOtherInList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 0;
                        myOtherInOutList.strSelectValue = "其它入库";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "其它出仓单":  
                    if (IsOpenAs("frmOtherOutList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 1;
                        myOtherInOutList.strSelectValue = "其它出库";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "采购入库单":
                    if (IsOpenAs("frmOtherInList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 0;
                        myOtherInOutList.strSelectValue = "采购进货入库";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "销售退货入库":
                    if (IsOpenAs("frmOtherInList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 0;
                        myOtherInOutList.strSelectValue = "销售退货入库";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "退料入库单":
                    if (IsOpenAs("frmOtherInList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 0;
                        myOtherInOutList.strSelectValue = "生产退料入库";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "生产完工入库":
                    if (IsOpenAs("frmOtherInList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 0;
                        myOtherInOutList.strSelectValue = "生产完工入库";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "委外退料入库":
                    if (IsOpenAs("frmOtherInList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 0;
                        myOtherInOutList.strSelectValue = "委外退料入库";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "委外完工入库":
                    if (IsOpenAs("frmOtherInList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 0;
                        myOtherInOutList.strSelectValue = "委外完工入库";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "发货出库单":
                    if (IsOpenAs("frmOtherOutList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 1;
                        myOtherInOutList.strSelectValue = "销售发货出库";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "采购退货出库":
                    if (IsOpenAs("frmOtherOutList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 1;
                        myOtherInOutList.strSelectValue = "采购退货出库";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "销售退货出库":
                    if (IsOpenAs("frmOtherOutList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 1;
                        myOtherInOutList.strSelectValue = "销售退货出库";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "领料出库单":
                    if (IsOpenAs("frmOtherOutList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 1;
                        myOtherInOutList.strSelectValue = "生产领料出库";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "补料出库单":
                    if (IsOpenAs("frmOtherOutList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 1;
                        myOtherInOutList.strSelectValue = "生产补料出库";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "委外领料出库":
                    if (IsOpenAs("frmOtherOutList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 1;
                        myOtherInOutList.strSelectValue = "委外领料出库";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "委外退货出库":
                    if (IsOpenAs("frmOtherOutList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 1;
                        myOtherInOutList.strSelectValue = "委外退货出库";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "领料单":   
                    if (IsOpenAs("frmDrawGoodsList") == false)
                    {
                        Product.frmDrawGoodsList myDrawGoodsList = new Product.frmDrawGoodsList();
                        myDrawGoodsList.MdiParent = this;
                        myDrawGoodsList.Show();
                    }
                    break;
                case "补料单": 
                    if (IsOpenAs("frmPatchGoodsList") == false)
                    {
                        Product.frmPatchGoodsList myPatchGoodsList = new Product.frmPatchGoodsList();
                        myPatchGoodsList.MdiParent = this;
                        myPatchGoodsList.Show();
                    }
                    break;
                case "退料单":   
                    if (IsOpenAs("frmBackGoodsList") == false)
                    {
                        Product.frmBackGoodsList myBackGoodsList = new Product.frmBackGoodsList();
                        myBackGoodsList.MdiParent = this;
                        myBackGoodsList.Show();
                    }
                    break;
                case "生产完工单":  
                    if (IsOpenAs("frmProductInList") == false)
                    {
                        Product.frmProductInList myProductInList = new Product.frmProductInList();
                        myProductInList.MdiParent = this;
                        myProductInList.Show();
                    }
                    break;
                case "实时库存":   
                    if (IsOpenAs("frmStorageQty") == false)
                    {
                        Storage.frmStorageQty myStorageQty = new Storage.frmStorageQty();
                        myStorageQty.MdiParent = this;
                        myStorageQty.Show();
                    }
                    break;
                case "库存结帐":
                    if (IsOpenAs("frmCheckOut") == false)
                    {
                        Sys.frmCheckOut myCheckOut = new Sys.frmCheckOut();
                        myCheckOut.ShowDialog();
                        myCheckOut.Dispose();
                    }
                    break;
                case "结帐数据查询":   
                    if (IsOpenAs("frmCheckOutQuery") == false)
                    {
                        Report.frmCheckOutQuery myCheckOutQuery = new Report.frmCheckOutQuery();
                        myCheckOutQuery.MdiParent = this;
                        myCheckOutQuery.Show();
                    }
                    break;
                case "业务查找":
                    if (IsOpenAs("frmFindBill") == false)
                    {
                        frmFindBill myFindBill = new frmFindBill();
                        myFindBill.ShowDialog();
                        myFindBill.Dispose();
                    }
                    break;

            //////////生产管理////////////  
 
                case "物料清单":
                    if (IsOpenAs("frmBom") == false)
                    {
                        Product.frmBom myBom = new Product.frmBom();
                        myBom.MdiParent = this;
                        myBom.Show();
                    }
                    break;
                case "MRP运算":
                    if (IsOpenAs("frmMRP") == false)
                    {
                        Stock.frmMRP myMRP = new Stock.frmMRP();
                        myMRP.ShowDialog();
                        myMRP.Dispose();
                    }
                    break;
                case "排程部门":
                    if (IsOpenAs("frmArrangeDept") == false)
                    {
                        Product.frmArrangeDept myArrangeDept = new Product.frmArrangeDept();
                        myArrangeDept.ShowDialog();
                        myArrangeDept.Dispose();
                    }
                    break;
                case "生产排程":
                    if (IsOpenAs("frmProductArrange") == false)
                    {
                        Product.frmProductArrange myProductArrange = new Product.frmProductArrange();
                        myProductArrange.MdiParent = this;
                        myProductArrange.Show();
                    }
                    break;
                case "生产计划单":
                    if (IsOpenAs("frmProductPlanList") == false)
                    {
                        Product.frmProductPlanList myProductPlanList = new Product.frmProductPlanList();
                        myProductPlanList.MdiParent = this;
                        myProductPlanList.Show();
                    }
                    break;
                case "生产任务单":
                    if (IsOpenAs("frmTaskList") == false)
                    {
                        Product.frmTaskList myTaskList = new Product.frmTaskList();
                        myTaskList.MdiParent = this;
                        myTaskList.Show();
                    }
                    break;
                case "生产状况表":
                    if (IsOpenAs("frmProductStatusList") == false)
                    {
                        Product.frmProductStatusList myProductStatusList = new Product.frmProductStatusList();
                        myProductStatusList.MdiParent = this;
                        myProductStatusList.Show();
                    }
                    break;
                case "质检单":
                    if (IsOpenAs("frmQcList") == false)
                    {
                        Product.frmQcList myQcList = new Product.frmQcList();
                        myQcList.MdiParent = this;
                        myQcList.Show();
                    }
                    break;
                case "产量跟踪表": 
                    break;

           ///////////委外加工///////////

                case "委外加工单":
                    if (IsOpenAs("frmOutBillList") == false)
                    {
                        OutProduct.frmOutBillList myOutBillList = new OutProduct.frmOutBillList();
                        myOutBillList.MdiParent = this;
                        myOutBillList.Show();
                    }
                    break;
                case "委外领料单":
                    if (IsOpenAs("frmOutDrawGoodsList") == false)
                    {
                        OutProduct.frmOutDrawGoodsList myOutDrawGoodsList = new OutProduct.frmOutDrawGoodsList();
                        myOutDrawGoodsList.MdiParent = this;
                        myOutDrawGoodsList.Show();
                    }
                    break;
                case "委外退料单":
                    if (IsOpenAs("frmOutBackGoodsList") == false)
                    {
                        OutProduct.frmOutBackGoodsList myOutBackGoodsList = new OutProduct.frmOutBackGoodsList();
                        myOutBackGoodsList.MdiParent = this;
                        myOutBackGoodsList.Show();
                    }
                    break;
                case "委外入库单":
                    if (IsOpenAs("frmOutInStoreList") == false)
                    {
                        OutProduct.frmOutInStoreList myOutInStoreList = new OutProduct.frmOutInStoreList();
                        myOutInStoreList.MdiParent = this;
                        myOutInStoreList.Show();
                    }
                    break;
                case "委外退货单":
                    if (IsOpenAs("frmOutBackStoreList") == false)
                    {
                        OutProduct.frmOutBackStoreList myOutBackStoreList = new OutProduct.frmOutBackStoreList();
                        myOutBackStoreList.MdiParent = this;
                        myOutBackStoreList.Show();
                    }
                    break;
                case "委外付款单":
                    if (IsOpenAs("frmOutPayList") == false)
                    {
                        OutProduct.frmOutPayList myOutPayList = new OutProduct.frmOutPayList();
                        myOutPayList.MdiParent = this;
                        myOutPayList.Show();
                    }
                    break;

          ///////////工资管理///////////

                case "工资项目设定":
                    if (IsOpenAs("frmWageItem") == false)
                    {
                        Wage.frmWageItem myWageItem = new Wage.frmWageItem();
                        myWageItem.ShowDialog();
                        myWageItem.Dispose();
                    }
                    break;
                case "产量结转工资":
                    if (IsOpenAs("frmWageCheckOut") == false)
                    {
                        Wage.frmWageCheckOut myWageCheckOut = new Wage.frmWageCheckOut();
                        myWageCheckOut.ShowDialog();
                        myWageCheckOut.Dispose();
                    }
                    break;
                case "个人计件录入":
                    if (IsOpenAs("frmWageInput") == false)
                    {
                        Wage.frmWageInput myWageInput = new Wage.frmWageInput();
                        myWageInput.MdiParent = this;
                        myWageInput.Show();
                    }                   
                    break;
                case "计月工资录入":
                    if (IsOpenAs("frmMonthWage") == false)
                    {
                        Wage.frmMonthWage myMonthWage = new Wage.frmMonthWage();
                        myMonthWage.MdiParent = this;
                        myMonthWage.Show();
                    }
                    break;
                case "工资发放表":  
                    if (IsOpenAs("frmGiffWage") == false)
                    {
                        Wage.frmGiffWage myGiffWage = new Wage.frmGiffWage();
                        myGiffWage.MdiParent = this;
                        myGiffWage.Show();
                    }
                    break;
                case "工组计件录入":
                    if (IsOpenAs("frmWageGroupInput") == false)
                    {
                        Wage.frmWageGroupInput myWageGroupInput = new Wage.frmWageGroupInput();
                        myWageGroupInput.MdiParent = this;
                        myWageGroupInput.Show();
                    }
                    break;

                case "工组计件统计":
                    if (IsOpenAs("frmGroupWage") == false)
                    {
                        Wage.frmGroupWage myWageQuery = new Wage.frmGroupWage();
                        myWageQuery.MdiParent = this;
                        myWageQuery.Show();
                    }
                    break;

         ///////////统计报表///////////

                case "采购订单执行情况表":
                    if (IsOpenAs("frmStockOrderExe") == false)
                    {
                        Report.frmStockOrderExe myStockOrderExe = new Report.frmStockOrderExe();
                        myStockOrderExe.MdiParent = this;
                        myStockOrderExe.Show();
                    }
                    break;
                case "供应商供货报表":
                    if (IsOpenAs("frmSupplierReport") == false)
                    {
                        Report.frmSupplierReport mySupplierReport = new Report.frmSupplierReport();
                        mySupplierReport.MdiParent = this;
                        mySupplierReport.Show();
                    }
                    break;
                case "货品采购报表":
                    if (IsOpenAs("frmItemStockReport") == false)
                    {
                        Report.frmItemStockReport myItemStockReport = new Report.frmItemStockReport();
                        myItemStockReport.MdiParent = this;
                        myItemStockReport.Show();
                    }
                    break;
                case "采购年报表":
                    if (IsOpenAs("frmStockYearReport") == false)
                    {
                        Report.frmStockYearReport myStockYearReport = new Report.frmStockYearReport();
                        myStockYearReport.MdiParent = this;
                        myStockYearReport.Show();
                    }
                    break;
                case "应付款报表":
                    if (IsOpenAs("frmPayReport") == false)
                    {
                        Report.frmPayReport myPayReport = new Report.frmPayReport();
                        myPayReport.MdiParent = this;
                        myPayReport.Show();
                    }
                    break;
                case "应付款帐薄":
                    if (IsOpenAs("frmPayAccount") == false)
                    {
                        Report.frmPayAccount myPayAccount = new Report.frmPayAccount();
                        myPayAccount.MdiParent = this;
                        myPayAccount.Show();
                    }
                    break;
                case "应付帐龄分析":
                    if (IsOpenAs("frmPayAge") == false)
                    {
                        Report.frmPayAge myPayAge = new Report.frmPayAge();
                        myPayAge.MdiParent = this;
                        myPayAge.Show();
                    }
                    break;
                case "客户订单执行情况表":
                    if (IsOpenAs("frmSellOrderExe") == false)
                    {
                        Report.frmSellOrderExe mySellOrderExe = new Report.frmSellOrderExe();
                        mySellOrderExe.MdiParent = this;
                        mySellOrderExe.Show();
                    }
                    break;
                case "客户销售报表":
                    if (IsOpenAs("frmClientReport") == false)
                    {
                        Report.frmClientReport myClientReport = new Report.frmClientReport();
                        myClientReport.MdiParent = this;
                        myClientReport.Show();
                    }
                    break;
                case "业务员销售报表":
                    if (IsOpenAs("frmOpertorReport") == false)
                    {
                        Report.frmOpertorReport myOpertorReport = new Report.frmOpertorReport();
                        myOpertorReport.MdiParent = this;
                        myOpertorReport.Show();
                    }
                    break;
                case "货品销售报表":
                    if (IsOpenAs("frmItemSellReport") == false)
                    {
                        Report.frmItemSellReport myItemSellReport = new Report.frmItemSellReport();
                        myItemSellReport.MdiParent = this;
                        myItemSellReport.Show();
                    }
                    break;
                case "货品销售利润表":
                    if (IsOpenAs("frmItemProfitReport") == false)
                    {
                        Report.frmItemProfitReport myItemProfitReport = new Report.frmItemProfitReport();
                        myItemProfitReport.MdiParent = this;
                        myItemProfitReport.Show();
                    }
                    break;
                case "销售年报表":
                    if (IsOpenAs("frmSellYearReport") == false)
                    {
                        Report.frmSellYearReport mySellYearReport = new Report.frmSellYearReport();
                        mySellYearReport.MdiParent = this;
                        mySellYearReport.Show();
                    }
                    break;
                case "地区销售报表":
                    if (IsOpenAs("frmAreaSellReport") == false)
                    {
                        Report.frmAreaSellReport myAreaSellReport = new Report.frmAreaSellReport();
                        myAreaSellReport.MdiParent = this;
                        myAreaSellReport.Show();
                    }
                    break;
                case "应收款报表":
                    if (IsOpenAs("frmAcceptReport") == false)
                    {
                        Report.frmAcceptReport myAcceptReport = new Report.frmAcceptReport();
                        myAcceptReport.MdiParent = this;
                        myAcceptReport.Show();
                    }
                    break;
                case "应收款帐薄":
                    if (IsOpenAs("frmAcceptAccount") == false)
                    {
                        Report.frmAcceptAccount myAcceptAccount = new Report.frmAcceptAccount();
                        myAcceptAccount.MdiParent = this;
                        myAcceptAccount.Show();
                    }
                    break;
                case "应收帐龄分析":
                    if (IsOpenAs("frmAcceptAge") == false)
                    {
                        Report.frmAcceptAge myAcceptAge = new Report.frmAcceptAge();
                        myAcceptAge.MdiParent = this;
                        myAcceptAge.Show();
                    }
                    break;
                case "库存报警报表":
                    if (IsOpenAs("frmStoreLimit") == false)
                    {
                        Report.frmStoreLimit myStoreLimit = new Report.frmStoreLimit();
                        myStoreLimit.MdiParent = this;
                        myStoreLimit.Show();
                    }
                    break;
                case "物料进销存汇总表":
                    if (IsOpenAs("frmStorageSum") == false)
                    {
                        Report.frmStorageSum myStorageSum = new Report.frmStorageSum();
                        myStorageSum.MdiParent = this;
                        myStorageSum.Show();
                    }
                    break;
                case "物料进销存明细表":
                    if (IsOpenAs("frmStorageDetail") == false)
                    {
                        Report.frmStorageDetail myStorageDetail = new Report.frmStorageDetail();
                        myStorageDetail.MdiParent = this;
                        myStorageDetail.Show();
                    }
                    break;
                case "设备维护报表":
                    if (IsOpenAs("frmRepairDeviceReport") == false)
                    {
                        Report.frmRepairDeviceReport myRepairDeviceReport = new Report.frmRepairDeviceReport();
                        myRepairDeviceReport.MdiParent = this;
                        myRepairDeviceReport.Show();
                    }
                    break;

                    
                case "任务单执行情况表":
                    if (IsOpenAs("frmTaskExe") == false)
                    {
                        Report.frmTaskExe myTaskExe = new Report.frmTaskExe();
                        myTaskExe.MdiParent = this;
                        myTaskExe.Show();
                    }
                    break;
                case "物料领料情况表":
                    if (IsOpenAs("frmItemDrawReport") == false)
                    {
                        Report.frmItemDrawReport myItemDrawReport = new Report.frmItemDrawReport();
                        myItemDrawReport.MdiParent = this;
                        myItemDrawReport.Show();
                    }
                    break;
                case "生产跟踪表":
                    if (IsOpenAs("frmProductTract") == false)
                    {
                        Report.frmProductTract myProductTract = new Report.frmProductTract();
                        myProductTract.MdiParent = this;
                        myProductTract.Show();
                    }
                    break;
                case "产品维修单":
                    if (IsOpenAs("frmRepairList") == false)
                    {
                        Product.frmRepairList myRepairList = new Product.frmRepairList();
                        myRepairList.MdiParent = this;
                        myRepairList.Show();
                    }
                    break;
                case "维修领料单":
                    if (IsOpenAs("frmRepairDrawGoodsList") == false)
                    {
                        Product.frmRepairDrawGoodsList myRepairDrawGoodsList = new Product.frmRepairDrawGoodsList();
                        myRepairDrawGoodsList.MdiParent = this;
                        myRepairDrawGoodsList.Show();
                    }
                    break;
                case "生产成本核算":
                    if (IsOpenAs("frmProductCost") == false)
                    {
                        Report.frmProductCost myProductCost = new Report.frmProductCost();
                        myProductCost.MdiParent = this;
                        myProductCost.Show();
                    }
                    break;
                case "生产日报表":
                    if (IsOpenAs("frmProductDayReport") == false)
                    {
                        Report.frmProductDayReport myProductDayReport = new Report.frmProductDayReport();
                        myProductDayReport.MdiParent = this;
                        myProductDayReport.Show();
                    }
                    break;
                case "外加工单执行情况表":
                    if (IsOpenAs("frmOutBillExe") == false)
                    {
                        Report.frmOutBillExe myOutBillExe = new Report.frmOutBillExe();
                        myOutBillExe.MdiParent = this;
                        myOutBillExe.Show();
                    }
                    break;
                case "外加工领料情况表":
                    if (IsOpenAs("frmOutDrawReport") == false)
                    {
                        Report.frmOutDrawReport myOutDrawReport = new Report.frmOutDrawReport();
                        myOutDrawReport.MdiParent = this;
                        myOutDrawReport.Show();
                    }
                    break;
                case "外加工费用报表":
                    if (IsOpenAs("frmOutPayReport") == false)
                    {
                        Report.frmOutPayReport myOutPayReport = new Report.frmOutPayReport();
                        myOutPayReport.MdiParent = this;
                        myOutPayReport.Show();
                    }
                    break;

                case "业务库存":
                    if (IsOpenAs("frmOtherStorageQty") == false)
                    {
                        Storage.frmOtherStorageQty myOtherStorageQty = new Storage.frmOtherStorageQty();
                        myOtherStorageQty.MdiParent = this;
                        myOtherStorageQty.Show();
                    }
                    break;

                case "仓库流水帐":
                    if (IsOpenAs("frmSequence") == false)
                    {
                        Report.frmSequence mySequence = new Report.frmSequence();
                        mySequence.MdiParent = this;
                        mySequence.Show();
                    }
                    break;

                case "设备登记":
                    Card.frmRegDevice myDevice = new Card.frmRegDevice();
                    myDevice.ShowDialog();
                    myDevice.Dispose();
                    break;

                //case "机器设置":
                //    Card.EastRiver.ShowForm(IntPtr.Zero, DataLib.SysVar.strCon, 0);
                //    /*
                //    Card.frmSetDevice mySetDevice = new Card.frmSetDevice();
                //    mySetDevice.ShowDialog();
                //    mySetDevice.Dispose();
                //     */ 
                //    break;

                case "联机操作":
                    Card.frmNetDevice myNetDevice = new Card.frmNetDevice();
                    myNetDevice.ShowDialog();
                    myNetDevice.Dispose();
                    break;

                case "U盘操作":
                    Card.frmNetDevice myNetDevice1 = new Card.frmNetDevice();
                    myNetDevice1.iFlag = 1;
                    myNetDevice1.ShowDialog();
                    myNetDevice1.Dispose();
                    break;

                case "实时采集":
                    //Card.EastRiver.ShowForm(IntPtr.Zero, DataLib.SysVar.strCon, 3);
                    Card.frmRealPick myRealPick = new Card.frmRealPick();
                    myRealPick.ShowDialog();
                    myRealPick.Dispose();
                    break;
                case "定时采集":
                    //Card.frmTimPick myTimPick = new Card.frmTimPick();
                    //myTimPick.ShowDialog();
                    //myTimPick.Dispose();
                    break;

                case "班次设定":
                    Card.frmSetClass mySetClass = new Card.frmSetClass();
                    mySetClass.ShowDialog();
                    mySetClass.Dispose();
                    break;

                case "考勤规则":
                    Card.frmKQRule myKQRule = new Card.frmKQRule();
                    myKQRule.ShowDialog();
                    myKQRule.Dispose();
                    break;

                case "刷卡记录":
                    Card.frmCardReport myCardRecord = new Card.frmCardReport();
                    myCardRecord.ShowDialog();
                    myCardRecord.Dispose();
                    break;
                case "考勤汇总表":
                    Card.frmKQTotalReport myKQTotalReport = new Card.frmKQTotalReport();
                    myKQTotalReport.ShowDialog();
                    myKQTotalReport.Dispose();
                    break;
                case "考勤日报表":
                    Card.frmKQDayReport myKQDayReport = new Card.frmKQDayReport();
                    myKQDayReport.ShowDialog();
                    myKQDayReport.Dispose();
                    break;
                case "未刷卡人员名单":
                    Card.frmNoCardReport myNoCardReport = new Card.frmNoCardReport();
                    myNoCardReport.ShowDialog();
                    myNoCardReport.Dispose();
                    break;
                case "请假登记":
                    Card.frmRegLeave myRegLeave = new Card.frmRegLeave();
                    myRegLeave.ShowDialog();
                    myRegLeave.Dispose();
                    break;
                case "出差登记":
                    Card.frmRegTravel myRegTravel = new Card.frmRegTravel();
                    myRegTravel.ShowDialog();
                    myRegTravel.Dispose();
                    break;
                case "调休补班":
                    Card.frmOtherRest myOtherRest = new Card.frmOtherRest();
                    myOtherRest.ShowDialog();
                    myOtherRest.Dispose();
                    break;
                case "手工补卡":
                    Card.frmUserCard myUserCard = new Card.frmUserCard();
                    myUserCard.ShowDialog();
                    myUserCard.Dispose();
                    break;
                case "停工待料":
                    Card.frmRegStop myRegStop = new Card.frmRegStop();
                    myRegStop.ShowDialog();
                    myRegStop.Dispose();
                    break;
                case "员工排班":
                    Card.frmArrangeClass myArrangeClass = new Card.frmArrangeClass();
                    myArrangeClass.ShowDialog();
                    myArrangeClass.Dispose();
                    break;
                case "门卫查相":
                    Card.frmReadEmpPic myReadEmpPic = new Card.frmReadEmpPic();
                    myReadEmpPic.ShowDialog();
                    myReadEmpPic.Dispose();
                    break;
                case "发卡":
                    Card.EastRiver.ShowForm(IntPtr.Zero, DataLib.SysVar.strCon, 1);
                    /*
                    Card.frmSendCard mySendCard = new Card.frmSendCard();
                    mySendCard.ShowDialog();
                    mySendCard.Dispose();
                     */ 
                    break;
                case "退卡":
                    Card.frmBackCard myBackCard = new Card.frmBackCard();
                    myBackCard.ShowDialog();
                    myBackCard.Dispose();
                    break;
                case "退款":
                    Card.frmBackMoney myBackMoney = new Card.frmBackMoney();
                    myBackMoney.ShowDialog();
                    myBackMoney.Dispose();
                    break;
                case "充值":
                    Card.EastRiver.ShowForm(IntPtr.Zero, DataLib.SysVar.strCon, 1);
                    /*
                    Card.frmFillMoney myFillMoney = new Card.frmFillMoney();
                    myFillMoney.ShowDialog();
                    myFillMoney.Dispose();
                     */ 
                    break;
                case "挂失处理":
                    Card.frmLostCard myLostCard = new Card.frmLostCard();
                    myLostCard.ShowDialog();
                    myLostCard.Dispose();
                    break;
                case "订饭记录":
                    Card.frmPreDinner myPreDinner = new Card.frmPreDinner();
                    myPreDinner.ShowDialog();
                    myPreDinner.Dispose();
                    break;
                case "售饭记录":
                    Card.frmSellDinner mySellDinner = new Card.frmSellDinner();
                    mySellDinner.ShowDialog();
                    mySellDinner.Dispose();
                    break;
                case "售饭情况表":
                    Card.frmDinnerReport myDinnerReport = new Card.frmDinnerReport();
                    myDinnerReport.ShowDialog();
                    myDinnerReport.Dispose();
                    break;
                case "来电记录":
                    if (IsOpenAs("DispTelReport") == false)
                    {
                        Report.DispTelReport myTelReport = new Report.DispTelReport();
                        myTelReport.MdiParent = this;
                        myTelReport.Show();
                    }
                    break;
                case "会计科目":
                    if (IsOpenAs("frmSubject") == false)
                    {
                        Finance.frmSubject mySubject = new Finance.frmSubject();
                        mySubject.ShowDialog();
                        mySubject.Dispose();
                    }
                    break;
                case "常用摘要":
                    if (IsOpenAs("frmAbstract") == false)
                    {
                        Finance.frmAbstract myAbstract = new Finance.frmAbstract();
                        myAbstract.ShowDialog();
                        myAbstract.Dispose();
                    }
                    break;
                case "币别":
                    if (IsOpenAs("frmCurrency") == false)
                    {
                        Finance.frmCurrency myCurrency = new Finance.frmCurrency();
                        myCurrency.MdiParent = this;
                        myCurrency.Show();
                    }
                    break;
                case "期初余额":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmCWInit") == false)
                    {
                        Finance.frmCWInit myCWInit = new Finance.frmCWInit();
                        myCWInit.MdiParent = this;
                        myCWInit.Show();
                    }
                    break;
                case "财务启用":
                    if (IsOpenAs("frmFinanceInit") == false)
                    {
                        Finance.frmFinanceInit myFinanceInit = new Finance.frmFinanceInit();
                        myFinanceInit.ShowDialog();
                        myFinanceInit.Dispose();
                    }
                    break;
                case "凭证录入":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmCertificate") == false)
                    {
                        Finance.frmCertificate myCertificate = new Finance.frmCertificate();
                        myCertificate.ShowDialog();
                        myCertificate.Dispose();
                    }
                    break;
                case "凭证查询":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmCertificateList") == false)
                    {
                        Finance.frmCertificateList myCertificateList = new Finance.frmCertificateList();
                        myCertificateList.MdiParent = this;
                        myCertificateList.Show();
                    }
                    break;
                case "凭证审核":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmCertificateList") == false)
                    {
                        Finance.frmCertificateList myCertificateList = new Finance.frmCertificateList();
                        myCertificateList.MdiParent = this;
                        myCertificateList.Show();
                    }
                    break;  
                case "凭证登帐":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmRecordCf") == false)
                    {
                        Finance.frmRecordCf myRecordCf = new Finance.frmRecordCf();
                        myRecordCf.ShowDialog();
                        myRecordCf.Dispose();
                    }
                    break;
                case "期末结帐":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmCfCehckOut") == false)
                    {
                        Finance.frmCfCehckOut myCfCehckOut = new Finance.frmCfCehckOut();
                        myCfCehckOut.ShowDialog();
                        myCfCehckOut.Dispose();
                    }
                    break;
                case "结转损益":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmCheckLoss") == false)
                    {
                        Finance.frmCheckLoss myCheckLoss = new Finance.frmCheckLoss();
                        myCheckLoss.ShowDialog();
                        myCheckLoss.Dispose();
                    }
                    break;
                case "总分类帐":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmFTotalReport") == false)
                    {
                        Finance.frmFTotalReport myFTotalReport = new Finance.frmFTotalReport();
                        myFTotalReport.MdiParent = this;
                        myFTotalReport.Show();
                    }
                    break;
                case "日记帐":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmFDayReport") == false)
                    {
                        Finance.frmFDayReport myFDayReport = new Finance.frmFDayReport();
                        myFDayReport.MdiParent = this;
                        myFDayReport.Show();
                    }
                    break;
                case "明细分类帐":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmFDetailReport") == false)
                    {
                        Finance.frmFDetailReport myFDetailReport = new Finance.frmFDetailReport();
                        myFDetailReport.MdiParent = this;
                        myFDetailReport.Show();
                    }
                    break;
                case "多栏式明细帐":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmFMulDetailReport") == false)
                    {
                        Finance.frmFMulDetailReport myFMulDetailReport = new Finance.frmFMulDetailReport();
                        myFMulDetailReport.MdiParent = this;
                        myFMulDetailReport.Show();
                    }
                    break;
                case "科目汇总表":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmFSubjectTotalReport") == false)
                    {
                        Finance.frmFSubjectTotalReport myFSubjectTotalReport = new Finance.frmFSubjectTotalReport();
                        myFSubjectTotalReport.MdiParent = this;
                        myFSubjectTotalReport.Show();
                    }
                    break;
                case "试算平衡表":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmFTryCalReport") == false)
                    {
                        Finance.frmFTryCalReport myFTryCalReport = new Finance.frmFTryCalReport();
                        myFTryCalReport.MdiParent = this;
                        myFTryCalReport.Show();
                    }
                    break;

                case "自定义财务报表":
                    if (TestcwInit() == false) return;
                    ShowFinaceReport();
                    break;
                case "资产负债表":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmFdebtReport") == false)
                    {
                        Finance.frmFdebtReport myFdebtReport = new Finance.frmFdebtReport();
                        myFdebtReport.MdiParent = this;
                        myFdebtReport.Show();
                    }
                    break;
                case "利润表":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmFGainReport") == false)
                    {
                        Finance.frmFGainReport myFGainReport = new Finance.frmFGainReport();
                        myFGainReport.MdiParent = this;
                        myFGainReport.Show();
                    }
                    break;
                case "损益表":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmFProfitReport") == false)
                    {
                        Finance.frmFProfitReport myFProfitReport = new Finance.frmFProfitReport();
                        myFProfitReport.MdiParent = this;
                        myFProfitReport.Show();
                    }
                    break;
                case "现金初始余额":
                    if (IsOpenAs("frmIniCash") == false)
                    {
                        Cash.frmIniCash myIniCash = new Cash.frmIniCash();
                        myIniCash.ShowDialog();
                        myIniCash.Dispose();
                    }
                    break;
                case "银行初始余额":
                    if (IsOpenAs("frmIniBank") == false)
                    {
                        Cash.frmIniBank myIniBank = new Cash.frmIniBank();
                        myIniBank.ShowDialog();
                        myIniBank.Dispose();
                    }
                    break;
                case "现金日记帐":
                    if (IsOpenAs("frmCashList") == false)
                    {
                        Cash.frmCashList myFCashList = new Cash.frmCashList();
                        myFCashList.MdiParent = this;
                        myFCashList.Show();
                    }
                    break;
                case "银行日记帐":
                    if (IsOpenAs("frmBankList") == false)
                    {
                        Cash.frmBankList myBankList = new Cash.frmBankList();
                        myBankList.MdiParent = this;
                        myBankList.Show();
                    }
                    break;
                case "出纳结帐":
                    if (IsOpenAs("frmCashCheckOut") == false)
                    {
                        Cash.frmCashCheckOut myCashCheckOut = new Cash.frmCashCheckOut();
                        myCashCheckOut.ShowDialog();
                        myCashCheckOut.Dispose();
                    }
                    break;
                case "出纳结帐报表":
                    if (IsOpenAs("frmCashCheckOutQuery") == false)
                    {
                        Report.frmCashCheckOutQuery myCashCheckOutQuery = new Report.frmCashCheckOutQuery();
                        myCashCheckOutQuery.MdiParent = this;
                        myCashCheckOutQuery.Show();
                    }
                    break;
                case "资产类别":
                    if (IsOpenAs("frmAssetType") == false)
                    {
                        Finance.frmAssetType myAssetType = new Finance.frmAssetType();
                        myAssetType.ShowDialog();
                        myAssetType.Dispose();
                    }
                    break;
                case "增减方式":
                    if (IsOpenAs("frmAddType") == false)
                    {
                        Finance.frmAddType frmAddType = new Finance.frmAddType();
                        frmAddType.ShowDialog();
                        frmAddType.Dispose();
                    }
                    break;
                case "资产增加":
                    if (IsOpenAs("frmAssetList") == false)
                    {
                        Finance.frmAssetList myAssetList = new Finance.frmAssetList();
                        myAssetList.MdiParent = this;
                        myAssetList.Show();
                    }
                    break;
                case "资产减少":
                    if (IsOpenAs("frmAssetReduceList") == false)
                    {
                        Finance.frmAssetReduceList myAssetReduceList = new Finance.frmAssetReduceList();
                        myAssetReduceList.MdiParent = this;
                        myAssetReduceList.Show();
                    }
                    break;
                case "计提折旧":
                    CalAsset();
                    break;
                case "使用情况":
                    if (IsOpenAs("frmUseInfo") == false)
                    {
                        Finance.frmUseInfo myUseInfo = new Finance.frmUseInfo();
                        myUseInfo.ShowDialog();
                        myUseInfo.Dispose();
                    }
                    break;
                case "固定资产清单":
                    if (IsOpenAs("frmAssetReport") == false)
                    {
                        Finance.frmAssetReport myAssetReport = new Finance.frmAssetReport();
                        myAssetReport.MdiParent = this;
                        myAssetReport.Show();
                    }
                    break;
                case "固定资产折旧表":
                    if (IsOpenAs("frmAssetDepreReport") == false)
                    {
                        Finance.frmAssetDepreReport myAssetDepreReport = new Finance.frmAssetDepreReport();
                        myAssetDepreReport.MdiParent = this;
                        myAssetDepreReport.Show();
                    }
                    break;
                case "固定资产累计折旧表":
                    if (IsOpenAs("frmAssetTotalOldReport") == false)
                    {
                        Finance.frmAssetTotalOldReport myAssetTotalOldReport = new Finance.frmAssetTotalOldReport();
                        myAssetTotalOldReport.MdiParent = this;
                        myAssetTotalOldReport.Show();
                    }
                    break;
                case "累计工作量查询":
                    if (IsOpenAs("frmWorkQueryReport") == false)
                    {
                        Finance.frmWorkQueryReport myWorkQueryReport = new Finance.frmWorkQueryReport();
                        myWorkQueryReport.MdiParent = this;
                        myWorkQueryReport.Show();
                    }
                    break;

                case "通告消息":
                    Sys.frmWakeNotice myWakeNotice = new Sys.frmWakeNotice();
                    myWakeNotice.ShowDialog();
                    myWakeNotice.Dispose();
                    break;
                case "号码归属地":
                    Sys.MBAdrQueryForm mr = new Sys.MBAdrQueryForm();
                    mr.ShowDialog();
                    mr.Dispose();
                    break;
                case "区号查询":
                    Sys.AreaCodeQueryForm AQF = new Sys.AreaCodeQueryForm();
                    AQF.ShowDialog();
                    AQF.Dispose();
                    break;
                case "设备资料":
                    if (IsOpenAs("frmDevice") == false)
                    {
                        Base.frmDevice myDeviceList = new Base.frmDevice();
                        myDeviceList.MdiParent = this;
                        myDeviceList.Show();
                    }
                    break;
                case "设备维护":
                    if (IsOpenAs("frmDeviceRepair") == false)
                    {
                        Base.frmDeviceRepair myDeviceRepair = new Base.frmDeviceRepair();
                        myDeviceRepair.MdiParent = this;
                        myDeviceRepair.Show();
                    }
                    break;
                case "多级审核":
                    if (IsOpenAs("frmMultCheck") == false)
                    {
                        Sys.frmMultCheck myMultCheck = new Sys.frmMultCheck();
                        myMultCheck.ShowDialog();
                        myMultCheck.Dispose();
                    }
                    break;


                case "二次开发接口":
                    if (IsOpenAs("UserDesign") == false)
                    {
                        Common.UserDesign myUserDesign = new Common.UserDesign();
                        myUserDesign.MdiParent = this;
                        myUserDesign.Show();
                    }
                    break;
                case "窗体设计器":
                    if (IsOpenAs("DesignForm") == false)
                    {
                        DataLib.SysVar.blnDesignForm = true;
                        try
                        {

                            UserDesignForm.DesignForm myDesignForm = new UserDesignForm.DesignForm();
                            myDesignForm.ShowDialog();
                            myDesignForm.Dispose();
                        }
                        catch (Exception E)
                        {
                            MessageBox.Show(E.Message, "错误");
                        }
                        finally
                        {
                            DataLib.SysVar.blnDesignForm = false;
                        }
                    }
                    break;
            }

        }

        /// <summary>
        /// 计提折旧
        /// </summary>
        private void CalAsset()
        {
            if (TestRight("CalAsset") == false) return;
            if (MessageBox.Show(this, "真的要对本期进行计提折旧操作吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("exec sp_CalAsset " + DateTime.Today.Year.ToString() + "," + DateTime.Today.Month.ToString()) == 0)
            {
                MessageBox.Show(this,"本期计提成功!!","提示");
            }
            
        }

        private void ShowFinaceReport()
        {
            if (TestRight("FinaceReport") == false) return;
            DataLib.SysVar.ShowUserReport(this.Handle, DataLib.SysVar.strCon);
            /*
            int intYear, intMonth;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select top 1 * from t_Period order by AID Desc");
            if (ds.Tables[0].Rows.Count == 0) return;
            intYear = Convert.ToInt32(ds.Tables[0].Rows[0]["F_Year"]);
            intMonth = Convert.ToInt32(ds.Tables[0].Rows[0]["F_Month"]);
            intMonth = intMonth + 1;
            if (intMonth > 12)
            {
                intMonth = 1;
                intYear = intYear + 1;
            }
            string sValue = intYear.ToString() + ";" + intMonth.ToString();
            DataLib.SysVar.RMDesigner(IntPtr.Zero, DataLib.SysVar.strCon, "Finance", "Year;Month", sValue);
             */ 
        }

        private void SetLinkEvent()
        {
            foreach (BarItemLink bItem in this.MenuBar.ItemLinks)
            {
                if (bItem is BarSubItemLink)
                {
                    if (bItem.Item.Name == "bsReport")
                    {
                        foreach (BarItemLink con in (bItem as BarSubItemLink).VisibleLinks)
                        {
                            foreach (BarButtonItemLink Btn in (con as BarSubItemLink).VisibleLinks)
                            {
                                Btn.Item.ItemClick += new ItemClickEventHandler(ItemClick);
                            }    
                        }
                    }
                    else
                    {
                        foreach (BarButtonItemLink con in (bItem as BarSubItemLink).VisibleLinks)
                        {
                            con.Item.ItemClick += new ItemClickEventHandler(ItemClick);
                        }
                    }
                }
            }          
        }

        private void ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm(e.Item.Caption);
        }   

        /// <summary>
        /// 判断ＭＤＩ窗口是否打开
        /// </summary>
        /// <param name="FormName"></param>
        /// <returns></returns>
        private bool IsOpenAs(string FormName)
        {
            if (FormName == "frmBack") return false;
            if (TestRight(FormName) == false) return true;
            if (this.MdiChildren.Length == 0) return false;

            if (DataLib.SysVar.blnInit == false)
            {
                MessageBox.Show("系统未进行初始化!!", "提示");
                return false;
            }

            foreach (Form myForm in this.MdiChildren)
            {
                if (myForm.Name == FormName)
                {
                    if (myForm.WindowState == FormWindowState.Minimized)
                        myForm.WindowState = FormWindowState.Normal;
                    myForm.Activate();
                    return true;
                }
            }
            return false;

        }

        private void bmBack_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowBack();
        }


        /// <summary>
        /// 判断是否初始化
        /// </summary>
        public void SetIniStatus()
        {
            DataLib.SysVar.intIndex = DataLib.SysVar.GetIntParmValue("F_C1");
            if (DataLib.SysVar.blnInit == false)
            {
                bsJxc.Enabled = false;
                bsProduct.Enabled = false;
                bsOut.Enabled = false;
                //bsReport.Enabled = false;
            }
            else
            {
                bsJxc.Enabled = true;
                bsProduct.Enabled = true;
                bsOut.Enabled = true;
                //bsReport.Enabled = true;
            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            if (DataLib.SysVar.GetParmValue("F_N2") == true)
            {
                if (IsOpenAs("frmWakeCenter") == false)
                {
                    Sys.frmWakeCenter myWakeCenter = new Sys.frmWakeCenter();
                    myWakeCenter.MdiParent = this;
                    myWakeCenter.Show();
                }

            }

            //OA.frmOAWakeUp F = new OA.frmOAWakeUp();
            ////F.MdiParent = this;
            //F.Show();
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void binAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmAbout myAbout = new frmAbout();
            myAbout.ShowDialog();
            myAbout.Dispose();
        }

        private void barButtonItem97_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.skinEngine1.SkinFile = "DiamondBlue.ssk";

        }

        private void barButtonItem98_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.skinEngine1.SkinFile = "DiamondGreen.ssk";

        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if(this .WindowState ==FormWindowState.Minimized)
            {
                this.Hide();
                this.notIcon.Visible = true;
            }
        }

        private void notIcon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Maximized;
                this.notIcon.Visible = false;
            }
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Maximized;
            this.notIcon.Visible = false;

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        
    }
}

