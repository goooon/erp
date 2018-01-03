using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class frmUGroup : Common.frmMDIChild
    {
        public frmUGroup()
        {
            InitializeComponent();
            ckRight.SendToBack();
            panelControl1.SendToBack();
        }

        /// <summary>
        /// 树结点状态
        /// </summary>
        /// <param name="e"></param>
        private void SetNodeCheck(TreeNode e)
        {
            if (e.Level == 1)
            {
                bool bFlag = false;
                TreeNode pNode;
                pNode = e.Parent;
                foreach (TreeNode Node in pNode.Nodes)
                {
                    if (Node.Checked == true)
                        bFlag = true;
                }

                if (bFlag == true)
                    pNode.Checked = true;
                else
                    pNode.Checked = false;
            }

        }

        /// <summary>
        /// 填充菜单
        /// </summary>
        private void FillMenu()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_Right");

            DataTable dt = ds.Tables[0];

            DataRow[] drParent = dt.Select("F_PID = ''");

            foreach (DataRow dr in drParent)
            {
                TreeNode Node = tvRight.Nodes.Add(dr["F_Name"].ToString());
                Node.Tag = dr["F_ID"].ToString();
                DataRow[] drChild = dt.Select("F_PID = '" + dr["F_ID"].ToString() + "'");
                foreach (DataRow dr1 in drChild)
                {
                    TreeNode cNode = Node.Nodes.Add(dr1["F_Name"].ToString());
                    cNode.Tag = dr1["F_ID"].ToString();
                }
            }

            ds.Dispose();
        }

        private void DataBind()
        {

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_UserGroup");
            lbGroup.DisplayMember = "F_Group";
            lbGroup.ValueMember = "F_Group";
            lbGroup.DataSource = ds.Tables[0].DefaultView;
        }

        private void frmUGroup_Load(object sender, EventArgs e)
        {
            DataBind();
            FillMenu();
        }

        private void btExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmEditUGroup myUGroup = new frmEditUGroup();
            myUGroup.strGroup = "";
            if (myUGroup.ShowDialog() == DialogResult.OK)
                DataBind();
            myUGroup.Dispose();
        }

        private void btEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lbGroup.SelectedIndex < 0) return;
            frmEditUGroup myUGroup = new frmEditUGroup();
            myUGroup.strGroup = lbGroup.SelectedValue.ToString();
            myUGroup.textEdit1.Text = lbGroup.SelectedValue.ToString();
            if (myUGroup.ShowDialog() == DialogResult.OK)
                DataBind();
            myUGroup.Dispose();
        }

        private void btDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lbGroup.SelectedIndex < 0) return;
            if (lbGroup.SelectedValue.ToString() == "超级用户")
            {
                MessageBox.Show("不能删除超级用户");
                return;
            }
            if (MessageBox.Show(this, "删除选定用户组,其对应的用户也将被删除,确定吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_UserGroup where F_Group = '" + lbGroup.SelectedValue.ToString() + "'") == 0)
                DataBind();
        }

        
        /// <summary>
        /// 设置权限
        /// </summary>
        private void FillRight()
        {
            if (lbGroup.SelectedIndex < 0) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_RightDetail where F_Group = '" + lbGroup.SelectedValue.ToString() + "' and F_Name = '可用'");
            DataTable dt = ds.Tables[0];

            foreach (TreeNode Node in tvRight.Nodes)
            {
                foreach (TreeNode cNode in Node.Nodes)
                {
                    DataRow[] drTmp = dt.Select("F_Class = '" + cNode.Text + "'");
                    if (drTmp.Length > 0)
                    {
                        cNode.Checked = Convert.ToBoolean(drTmp[0]["F_Enable"]);
                    }
                    else
                    {
                        cNode.Checked = false;
                    }
                }

            }
            ds.Dispose();
        }
        

            
        private void SetRight(DataTable dt,string strField)
        {
            if (dt.Rows.Count == 0)
            {
                ckRight.Items.Add(strField, true);
            }
            else
            {
                DataRow[] drTmp;
                drTmp = dt.Select("(F_Name = '" + strField + "') and (F_Enable = 1)");
                if (drTmp.Length > 0)
                    ckRight.Items.Add(strField, true);
                else
                    ckRight.Items.Add(strField, false);
            }
        }
          

        private void tvRight_AfterSelect(object sender, TreeViewEventArgs e)
        {
            /*
            ckRight.Items.Clear();
            if (tvRight.SelectedNode.Parent == null)
            {   
                return;
            }

            string strSQL = "select * from t_RightDetail where F_Group = '" + lbGroup.Text.ToString() + "' and F_Class = '" + tvRight.SelectedNode.Tag.ToString() + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            DataTable dt = ds.Tables[0];

            switch (tvRight.SelectedNode.Parent.Tag.ToString())
            {
                case "0":
                    SetRight(dt, "可用");
                    break;
                case "1":
                    SetRight(dt, "可用");
                    break;
                case "2":
                    SetRight(dt, "可用");
                    SetRight(dt, "新增");
                    SetRight(dt, "编辑");
                    SetRight(dt, "删除");
                    SetRight(dt, "审核");
                    SetRight(dt, "反审核");
                    SetRight(dt, "中止");
                    SetRight(dt, "反中止");
                    SetRight(dt, "打印");
                    break;
                case "3":
                    SetRight(dt, "可用");
                    break;
                case "4":
                    SetRight(dt, "可用");
                    SetRight(dt, "新增");
                    SetRight(dt, "编辑");
                    SetRight(dt, "删除");
                    SetRight(dt, "审核");
                    SetRight(dt, "反审核");
                    SetRight(dt, "打印");
                    break;
                case "5":
                    SetRight(dt, "可用");
                    break;
                case "6":
                    SetRight(dt, "可用");
                    break;
            }
             */ 
        }

        /// <summary>
        /// 授权
        /// </summary>
        private void SaveRight()
        {
            string strSQL = "select * from t_RightDetail where F_Group = '"+lbGroup.Text.ToString()+"' and F_Class = '"+tvRight.SelectedNode.Tag.ToString()+"'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            DataTable dt = ds.Tables[0];
            DataRow drField;
            int intCnt = ckRight.Items.Count;
            for (int i = 0; i < intCnt; i++)
            {
                DataRow[] dr = dt.Select("F_Name = '" + ckRight.Items[i].Value.ToString() + "'");
                if (dr.Length == 0)
                {
                    drField = dt.NewRow();
                    drField["F_Group"] = lbGroup.Text.ToString();
                    drField["F_Class"] = tvRight.SelectedNode.Tag.ToString();
                    drField["F_Name"] = ckRight.Items[i].Value.ToString();
                     if (ckRight.Items[i].CheckState == CheckState.Checked)
                        drField["F_Enable"] = true;
                    else
                        drField["F_Enable"] = false;
                    dt.Rows.Add(drField);
                }
                else
                {

                    drField = dr[0];
                    if (ckRight.Items[i].CheckState == CheckState.Checked)
                        drField["F_Enable"] = true;
                    else
                        drField["F_Enable"] = false;
                }
            }
            myHelper.SaveData(ds,strSQL);
        }

        private void frmUGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                SaveRight();
        }

        private void lbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillRight();
            /*
            if (tvRight.SelectedNode == null) return;
            if (tvRight.Nodes.Count > 0)
               tvRight_AfterSelect(null, null);
             */ 
        }


        private void btRight_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveRight();
        }

        private void tvRight_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByKeyboard ||
                e.Action == TreeViewAction.ByMouse)
            {

                if (e.Node.Level == 0)
                {
                    TreeNode pNode = e.Node;
                    bool bFlag = false;
                    if (pNode.Checked == true)
                        bFlag = true;
                    else
                        bFlag = false;

                    foreach (TreeNode Node in e.Node.Nodes)
                    {
                        Node.Checked = bFlag;
                    }
                }

            }

            if (e.Node.Level == 1)
                SetNodeCheck(e.Node);
        }

    }
}

