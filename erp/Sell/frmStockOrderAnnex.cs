using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sell
{
    public partial class frmStockOrderAnnex : BaseClass.frmBase
    {
        public BindingSource binSource = null;
        public frmStockOrderAnnex()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 大二进制文件处理
        /// </summary>
        /// <param name="intFlag"></param>
        /// <param name="intTag"></param>
        private void SaveOrOpenFile(int intFlag,int intTag)
        {
            DataRow dr = ((DataRowView)binSource.Current).Row;
            DataLib.sysClass myClass = new DataLib.sysClass();
            if (intFlag == 0)
            {
                myClass.SaveFileToDr(dr, intTag);
            }
            else
            {
                myClass.LoadFileFromDr(dr, intTag);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveOrOpenFile(0, 1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveOrOpenFile(0, 2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveOrOpenFile(0, 3);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SaveOrOpenFile(0, 4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveOrOpenFile(1, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveOrOpenFile(1, 2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveOrOpenFile(1, 3);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SaveOrOpenFile(1, 4);
        }
    }
}

