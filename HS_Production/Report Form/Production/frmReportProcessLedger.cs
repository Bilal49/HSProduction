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


    public partial class frmReportProcessLedger : Form
    {
        ReportDocument document = null;
        ProductManager PM = new ProductManager();
        ProcessingManager manageProcessing = new ProcessingManager();
        public frmReportProcessLedger(ReportDocument pdocument = null)
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
                if (cmbWarehouse.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please Select Department Name", "Depart Name is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                document = new ReportDocument();
                string path = Application.StartupPath + "/rpt/Production/rptProcessLedger.rpt";
                document.Load(path);
                DataTable dtReport = new DataTable();
                dtReport = manageProcessing.GetProcessLedgerReport(Convert.ToDateTime(dtpFromDate.Text), Convert.ToDateTime(dtpToDate.Text), txtFromProductCode.Text, txtToProductCode.Text, Convert.ToInt32(cmbProductCatagory.SelectedValue), Convert.ToInt32(cmbWarehouse.SelectedValue));
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

        private void btnFPartySearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetProductSearchForFinish", null, "Articles");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtFromProductCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtFromProductCode.Text = string.Empty;
                    txtFromProductCode.Focus();
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
                search.getattributes("GetProductSearchForFinish", null, "Articles");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtToProductCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtToProductCode.Text = string.Empty;
                    txtToProductCode.Focus();
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

            txtFromProductCode.Text = string.Empty;
            txtToProductCode.Text = string.Empty;

            cmbFProductName.SelectedIndex = 0;
            cmbWarehouse.SelectedIndex = 0;

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
           
            DataTable dtProductCatagory = PM.GetAllProductCategory();
            if (dtProductCatagory.Rows.Count > 0)
            {
                DataRow dr = dtProductCatagory.NewRow();
                dr["ProductCategoryId"] = -1;
                dr["CategoryName"] = "--- All Category ---";
                dtProductCatagory.Rows.InsertAt(dr, 0);
                cmbProductCatagory.DataSource = dtProductCatagory;
                cmbProductCatagory.DisplayMember = "CategoryName";
                cmbProductCatagory.ValueMember = "ProductCategoryId";
            }

            WarehouseManager manageWarehouse = new WarehouseManager();
            DataTable dtWarehouse = manageWarehouse.GetWarehouseList();
            DataRow drWarehouse = dtWarehouse.NewRow();
            drWarehouse["WarehouseId"] = -1;
            drWarehouse["Warehouse"] = "--- Select Depart ---";
            dtWarehouse.Rows.InsertAt(drWarehouse, 0);
            cmbWarehouse.DataSource = dtWarehouse;
            cmbWarehouse.DisplayMember = "Warehouse";
            cmbWarehouse.ValueMember = "WarehouseId";


            DataTable dtProducts = PM.GetProductListForFinish();

            DataRow drFProductName = dtProducts.NewRow();
            drFProductName["ProductCode"] = "";
            drFProductName["ProductName"] = "--- Search By Item Name ---";
            dtProducts.Rows.InsertAt(drFProductName, 0);
            cmbFProductName.DataSource = dtProducts;
            cmbFProductName.DisplayMember = "ProductName";
            cmbFProductName.ValueMember = "ProductCode";
            cmbFProductName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbFProductName.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void txtFromProductCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtFromProductCode.Text))
                {
                    txtFromPName.Text = PM.GetProduct(PM.GetFinishProductIdByCode(txtFromProductCode.Text)).Rows[0]["ProductName"].ToString();
                }
                else
                {
                    txtFromPName.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {

                txtFromPName.Text = string.Empty;
            }

        }

        private void txtToProductCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtToProductCode.Text))
                {
                    txtToPName.Text = PM.GetProduct(PM.GetFinishProductIdByCode(txtToProductCode.Text)).Rows[0]["ProductName"].ToString();
                }
                else
                {
                    txtToPName.Text = string.Empty;
                }
            }
            catch
            {
                txtToPName.Text = string.Empty;
            }

        }

        private void cmbFProductName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbFProductName_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtFromProductCode.Text = cmbFProductName.SelectedValue.ToString();
                txtToProductCode.Text = cmbFProductName.SelectedValue.ToString();
            }
            catch
            {
                txtFromProductCode.Text = string.Empty;
                txtToProductCode.Text = string.Empty;
            }
        }
        
    }

