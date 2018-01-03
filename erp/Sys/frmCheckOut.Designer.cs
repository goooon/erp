namespace Sys
{
    partial class frmCheckOut
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
            this.sbCancel = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.btnUnStorageCheck = new DevExpress.XtraEditors.SimpleButton();
            this.sbStoreCheck = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbFlag = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtMonth = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtMonth.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // sbCancel
            // 
            this.sbCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbCancel.Appearance.Options.UseFont = true;
            this.sbCancel.Location = new System.Drawing.Point(258, 227);
            this.sbCancel.Name = "sbCancel";
            this.sbCancel.Size = new System.Drawing.Size(75, 23);
            this.sbCancel.TabIndex = 2;
            this.sbCancel.Text = "关闭(&C)";
            this.sbCancel.Click += new System.EventHandler(this.sbCancel_Click);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(12, 12);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(325, 209);
            this.xtraTabControl1.TabIndex = 3;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            this.xtraTabControl1.Text = "xtraTabControl1";
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.btnUnStorageCheck);
            this.xtraTabPage1.Controls.Add(this.sbStoreCheck);
            this.xtraTabPage1.Controls.Add(this.groupBox1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(319, 182);
            this.xtraTabPage1.Text = "库存结帐";
            // 
            // btnUnStorageCheck
            // 
            this.btnUnStorageCheck.Location = new System.Drawing.Point(231, 147);
            this.btnUnStorageCheck.Name = "btnUnStorageCheck";
            this.btnUnStorageCheck.Size = new System.Drawing.Size(75, 23);
            this.btnUnStorageCheck.TabIndex = 3;
            this.btnUnStorageCheck.Text = "反结帐";
            this.btnUnStorageCheck.Click += new System.EventHandler(this.btnUnStorageCheck_Click);
            // 
            // sbStoreCheck
            // 
            this.sbStoreCheck.Location = new System.Drawing.Point(150, 147);
            this.sbStoreCheck.Name = "sbStoreCheck";
            this.sbStoreCheck.Size = new System.Drawing.Size(75, 23);
            this.sbStoreCheck.TabIndex = 2;
            this.sbStoreCheck.Text = "结帐";
            this.sbStoreCheck.Click += new System.EventHandler(this.sbStoreCheck_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbFlag);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtMonth);
            this.groupBox1.Location = new System.Drawing.Point(10, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 138);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // lbFlag
            // 
            this.lbFlag.AutoSize = true;
            this.lbFlag.ForeColor = System.Drawing.Color.Red;
            this.lbFlag.Location = new System.Drawing.Point(45, 112);
            this.lbFlag.Name = "lbFlag";
            this.lbFlag.Size = new System.Drawing.Size(185, 12);
            this.lbFlag.TabIndex = 4;
            this.lbFlag.Text = "正在进行库存结帐，请稍待......";
            this.lbFlag.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 36);
            this.label2.TabIndex = 3;
            this.label2.Text = "注:库存月结操作是将本月库存数结转下来，当成\r\n下月期初数，结帐操作完成后，本月所有业务单据\r\n将不能再作修改。";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "月份:";
            // 
            // dtMonth
            // 
            this.dtMonth.EditValue = null;
            this.dtMonth.Location = new System.Drawing.Point(106, 75);
            this.dtMonth.Name = "dtMonth";
            this.dtMonth.Properties.DisplayFormat.FormatString = "yyyy-MM";
            this.dtMonth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtMonth.Properties.Mask.EditMask = "yyyy-MM";
            this.dtMonth.Size = new System.Drawing.Size(72, 21);
            this.dtMonth.TabIndex = 2;
            // 
            // frmCheckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(349, 259);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.sbCancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCheckOut";
            this.Text = "月末结帐";
            this.Load += new System.EventHandler(this.frmCheckOut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtMonth.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton sbCancel;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.SimpleButton sbStoreCheck;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbFlag;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit dtMonth;
        private DevExpress.XtraEditors.SimpleButton btnUnStorageCheck;
    }
}
