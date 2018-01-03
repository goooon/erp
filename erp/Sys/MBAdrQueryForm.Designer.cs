namespace Sys
{
    partial class MBAdrQueryForm
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
            this.winTextBox1 = new myControl.EditControl();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.editBox1 = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.editBox1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // winTextBox1
            // 
            this.winTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.winTextBox1.DataField = "";
            this.winTextBox1.DataSource = null;
            this.winTextBox1.EditLabel = "手机号码:";
            this.winTextBox1.Location = new System.Drawing.Point(72, 21);
            this.winTextBox1.Name = "winTextBox1";
            this.winTextBox1.Request = false;
            this.winTextBox1.Size = new System.Drawing.Size(206, 23);
            this.winTextBox1.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(284, 21);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(55, 23);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "查询结果:";
            // 
            // editBox1
            // 
            this.editBox1.Location = new System.Drawing.Point(46, 80);
            this.editBox1.Name = "editBox1";
            this.editBox1.Properties.AutoHeight = false;
            this.editBox1.Size = new System.Drawing.Size(340, 105);
            this.editBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.PeachPuff;
            this.label2.Location = new System.Drawing.Point(70, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(285, 74);
            this.label2.TabIndex = 4;
            this.label2.Text = "正在查询，请稍待...";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            // 
            // MBAdrQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(428, 249);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.editBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.winTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MBAdrQueryForm";
            this.Text = "号码归属地查询";
            ((System.ComponentModel.ISupportInitialize)(this.editBox1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private myControl.EditControl winTextBox1;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit editBox1;
        private System.Windows.Forms.Label label2;
    }
}
