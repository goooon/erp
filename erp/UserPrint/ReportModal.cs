using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using DevExpress.XtraReports.UI;
using System.Text;
using DevExpress.XtraPrinting.Localization; 

namespace UserPrint
{
    public partial class ReportModal : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportModal()
        {
            InitializeComponent();
        }

        public ReportModal(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
