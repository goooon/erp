namespace Report
{
    partial class frmStockYearReport
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
            this.deMonth = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.sbRefresh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.rgOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deMonth.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ucDate
            // 
            this.ucDate.Location = new System.Drawing.Point(391, 34);
            this.ucDate.Visible = false;
            // 
            // rgOption
            // 
            this.rgOption.Visible = false;
            // 
            // lbTitle
            // 
            this.lbTitle.Size = new System.Drawing.Size(101, 24);
            this.lbTitle.Text = "frmBase";
            // 
            // deMonth
            // 
            this.deMonth.EditValue = null;
            this.deMonth.Location = new System.Drawing.Point(391, 38);
            this.deMonth.Name = "deMonth";
            this.deMonth.Properties.DisplayFormat.FormatString = "yyyy";
            this.deMonth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deMonth.Properties.EditFormat.FormatString = "yyyy-MM";
            this.deMonth.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deMonth.Properties.Mask.EditMask = "yyyy";
            this.deMonth.Size = new System.Drawing.Size(51, 21);
            this.deMonth.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(350, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "年份:";
            // 
            // sbRefresh
            // 
            this.sbRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbRefresh.Appearance.Options.UseFont = true;
            this.sbRefresh.Location = new System.Drawing.Point(448, 38);
            this.sbRefresh.Name = "sbRefresh";
            this.sbRefresh.Size = new System.Drawing.Size(61, 23);
            this.sbRefresh.TabIndex = 19;
            this.sbRefresh.Text = "刷新(&R)";
            this.sbRefresh.Click += new System.EventHandler(this.sbRefresh_Click);
            // 
            // frmStockYearReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(748, 501);
            this.Controls.Add(this.sbRefresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deMonth);
            this.Name = "frmStockYearReport";
            this.Text = "物料采购年报表";
            this.Load += new System.EventHandler(this.frmStorageSum_Load);
            this.Controls.SetChildIndex(this.deMonth, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.sbRefresh, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rgOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deMonth.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit deMonth;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton sbRefresh;

    }
}
