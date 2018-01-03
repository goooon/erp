using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace myControl
{
    public partial class CustomDesignForm : DevExpress.XtraReports.UserDesigner.XRDesignFormEx
    {
        protected override void SaveLayout()
        {
            base.SaveLayout();
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.xrDesignPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // xrDesignPanel
            // 
            this.xrDesignPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.xrDesignPanel_Paint);
            // 
            // CustomDesignForm
            // 
            this.ClientSize = new System.Drawing.Size(688, 478);
            this.Name = "CustomDesignForm";
            this.Controls.SetChildIndex(this.xrDesignPanel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.xrDesignPanel)).EndInit();
            this.ResumeLayout(false);

        }

        private void xrDesignPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
