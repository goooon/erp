using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Wage
{
    public partial class frmFormula : BaseClass.frmBase
    {
        public frmFormula()
        {
            InitializeComponent();
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sbOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            this.meFormula.Text =  this.meFormula.Text + (sender as SimpleButton).Text;
        }

    }
}

