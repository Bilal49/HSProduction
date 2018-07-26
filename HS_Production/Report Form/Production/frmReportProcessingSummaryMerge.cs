using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using FIL.App_Code.SaleMasterManager;
using FIL;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;


public partial class frmReportProcessingSummaryMerge : Form
{
    ReportDocument document = null;
    WarehouseManager manageWarehouse = new WarehouseManager();
    ProductManager manageProduct = new ProductManager();
    ProcessingManager manageProcess = new ProcessingManager();
    SalesOrderManager manageSO = new SalesOrderManager();
    //DataTable dsMain = null;
    BindingSource bsLookup = new BindingSource();
    //RepositoryItemCheckedComboBoxEdit reposityCheckEdit = null;
    string SelectedSO = string.Empty;
    //DataNavigator dataNav = null;
    public frmReportProcessingSummaryMerge(ReportDocument pdocument = null)
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

            string path = Application.StartupPath + "/rpt/Production/rptProcessLineSummaryMerge.rpt";
            document.Load(path);
            DataTable dtReport = new DataTable();
            dtReport = manageProcess.GetReportProcessingSummaryMerge( dtpFrom.Value,  dtpTo.Value );
            document.SetDataSource(dtReport);
            Utility.SetReportDefaultParameter(ref document);
            CrViewer.ReportSource = document;
        }
        catch (Exception ex)
        {
        }
    }

    private void crystalRptCustomerLedger_ReportRefresh(object source, CrystalDecisions.Windows.Forms.ViewerEventArgs e)
    {
        btnViewReport_Click(null, null);
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        document = null;
        CrViewer.ReportSource = null;
        dtpFromDate.Value = DateTime.Now;
        dtpToDate.Value = DateTime.Now;
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
        }
        catch (Exception ex)
        {
        }
    }

 

   
   
}

