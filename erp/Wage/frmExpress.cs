using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Wage
{
    public partial class frmExpress : BaseClass.frmBase
    {
        public DataTable dtField = null;
        public string strExpress = "";

        public frmExpress()
        {
            InitializeComponent();
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sbOk_Click(object sender, EventArgs e)
        {
            if (meFormula.Text != "")
                strExpress = Explained();
            else
                strExpress = "";
            this.DialogResult = DialogResult.OK;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            this.meFormula.Text =  this.meFormula.Text + (sender as SimpleButton).Text;
        }

        private void FillField()
        {
            foreach (DataRow dr in dtField.Rows)
            {
                if (dr.RowState == DataRowState.Deleted) continue;
                TreeNode Node = new TreeNode();
                Node.Text = dr["F_WageItem"].ToString();
                Node.Tag = dr["F_HideItem"].ToString();
                tvField.Nodes.Add(Node);
            }
        }

        private string Explained()
        {
            string sExp = this.meFormula.Text;

            foreach (TreeNode Node in tvField.Nodes)
            {
                if (sExp.IndexOf(Node.Text) >= 0)
                {
                    sExp = sExp.Replace(Node.Text, Node.Tag.ToString());
                }
            }

            if (sExp.IndexOf("如果完") >= 0)
            {
                sExp = sExp.Replace("如果完", "end");
            }

            if (sExp.IndexOf("如果") >= 0)
            {
                sExp = sExp.Replace("如果", "case when");
            }

            if (sExp.IndexOf("就") >= 0)
            {
                sExp = sExp.Replace("就", "then");
            }

            if (sExp.IndexOf("否则") >= 0)
            {
                sExp = sExp.Replace("否则", "else");
            }

            if (sExp.IndexOf("空值完") >= 0)
            {
                sExp = sExp.Replace("空值完", ")");
            }

            if (sExp.IndexOf("空值") >= 0)
            {
                sExp = sExp.Replace("空值", "isnull(");
            }

            if (sExp.IndexOf("则") >= 0)
            {
                sExp = sExp.Replace("则", ",");
            }

            if (sExp.IndexOf("且") >= 0)
            {
                sExp = sExp.Replace("且", "and");
            }

            if (sExp.IndexOf("或") >= 0)
            {
                sExp = sExp.Replace("或", "or");
            }

            if (sExp.IndexOf("非") >= 0)
            {
                sExp = sExp.Replace("非", "not");
            }

            return sExp;
        }

        private void frmExpress_Load(object sender, EventArgs e)
        {
            FillField();
        }


        private void tvField_DoubleClick(object sender, EventArgs e)
        {
            if (tvField.SelectedNode == null) return;
            Clipboard.SetText(tvField.SelectedNode.Text);
            this.meFormula.Paste();
            Clipboard.Clear();
        }

    }
}

