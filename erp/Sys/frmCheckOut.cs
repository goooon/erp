using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class frmCheckOut : BaseClass.frmBase
    {
        public frmCheckOut()
        {
            InitializeComponent();
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCheckOut_Load(object sender, EventArgs e)
        {
            dtMonth.EditValue = DateTime.Today;
            //dePay.EditValue = DateTime.Today;
            //deAccept.EditValue = DateTime.Today;
        }

        /// <summary>
        /// 库存结帐
        /// </summary>
        private void StoreCheck()
        {
            string strSQL = "";
            DateTime dtValue = Convert.ToDateTime(dtMonth.EditValue);
            string strYear = dtValue.Year.ToString();
            string strMonth = dtValue.Month.ToString().PadLeft(2, '0');
            string strValue = strYear + strMonth;

            strSQL = "select top 1 * from t_StorageCheck where F_Month = '" + strValue + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);

            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("本月已结过帐!!");
                return;
            }
            ds.Dispose();

            if (MessageBox.Show(this, "真的要对本月进行库存结帐吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            dtMonth.Enabled = false;
            lbFlag.Visible = true;
            groupBox1.Update();
            try
            {
                
                ds = myHelper.GetDs("sp_noCheck '" + dtValue.ToString() + "'");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("本月存在未审核的单据");
                    frmNoCheck myNoCheck = new frmNoCheck();
                    myNoCheck.dtValue = dtValue;
                    myNoCheck.ShowDialog();
                    myNoCheck.Dispose();
                    return;
                }
                ds.Dispose();
                
                strSQL = "sp_StorageCheck '" + dtMonth.EditValue.ToString() + "'";

                if (myHelper.ExecuteSQL(strSQL) == 0)
                {
                    MessageBox.Show("结帐操作成功!!");
                }
            }
            finally
            {
                dtMonth.Enabled = true;
                lbFlag.Visible = false;
            }
        }

        /// <summary>
        /// 库存反结帐
        /// </summary>
        private void UnStoreCheck()
        {
            string strSQL = "";
            DateTime dtValue = Convert.ToDateTime(dtMonth.EditValue);
            string strYear = dtValue.Year.ToString();
            string strMonth = dtValue.Month.ToString().PadLeft(2, '0');
            string strValue = strYear + strMonth;

            strSQL = "select top 1 * from t_StorageCheck where F_Month = '" + strValue + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);

            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("本月还没进行库存结帐,不能反结帐!!");
                return;
            }

            if (MessageBox.Show(this, "真的要对本月进行库存反结帐吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            strSQL = "delete from t_StorageCheck where F_Month = '" + strValue + "'";
            if (myHelper.ExecuteSQL(strSQL) == 0)
            {
                strSQL = "delete from t_CheckMonth where F_Month = '" + strValue + "'";
                if (myHelper.ExecuteSQL(strSQL) == 0)
                    MessageBox.Show("反结帐成功!!");
            }
        }

        /// <summary>
        /// 应付款结帐
        /// </summary>
        private void PayCheck()
        {
            string strSQL = "";
            DateTime dtValue = Convert.ToDateTime("1900-1-1");
                //Convert.ToDateTime(dePay.EditValue);
            string strYear = dtValue.Year.ToString();
            string strMonth = dtValue.Month.ToString().PadLeft(2, '0');
            string strValue = strYear + strMonth;

            strSQL = "select top 1 * from t_PayCheck where F_Month = '" + strValue + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);

            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("本月已结过帐!!");
                return;
            }
            ds.Dispose();

            if (MessageBox.Show(this, "真的要对本月进行付款结帐吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            //dePay.Enabled = false;
            //lbPay.Visible = true;
            //groupBox2.Update();
            try
            {
                /*
                ds = myHelper.GetDs("sp_noPayCheck '" + dtValue.ToString() + "'");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("本月存在未审核的单据");
                    frmNoCheck myNoCheck = new frmNoCheck();
                    myNoCheck.dtValue = dtValue;
                    myNoCheck.ShowDialog();
                    myNoCheck.Dispose();
                    return;
                }
                ds.Dispose();
                */
               // strSQL = "sp_PayCheck '" + dePay.EditValue.ToString() + "'";
                strSQL = "";
                if (myHelper.ExecuteSQL(strSQL) == 0)
                {
                    MessageBox.Show("结帐操作成功!!");
                }
            }
            finally
            {
                //dePay.Enabled = true;
                //lbPay.Visible = false;
            }
        }

        /// <summary>
        /// 应收款结帐
        /// </summary>
        private void AcceptCheck()
        {
            string strSQL = "";
            DateTime dtValue = Convert.ToDateTime("1900-1-1");
            //DateTime dtValue = Convert.ToDateTime(deAccept.EditValue);
            string strYear = dtValue.Year.ToString();
            string strMonth = dtValue.Month.ToString().PadLeft(2, '0');
            string strValue = strYear + strMonth;

            strSQL = "select top 1 * from t_AcceptCheck where F_Month = '" + strValue + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);

            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("本月已结过帐!!");
                return;
            }
            ds.Dispose();

            if (MessageBox.Show(this, "真的要对本月进行收款结帐吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            //deAccept.Enabled = false;
            //lbAccept.Visible = true;
            //groupBox3.Update();
            try
            {
                /*
                ds = myHelper.GetDs("sp_noAcceptCheck '" + dtValue.ToString() + "'");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("本月存在未审核的单据");
                    frmNoCheck myNoCheck = new frmNoCheck();
                    myNoCheck.dtValue = dtValue;
                    myNoCheck.ShowDialog();
                    myNoCheck.Dispose();
                    return;
                }
                ds.Dispose();
                */
                //strSQL = "sp_AcceptCheck '" + dePay.EditValue.ToString() + "'";
                strSQL = "";
                if (myHelper.ExecuteSQL(strSQL) == 0)
                {
                    MessageBox.Show("结帐操作成功!!");
                }
            }
            finally
            {
                //deAccept.Enabled = true;
                //lbAccept.Visible = false;
            }
        }

        private void sbAcceptCheck_Click(object sender, EventArgs e)
        {
            AcceptCheck();
        }

        private void sbPayCheck_Click(object sender, EventArgs e)
        {
            PayCheck();
        }

        private void sbStoreCheck_Click(object sender, EventArgs e)
        {
            StoreCheck();
        }

        private void btnUnStorageCheck_Click(object sender, EventArgs e)
        {
            UnStoreCheck();
        }
    }
}

