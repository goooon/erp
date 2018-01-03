namespace Sell
{
    partial class frmSellOut
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
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem3 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem4 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            this.lupControl1 = new myControl.lupControl();
            this.editControl5 = new myControl.EditControl();
            this.lupControl2 = new myControl.lupControl();
            this.lupControl3 = new myControl.lupControl();
            this.editControl6 = new myControl.EditControl();
            this.dateControl2 = new myControl.DateControl();
            this.lupControl4 = new myControl.lupControl();
            this.lupControl5 = new myControl.lupControl();
            this.cbControl1 = new myControl.cbControl();
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
            this.dateControl1.Location = new System.Drawing.Point(624, 29);
            // 
            // editControl1
            // 
            this.editControl1.Location = new System.Drawing.Point(626, 0);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.OldLace;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.cbControl1);
            this.panelControl1.Controls.Add(this.lupControl5);
            this.panelControl1.Controls.Add(this.lupControl4);
            this.panelControl1.Controls.Add(this.dateControl2);
            this.panelControl1.Controls.Add(this.editControl6);
            this.panelControl1.Controls.Add(this.lupControl3);
            this.panelControl1.Controls.Add(this.lupControl2);
            this.panelControl1.Controls.Add(this.editControl5);
            this.panelControl1.Controls.Add(this.lupControl1);
            this.panelControl1.Location = new System.Drawing.Point(0, 26);
            this.panelControl1.Size = new System.Drawing.Size(822, 167);
            this.panelControl1.Controls.SetChildIndex(this.lbTitle, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.dateControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl5, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl2, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl3, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl6, 0);
            this.panelControl1.Controls.SetChildIndex(this.dateControl2, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl4, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl5, 0);
            this.panelControl1.Controls.SetChildIndex(this.cbControl1, 0);
            // 
            // lupControl1
            // 
            this.lupControl1.BackColor = System.Drawing.Color.Transparent;
            this.lupControl1.DataField = "F_ClientID";
            this.lupControl1.DisplayCaption = "";
            this.lupControl1.EditLabel = "客户:";
            this.lupControl1.Location = new System.Drawing.Point(25, 55);
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
            this.editControl5.EditLabel = "备注:";
            this.editControl5.Location = new System.Drawing.Point(25, 139);
            this.editControl5.Name = "editControl5";
            this.editControl5.Request = false;
            this.editControl5.Size = new System.Drawing.Size(668, 22);
            this.editControl5.TabIndex = 7;
            // 
            // lupControl2
            // 
            this.lupControl2.BackColor = System.Drawing.Color.Transparent;
            this.lupControl2.DataField = "F_DeptID";
            this.lupControl2.DisplayCaption = "";
            this.lupControl2.EditLabel = "部门:";
            this.lupControl2.Location = new System.Drawing.Point(25, 83);
            this.lupControl2.LookUpDataSource = null;
            this.lupControl2.LookUpDisplayField = null;
            this.lupControl2.LookUpKeyField = null;
            this.lupControl2.Name = "lupControl2";
            this.lupControl2.PopWidth = 150;
            this.lupControl2.Request = false;
            this.lupControl2.Size = new System.Drawing.Size(200, 22);
            this.lupControl2.TabIndex = 4;
            // 
            // lupControl3
            // 
            this.lupControl3.BackColor = System.Drawing.Color.Transparent;
            this.lupControl3.DataField = "F_Opertor";
            this.lupControl3.DisplayCaption = "";
            this.lupControl3.EditLabel = "业务员:";
            this.lupControl3.Location = new System.Drawing.Point(315, 83);
            this.lupControl3.LookUpDataSource = null;
            this.lupControl3.LookUpDisplayField = null;
            this.lupControl3.LookUpKeyField = null;
            this.lupControl3.Name = "lupControl3";
            this.lupControl3.PopWidth = 150;
            this.lupControl3.Request = false;
            this.lupControl3.Size = new System.Drawing.Size(188, 22);
            this.lupControl3.TabIndex = 5;
            // 
            // editControl6
            // 
            this.editControl6.BackColor = System.Drawing.Color.Transparent;
            this.editControl6.DataField = "F_ContractID";
            this.editControl6.EditLabel = "合同号:";
            this.editControl6.Location = new System.Drawing.Point(525, 83);
            this.editControl6.Name = "editControl6";
            this.editControl6.Request = false;
            this.editControl6.Size = new System.Drawing.Size(168, 24);
            this.editControl6.TabIndex = 6;
            // 
            // dateControl2
            // 
            this.dateControl2.BackColor = System.Drawing.Color.Transparent;
            this.dateControl2.DataField = "F_AcceptDate";
            this.dateControl2.EditLabel = "收款日期:";
            this.dateControl2.Location = new System.Drawing.Point(509, 56);
            this.dateControl2.Name = "dateControl2";
            this.dateControl2.Request = true;
            this.dateControl2.Size = new System.Drawing.Size(184, 21);
            this.dateControl2.TabIndex = 8;
            // 
            // lupControl4
            // 
            this.lupControl4.BackColor = System.Drawing.Color.Transparent;
            this.lupControl4.DataField = "F_AcceptMode";
            this.lupControl4.DisplayCaption = "";
            this.lupControl4.EditLabel = "收款方式:";
            this.lupControl4.Location = new System.Drawing.Point(301, 55);
            this.lupControl4.LookUpDataSource = null;
            this.lupControl4.LookUpDisplayField = null;
            this.lupControl4.LookUpKeyField = null;
            this.lupControl4.Name = "lupControl4";
            this.lupControl4.PopWidth = 150;
            this.lupControl4.Request = true;
            this.lupControl4.Size = new System.Drawing.Size(202, 22);
            this.lupControl4.TabIndex = 9;
            // 
            // lupControl5
            // 
            this.lupControl5.BackColor = System.Drawing.Color.Transparent;
            this.lupControl5.DataField = "F_CarryCompany";
            this.lupControl5.DisplayCaption = "";
            this.lupControl5.EditLabel = "货运公司:";
            this.lupControl5.Location = new System.Drawing.Point(0, 111);
            this.lupControl5.LookUpDataSource = null;
            this.lupControl5.LookUpDisplayField = null;
            this.lupControl5.LookUpKeyField = null;
            this.lupControl5.Name = "lupControl5";
            this.lupControl5.PopWidth = 150;
            this.lupControl5.Request = false;
            this.lupControl5.Size = new System.Drawing.Size(225, 22);
            this.lupControl5.TabIndex = 11;
            // 
            // cbControl1
            // 
            this.cbControl1.BackColor = System.Drawing.Color.Transparent;
            comboBoxItem1.Value = "销售发货出库";
            comboBoxItem2.Value = "零售出库";
            comboBoxItem3.Value = "业务出库";
            comboBoxItem4.Value = "代理商出库";
            this.cbControl1.cbItem = new DevExpress.XtraEditors.Controls.ComboBoxItem[] {
        comboBoxItem1,
        comboBoxItem2,
        comboBoxItem3,
        comboBoxItem4};
            this.cbControl1.DataField = "F_Type";
            this.cbControl1.EditLabel = "出库类型:";
            this.cbControl1.EditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbControl1.Location = new System.Drawing.Point(301, 113);
            this.cbControl1.Name = "cbControl1";
            this.cbControl1.Request = true;
            this.cbControl1.Size = new System.Drawing.Size(227, 21);
            this.cbControl1.TabIndex = 12;
            // 
            // frmSellOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(822, 540);
            this.Name = "frmSellOut";
            this.Text = "销售发货单";
            this.Load += new System.EventHandler(this.frmStockOrder_Load);
            this.Shown += new System.EventHandler(this.frmSellOut_Shown);
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
        public myControl.EditControl editControl6;
        public myControl.lupControl lupControl3;
        public myControl.lupControl lupControl2;
        public myControl.DateControl dateControl2;
        public myControl.lupControl lupControl4;
        public myControl.lupControl lupControl5;
        public myControl.cbControl cbControl1;

    }
}
