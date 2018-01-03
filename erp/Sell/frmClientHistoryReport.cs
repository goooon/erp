using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sell
{
    public partial class frmClientHistoryReport : Common.frmReport
    {
        public string strClientID = "";
        public frmClientHistoryReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 取查询参数
        /// </summary>
        /// <returns></returns>
        protected override Hashtable GetParm()
        {

            Hashtable parm = new Hashtable();
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            parm.Add("@ClientID", strClientID);
            return parm;
        }
    }
}

