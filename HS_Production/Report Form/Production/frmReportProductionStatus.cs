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

    public partial class frmReportProductionStatus : Form
    {
        ReportDocument document = null;
        //SalesManager manageSales = new SalesManager();
        //SalesOrderManager manageSalesOrder = new SalesOrderManager();
        ProductionManager manageProduction = new ProductionManager();
        public frmReportProductionStatus(ReportDocument pdocument = null)
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
                string path = "";

                path = Application.StartupPath + "/rpt/Production/rptProductionStatus.rpt";
               
                document.Load(path);
                DataTable dtReport = new DataTable();
                dtReport = manageProduction.GetReportProductionStatus(Convert.ToDateTime(dtpFromDate.Text), Convert.ToDateTime(dtpToDate.Text));
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

