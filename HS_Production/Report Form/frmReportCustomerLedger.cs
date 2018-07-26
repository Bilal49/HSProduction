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
    public partial class frmReportCustomerLedger : Form
    {
        public frmReportCustomerLedger()
        {
            InitializeComponent();
        }

        ReportDocument document = null;
        private void btnCustomerCodeSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetCustomerSearch", null, "Customer");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtCustomerCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtCustomerCode.Text = string.Empty;
                    txtCustomerCode.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCustomerCode.Text))
                {
                    MessageBox.Show("Please Enter Customer Code" , "Customer does Not Found." , MessageBoxButtons.OK , MessageBoxIcon.Warning);
                    return;
                }

                CustomerManager c = new CustomerManager();
                document = new ReportDocument();
                string path = Application.StartupPath + "/rpt/rptCustomerLedger.rpt";
                document.Load(path);
                DataTable dtReport = new DataTable();
                dtReport = c.GetReportCustomerLedger(txtCustomerCode.Text,Convert.ToDateTime(dtpFromDate.Text),Convert.ToDateTime(dtpToDate.Text));
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
            //if(document != null)
            //{
            //    Utility.SetReportDefaultParameter(ref document);
            //}
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblToDate_Click(object sender, EventArgs e)
        {

        }
    }
}
