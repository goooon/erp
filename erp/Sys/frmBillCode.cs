using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class frmBillCode : BaseClass.frmBase
    {
        public frmBillCode()
        {
            InitializeComponent();
            BindData();
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void BindData()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_BillCode order by F_ID");
            GridBillCode.DataSource = ds.Tables[0].DefaultView;
        }

        /// <summary>
        ///保存数据
        /// </summary>
        private void SaveData()
        {
            ViewBillCode.PostEditor();
            ViewBillCode.UpdateCurrentRow();
            DataSet ds = ((DataView)GridBillCode.DataSource).Table.DataSet;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.SaveData(ds, "select * from t_BillCode") == 0)
            {
                MessageBox.Show(this, "数据保存成功！！");
                ds.AcceptChanges();
            }
        }

        private void tsClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }
    }
}
