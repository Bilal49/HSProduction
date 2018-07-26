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
    public partial class frmReportVenderLedger : Form
    {
        public frmReportVenderLedger()
        {
            InitializeComponent();
        }
      

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(txtVendorCode.Text))
                {
                    MessageBox.Show("Please Select Vendor Code", "Vendor Code Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                VendorManager v = new VendorManager();
                ReportDocument document = new ReportDocument();
                string path = Application.StartupPath + "/rpt/rptVenderLedger.rpt";
                document.Load(path);
                DataTable dtReport = new DataTable();
                dtReport = v.GetReportVendorLedger(txtVendorCode.Text, Convert.ToDateTime(dtpFromDate.Text), Convert.ToDateTime(dtpToDate.Text));
                document.SetDataSource(dtReport);
                Utility.SetReportDefaultParameter(ref document);
                if (document.ParameterFields["@FromDate"] != null)
                {
                    document.SetParameterValue("@FromDate", Convert.ToDateTime(dtpFromDate.Text));
                }
                if (document.ParameterFields["@ToDate"] != null)
                {
                    document.SetParameterValue("@ToDate", Convert.ToDateTime(dtpToDate.Text));
                }
                crystalRptCustomerLedger.ReportSource = document;
               // crystalRptCustomerLedger.Refresh();
               
            }
            catch (Exception ex)
            {
            }
        }

        private void btnVendorCodeSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetVendorSearch", null, "Vendor");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtVendorCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtVendorCode.Text = string.Empty;
                    txtVendorCode.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void crystalRptCustomerLedger_ReportRefresh(object source, CrystalDecisions.Windows.Forms.ViewerEventArgs e)
        {

        }
    }
}
