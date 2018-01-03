using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class frmEditDetailRight : BaseClass.frmBase
    {
        private bool blnEdit = false;
        public string strUser = "";
        public string strField = "";
        public string strModule = "";
        public DevExpress.XtraGrid.Views.Grid.GridView gvGrid;

        public frmEditDetailRight()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 编辑权限
        /// </summary>
        /// <param name="strZH"></param>
        /// <param name="strField"></param>
        public void Edit(string strZH,string strField)
        {
            textBox1.Text = strZH;
            textBox2.Text = strField;
            blnEdit = true;
        }

        /// <summary>
        /// 保存明细权限
        /// </summary>
        public void Save()
        {
            string strSQL = "";

            if (textBox1.Text == "")
            {
                MessageBox.Show(this, "中文注释不能为空!!", "提示");
                textBox1.Focus();
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show(this, "字段名称不能为空!!", "提示");
                textBox2.Focus();
                return;
            }

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            int intCnt = gvGrid.RowCount;
            for(int i = 0;i < intCnt; i++)
            {
                DataRow dr = gvGrid.GetDataRow(i);
                
                strSQL = "insert into t_DetailRight(F_UID,F_Module,F_FieldCH,F_Field,F_Visible) values('" + dr["F_ID"].ToString() + "','" + strModule + "','" + textBox1.Text + "','" + textBox2.Text + "',0)";
                myHelper.ExecuteSQL(strSQL);
            }
            //if (blnEdit == false)
            //{
            //    strSQL = "insert into t_DetailRight(F_UID,F_Module,F_FieldCH,F_Field,F_Visible) values('" + strUser + "','" +strModule + "','" + textBox1.Text + "','" + textBox2.Text + "',0)";
            //}
            //else
            //{
            //    strSQL = "update t_DetailRight set F_FieldCH = '"+textBox1.Text+"',F_Field = '"+textBox2.Text+"' where F_UID = '"+strUser+"' and F_Field = '"+strField+"' and F_Module = '"+strModule+"'";
            //}

             Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

