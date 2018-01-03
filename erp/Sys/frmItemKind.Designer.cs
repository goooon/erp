namespace Sys
{
    partial class frmItemKind
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.sbOK = new DevExpress.XtraEditors.SimpleButton();
            this.sbCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lbKind = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // sbOK
            // 
            this.sbOK.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbOK.Appearance.Options.UseFont = true;
            this.sbOK.Location = new System.Drawing.Point(159, 12);
            this.sbOK.Name = "sbOK";
            this.sbOK.Size = new System.Drawing.Size(64, 23);
            this.sbOK.TabIndex = 1;
            this.sbOK.Text = "确定(&O)";
            this.sbOK.Click += new System.EventHandler(this.sbOK_Click);
            // 
            // sbCancel
            // 
            this.sbCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbCancel.Appearance.Options.UseFont = true;
            this.sbCancel.Location = new System.Drawing.Point(159, 41);
            this.sbCancel.Name = "sbCancel";
            this.sbCancel.Size = new System.Drawing.Size(64, 23);
            this.sbCancel.TabIndex = 2;
            this.sbCancel.Text = "取消(&C)";
            this.sbCancel.Click += new System.EventHandler(this.sbCancel_Click);
            // 
            // lbKind
            // 
            this.lbKind.FormattingEnabled = true;
            this.lbKind.ItemHeight = 12;
            this.lbKind.Items.AddRange(new object[] {
            "原材料",
            "产成品",
            "半成品",
            "其它"});
            this.lbKind.Location = new System.Drawing.Point(12, 12);
            this.lbKind.Name = "lbKind";
            this.lbKind.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbKind.Size = new System.Drawing.Size(120, 112);
            this.lbKind.TabIndex = 3;
            // 
            // frmItemKind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(244, 139);
            this.Controls.Add(this.lbKind);
            this.Controls.Add(this.sbCancel);
            this.Controls.Add(this.sbOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmItemKind";
            this.Text = "选择物料属性";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton sbOK;
        private DevExpress.XtraEditors.SimpleButton sbCancel;
        public System.Windows.Forms.ListBox lbKind;
    }
}
