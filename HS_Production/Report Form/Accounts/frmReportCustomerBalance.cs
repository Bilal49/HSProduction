using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace FIL.Report_Form
{
    public partial class frmReportCustomerBalance : Form
    {
        public frmReportCustomerBalance()
        {
            InitializeComponent();
        }

        ReportDocument document = null;
      

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            try
            {
                AccountManager manageAccount = new AccountManager();
                document = new ReportDocument();
                string path = Application.StartupPath + "/rpt/Accounts/rptCustomerBalance.rpt";
                document.Load(path);
                DataTable dtReport = new DataTable();
                dtReport = manageAccount.GetReportCustomerBalance(dtpFromDate.Value);
                document.SetDataSource(dtReport);
                Utility.SetReportDefaultParameter(ref document);
                if (document.ParameterFields["CDate"] != null)
                {
                    document.SetParameterValue("CDate", dtpFromDate.Value);
                }
                crystalRptCustomerLedger.ReportSource = document;
                crystalRptCustomerLedger.Refresh();
                //document.PrintToPrinter(1, true, 0, 0);
            }
            catch (Exception ex)
            {
            }
        }

        private void crystalRptCustomerLedger_ReportRefresh(object source, CrystalDecisions.Windows.Forms.ViewerEventArgs e)
        {
            btnViewReport_Click(null, null);
           
        }
        private void frmReportCustomerBalance_Load(object sender, EventArgs e)
        {

        }
    }
}
