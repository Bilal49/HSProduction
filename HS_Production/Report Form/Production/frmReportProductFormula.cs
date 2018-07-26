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


public partial class frmReportProductFormula : Form
{
    ReportDocument document = null;
    WarehouseManager manageWarehouse = new WarehouseManager();
    ProductManager manageProduct = new ProductManager();
    Utility clsUtility = new Utility();

    public frmReportProductFormula(ReportDocument pdocument = null)
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
            if (Convert.ToInt32(cmbProductFormulaNew.EditValue) < 0)
            {
                MessageBox.Show("Please Select Article Receipy", "Receipy is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProductFormulaNew.Focus();
                return;
            }
            document = new ReportDocument();
            string path = Application.StartupPath + "/rpt/Production/rptProductFormulaWithRequired.rpt";
            document.Load(path);
            DataTable dtReport = new DataTable();
            dtReport = manageProduct.GetReportProductFormulaWithRequired(Convert.ToInt32(cmbProductFormulaNew.EditValue), (string.IsNullOrEmpty(txtQty.Text) ? 1 : Convert.ToInt32(txtQty.Text)));
            document.SetDataSource(dtReport);
            Utility.SetReportDefaultParameter(ref document);
            if (document.ParameterFields["CQty"] != null)
            {
                document.SetParameterValue("CQty", (string.IsNullOrEmpty(txtQty.Text) ? 1 : Convert.ToInt32(txtQty.Text)));
            }
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
        txtPCode.Text = string.Empty;
        txtFormulaId.Text = string.Empty;
        //cmbProductFormula.SelectedIndex = 0;
        cmbProductFormulaNew.EditValue = -1;
        
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

        DataTable dtProductFormula = new DataTable();
        if (string.IsNullOrEmpty(txtPCode.Text))
        {
            dtProductFormula = manageProduct.GetAllProductFormula();
        }
        else
        {
            dtProductFormula = manageProduct.GetAllProductFormulaByFinishProductId(manageProduct.GetProductIdByCode(txtPCode.Text)); // manageWarehouse.GetWarehouseList();
        }
        
        DataRow dr = dtProductFormula.NewRow();
        dr["FormulaMasterId"] = -1;
        dr["FormulaName"] = "--- Select Product Receipy ---";
        dtProductFormula.Rows.InsertAt(dr, 0);
        //cmbProductFormula.DataSource = dtProductFormula;
        //cmbProductFormula.DisplayMember = "FormulaName";
        //cmbProductFormula.ValueMember = "FormulaMasterId";

        cmbProductFormulaNew.Properties.DataSource = dtProductFormula;
        cmbProductFormulaNew.Properties.DisplayMember = "FormulaName";
        cmbProductFormulaNew.Properties.ValueMember = "FormulaMasterId";

        try
        {
            cmbProductFormulaNew.Properties.PopulateViewColumns();
            cmbProductFormulaNew.Properties.View.Columns[0].Visible = false;
            cmbProductFormulaNew.EditValue = "-1";
            cmbProductFormulaNew.Properties.ShowPopupShadow = true;
            cmbProductFormulaNew.Properties.PopupFormMinSize = new Size(450, 250);
            cmbProductFormulaNew.Properties.NullText = "";
            cmbProductFormulaNew.Properties.ShowFooter = false;
            cmbProductFormulaNew.Properties.ResetTextEditStyleToStandardInFilterControl = true;
            cmbProductFormulaNew.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            cmbProductFormulaNew.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            cmbProductFormulaNew.Properties.ImmediatePopup = true;
        }
        catch
        {
        }

        txtFormulaId.Text = string.Empty;

    }

