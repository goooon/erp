using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Storage
{
    public partial class frmOtherInOutList : Common.frmBillList
    {
        public int intTag = 0;
        public string strSelectValue = "初始化数据";
        public frmOtherInOutList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 参数
        /// </summary>
        /// <returns></returns>
        protected override Hashtable GetParm3()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Value", strSelectValue);
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            parm.Add("@Check", cbCheck.SelectedIndex);
            return parm;
        }

        protected override bool TestNew()
        {
            string sTag = "";
            if (intTag == 0)
                sTag = "frmOtherInList";
            else
                sTag = "frmOtherOutList";

            if (TestRight("新增", sTag) == false) return false;
            return true;
        }

        protected override bool TestEdit()
        {
            string sTag = "";
            if (intTag == 0)
                sTag = "frmOtherInList";
            else
                sTag = "frmOtherOutList";

            if (TestRight("编辑", sTag) == false) return false;
            return true;
        }

        protected override bool TestDel()
        {
            string sTag = "";
            if (intTag == 0)
                sTag = "frmOtherInList";
            else
                sTag = "frmOtherOutList";


            if (TestRight("删除", sTag) == false) return false;
            return true;
        }

        protected override int BindData()
        {
            if (base.BindData() == 0)
            {
                string sTag = "";
                if (intTag == 0)
                    sTag = "frmOtherInList";
                else
                    sTag = "frmOtherOutList";

                DataLib.SysVar.TestColumnRight(gvList, sTag);
                return 0;
            }
            else
                return -1;
            
        }

        /// <summary>
        /// 新增
        /// </summary>
        protected override void New()
        {

            if (intTag == 0)
            {
                Storage.frmOtherIn myOtherIn = new Storage.frmOtherIn();
                myOtherIn.strSelectValue = this.strSelectValue;
                myOtherIn.ShowDialog();
                myOtherIn.Dispose();
            }
            else
            {
                Storage.frmOtherOut myOtherOut = new Storage.frmOtherOut();
                myOtherOut.strSelectValue = this.strSelectValue;
                myOtherOut.ShowDialog();
                myOtherOut.Dispose();
            }
            base.New();
              
        }

        /// <summary>
        /// 编辑　　
        /// </summary>
        protected override void Edit()
        {
            if (gvList.FocusedRowHandle < 0) return;
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);

            if (intTag == 0)
            {
                Storage.frmOtherIn myOtherIn = new Storage.frmOtherIn();
                myOtherIn.strBillID = dr["F_BillID"].ToString();
                myOtherIn.strSelectValue = this.strSelectValue;
                myOtherIn.ShowDialog();
                myOtherIn.Dispose();
            }
            else
            {
                Storage.frmOtherOut myOtherOut = new Storage.frmOtherOut();
                myOtherOut.strBillID = dr["F_BillID"].ToString();
                myOtherOut.strSelectValue = this.strSelectValue;
                myOtherOut.ShowDialog();
                myOtherOut.Dispose();
            }
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
            if (myHelper.ExecuteSQL("delete from t_Other where F_BillID = '"+dr["F_BillID"].ToString()+"'") == 0)
                gvList.DeleteRow(gvList.FocusedRowHandle);

        }

        private void frmOtherInOutList_Load(object sender, EventArgs e)
        {
            if (intTag == 0)
            {
                //this.Text = "其它进仓列表";
                this.BillTag = "frmOtherInList";

                cbControl1.EditLabel = "入库类型";
                cbControl1.AddItem("采购进货入库");
                cbControl1.AddItem("销售退货入库");
                cbControl1.AddItem("生产退料入库");
                cbControl1.AddItem("生产完工入库");
                cbControl1.AddItem("委外退料入库");
                cbControl1.AddItem("委外完工入库");
                cbControl1.AddItem("其它入库");
            }
            else
            {
                //this.Text = "其它出仓列表";
                this.BillTag = "frmOtherOutList";

                cbControl1.EditLabel = "出库类型";
                cbControl1.AddItem("采购退货出库");
                cbControl1.AddItem("销售发货出库");
                cbControl1.AddItem("生产领料出库");
                cbControl1.AddItem("生产补料出库");
                cbControl1.AddItem("委外领料出库");
                cbControl1.AddItem("委外退货出库");
                cbControl1.AddItem("零售出库");
                cbControl1.AddItem("业务出库");
                cbControl1.AddItem("代理商出库");
                cbControl1.AddItem("其它出库");
                
            }
            cbControl1.SetValue(strSelectValue);
            this.Text = this.strSelectValue;
        }

        private void cbControl1_SelectIndexChange(object sender, EventArgs e)
        {
            this.strSelectValue = cbControl1.GetValue().ToString();
            BindData();
        }
    }
}

