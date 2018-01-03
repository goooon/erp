namespace Report
{
    partial class frmAcceptAccount
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
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem3 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem4 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            this.TabPage = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gcSellOut = new DevExpress.XtraGrid.GridControl();
            this.gvSellOut = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gcAccept = new DevExpress.XtraGrid.GridControl();
            this.gvAccept = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.gcSellBack = new DevExpress.XtraGrid.GridControl();
            this.gvSellBack = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cbType = new myControl.cbControl();
            ((System.ComponentModel.ISupportInitialize)(this.rgOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabPage)).BeginInit();
            this.TabPage.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSellOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSellOut)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAccept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccept)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSellBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSellBack)).BeginInit();
            this.SuspendLayout();
            // 
            // rgOption
            // 
            this.rgOption.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgOption.Properties.Appearance.Options.UseBackColor = true;
            this.rgOption.Visible = false;
            // 
            // lbTitle
            // 
            this.lbTitle.Size = new System.Drawing.Size(101, 24);
            this.lbTitle.Text = "frmBase";
            // 
            // TabPage
            // 
            this.TabPage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TabPage.Location = new System.Drawing.Point(0, 303);
            this.TabPage.Name = "TabPage";
            this.TabPage.SelectedTabPage = this.xtraTabPage1;
            this.TabPage.Size = new System.Drawing.Size(890, 293);
            this.TabPage.TabIndex = 17;
            this.TabPage.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gcSellOut);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(881, 261);
            this.xtraTabPage1.Text = "销售发货";
            // 
            // gcSellOut
            // 
            this.gcSellOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSellOut.EmbeddedNavigator.Name = "";
            this.gcSellOut.Location = new System.Drawing.Point(0, 0);
            this.gcSellOut.MainView = this.gvSellOut;
            this.gcSellOut.Name = "gcSellOut";
            this.gcSellOut.Size = new System.Drawing.Size(881, 261);
            this.gcSellOut.TabIndex = 0;
            this.gcSellOut.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSellOut});
            // 
            // gvSellOut
            // 
            this.gvSellOut.GridControl = this.gcSellOut;
            this.gvSellOut.Name = "gvSellOut";
            this.gvSellOut.OptionsBehavior.Editable = false;
            this.gvSellOut.OptionsCustomization.AllowFilter = false;
            this.gvSellOut.OptionsLayout.Columns.StoreAllOptions = true;
            this.gvSellOut.OptionsLayout.Columns.StoreAppearance = true;
            this.gvSellOut.OptionsLayout.StoreDataSettings = false;
            this.gvSellOut.OptionsLayout.StoreVisualOptions = false;
            this.gvSellOut.OptionsView.ColumnAutoWidth = false;
            this.gvSellOut.OptionsView.ShowAutoFilterRow = true;
            this.gvSellOut.OptionsView.ShowFooter = true;
            this.gvSellOut.OptionsView.ShowGroupPanel = false;
            this.gvSellOut.DoubleClick += new System.EventHandler(this.gvStockIn_DoubleClick);
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.gcAccept);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(881, 261);
            this.xtraTabPage2.Text = "销售收款";
            // 
            // gcAccept
            // 
            this.gcAccept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAccept.EmbeddedNavigator.Name = "";
            this.gcAccept.Location = new System.Drawing.Point(0, 0);
            this.gcAccept.MainView = this.gvAccept;
            this.gcAccept.Name = "gcAccept";
            this.gcAccept.Size = new System.Drawing.Size(881, 261);
            this.gcAccept.TabIndex = 1;
            this.gcAccept.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAccept});
            // 
            // gvAccept
            // 
            this.gvAccept.GridControl = this.gcAccept;
            this.gvAccept.Name = "gvAccept";
            this.gvAccept.OptionsBehavior.Editable = false;
            this.gvAccept.OptionsCustomization.AllowFilter = false;
            this.gvAccept.OptionsLayout.Columns.StoreAllOptions = true;
            this.gvAccept.OptionsLayout.Columns.StoreAppearance = true;
            this.gvAccept.OptionsLayout.StoreDataSettings = false;
            this.gvAccept.OptionsLayout.StoreVisualOptions = false;
            this.gvAccept.OptionsView.ColumnAutoWidth = false;
            this.gvAccept.OptionsView.ShowAutoFilterRow = true;
            this.gvAccept.OptionsView.ShowFooter = true;
            this.gvAccept.OptionsView.ShowGroupPanel = false;
            this.gvAccept.DoubleClick += new System.EventHandler(this.gvPay_DoubleClick);
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.gcSellBack);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(881, 261);
            this.xtraTabPage3.Text = "销售退货";
            // 
            // gcSellBack
            // 
            this.gcSellBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSellBack.EmbeddedNavigator.Name = "";
            this.gcSellBack.Location = new System.Drawing.Point(0, 0);
            this.gcSellBack.MainView = this.gvSellBack;
            this.gcSellBack.Name = "gcSellBack";
            this.gcSellBack.Size = new System.Drawing.Size(881, 261);
            this.gcSellBack.TabIndex = 1;
            this.gcSellBack.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSellBack});
            // 
            // gvSellBack
            // 
            this.gvSellBack.GridControl = this.gcSellBack;
            this.gvSellBack.Name = "gvSellBack";
            this.gvSellBack.OptionsBehavior.Editable = false;
            this.gvSellBack.OptionsCustomization.AllowFilter = false;
            this.gvSellBack.OptionsLayout.Columns.StoreAllOptions = true;
            this.gvSellBack.OptionsLayout.Columns.StoreAppearance = true;
            this.gvSellBack.OptionsLayout.StoreDataSettings = false;
            this.gvSellBack.OptionsLayout.StoreVisualOptions = false;
            this.gvSellBack.OptionsView.ColumnAutoWidth = false;
            this.gvSellBack.OptionsView.ShowAutoFilterRow = true;
            this.gvSellBack.OptionsView.ShowFooter = true;
            this.gvSellBack.OptionsView.ShowGroupPanel = false;
            this.gvSellBack.DoubleClick += new System.EventHandler(this.gvStockBack_DoubleClick);
            // 
            // cbType
            // 
            this.cbType.BackColor = System.Drawing.Color.Transparent;
            comboBoxItem3.Value = "按单据";
            comboBoxItem4.Value = "按明细";
            this.cbType.cbItem = new DevExpress.XtraEditors.Controls.ComboBoxItem[] {
        comboBoxItem3,
        comboBoxItem4};
            this.cbType.DataField = null;
            this.cbType.EditLabel = "统计类别:";
            this.cbType.EditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbType.Location = new System.Drawing.Point(731, 37);
            this.cbType.Name = "cbType";
            this.cbType.Request = false;
            this.cbType.Size = new System.Drawing.Size(150, 21);
            this.cbType.TabIndex = 18;
            this.cbType.SelectIndexChange += new myControl.SelectIndexChangeEventHandler(this.cbType_SelectIndexChange);
            // 
            // frmAcceptAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(890, 618);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.TabPage);
            this.Name = "frmAcceptAccount";
            this.Text = "应收款帐薄";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAcceptAccount_KeyDown);
            this.Controls.SetChildIndex(this.TabPage, 0);
            this.Controls.SetChildIndex(this.cbType, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rgOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabPage)).EndInit();
            this.TabPage.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSellOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSellOut)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcAccept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccept)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSellBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSellBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl TabPage;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraGrid.GridControl gcSellOut;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSellOut;
        private DevExpress.XtraGrid.GridControl gcAccept;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAccept;
        private DevExpress.XtraGrid.GridControl gcSellBack;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSellBack;
        private myControl.cbControl cbType;
    }
}
