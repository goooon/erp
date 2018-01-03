namespace Storage
{
    partial class frmOtherInOutList
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
            this.cbControl1 = new myControl.cbControl();
            ((System.ComponentModel.ISupportInitialize)(this.cbType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCheck.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFinish.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCutOff.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cbType
            // 
            this.cbType.Location = new System.Drawing.Point(829, 13);
            // 
            // cbCheck
            // 
            // 
            // cbFinish
            // 
            this.cbFinish.Location = new System.Drawing.Point(711, 13);
            this.cbFinish.Visible = false;
            // 
            // cbCutOff
            // 
            this.cbCutOff.Location = new System.Drawing.Point(593, 13);
            this.cbCutOff.Visible = false;
            // 
            // lbType
            // 
            this.lbType.Location = new System.Drawing.Point(794, 18);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(670, 18);
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(552, 18);
            this.label3.Visible = false;
            // 
            // cbControl1
            // 
            this.cbControl1.BackColor = System.Drawing.Color.Transparent;
            this.cbControl1.cbItem = new DevExpress.XtraEditors.Controls.ComboBoxItem[0];
            this.cbControl1.DataField = "";
            this.cbControl1.DataSource = null;
            this.cbControl1.EditLabel = "入库类型:";
            this.cbControl1.EditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbControl1.Location = new System.Drawing.Point(512, 38);
            this.cbControl1.Name = "cbControl1";
            this.cbControl1.Request = false;
            this.cbControl1.SelectedIndex = -1;
            this.cbControl1.Size = new System.Drawing.Size(194, 21);
            this.cbControl1.TabIndex = 20;
            this.cbControl1.SelectIndexChange += new myControl.SelectIndexChangeEventHandler(this.cbControl1_SelectIndexChange);
            // 
            // frmOtherInOutList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(892, 526);
            this.Controls.Add(this.cbControl1);
            this.Name = "frmOtherInOutList";
            this.Text = "其它进仓列表";
            this.Load += new System.EventHandler(this.frmOtherInOutList_Load);
            this.Controls.SetChildIndex(this.cbControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.cbType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCheck.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFinish.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCutOff.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private myControl.cbControl cbControl1;
    }
}
