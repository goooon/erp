using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Sell
{
    public partial class frmSellOrderList : Common.frmBillList
    {
        public frmSellOrderList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 提取查询参数
        /// </summary>
        /// <returns></returns>
        protected override Hashtable GetParm5()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            parm.Add("@Check", cbCheck.SelectedIndex);
            parm.Add("@CutOff", cbCutOff.SelectedIndex);
            parm.Add("@Finish", cbFinish.SelectedIndex);
            if (DataLib.SysVar.strUGroup == "超级用户" && DataLib.SysVar.blnSaleMan == false)
                parm.Add("@BillMan", "");
            else
                parm.Add("@BillMan", DataLib.SysVar.strUName);

            return parm;
        }

        /// <summary>
        /// 新增
        /// </summary>
        protected override void New()
        {
            Sell.frmSellOrder mySellOrder = new Sell.frmSellOrder();
            mySellOrder.ShowDialog();
            mySellOrder.Dispose();
            base.New();
             
        }

        /// <summary>
        /// 编辑　　
        /// </summary>
        protected override void Edit()
        {
            if (gvList.FocusedRowHandle < 0) return;
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);

            Sell.frmSellOrder mySellOrder = new Sell.frmSellOrder();
            mySellOrder.strBillID = dr["F_BillID"].ToString();
            mySellOrder.ShowDialog();
            mySellOrder.Dispose();
            base.Edit();
        }

        /// <summary>
        /// 删除
        /// </summary>
        protected override void Del()
        {
            base.Del();
            if (gvList.FocusedRowHandle < 0) return;
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            if (Convert.ToBoolean(dr["F_Check"]) == true)
            {
                MessageBox.Show(this, "不能删除已审核的单据！！", "提示");
                return;
            }
            if (MessageBox.Show(this, "真的要删除选定单据吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_SellOrder where F_BillID = '"+dr["F_BillID"].ToString()+"'") == 0)
                gvList.DeleteRow(gvList.FocusedRowHandle);

        }
    }
}

