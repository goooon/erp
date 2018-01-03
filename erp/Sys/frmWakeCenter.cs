using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class frmWakeCenter : BaseClass.frmBase
    {
        public frmWakeCenter()
        {
            InitializeComponent();
        }

        private bool TestUse(string strModule)
        {
            if (DataLib.SysVar.strUGroup == "超级用户") return true;
            string strSQL = @"select F_Enable from t_RightDetail
                            where F_Class = '" + strModule + @"'
                            and F_Name = '可用'
                            and F_Group = '" + DataLib.SysVar.strUGroup + "'";

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (ds.Tables[0].Rows.Count == 0) return false;

            return Convert.ToBoolean(ds.Tables[0].Rows[0][0]);
        }

        private void GetApplyStock()
        {
            string strSQL = "";
            DataSet ds = null;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (TestUse("frmApplyStockList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_Dept,c.F_Name as F_EmpName from t_ApplyStock a ";
                strSQL = strSQL + "left join t_Class b ";
                strSQL = strSQL + "on a.F_DeptID = b.F_ID ";
                strSQL = strSQL + "left join t_Emp c ";
                strSQL = strSQL + "on a.F_ApplyMan = c.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";

                ds = myHelper.GetDs(strSQL);
                gcApplyStock.DataSource = ds.Tables[0].DefaultView;
            }


            if (TestUse("frmStockOrderList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_Supplier,c.F_Name as F_Dept,d.F_Name as F_EmpName from t_StockOrder a ";
                strSQL = strSQL + "left join t_Supplier b ";
                strSQL = strSQL + "on a.F_SupplierID = b.F_ID ";
                strSQL = strSQL + "left join t_Class c ";
                strSQL = strSQL + "on a.F_DeptID = c.F_ID ";
                strSQL = strSQL + "left join t_Emp d ";
                strSQL = strSQL + "on a.F_Opertor = d.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";

                ds = myHelper.GetDs(strSQL);
                gcStockOrder.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmStockOrderList") == true)
            {
                decimal decDay1 = DataLib.SysVar.GetDecParmValue("F_C6");
                strSQL = "select a.*,b.F_Name as F_Supplier,c.F_Name as F_Dept,d.F_Name as F_EmpName from t_StockOrder a ";
                strSQL = strSQL + "left join t_Supplier b ";
                strSQL = strSQL + "on a.F_SupplierID = b.F_ID ";
                strSQL = strSQL + "left join t_Class c ";
                strSQL = strSQL + "on a.F_DeptID = c.F_ID ";
                strSQL = strSQL + "left join t_Emp d ";
                strSQL = strSQL + "on a.F_Opertor = d.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) =  1 and isnull(a.F_Finish,0) = 0 ";
                strSQL = strSQL + " and datediff(day,getdate(),F_StockTime) <= "+decDay1.ToString();
                strSQL = strSQL + " and datediff(day,getdate(),F_StockTime) >= 0";
                strSQL = strSQL + " and isnull(a.F_Invalid,0) = 0 ";
                ds = myHelper.GetDs(strSQL);
                gcStockOrder1.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmStockInList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_Supplier,c.F_Name as F_Dept,d.F_Name as F_EmpName from t_StockIn a ";
                strSQL = strSQL + "left join t_Supplier b ";
                strSQL = strSQL + "on a.F_SupplierID = b.F_ID ";
                strSQL = strSQL + "left join t_Class c ";
                strSQL = strSQL + "on a.F_DeptID = c.F_ID ";
                strSQL = strSQL + "left join t_Emp d ";
                strSQL = strSQL + "on a.F_StockMan = d.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";

                ds = myHelper.GetDs(strSQL);
                gcStockIn.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmStockPayList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_Supplier from t_Pay a ";
                strSQL = strSQL + "left join t_Supplier b ";
                strSQL = strSQL + "on a.F_SupplierID = b.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";

                ds = myHelper.GetDs(strSQL);
                gcPay.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmStockBackList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_Supplier from t_StockBack a ";
                strSQL = strSQL + "left join t_Supplier b ";
                strSQL = strSQL + "on a.F_SupplierID = b.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";

                ds = myHelper.GetDs(strSQL);
                gcStockBack.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmAskPriceList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_Client from t_AskPrice a ";
                strSQL = strSQL + "left join t_Client b ";
                strSQL = strSQL + "on a.F_ClientID = b.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";

                ds = myHelper.GetDs(strSQL);
                gcAskPrice.DataSource = ds.Tables[0].DefaultView;
            }


            if (TestUse("frmSellPriceList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_Client from t_SellPrice a ";
                strSQL = strSQL + "left join t_Client b ";
                strSQL = strSQL + "on a.F_ClientID = b.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";

                ds = myHelper.GetDs(strSQL);
                gcSellPrice.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmSellOrderList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_Client,c.F_Name as F_EmpName from t_SellOrder a ";
                strSQL = strSQL + "left join t_Client b ";
                strSQL = strSQL + "on a.F_ClientID = b.F_ID ";
                strSQL = strSQL + "left join t_Emp c ";
                strSQL = strSQL + "on a.F_Opertor = c.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and (a.F_BillMan = '" + DataLib.SysVar.strUName + "' or a.F_BillMan = '超级用户')";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";
                ds = myHelper.GetDs(strSQL);
                gcSellOrder.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmSellOrderList") == true)
            {
                decimal decDay2 = DataLib.SysVar.GetDecParmValue("F_C5");
                strSQL = "select a.*,b.F_Name as F_Client,c.F_Name as F_EmpName from t_SellOrder a ";
                strSQL = strSQL + "left join t_Client b ";
                strSQL = strSQL + "on a.F_ClientID = b.F_ID ";
                strSQL = strSQL + "left join t_Emp c ";
                strSQL = strSQL + "on a.F_Opertor = c.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 1 and isnull(a.F_Finish,0) = 0 ";
                strSQL = strSQL + "and datediff(day,getdate(),F_SendDate) >= 0 and datediff(day,getdate(),F_SendDate) <= "+decDay2.ToString();
                strSQL = strSQL + " and (a.F_BillMan = '" + DataLib.SysVar.strUName + "' or a.F_BillMan = '超级用户')";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";
                ds = myHelper.GetDs(strSQL);
                gcSellOrder1.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmSellPreList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_Client,c.F_Name as F_EmpName from t_SellPre a ";
                strSQL = strSQL + "left join t_Client b ";
                strSQL = strSQL + "on a.F_ClientID = b.F_ID ";
                strSQL = strSQL + "left join t_Emp c ";
                strSQL = strSQL + "on a.F_Opertor = c.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and (a.F_BillMan = '" + DataLib.SysVar.strUName + "' or a.F_BillMan = '超级用户')";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";
                ds = myHelper.GetDs(strSQL);
                gcSellPre.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmSellOutList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_Client,c.F_Name as F_EmpName from t_SellOut a ";
                strSQL = strSQL + "left join t_Client b ";
                strSQL = strSQL + "on a.F_ClientID = b.F_ID ";
                strSQL = strSQL + "left join t_Emp c ";
                strSQL = strSQL + "on a.F_Opertor = c.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and (a.F_BillMan = '" + DataLib.SysVar.strUName + "' or a.F_BillMan = '超级用户')";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";
                ds = myHelper.GetDs(strSQL);
                gcSellOut.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmSellAcceptList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_Client from t_Accept a ";
                strSQL = strSQL + "left join t_Client b ";
                strSQL = strSQL + "on a.F_ClientID = b.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and (a.F_BillMan = '" + DataLib.SysVar.strUName + "' or a.F_BillMan = '超级用户')";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";
                ds = myHelper.GetDs(strSQL);
                gcAccept.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmSellBackList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_Client from t_SellBack a ";
                strSQL = strSQL + "left join t_Client b ";
                strSQL = strSQL + "on a.F_ClientID = b.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and (a.F_BillMan = '" + DataLib.SysVar.strUName + "' or a.F_BillMan = '超级用户')";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";
                ds = myHelper.GetDs(strSQL);
                gcSellBack.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmCheckList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_Storage from t_Check a ";
                strSQL = strSQL + "left join t_Storage b ";
                strSQL = strSQL + "on a.F_StorageID = b.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";
                ds = myHelper.GetDs(strSQL);
                gcCheck.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmOtherInList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_Dept from t_Other a ";
                strSQL = strSQL + "left join t_Class b ";
                strSQL = strSQL + "on a.F_DeptID = b.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and isnull(F_Flag,0) = 0 ";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";
                ds = myHelper.GetDs(strSQL);
                gcOtherIn.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmOtherOutList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_Dept from t_Other a ";
                strSQL = strSQL + "left join t_Class b ";
                strSQL = strSQL + "on a.F_DeptID = b.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and isnull(F_Flag,0) = 1 ";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";
                ds = myHelper.GetDs(strSQL);
                gcOtherOut.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmExchangeList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_OutStorageName,c.F_Name as F_InStorageName from t_Exchange a ";
                strSQL = strSQL + "left join t_Storage b ";
                strSQL = strSQL + "on a.F_OutStorage = b.F_ID ";
                strSQL = strSQL + "left join t_Storage c ";
                strSQL = strSQL + "on a.F_InStorage = c.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";
                ds = myHelper.GetDs(strSQL);
                gcExchange.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmInstallList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_ItemName,b.F_Spec,c.F_Name as F_Storage from t_Install a ";
                strSQL = strSQL + "left join t_Item b ";
                strSQL = strSQL + "on a.F_ItemID = b.F_ID ";
                strSQL = strSQL + "left join t_Storage c ";
                strSQL = strSQL + "on a.F_StorageID = c.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";
                ds = myHelper.GetDs(strSQL);
                gcInstall.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmProductPlanList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_Dept from t_ProductPlan a ";
                strSQL = strSQL + "left join t_Class b ";
                strSQL = strSQL + "on a.F_DeptID = b.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";
                ds = myHelper.GetDs(strSQL);
                gcProductPlan.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmTaskList") == true)
            {
                strSQL = "select * from t_Task where isnull(F_Check,0) = 0 and isnull(F_Invalid,0) = 0";

                ds = myHelper.GetDs(strSQL);
                gcTask.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmProductStatusList") == true)
            {
                strSQL = "select * from t_ProductStatus where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0";

                ds = myHelper.GetDs(strSQL);
                gcProductStatus.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmDrawGoodsList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_Dept from t_DrawGoods a ";
                strSQL = strSQL + "left join t_Class b ";
                strSQL = strSQL + "on a.F_DeptID = b.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";

                ds = myHelper.GetDs(strSQL);
                gcDrawGoods.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmPatchGoodsList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_Dept from t_PatchGoods a ";
                strSQL = strSQL + "left join t_Class b ";
                strSQL = strSQL + "on a.F_DeptID = b.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";

                ds = myHelper.GetDs(strSQL);
                gcPatchGoods.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmBackGoodsList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_Dept from t_BackGoods a ";
                strSQL = strSQL + "left join t_Class b ";
                strSQL = strSQL + "on a.F_DeptID = b.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";

                ds = myHelper.GetDs(strSQL);
                gcBackGoods.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmProductInList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_Dept from t_ProductIn a ";
                strSQL = strSQL + "left join t_Class b ";
                strSQL = strSQL + "on a.F_DeptID = b.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";
                ds = myHelper.GetDs(strSQL);
                gcProductIn.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmOutBillList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_OutSupplier from t_OutBill a ";
                strSQL = strSQL + "left join t_OutSupplier b ";
                strSQL = strSQL + "on a.F_OutSupplierID = b.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";
                ds = myHelper.GetDs(strSQL);
                gcOutBill.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmOutDrawGoodsList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_OutSupplier from t_OutDrawGoods a ";
                strSQL = strSQL + "left join t_OutSupplier b ";
                strSQL = strSQL + "on a.F_OutSupplierID = b.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";
                ds = myHelper.GetDs(strSQL);
                gcOutDrawGoods.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmOutBackGoodsList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_OutSupplier from t_OutBackGoods a ";
                strSQL = strSQL + "left join t_OutSupplier b ";
                strSQL = strSQL + "on a.F_OutSupplierID = b.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";
                ds = myHelper.GetDs(strSQL);
                gcOutBackGoods.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmOutInStoreList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_OutSupplier from t_OutInStore a ";
                strSQL = strSQL + "left join t_OutSupplier b ";
                strSQL = strSQL + "on a.F_OutSupplierID = b.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";
                ds = myHelper.GetDs(strSQL);
                gcOutInStore.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmOutBackStoreList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_OutSupplier from t_OutBackStore a ";
                strSQL = strSQL + "left join t_OutSupplier b ";
                strSQL = strSQL + "on a.F_OutSupplierID = b.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";
                ds = myHelper.GetDs(strSQL);
                gcOutBackStore.DataSource = ds.Tables[0].DefaultView;
            }

            if (TestUse("frmOutPayList") == true)
            {
                strSQL = "select a.*,b.F_Name as F_OutSupplier from t_OutPay a ";
                strSQL = strSQL + "left join t_OutSupplier b ";
                strSQL = strSQL + "on a.F_OutSupplierID = b.F_ID ";
                strSQL = strSQL + "where isnull(a.F_Check,0) = 0 ";
                strSQL = strSQL + "and isnull(a.F_Invalid,0) = 0 ";
                ds = myHelper.GetDs(strSQL);
                gcOutPay.DataSource = ds.Tables[0].DefaultView;
            }

            strSQL = "select a.*,b.F_Kind,b.F_Name as F_ItemName,b.F_Spec,";
            strSQL = strSQL + "b.F_UpLimit,b.F_DownLimit,b.F_SafeQty,";
            strSQL = strSQL + "c.F_Name as F_Storage ";
            strSQL = strSQL + "from t_StorageQty a,t_Item b,t_Storage c ";
            strSQL = strSQL + "where a.F_ItemID = b.F_ID ";
            strSQL = strSQL + "and a.F_StorageID = c.F_ID ";

            ds = myHelper.GetDs(strSQL);
            gcLimit.DataSource = ds.Tables[0].DefaultView;


            strSQL = "select * from t_Notice where Year(F_Date) = " + DateTime.Today.Year.ToString();
            strSQL =  strSQL + " and Month(F_Date) = "+DateTime.Today.Month.ToString()+" and Day(F_Date) = "+DateTime.Today.Day.ToString();
            ds = myHelper.GetDs(strSQL);
            txtMain.DataBindings.Add("EditValue",ds.Tables[0],"F_Main");
            meTxt.DataBindings.Add("EditValue", ds.Tables[0], "F_Memo");


            strSQL = @"select a.*,b.*,c.F_Name as F_ItemName,c.F_Spec
                        from t_Cast a,t_CastDetail b,t_Item c
                        where a.F_ID = b.F_ID
                        and b.F_ItemID = c.F_ID
                        and DATEDIFF(day,getdate(),a.F_End) <= 7
                        and DATEDIFF(day,getdate(),a.F_End) > 0";
            ds = myHelper.GetDs(strSQL);
            gcPreOut.DataSource = ds.Tables[0].DefaultView;

            strSQL = @"select a.*,b.*,c.F_Name as F_ItemName,c.F_Spec
                        from t_Cast a,t_CastDetail b,t_Item c
                        where a.F_ID = b.F_ID
                        and b.F_ItemID = c.F_ID
                        and DATEDIFF(day,getdate(),a.F_End) < 0";
            ds = myHelper.GetDs(strSQL);
            gcHasOut.DataSource = ds.Tables[0].DefaultView;

        }

        private void OpenBill(string strTag)
        {
            DataRow dr;
            switch (strTag)
            {
                case "ApplyStock":
                    if (gvApplyStock.FocusedRowHandle < 0) return;
                    dr = gvApplyStock.GetDataRow(gvApplyStock.FocusedRowHandle);
                    Stock.frmApplyStock myApplyStock = new Stock.frmApplyStock();
                    myApplyStock.strBillID = dr["F_BillID"].ToString();
                    myApplyStock.ShowDialog();
                    myApplyStock.Dispose();
                    break;
                case "StockOrder":
                    if (gvStockOrder.FocusedRowHandle < 0) return;
                    dr = gvStockOrder.GetDataRow(gvStockOrder.FocusedRowHandle);
                    Stock.frmStockOrder myStockOrder = new Stock.frmStockOrder();
                    myStockOrder.strBillID = dr["F_BillID"].ToString();
                    myStockOrder.ShowDialog();
                    myStockOrder.Dispose();
                    break;
                case "StockOrder1":
                    if (gvStockOrder1.FocusedRowHandle < 0) return;
                    dr = gvStockOrder1.GetDataRow(gvStockOrder1.FocusedRowHandle);
                    Stock.frmStockOrder myStockOrder1 = new Stock.frmStockOrder();
                    myStockOrder1.strBillID = dr["F_BillID"].ToString();
                    myStockOrder1.ShowDialog();
                    myStockOrder1.Dispose();
                    break;
                case "StockIn":
                    if (gvStockIn.FocusedRowHandle < 0) return;
                    dr = gvStockIn.GetDataRow(gvStockIn.FocusedRowHandle);
                    Stock.frmStockIn myStockIn = new Stock.frmStockIn();
                    myStockIn.strBillID = dr["F_BillID"].ToString();
                    myStockIn.ShowDialog();
                    myStockIn.Dispose();
                    break;
                case "StockPay":
                    if (gvPay.FocusedRowHandle < 0) return;
                    dr = gvPay.GetDataRow(gvPay.FocusedRowHandle);
                    Stock.frmStockPay myStockPay = new Stock.frmStockPay();
                    myStockPay.strBillID = dr["F_BillID"].ToString();
                    myStockPay.ShowDialog();
                    myStockPay.Dispose();
                    break;
                case "StockBack":
                    if (gvStockBack.FocusedRowHandle < 0) return;
                    dr = gvStockBack.GetDataRow(gvStockBack.FocusedRowHandle);
                    Stock.frmStockBack myStockBack = new Stock.frmStockBack();
                    myStockBack.strBillID = dr["F_BillID"].ToString();
                    myStockBack.ShowDialog();
                    myStockBack.Dispose();
                    break;
                case "AskPrice":
                    if (gvAskPrice.FocusedRowHandle < 0) return;
                    dr = gvAskPrice.GetDataRow(gvAskPrice.FocusedRowHandle);
                    Sell.frmAskPrice myAskPrice = new Sell.frmAskPrice();
                    myAskPrice.strBillID = dr["F_BillID"].ToString();
                    myAskPrice.ShowDialog();
                    myAskPrice.Dispose();
                    break;
                case "SellPrice":
                    if (gvSellPrice.FocusedRowHandle < 0) return;
                    dr = gvSellPrice.GetDataRow(gvSellPrice.FocusedRowHandle);

                    Sell.frmSellPrice mySellPrice = new Sell.frmSellPrice();
                    mySellPrice.strBillID = dr["F_BillID"].ToString();
                    mySellPrice.ShowDialog();
                    mySellPrice.Dispose();
                    break;
                case "SellOrder":
                    if (gvSellOrder.FocusedRowHandle < 0) return;
                    dr = gvSellOrder.GetDataRow(gvSellOrder.FocusedRowHandle);
                    Sell.frmSellOrder mySellOrder = new Sell.frmSellOrder();
                    mySellOrder.strBillID = dr["F_BillID"].ToString();
                    mySellOrder.ShowDialog();
                    mySellOrder.Dispose();
                    break;
                case "SellOrder1":
                    if (gvSellOrder1.FocusedRowHandle < 0) return;
                    dr = gvSellOrder1.GetDataRow(gvSellOrder1.FocusedRowHandle);
                    Sell.frmSellOrder mySellOrder1 = new Sell.frmSellOrder();
                    mySellOrder1.strBillID = dr["F_BillID"].ToString();
                    mySellOrder1.ShowDialog();
                    mySellOrder1.Dispose();
                    break;
                case "SellPre":
                    if (gvSellPre.FocusedRowHandle < 0) return;
                    dr = gvSellPre.GetDataRow(gvSellPre.FocusedRowHandle);
                    Sell.frmSellPre mySellPre = new Sell.frmSellPre();
                    mySellPre.strBillID = dr["F_BillID"].ToString();
                    mySellPre.ShowDialog();
                    mySellPre.Dispose();
                    break;
                case "SellOut":
                    if (gvSellOut.FocusedRowHandle < 0) return;
                    dr = gvSellOut.GetDataRow(gvSellOut.FocusedRowHandle);
                    Sell.frmSellOut mySellOut = new Sell.frmSellOut();
                    mySellOut.strBillID = dr["F_BillID"].ToString();
                    mySellOut.ShowDialog();
                    mySellOut.Dispose();
                    break;
                case "Accept":
                    if (gvAccept.FocusedRowHandle < 0) return;
                    dr = gvAccept.GetDataRow(gvAccept.FocusedRowHandle);
                    Sell.frmSellAccept mySellAccept = new Sell.frmSellAccept();
                    mySellAccept.strBillID = dr["F_BillID"].ToString();
                    mySellAccept.ShowDialog();
                    mySellAccept.Dispose();
                    break;
                case "SellBack":
                    if (gvSellBack.FocusedRowHandle < 0) return;
                    dr = gvSellBack.GetDataRow(gvSellBack.FocusedRowHandle);
                    Sell.frmSellBack mySellBack = new Sell.frmSellBack();
                    mySellBack.strBillID = dr["F_BillID"].ToString();
                    mySellBack.ShowDialog();
                    mySellBack.Dispose();
                    break;
                case "Check":
                    if (gvCheck.FocusedRowHandle < 0) return;
                    dr = gvCheck.GetDataRow(gvCheck.FocusedRowHandle);
                    Storage.frmCheck myCheck = new Storage.frmCheck();
                    myCheck.strBillID = dr["F_BillID"].ToString();
                    myCheck.ShowDialog();
                    myCheck.Dispose();
                    break;
                case "Exchange":
                    if (gvExchange.FocusedRowHandle < 0) return;
                    dr = gvExchange.GetDataRow(gvExchange.FocusedRowHandle);
                    Storage.frmExchange myExchange = new Storage.frmExchange();
                    myExchange.strBillID = dr["F_BillID"].ToString();
                    myExchange.ShowDialog();
                    myExchange.Dispose();
                    break;
                case "OtherIn":
                    if (gvOtherIn.FocusedRowHandle < 0) return;
                    dr = gvOtherIn.GetDataRow(gvOtherIn.FocusedRowHandle);
                    Storage.frmOtherIn myOtherIn = new Storage.frmOtherIn();
                    myOtherIn.strBillID = dr["F_BillID"].ToString();
                    myOtherIn.ShowDialog();
                    myOtherIn.Dispose();
                    break;
                case "OtherOut":
                    if (gvOtherOut.FocusedRowHandle < 0) return;
                    dr = gvOtherOut.GetDataRow(gvOtherOut.FocusedRowHandle);
                    Storage.frmOtherOut myOtherOut = new Storage.frmOtherOut();
                    myOtherOut.strBillID = dr["F_BillID"].ToString();
                    myOtherOut.ShowDialog();
                    myOtherOut.Dispose();
                    break;
                case "install":
                    if (gvInstall.FocusedRowHandle < 0) return;
                    dr = gvInstall.GetDataRow(gvInstall.FocusedRowHandle);
                    Storage.frmInstall myInstall = new Storage.frmInstall();
                    myInstall.strBillID = dr["F_BillID"].ToString();
                    myInstall.ShowDialog();
                    myInstall.Dispose();
                    break;
                case "ProductPlan":
                    if (gvProductPlan.FocusedRowHandle < 0) return;
                    dr = gvProductPlan.GetDataRow(gvProductPlan.FocusedRowHandle);
                    Product.frmProductPlan myProductPlan = new Product.frmProductPlan();
                    myProductPlan.strBillID = dr["F_BillID"].ToString();
                    myProductPlan.ShowDialog();
                    myProductPlan.Dispose();
                    break;
                case "Task":
                    if (gvTask.FocusedRowHandle < 0) return;
                    dr = gvTask.GetDataRow(gvTask.FocusedRowHandle);

                    Product.frmTask myTask = new Product.frmTask();
                    myTask.strBillID = dr["F_BillID"].ToString();
                    myTask.ShowDialog();
                    myTask.Dispose();
                    break;
                case "ProductStatus":
                    if (gvProductStatus.FocusedRowHandle < 0) return;
                    dr = gvProductStatus.GetDataRow(gvProductStatus.FocusedRowHandle);
                    Product.frmProductStatus myProductStatus = new Product.frmProductStatus();
                    myProductStatus.strBillID = dr["F_BillID"].ToString();
                    myProductStatus.ShowDialog();
                    myProductStatus.Dispose();
                    break;
                case "DrawGoods":
                    if (gvDrawGoods.FocusedRowHandle < 0) return;
                    dr = gvDrawGoods.GetDataRow(gvDrawGoods.FocusedRowHandle);
                    Product.frmDrawGoods myDrawGoods = new Product.frmDrawGoods();
                    myDrawGoods.strBillID = dr["F_BillID"].ToString();
                    myDrawGoods.ShowDialog();
                    myDrawGoods.Dispose();
                    break;
                case "PatchGoods":
                    if (gvPatchGoods.FocusedRowHandle < 0) return;
                    dr = gvPatchGoods.GetDataRow(gvPatchGoods.FocusedRowHandle);
                    Product.frmPatchGoods myPatchGoods = new Product.frmPatchGoods();
                    myPatchGoods.strBillID = dr["F_BillID"].ToString();
                    myPatchGoods.ShowDialog();
                    myPatchGoods.Dispose();
                    break;
                case "BackGoods":
                    if (gvBackGoods.FocusedRowHandle < 0) return;
                    dr = gvBackGoods.GetDataRow(gvBackGoods.FocusedRowHandle);
                    Product.frmBackGoods myBackGoods = new Product.frmBackGoods();
                    myBackGoods.strBillID = dr["F_BillID"].ToString();
                    myBackGoods.ShowDialog();
                    myBackGoods.Dispose();
                    break;
                case "ProductIn":
                    if (gvProductIn.FocusedRowHandle < 0) return;
                    dr = gvProductIn.GetDataRow(gvProductIn.FocusedRowHandle);
                    Product.frmProductIn myProductIn = new Product.frmProductIn();
                    myProductIn.strBillID = dr["F_BillID"].ToString();
                    myProductIn.ShowDialog();
                    myProductIn.Dispose();
                    break;
                case "OutBill":
                    if (gvOutBill.FocusedRowHandle < 0) return;
                    dr = gvOutBill.GetDataRow(gvOutBill.FocusedRowHandle);
                    OutProduct.frmOutBill myOutBill = new OutProduct.frmOutBill();
                    myOutBill.strBillID = dr["F_BillID"].ToString();
                    myOutBill.ShowDialog();
                    myOutBill.Dispose();
                    break;
                case "OutDrawGoods":
                    if (gvOutDrawGoods.FocusedRowHandle < 0) return;
                    dr = gvOutDrawGoods.GetDataRow(gvOutDrawGoods.FocusedRowHandle);
                    OutProduct.frmOutDrawGoods myOutDrawGoods = new OutProduct.frmOutDrawGoods();
                    myOutDrawGoods.strBillID = dr["F_BillID"].ToString();
                    myOutDrawGoods.ShowDialog();
                    myOutDrawGoods.Dispose();
                    break;
                case "OutBackGoods":
                    if (gvOutBackGoods.FocusedRowHandle < 0) return;
                    dr = gvOutBackGoods.GetDataRow(gvOutBackGoods.FocusedRowHandle);

                    OutProduct.frmOutBackGoods myOutBackGoods = new OutProduct.frmOutBackGoods();
                    myOutBackGoods.strBillID = dr["F_BillID"].ToString();
                    myOutBackGoods.ShowDialog();
                    myOutBackGoods.Dispose();
                    break;
                case "OutInStore":
                    if (gvOutInStore.FocusedRowHandle < 0) return;
                    dr = gvOutInStore.GetDataRow(gvOutInStore.FocusedRowHandle);

                    OutProduct.frmOutInStore myOutInStore = new OutProduct.frmOutInStore();
                    myOutInStore.strBillID = dr["F_BillID"].ToString();
                    myOutInStore.ShowDialog();
                    myOutInStore.Dispose();
                    break;
                case "OutBackStore":
                    if (gvOutBackStore.FocusedRowHandle < 0) return;
                    dr = gvOutBackStore.GetDataRow(gvOutBackStore.FocusedRowHandle);
                    OutProduct.frmOutBackStore myOutBackStore = new OutProduct.frmOutBackStore();
                    myOutBackStore.strBillID = dr["F_BillID"].ToString();
                    myOutBackStore.ShowDialog();
                    myOutBackStore.Dispose();
                    break;
                case "OutPay":
                    if (gvOutPay.FocusedRowHandle < 0) return;
                    dr = gvOutPay.GetDataRow(gvOutPay.FocusedRowHandle);
                    OutProduct.frmOutPay myOutPay = new OutProduct.frmOutPay();
                    myOutPay.strBillID = dr["F_BillID"].ToString();
                    myOutPay.ShowDialog();
                    myOutPay.Dispose();
                    break;

            }
        }


        private void frmWakeCenter_Shown(object sender, EventArgs e)
        {
            GetApplyStock();
        }

        private void gvApplyStock_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("ApplyStock");
        }

        private void gvStockOrder_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("StockOrder");
        }

        private void gvStockIn_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("StockIn");
        }

        private void gvPay_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("StockPay");
        }

        private void gvStockBack_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("StockBack");
        }

        private void gcAskPrice_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("AskPrice");
        }

        private void gvSellPrice_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("SellPrice");
        }

        private void gvSellOrder_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("SellOrder");
        }

        private void gvSellPre_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("SellPre");
        }

        private void gvSellOut_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("SellOut");
        }

        private void gvAccept_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("Accept");
        }

        private void gvSellBack_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("SellBack");
        }

        private void gvCheck_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("Check");
        }

        private void gvExchange_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("Exchange");
        }

        private void gvInstall_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("install");
        }

        private void gvOtherIn_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("OtherIn");
        }

        private void gvOtherOut_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("OtherOut");
        }

        private void gvProductPlan_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("ProductPlan");
        }

        private void gvTask_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("Task");
        }

        private void gvProductStatus_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("ProductStatus");
        }

        private void gvDrawGoods_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("DrawGoods");
        }

        private void gvPatchGoods_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("PatchGoods");
        }

        private void gvBackGoods_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("BackGoods");
        }

        private void gvProductIn_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("ProductIn");
        }

        private void gvOutBill_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("OutBill");
        }

        private void gvOutDrawGoods_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("OutDrawGoods");
        }

        private void gvOutBackGoods_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("OutBackGoods");
        }

        private void gvOutInStore_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("OutInStore");
        }

        private void gvOutBackStore_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("OutBackStore");
        }

        private void gvOutPay_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("OutPay");
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("StockOrder1");
        }

        private void gvSellOrder1_DoubleClick(object sender, EventArgs e)
        {
            OpenBill("SellOrder1");
        }
    }
}

