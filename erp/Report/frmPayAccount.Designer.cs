namespace Report
{
    partial class frmPayAccount
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem1 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem2 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayAccount));
            this.TabPage = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gcStockIn = new DevExpress.XtraGrid.GridControl();
            this.gvStockIn = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gcPay = new DevExpress.XtraGrid.GridControl();
            this.gvPay = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.gcStockBack = new DevExpress.XtraGrid.GridControl();
            this.gvStockBack = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cbType = new myControl.cbControl();
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            this.printableComponentLink2 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            this.printableComponentLink3 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rgOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabPage)).BeginInit();
            this.TabPage.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcStockIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStockIn)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPay)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcStockBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStockBack)).BeginInit();
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
            this.TabPage.Location = new System.Drawing.Point(0, 261);
            this.TabPage.Name = "TabPage";
            this.TabPage.SelectedTabPage = this.xtraTabPage1;
            this.TabPage.Size = new System.Drawing.Size(901, 317);
            this.TabPage.TabIndex = 17;
            this.TabPage.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gcStockIn);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(892, 285);
            this.xtraTabPage1.Text = "采购进货";
            // 
            // gcStockIn
            // 
            this.gcStockIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcStockIn.EmbeddedNavigator.Name = "";
            this.gcStockIn.Location = new System.Drawing.Point(0, 0);
            this.gcStockIn.MainView = this.gvStockIn;
            this.gcStockIn.Name = "gcStockIn";
            this.gcStockIn.Size = new System.Drawing.Size(892, 285);
            this.gcStockIn.TabIndex = 0;
            this.gcStockIn.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvStockIn});
            // 
            // gvStockIn
            // 
            this.gvStockIn.GridControl = this.gcStockIn;
            this.gvStockIn.Name = "gvStockIn";
            this.gvStockIn.OptionsBehavior.Editable = false;
            this.gvStockIn.OptionsCustomization.AllowFilter = false;
            this.gvStockIn.OptionsLayout.Columns.StoreAllOptions = true;
            this.gvStockIn.OptionsLayout.Columns.StoreAppearance = true;
            this.gvStockIn.OptionsLayout.StoreDataSettings = false;
            this.gvStockIn.OptionsLayout.StoreVisualOptions = false;
            this.gvStockIn.OptionsView.ColumnAutoWidth = false;
            this.gvStockIn.OptionsView.ShowAutoFilterRow = true;
            this.gvStockIn.OptionsView.ShowFooter = true;
            this.gvStockIn.OptionsView.ShowGroupPanel = false;
            this.gvStockIn.DoubleClick += new System.EventHandler(this.gvStockIn_DoubleClick);
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.gcPay);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(892, 285);
            this.xtraTabPage2.Text = "采购付款";
            // 
            // gcPay
            // 
            this.gcPay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPay.EmbeddedNavigator.Name = "";
            this.gcPay.Location = new System.Drawing.Point(0, 0);
            this.gcPay.MainView = this.gvPay;
            this.gcPay.Name = "gcPay";
            this.gcPay.Size = new System.Drawing.Size(892, 285);
            this.gcPay.TabIndex = 1;
            this.gcPay.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPay});
            // 
            // gvPay
            // 
            this.gvPay.GridControl = this.gcPay;
            this.gvPay.Name = "gvPay";
            this.gvPay.OptionsBehavior.Editable = false;
            this.gvPay.OptionsCustomization.AllowFilter = false;
            this.gvPay.OptionsLayout.Columns.StoreAllOptions = true;
            this.gvPay.OptionsLayout.Columns.StoreAppearance = true;
            this.gvPay.OptionsLayout.StoreDataSettings = false;
            this.gvPay.OptionsLayout.StoreVisualOptions = false;
            this.gvPay.OptionsView.ColumnAutoWidth = false;
            this.gvPay.OptionsView.ShowAutoFilterRow = true;
            this.gvPay.OptionsView.ShowFooter = true;
            this.gvPay.OptionsView.ShowGroupPanel = false;
            this.gvPay.DoubleClick += new System.EventHandler(this.gvPay_DoubleClick);
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.gcStockBack);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(892, 285);
            this.xtraTabPage3.Text = "采购退货";
            // 
            // gcStockBack
            // 
            this.gcStockBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcStockBack.EmbeddedNavigator.Name = "";
            this.gcStockBack.Location = new System.Drawing.Point(0, 0);
            this.gcStockBack.MainView = this.gvStockBack;
            this.gcStockBack.Name = "gcStockBack";
            this.gcStockBack.Size = new System.Drawing.Size(892, 285);
            this.gcStockBack.TabIndex = 1;
            this.gcStockBack.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvStockBack});
            // 
            // gvStockBack
            // 
            this.gvStockBack.GridControl = this.gcStockBack;
            this.gvStockBack.Name = "gvStockBack";
            this.gvStockBack.OptionsBehavior.Editable = false;
            this.gvStockBack.OptionsCustomization.AllowFilter = false;
            this.gvStockBack.OptionsLayout.Columns.StoreAllOptions = true;
            this.gvStockBack.OptionsLayout.Columns.StoreAppearance = true;
            this.gvStockBack.OptionsLayout.StoreDataSettings = false;
            this.gvStockBack.OptionsLayout.StoreVisualOptions = false;
            this.gvStockBack.OptionsView.ColumnAutoWidth = false;
            this.gvStockBack.OptionsView.ShowAutoFilterRow = true;
            this.gvStockBack.OptionsView.ShowFooter = true;
            this.gvStockBack.OptionsView.ShowGroupPanel = false;
            this.gvStockBack.DoubleClick += new System.EventHandler(this.gvStockBack_DoubleClick);
            // 
            // cbType
            // 
            this.cbType.BackColor = System.Drawing.Color.Transparent;
            comboBoxItem1.Value = "按单据";
            comboBoxItem2.Value = "按明细";
            this.cbType.cbItem = new DevExpress.XtraEditors.Controls.ComboBoxItem[] {
        comboBoxItem1,
        comboBoxItem2};
            this.cbType.DataField = null;
            this.cbType.EditLabel = "统计类别:";
            this.cbType.EditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbType.Location = new System.Drawing.Point(731, 37);
            this.cbType.Name = "cbType";
            this.cbType.Request = false;
            this.cbType.Size = new System.Drawing.Size(150, 21);
            this.cbType.TabIndex = 19;
            this.cbType.SelectIndexChange += new myControl.SelectIndexChangeEventHandler(this.cbType_SelectIndexChange);
            // 
            // printableComponentLink1
            // 
            this.printableComponentLink1.Component = this.gcStockIn;
            //this.printableComponentLink1.CustomPaperSize = new System.Drawing.Size(0, 0);
            this.printableComponentLink1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink1.ImageStream")));
            this.printableComponentLink1.PrintingSystem = this.printingSystem;
            //this.printableComponentLink1.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart;
            // 
            // printableComponentLink2
            // 
            this.printableComponentLink2.Component = this.gcPay;
            //this.printableComponentLink2.CustomPaperSize = new System.Drawing.Size(0, 0);
            this.printableComponentLink2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink2.ImageStream")));
            this.printableComponentLink2.PrintingSystem = this.printingSystem;
            //this.printableComponentLink2.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart;
            // 
            // printableComponentLink3
            // 
            this.printableComponentLink3.Component = this.gcStockBack;
            //this.printableComponentLink3.CustomPaperSize = new System.Drawing.Size(0, 0);
            this.printableComponentLink3.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink3.ImageStream")));
            this.printableComponentLink3.PrintingSystem = this.printingSystem;
            //this.printableComponentLink3.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart;
            // 
            // frmPayAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(901, 600);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.TabPage);
            this.Name = "frmPayAccount";
            this.Text = "应付款帐薄";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPayAccount_KeyDown);
            this.Controls.SetChildIndex(this.TabPage, 0);
            this.Controls.SetChildIndex(this.cbType, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rgOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabPage)).EndInit();
            this.TabPage.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcStockIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStockIn)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPay)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcStockBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStockBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl TabPage;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraGrid.GridControl gcStockIn;
        private DevExpress.XtraGrid.Views.Grid.GridView gvStockIn;
        private DevExpress.XtraGrid.GridControl gcPay;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPay;
        private DevExpress.XtraGrid.GridControl gcStockBack;
        private DevExpress.XtraGrid.Views.Grid.GridView gvStockBack;
        private myControl.cbControl cbType;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink2;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink3;

    }
}
