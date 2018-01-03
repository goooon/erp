namespace Sys
{
    partial class frmCompanyInfo
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
            this.dateControl1 = new myControl.DateControl();
            this.editControl6 = new myControl.EditControl();
            this.editControl5 = new myControl.EditControl();
            this.editControl4 = new myControl.EditControl();
            this.editControl3 = new myControl.EditControl();
            this.editControl2 = new myControl.EditControl();
            this.editControl1 = new myControl.EditControl();
            this.picLogo = new DevExpress.XtraEditors.PictureEdit();
            this.ckUse = new DevExpress.XtraEditors.CheckEdit();
            this.editControl7 = new myControl.EditControl();
            this.editControl8 = new myControl.EditControl();
            this.editControl9 = new myControl.EditControl();
            this.editControl10 = new myControl.EditControl();
            this.editControl11 = new myControl.EditControl();
            this.editControl12 = new myControl.EditControl();
            this.editControl13 = new myControl.EditControl();
            this.gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckUse.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnOK
            // 
            this.BtnOK.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Appearance.Options.UseFont = true;
            this.BtnOK.Location = new System.Drawing.Point(385, 364);
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(466, 364);
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.editControl13);
            this.gbox.Controls.Add(this.editControl12);
            this.gbox.Controls.Add(this.editControl11);
            this.gbox.Controls.Add(this.editControl10);
            this.gbox.Controls.Add(this.editControl9);
            this.gbox.Controls.Add(this.editControl8);
            this.gbox.Controls.Add(this.editControl7);
            this.gbox.Controls.Add(this.ckUse);
            this.gbox.Controls.Add(this.dateControl1);
            this.gbox.Controls.Add(this.editControl6);
            this.gbox.Controls.Add(this.editControl5);
            this.gbox.Controls.Add(this.editControl4);
            this.gbox.Controls.Add(this.editControl3);
            this.gbox.Controls.Add(this.editControl2);
            this.gbox.Controls.Add(this.editControl1);
            this.gbox.Controls.Add(this.picLogo);
            this.gbox.Size = new System.Drawing.Size(528, 338);
            // 
            // dateControl1
            // 
            this.dateControl1.BackColor = System.Drawing.Color.Transparent;
            this.dateControl1.DataField = "F_UseDate";
            this.dateControl1.EditLabel = "启用日期:";
            this.dateControl1.Location = new System.Drawing.Point(10, 303);
            this.dateControl1.Name = "dateControl1";
            this.dateControl1.Request = false;
            this.dateControl1.Size = new System.Drawing.Size(185, 21);
            this.dateControl1.TabIndex = 13;
            // 
            // editControl6
            // 
            this.editControl6.BackColor = System.Drawing.Color.Transparent;
            this.editControl6.DataField = "F_Email";
            this.editControl6.EditLabel = "邮箱:";
            this.editControl6.Location = new System.Drawing.Point(37, 276);
            this.editControl6.Name = "editControl6";
            this.editControl6.Request = false;
            this.editControl6.Size = new System.Drawing.Size(470, 21);
            this.editControl6.TabIndex = 12;
            // 
            // editControl5
            // 
            this.editControl5.BackColor = System.Drawing.Color.Transparent;
            this.editControl5.DataField = "F_Net";
            this.editControl5.EditLabel = "网址:";
            this.editControl5.Location = new System.Drawing.Point(37, 249);
            this.editControl5.Name = "editControl5";
            this.editControl5.Request = false;
            this.editControl5.Size = new System.Drawing.Size(470, 21);
            this.editControl5.TabIndex = 11;
            // 
            // editControl4
            // 
            this.editControl4.BackColor = System.Drawing.Color.Transparent;
            this.editControl4.DataField = "F_Adr";
            this.editControl4.EditLabel = "地址:";
            this.editControl4.Location = new System.Drawing.Point(37, 222);
            this.editControl4.Name = "editControl4";
            this.editControl4.Request = false;
            this.editControl4.Size = new System.Drawing.Size(470, 21);
            this.editControl4.TabIndex = 10;
            // 
            // editControl3
            // 
            this.editControl3.BackColor = System.Drawing.Color.Transparent;
            this.editControl3.DataField = "F_LinkMan";
            this.editControl3.EditLabel = "联系人:";
            this.editControl3.Location = new System.Drawing.Point(25, 195);
            this.editControl3.Name = "editControl3";
            this.editControl3.Request = false;
            this.editControl3.Size = new System.Drawing.Size(214, 21);
            this.editControl3.TabIndex = 9;
            // 
            // editControl2
            // 
            this.editControl2.BackColor = System.Drawing.Color.Transparent;
            this.editControl2.DataField = "F_Tel";
            this.editControl2.EditLabel = "联系电话1:";
            this.editControl2.Location = new System.Drawing.Point(6, 114);
            this.editControl2.Name = "editControl2";
            this.editControl2.Request = false;
            this.editControl2.Size = new System.Drawing.Size(233, 21);
            this.editControl2.TabIndex = 3;
            // 
            // editControl1
            // 
            this.editControl1.BackColor = System.Drawing.Color.Transparent;
            this.editControl1.DataField = "F_Company";
            this.editControl1.EditLabel = "企业名称:";
            this.editControl1.Location = new System.Drawing.Point(12, 50);
            this.editControl1.Name = "editControl1";
            this.editControl1.Request = true;
            this.editControl1.Size = new System.Drawing.Size(367, 21);
            this.editControl1.TabIndex = 1;
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(409, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(100, 96);
            this.picLogo.TabIndex = 22;
            // 
            // ckUse
            // 
            this.ckUse.Location = new System.Drawing.Point(385, 303);
            this.ckUse.Name = "ckUse";
            this.ckUse.Properties.Caption = "启用";
            this.ckUse.Size = new System.Drawing.Size(56, 19);
            this.ckUse.TabIndex = 14;
            // 
            // editControl7
            // 
            this.editControl7.BackColor = System.Drawing.Color.Transparent;
            this.editControl7.DataField = "F_Tel1";
            this.editControl7.EditLabel = "联系电话2:";
            this.editControl7.Location = new System.Drawing.Point(256, 114);
            this.editControl7.Name = "editControl7";
            this.editControl7.Request = false;
            this.editControl7.Size = new System.Drawing.Size(253, 21);
            this.editControl7.TabIndex = 4;
            // 
            // editControl8
            // 
            this.editControl8.BackColor = System.Drawing.Color.Transparent;
            this.editControl8.DataField = "F_Tel2";
            this.editControl8.EditLabel = "联系电话3:";
            this.editControl8.Location = new System.Drawing.Point(6, 141);
            this.editControl8.Name = "editControl8";
            this.editControl8.Request = false;
            this.editControl8.Size = new System.Drawing.Size(233, 21);
            this.editControl8.TabIndex = 5;
            // 
            // editControl9
            // 
            this.editControl9.BackColor = System.Drawing.Color.Transparent;
            this.editControl9.DataField = "F_ID";
            this.editControl9.EditLabel = "企业编号:";
            this.editControl9.Location = new System.Drawing.Point(12, 20);
            this.editControl9.Name = "editControl9";
            this.editControl9.Request = true;
            this.editControl9.Size = new System.Drawing.Size(367, 21);
            this.editControl9.TabIndex = 0;
            // 
            // editControl10
            // 
            this.editControl10.BackColor = System.Drawing.Color.Transparent;
            this.editControl10.DataField = "F_Fax";
            this.editControl10.EditLabel = "传真1:";
            this.editControl10.Location = new System.Drawing.Point(280, 141);
            this.editControl10.Name = "editControl10";
            this.editControl10.Request = false;
            this.editControl10.Size = new System.Drawing.Size(229, 21);
            this.editControl10.TabIndex = 6;
            // 
            // editControl11
            // 
            this.editControl11.BackColor = System.Drawing.Color.Transparent;
            this.editControl11.DataField = "F_Fax1";
            this.editControl11.EditLabel = "传真2:";
            this.editControl11.Location = new System.Drawing.Point(30, 168);
            this.editControl11.Name = "editControl11";
            this.editControl11.Request = false;
            this.editControl11.Size = new System.Drawing.Size(209, 21);
            this.editControl11.TabIndex = 7;
            // 
            // editControl12
            // 
            this.editControl12.BackColor = System.Drawing.Color.Transparent;
            this.editControl12.DataField = "F_Fax2";
            this.editControl12.EditLabel = "传真3:";
            this.editControl12.Location = new System.Drawing.Point(280, 168);
            this.editControl12.Name = "editControl12";
            this.editControl12.Request = false;
            this.editControl12.Size = new System.Drawing.Size(229, 21);
            this.editControl12.TabIndex = 8;
            // 
            // editControl13
            // 
            this.editControl13.BackColor = System.Drawing.Color.Transparent;
            this.editControl13.DataField = "F_TaxID";
            this.editControl13.EditLabel = "税务编号:";
            this.editControl13.Location = new System.Drawing.Point(12, 80);
            this.editControl13.Name = "editControl13";
            this.editControl13.Request = false;
            this.editControl13.Size = new System.Drawing.Size(367, 21);
            this.editControl13.TabIndex = 2;
            // 
            // frmCompanyInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(553, 399);
            this.Name = "frmCompanyInfo";
            this.Text = "公司信息";
            this.gbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckUse.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private myControl.DateControl dateControl1;
        private myControl.EditControl editControl6;
        private myControl.EditControl editControl5;
        private myControl.EditControl editControl4;
        private myControl.EditControl editControl3;
        private myControl.EditControl editControl2;
        private myControl.EditControl editControl1;
        private DevExpress.XtraEditors.PictureEdit picLogo;
        private DevExpress.XtraEditors.CheckEdit ckUse;
        private myControl.EditControl editControl8;
        private myControl.EditControl editControl7;
        private myControl.EditControl editControl10;
        private myControl.EditControl editControl9;
        private myControl.EditControl editControl13;
        private myControl.EditControl editControl12;
        private myControl.EditControl editControl11;

    }
}
