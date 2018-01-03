namespace Report
{
    partial class frmSequence
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtItem = new DevExpress.XtraEditors.TextEdit();
            this.sbSelect = new DevExpress.XtraEditors.SimpleButton();
            this.sbRefresh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.rgOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // rgOption
            // 
            this.rgOption.Location = new System.Drawing.Point(97, 10);
            this.rgOption.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgOption.Properties.Appearance.Options.UseBackColor = true;
            this.rgOption.Visible = false;
            // 
            // lbTitle
            // 
            this.lbTitle.Size = new System.Drawing.Size(101, 24);
            this.lbTitle.Text = "frmBase";
            // 
            // ucDate
            // 
            this.ucDate.Location = new System.Drawing.Point(214, 11);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtItem);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.sbSelect);
            this.panel1.Controls.Add(this.sbRefresh);
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Size = new System.Drawing.Size(903, 45);
            this.panel1.Controls.SetChildIndex(this.ucDate, 0);
            this.panel1.Controls.SetChildIndex(this.sbRefresh, 0);
            this.panel1.Controls.SetChildIndex(this.sbSelect, 0);
            this.panel1.Controls.SetChildIndex(this.rgOption, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.txtItem, 0);
            this.panel1.Controls.SetChildIndex(this.lbTitle, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(617, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "物料:";
            // 
            // txtItem
            // 
            this.txtItem.Enabled = false;
            this.txtItem.Location = new System.Drawing.Point(654, 13);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(142, 21);
            this.txtItem.TabIndex = 18;
            // 
            // sbSelect
            // 
            this.sbSelect.Location = new System.Drawing.Point(798, 12);
            this.sbSelect.Name = "sbSelect";
            this.sbSelect.Size = new System.Drawing.Size(24, 23);
            this.sbSelect.TabIndex = 19;
            this.sbSelect.Text = "...";
            this.sbSelect.Click += new System.EventHandler(this.sbSelect_Click);
            // 
            // sbRefresh
            // 
            this.sbRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbRefresh.Appearance.Options.UseFont = true;
            this.sbRefresh.Location = new System.Drawing.Point(838, 12);
            this.sbRefresh.Name = "sbRefresh";
            this.sbRefresh.Size = new System.Drawing.Size(53, 23);
            this.sbRefresh.TabIndex = 20;
            this.sbRefresh.Text = "刷新(&R)";
            this.sbRefresh.Click += new System.EventHandler(this.sbRefresh_Click);
            // 
            // frmSequence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(903, 501);
            this.Name = "frmSequence";
            this.Text = "仓库流水帐";
            this.Load += new System.EventHandler(this.frmSequence_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtItem;
        private DevExpress.XtraEditors.SimpleButton sbSelect;
        private DevExpress.XtraEditors.SimpleButton sbRefresh;

    }
}
