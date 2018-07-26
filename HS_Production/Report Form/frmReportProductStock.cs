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
    public partial class frmReportProductStock : Form
    {
        ProductManager manageProduct = new ProductManager();
        bool IsAmountStockReport = false;
        public frmReportProductStock(bool IsAmountShowReport  = false)
        {
            this.IsAmountStockReport = IsAmountShowReport;
            InitializeComponent();
        }

        private void frmReportProductStock_Load(object sender, EventArgs e)
        {
            FillDropDown();
        }

        private void FillDropDown()
        {

            DataTable dtProductCatagory = manageProduct.GetAllProductCategory();

            DataRow dr = dtProductCatagory.NewRow();
            dr["ProductCategoryId"] = -1;
            dr["CategoryName"] = "--- All Category ---";
            dtProductCatagory.Rows.InsertAt(dr, 0);
            cmbProductCatagory.DataSource = dtProductCatagory;
            cmbProductCatagory.DisplayMember = "CategoryName";
            cmbProductCatagory.ValueMember = "ProductCategoryId";


            WarehouseManager manageWarehouse = new WarehouseManager();
            DataTable dtWarehouse = manageWarehouse.GetWarehouseList();
            DataRow drWarehouse = dtWarehouse.NewRow();
            drWarehouse["WarehouseId"] = -1;
            drWarehouse["Warehouse"] = "--- All Depart ---";
            dtWarehouse.Rows.InsertAt(drWarehouse, 0);
            cmbWarehouse.DataSource = dtWarehouse;
            cmbWarehouse.DisplayMember = "Warehouse";
            cmbWarehouse.ValueMember = "WarehouseId";
            if (MainForm.StoreId > 0)
            {
                cmbWarehouse.SelectedValue = MainForm.StoreId;
            }


            DataTable dtProducts = manageProduct.GetProductListCode();

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
        private void btnToSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetProductSearch", null, "Items");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtToCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtToCode.Text = string.Empty;
                    txtToCode.Focus();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFromSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetProductSearch", null, "Items");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtFromCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtFromCode.Text = string.Empty;
                    txtFromCode.Focus();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbWarehouse.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Depart Name", "Depart Name is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ReportDocument document = new ReportDocument();
                string path = string.Empty;
                if (IsAmountStockReport)
                {
                    path = Application.StartupPath + "/rpt/rptStockWithValue.rpt";
                }
                else
                {
                    path = Application.StartupPath + "/rpt/rptStock.rpt";
                }

                
                //string path = @"E:\HandsomeSolution\GernalShop-PreviousWork\GernalShop-PreviousWork\GernalShopLastUpdate\FIL\rpt\Inventory\rptStock.rpt";
                document.Load(path);
                DataTable dtReport = new DataTable();
                dtReport = manageProduct.GetReportStock(Convert.ToInt32(cmbProductCatagory.SelectedValue), txtFromCode.Text, txtToCode.Text,
                    Convert.ToInt32(cmbWarehouse.SelectedValue));
                document.SetDataSource(dtReport);
                document.SetParameterValue("ShowCategory", chkShowCetagory.Checked);
                document.SetParameterValue("ShowStock", chkShowStock.Checked);
                document.SetParameterValue("ShowColor", chkShowColor.Checked);
                document.SetParameterValue("ShowCName", chkShowCompany.Checked);
                Utility.SetReportDefaultParameter(ref document);
                crystalRptProductStock.ReportSource = document;
                crystalRptProductStock.Refresh();
                //document.PrintToPrinter(1, true, 0, 0);
            }
            catch (Exception ex)
            {
            }
        }

        private void txtFromCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtFromCode.Text))
                {
                    //DataTable dtProduct = manageProduct.GetProduct(Convert.ToInt32(txtFromCode.Text));
                    //if (dtProduct.Rows.Count > 0)
                    //{
                    //    txtFromProduct.Text = dtProduct.Rows[0]["ProductCode"].ToString();
                    //}
                    txtFromProduct.Text = manageProduct.GetProduct(manageProduct.GetProductIdByCode(txtFromCode.Text)).Rows[0]["ProductName"].ToString();
                }
                else
                {
                    txtFromProduct.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {

                txtFromProduct.Text = string.Empty;
            }


        }

        private void txtToCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtToCode.Text))
                {
                    txtToProduct.Text = manageProduct.GetProduct(manageProduct.GetProductIdByCode(txtToCode.Text)).Rows[0]["ProductName"].ToString();
                }
                else
                {
                    txtToProduct.Text = string.Empty;
                }
            }
            catch
            {
                txtToProduct.Text = string.Empty;
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFromCode.Text = string.Empty;
            txtToCode.Text = string.Empty;

            cmbProductCatagory.SelectedIndex = 0;
            if (MainForm.StoreId > 0)
            {
                cmbWarehouse.SelectedValue = MainForm.StoreId;
            }
            else
            {
                cmbWarehouse.SelectedIndex = 0;
            }
            cmbProductNameNew.EditValue = "-1";
            crystalRptProductStock.ReportSource = null;
        }

        private void cmbFProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    txtFromCode.Text = cmbFProductName.SelectedValue.ToString();
            //    txtToCode.Text = cmbFProductName.SelectedValue.ToString();
            //}
            //catch
            //{
            //    txtFromCode.Text = string.Empty;
            //    txtToCode.Text = string.Empty;
            //}

        }

        private void txtFromProduct_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbFProductName_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtFromCode.Text = cmbFProductName.SelectedValue.ToString();
                txtToCode.Text = cmbFProductName.SelectedValue.ToString();
            }
            catch
            {
                txtFromCode.Text = string.Empty;
                txtToCode.Text = string.Empty;
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
                        txtFromCode.Text = cmbProductNameNew.EditValue.ToString();
                        txtToCode.Text = cmbProductNameNew.EditValue.ToString();
                    }
                    catch
                    {
                        txtFromCode.Text = string.Empty;
                        txtToCode.Text = string.Empty;
                    }
                }
                else
                {
                    txtFromCode.Text = string.Empty;
                    txtToCode.Text = string.Empty;
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
                BeginInvoke(new MethodInvoker(() => { cmbProductNameNew.SelectAll(); }));
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
