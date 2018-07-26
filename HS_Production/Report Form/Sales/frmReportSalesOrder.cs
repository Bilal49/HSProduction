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

    public partial class frmReportSalesOrder : Form
    {
        ReportDocument document = null;
        //SalesManager manageSales = new SalesManager();
        SalesOrderManager manageSalesOrder = new SalesOrderManager();
        public frmReportSalesOrder(ReportDocument pdocument = null)
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
                if (chkPrice.Checked)
                {
                    path = Application.StartupPath + "/rpt/Sales/rptSalesOrderWithPrice.rpt";
                }
                else
                {
                    path = Application.StartupPath + "/rpt/Sales/rptSalesOrder.rpt";
                }

               
                document.Load(path);
                DataTable dtReport = new DataTable();
                dtReport = manageSalesOrder.GetSalesOrderReport(Convert.ToDateTime(dtpFromDate.Text), Convert.ToDateTime(dtpToDate.Text), txtFOrder.Text, txtTOrder.Text, txtFromCustomerCode.Text, txtToCustomerCode.Text,-1);
                document.SetDataSource(dtReport);
                Utility.SetReportDefaultParameter(ref document);
                CrViewer.ReportSource = document;
                ////CrViewer.Refresh();
                ////document.PrintToPrinter(1, true, 0, 0);
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

        private void btnFPartySearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetCustomerSearch", null, "Customer");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtFromCustomerCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtFromCustomerCode.Text = string.Empty;
                    txtFromCustomerCode.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTPartySearch_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearch search = new frmSearch();
                search.getattributes("GetCustomerSearch", null, "Customer");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtToCustomerCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtToCustomerCode.Text = string.Empty;
                    txtToCustomerCode.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            document = null;
            CrViewer.ReportSource = null;
            dtpFromDate.Value = DateTime.Now;
            dtpToDate.Value = DateTime.Now;

            txtFromCustomerCode.Text = string.Empty;
            txtToCustomerCode.Text = string.Empty;

            txtFOrder.Text = string.Empty;
            txtTOrder.Text = string.Empty;

            chkPrice.Checked = false;

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

        private void btnFInvoiceSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetSearchSalesOrders", null, "Sales Orders");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtFOrder.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtFOrder.Text = string.Empty;
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTInvoiceSearch_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearch search = new frmSearch();
                search.getattributes("GetSearchSalesOrders", null, "Sales Order");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtTOrder.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtTOrder.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

