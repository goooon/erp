namespace Storage
{
    partial class frmInstall
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
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem1 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem2 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            this.lupControl1 = new myControl.lupControl();
            this.editControl5 = new myControl.EditControl();
            this.cbControl1 = new myControl.cbControl();
            this.editControl6 = new myControl.EditControl();
            this.editControl7 = new myControl.EditControl();
            this.editControl8 = new myControl.EditControl();
            this.editControl9 = new myControl.EditControl();
            this.editControl10 = new myControl.EditControl();
            this.sbSelItem = new DevExpress.XtraEditors.SimpleButton();
            this.spinControl1 = new myControl.SpinControl();
            this.sbExpand = new DevExpress.XtraEditors.SimpleButton();
            this.editControl11 = new myControl.EditControl();
            this.editControl12 = new myControl.EditControl();
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.Size = new System.Drawing.Size(94, 21);
            this.lbTitle.Text = "frmBase";
            // 
            // dateControl1
            // 
            this.dateControl1.Location = new System.Drawing.Point(554, 32);
            // 
            // editControl1
            // 
            this.editControl1.Location = new System.Drawing.Point(554, 7);
            this.editControl1.Size = new System.Drawing.Size(175, 21);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.OldLace;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.editControl12);
            this.panelControl1.Controls.Add(this.editControl11);
            this.panelControl1.Controls.Add(this.sbExpand);
            this.panelControl1.Controls.Add(this.spinControl1);
            this.panelControl1.Controls.Add(this.sbSelItem);
            this.panelControl1.Controls.Add(this.editControl10);
            this.panelControl1.Controls.Add(this.editControl9);
            this.panelControl1.Controls.Add(this.editControl8);
            this.panelControl1.Controls.Add(this.editControl7);
            this.panelControl1.Controls.Add(this.editControl6);
            this.panelControl1.Controls.Add(this.cbControl1);
            this.panelControl1.Controls.Add(this.editControl5);
            this.panelControl1.Controls.Add(this.lupControl1);
            this.panelControl1.Location = new System.Drawing.Point(0, 26);
            this.panelControl1.Size = new System.Drawing.Size(803, 160);
            this.panelControl1.Controls.SetChildIndex(this.lbTitle, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.dateControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl5, 0);
            this.panelControl1.Controls.SetChildIndex(this.cbControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl6, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl7, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl8, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl9, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl10, 0);
            this.panelControl1.Controls.SetChildIndex(this.sbSelItem, 0);
            this.panelControl1.Controls.SetChildIndex(this.spinControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.sbExpand, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl11, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl12, 0);
            // 
            // lupControl1
            // 
            this.lupControl1.BackColor = System.Drawing.Color.Transparent;
            this.lupControl1.DataField = "F_StorageID";
            this.lupControl1.DisplayCaption = "";
            this.lupControl1.EditLabel = "仓库:";
            this.lupControl1.Location = new System.Drawing.Point(225, 44);
            this.lupControl1.LookUpDataSource = null;
            this.lupControl1.LookUpDisplayField = null;
            this.lupControl1.LookUpKeyField = null;
            this.lupControl1.Name = "lupControl1";
            this.lupControl1.PopWidth = 150;
            this.lupControl1.Request = true;
            this.lupControl1.Size = new System.Drawing.Size(150, 22);
            this.lupControl1.TabIndex = 3;
            // 
            // editControl5
            // 
            this.editControl5.BackColor = System.Drawing.Color.Transparent;
            this.editControl5.DataField = "F_Remark";
            this.editControl5.EditLabel = "备注:";
            this.editControl5.Location = new System.Drawing.Point(32, 130);
            this.editControl5.Name = "editControl5";
            this.editControl5.Request = false;
            this.editControl5.Size = new System.Drawing.Size(565, 23);
            this.editControl5.TabIndex = 4;
            // 
            // cbControl1
            // 
            this.cbControl1.BackColor = System.Drawing.Color.Transparent;
            comboBoxItem1.Value = "组装";
            comboBoxItem2.Value = "拆卸";
            this.cbControl1.cbItem = new DevExpress.XtraEditors.Controls.ComboBoxItem[] {
        comboBoxItem1,
        comboBoxItem2};
            this.cbControl1.DataField = "F_Type";
            this.cbControl1.EditLabel = "类别:";
            this.cbControl1.EditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbControl1.Location = new System.Drawing.Point(30, 43);
            this.cbControl1.Name = "cbControl1";
            this.cbControl1.Request = false;
            this.cbControl1.Size = new System.Drawing.Size(150, 26);
            this.cbControl1.TabIndex = 7;
            // 
            // editControl6
            // 
            this.editControl6.BackColor = System.Drawing.Color.Transparent;
            this.editControl6.DataField = "F_ItemID";
            this.editControl6.EditLabel = "物料编码:";
            this.editControl6.Location = new System.Drawing.Point(7, 72);
            this.editControl6.Name = "editControl6";
            this.editControl6.Request = false;
            this.editControl6.Size = new System.Drawing.Size(173, 21);
            this.editControl6.TabIndex = 8;
            // 
            // editControl7
            // 
            this.editControl7.BackColor = System.Drawing.Color.Transparent;
            this.editControl7.DataField = "";
            this.editControl7.EditLabel = "物料名称:";
            this.editControl7.Enabled = false;
            this.editControl7.Location = new System.Drawing.Point(204, 72);
            this.editControl7.Name = "editControl7";
            this.editControl7.Request = false;
            this.editControl7.Size = new System.Drawing.Size(345, 21);
            this.editControl7.TabIndex = 9;
            // 
            // editControl8
            // 
            this.editControl8.BackColor = System.Drawing.Color.Transparent;
            this.editControl8.DataField = "";
            this.editControl8.EditLabel = "规格:";
            this.editControl8.Enabled = false;
            this.editControl8.Location = new System.Drawing.Point(32, 102);
            this.editControl8.Name = "editControl8";
            this.editControl8.Request = false;
            this.editControl8.Size = new System.Drawing.Size(207, 21);
            this.editControl8.TabIndex = 10;
            // 
            // editControl9
            // 
            this.editControl9.BackColor = System.Drawing.Color.Transparent;
            this.editControl9.DataField = "F_Unit";
            this.editControl9.EditLabel = "单位:";
            this.editControl9.Enabled = false;
            this.editControl9.Location = new System.Drawing.Point(245, 102);
            this.editControl9.Name = "editControl9";
            this.editControl9.Request = false;
            this.editControl9.Size = new System.Drawing.Size(84, 21);
            this.editControl9.TabIndex = 11;
            // 
            // editControl10
            // 
            this.editControl10.BackColor = System.Drawing.Color.Transparent;
            this.editControl10.DataField = "F_BatchNo";
            this.editControl10.EditLabel = "批号:";
            this.editControl10.Enabled = false;
            this.editControl10.Location = new System.Drawing.Point(449, 103);
            this.editControl10.Name = "editControl10";
            this.editControl10.Request = false;
            this.editControl10.Size = new System.Drawing.Size(122, 21);
            this.editControl10.TabIndex = 12;
            // 
            // sbSelItem
            // 
            this.sbSelItem.Appearance.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbSelItem.Appearance.Options.UseFont = true;
            this.sbSelItem.Location = new System.Drawing.Point(179, 72);
            this.sbSelItem.Name = "sbSelItem";
            this.sbSelItem.Size = new System.Drawing.Size(25, 21);
            this.sbSelItem.TabIndex = 13;
            this.sbSelItem.Text = "...";
            this.sbSelItem.Click += new System.EventHandler(this.sbSelItem_Click);
            // 
            // spinControl1
            // 
            this.spinControl1.BackColor = System.Drawing.Color.Transparent;
            this.spinControl1.DataField = "F_Qty";
            this.spinControl1.EditLabel = "数量:";
            this.spinControl1.Location = new System.Drawing.Point(600, 102);
            this.spinControl1.Name = "spinControl1";
            this.spinControl1.Size = new System.Drawing.Size(95, 21);
            this.spinControl1.TabIndex = 14;
            // 
            // sbExpand
            // 
            this.sbExpand.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbExpand.Appearance.Options.UseFont = true;
            this.sbExpand.Location = new System.Drawing.Point(716, 130);
            this.sbExpand.Name = "sbExpand";
            this.sbExpand.Size = new System.Drawing.Size(75, 23);
            this.sbExpand.TabIndex = 15;
            this.sbExpand.Text = "Bom展开";
            this.sbExpand.Click += new System.EventHandler(this.sbExpand_Click);
            // 
            // editControl11
            // 
            this.editControl11.BackColor = System.Drawing.Color.Transparent;
            this.editControl11.DataField = "F_Color";
            this.editControl11.EditLabel = "颜色:";
            this.editControl11.Enabled = false;
            this.editControl11.Location = new System.Drawing.Point(573, 72);
            this.editControl11.Name = "editControl11";
            this.editControl11.Request = false;
            this.editControl11.Size = new System.Drawing.Size(122, 21);
            this.editControl11.TabIndex = 16;
            // 
            // editControl12
            // 
            this.editControl12.BackColor = System.Drawing.Color.Transparent;
            this.editControl12.DataField = "F_Grade";
            this.editControl12.EditLabel = "等级:";
            this.editControl12.Enabled = false;
            this.editControl12.Location = new System.Drawing.Point(335, 103);
            this.editControl12.Name = "editControl12";
            this.editControl12.Request = false;
            this.editControl12.Size = new System.Drawing.Size(108, 21);
            this.editControl12.TabIndex = 17;
            // 
            // frmInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(803, 555);
            this.Name = "frmInstall";
            this.Text = "拆装单";
            this.Load += new System.EventHandler(this.frmStockOrder_Load);
            this.Shown += new System.EventHandler(this.frmInstall_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton sbSelItem;
        public myControl.lupControl lupControl1;
        public myControl.EditControl editControl5;
        public myControl.cbControl cbControl1;
        public myControl.EditControl editControl7;
        public myControl.EditControl editControl6;
        public myControl.EditControl editControl8;
        public myControl.EditControl editControl9;
        public myControl.EditControl editControl10;
        public myControl.SpinControl spinControl1;
        public DevExpress.XtraEditors.SimpleButton sbExpand;
        public myControl.EditControl editControl12;
        public myControl.EditControl editControl11;
    }
}
