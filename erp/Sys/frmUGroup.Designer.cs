namespace Sys
{
    partial class frmUGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUGroup));
            this.barManager = new DevExpress.XtraBars.BarManager();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btDel = new DevExpress.XtraBars.BarButtonItem();
            this.btRight = new DevExpress.XtraBars.BarButtonItem();
            this.btExit = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tvRight = new System.Windows.Forms.TreeView();
            this.ckRight = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lbGroup = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btAdd,
            this.btEdit,
            this.btDel,
            this.btExit,
            this.btRight});
            this.barManager.MaxItemId = 5;
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 1";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btDel),
            new DevExpress.XtraBars.LinkPersistInfo(this.btRight, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btExit, true)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Custom 1";
            // 
            // btAdd
            // 
            this.btAdd.Caption = "新增";
            this.btAdd.Glyph = ((System.Drawing.Image)(resources.GetObject("btAdd.Glyph")));
            this.btAdd.Id = 0;
            this.btAdd.Name = "btAdd";
            this.btAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btAdd_ItemClick);
            // 
            // btEdit
            // 
            this.btEdit.Caption = "编辑";
            this.btEdit.Glyph = ((System.Drawing.Image)(resources.GetObject("btEdit.Glyph")));
            this.btEdit.Id = 1;
            this.btEdit.Name = "btEdit";
            this.btEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btEdit_ItemClick);
            // 
            // btDel
            // 
            this.btDel.Caption = "删除";
            this.btDel.Glyph = ((System.Drawing.Image)(resources.GetObject("btDel.Glyph")));
            this.btDel.Id = 2;
            this.btDel.Name = "btDel";
            this.btDel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btDel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btDel_ItemClick);
            // 
            // btRight
            // 
            this.btRight.Caption = "授权";
            this.btRight.Glyph = ((System.Drawing.Image)(resources.GetObject("btRight.Glyph")));
            this.btRight.Id = 4;
            this.btRight.Name = "btRight";
            this.btRight.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btRight.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btRight_ItemClick);
            // 
            // btExit
            // 
            this.btExit.Caption = "关闭";
            this.btExit.Glyph = ((System.Drawing.Image)(resources.GetObject("btExit.Glyph")));
            this.btExit.Id = 3;
            this.btExit.Name = "btExit";
            this.btExit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btExit_ItemClick);
            // 
            // tvRight
            // 
            this.tvRight.CheckBoxes = true;
            this.tvRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvRight.HideSelection = false;
            this.tvRight.Location = new System.Drawing.Point(137, 26);
            this.tvRight.Name = "tvRight";
            this.tvRight.Size = new System.Drawing.Size(286, 330);
            this.tvRight.TabIndex = 5;
            this.tvRight.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvRight_AfterCheck);
            this.tvRight.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvRight_AfterSelect);
            // 
            // ckRight
            // 
            this.ckRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.ckRight.Location = new System.Drawing.Point(423, 26);
            this.ckRight.Name = "ckRight";
            this.ckRight.Size = new System.Drawing.Size(135, 330);
            this.ckRight.TabIndex = 6;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lbGroup);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 26);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(137, 330);
            this.panelControl1.TabIndex = 7;
            // 
            // lbGroup
            // 
            this.lbGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbGroup.Location = new System.Drawing.Point(2, 2);
            this.lbGroup.Name = "lbGroup";
            this.lbGroup.Size = new System.Drawing.Size(133, 326);
            this.lbGroup.TabIndex = 5;
            this.lbGroup.SelectedIndexChanged += new System.EventHandler(this.lbGroup_SelectedIndexChanged);
            // 
            // frmUGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(558, 356);
            this.Controls.Add(this.tvRight);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ckRight);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmUGroup";
            this.Text = "用户组管理";
            this.Load += new System.EventHandler(this.frmUGroup_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUGroup_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraEditors.CheckedListBoxControl ckRight;
        private System.Windows.Forms.TreeView tvRight;
        private DevExpress.XtraBars.BarButtonItem btAdd;
        private DevExpress.XtraBars.BarButtonItem btEdit;
        private DevExpress.XtraBars.BarButtonItem btDel;
        private DevExpress.XtraBars.BarButtonItem btExit;
        private DevExpress.XtraBars.BarButtonItem btRight;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ListBoxControl lbGroup;
    }
}
