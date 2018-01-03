namespace JXC
{
    partial class frmFindBill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFindBill));
            this.gcMain = new DevExpress.XtraGrid.GridControl();
            this.gvMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rgOption = new DevExpress.XtraEditors.RadioGroup();
            this.cbType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sbAdd = new DevExpress.XtraEditors.SimpleButton();
            this.TabControl = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.txtValue = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.spValue = new DevExpress.XtraEditors.SpinEdit();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.dtValue = new DevExpress.XtraEditors.DateEdit();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.rgBoon = new DevExpress.XtraEditors.RadioGroup();
            this.lbField = new System.Windows.Forms.Label();
            this.cbEqule = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gcField = new DevExpress.XtraGrid.GridControl();
            this.gvField = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sbFind = new DevExpress.XtraEditors.SimpleButton();
            this.sbReset = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.gcCon = new DevExpress.XtraGrid.GridControl();
            this.gvCon = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbType.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabControl)).BeginInit();
            this.TabControl.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spValue.Properties)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtValue.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtValue.Properties)).BeginInit();
            this.xtraTabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgBoon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEqule.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCon)).BeginInit();
            this.SuspendLayout();
            // 
            // gcMain
            // 
            this.gcMain.Location = new System.Drawing.Point(13, 227);
            this.gcMain.MainView = this.gvMain;
            this.gcMain.Name = "gcMain";
            this.gcMain.Size = new System.Drawing.Size(646, 185);
            this.gcMain.TabIndex = 0;
            this.gcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMain});
            // 
            // gvMain
            // 
            this.gvMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn10,
            this.gridColumn8,
            this.gridColumn9});
            this.gvMain.GridControl = this.gcMain;
            this.gvMain.Name = "gvMain";
            this.gvMain.OptionsBehavior.Editable = false;
            this.gvMain.OptionsCustomization.AllowFilter = false;
            this.gvMain.OptionsView.ColumnAutoWidth = false;
            this.gvMain.OptionsView.ShowFooter = true;
            this.gvMain.OptionsView.ShowGroupPanel = false;
            this.gvMain.DoubleClick += new System.EventHandler(this.gvMain_DoubleClick);
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn3.Caption = "单号";
            this.gridColumn3.FieldName = "F_BillID";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn4.Caption = "日期";
            this.gridColumn4.FieldName = "F_Date";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn5.Caption = "开单人";
            this.gridColumn5.FieldName = "F_BillMan";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn6.Caption = "审核人";
            this.gridColumn6.FieldName = "F_CheckMan";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn7.Caption = "审核日期";
            this.gridColumn7.FieldName = "F_CheckDate";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn10.Caption = "审核标志";
            this.gridColumn10.FieldName = "F_Check";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn8.Caption = "名称";
            this.gridColumn8.FieldName = "F_Memo";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 2;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn9.Caption = "单据金额";
            this.gridColumn9.FieldName = "F_Money";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rgOption);
            this.groupBox1.Controls.Add(this.cbType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(646, 45);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // rgOption
            // 
            this.rgOption.EditValue = 0;
            this.rgOption.Location = new System.Drawing.Point(7, 14);
            this.rgOption.Name = "rgOption";
            this.rgOption.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgOption.Properties.Appearance.Options.UseBackColor = true;
            this.rgOption.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgOption.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "全部"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "采购"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "销售"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "仓库"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(4, "生产"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(5, "委外")});
            this.rgOption.Size = new System.Drawing.Size(390, 25);
            this.rgOption.TabIndex = 2;
            this.rgOption.SelectedIndexChanged += new System.EventHandler(this.rgOption_SelectedIndexChanged);
            // 
            // cbType
            // 
            this.cbType.Location = new System.Drawing.Point(504, 14);
            this.cbType.Name = "cbType";
            this.cbType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbType.Size = new System.Drawing.Size(126, 21);
            this.cbType.TabIndex = 1;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(439, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "业务类别:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sbAdd);
            this.groupBox2.Controls.Add(this.TabControl);
            this.groupBox2.Controls.Add(this.lbField);
            this.groupBox2.Controls.Add(this.cbEqule);
            this.groupBox2.Controls.Add(this.gcField);
            this.groupBox2.Location = new System.Drawing.Point(13, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 180);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "定义条件";
            // 
            // sbAdd
            // 
            this.sbAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbAdd.Appearance.Options.UseFont = true;
            this.sbAdd.Location = new System.Drawing.Point(229, 153);
            this.sbAdd.Name = "sbAdd";
            this.sbAdd.Size = new System.Drawing.Size(61, 23);
            this.sbAdd.TabIndex = 5;
            this.sbAdd.Text = "添加条件";
            this.sbAdd.Click += new System.EventHandler(this.sbAdd_Click);
            // 
            // TabControl
            // 
            this.TabControl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.TabControl.Appearance.Options.UseBackColor = true;
            this.TabControl.Location = new System.Drawing.Point(159, 75);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedTabPage = this.xtraTabPage1;
            this.TabControl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.TabControl.Size = new System.Drawing.Size(135, 76);
            this.TabControl.TabIndex = 4;
            this.TabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3,
            this.xtraTabPage4});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.txtValue);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(126, 67);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(8, 22);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(116, 21);
            this.txtValue.TabIndex = 0;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.spValue);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(126, 67);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // spValue
            // 
            this.spValue.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spValue.Location = new System.Drawing.Point(3, 22);
            this.spValue.Name = "spValue";
            this.spValue.Size = new System.Drawing.Size(120, 21);
            this.spValue.TabIndex = 0;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.dtValue);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(126, 67);
            this.xtraTabPage3.Text = "xtraTabPage3";
            // 
            // dtValue
            // 
            this.dtValue.EditValue = null;
            this.dtValue.Location = new System.Drawing.Point(4, 22);
            this.dtValue.Name = "dtValue";
            this.dtValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtValue.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtValue.Size = new System.Drawing.Size(120, 21);
            this.dtValue.TabIndex = 0;
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.rgBoon);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(126, 67);
            this.xtraTabPage4.Text = "xtraTabPage4";
            // 
            // rgBoon
            // 
            this.rgBoon.EditValue = true;
            this.rgBoon.Location = new System.Drawing.Point(23, 3);
            this.rgBoon.Name = "rgBoon";
            this.rgBoon.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgBoon.Properties.Appearance.Options.UseBackColor = true;
            this.rgBoon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgBoon.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "是"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "否")});
            this.rgBoon.Size = new System.Drawing.Size(76, 58);
            this.rgBoon.TabIndex = 0;
            // 
            // lbField
            // 
            this.lbField.AutoSize = true;
            this.lbField.Location = new System.Drawing.Point(159, 18);
            this.lbField.Name = "lbField";
            this.lbField.Size = new System.Drawing.Size(0, 12);
            this.lbField.TabIndex = 3;
            // 
            // cbEqule
            // 
            this.cbEqule.EditValue = "等于";
            this.cbEqule.Location = new System.Drawing.Point(159, 48);
            this.cbEqule.Name = "cbEqule";
            this.cbEqule.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbEqule.Properties.Items.AddRange(new object[] {
            "等于",
            "大于",
            "大于等于",
            "小于",
            "小于等于",
            "包含",
            "不包含"});
            this.cbEqule.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbEqule.Size = new System.Drawing.Size(131, 21);
            this.cbEqule.TabIndex = 2;
            // 
            // gcField
            // 
            this.gcField.Location = new System.Drawing.Point(7, 17);
            this.gcField.MainView = this.gvField;
            this.gcField.Name = "gcField";
            this.gcField.Size = new System.Drawing.Size(145, 157);
            this.gcField.TabIndex = 1;
            this.gcField.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvField});
            // 
            // gvField
            // 
            this.gvField.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gvField.GridControl = this.gcField;
            this.gvField.Name = "gvField";
            this.gvField.OptionsBehavior.Editable = false;
            this.gvField.OptionsCustomization.AllowFilter = false;
            this.gvField.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvField.OptionsView.ShowGroupPanel = false;
            this.gvField.OptionsView.ShowHorzLines = false;
            this.gvField.OptionsView.ShowIndicator = false;
            this.gvField.OptionsView.ShowVertLines = false;
            this.gvField.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvField_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "字段列表";
            this.gridColumn1.FieldName = "F_Caption";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // sbFind
            // 
            this.sbFind.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbFind.Appearance.Options.UseFont = true;
            this.sbFind.Location = new System.Drawing.Point(597, 58);
            this.sbFind.Name = "sbFind";
            this.sbFind.Size = new System.Drawing.Size(62, 23);
            this.sbFind.TabIndex = 4;
            this.sbFind.Text = "查找(&F)";
            this.sbFind.Click += new System.EventHandler(this.sbFind_Click);
            // 
            // sbReset
            // 
            this.sbReset.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbReset.Appearance.Options.UseFont = true;
            this.sbReset.Location = new System.Drawing.Point(597, 87);
            this.sbReset.Name = "sbReset";
            this.sbReset.Size = new System.Drawing.Size(62, 23);
            this.sbReset.TabIndex = 5;
            this.sbReset.Text = "重置(&S)";
            this.sbReset.Click += new System.EventHandler(this.sbReset_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new System.Drawing.Point(597, 151);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(62, 23);
            this.simpleButton2.TabIndex = 6;
            this.simpleButton2.Text = "显示(&V)";
            // 
            // gcCon
            // 
            this.gcCon.Location = new System.Drawing.Point(320, 63);
            this.gcCon.MainView = this.gvCon;
            this.gcCon.Name = "gcCon";
            this.gcCon.Size = new System.Drawing.Size(263, 158);
            this.gcCon.TabIndex = 7;
            this.gcCon.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCon});
            // 
            // gvCon
            // 
            this.gvCon.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2});
            this.gvCon.GridControl = this.gcCon;
            this.gvCon.Name = "gvCon";
            this.gvCon.OptionsBehavior.Editable = false;
            this.gvCon.OptionsCustomization.AllowFilter = false;
            this.gvCon.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvCon.OptionsView.ShowColumnHeaders = false;
            this.gvCon.OptionsView.ShowGroupPanel = false;
            this.gvCon.OptionsView.ShowHorzLines = false;
            this.gvCon.OptionsView.ShowIndicator = false;
            this.gvCon.OptionsView.ShowVertLines = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "已定义条件";
            this.gridColumn2.FieldName = "F_ConText";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "已定义条件:";
            // 
            // frmFindBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(671, 424);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gcCon);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.sbReset);
            this.Controls.Add(this.sbFind);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gcMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFindBill";
            this.Text = "业务查找";
            this.Load += new System.EventHandler(this.frmFindBill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbType.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabControl)).EndInit();
            this.TabControl.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtValue.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spValue.Properties)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtValue.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtValue.Properties)).EndInit();
            this.xtraTabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgBoon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEqule.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ComboBoxEdit cbType;
        private DevExpress.XtraEditors.RadioGroup rgOption;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.SimpleButton sbFind;
        private DevExpress.XtraEditors.SimpleButton sbReset;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraGrid.GridControl gcField;
        private DevExpress.XtraGrid.Views.Grid.GridView gvField;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.Label lbField;
        private DevExpress.XtraEditors.ComboBoxEdit cbEqule;
        private DevExpress.XtraTab.XtraTabControl TabControl;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.TextEdit txtValue;
        private DevExpress.XtraEditors.SpinEdit spValue;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraEditors.DateEdit dtValue;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private DevExpress.XtraEditors.RadioGroup rgBoon;
        private DevExpress.XtraGrid.GridControl gcCon;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCon;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.SimpleButton sbAdd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private System.Windows.Forms.Label label2;
    }
}
