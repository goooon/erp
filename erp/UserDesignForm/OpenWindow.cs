using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UserDesignForm
{
    public partial class OpenWindow : Form
    {
        public OpenWindow()
        {
            InitializeComponent();
            tvForm.ExpandAll();
        }

        private void GetModule(object sender,EventArgs e)
        {
            if (tvForm.SelectedNode == null) return;
            if (tvForm.SelectedNode.Level != 1) return;
            this.DialogResult = DialogResult.OK;
        }
    }
}
