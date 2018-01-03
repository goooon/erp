namespace Sys
{
    partial class frmDataExport
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
            this.sbExport = new DevExpress.XtraEditors.SimpleButton();
            this.sbClose = new DevExpress.XtraEditors.SimpleButton();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.ckOperation = new DevExpress.XtraEditors.CheckEdit();
            this.ucDate = new myControl.ucDate();
            this.ckBase = new DevExpress.XtraEditors.CheckEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lbFlag = new System.Windows.Forms.Label();
            this.txtFile = new DevExpress.XtraEditors.TextEdit();
            this.sbSelect = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.FileDlg = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckOperation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckBase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFile.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // sbExport
            // 
            this.sbExport.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbExport.Appearance.Options.UseFont = true;
            this.sbExport.Location = new System.Drawing.Point(360, 374);
            this.sbExport.Name = "sbExport";
            this.sbExport.Size = new System.Drawing.Size(64, 23);
            this.sbExport.TabIndex = 0;
            this.sbExport.Text = "导出(&E)";
            this.sbExport.Click += new System.EventHandler(this.sbExport_Click);
            // 
            // sbClose
            // 
            this.sbClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbClose.Appearance.Options.UseFont = true;
            this.sbClose.Location = new System.Drawing.Point(431, 374);
            this.sbClose.Name = "sbClose";
            this.sbClose.Size = new System.Drawing.Size(64, 23);
            this.sbClose.TabIndex = 1;
            this.sbClose.Text = "关闭(&C)";
            this.sbClose.Click += new System.EventHandler(this.sbClose_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(13, 345);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(472, 13);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkedListBox1);
            this.groupBox1.Controls.Add(this.ckOperation);
            this.groupBox1.Controls.Add(this.ucDate);
            this.groupBox1.Controls.Add(this.ckBase);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 260);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "辅助资料",
            "公司信息",
            "用户组资料",
            "用户资料",
            "权限资料",
            "供应商资料",
            "客户资料",
            "职员资料",
            "物料资料",
            "仓库资料",
            "工组资料",
            "工序资料",
            "工艺流程资料",
            "产品工序规划资料",
            "外加工厂商资料",
            "BOM资料",
            "货运公司资料",
            "系统类别资料",
            "申购单",
            "采购订单",
            "采购进货单",
            "采购付款单",
            "采购退货单",
            "询价单",
            "报价单",
            "客户订单",
            "发货通知单",
            "发货单",
            "收款单",
            "销售退货单",
            "盘点单",
            "调拔单",
            "折装单",
            "其它进出仓单",
            "生产计划单",
            "生产任务单",
            "生产状况表",
            "领料单",
            "补料单",
            "退料单",
            "产品进仓单",
            "委外加工单",
            "委外领料单",
            "委外退料单",
            "委外入仓单",
            "委外退货单",
            "委外付款单"});
            this.checkedListBox1.Location = new System.Drawing.Point(6, 88);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(467, 132);
            this.checkedListBox1.TabIndex = 5;
            // 
            // ckOperation
            // 
            this.ckOperation.EditValue = true;
            this.ckOperation.Location = new System.Drawing.Point(213, 60);
            this.ckOperation.Name = "ckOperation";
            this.ckOperation.Properties.Caption = "所有业务";
            this.ckOperation.Size = new System.Drawing.Size(75, 19);
            this.ckOperation.TabIndex = 2;
            this.ckOperation.CheckedChanged += new System.EventHandler(this.ckOperation_CheckedChanged);
            // 
            // ucDate
            // 
            this.ucDate.DateTag = myControl.DateFlag.全部;
            this.ucDate.Location = new System.Drawing.Point(6, 228);
            this.ucDate.Name = "ucDate";
            this.ucDate.Size = new System.Drawing.Size(336, 26);
            this.ucDate.TabIndex = 4;
            // 
            // ckBase
            // 
            this.ckBase.EditValue = true;
            this.ckBase.Location = new System.Drawing.Point(21, 60);
            this.ckBase.Name = "ckBase";
            this.ckBase.Properties.Caption = "基本资料";
            this.ckBase.Size = new System.Drawing.Size(75, 19);
            this.ckBase.TabIndex = 1;
            this.ckBase.CheckedChanged += new System.EventHandler(this.ckBase_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据引出是将本期数据导出到一数据包,此数据包可用数据导入\r\n功能导入。\r\n\r\n";
            // 
            // lbFlag
            // 
            this.lbFlag.AutoSize = true;
            this.lbFlag.Location = new System.Drawing.Point(188, 324);
            this.lbFlag.Name = "lbFlag";
            this.lbFlag.Size = new System.Drawing.Size(0, 12);
            this.lbFlag.TabIndex = 5;
            // 
            // txtFile
            // 
            this.txtFile.Enabled = false;
            this.txtFile.Location = new System.Drawing.Point(13, 300);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(454, 21);
            this.txtFile.TabIndex = 6;
            // 
            // sbSelect
            // 
            this.sbSelect.Location = new System.Drawing.Point(473, 298);
            this.sbSelect.Name = "sbSelect";
            this.sbSelect.Size = new System.Drawing.Size(22, 23);
            this.sbSelect.TabIndex = 7;
            this.sbSelect.Text = "...";
            this.sbSelect.Click += new System.EventHandler(this.sbSelect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "存放文件:";
            // 
            // FileDlg
            // 
            this.FileDlg.DefaultExt = "Rar";
            this.FileDlg.Filter = "压缩文件|*.Rar";
            // 
            // frmDataExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(507, 409);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sbSelect);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.lbFlag);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.sbClose);
            this.Controls.Add(this.sbExport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDataExport";
            this.Text = "数据导出";
            this.Shown += new System.EventHandler(this.frmDataExport_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckOperation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckBase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFile.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton sbExport;
        private DevExpress.XtraEditors.SimpleButton sbClose;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private myControl.ucDate ucDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbFlag;
        private DevExpress.XtraEditors.CheckEdit ckOperation;
        private DevExpress.XtraEditors.CheckEdit ckBase;
        private DevExpress.XtraEditors.TextEdit txtFile;
        private DevExpress.XtraEditors.SimpleButton sbSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog FileDlg;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}
