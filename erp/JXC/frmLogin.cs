using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JXC
{
    public partial class frmLogin : Common.frmDialog
    {
        private bool bFlag = false;
        private bool bAccount = false;

        public frmLogin()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "DiamondBlue.ssk";
            gbox.Visible = false;
        }

        private void BindAccount(string sFlag)
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetAccount(sFlag);
            lupAccount.Properties.DataSource = ds.Tables[0].DefaultView;
            lupAccount.Properties.ValueMember = "FID";
            lupAccount.Properties.DisplayMember = "FName";

            string strAccount = DataLib.SysVar.IniReadValue("Database", "Account", DataLib.SysVar.iniFile);
            if (lupAccount.Properties.GetDataSourceRowByKeyValue(strAccount) != null)
               if (strAccount.Length > 0) lupAccount.EditValue = strAccount;
        }

        private void SetInfo()
        {
            if (lupAccount.EditValue == DBNull.Value) return;
            DataRow dr = ((DataRowView)lupAccount.Properties.GetDataSourceRowByDisplayValue(lupAccount.Text)).Row;
            //DataLib.SysVar.strSysCon = "Data Source=.;Initial Catalog=" + dr["FDBName"].ToString() + ";Persist Security Info=True;User ID=" + DataLib.SysVar.strLogID + ";Password=" + DataLib.SysVar.strLogPsw;

            string strHost = ".";
            if (DataLib.SysVar.strServer == "localhost")
            {
                DataLib.sysClass myClass = new DataLib.sysClass();
                string[] strIP = myClass.GetIP();
                strHost = strIP[0];
            }
            else
                strHost = DataLib.SysVar.strServer;

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            myHelper.SetPrintInfo();

            DataLib.SysVar.strDB = dr["FDBName"].ToString();
            DataLib.SysVar.strCon = "Provider=SQLOLEDB.1;Password=" + DataLib.SysVar.strLogPsw + ";Persist Security Info=False;User ID=" + DataLib.SysVar.strLogID + ";Initial Catalog=" + dr["FDBName"].ToString() + ";Data Source="+strHost;
           // MessageBox.Show(DataLib.SysVar.strCon);
        }

        /*
        private void BindFactory()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select F_ID,F_Name from t_Factory");
            lupFactory.Properties.DataSource = ds.Tables[0].DefaultView;
            lupFactory.Properties.DisplayMember = "F_Name";
            lupFactory.Properties.ValueMember = "F_ID";
        }
        */

        private void BtnOK_Click(object sender, EventArgs e)
        {
            SetInfo();
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select a.*,b.F_View,isnull(b.F_Salesman,0) as F_Salesman from t_User a,t_UserGroup b where a.F_Group = b.F_Group and a.F_ID = '" + txtUID.Text + "' and a.F_Psw = '" + txtPsw.Text + "'");
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(this, "密码错误，请查证！！", "提示");
                txtPsw.SelectAll();
                txtPsw.Focus();
                base.DialogResult = DialogResult.None;
                return;
            }

            myHelper.ExecuteSQL("update t_User set F_Login = 1 where F_ID = '" + txtUID.Text + "'");

            DataLib.SysVar.IniWriteValue("Database", "Account", lupAccount.EditValue.ToString(), "C:\\Set.ini");
            DataSet dsTmp = myHelper.GetDs("select * from t_CompanyInfo");
            DataLib.SysVar.strUID = txtUID.Text;
            DataLib.SysVar.strUName = txtUName.Text;
            DataLib.SysVar.strUGroup = ds.Tables[0].Rows[0]["F_Group"].ToString();
            DataLib.SysVar.blnSaleMan = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_Salesman"]);
            DataLib.SysVar.blnInit = Convert.ToBoolean(dsTmp.Tables[0].Rows[0]["F_Use"]);
            DataLib.SysVar.strCompany = dsTmp.Tables[0].Rows[0]["F_Company"].ToString();
            DataLib.SysVar.blnView = Convert.ToBoolean(ds.Tables[0].Rows[0]["F_View"]);
            DataLib.SysVar.blnStorageFlag = DataLib.SysVar.GetParmValue("F_N10");
            DataLib.SysVar.strAccount = lupAccount.Text;
        }

        private void txtUID_Leave(object sender, EventArgs e)
        {
            if (txtUID.IsModified == true)
            {
                DataLib.DataHelper myHelper = new DataLib.DataHelper();
                DataSet ds = myHelper.GetDs("select F_Name from t_User where F_ID = '" + txtUID.Text + "'");
                if (ds == null) return;
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(this, "无些用户，请查证！！", "提示");
                    txtUID.SelectAll();
                    txtUID.Focus();
                    return;
                }
                else
                {
                    txtUName.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            BindAccount("true");
            //BindFactory();
        }

        private void lupAccount_EditValueChanged(object sender, EventArgs e)
        {
            SetInfo();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift == true && e.KeyCode == Keys.F12)
            {
                if (bFlag == false)
                {
                    BindAccount("false");
                    bFlag = true;
                }
                else
                {
                    BindAccount("true");
                    bFlag = false;
                }
            }

            if (e.Shift == true && e.Alt == true && e.Control == true && e.KeyCode == Keys.F10)
            {
                if (bAccount == false)
                {
                    DataLib.SysVar.strServer = DataLib.SysVar.IniReadValue("Database", "Server1", DataLib.SysVar.iniFile);
                    
                }
                else
                {
                    DataLib.SysVar.strServer = DataLib.SysVar.IniReadValue("Database", "Server", DataLib.SysVar.iniFile);
                }
                BindAccount("true");
            }
        }
    }
}

