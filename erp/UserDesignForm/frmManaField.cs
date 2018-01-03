using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UserDesignForm
{
    public partial class frmManaField : BaseClass.frmBase
    {
        public DataTable dtField = null;
        public string strModuleName;
        public string strTableName;
        public string strTableText;
        public string strExpress = "";


        public frmManaField()
        {
            InitializeComponent();
        }

        private void btnSel_Click(object sender, EventArgs e)
        {

        }

        private bool AddField()
        {
            if (txtFielText.Text == "")
            {
                MessageBox.Show("字段标识不能为空!", "提示");
                txtFielText.Focus();
                return false;
            }

            if (txtField.Text == "")
            {
                MessageBox.Show("字段名称不能为空!", "提示");
                txtField.Focus();
                return false;
            }

            if (cbType.Text == "")
            {
                MessageBox.Show("字段类型不能为空!", "提示");
                cbType.Focus();
                return false;
            }

            if (richTextBox2.Text != "")
            {
                if (txtDispField.Text == "")
                {
                    MessageBox.Show("显示字段不能为空!", "提示");
                    txtDispField.Focus();
                    return false;
                }

                if (txtValueField.Text == "")
                {
                    MessageBox.Show("值字段不能为空!", "提示");
                    txtValueField.Focus();
                    return false;
                }
            }

            string sType = cbType.Text;
            string sLen = msLength.Text;

            string sTypeName = "";

            switch (sType)
            {
                case "字符型":
                    sTypeName = "varchar";
                    break;
                case "整数":
                    sTypeName = "int";
                    break;
                case "浮点数":
                    sTypeName = "float";
                    break;
                case "布尔值":
                    sTypeName = "float";
                    break;
                case "日期":
                    sTypeName = "datetime";
                    break;
                case "文本":
                    sTypeName = "ntext";
                    break;
            }

            if (sTypeName == "varchar")
                sTypeName = sTypeName + "(" + sLen + ")";

            if (sType == "计算字段")
            {
                AddOtherField();
            }
            else
            {
                string strNull = "not null";
                if (ckNull.Checked == true) strNull = "null";
                string strSQL = "alter table " + strTableName + " add " + txtField.Text + " " + sTypeName + " default('" + txtDefault.Text + "') " + strNull;

                DataLib.DataHelper myHelper = new DataLib.DataHelper();
                if (myHelper.ExecuteSQL(strSQL) == 0)
                {
                    AddOtherField();
                }
            }
            return true;


        }

        private void AddOtherField()
        {
            int iCheck = 0;
            if (ckNull.Checked == true) iCheck = 1;
            string strSQL = string.Format("insert into t_SysField values('{0}','{1}','{2}','{3}','{4}','{5}',{6},'{7}','{8}','{9}',{10},{11},'{12}','{13}','{14}')", strModuleName, strTableText, strTableName, txtFielText.Text, txtField.Text, cbType.Text, msLength.Text, txtDefault.Text, richTextBox1.Text, strExpress,iCheck.ToString(), 0,richTextBox2.Text,txtDispField.Text,txtValueField.Text);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            myHelper.ExecuteSQL(strSQL);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (AddField() == true)
               this.DialogResult = DialogResult.OK;
        }

        private void btnSel_Click_1(object sender, EventArgs e)
        {
            frmExpress F = new frmExpress();
            F.dtField = this.dtField;
            F.meFormula.Text = richTextBox1.Text;
            if (F.ShowDialog() == DialogResult.OK)
            {
                this.strExpress = F.strExpress;
                richTextBox1.Text = F.meFormula.Text;
            }
            F.Dispose();
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbType.Text == "计算字段")
            {
                richTextBox1.Enabled = true;
                btnSel.Enabled = true;
            }
            else
            {
                richTextBox1.Text = "";
                richTextBox1.Enabled = false;
                btnSel.Enabled = false;
            }
        }
    }
}
