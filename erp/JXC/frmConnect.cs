using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JXC
{
    public partial class frmConnect : BaseClass.frmBase
    {
        public frmConnect()
        {
            InitializeComponent();
        }

        public void frmConnect_Load(object sender, EventArgs e)
        {
            txtServer.Text = DataLib.SysVar.IniReadValue("Database", "Server", DataLib.SysVar.iniFile);
            string sIndex = DataLib.SysVar.IniReadValue("Database", "ConnectType", DataLib.SysVar.iniFile);
            if (sIndex.Length > 0)
            {
                cbType.SelectedIndex = Convert.ToInt32(sIndex);
                DataLib.SysVar.intConnect = cbType.SelectedIndex;
            }
            //txtLogin.Text = DataLib.SysVar.IniReadValue("Database", "LogID", strIniFile);
           // txtPsw.Text = DataLib.SysVar.IniReadValue("Database", "LogPsw", strIniFile);
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void sbOK_Click(object sender, EventArgs e)
        {
            if (txtServer.Text.Length == 0)
            {
                MessageBox.Show("ÇëÊäÈë·þÎñÆ÷!!");
                txtServer.Focus();
                return;
            }
            txtServer.Enabled = false;
            //txtLogin.Enabled = false;
            //txtPsw.Enabled = false;
            sbOK.Enabled = false;
            //sbCancel.Enabled = false;
            this.panel1.Visible = true;
            this.Update();
            try
            {
                if (txtServer.Text.IndexOf("/") > 0)
                    DataLib.SysVar.strUrl = "http://" + txtServer.Text + "/Service.asmx";
                else
                    DataLib.SysVar.strUrl = "http://" + txtServer.Text + "/JxcService/Service.asmx";

                    
                Application.DoEvents();
                DataLib.DataHelper myHelper = new DataLib.DataHelper();
                if (myHelper.TestLogin(txtServer.Text) == true)
                {
                    DataLib.SysVar.strServer = txtServer.Text;
                    //DataLib.SysVar.strLogID = txtLogin.Text;
                    //DataLib.SysVar.strLogPsw = txtPsw.Text;
                    DataLib.SysVar.IniWriteValue("Database", "Server", txtServer.Text, DataLib.SysVar.iniFile);
                    DataLib.SysVar.IniWriteValue("Database", "ConnectType", cbType.SelectedIndex.ToString(), DataLib.SysVar.iniFile);
                    if (checkEdit1.Checked == true)
                        DataLib.SysVar.IniWriteValue("Database", "HideServerForm", "1", DataLib.SysVar.iniFile);
                    //DataLib.SysVar.IniWriteValue("Database", "LogID", txtLogin.Text, strIniFile);
                    //DataLib.SysVar.IniWriteValue("Database", "LogPsw", txtPsw.Text, strIniFile);

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    DataLib.SysVar.IniWriteValue("Database", "HideServerForm", "0", DataLib.SysVar.iniFile);
                }
            }
            finally
            {
                txtServer.Enabled = true;
                //txtLogin.Enabled = true;
                //txtPsw.Enabled = true;
                sbOK.Enabled = true;
                //sbCancel.Enabled = true;
                panel1.Visible = false;
            }
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataLib.SysVar.intConnect = cbType.SelectedIndex;
        }
    }
}

