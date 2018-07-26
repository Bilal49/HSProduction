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
using FIL;


    public partial class frmReportSalesDetailByType : Form
    {
        ReportDocument document = null;
       
        SalesManager manageSales = new SalesManager();
        Smartworks.DAL dataAcess = new Smartworks.DAL();
       
        public frmReportSalesDetailByType()
        {
            InitializeComponent();
            
        }

       
        
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCustomerCode.Text))
                {
                    MessageBox.Show("Please Select Party Name", "Party Name Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbProductType.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Product Type", "Product Type is  Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                document = new ReportDocument();
                string path = string.Empty;
                path = Application.StartupPath + "/rpt/Sales/rptSalesDetailByType.rpt";
               

                document.Load(path);
                DataTable dtReport = new DataTable();
                dtReport = manageSales.GetSalesDetailTypeReport(Convert.ToDateTime(dtpFromDate.Text), Convert.ToDateTime(dtpToDate.Text), txtCustomerCode.Text, txtCustomerCode.Text, Convert.ToInt32(cmbProductType.SelectedValue));
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
                search.getattributes("GetCustomerSearch", null, "Party Names");
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

            txtCustomerCode.Text = string.Empty;
            txtToVendorCode.Text = string.Empty;

            cmbProductType.SelectedIndex = 0;


            dtpFromDate.Focus();

        }

        private void frmReportStockInn_Load(object sender, EventArgs e)
        {
            try
            {
                FillDropDown();
                if (document != null)
                {
                    CrViewer.ReportSource = document;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void FillDropDown()
        {
            ProductManager manageProduct = new ProductManager();
            
            DataTable dtProductType = new DataTable();
            dtProductType = manageProduct.GetProductTypeList();
            DataRow drType = dtProductType.NewRow();
            drType["ProductTypeId"] = -1;
            drType["ProductType"] = "---Select Type---";
            dtProductType.Rows.InsertAt(drType, 0);
            cmbProductType.DataSource = dtProductType;
            cmbProductType.DisplayMember = "ProductType";
            cmbProductType.ValueMember = "ProductTypeId";
        }

        private void btnFInvoiceSearch_Click(object sender, EventArgs e)
        {
            

            //try
            //{
            //    frmSearch search = new frmSearch();
            //    search.getattributes("GetSearchInvoices", null, "Invoices");
            //    search.ShowDialog();
            //    if (!string.IsNullOrEmpty(MainForm.Searched_Id))
            //    {
            //        txtFInvoice.Text = MainForm.Searched_Id;
            //        MainForm.Searched_Id = string.Empty;
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnTInvoiceSearch_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    frmSearch search = new frmSearch();
            //    search.getattributes("GetSearchInvoices", null, "Invoices");
            //    search.ShowDialog();
            //    if (!string.IsNullOrEmpty(MainForm.Searched_Id))
            //    {
            //        txtTInvoice.Text = MainForm.Searched_Id;
            //        MainForm.Searched_Id = string.Empty;
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void txtFromVendorCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {

                DataTable dtCustomer = dataAcess.getDataTable("SELECT  * FROM dbo.Customer WHERE Code = '" + txtCustomerCode.Text + "' ");
                if (dtCustomer.Rows.Count > 0)
                {
                    txtCustomerName.Text = dtCustomer.Rows[0]["CustomerName"].ToString();
                }
                else
                {
                    txtCustomerName.Text = string.Empty;
                }

            }
            else
            {
                txtCustomerName.Text = string.Empty;
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

