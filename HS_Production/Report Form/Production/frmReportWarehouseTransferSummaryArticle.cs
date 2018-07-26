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


    public partial class frmReportWarehouseTransferSummaryArticle : Form
    {
        ReportDocument document = null;
        WarehouseManager manageWarehouse = new WarehouseManager();
        public frmReportWarehouseTransferSummaryArticle(ReportDocument pdocument = null)
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
                ProductManager manageProduct = new ProductManager();
                if (Convert.ToInt32(cmbWarehouse.SelectedValue) < 0)
                {
                    MessageBox.Show("Please Select Department Name", "Depart is Required",MessageBoxButtons.OK , MessageBoxIcon.Warning);
                    cmbWarehouse.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtSONo.Text))
                {
                    MessageBox.Show("Please Select Sales Order No.", "Sales Order is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSONo.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtPCode.Text))
                {
                    MessageBox.Show("Please Select Article Code.", "Article Code is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPCode.Focus();
                    return;
                }
                document = new ReportDocument();
                int ProductId = -1;
                if (!string.IsNullOrEmpty(txtPCode.Text))
                {
                    ProductId = manageProduct.GetProductIdByCode(txtPCode.Text);
                }
                string path = Application.StartupPath + "/rpt/Production/rptWarehouseTransferSummaryArticle.rpt";
                document.Load(path);
                DataTable dtReport = new DataTable();
                dtReport = manageWarehouse.GetTransferSummaryReportForArticle(Convert.ToDateTime(dtpDate.Text), Convert.ToInt32(cmbWarehouse.SelectedValue), txtSONo.Text, ProductId);
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
            dtpDate.Value = DateTime.Now;
            cmbWarehouse.SelectedIndex = 0;
            txtSONo.Text = string.Empty;
            txtPCode.Text = string.Empty;
            dtpDate.Focus();
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

            DataTable dtWarehouse = manageWarehouse.GetWarehouseList();
            if (dtWarehouse.Rows.Count > 0)
            {
                DataRow dr = dtWarehouse.NewRow();
                dr["WarehouseId"] = -1;
                dr["Warehouse"] = "--- Select Depart ---";
                dtWarehouse.Rows.InsertAt(dr, 0);
                cmbWarehouse.DataSource = dtWarehouse;
                cmbWarehouse.DisplayMember = "Warehouse";
                cmbWarehouse.ValueMember = "WarehouseId";

                if (MainForm.StoreId > 0)
                {
                    cmbWarehouse.SelectedValue = MainForm.StoreId;
                }
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDate.Value > DateTime.Now)
            {
                //yeh condition lagwai hai k ajj ki date se upper ki date select na ker sky user, q k data toh hoga hi nh toh date selection auto getdate ajye.

                dtpDate.Value = DateTime.Now;
            }
        }

        private void btnSNo_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearch search = new frmSearch();
                search.getattributes("GetSearchSalesOrders", null, "Sales Orders");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtSONo.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSONo.Text))
                {
                    MessageBox.Show("Please Select Sale Order Number.", "Sale Order is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                frmSearch search = new frmSearch();
                Smartworks.ColumnField[] gSalesOrderProduct = new Smartworks.ColumnField[1];
                gSalesOrderProduct[0] = new Smartworks.ColumnField("@SaleOrderNo", txtSONo.Text);
                search.getattributes("GetProductSearchForSalesOrder", gSalesOrderProduct, "Products");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtPCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSONo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSONo.Text))
            {
                try
                {
                    //DataTable dtSOrder = manageSalesOrder.GetSaleOrderMaster(manageSalesOrder.GetSalesOrderMasterIdByCode(txtSONo.Text));
                    //if (dtSOrder.Rows.Count > 0)
                    //{
                    //    CustomerManager manageCustomer = new CustomerManager();
                    //    txtPONo.Text = dtSOrder.Rows[0]["PONo"].ToString();
                    //    txtCName.Text = manageCustomer.GetCustomer(manageCustomer.GetCustomerIdByCode(dtSOrder.Rows[0]["CustomerCode"].ToString())).Rows[0]["CustomerName"].ToString();
                    //}
                }
                catch (Exception ex)
                {
                    //txtCName.Text = string.Empty;
                }
            }
            else
            {
                //txtCName.Text = string.Empty;
                txtPCode.Text = string.Empty;
            }
        }

        private void txtPCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ProductManager manageProduct = new ProductManager();
                if (!string.IsNullOrEmpty(txtPCode.Text))
                {
                    DataTable dtProduct = new DataTable();
                    dtProduct = manageProduct.GetProduct(manageProduct.GetProductIdByCode(txtPCode.Text));
                    if (dtProduct.Rows.Count > 0)
                    {
                        txtPName.Text = dtProduct.Rows[0]["ProductName"].ToString();
                    }
                }
                else
                {
                    txtPName.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
    }