    private void txtProductCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(txtPCode.Text))
            {
                DataTable dtProduct = new DataTable();
                dtProduct = manageProduct.GetProduct(manageProduct.GetProductIdByCode(txtPCode.Text));
                txtPName.Text = dtProduct.Rows[0]["ProductName"].ToString();
                if (!string.IsNullOrEmpty(dtProduct.Rows[0]["Picture"].ToString()))
                {
                    try
                    {
                        pbitem.Image = clsUtility.Base64ToImage(dtProduct.Rows[0]["Picture"].ToString());
                    }
                    catch
                    {
                        pbitem.Image = FIL.Properties.Resources.User;

                    }

                }
                else
                {
                    pbitem.Image = FIL.Properties.Resources.User;

                }

            }
            else
            {
                txtPName.Text = string.Empty;
                pbitem.Image = FIL.Properties.Resources.User;
            }
            FillDropDown();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void btnVoucherToCodeSearch_Click(object sender, EventArgs e)
    {
        try
        {

            frmSearch search = new frmSearch();
            search.getattributes("GetProductSearchForSemiAndFinish", null, "Products");
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

    private void btnfomulaSearch_Click(object sender, EventArgs e)
    {
        try
        {
            frmSearch search = new frmSearch();
            search.getattributes("GetProductFormulaSearch", null, "Product Formula");
            search.ShowDialog();
            if (!string.IsNullOrEmpty(MainForm.Searched_Id))
            {
                txtFormulaId.Text = MainForm.Searched_Id;
                MainForm.Searched_Id = string.Empty;

            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

    }
   
    private void txtFormulaId_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtFormulaId.Text))
        {
            int FormulaId = -1;
            FormulaId = manageProduct.GetFormulaIdByCode(Convert.ToInt32(txtFormulaId.Text));
            if (FormulaId > 0)
            {
                cmbProductFormulaNew.EditValue = FormulaId;
            }
            else
            {
                cmbProductFormulaNew.EditValue = -1;
            }
            
        }
    }

    private void txtFormulaId_KeyPress(object sender, KeyPressEventArgs e)
    {
        clsUtility.setOnlyNumberic((TextBox)sender, false, e);
    }

    //private void cmbProductFormula_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (cmbProductFormula.SelectedIndex > 0)
    //    {
    //        txtFormulaId.Text = cmbProductFormula.SelectedValue.ToString();
    //    }
    //    else
    //    {
    //        txtFormulaId.Text = string.Empty;
    //    }
        
    //}
    private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
    {
        clsUtility.setOnlyNumberic((TextBox)sender, false, e);
    }

    private void cmbProductFormulaNew_EditValueChanged(object sender, EventArgs e)
    {   
        if (!string.IsNullOrEmpty(cmbProductFormulaNew.EditValue.ToString()))
        {
            if (cmbProductFormulaNew.EditValue.ToString() == "-1")
            {
                txtFormulaId.Text = string.Empty;
            }
            else
            {
                txtFormulaId.Text = cmbProductFormulaNew.EditValue.ToString();
            }
            
        }
        else if (cmbProductFormulaNew.EditValue.ToString() == "-1")
        {
            txtFormulaId.Text = string.Empty;
        }
        else
        {
            txtFormulaId.Text = string.Empty;
        }
             
    }

    private void cmbProductFormulaNew_Enter(object sender, EventArgs e)
    {
        if (cmbProductFormulaNew.EditValue.ToString() == "-1")
        {
            cmbProductFormulaNew.Text = "";
        }
        else
        {
            cmbProductFormulaNew.SelectAll();
            cmbProductFormulaNew.SelectionLength = cmbProductFormulaNew.Text.Length;
        }

    }

    private void cmbProductFormulaNew_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(cmbProductFormulaNew.EditValue.ToString()))
        {
            cmbProductFormulaNew.EditValue = "-1";
        }
        
    }

    private void cmbProductFormulaNew_KeyDown(object sender, KeyEventArgs e)
    {
        DevExpress.XtraEditors.GridLookUpEdit gridLookUpEdit = sender as DevExpress.XtraEditors.GridLookUpEdit;
        if (e.KeyCode == Keys.Back)
            BeginInvoke(new MethodInvoker(() => { SendKeys.Send("{Delete}"); }));
        if (e.KeyCode == Keys.Enter)
        {
            cmbProductFormulaNew.SelectionLength = 0;
        }
    }

}

