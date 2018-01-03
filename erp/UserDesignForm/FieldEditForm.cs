using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UserDesignForm
{
    public partial class FieldEditForm : BaseClass.frmBase
    {
        public FieldEditForm()
        {
            InitializeComponent();
            if (this.DesignMode == false)
            {
                FillTable();
                
            }
        }

        private void FillTable()
        {
            string sModule = "";
            TreeNode cNode = null;
            TreeNode Node = tvTable.Nodes.Add("管理系统");
            string strSQL = @"select F_Module,F_TableText,F_TableName from t_SysField
                              where F_Module IS NOT NULL
                              group by F_Module,F_TableText,F_TableName";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (sModule != dr["F_Module"].ToString())
                {
                    cNode = Node.Nodes.Add(dr["F_Module"].ToString());
                    sModule = dr["F_Module"].ToString();
                }
               
                TreeNode ccNode = cNode.Nodes.Add(dr["F_TableText"].ToString() + "(" + dr["F_TableName"].ToString() + ")");
                ccNode.Tag = dr["F_TableName"];
                

            }
        }

        private void RefreshField(string strTable)
        {
            string strSQL = "select * from t_SysField where F_TableName = '"+strTable+"'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gridField.DataSource = ds.Tables[0];
        }

        private void tvTable_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level != 2)
            {
                RefreshField("");
            }
            else
            {
                RefreshField(e.Node.Tag.ToString());
            }
        }

        private void BtnExpress_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmExpress F = new frmExpress();
            F.dtField = (DataTable)gridField.DataSource;
            if (viewField.GetRowCellValue(viewField.FocusedRowHandle, "F_Express") != DBNull.Value)
                F.meFormula.Text = viewField.GetRowCellValue(viewField.FocusedRowHandle, "F_Express").ToString();
            if (F.ShowDialog() == DialogResult.OK)
            {
                viewField.SetRowCellValue(viewField.FocusedRowHandle,"F_Express",F.meFormula.Text);
                viewField.SetRowCellValue(viewField.FocusedRowHandle, "F_Express1", F.strExpress);
            }
            F.Dispose();
        }

        private void AddRow(object sender, EventArgs e)
        {
            if (tvTable.SelectedNode.Level != 2) return;
            frmManaField F = new frmManaField();
            F.dtField = (DataTable)gridField.DataSource;
            F.strModuleName = tvTable.SelectedNode.Parent.Text;
            F.strTableText = tvTable.SelectedNode.Text.ToString();
            F.strTableName = tvTable.SelectedNode.Tag.ToString();
            if (F.ShowDialog() == DialogResult.OK)
            {
                RefreshField(tvTable.SelectedNode.Tag.ToString());
            }
            F.Dispose();
        }

        private void DelRow(object sender, EventArgs e)
        {
            if (viewField.FocusedRowHandle < 0) return;

            DataRow dr = viewField.GetDataRow(viewField.FocusedRowHandle);

            if (Convert.ToBoolean(dr["F_Sys"]) == true)
            {
                MessageBox.Show(this, "不能删除系统预设字段!", "提示");
                return;
            }
            if (MessageBox.Show(this, "真的要删除选定的数据列吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            string strSQL = "";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (dr["F_Type"].ToString() == "计算字段")
            {
                strSQL = "delete from t_SysField where F_TableName = '" + dr["F_TableName"].ToString() + "' and F_FieldName = '" + dr["F_FieldName"].ToString() + "'";
                if (myHelper.ExecuteSQL(strSQL) == 0)
                {
                    viewField.DeleteRow(viewField.FocusedRowHandle);
                    RefreshField(tvTable.SelectedNode.Tag.ToString());
                }
            }
            else
            {
                strSQL = "exec sp_uDropColumn '" + dr["F_TableName"].ToString() + "','" + dr["F_FieldName"].ToString() + "'";

                if (myHelper.ExecuteSQL(strSQL) == 0)
                {
                    strSQL = "delete from t_SysField where F_TableName = '" + dr["F_TableName"].ToString() + "' and F_FieldName = '" + dr["F_FieldName"].ToString() + "'";
                    if (myHelper.ExecuteSQL(strSQL) == 0)
                    {
                        viewField.DeleteRow(viewField.FocusedRowHandle);
                        RefreshField(tvTable.SelectedNode.Tag.ToString());
                    }
                }
            }
        }

        private void Edit(object sender, EventArgs e)
        {
            frmManaField F = new frmManaField();
            F.dtField = (DataTable)gridField.DataSource;
            F.ShowDialog();
            F.Dispose();
        }

        private void Save(object sender, EventArgs e)
        {
            viewField.CloseEditor();
            viewField.UpdateCurrentRow();
            DataSet ds = ((DataTable)gridField.DataSource).DataSet;

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                if (dr.RowState == DataRowState.Deleted) continue;
                if (dr["F_FieldText"] == DBNull.Value)
                {
                    MessageBox.Show("字段标识不能为空", "提示");
                    return;
                }

                //if (dr["F_FieldName"] == DBNull.Value)
                //{
                //    MessageBox.Show("字段名称不能为空","提示");
                //    return;
                //}

                //if (dr["F_Type"] == DBNull.Value)
                //{
                //    MessageBox.Show("字段类型不能为空", "提示");
                //    return;
                //}

                //dr["F_Module"] = tvTable.SelectedNode.Parent.Text;
                //dr["F_TableText"] = tvTable.SelectedNode.Text;
                //dr["F_TableName"] = tvTable.SelectedNode.Tag.ToString();
            }

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.SaveData(ds, "select * from t_SysField") >= 0)
            {
                MessageBox.Show("数据保存成功!", "提示");
                ds.AcceptChanges();
            }
        }

        private void tsClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FieldEditForm_Load(object sender, EventArgs e)
        {
            tvTable.TopNode.Expand();
        }
    }
}
