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
    public partial class frmSellBackList : Common.frmBillList
    {
        public frmSellBackList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 提取查询参数
        /// </summary>
        /// <returns></returns>
        protected override Hashtable GetParm3()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            parm.Add("@Check", cbCheck.SelectedIndex);
            if (DataLib.SysVar.strUGroup == "超级用户" && DataLib.SysVar.blnSaleMan == false)
                parm.Add("@BillMan", "");
            else
                parm.Add("@BillMan", DataLib.SysVar.strUID);

            return parm;
        }


        /// <summary>
        /// 新增
        /// </summary>
        protected override void New()
        {
            Sell.frmSellBack mySellBack = new Sell.frmSellBack();
            mySellBack.ShowDialog();
            mySellBack.Dispose();
            base.New();
             
        }

        /// <summary>
        /// 编辑　　
        /// </summary>
        protected override void Edit()
        {
            if (gvList.FocusedRowHandle < 0) return;
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);


            Sell.frmSellBack mySellBack = new Sell.frmSellBack();
            mySellBack.strBillID = dr["F_BillID"].ToString();
            mySellBack.ShowDialog();
            mySellBack.Dispose();
            base.Edit();
        }

        /// <summary>
        /// 删除
        /// </summary>
        protected override void Del()
        {  
            if (gvList.FocusedRowHandle < 0) return;
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            if (Convert.ToBoolean(dr["F_Check"]) == true)
            {
                MessageBox.Show(this, "不能删除已审核的单据！！", "提示");
                return;
            }
            if (MessageBox.Show(this, "真的要删除选定单据吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_SellBack where F_BillID = '"+dr["F_BillID"].ToString()+"'") == 0)
                gvList.DeleteRow(gvList.FocusedRowHandle);

            base.Del();
        }
    }
}

