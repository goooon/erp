namespace Sys
{
    partial class frmRight
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
            this.gcRight = new DevExpress.XtraGrid.GridControl();
            this.gvRight = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvRightDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcGroup = new DevExpress.XtraGrid.GridControl();
            this.gvGroup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ckAll = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gcRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcRight
            // 
            this.gcRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gcRight.EmbeddedNavigator.Name = "";
            this.gcRight.Location = new System.Drawing.Point(193, 71);
            this.gcRight.MainView = this.gvRight;
            this.gcRight.Name = "gcRight";
            this.gcRight.Size = new System.Drawing.Size(562, 429);
            this.gcRight.TabIndex = 0;
            this.gcRight.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRight,
            this.gvRightDetail});
            // 
            // gvRight
            // 
            this.gvRight.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvRight.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvRight.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gvRight.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gvRight.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gvRight.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gvRight.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvRight.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvRight.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gvRight.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gvRight.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gvRight.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gvRight.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvRight.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gvRight.Appearance.Empty.Options.UseBackColor = true;
            this.gvRight.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gvRight.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gvRight.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gvRight.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvRight.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gvRight.Appearance.EvenRow.Options.UseForeColor = true;
            this.gvRight.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvRight.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvRight.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gvRight.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gvRight.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gvRight.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gvRight.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvRight.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gvRight.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gvRight.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gvRight.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gvRight.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(195)))));
            this.gvRight.Appearance.FixedLine.Options.UseBackColor = true;
            this.gvRight.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gvRight.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gvRight.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvRight.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvRight.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(109)))), ((int)(((byte)(189)))));
            this.gvRight.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(139)))), ((int)(((byte)(206)))));
            this.gvRight.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvRight.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvRight.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gvRight.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvRight.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvRight.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvRight.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gvRight.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gvRight.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gvRight.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gvRight.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvRight.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvRight.Appearance.GroupButton.Options.UseBackColor = true;
            this.gvRight.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gvRight.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvRight.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvRight.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gvRight.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gvRight.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gvRight.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gvRight.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvRight.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gvRight.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gvRight.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvRight.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gvRight.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvRight.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gvRight.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvRight.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvRight.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gvRight.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvRight.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gvRight.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gvRight.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gvRight.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvRight.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvRight.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gvRight.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.gvRight.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gvRight.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvRight.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvRight.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gvRight.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvRight.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvRight.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvRight.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvRight.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvRight.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gvRight.Appearance.OddRow.Options.UseBackColor = true;
            this.gvRight.Appearance.OddRow.Options.UseBorderColor = true;
            this.gvRight.Appearance.OddRow.Options.UseForeColor = true;
            this.gvRight.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gvRight.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gvRight.Appearance.Preview.Options.UseFont = true;
            this.gvRight.Appearance.Preview.Options.UseForeColor = true;
            this.gvRight.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gvRight.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gvRight.Appearance.Row.Options.UseBackColor = true;
            this.gvRight.Appearance.Row.Options.UseForeColor = true;
            this.gvRight.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gvRight.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gvRight.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gvRight.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gvRight.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gvRight.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvRight.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvRight.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gvRight.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gvRight.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gvRight.Appearance.VertLine.Options.UseBackColor = true;
            this.gvRight.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gvRight.GridControl = this.gcRight;
            this.gvRight.Name = "gvRight";
            this.gvRight.OptionsCustomization.AllowFilter = false;
            this.gvRight.OptionsCustomization.AllowSort = false;
            this.gvRight.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvRight.OptionsView.AllowCellMerge = true;
            this.gvRight.OptionsView.EnableAppearanceEvenRow = true;
            this.gvRight.OptionsView.EnableAppearanceOddRow = true;
            this.gvRight.OptionsView.ShowGroupPanel = false;
            this.gvRight.OptionsView.ShowIndicator = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn2.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn2.Caption = "模块名称";
            this.gridColumn2.FieldName = "F_Modal";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn3.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn3.Caption = "权限名称";
            this.gridColumn3.FieldName = "F_Name";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "权限";
            this.gridColumn4.FieldName = "F_Enable";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gvRightDetail
            // 
            this.gvRightDetail.GridControl = this.gcRight;
            this.gvRightDetail.Name = "gvRightDetail";
            // 
            // gcGroup
            // 
            this.gcGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gcGroup.EmbeddedNavigator.Name = "";
            this.gcGroup.Location = new System.Drawing.Point(12, 44);
            this.gcGroup.MainView = this.gvGroup;
            this.gcGroup.Name = "gcGroup";
            this.gcGroup.Size = new System.Drawing.Size(175, 456);
            this.gcGroup.TabIndex = 1;
            this.gcGroup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvGroup});
            // 
            // gvGroup
            // 
            this.gvGroup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gvGroup.GridControl = this.gcGroup;
            this.gvGroup.Name = "gvGroup";
            this.gvGroup.OptionsBehavior.Editable = false;
            this.gvGroup.OptionsCustomization.AllowFilter = false;
            this.gvGroup.OptionsCustomization.AllowSort = false;
            this.gvGroup.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvGroup.OptionsView.ShowGroupPanel = false;
            this.gvGroup.OptionsView.ShowIndicator = false;
            this.gvGroup.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvGroup_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "用户组";
            this.gridColumn1.FieldName = "F_Group";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.ckAll);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Controls.Add(this.btnDel);
            this.panelControl1.Controls.Add(this.btnEdit);
            this.panelControl1.Controls.Add(this.btnAdd);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(767, 38);
            this.panelControl1.TabIndex = 2;
            // 
            // ckAll
            // 
            this.ckAll.AutoSize = true;
            this.ckAll.Location = new System.Drawing.Point(492, 10);
            this.ckAll.Name = "ckAll";
            this.ckAll.Size = new System.Drawing.Size(48, 16);
            this.ckAll.TabIndex = 4;
            this.ckAll.Text = "全选";
            this.ckAll.UseVisualStyleBackColor = true;
            this.ckAll.CheckedChanged += new System.EventHandler(this.ckAll_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(333, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(153, 8);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(63, 23);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(84, 8);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(63, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(66, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "系统管理",
            "基本资料",
            "采购管理",
            "销售管理",
            "仓库管理",
            "生产管理",
            "委外加工",
            "工资管理",
            "财务管理",
            "出纳管理",
            "固定资产",
            "统计报表",
            "全部"});
            this.cbType.Location = new System.Drawing.Point(194, 45);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(158, 20);
            this.cbType.TabIndex = 3;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(373, 47);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "查看所有资料";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(475, 47);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(96, 16);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "引出报表资料";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(577, 47);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(72, 16);
            this.checkBox3.TabIndex = 6;
            this.checkBox3.Text = "打印报表";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(655, 47);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(108, 16);
            this.checkBox4.TabIndex = 7;
            this.checkBox4.Text = "反审后修改价格";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // frmRight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(767, 512);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gcGroup);
            this.Controls.Add(this.gcRight);
            this.Name = "frmRight";
            this.Text = "用户组管理";
            this.Load += new System.EventHandler(this.frmRight_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcRight;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRight;
        private DevExpress.XtraGrid.GridControl gcGroup;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGroup;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRightDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox ckAll;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
    }
}
