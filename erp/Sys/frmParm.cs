using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class frmParm : BaseClass.frmBase
    {
        public frmParm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBind()
        {
            string strSQL = "select * from t_Parm";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            checkBox1.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N1"]);
            checkBox2.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N2"]);
            checkBox3.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N3"]);
           
            checkBox4.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N8"]);
            checkBox5.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N9"]);
            checkBox6.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N10"]);
            checkBox7.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N11"]);
            checkBox8.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N12"]);
            checkBox10.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N13"]);
            checkBox11.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N14"]);
            checkBox9.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_NeedPrice"]);
            checkBox12.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N15"]);
            cbDate.SelectedIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["F_C1"]);
            textEdit1.EditValue = ds.Tables[0].Rows[0]["F_Debit1"];
            textEdit2.EditValue = ds.Tables[0].Rows[0]["F_Credit1"];
            textEdit3.EditValue = ds.Tables[0].Rows[0]["F_Credit2"];
            textEdit4.EditValue = ds.Tables[0].Rows[0]["F_Debit2"];
            textEdit5.EditValue = ds.Tables[0].Rows[0]["F_Credit3"];
            textEdit6.EditValue = ds.Tables[0].Rows[0]["F_Debit3"];
            textEdit7.EditValue = ds.Tables[0].Rows[0]["F_Credit4"];
            textEdit8.EditValue = ds.Tables[0].Rows[0]["F_Debit4"];
            textEdit9.EditValue = ds.Tables[0].Rows[0]["F_Credit5"];
            textEdit10.EditValue = ds.Tables[0].Rows[0]["F_Debit5"];
            textEdit11.EditValue = ds.Tables[0].Rows[0]["F_Credit6"];
            textEdit12.EditValue = ds.Tables[0].Rows[0]["F_Debit6"];
            textEdit13.EditValue = ds.Tables[0].Rows[0]["F_Credit7"];
            textEdit14.EditValue = ds.Tables[0].Rows[0]["F_Debit7"];
            comboBoxEdit1.Text = ds.Tables[0].Rows[0]["F_Type1"].ToString();
            comboBoxEdit2.Text = ds.Tables[0].Rows[0]["F_Type2"].ToString();
            comboBoxEdit3.Text = ds.Tables[0].Rows[0]["F_Type3"].ToString();
            spinEdit1.Value = Convert.ToDecimal(ds.Tables[0].Rows[0]["F_C2"]);
            spinEdit2.Value = Convert.ToDecimal(ds.Tables[0].Rows[0]["F_C3"]);
            spinEdit3.Value = Convert.ToDecimal(ds.Tables[0].Rows[0]["F_C4"]);
            spinEdit3.Enabled = checkBox8.Checked;
            spinEdit4.Value = Convert.ToDecimal(ds.Tables[0].Rows[0]["F_C5"]);
            spinEdit5.Value = Convert.ToDecimal(ds.Tables[0].Rows[0]["F_C6"]);
            spinEdit6.Value = Convert.ToDecimal(ds.Tables[0].Rows[0]["F_C7"]);
            textEdit15.Text = ds.Tables[0].Rows[0]["F_OAAdr"].ToString();

            //采购
            checkBox13.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N16"]);
            checkBox14.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N17"]);
            checkBox15.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N18"]);
            checkBox16.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N19"]);
            checkBox17.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N20"]);

            //销售
            checkBox18.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N21"]);
            checkBox19.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N22"]);
            checkBox20.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N23"]);
            checkBox21.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N24"]);
            checkBox22.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N25"]);
            checkBox23.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N26"]);

            //仓库
            checkBox29.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N27"]);
            checkBox28.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N28"]);
            checkBox27.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N29"]);
            checkBox26.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N30"]);

            //生产
            checkBox31.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N31"]);
            checkBox30.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N32"]);
            checkBox25.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N33"]);
            checkBox24.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N34"]);
            checkBox32.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N35"]);
            checkBox33.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N36"]);
            checkBox34.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N37"]);

            //委外
            checkBox41.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N38"]);
            checkBox40.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N39"]);
            checkBox39.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N40"]);
            checkBox38.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N41"]);
            checkBox37.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N42"]);
            checkBox36.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N43"]);


            checkBox35.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_N44"]);
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 提取科目代码
        /// </summary>
        /// <returns></returns>
        private string GetSubject()
        {
            string strSubject = "";
            Finance.frmSubject mySubject = new Finance.frmSubject();
            mySubject.bFlag = true;
            if (mySubject.ShowDialog() == DialogResult.OK)
                strSubject = mySubject.GetSubject();
            mySubject.Dispose();
            return strSubject;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbOK_Click(object sender, EventArgs e)
        {
            string strSQL = "select * from t_Parm";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            DataRow dr = ds.Tables[0].Rows[0];
            dr.BeginEdit();
            dr["F_N1"] = checkBox1.Checked;
            dr["F_N2"] = checkBox2.Checked;
            dr["F_N3"] = checkBox3.Checked;
            dr["F_N8"] = checkBox4.Checked;
            dr["F_N9"] = checkBox5.Checked;
            dr["F_N10"] = checkBox6.Checked;
            dr["F_N11"] = checkBox7.Checked;
            dr["F_N12"] = checkBox8.Checked;
            dr["F_N13"] = checkBox10.Checked;
            dr["F_N14"] = checkBox11.Checked;
            dr["F_N15"] = checkBox12.Checked;
            dr["F_NeedPrice"] = checkBox9.Checked;
            dr["F_C1"] = cbDate.SelectedIndex;
            dr["F_Debit1"] = textEdit1.Text;
            dr["F_Credit1"] = textEdit2.Text;

            dr["F_Debit2"] = textEdit4.Text;
            dr["F_Credit2"] = textEdit3.Text;

            dr["F_Debit3"] = textEdit6.Text;
            dr["F_Credit3"] = textEdit5.Text;

            dr["F_Debit4"] = textEdit8.Text;
            dr["F_Credit4"] = textEdit7.Text;

            dr["F_Debit5"] = textEdit10.Text;
            dr["F_Credit6"] = textEdit9.Text;

            dr["F_Debit6"] = textEdit12.Text;
            dr["F_Credit6"] = textEdit11.Text;

            dr["F_Debit7"] = textEdit14.Text;

            dr["F_Credit7"] = textEdit13.Text;

            dr["F_Type1"] = comboBoxEdit1.Text;
            dr["F_Type2"] = comboBoxEdit2.Text;
            dr["F_Type3"] = comboBoxEdit3.Text;
            dr["F_C2"] = spinEdit1.Value;
            dr["F_C3"] = spinEdit2.Value;
            dr["F_C4"] = spinEdit3.Value;
            dr["F_C5"] = spinEdit4.Value;
            dr["F_C6"] = spinEdit5.Value;
            dr["F_C7"] = spinEdit6.Value;
            dr["F_OAAdr"] = textEdit15.Text;




            //采购
            dr["F_N16"] = checkBox13.Checked;
            dr["F_N17"] = checkBox14.Checked;
            dr["F_N18"] = checkBox15.Checked;
            dr["F_N19"] = checkBox16.Checked;
            dr["F_N20"] = checkBox17.Checked;

            //销售
            dr["F_N21"] = checkBox18.Checked;
            dr["F_N22"] = checkBox19.Checked;
            dr["F_N23"] = checkBox20.Checked;
            dr["F_N24"] = checkBox21.Checked;
            dr["F_N25"] = checkBox22.Checked;
            dr["F_N26"] = checkBox23.Checked;

            //仓库
            dr["F_N27"] = checkBox29.Checked;
            dr["F_N28"] = checkBox28.Checked;
            dr["F_N29"] = checkBox27.Checked;
            dr["F_N30"] = checkBox26.Checked;


            //生产
            dr["F_N31"] = checkBox31.Checked;
            dr["F_N32"] = checkBox30.Checked;
            dr["F_N33"] = checkBox25.Checked;
            dr["F_N34"] = checkBox24.Checked;
            dr["F_N35"] = checkBox32.Checked;
            dr["F_N36"] = checkBox33.Checked;
            dr["F_N37"] = checkBox34.Checked;

            //委外
            dr["F_N38"] = checkBox41.Checked;
            dr["F_N39"] = checkBox40.Checked;
            dr["F_N40"] = checkBox39.Checked;
            dr["F_N41"] = checkBox38.Checked;
            dr["F_N42"] = checkBox37.Checked;
            dr["F_N43"] = checkBox36.Checked;


            dr["F_N44"] = checkBox35.Checked;

            dr.EndEdit();
            if (myHelper.SaveData(ds, strSQL) == 0)
               this.DialogResult = DialogResult.OK;
        }

        private void frmParm_Load(object sender, EventArgs e)
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select F_Use from t_CompanyInfo");
            if (Convert.ToBoolean(ds.Tables[0].Rows[0][0]) == true)
            {
                checkBox6.Enabled = false;
            }
            DataBind();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strSubject = GetSubject();
            if (strSubject != "") textEdit1.Text = strSubject;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strSubject = GetSubject();
            if (strSubject != "") textEdit2.Text = strSubject;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strSubject = GetSubject();
            if (strSubject != "") textEdit3.Text = strSubject;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string strSubject = GetSubject();
            if (strSubject != "") textEdit4.Text = strSubject;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string strSubject = GetSubject();
            if (strSubject != "") textEdit5.Text = strSubject;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string strSubject = GetSubject();
            if (strSubject != "") textEdit6.Text = strSubject;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string strSubject = GetSubject();
            if (strSubject != "") textEdit7.Text = strSubject;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string strSubject = GetSubject();
            if (strSubject != "") textEdit8.Text = strSubject;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string strSubject = GetSubject();
            if (strSubject != "") textEdit9.Text = strSubject;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string strSubject = GetSubject();
            if (strSubject != "") textEdit10.Text = strSubject;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string strSubject = GetSubject();
            if (strSubject != "") textEdit11.Text = strSubject;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string strSubject = GetSubject();
            if (strSubject != "") textEdit12.Text = strSubject;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string strSubject = GetSubject();
            if (strSubject != "") textEdit13.Text = strSubject;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string strSubject = GetSubject();
            if (strSubject != "") textEdit14.Text = strSubject;
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            spinEdit3.Enabled = checkBox8.Checked;
        }
      
    }
}

