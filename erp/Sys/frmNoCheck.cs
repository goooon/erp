using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class frmNoCheck : BaseClass.frmBase
    {
        public DateTime dtValue;
        public frmNoCheck()
        {
            InitializeComponent();
        }

        private void DataBind()
        {
            string strSQL = "sp_noCheck '" + dtValue.ToString() + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gcMain.DataSource = ds.Tables[0].DefaultView;
        }

        private void sbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmNoCheck_Shown(object sender, EventArgs e)
        {
            DataBind();
        }

        private void ShowBill()
        {
            if (gvMain.FocusedRowHandle < 0) return;

            DataRow dr = gvMain.GetDataRow(gvMain.FocusedRowHandle);
            string strTag = dr["F_Tag"].ToString();
            switch (strTag)
            {
                case "采购进货单":           
                    Stock.frmStockIn myStockIn = new Stock.frmStockIn();
                    myStockIn.strBillID = dr["F_BillID"].ToString();
                    myStockIn.ShowDialog();
                    myStockIn.Dispose();
                    break;
                case "采购退货单":
                    Stock.frmStockBack myStockBack = new Stock.frmStockBack();
                    myStockBack.strBillID = dr["F_BillID"].ToString();
                    myStockBack.ShowDialog();
                    myStockBack.Dispose();
                    break;
                case "销售出仓单":
                    Sell.frmSellOut mySellOut = new Sell.frmSellOut();
                    mySellOut.strBillID = dr["F_BillID"].ToString();
                    mySellOut.ShowDialog();
                    mySellOut.Dispose();
                    break;
                case "销售退货单":
                    Sell.frmSellBack mySellBack = new Sell.frmSellBack();
                    mySellBack.strBillID = dr["F_BillID"].ToString();
                    mySellBack.ShowDialog();
                    mySellBack.Dispose();
                    break;
                case "盘点单":
                    Storage.frmCheck myCheck = new Storage.frmCheck();
                    myCheck.strBillID = dr["F_BillID"].ToString();
                    myCheck.ShowDialog();
                    myCheck.Dispose();
                    break;
                case "拆装单":
                    Storage.frmInstall myInstall = new Storage.frmInstall();
                    myInstall.strBillID = dr["F_BillID"].ToString();
                    myInstall.ShowDialog();
                    myInstall.Dispose();
                    break;
                case "调拔单":
                    Storage.frmExchange myExchange = new Storage.frmExchange();
                    myExchange.strBillID = dr["F_BillID"].ToString();
                    myExchange.ShowDialog();
                    myExchange.Dispose();
                    break;
                case "领料单":
                    Product.frmDrawGoods myDrawGoods = new Product.frmDrawGoods();
                    myDrawGoods.strBillID = dr["F_BillID"].ToString();
                    myDrawGoods.ShowDialog();
                    myDrawGoods.Dispose();
                    break;
                case "补料单":
                    Product.frmPatchGoods myPatchGoods = new Product.frmPatchGoods();
                    myPatchGoods.strBillID = dr["F_BillID"].ToString();
                    myPatchGoods.ShowDialog();
                    myPatchGoods.Dispose();
                    break;
                case "退料单":
                    Product.frmBackGoods myBackGoods = new Product.frmBackGoods();
                    myBackGoods.strBillID = dr["F_BillID"].ToString();
                    myBackGoods.ShowDialog();
                    myBackGoods.Dispose();
                    break;
                case "产品进仓单":
                    Product.frmProductIn myProductIn = new Product.frmProductIn();
                    myProductIn.strBillID = dr["F_BillID"].ToString();
                    myProductIn.ShowDialog();
                    myProductIn.Dispose();
                    break;
                case "其它进仓单":
                    Storage.frmOtherIn myOtherIn = new Storage.frmOtherIn();
                    myOtherIn.strBillID = dr["F_BillID"].ToString();
                    myOtherIn.ShowDialog();
                    myOtherIn.Dispose();
                    break;
                case "其它出仓单":
                    Storage.frmOtherOut myOtherOut = new Storage.frmOtherOut();
                    myOtherOut.strBillID = dr["F_BillID"].ToString();
                    myOtherOut.ShowDialog();
                    myOtherOut.Dispose();
                    break;
            }
            DataBind();

        }

        private void sbOpen_Click(object sender, EventArgs e)
        {
            ShowBill();
        }

        private void gvMain_DoubleClick(object sender, EventArgs e)
        {
            ShowBill();
        }
    }
}

