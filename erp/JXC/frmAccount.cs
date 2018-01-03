using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JXC
{
    public partial class frmAccount : BaseClass.frmBase
    {
        public frmAccount()
        {
            InitializeComponent();
            blnLog = false;
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DataBind()
        {
            //DataLib.SysVar.strSysCon = "Data Source=.;Initial Catalog=Master;Persist Security Info=True;User ID=" + DataLib.SysVar.strLogID + ";Password="+DataLib.SysVar.strLogPsw;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetAccount("true");
            //DataSet ds = myHelper.GetDs("select * from master.dbo.t_JXCAccount");
            gcAccount.DataSource = ds.Tables[0].DefaultView;
            ds.Dispose();
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            if (gvAccount.FocusedRowHandle < 0) return;
            DataRow dr = gvAccount.GetDataRow(gvAccount.FocusedRowHandle);
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
            DataLib.SysVar.strCon = "Provider=SQLOLEDB.1;Password=" + DataLib.SysVar.strLogPsw + ";Persist Security Info=False;User ID=" + DataLib.SysVar.strLogID + ";Initial Catalog=" + dr["FDBName"].ToString() + ";Data Source=" + strHost;
            this.DialogResult = DialogResult.OK;
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        private void gvAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
               sbOK_Click(null, null);
        }

        private void frmAccount_Shown(object sender, EventArgs e)
        {
            gcAccount.Focus();
        }

        private void gvAccount_DoubleClick(object sender, EventArgs e)
        {
            sbOK_Click(null, null);
        }
    }
}

