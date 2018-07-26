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
using FIL.App_Code.PurchaseManager;
using System.Data.SqlClient;

namespace FIL.Report_Form
{
    public partial class frmReportPurchaseOrder : Form
    {
        ReportDocument document = null;
        PurchaseOrderManager managePurchaseOrder = new PurchaseOrderManager();
        Smartworks.DAL dataAcess = new Smartworks.DAL();
        public frmReportPurchaseOrder(ReportDocument pdocument = null)
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
                string path = Application.StartupPath + "/rpt/Purchaserpt/rptPurchaseOrder.rpt";
                document.Load(path);
                DataTable dtReport = new DataTable();
                dtReport = managePurchaseOrder.GetPurchaseOrderReport(Convert.ToDateTime(dtpFromDate.Text), Convert.ToDateTime(dtpToDate.Text), txtFOrder.Text, txtTOrder.Text, txtFromVendorCode.Text, txtToVendorCode.Text , -1);
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
                search.getattributes("GetVendorSearch", null, "Party Names");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtFromVendorCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtFromVendorCode.Text = string.Empty;
                    txtFromVendorCode.Focus();
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
                search.getattributes("GetVendorSearch", null, "Party Names");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtToVendorCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtToVendorCode.Text = string.Empty;
                    txtToVendorCode.Focus();
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

            txtFromVendorCode.Text = string.Empty;
            txtToVendorCode.Text = string.Empty;

            txtFOrder.Text = string.Empty;
            txtTOrder.Text = string.Empty;

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
                search.getattributes("GetSearchPurchaseOrders", null, "Purchase Orders");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtFOrder.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
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
                search.getattributes("GetSearchPurchaseOrders", null, "Purchase Orders");
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

        private void txtFromVendorCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFromVendorCode.Text))
            {

                DataTable dtVendor = dataAcess.getDataTable("SELECT  * FROM dbo.Vendor WHERE Code = '" + txtFromVendorCode.Text + "' ");
                if (dtVendor.Rows.Count > 0)
                {
                    txtFVendorName.Text = dtVendor.Rows[0]["VendorName"].ToString();
                }

            }
            else
            {
                txtFVendorName.Text = string.Empty;
            }
        }

        private void txtToVendorCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtToVendorCode.Text))
            {

                DataTable dtVendor = dataAcess.getDataTable("SELECT  * FROM dbo.Vendor WHERE Code = '" + txtToVendorCode.Text + "' ");
                if (dtVendor.Rows.Count > 0)
                {
                    txtTVendorName.Text = dtVendor.Rows[0]["VendorName"].ToString();
                }

            }
            else
            {
                txtTVendorName.Text = string.Empty;
            }
        }
    }
}
