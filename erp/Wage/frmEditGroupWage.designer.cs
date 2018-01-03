namespace Wage
{
    partial class frmEditGroupWage
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
            this.editControl9 = new myControl.EditControl();
            this.dateControl1 = new myControl.DateControl();
            this.spQty = new myControl.SpinControl();
            this.spPrice = new myControl.SpinControl();
            this.spMoney = new myControl.SpinControl();
            this.ckOption = new DevExpress.XtraEditors.CheckEdit();
            this.lupItem = new myControl.lupControl();
            this.lupDept = new myControl.lupControl();
            this.lupGroup = new myControl.lupControl();
            this.lupProcess = new myControl.lupControl();
            this.gcEmp = new DevExpress.XtraGrid.GridControl();
            this.gvEmp = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmp)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnOK
            // 
            this.BtnOK.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Appearance.Options.UseFont = true;
            this.BtnOK.Location = new System.Drawing.Point(388, 324);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(469, 324);
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.btnRemove);
            this.gbox.Controls.Add(this.btnAdd);
            this.gbox.Controls.Add(this.gcEmp);
            this.gbox.Controls.Add(this.lupProcess);
            this.gbox.Controls.Add(this.lupGroup);
            this.gbox.Controls.Add(this.lupDept);
            this.gbox.Controls.Add(this.lupItem);
            this.gbox.Controls.Add(this.spMoney);
            this.gbox.Controls.Add(this.spPrice);
            this.gbox.Controls.Add(this.spQty);
            this.gbox.Controls.Add(this.dateControl1);
            this.gbox.Controls.Add(this.editControl9);
            this.gbox.Location = new System.Drawing.Point(13, 12);
            this.gbox.Size = new System.Drawing.Size(531, 306);
            // 
            // ckCopy
            // 
            this.ckCopy.Location = new System.Drawing.Point(122, 328);
            this.ckCopy.Visible = true;
            // 
            // editControl9
            // 
            this.editControl9.BackColor = System.Drawing.Color.Transparent;
            this.editControl9.DataField = "F_Remark";
            this.editControl9.DataSource = null;
            this.editControl9.EditLabel = "备注:";
            this.editControl9.Location = new System.Drawing.Point(18, 263);
            this.editControl9.Name = "editControl9";
            this.editControl9.Request = false;
            this.editControl9.Size = new System.Drawing.Size(441, 21);
            this.editControl9.TabIndex = 9;
            // 
            // dateControl1
            // 
            this.dateControl1.BackColor = System.Drawing.Color.Transparent;
            this.dateControl1.DataField = "F_Time";
            this.dateControl1.DataSource = null;
            this.dateControl1.DisplayFormat = "d";
            this.dateControl1.EditLabel = "日期:";
            this.dateControl1.EditMask = "d";
            this.dateControl1.Location = new System.Drawing.Point(18, 29);
            this.dateControl1.Name = "dateControl1";
            this.dateControl1.Request = true;
            this.dateControl1.Size = new System.Drawing.Size(192, 21);
            this.dateControl1.TabIndex = 1;
            // 
            // spQty
            // 
            this.spQty.BackColor = System.Drawing.Color.Transparent;
            this.spQty.DataField = "F_Qty";
            this.spQty.DataSource = null;
            this.spQty.EditLabel = "数量:";
            this.spQty.Location = new System.Drawing.Point(18, 226);
            this.spQty.Name = "spQty";
            this.spQty.Size = new System.Drawing.Size(141, 21);
            this.spQty.TabIndex = 6;
            // 
            // spPrice
            // 
            this.spPrice.BackColor = System.Drawing.Color.Transparent;
            this.spPrice.DataField = "F_Price";
            this.spPrice.DataSource = null;
            this.spPrice.EditLabel = "工价:";
            this.spPrice.Location = new System.Drawing.Point(165, 226);
            this.spPrice.Name = "spPrice";
            this.spPrice.Size = new System.Drawing.Size(134, 21);
            this.spPrice.TabIndex = 7;
            // 
            // spMoney
            // 
            this.spMoney.BackColor = System.Drawing.Color.Transparent;
            this.spMoney.DataField = "F_Money";
            this.spMoney.DataSource = null;
            this.spMoney.EditLabel = "金额:";
            this.spMoney.Enabled = false;
            this.spMoney.Location = new System.Drawing.Point(305, 226);
            this.spMoney.Name = "spMoney";
            this.spMoney.Size = new System.Drawing.Size(154, 21);
            this.spMoney.TabIndex = 15;
            // 
            // ckOption
            // 
            this.ckOption.EditValue = true;
            this.ckOption.Location = new System.Drawing.Point(17, 328);
            this.ckOption.Name = "ckOption";
            this.ckOption.Properties.Caption = "保存后增加";
            this.ckOption.Size = new System.Drawing.Size(103, 19);
            this.ckOption.TabIndex = 2;
            this.ckOption.CheckedChanged += new System.EventHandler(this.ckOption_CheckedChanged);
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
            this.lupItem.Location = new System.Drawing.Point(18, 71);
            this.lupItem.LookUpDataSource = null;
            this.lupItem.LookUpDisplayField = null;
            this.lupItem.LookUpKeyField = null;
            this.lupItem.Name = "lupItem";
            this.lupItem.PopWidth = 150;
            this.lupItem.Request = true;
            this.lupItem.Size = new System.Drawing.Size(265, 22);
            this.lupItem.TabIndex = 2;
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
            this.lupDept.Location = new System.Drawing.Point(18, 109);
            this.lupDept.LookUpDataSource = null;
            this.lupDept.LookUpDisplayField = null;
            this.lupDept.LookUpKeyField = null;
            this.lupDept.Name = "lupDept";
            this.lupDept.PopWidth = 150;
            this.lupDept.Request = true;
            this.lupDept.Size = new System.Drawing.Size(265, 23);
            this.lupDept.TabIndex = 3;
            this.lupDept.ValueChanged += new myControl.SelectChangeEventHandler(this.lupDept_ValueChanged);
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
            this.lupGroup.Location = new System.Drawing.Point(18, 148);
            this.lupGroup.LookUpDataSource = null;
            this.lupGroup.LookUpDisplayField = null;
            this.lupGroup.LookUpKeyField = null;
            this.lupGroup.Name = "lupGroup";
            this.lupGroup.PopWidth = 150;
            this.lupGroup.Request = true;
            this.lupGroup.Size = new System.Drawing.Size(265, 23);
            this.lupGroup.TabIndex = 4;
            this.lupGroup.ValueChanged += new myControl.SelectChangeEventHandler(this.lupGroup_ValueChanged);
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
            this.lupProcess.Location = new System.Drawing.Point(18, 187);
            this.lupProcess.LookUpDataSource = null;
            this.lupProcess.LookUpDisplayField = null;
            this.lupProcess.LookUpKeyField = null;
            this.lupProcess.Name = "lupProcess";
            this.lupProcess.PopWidth = 150;
            this.lupProcess.Request = true;
            this.lupProcess.Size = new System.Drawing.Size(265, 23);
            this.lupProcess.TabIndex = 5;
            // 
            // gcEmp
            // 
            this.gcEmp.EmbeddedNavigator.Name = "";
            this.gcEmp.Location = new System.Drawing.Point(317, 48);
            this.gcEmp.MainView = this.gvEmp;
            this.gcEmp.Name = "gcEmp";
            this.gcEmp.Size = new System.Drawing.Size(185, 172);
            this.gcEmp.TabIndex = 16;
            this.gcEmp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEmp});
            // 
            // gvEmp
            // 
            this.gvEmp.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gvEmp.GridControl = this.gcEmp;
            this.gvEmp.Name = "gvEmp";
            this.gvEmp.OptionsBehavior.Editable = false;
            this.gvEmp.OptionsView.ColumnAutoWidth = false;
            this.gvEmp.OptionsView.ShowGroupPanel = false;
            this.gvEmp.OptionsView.ShowIndicator = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "员工";
            this.gridColumn1.FieldName = "F_Name";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 121;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(317, 21);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(49, 23);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "加入";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(372, 21);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(49, 23);
            this.btnRemove.TabIndex = 18;
            this.btnRemove.Text = "移除";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // frmEditGroupWage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(556, 357);
            this.Controls.Add(this.ckOption);
            this.Name = "frmEditGroupWage";
            this.Text = "工组计件--编辑";
            this.Controls.SetChildIndex(this.ckCopy, 0);
            this.Controls.SetChildIndex(this.ckOption, 0);
            this.Controls.SetChildIndex(this.BtnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.gbox, 0);
            this.gbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private myControl.EditControl editControl9;
        private myControl.DateControl dateControl1;
        private myControl.SpinControl spQty;
        private myControl.SpinControl spMoney;
        private myControl.SpinControl spPrice;
        private DevExpress.XtraEditors.CheckEdit ckOption;
        private myControl.lupControl lupDept;
        private myControl.lupControl lupItem;
        private myControl.lupControl lupProcess;
        private myControl.lupControl lupGroup;
        private DevExpress.XtraGrid.GridControl gcEmp;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEmp;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;

    }
}
