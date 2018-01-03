namespace Sys
{
    partial class OpenWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("客户资料");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("供应商资料");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("物料资料");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("产品资料");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("仓库资料");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("员工资料");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("外加工厂商");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("基本资料", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("申购单");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("采购订单");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("采购进货单");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("采购付款单");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("采购退货单");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("采购管理", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("报价单");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("客户订单");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("发货通知单");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("发货单");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("收款单");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("销售退货单");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("客户费用");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("销售管理", new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21});
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("其它进仓单");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("其它出仓单");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("盘点单");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("调拔单");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("拆装单");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("仓库管理", new System.Windows.Forms.TreeNode[] {
            treeNode23,
            treeNode24,
            treeNode25,
            treeNode26,
            treeNode27});
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Bom单");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("生产计划单");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("生产任务单");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("生产状况表");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("领料单");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("补料单");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("退料单");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("产品进仓单");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("生产管理", new System.Windows.Forms.TreeNode[] {
            treeNode29,
            treeNode30,
            treeNode31,
            treeNode32,
            treeNode33,
            treeNode34,
            treeNode35,
            treeNode36});
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("委外加工单");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("委外领料单");
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("委外退料单");
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("委外进仓单");
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("委外退货单");
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("委外付款单");
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("委外加工", new System.Windows.Forms.TreeNode[] {
            treeNode38,
            treeNode39,
            treeNode40,
            treeNode41,
            treeNode42,
            treeNode43});
            this.tvForm = new System.Windows.Forms.TreeView();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tvForm
            // 
            this.tvForm.Location = new System.Drawing.Point(13, 13);
            this.tvForm.Name = "tvForm";
            treeNode1.Name = "节点2";
            treeNode1.Text = "客户资料";
            treeNode2.Name = "节点3";
            treeNode2.Text = "供应商资料";
            treeNode3.Name = "节点2";
            treeNode3.Text = "物料资料";
            treeNode4.Name = "节点3";
            treeNode4.Text = "产品资料";
            treeNode5.Name = "节点4";
            treeNode5.Text = "仓库资料";
            treeNode6.Name = "节点0";
            treeNode6.Text = "员工资料";
            treeNode7.Name = "节点9";
            treeNode7.Text = "外加工厂商";
            treeNode8.Name = "节点0";
            treeNode8.Text = "基本资料";
            treeNode9.Name = "节点8";
            treeNode9.Text = "申购单";
            treeNode10.Name = "节点4";
            treeNode10.Text = "采购订单";
            treeNode11.Name = "节点5";
            treeNode11.Text = "采购进货单";
            treeNode12.Name = "节点6";
            treeNode12.Text = "采购付款单";
            treeNode13.Name = "节点7";
            treeNode13.Text = "采购退货单";
            treeNode14.Name = "节点1";
            treeNode14.Text = "采购管理";
            treeNode15.Name = "节点0";
            treeNode15.Text = "报价单";
            treeNode16.Name = "节点12";
            treeNode16.Text = "客户订单";
            treeNode17.Name = "节点17";
            treeNode17.Text = "发货通知单";
            treeNode18.Name = "节点18";
            treeNode18.Text = "发货单";
            treeNode19.Name = "节点19";
            treeNode19.Text = "收款单";
            treeNode20.Name = "节点20";
            treeNode20.Text = "销售退货单";
            treeNode21.Name = "节点1";
            treeNode21.Text = "客户费用";
            treeNode22.Name = "节点10";
            treeNode22.Text = "销售管理";
            treeNode23.Name = "节点13";
            treeNode23.Text = "其它进仓单";
            treeNode24.Name = "节点14";
            treeNode24.Text = "其它出仓单";
            treeNode25.Name = "节点15";
            treeNode25.Text = "盘点单";
            treeNode26.Name = "节点16";
            treeNode26.Text = "调拔单";
            treeNode27.Name = "节点0";
            treeNode27.Text = "拆装单";
            treeNode28.Name = "节点11";
            treeNode28.Text = "仓库管理";
            treeNode29.Name = "节点2";
            treeNode29.Text = "Bom单";
            treeNode30.Name = "节点3";
            treeNode30.Text = "生产计划单";
            treeNode31.Name = "节点4";
            treeNode31.Text = "生产任务单";
            treeNode32.Name = "节点5";
            treeNode32.Text = "生产状况表";
            treeNode33.Name = "节点6";
            treeNode33.Text = "领料单";
            treeNode34.Name = "节点7";
            treeNode34.Text = "补料单";
            treeNode35.Name = "节点8";
            treeNode35.Text = "退料单";
            treeNode36.Name = "节点9";
            treeNode36.Text = "产品进仓单";
            treeNode37.Name = "节点0";
            treeNode37.Text = "生产管理";
            treeNode38.Name = "节点10";
            treeNode38.Text = "委外加工单";
            treeNode39.Name = "节点11";
            treeNode39.Text = "委外领料单";
            treeNode40.Name = "节点12";
            treeNode40.Text = "委外退料单";
            treeNode41.Name = "节点13";
            treeNode41.Text = "委外进仓单";
            treeNode42.Name = "节点14";
            treeNode42.Text = "委外退货单";
            treeNode43.Name = "节点15";
            treeNode43.Text = "委外付款单";
            treeNode44.Name = "节点1";
            treeNode44.Text = "委外加工";
            this.tvForm.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode14,
            treeNode22,
            treeNode28,
            treeNode37,
            treeNode44});
            this.tvForm.Size = new System.Drawing.Size(298, 280);
            this.tvForm.TabIndex = 0;
            this.tvForm.DoubleClick += new System.EventHandler(this.GetModule);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(155, 299);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "打开(&O)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.GetModule);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(236, 299);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // OpenWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 330);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tvForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打开窗体";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.TreeView tvForm;
    }
}