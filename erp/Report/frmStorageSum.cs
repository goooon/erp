using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Report
{
    public partial class frmStorageSum : Common.frmReport
    {
        public frmStorageSum()
        {
            InitializeComponent();
        }

        protected override Hashtable GetParm()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            parm.Add("@sKind", cbType.Text);
            return parm;
        }

        protected override Hashtable GetParm1()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            parm.Add("@sKind", cbType.Text);
            parm.Add("@Value", strValue);
            return parm;
        }

        protected override void SelectIndexChange()
        {
            if (gvReport.FocusedRowHandle < 0)
            {
                strValue = "";
            }
            else
            {
                if (rgOption.SelectedIndex == 1)
                {
                    DataRow dr = gvReport.GetDataRow(gvReport.FocusedRowHandle);
                    strValue = dr["F_ItemID"].ToString()+dr["F_StorageID"].ToString();
                }
            }

            base.SelectIndexChange();
        }

        private void frmStorageSum_Load(object sender, EventArgs e)
        {

        }

        private void sbRefresh_Click(object sender, EventArgs e)
        {

        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected override void OnViewDbClick(object sender, EventArgs e)
        {
            base.OnViewDbClick(sender, e);
            //ShowBill();
        }

        private void ShowBill()
        {
            if (gvReport.FocusedRowHandle < 0) return;

            DataRow dr = gvReport.GetDataRow(gvReport.FocusedRowHandle);
            string strTag = dr["F_Type"].ToString();
            switch (strTag)
            {
                
                case "盘点":
                    Storage.frmCheck myCheck = new Storage.frmCheck();
                    myCheck.strBillID = dr["F_BillID"].ToString();
                    myCheck.ShowDialog();
                    myCheck.Dispose();
                    break;
                case "组装":
                    Storage.frmInstall myInstall = new Storage.frmInstall();
                    myInstall.strBillID = dr["F_BillID"].ToString();
                    myInstall.ShowDialog();
                    myInstall.Dispose();
                    break;
                case "拆卸":
                    Storage.frmInstall myInstall1 = new Storage.frmInstall();
                    myInstall1.strBillID = dr["F_BillID"].ToString();
                    myInstall1.ShowDialog();
                    myInstall1.Dispose();
                    break;
                case "调入":
                    Storage.frmExchange myExchange = new Storage.frmExchange();
                    myExchange.strBillID = dr["F_BillID"].ToString();
                    myExchange.ShowDialog();
                    myExchange.Dispose();
                    break;
                case "调出":
                    Storage.frmExchange myExchange1 = new Storage.frmExchange();
                    myExchange1.strBillID = dr["F_BillID"].ToString();
                    myExchange1.ShowDialog();
                    myExchange1.Dispose();
                    break;
                default :
                    Storage.frmOtherIn myOtherIn = new Storage.frmOtherIn();
                    myOtherIn.strBillID = dr["F_BillID"].ToString();
                    myOtherIn.ShowDialog();
                    myOtherIn.Dispose();
                    break;
            }

        }
    }
}

