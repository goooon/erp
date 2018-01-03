namespace Wage
{
    partial class frmEditWage
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
            this.editControl9 = new myControl.EditControl();
            this.dateControl1 = new myControl.DateControl();
            this.spQty = new myControl.SpinControl();
            this.spPrice = new myControl.SpinControl();
            this.spMoney = new myControl.SpinControl();
            this.ckOption = new DevExpress.XtraEditors.CheckEdit();
            this.cbControl1 = new myControl.cbControl();
            this.lupItem = new myControl.lupControl();
            this.lupDept = new myControl.lupControl();
            this.lupEmp = new myControl.lupControl();
            this.lupProcess = new myControl.lupControl();
            this.lupGroup = new myControl.lupControl();
            this.gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckOption.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnOK
            // 
            this.BtnOK.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Appearance.Options.UseFont = true;
            this.BtnOK.Location = new System.Drawing.Point(333, 324);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(414, 324);
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.lupGroup);
            this.gbox.Controls.Add(this.lupProcess);
            this.gbox.Controls.Add(this.lupEmp);
            this.gbox.Controls.Add(this.lupDept);
            this.gbox.Controls.Add(this.lupItem);
            this.gbox.Controls.Add(this.cbControl1);
            this.gbox.Controls.Add(this.spMoney);
            this.gbox.Controls.Add(this.spPrice);
            this.gbox.Controls.Add(this.spQty);
            this.gbox.Controls.Add(this.dateControl1);
            this.gbox.Controls.Add(this.editControl9);
            this.gbox.Location = new System.Drawing.Point(13, 12);
            this.gbox.Size = new System.Drawing.Size(476, 304);
            // 
            // ckCopy
            // 
            this.ckCopy.Location = new System.Drawing.Point(120, 322);
            this.ckCopy.Size = new System.Drawing.Size(109, 19);
            this.ckCopy.Visible = true;
            // 
            // editControl9
            // 
            this.editControl9.BackColor = System.Drawing.Color.Transparent;
            this.editControl9.DataField = "F_Remark";
            this.editControl9.DataSource = null;
            this.editControl9.EditLabel = "备注:";
            this.editControl9.Location = new System.Drawing.Point(18, 254);
            this.editControl9.Name = "editControl9";
            this.editControl9.Request = false;
            this.editControl9.Size = new System.Drawing.Size(436, 21);
            this.editControl9.TabIndex = 10;
            // 
            // dateControl1
            // 
            this.dateControl1.BackColor = System.Drawing.Color.Transparent;
            this.dateControl1.DataField = "F_Time";
            this.dateControl1.DataSource = null;
            this.dateControl1.DisplayFormat = "d";
            this.dateControl1.EditLabel = "日期:";
            this.dateControl1.EditMask = "d";
            this.dateControl1.Location = new System.Drawing.Point(16, 20);
            this.dateControl1.Name = "dateControl1";
            this.dateControl1.Request = true;
            this.dateControl1.Size = new System.Drawing.Size(179, 21);
            this.dateControl1.TabIndex = 1;
            // 
            // spQty
            // 
            this.spQty.BackColor = System.Drawing.Color.Transparent;
            this.spQty.DataField = "F_Qty";
            this.spQty.DataSource = null;
            this.spQty.EditLabel = "数量:";
            this.spQty.Location = new System.Drawing.Point(18, 215);
            this.spQty.Name = "spQty";
            this.spQty.Size = new System.Drawing.Size(133, 21);
            this.spQty.TabIndex = 7;
            // 
            // spPrice
            // 
            this.spPrice.BackColor = System.Drawing.Color.Transparent;
            this.spPrice.DataField = "F_Price";
            this.spPrice.DataSource = null;
            this.spPrice.EditLabel = "工价:";
            this.spPrice.Location = new System.Drawing.Point(192, 215);
            this.spPrice.Name = "spPrice";
            this.spPrice.Size = new System.Drawing.Size(110, 21);
            this.spPrice.TabIndex = 8;
            // 
            // spMoney
            // 
            this.spMoney.BackColor = System.Drawing.Color.Transparent;
            this.spMoney.DataField = "F_Money";
            this.spMoney.DataSource = null;
            this.spMoney.EditLabel = "金额:";
            this.spMoney.Enabled = false;
            this.spMoney.Location = new System.Drawing.Point(320, 215);
            this.spMoney.Name = "spMoney";
            this.spMoney.Size = new System.Drawing.Size(134, 21);
            this.spMoney.TabIndex = 9;
            // 
            // ckOption
            // 
            this.ckOption.EditValue = true;
            this.ckOption.Location = new System.Drawing.Point(11, 322);
            this.ckOption.Name = "ckOption";
            this.ckOption.Properties.Caption = "保存后增加";
            this.ckOption.Size = new System.Drawing.Size(103, 19);
            this.ckOption.TabIndex = 2;
            this.ckOption.CheckedChanged += new System.EventHandler(this.ckOption_CheckedChanged);
            // 
            // cbControl1
            // 
            this.cbControl1.BackColor = System.Drawing.Color.Transparent;
            comboBoxItem1.Value = "计件";
            comboBoxItem2.Value = "计时";
            this.cbControl1.cbItem = new DevExpress.XtraEditors.Controls.ComboBoxItem[] {
        comboBoxItem1,
        comboBoxItem2};
            this.cbControl1.DataField = "F_Type";
            this.cbControl1.DataSource = null;
            this.cbControl1.EditLabel = "计算方式:";
            this.cbControl1.EditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbControl1.Location = new System.Drawing.Point(284, 20);
            this.cbControl1.Name = "cbControl1";
            this.cbControl1.Request = false;
            this.cbControl1.SelectedIndex = -1;
            this.cbControl1.Size = new System.Drawing.Size(170, 21);
            this.cbControl1.TabIndex = 2;
            // 
            // lupItem
            // 
            this.lupItem.BackColor = System.Drawing.Color.Transparent;
            this.lupItem.DataField = "F_ItemID";
            this.lupItem.DataSource = null;
            this.lupItem.DisplayCaption = "";
            this.lupItem.DropSQL = "";
            this.lupItem.EditLabel = "产品:";
            this.lupItem.InvokeClass = "";
            this.lupItem.LinkFields = null;
            this.lupItem.Location = new System.Drawing.Point(18, 59);
            this.lupItem.LookUpDataSource = null;
            this.lupItem.LookUpDisplayField = null;
            this.lupItem.LookUpKeyField = null;
            this.lupItem.Name = "lupItem";
            this.lupItem.PopWidth = 150;
            this.lupItem.Request = false;
            this.lupItem.Size = new System.Drawing.Size(322, 22);
            this.lupItem.TabIndex = 3;
            // 
            // lupDept
            // 
            this.lupDept.BackColor = System.Drawing.Color.Transparent;
            this.lupDept.DataField = "F_DeptID";
            this.lupDept.DataSource = null;
            this.lupDept.DisplayCaption = "";
            this.lupDept.DropSQL = "";
            this.lupDept.EditLabel = "部门:";
            this.lupDept.InvokeClass = "";
            this.lupDept.LinkFields = null;
            this.lupDept.Location = new System.Drawing.Point(18, 96);
            this.lupDept.LookUpDataSource = null;
            this.lupDept.LookUpDisplayField = null;
            this.lupDept.LookUpKeyField = null;
            this.lupDept.Name = "lupDept";
            this.lupDept.PopWidth = 150;
            this.lupDept.Request = false;
            this.lupDept.Size = new System.Drawing.Size(251, 22);
            this.lupDept.TabIndex = 4;
            this.lupDept.ValueChanged += new myControl.SelectChangeEventHandler(this.lupDept_ValueChanged);
            // 
            // lupEmp
            // 
            this.lupEmp.BackColor = System.Drawing.Color.Transparent;
            this.lupEmp.DataField = "F_EmpID";
            this.lupEmp.DataSource = null;
            this.lupEmp.DisplayCaption = "";
            this.lupEmp.DropSQL = "";
            this.lupEmp.EditLabel = "员工:";
            this.lupEmp.InvokeClass = "";
            this.lupEmp.LinkFields = null;
            this.lupEmp.Location = new System.Drawing.Point(18, 136);
            this.lupEmp.LookUpDataSource = null;
            this.lupEmp.LookUpDisplayField = null;
            this.lupEmp.LookUpKeyField = null;
            this.lupEmp.Name = "lupEmp";
            this.lupEmp.PopWidth = 150;
            this.lupEmp.Request = false;
            this.lupEmp.Size = new System.Drawing.Size(251, 22);
            this.lupEmp.TabIndex = 5;
            // 
            // lupProcess
            // 
            this.lupProcess.BackColor = System.Drawing.Color.Transparent;
            this.lupProcess.DataField = "F_ProcID";
            this.lupProcess.DataSource = null;
            this.lupProcess.DisplayCaption = "";
            this.lupProcess.DropSQL = "";
            this.lupProcess.EditLabel = "工序:";
            this.lupProcess.InvokeClass = "";
            this.lupProcess.LinkFields = null;
            this.lupProcess.Location = new System.Drawing.Point(18, 175);
            this.lupProcess.LookUpDataSource = null;
            this.lupProcess.LookUpDisplayField = null;
            this.lupProcess.LookUpKeyField = null;
            this.lupProcess.Name = "lupProcess";
            this.lupProcess.PopWidth = 150;
            this.lupProcess.Request = false;
            this.lupProcess.Size = new System.Drawing.Size(251, 22);
            this.lupProcess.TabIndex = 6;
            this.lupProcess.ValueChanged += new myControl.SelectChangeEventHandler(this.lupProcess_ValueChanged);
            // 
            // lupGroup
            // 
            this.lupGroup.BackColor = System.Drawing.Color.Transparent;
            this.lupGroup.DataField = "F_GroupID";
            this.lupGroup.DataSource = null;
            this.lupGroup.DisplayCaption = "";
            this.lupGroup.DropSQL = "";
            this.lupGroup.EditLabel = "工组:";
            this.lupGroup.InvokeClass = "";
            this.lupGroup.LinkFields = null;
            this.lupGroup.Location = new System.Drawing.Point(275, 96);
            this.lupGroup.LookUpDataSource = null;
            this.lupGroup.LookUpDisplayField = null;
            this.lupGroup.LookUpKeyField = null;
            this.lupGroup.Name = "lupGroup";
            this.lupGroup.PopWidth = 150;
            this.lupGroup.Request = false;
            this.lupGroup.Size = new System.Drawing.Size(195, 23);
            this.lupGroup.TabIndex = 11;
            this.lupGroup.TabStop = false;
            // 
            // frmEditWage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(501, 358);
            this.Controls.Add(this.ckOption);
            this.Name = "frmEditWage";
            this.Text = "个人计件--编辑";
            this.Controls.SetChildIndex(this.ckCopy, 0);
            this.Controls.SetChildIndex(this.BtnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.ckOption, 0);
            this.Controls.SetChildIndex(this.gbox, 0);
            this.gbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckOption.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private myControl.EditControl editControl9;
        private myControl.DateControl dateControl1;
        private myControl.SpinControl spQty;
        private myControl.SpinControl spMoney;
        private myControl.SpinControl spPrice;
        private myControl.cbControl cbControl1;
        public DevExpress.XtraEditors.CheckEdit ckOption;
        private myControl.lupControl lupDept;
        private myControl.lupControl lupItem;
        private myControl.lupControl lupProcess;
        private myControl.lupControl lupEmp;
        private myControl.lupControl lupGroup;

    }
}
