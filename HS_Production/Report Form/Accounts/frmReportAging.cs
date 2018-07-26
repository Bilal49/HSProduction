using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;


public partial class frmReportAging : Form
{
    ReportDocument document = null;
    AccountManager manageAccount = new AccountManager();


    public frmReportAging(ReportDocument pdocument = null)
    {
        InitializeComponent();
        if (pdocument != null)
        {
            document = pdocument;
        }
    }

    private void btnViewReport_Click(object sender, EventArgs e)
    {
        try
        {
            document = new ReportDocument();
            string path = Application.StartupPath + "/rpt/Accounts/rptAgingSheet.rpt";
            document.Load(path);
            DataTable dtReport = new DataTable();

            dtReport = manageAccount.GetReportAgingBalanceSheet(dtpFromDate.Value);


            document.SetDataSource(dtReport);
            Utility.SetReportDefaultParameter(ref document);
            if (document.ParameterFields["CFromDate"] != null)
            {
                document.SetParameterValue("CFromDate", dtpFromDate.Value);
            }
            CrViewer.ReportSource = document;

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void crystalRptCustomerLedger_ReportRefresh(object source, CrystalDecisions.Windows.Forms.ViewerEventArgs e)
    {
        btnViewReport_Click(null, null);

    }

    private void dtpToDate_ValueChanged(object sender, EventArgs e)
    {

    }

    private void lblToDate_Click(object sender, EventArgs e)
    {

    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        document = null;
        CrViewer.ReportSource = null;
        dtpFromDate.Value = DateTime.Now;
        dtpFromDate.Focus();

    }

    private void frmReportStockInn_Load(object sender, EventArgs e)
    {
        try
        {
            if (document != null)
            {
                CrViewer.ReportSource = document;
            }
            //FillDropDown();

        }
        catch (Exception ex)
        {
        }
    }
    Smartworks.DAL dataAcess = new Smartworks.DAL();


    private void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAll.Checked)
        {
            dtpFromDate.Value = DateTime.Now;
            dtpFromDate.Enabled = false;
        }
        else
        {
            dtpFromDate.Enabled = true;
        }
    }

    
}

