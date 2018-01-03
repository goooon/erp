using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UserReport
{
    public partial class frmUserReport : BaseClass.frmBase
    {
        public frmUserReport()
        {
            InitializeComponent();
        }

        private void tbExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FillType()
        {
            tvType.Nodes.Clear();
            TreeNode Node = tvType.Nodes.Add("所有报表");
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select F_Type from t_UserReport group by F_Type");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Node.Nodes.Add(dr["F_Type"].ToString());
            }
            ds.Dispose();
            Node.Expand();
            tvType.SelectedNode = Node;
        }

        private void RetrieveReport(string strType)
        {

            string strSQL = "";
            if (strType == "")
                strSQL = "select F_Name from t_UserReport";
            else
                strSQL = "select F_Name from t_UserReport where F_Type = '" + strType + "'";
            lvReport.Items.Clear();
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListViewItem lvItem = lvReport.Items.Add(dr["F_Name"].ToString());
                lvItem.ImageIndex = 0;
            }
            ds.Dispose();
        }

        private void frmUserReport_Load(object sender, EventArgs e)
        {
            FillType();
        }

        private void tbNew_Click(object sender, EventArgs e)
        {
            frmEditReport myEditReport = new frmEditReport();
            myEditReport.pFlag = false;
            if (myEditReport.ShowDialog() == DialogResult.OK)
                FillType();
            myEditReport.Dispose();
        }

        private void tbOpen_Click(object sender, EventArgs e)
        {
            if (lvReport.SelectedItems.Count == 0) return;
            ShowReport(lvReport.SelectedItems[0].Text);
        }

        private void tvType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvType.SelectedNode.Level == 0)
               RetrieveReport("");
            else
               RetrieveReport(tvType.SelectedNode.Text);
        }

        private void ShowReport(string strName)
        {
            if (lvReport.SelectedItems.Count == 0) return;
            frmReportEx myReportEx = new frmReportEx();
            myReportEx.Text = strName;
            myReportEx.strName = lvReport.SelectedItems[0].Text;
            myReportEx.ShowDialog();
            myReportEx.Dispose();
        }

        private void lvReport_DoubleClick(object sender, EventArgs e)
        {
            tbOpen_Click(null, null);
        }

        private void tbEdit_Click(object sender, EventArgs e)
        {
            if (lvReport.SelectedItems.Count == 0) return;
            if (tvType.SelectedNode.Level == 0)
            {
                MessageBox.Show("不能在第一级删除报表!!", "提示");
                return;
            }
            frmEditReport myEditReport = new frmEditReport();
            myEditReport.pFlag = true;
            myEditReport.strName = lvReport.SelectedItems[0].Text;
            myEditReport.txtName.Text = lvReport.SelectedItems[0].Text;
            myEditReport.cbType.Text = tvType.SelectedNode.Text;

            foreach (TreeNode Node in tvType.TopNode.Nodes)
            {
                myEditReport.cbType.Properties.Items.Add(Node.Text);
            }

            if (myEditReport.ShowDialog() == DialogResult.OK)
                FillType();
            myEditReport.Dispose();
        }

        private void tbDel_Click(object sender, EventArgs e)
        {
            if (lvReport.SelectedItems.Count == 0) return;
            if (tvType.SelectedNode.Level == 0)
            {
                MessageBox.Show("不能在第一级删除报表!!", "提示");
                return;
            }
            if (MessageBox.Show(this, "真的要删除选定报表吗?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_UserReport where F_Name = '" + lvReport.SelectedItems[0].Text + "'") == 0)
                tvType_AfterSelect(null, null);
        }
    }
}

