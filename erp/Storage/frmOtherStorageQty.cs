using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Storage
{
    public partial class frmOtherStorageQty : Common.frmReport
    {
        public frmOtherStorageQty()
        {
            InitializeComponent();
            ucDate.Visible = false;
            rgOption.Visible = false;
        }

        private void frmOtherStorageQty_KeyDown(object sender, KeyEventArgs e)
        {
            //物料Bom库存情况
            if (e.KeyCode == Keys.F6)
            {
                if (gvReport.FocusedRowHandle < 0) return;
                DataRow dr = gvReport.GetDataRow(gvReport.FocusedRowHandle);

                if (dr["F_ItemID"] == DBNull.Value) return;
                Common.frmBomStoreQty F = new Common.frmBomStoreQty(dr["F_ItemID"].ToString());
                F.ShowDialog();
                F.Dispose();
            }
        }
    }
}

