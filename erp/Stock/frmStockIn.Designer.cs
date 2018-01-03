namespace Stock
{
    partial class frmStockIn
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
            this.lupControl1 = new myControl.lupControl();
            this.editControl5 = new myControl.EditControl();
            this.dateControl2 = new myControl.DateControl();
            this.lupControl2 = new myControl.lupControl();
            this.lupControl3 = new myControl.lupControl();
            this.editControl6 = new myControl.EditControl();
            this.dateControl3 = new myControl.DateControl();
            this.lupControl4 = new myControl.lupControl();
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
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.OldLace;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.lupControl4);
            this.panelControl1.Controls.Add(this.dateControl3);
            this.panelControl1.Controls.Add(this.editControl6);
            this.panelControl1.Controls.Add(this.lupControl3);
            this.panelControl1.Controls.Add(this.lupControl2);
            this.panelControl1.Controls.Add(this.dateControl2);
            this.panelControl1.Controls.Add(this.editControl5);
            this.panelControl1.Controls.Add(this.lupControl1);
            this.panelControl1.Location = new System.Drawing.Point(0, 26);
            this.panelControl1.Size = new System.Drawing.Size(809, 141);
            this.panelControl1.Controls.SetChildIndex(this.lbTitle, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.dateControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl5, 0);
            this.panelControl1.Controls.SetChildIndex(this.dateControl2, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl2, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl3, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl6, 0);
            this.panelControl1.Controls.SetChildIndex(this.dateControl3, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl4, 0);
            // 
            // editControl4
            // 
            this.editControl4.Location = new System.Drawing.Point(627, 6);
            // 
            // editControl3
            // 
            this.editControl3.Location = new System.Drawing.Point(285, 6);
            // 
            // dateControl1
            // 
            this.dateControl1.Location = new System.Drawing.Point(592, 36);
            // 
            // editControl1
            // 
            this.editControl1.Location = new System.Drawing.Point(594, 8);
            // 
            // lupControl1
            // 
            this.lupControl1.BackColor = System.Drawing.Color.Transparent;
            this.lupControl1.DataField = "F_SupplierID";
            this.lupControl1.DataSource = null;
            this.lupControl1.DisplayCaption = "";
            this.lupControl1.EditLabel = "供应商:";
            this.lupControl1.Location = new System.Drawing.Point(25, 56);
            this.lupControl1.LookUpDataSource = null;
            this.lupControl1.LookUpDisplayField = null;
            this.lupControl1.LookUpKeyField = null;
            this.lupControl1.Name = "lupControl1";
            this.lupControl1.PopWidth = 150;
            this.lupControl1.Request = true;
            this.lupControl1.Size = new System.Drawing.Size(270, 22);
            this.lupControl1.TabIndex = 3;
            // 
            // editControl5
            // 
            this.editControl5.BackColor = System.Drawing.Color.Transparent;
            this.editControl5.DataField = "F_Remark";
            this.editControl5.DataSource = null;
            this.editControl5.EditLabel = "备注:";
            this.editControl5.Location = new System.Drawing.Point(37, 114);
            this.editControl5.Name = "editControl5";
            this.editControl5.Request = false;
            this.editControl5.Size = new System.Drawing.Size(665, 21);
            this.editControl5.TabIndex = 8;
            // 
            // dateControl2
            // 
            this.dateControl2.BackColor = System.Drawing.Color.Transparent;
            this.dateControl2.DataField = "F_StockTime";
            this.dateControl2.DataSource = null;
            this.dateControl2.EditLabel = "进仓日期:";
            this.dateControl2.Location = new System.Drawing.Point(339, 56);
            this.dateControl2.Name = "dateControl2";
            this.dateControl2.Request = true;
            this.dateControl2.Size = new System.Drawing.Size(180, 22);
            this.dateControl2.TabIndex = 4;
            // 
            // lupControl2
            // 
            this.lupControl2.BackColor = System.Drawing.Color.Transparent;
            this.lupControl2.DataField = "F_DeptID";
            this.lupControl2.DataSource = null;
            this.lupControl2.DisplayCaption = "";
            this.lupControl2.EditLabel = "部门:";
            this.lupControl2.Location = new System.Drawing.Point(37, 86);
            this.lupControl2.LookUpDataSource = null;
            this.lupControl2.LookUpDisplayField = null;
            this.lupControl2.LookUpKeyField = null;
            this.lupControl2.Name = "lupControl2";
            this.lupControl2.PopWidth = 150;
            this.lupControl2.Request = false;
            this.lupControl2.Size = new System.Drawing.Size(154, 22);
            this.lupControl2.TabIndex = 5;
            // 
            // lupControl3
            // 
            this.lupControl3.BackColor = System.Drawing.Color.Transparent;
            this.lupControl3.DataField = "F_StockMan";
            this.lupControl3.DataSource = null;
            this.lupControl3.DisplayCaption = "";
            this.lupControl3.EditLabel = "采购员:";
            this.lupControl3.Location = new System.Drawing.Point(200, 86);
            this.lupControl3.LookUpDataSource = null;
            this.lupControl3.LookUpDisplayField = null;
            this.lupControl3.LookUpKeyField = null;
            this.lupControl3.Name = "lupControl3";
            this.lupControl3.PopWidth = 150;
            this.lupControl3.Request = false;
            this.lupControl3.Size = new System.Drawing.Size(152, 22);
            this.lupControl3.TabIndex = 6;
            // 
            // editControl6
            // 
            this.editControl6.BackColor = System.Drawing.Color.Transparent;
            this.editControl6.DataField = "F_ContractID";
            this.editControl6.DataSource = null;
            this.editControl6.EditLabel = "合同号:";
            this.editControl6.Location = new System.Drawing.Point(358, 86);
            this.editControl6.Name = "editControl6";
            this.editControl6.Request = false;
            this.editControl6.Size = new System.Drawing.Size(161, 22);
            this.editControl6.TabIndex = 7;
            // 
            // dateControl3
            // 
            this.dateControl3.BackColor = System.Drawing.Color.Transparent;
            this.dateControl3.DataField = "F_PayDate";
            this.dateControl3.DataSource = null;
            this.dateControl3.EditLabel = "付款日期:";
            this.dateControl3.Location = new System.Drawing.Point(525, 86);
            this.dateControl3.Name = "dateControl3";
            this.dateControl3.Request = true;
            this.dateControl3.Size = new System.Drawing.Size(180, 22);
            this.dateControl3.TabIndex = 9;
            // 
            // lupControl4
            // 
            this.lupControl4.BackColor = System.Drawing.Color.Transparent;
            this.lupControl4.DataField = "F_PayMode";
            this.lupControl4.DataSource = null;
            this.lupControl4.DisplayCaption = "";
            this.lupControl4.EditLabel = "付款方式:";
            this.lupControl4.Location = new System.Drawing.Point(525, 56);
            this.lupControl4.LookUpDataSource = null;
            this.lupControl4.LookUpDisplayField = null;
            this.lupControl4.LookUpKeyField = null;
            this.lupControl4.Name = "lupControl4";
            this.lupControl4.PopWidth = 150;
            this.lupControl4.Request = true;
            this.lupControl4.Size = new System.Drawing.Size(177, 22);
            this.lupControl4.TabIndex = 10;
            // 
            // frmStockIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(809, 559);
            this.Name = "frmStockIn";
            this.Text = "采购进货单";
            this.Load += new System.EventHandler(this.frmStockOrder_Load);
            this.Shown += new System.EventHandler(this.frmStockIn_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmStockIn_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public myControl.lupControl lupControl1;
        public myControl.EditControl editControl5;
        public myControl.DateControl dateControl2;
        public myControl.EditControl editControl6;
        public myControl.lupControl lupControl3;
        public myControl.lupControl lupControl2;
        public myControl.DateControl dateControl3;
        public myControl.lupControl lupControl4;

    }
}
