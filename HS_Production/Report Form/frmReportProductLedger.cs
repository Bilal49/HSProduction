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

namespace FIL.Report_Form
{
    public partial class frmReportProductLedger : Form
    {
        ReportDocument document = null;
        ProductManager PM = new ProductManager();
        public frmReportProductLedger(ReportDocument pdocument = null)
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
                string path = Application.StartupPath + "/rpt/rptProductLedger.rpt";
                document.Load(path);
                DataTable dtReport = new DataTable();
                dtReport = PM.GetProductLedgerReport(Convert.ToDateTime(dtpFromDate.Text), Convert.ToDateTime(dtpToDate.Text) , txtFromProductCode.Text, txtToProductCode.Text , Convert.ToInt32(cmbProductCatagory.SelectedValue), Convert.ToInt32(cmbWarehouse.SelectedValue));
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
                search.getattributes("GetProductSearch", null, "Items");
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
                search.getattributes("GetProductSearch", null, "Items");
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
            if (MainForm.StoreId > 0)
            {
                cmbWarehouse.SelectedValue = MainForm.StoreId;
            }

            DataTable dtProducts = PM.GetProductListCode();

            DataRow drFProductName = dtProducts.NewRow();
            drFProductName["ProductCode"] = "-1";
            drFProductName["ProductName"] = "--- Search By Item Name ---";
            dtProducts.Rows.InsertAt(drFProductName, 0);
            cmbFProductName.DataSource = dtProducts;
            cmbFProductName.DisplayMember = "ProductName";
            cmbFProductName.ValueMember = "ProductCode";
            cmbFProductName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbFProductName.AutoCompleteSource = AutoCompleteSource.ListItems;


            cmbProductNameNew.Properties.DataSource = dtProducts;
            cmbProductNameNew.Properties.DisplayMember = "ProductName";
            cmbProductNameNew.Properties.ValueMember = "ProductCode";

            try
            {
                cmbProductNameNew.Properties.PopulateViewColumns();
                cmbProductNameNew.Properties.View.Columns[0].Visible = false;
                cmbProductNameNew.EditValue = "-1";
                cmbProductNameNew.Properties.ShowPopupShadow = true;
                cmbProductNameNew.Properties.PopupFormMinSize = new Size(450, 250);
                cmbProductNameNew.Properties.NullText = "";
                cmbProductNameNew.Properties.ShowFooter = false;
                cmbProductNameNew.Properties.ResetTextEditStyleToStandardInFilterControl = true;
                cmbProductNameNew.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
                cmbProductNameNew.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                cmbProductNameNew.Properties.ImmediatePopup = true;
            }
            catch
            {
            }
        }

        private void txtFromProductCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtFromProductCode.Text))
                {
                    txtFromPName.Text = PM.GetProduct(PM.GetProductIdByCode(txtFromProductCode.Text)).Rows[0]["ProductName"].ToString();
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
                    txtToPName.Text = PM.GetProduct(PM.GetProductIdByCode(txtToProductCode.Text)).Rows[0]["ProductName"].ToString();
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

        private void cmbProductNameNew_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbProductNameNew.EditValue.ToString()))
            {
                if (cmbProductNameNew.EditValue.ToString() != "-1")
                {
                    try
                    {
                        txtFromProductCode.Text = cmbProductNameNew.EditValue.ToString();
                        txtToProductCode.Text = cmbProductNameNew.EditValue.ToString();
                    }
                    catch
                    {
                        txtFromProductCode.Text = string.Empty;
                        txtToProductCode.Text = string.Empty;
                    }
                }
                else
                {
                    txtFromProductCode.Text = string.Empty;
                    txtToProductCode.Text = string.Empty;
                }
            }
        }

        private void cmbProductNameNew_Enter(object sender, EventArgs e)
        {
            if (cmbProductNameNew.EditValue.ToString() == "-1")
            {
                cmbProductNameNew.Text = "";
            }
            else
            {
                cmbProductNameNew.SelectAll();
                cmbProductNameNew.SelectionLength = cmbProductNameNew.Text.Length;
            }
            
        }

        private void cmbProductNameNew_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbProductNameNew.EditValue.ToString()))
            {
                cmbProductNameNew.EditValue = "-1";
            }

        }

        private void cmbProductNameNew_KeyDown(object sender, KeyEventArgs e)
        {
            DevExpress.XtraEditors.GridLookUpEdit gridLookUpEdit = sender as DevExpress.XtraEditors.GridLookUpEdit;
            if (e.KeyCode == Keys.Back)
                BeginInvoke(new MethodInvoker(() => { SendKeys.Send("{Delete}"); }));
            if (e.KeyCode == Keys.Enter)
            {
                cmbProductNameNew.SelectionLength = 0;
            }
        }
        
    }
}
