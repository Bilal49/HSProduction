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


public partial class frmReportProcessingSummary : Form
{
    ReportDocument document = null;
    WarehouseManager manageWarehouse = new WarehouseManager();
    ProductManager manageProduct = new ProductManager();
    ProcessingManager manageProcess = new ProcessingManager();
    SalesOrderManager manageSO = new SalesOrderManager();
    DataTable dsMain = null;
    BindingSource bsLookup = new BindingSource();
    RepositoryItemCheckedComboBoxEdit reposityCheckEdit = null;
    string SelectedSO = string.Empty;
    //DataNavigator dataNav = null;
    public frmReportProcessingSummary(ReportDocument pdocument = null)
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
            int WarehouseId = -1;
            int ProductId = -1;

            if (cmbWarehouse.SelectedIndex > 0)
            {
                WarehouseId = Convert.ToInt32(cmbWarehouse.SelectedValue.ToString());
            }
            if (!string.IsNullOrEmpty(txtProductCode.Text))
            {
                ProductId = manageProduct.GetProductIdByCode(txtProductCode.Text);
            }

            document = new ReportDocument();
            //string path = Application.StartupPath + "/rpt/Production/rptProcessLineSummaryByDetail.rpt";
            string path = Application.StartupPath + "/rpt/Production/rptProcessLineSummary.rpt";
            document.Load(path);
            DataTable dtReport = new DataTable();
            if (chkAlldate.Checked)
            {
                dtReport = manageProcess.GetReportProcessingSummary(WarehouseId, ProductId, SelectedSO , null, null , dtpAsOn.Value);
            }
            else
            {
                //useless method hogya Salman yeh , q k yeh wala case ab shayed nh chaly ga , from date and To date wala kam hata dia hai , & report mai bhi date ka column hata dia.
                dtReport = manageProcess.GetReportProcessingSummary(WarehouseId, ProductId, SelectedSO, dtpFromDate.Value, dtpToDate.Value , null);
            }

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
        txtSOrderNo.Text = string.Empty;
        SelectedSO = string.Empty;
        txtProductCode.Text = string.Empty;
        txtProductName.Text = string.Empty;
        cmbWarehouse.SelectedIndex = 0;
        //LookUpEdit.EditValue = -1;
        gridLookUpEdit1View.ClearSelection();
        LookUpEdit.Text = "";
        LookUpEdit.EditValue = null;
        LookUpEdit.RefreshEditValue();
        chkAlldate.Checked = true;
        dtpAsOn.Value = DateTime.Now;
        dtpFromDate.Focus();
    }

    private void frmReportStockInn_Load(object sender, EventArgs e)
    {
        try
        {
            setupGrid();
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

    private void setupGrid()
    {
        dsMain = new DataTable();
        dsMain = manageSO.GetSalesOrderListForLookupEdit();
        dsMain.TableName = "SOrders";

        bsLookup.DataSource = dsMain;
      //  bsLookup.DataMember = "SOrders";

      

        
        
        LookUpEdit.Properties.DataSource = bsLookup;

        LookUpEdit.Properties.DisplayMember = "SOrderNo";
        LookUpEdit.Properties.ValueMember = "SOrderId";
        LookUpEdit.Properties.ShowFooter = false;
        LookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;

        LookUpEdit.Properties.PopupFilterMode = PopupFilterMode.Contains;

        LookUpEdit.Properties.PopupFormSize = new Size(450, 350);
        LookUpEdit.Properties.NullText = "";
        LookUpEdit.Properties.ShowFooter = false;
        LookUpEdit.Properties.View.OptionsView.ColumnAutoWidth = false;
        LookUpEdit.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
        LookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
        LookUpEdit.Properties.ImmediatePopup = true;
        LookUpEdit.Properties.PopulateViewColumns();

        //LookUpEdit.Properties.M
        gridLookUpEdit1View.OptionsSelection.MultiSelect = true;
        gridLookUpEdit1View.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
        gridLookUpEdit1View.OptionsSelection.CheckBoxSelectorColumnWidth = 50;
        gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
        gridLookUpEdit1View.Columns.ColumnByName("colSOrderId").Visible = false;

        gridLookUpEdit1View.Columns.ColumnByName("colSOrderNo").Caption = "Order #";
        gridLookUpEdit1View.Columns.ColumnByName("colOrderDate").Caption = "Dated";
        gridLookUpEdit1View.Columns.ColumnByName("colTQuantity").Caption = "Order Qty";
        gridLookUpEdit1View.Columns.ColumnByName("colCustomerName").Caption = "Customer";

        gridLookUpEdit1View.Columns.ColumnByName("colSOrderNo").VisibleIndex = 0;
        gridLookUpEdit1View.Columns.ColumnByName("colOrderDate").VisibleIndex = 1;
        gridLookUpEdit1View.Columns.ColumnByName("colTQuantity").VisibleIndex = 2;
        gridLookUpEdit1View.Columns.ColumnByName("colCustomerName").VisibleIndex = 3;

        gridLookUpEdit1View.Columns.ColumnByName("colSOrderNo").Width = 80;
        gridLookUpEdit1View.Columns.ColumnByName("colOrderDate").Width = 80;
        gridLookUpEdit1View.Columns.ColumnByName("colTQuantity").Width = 60;
        gridLookUpEdit1View.Columns.ColumnByName("colCustomerName").Width = 150;

        


        //gridLookUpEdit1View.Columns.ColumnByName("colOrderDate").DisplayFormat = "dd-MMM-yyyy";

            //gvDetail.Columns.ColumnByName("colPLDetailId").Visible = false;
        //gridLookUpEdit1View.OptionsView
            //gridLookup.Properties.PopupView.Columns

        //LookUpEdit.Data
        //LookUpEdit.DataBindings = bsLookup;
        //searchLookUpEdit1View.DataSource = dsMain;
        //searchLookUpEdit1View.DataSource = bsLookup;
        //LookUpEdit
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
        }
    }

    private void chkAlldate_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAlldate.Checked)
        {

            dtpFromDate.Enabled = false;
            dtpToDate.Enabled = false;

            dtpAsOn.Enabled = true;
        }
        else
        {
            dtpFromDate.Enabled = true;
            dtpToDate.Enabled = true;

            dtpAsOn.Enabled = false;
            dtpAsOn.Value = DateTime.Now;
        }
    }

    private void btnSOSearch_Click(object sender, EventArgs e)
    {
        try
        {
            frmSearch search = new frmSearch();
            search.getattributes("GetSearchSalesOrders", null, "Sales Orders");
            search.ShowDialog();
            if (!string.IsNullOrEmpty(MainForm.Searched_Id))
            {
                txtSOrderNo.Text = MainForm.Searched_Id;
                MainForm.Searched_Id = string.Empty;
                //LoadPOrder(); 
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void btnProductSearch_Click(object sender, EventArgs e)
    {
        try
        {
            frmSearch search = new frmSearch();
            search.getattributes("GetProductSearchForSemiAndFinish", null, "Articles");
            search.ShowDialog();
            if (!string.IsNullOrEmpty(MainForm.Searched_Id))
            {
                txtProductCode.Text = MainForm.Searched_Id;
                MainForm.Searched_Id = string.Empty;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void txtProductCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(txtProductCode.Text))
            {
                txtProductName.Text = manageProduct.GetProduct(manageProduct.GetProductIdByCode(txtProductCode.Text)).Rows[0]["ProductName"].ToString();
            }
            else
            {
                txtProductName.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            txtProductName.Text = string.Empty;
        }
    }

   // bool IsEditEventRunning = false;

    private void LookUpEdit_EditValueChanged(object sender, EventArgs e)
    {
        //if (IsEditEventRunning)
        //{
        //    return;
        //}
        string displayText = string.Empty;
        SelectedSO = string.Empty;
        //string displayText = LookUpEdit.Properties.GetDisplayText(LookUpEdit.EditValue);
        //gridLookUpEdit1View.GetSelectedRows()[2]
        foreach (int index in gridLookUpEdit1View.GetSelectedRows())
        {
            DataRow drSelected = dsMain.Rows[index];
            if (string.IsNullOrEmpty(displayText))
            {
                SelectedSO = "'" + drSelected["SOrderNo"].ToString() +"'";
                displayText = drSelected["SOrderNo"].ToString();
               
                //if (dsMain.Select("SOrderId = '" + Ids + "'").Length > 0)
                //{
                //    displayText = dsMain.Select("SOrderId = '" + Ids + "'")[0]["SOrderNo"].ToString();
                //}
                
            }
            else
            {
                SelectedSO = SelectedSO + " , " + "'" + drSelected["SOrderNo"].ToString() + "'";
                displayText = displayText + " , " + drSelected["SOrderNo"].ToString();
                //if (dsMain.Select("SOrderId = '" + Ids + "'").Length > 0)
                //{
                //    displayText = displayText + " , "+ dsMain.Select("SOrderId = '" + Ids + "'")[0]["SOrderNo"].ToString();
                //}
                //displayText +=   "";
            }
            //IsEditEventRunning = true;
            //LookUpEdit.EditValue = displayText;
            //IsEditEventRunning = false;
        }

    }

    private void gridLookUpEdit1View_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
    {

    }

    private void LookUpEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
    {
        try
        {
            
            string displayText = string.Empty;
            
            foreach (int index in gridLookUpEdit1View.GetSelectedRows())
            {
                DataRow drSelected = dsMain.Rows[index];
                if (string.IsNullOrEmpty(displayText))
                {   
                    displayText = drSelected["SOrderNo"].ToString();
                }
                else
                {   
                    displayText = displayText + " , " + drSelected["SOrderNo"].ToString();
                }
            }
            e.DisplayText = displayText;
        }
        catch (Exception ex)
        { }
    }

}

