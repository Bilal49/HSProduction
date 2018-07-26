using CrystalDecisions.CrystalReports.Engine;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraGrid.Views.Grid;
using FIL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


public partial class frmProcess : Form
{
    Smartworks.DAL dataAcess = new Smartworks.DAL();
    ProductManager manageProduct = new ProductManager();
    WarehouseManager manageWarehouse = new WarehouseManager();

    SalesOrderManager manageSalesOrder = new SalesOrderManager();
    //ProductionManager manageProduction = new ProductionManager();
    ProcessingManager manageProcessing = new ProcessingManager();

    BindingSource bsWarehouse = new BindingSource();
    BindingSource bsTransferWarehouse = new BindingSource();

    BindingSource bsSaleOrder = new BindingSource();
    BindingSource bsProducts = new BindingSource();
    BindingSource bsDisplayProducts = new BindingSource();
    List<int> DeletedIds = new List<int>();

    



    RepositoryItemGridLookUpEdit repositoryGridLookup = new RepositoryItemGridLookUpEdit();
    RepositoryItemGridLookUpEdit repositorySalesOrder = new RepositoryItemGridLookUpEdit();

    RepositoryItemGridLookUpEdit repositoryWarehouseGridLookup = new RepositoryItemGridLookUpEdit();
    RepositoryItemGridLookUpEdit repositoryTransferWarehouseGridLookup = new RepositoryItemGridLookUpEdit();


    DataSet dsMain = null;

    DataRow drMaster;

    int ProcessMasterId = -1;
    bool IsProcessLoaded = false;
    public frmProcess()
    {
        InitializeComponent();
    }
    private void frmProductFormula_Load(object sender, EventArgs e)
    {
        try
        {
            ButtonRights(true);
            //FillDropDown();
            setupGrip();
            txtCode.Text = GetNewNextNumber();
            btnNextInvioceNo.Enabled = false;
            btnPrevInvioceNo.Enabled = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

    }

    #region Method

    private String GetNewNextNumber()
    {
        string NewInvoiceNo = "";
        NewInvoiceNo = manageProcessing.GetMaxInvioceNo();
        if (!string.IsNullOrEmpty(NewInvoiceNo))
        {
            NewInvoiceNo = manageProcessing.GetNextInvioceNo(NewInvoiceNo);
        }
        else
        {
            NewInvoiceNo = "PS-000001";
        }
        return NewInvoiceNo;
    }

    private void FillDropDown()
    {
        DataTable dtWarehouse = new DataTable();
        dtWarehouse = manageWarehouse.GetWarehouseList();
        DataRow drWarehouse = dtWarehouse.NewRow();
        drWarehouse["WarehouseId"] = -1;
        drWarehouse["Warehouse"] = "--Select All Depart--";
        dtWarehouse.Rows.InsertAt(drWarehouse, 0);
        cmbWarehouse.DataSource = dtWarehouse;
        cmbWarehouse.DisplayMember = "Warehouse";
        cmbWarehouse.ValueMember = "WarehouseId";


        DataTable dtTransferWarehouse = new DataTable();
        dtTransferWarehouse = manageWarehouse.GetWarehouseList();
        DataRow drTransferWarehouse = dtTransferWarehouse.NewRow();
        drTransferWarehouse["WarehouseId"] = -1;
        drTransferWarehouse["Warehouse"] = "--Select All Depart--";
        dtTransferWarehouse.Rows.InsertAt(drTransferWarehouse, 0);
        cmbTransferWarehouse.DataSource = dtTransferWarehouse;
        cmbTransferWarehouse.DisplayMember = "Warehouse";
        cmbTransferWarehouse.ValueMember = "WarehouseId";

    }


    private void setupGrip()
    {
        dsMain = new DataSet();
        dsMain = manageProcessing.GetProcessStructure(ProcessMasterId);

        dsMain.Tables[0].TableName = "ProcessMaster";
        dsMain.Tables[1].TableName = "ProcessDetail";
        dsMain.Tables[2].TableName = "Products";
        dsMain.Tables[3].TableName = "MesurementUnit";
        dsMain.Tables[4].TableName = "Warehouse";
        dsMain.Tables[5].TableName = "Color";
        dsMain.Tables[6].TableName = "SOrder";


        dsMain.Tables["ProcessMaster"].Columns["ProcessMasterId"].AutoIncrement = true;
        dsMain.Tables["ProcessMaster"].Columns["ProcessMasterId"].AutoIncrementSeed = -1;
        dsMain.Tables["ProcessMaster"].Columns["ProcessMasterId"].AutoIncrementStep = -1;

        dsMain.Tables["ProcessDetail"].Columns["ProcessDetailId"].AutoIncrement = true;
        dsMain.Tables["ProcessDetail"].Columns["ProcessDetailId"].AutoIncrementSeed = -1;
        dsMain.Tables["ProcessDetail"].Columns["ProcessDetailId"].AutoIncrementStep = -1;



        dsMain.Relations.Add("MasterRelation", dsMain.Tables["ProcessMaster"].Columns["ProcessMasterId"], dsMain.Tables["ProcessDetail"].Columns["ProcessMasterId"]);


        if (dsMain.Tables["ProcessMaster"].Rows.Count > 0)
        {
            drMaster = dsMain.Tables["ProcessMaster"].Rows[0];
        }
        else
        {
            drMaster = dsMain.Tables["ProcessMaster"].NewRow();
            dsMain.Tables["ProcessMaster"].Rows.Add(drMaster);
        }
        //drMaster = dsMain.Tables["ProcessMaster"].NewRow();
        //dsMain.Tables["ProcessMaster"].Rows.Add(drMaster);
        //dvm = new DataViewManager(dsMain);
        //dvProduct = dvm.CreateDataView(dsMain.Tables["Products"]);

        GCDetail.DataSource = dsMain;
        GCDetail.DataMember = "ProcessDetail";
        GCDetail.ForceInitialize();
        GridSetting();
    }

    private void GridSetting()
    {
        gvDetail.Columns.ColumnByName("colProcessDetailId").OptionsColumn.ReadOnly = true;
        gvDetail.Columns.ColumnByName("colProcessMasterId").OptionsColumn.ReadOnly = true;

        gvDetail.Columns.ColumnByName("colProcessDetailId").Visible = false;
        gvDetail.Columns.ColumnByName("colProcessMasterId").Visible = false;
        gvDetail.Columns.ColumnByName("colStatusId").Visible = false;

        //gvDetail.Columns.ColumnByName("colWarehouseId").Visible = false;
        gvDetail.Columns.ColumnByName("colReceivedDate").Visible = false;
        gvDetail.Columns.ColumnByName("colReceivedQty").Visible = false;
        gvDetail.Columns.ColumnByName("colRejectQty").Visible = true;
        gvDetail.Columns.ColumnByName("colBalanceQty").Visible = false;
        //gvDetail.Columns.ColumnByName("colTransferWarehouseId").Visible = false;
        gvDetail.Columns.ColumnByName("colTransferDate").Visible = false;


        gvDetail.Columns.ColumnByName("colWarehouseId").Caption = "From Depart";
        //gvDetail.Columns.ColumnByName("colReceivedDate").Caption = "Receive On";
        //gvDetail.Columns.ColumnByName("colReceivedQty").Caption = "Remaining Qty";
        gvDetail.Columns.ColumnByName("colProcessQty").Caption = "Quantity";
        gvDetail.Columns.ColumnByName("colSOrderId").Caption = "Sale Order #";
        gvDetail.Columns.ColumnByName("colProductId").Caption = "Article Name";
        gvDetail.Columns.ColumnByName("colRejectQty").Caption = "Reject Qty";
        //gvDetail.Columns.ColumnByName("colBalanceQty").Caption = "Balance Qty";
        gvDetail.Columns.ColumnByName("colTransferWarehouseId").Caption = "Transfer Depart";
        //gvDetail.Columns.ColumnByName("colTransferDate").Caption = "Transfer Date";
        gvDetail.Columns.ColumnByName("colRemarks").Caption = "Remarks";


        gvDetail.Columns.ColumnByName("colSOrderId").VisibleIndex = 0;
        gvDetail.Columns.ColumnByName("colProductId").VisibleIndex = 1;
        gvDetail.Columns.ColumnByName("colWarehouseId").VisibleIndex = 2;
        gvDetail.Columns.ColumnByName("colProcessQty").VisibleIndex = 3;
        gvDetail.Columns.ColumnByName("colRejectQty").VisibleIndex = 4;
        gvDetail.Columns.ColumnByName("colTransferWarehouseId").VisibleIndex = 5;
        gvDetail.Columns.ColumnByName("colRemarks").VisibleIndex = 6;


        gvDetail.Columns.ColumnByName("colSOrderId").Width = 150;
        gvDetail.Columns.ColumnByName("colProductId").Width = 250;
        gvDetail.Columns.ColumnByName("colProcessQty").Width = 80;
        gvDetail.Columns.ColumnByName("colRejectQty").Width = 80;
        gvDetail.Columns.ColumnByName("colRemarks").Width = 150;
        gvDetail.Columns.ColumnByName("colWarehouseId").Width = 150;
        gvDetail.Columns.ColumnByName("colTransferWarehouseId").Width = 150;



        // gvDetail.Columns.ColumnByName("colReceivedQty").OptionsColumn.AllowEdit = false;
        gvDetail.Columns.ColumnByName("colSOrderId").OptionsColumn.AllowEdit = true;
        gvDetail.Columns.ColumnByName("colProductId").OptionsColumn.AllowEdit = true;



        bsSaleOrder.DataSource = dsMain;
        bsSaleOrder.DataMember = "SOrder";


        bsProducts.DataSource = dsMain;
        bsProducts.DataMember = "Products";
        bsProducts.Filter = "SOrderId = " + -1 + "";


        bsDisplayProducts.DataSource = dsMain;
        bsDisplayProducts.DataMember = "Products";
        bsDisplayProducts.Filter = "ProductId = " + -1 + "";


        bsWarehouse.DataSource = dsMain;
        bsWarehouse.DataMember = "Warehouse";

        bsTransferWarehouse.DataSource = dsMain;
        bsTransferWarehouse.DataMember = "Warehouse";
        
       

        repositorySalesOrder.DataSource = bsSaleOrder;
        repositorySalesOrder.DisplayMember = "SOrderNo";
        repositorySalesOrder.ValueMember = "SOrderId";
        repositorySalesOrder.PopupFormSize = new Size(350, 250);
        repositorySalesOrder.NullText = "";
        repositorySalesOrder.ShowFooter = false;
        //repositorySalesOrder.View.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
        //repositorySalesOrder.View.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Default;
        //repositorySalesOrder.View.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.Text;
        //repositorySalesOrder.
        repositorySalesOrder.View.OptionsView.ShowAutoFilterRow = true;
        //repositorySalesOrder.ContextButtonOptions.All
        repositorySalesOrder.View.OptionsView.ColumnAutoWidth = false;
        repositorySalesOrder.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
        repositorySalesOrder.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
        repositorySalesOrder.ImmediatePopup = true;
        repositorySalesOrder.PopulateViewColumns();
        GCDetail.RepositoryItems.Add(repositorySalesOrder);

        (GCDetail.MainView as GridView).Columns.ColumnByName("colSOrderId").ColumnEdit = repositorySalesOrder;

        if (repositorySalesOrder.View.Columns.Count > 0)
        {

            //repositorySalesOrder.View.Columns.ColumnByName("colSOrderId").Visible = false;

            //repositorySalesOrder.View.Columns.ColumnByName("colSOrderNo").Caption = "Order #";
            //repositorySalesOrder.View.Columns.ColumnByName("colPONo").Caption = "PO NO.";

            //repositorySalesOrder.View.Columns.ColumnByName("colSOrderNo").Width = 150;
            //repositorySalesOrder.View.Columns.ColumnByName("colPONo").Width = 100;

            //repositorySalesOrder.View.Columns.ColumnByName("colSOrderNo").VisibleIndex = 0;
            //repositorySalesOrder.View.Columns.ColumnByName("colPONo").VisibleIndex = 1;

            repositorySalesOrder.View.Columns.ColumnByName("colSOrderId").Visible = false;

            repositorySalesOrder.View.Columns.ColumnByName("colSOrderNo").Caption = "Order #";
            repositorySalesOrder.View.Columns.ColumnByName("colPONo").Caption = "PO_No";
            repositorySalesOrder.View.Columns.ColumnByName("colCustomerName").Caption = "Customer";
            repositorySalesOrder.View.Columns.ColumnByName("colFYear").Caption = "Year";

            repositorySalesOrder.View.Columns.ColumnByName("colSOrderNo").Width = 100;
            repositorySalesOrder.View.Columns.ColumnByName("colPONo").Width = 80;
            repositorySalesOrder.View.Columns.ColumnByName("colCustomerName").Width = 150;
            repositorySalesOrder.View.Columns.ColumnByName("colFYear").Width = 50;


            repositorySalesOrder.View.Columns.ColumnByName("colSOrderNo").VisibleIndex = 0;
            repositorySalesOrder.View.Columns.ColumnByName("colPONo").VisibleIndex = 1;
            repositorySalesOrder.View.Columns.ColumnByName("colCustomerName").VisibleIndex = 2;
            repositorySalesOrder.View.Columns.ColumnByName("colFYear").VisibleIndex = 3;
        }


        repositoryGridLookup.DataSource = bsProducts;
        repositoryGridLookup.DisplayMember = "ProductName";
        repositoryGridLookup.ValueMember = "ProductId";
        repositoryGridLookup.PopupFormSize = new Size(450, 250);
        repositoryGridLookup.NullText = "";
        repositoryGridLookup.ShowFooter = false;
        repositoryGridLookup.View.OptionsView.ColumnAutoWidth = false;
        repositoryGridLookup.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
        repositoryGridLookup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
        repositoryGridLookup.ImmediatePopup = true;
        repositoryGridLookup.PopulateViewColumns();
        GCDetail.RepositoryItems.Add(repositoryGridLookup);

        (GCDetail.MainView as GridView).Columns.ColumnByName("colProductId").ColumnEdit = repositoryGridLookup;

        if (repositoryGridLookup.View.Columns.Count > 0)
        {

            repositoryGridLookup.View.Columns.ColumnByName("colProductId").Visible = false;
            repositoryGridLookup.View.Columns.ColumnByName("colBarcode").Visible = false;
            repositoryGridLookup.View.Columns.ColumnByName("colDiscountPerc").Visible = false;
            repositoryGridLookup.View.Columns.ColumnByName("colProductCategoryId").Visible = false;
            repositoryGridLookup.View.Columns.ColumnByName("colCostPrice").Visible = false;
            repositoryGridLookup.View.Columns.ColumnByName("colQtyInhand").Visible = false;
            repositoryGridLookup.View.Columns.ColumnByName("colCategoryName").Visible = false;
            repositoryGridLookup.View.Columns.ColumnByName("colSOrderId").Visible = false;

            repositoryGridLookup.View.Columns.ColumnByName("colProductName").Caption = "Name";
            repositoryGridLookup.View.Columns.ColumnByName("colProductCode").Caption = "Code";
            repositoryGridLookup.View.Columns.ColumnByName("colOrderQty").Caption = "Order Qty";
            //repositoryGridLookup.View.Columns.ColumnByName("colCostPrice").Caption = "Cost Price";
            //repositoryGridLookup.View.Columns.ColumnByName("colQtyInhand").Caption = "QtyInHand";
            //repositoryGridLookup.View.Columns.ColumnByName("colCategoryName").Caption = "Category Name";

            repositoryGridLookup.View.Columns.ColumnByName("colProductName").Width = 150;
            repositoryGridLookup.View.Columns.ColumnByName("colProductCode").Width = 80;
            repositoryGridLookup.View.Columns.ColumnByName("colOrderQty").Width = 70;
            //repositoryGridLookup.View.Columns.ColumnByName("colQtyInhand").Width = 40;
            //repositoryGridLookup.View.Columns.ColumnByName("colCategoryName").Width = 100;

            repositoryGridLookup.View.Columns.ColumnByName("colProductCode").VisibleIndex = 0;
            repositoryGridLookup.View.Columns.ColumnByName("colProductName").VisibleIndex = 1;
            repositoryGridLookup.View.Columns.ColumnByName("colOrderQty").VisibleIndex = 2;
            //repositoryGridLookup.View.Columns.ColumnByName("colQtyInhand").VisibleIndex = 3;
            //repositoryGridLookup.View.Columns.ColumnByName("colCategoryName").VisibleIndex = 4;
        }


        //**************************
        repositoryWarehouseGridLookup.DataSource = bsWarehouse;
        repositoryWarehouseGridLookup.DisplayMember = "WarehouseName";
        repositoryWarehouseGridLookup.ValueMember = "WarehouseId";
        repositoryWarehouseGridLookup.PopupFormSize = new Size(250, 250);
        repositoryWarehouseGridLookup.NullText = "";
        repositoryWarehouseGridLookup.ShowFooter = false;
        repositoryWarehouseGridLookup.View.OptionsView.ColumnAutoWidth = false;
        repositoryWarehouseGridLookup.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
        repositoryWarehouseGridLookup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
        repositoryWarehouseGridLookup.ImmediatePopup = true;
        repositoryWarehouseGridLookup.PopulateViewColumns();
        GCDetail.RepositoryItems.Add(repositoryWarehouseGridLookup);

        (GCDetail.MainView as GridView).Columns.ColumnByName("colWarehouseId").ColumnEdit = repositoryWarehouseGridLookup;

        if (repositoryWarehouseGridLookup.View.Columns.Count > 0)
        {

            repositoryWarehouseGridLookup.View.Columns.ColumnByName("colWarehouseId").Visible = false;
            repositoryWarehouseGridLookup.View.Columns.ColumnByName("colWarehouseName").Caption = "Warehouse";
            repositoryWarehouseGridLookup.View.Columns.ColumnByName("colWarehouseName").Width = 150;
            repositoryWarehouseGridLookup.View.Columns.ColumnByName("colWarehouseName").VisibleIndex = 0;
        }

        //**************************
        repositoryTransferWarehouseGridLookup.DataSource = bsTransferWarehouse;
        repositoryTransferWarehouseGridLookup.DisplayMember = "WarehouseName";
        repositoryTransferWarehouseGridLookup.ValueMember = "WarehouseId";
        repositoryTransferWarehouseGridLookup.PopupFormSize = new Size(250, 250);
        repositoryTransferWarehouseGridLookup.NullText = "";
        repositoryTransferWarehouseGridLookup.ShowFooter = false;
        repositoryTransferWarehouseGridLookup.View.OptionsView.ColumnAutoWidth = false;
        repositoryTransferWarehouseGridLookup.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
        repositoryTransferWarehouseGridLookup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
        repositoryTransferWarehouseGridLookup.ImmediatePopup = true;
        repositoryTransferWarehouseGridLookup.PopulateViewColumns();
        GCDetail.RepositoryItems.Add(repositoryTransferWarehouseGridLookup);

        (GCDetail.MainView as GridView).Columns.ColumnByName("colTransferWarehouseId").ColumnEdit = repositoryTransferWarehouseGridLookup;

        if (repositoryTransferWarehouseGridLookup.View.Columns.Count > 0)
        {

            repositoryTransferWarehouseGridLookup.View.Columns.ColumnByName("colWarehouseId").Visible = false;
            repositoryTransferWarehouseGridLookup.View.Columns.ColumnByName("colWarehouseName").Caption = "Warehouse";
            repositoryTransferWarehouseGridLookup.View.Columns.ColumnByName("colWarehouseName").Width = 150;
            repositoryTransferWarehouseGridLookup.View.Columns.ColumnByName("colWarehouseName").VisibleIndex = 0;
        }

    }

    private void ButtonRights(bool Enable)
    {
        btnAdd.Enabled = Enable;
        btnUpdate.Enabled = !Enable;
        //GCDetail.Enabled = !Enable;
        btnDelete.Enabled = !Enable;
        txtCode.ReadOnly = !Enable;

    }

    private bool Validation()
    {
        bool result = true;

        if (dsMain.Tables["ProcessDetail"].Rows.Count <= 0)
        {
            MessageBox.Show("Please Enter Detail of Processing Transfer.", "Detail Not Found.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            result = false;
            GCDetail.Focus();
            return result;
        }
        //if (string.IsNullOrEmpty(txtSOrderNo.Text))
        //{
        //    MessageBox.Show("Please Select Sales Order Number", "Sales Order is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    result = false;
        //    btnSOSearch.Focus();
        //    return result;
        //}

        //if (string.IsNullOrEmpty(txtPCode.Text))
        //{
        //    MessageBox.Show("Please Select Product Name", "Product Name is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    result = false;
        //    btnPSearch.Focus();
        //    return result;
        //}

        //if (string.IsNullOrEmpty(txtProcessQty.Text))
        //{
        //    if (ProcessMasterId < 0)
        //    {
        //        MessageBox.Show("Please Enter Process Quantity", "Process Quantity is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        result = false;
        //        txtProcessQty.Focus();
        //        return result;
        //    }
        //}

        //if (Convert.ToDecimal(txtProcessQty.Text) <= 0)
        //{
        //    if (ProcessMasterId < 0)
        //    {
        //        MessageBox.Show("Please Enter Process Quantity", "Process Quantity is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        result = false;
        //        txtProcessQty.Focus();
        //        return result;
        //    }

        //}

        //if (Convert.ToInt32(cmbWarehouse.SelectedValue) <= 0)
        //{
        //    MessageBox.Show("Please Select Depart Name", "Depart Name is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    result = false;
        //    cmbWarehouse.Focus();
        //    return result;
        //}

        //if (Convert.ToInt32(cmbTransferWarehouse.SelectedValue) <= 0)
        //{
        //    MessageBox.Show("Please Select Depart Name", "Depart Name is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    result = false;
        //    cmbTransferWarehouse.Focus();
        //    return result;
        //}

        //if (Convert.ToInt32(cmbTransferWarehouse.SelectedValue) == Convert.ToInt32(cmbWarehouse.SelectedValue))
        //{
        //    MessageBox.Show("Please Select Transfer Depart Name", "Transfer Depart Name is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    result = false;
        //    cmbTransferWarehouse.Focus();
        //    return result;
        //}
        //            if (dsGrid.Tables["ProductionDetail"].Rows.Count <= 0)
        //{
        //    MessageBox.Show("Please Enter Production Detail", "Production Details Not Found.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    result = false;
        //    cmbFormula.Focus();
        //    return result;
        //}

        return result;
    }

    private void ClearFeilds()
    {

        //txtFormulaName.Text = string.Empty;
        txtSOrderNo.Text = string.Empty;
        txtPCode.Text = string.Empty;
        txtOrderQty.Text = string.Empty;
        txtDoneQty.Text = string.Empty;
        txtProcessQty.Text = string.Empty;
        dtpOrder.Value = DateTime.Now;
        dtp.Value = DateTime.Now;

        cmbWarehouse.SelectedValue = -1;
        cmbTransferWarehouse.SelectedValue = -1;

        txtRemarks.Text = string.Empty;
        pbitem.Image = FIL.Properties.Resources.User;
        ProcessMasterId = -1;
        DeletedIds = new List<int>();
        txtProcessQty.ReadOnly = false;


        cmbWarehouse.Enabled = true;
        btnSOSearch.Enabled = true;
        btnPSearch.Enabled = true;
        IsProcessLoaded = false;

        dsMain.Tables["ProcessDetail"].Rows.Clear();
        dsMain.Tables["ProcessMaster"].Rows.Clear();

        dsMain.RejectChanges();
        drMaster = dsMain.Tables["ProcessMaster"].NewRow();
        dsMain.Tables["ProcessMaster"].Rows.Add(drMaster);
        // GCDetail.DataSource = dsMain.Tables["FormulaDetail"];
        //GridSetting();
        txtCode.Text = GetNewNextNumber();
        try
        {
            bsProducts.Filter = "SOrderId = " + -1 + "";
        }
        catch (Exception ex)
        {
        }

        ButtonRights(true);
        btnNextInvioceNo.Enabled = false;
        btnPrevInvioceNo.Enabled = false;


    }

    public Image Base64ToImage(string base64String)
    {
        // Convert Base64 String to byte[]
        byte[] imageBytes = Convert.FromBase64String(base64String);
        MemoryStream ms = new MemoryStream(imageBytes, 0,
          imageBytes.Length);

        // Convert byte[] to Image
        ms.Write(imageBytes, 0, imageBytes.Length);
        Image image = Image.FromStream(ms, true);
        return image;
    }

    private void LoadProcess()
    {
        IsProcessLoaded = true;
        setupGrip();
        txtSOrderNo.Text = dsMain.Tables["ProcessMaster"].Rows[0]["SOrderNo"].ToString();
        //DataTable dtProduct = new DataTable();
        //dtProduct = manageProduct.GetProduct(Convert.ToInt32(dsMain.Tables["ProcessMaster"].Rows[0]["ProductId"]));
        //if (dtProduct.Rows.Count > 0)
        //{
        //    txtPCode.Text = dtProduct.Rows[0]["ProductCode"].ToString();
        //}
        //txtProcessQty.Text = dsMain.Tables["ProcessMaster"].Rows[0]["ProcessQty"].ToString();
        dtp.Value = Convert.ToDateTime(dsMain.Tables["ProcessMaster"].Rows[0]["Date"]);
        cmbWarehouse.SelectedValue = dsMain.Tables["ProcessMaster"].Rows[0]["WarehouseId"].ToString();
        cmbTransferWarehouse.SelectedValue = dsMain.Tables["ProcessMaster"].Rows[0]["TransferWarehouseId"].ToString();
        txtRemarks.Text = dsMain.Tables["ProcessMaster"].Rows[0]["Remarks"].ToString();

        //txtProcessQty.ReadOnly = true;
       // cmbWarehouse.Enabled = false;

        btnSOSearch.Enabled = false;
        btnPSearch.Enabled = false;
        IsProcessLoaded = false;
        ButtonRights(false);
    }

    #endregion

    #region Grid Events
    private void gvDetail_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
    {
        //GridView view = sender as GridView;
        //object cellValue = view.GetRowCellValue(e.RowHandle, gvDetail.Columns[0]);
        //MessageBox.Show(cellValue.ToString());

        //if (e.Value != null)
        //{
        //    switch (e.Column.Name.ToString())
        //    {
        //        case "colProductId":
        //            {
        //                try
        //                {

        //                    //dvProduct.RowFilter = "ProductId='" + e.Value.ToString() + "'";
        //                }
        //                catch
        //                {
        //                }
        //                break;
        //            }

        //    }
        //}
        try
        {
            DataRow dr = gvDetail.GetFocusedDataRow();
            if (dr == null)
            {
                return;
            }

            //switch (e.Column.Name.ToString())
            //{
            //    case "colSOrderId":
            //        bsProducts.Filter = "SOrderId = " + dr["SOrderId"].ToString() + "";
            //        break;

            //    case "colProductId":


            //        break;

            //}
        
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

    }


    private void Custom_RowStyle(object sender, RowStyleEventArgs e)
    {
        //try
        //{
        //    GridView View = sender as GridView;
        //    if (e.RowHandle >= 0)
        //    {
        //        int DetailId = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, View.Columns["PDId"])); //View.GetRowCellDisplayText(e.RowHandle, View.Columns["PMDId"]);
        //        if (DetailId > 0)
        //        {
        //            e.Appearance.BackColor = Color.FromArgb(150, Color.LightGreen); //Color.LightCoral
        //            e.Appearance.BackColor2 = Color.White;
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{ 
        //}

    }

    private void gvDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
    {
        try
        {
            DataRow dr = gvDetail.GetFocusedDataRow();
            switch (e.Column.Name.ToString())
            {

                case "colSOrderId":
                    bsProducts.Filter = "SOrderId = " + dr["SOrderId"].ToString() + "";
                    break;

                case "colProductId":
                    break;

                //case "colWarehouseId":
                //    {
                //        int WarehouseId = -1;
                //        Nullable<DateTime> Dated = null;
                //        if (!string.IsNullOrEmpty(dr["ReceivedDate"].ToString()))
                //        {
                //            Dated = Convert.ToDateTime(dr["ReceivedDate"].ToString());
                //        }
                //        WarehouseId = (string.IsNullOrEmpty(dr["WarehouseId"].ToString()) ? -1 : Convert.ToInt32(dr["WarehouseId"]));
                //        dr["ReceivedQty"] = manageProcessing.GetRemainigQtyByWarehouseAndDate(txtSOrderNo.Text, WarehouseId, Dated);
                //        break;
                //    }
                //case "colReceivedDate":
                //    {
                //        int WarehouseId = -1;
                //        Nullable<DateTime> Dated = null;
                //        if (!string.IsNullOrEmpty(dr["ReceivedDate"].ToString()))
                //        {
                //            Dated = Convert.ToDateTime(dr["ReceivedDate"].ToString());
                //        }
                //        WarehouseId = (string.IsNullOrEmpty(dr["WarehouseId"].ToString()) ? -1 : Convert.ToInt32(dr["WarehouseId"]));
                //        dr["ReceivedQty"] = manageProcessing.GetRemainigQtyByWarehouseAndDate(txtSOrderNo.Text, WarehouseId, Dated);
                //        break;
                //    }
                //case "colProcessQty":
                //    {
                //        decimal ReceivedQty = (string.IsNullOrEmpty(dr["ReceivedQty"].ToString()) ? 0 : Convert.ToDecimal(dr["ReceivedQty"]));
                //        decimal ProcessQty = (string.IsNullOrEmpty(dr["ProcessQty"].ToString()) ? 0 : Convert.ToDecimal(dr["ProcessQty"]));
                //        decimal RejectQty = (string.IsNullOrEmpty(dr["RejectQty"].ToString()) ? 0 : Convert.ToDecimal(dr["RejectQty"]));

                //        dr["BalanceQty"] = ReceivedQty - ProcessQty - RejectQty;

                //        break;
                //    }
                //case "colRejectQty":
                //    {

                //        decimal ReceivedQty = (string.IsNullOrEmpty(dr["ReceivedQty"].ToString()) ? 0 : Convert.ToDecimal(dr["ReceivedQty"]));
                //        decimal ProcessQty = (string.IsNullOrEmpty(dr["ProcessQty"].ToString()) ? 0 : Convert.ToDecimal(dr["ProcessQty"]));
                //        decimal RejectQty = (string.IsNullOrEmpty(dr["RejectQty"].ToString()) ? 0 : Convert.ToDecimal(dr["RejectQty"]));

                //        dr["BalanceQty"] = ReceivedQty - ProcessQty - RejectQty;

                //        break;
                //    }


            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void gvDetail_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
    {
        try
        {
            DataRow dr = gvDetail.GetFocusedDataRow();
            if ((dr != null))
            {
                //if (!string.IsNullOrEmpty(dr["ProductId"].ToString()))
                //{
                //    //dvProduct.RowFilter = "ProductId='" + dr["ProductId"].ToString() + "'";
                //}
                //bsProducts.Filter = "SOrderId = " + (string.IsNullOrEmpty(dr["SOrderId"].ToString()) ? -1 : Convert.ToInt32(dr["SOrderId"].ToString())) + "";
                //bsPendingSOProducts.Filter = "ProductId = '" + (string.IsNullOrEmpty(dr["ProductId"].ToString()) ? -1 : Convert.ToInt32(dr["ProductId"].ToString())) + "' and SOrderId  = '" + (string.IsNullOrEmpty(dr["SOrderId"].ToString()) ? -1 : Convert.ToInt32(dr["SOrderId"].ToString())) + "'";
                //dvProducts.RowFilter = "ProductId='" + dr["ProductId"].ToString() + "'";

                bsProducts.Filter = "SOrderId = " + dr["SOrderId"].ToString() + "";
                bsDisplayProducts.Filter = "ProductId = " + dr["ProductId"].ToString() + "";
               
            }
        }
        catch (Exception ex)
        {
        }

    }

    private void gvDetail_GotFocus(object sender, EventArgs e)
    {
        gvDetail_FocusedRowChanged(null, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(0, gvDetail.FocusedRowHandle));
    }

    private void gvDetail_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
    {
        if (e.Value != null)
        {
            DataRowView dr = (DataRowView)gvDetail.GetFocusedRow();
            if ((dr != null))
            {
                try
                {
                    switch (gvDetail.FocusedColumn.Name)
                    {
                        case "colReceivedDate":
                            if (string.IsNullOrEmpty(e.Value.ToString()))
                            {
                                MessageBox.Show("Please Enter Received Date", "Date Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                e.Valid = false;

                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
        else
        {
            gvDetail.CancelUpdateCurrentRow();
        }
    }

    private void gvDetail_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
    {
        MessageBox.Show(e.ErrorText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void gvDetail_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
    {
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;

        switch (gvDetail.FocusedColumn.Name)
        {
            case "colProductId":
                gvDetail.FocusedColumn = gvDetail.Columns.ColumnByName("colProductId");
                break;
        }
        gvDetail.HideEditor();
    }
    private void gvDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
    {

        bool result = true;
        DataRow dr = default(DataRow);
        dr = gvDetail.GetDataRow(e.RowHandle);

        //if (string.IsNullOrEmpty(dr["WarehouseId"].ToString()))
        //{
        //    //e.Valid = false;
        //    result = false;
        //    e.ErrorText = "Depart Name is Missing.";
        //}
        //else if (string.IsNullOrEmpty(dr["ReceivedDate"].ToString()))
        //{
        //    //e.Valid = false;
        //    result = false;
        //    e.ErrorText = "Received Date Not Found.";
        //}
        //else if (string.IsNullOrEmpty(dr["ProcessQty"].ToString()))
        //{
        //    //e.Valid = false;
        //    result = false;
        //    e.ErrorText = "Process Qty Not Found.";
        //}
        ////else if (Convert.ToDecimal(dr["ProcessQty"].ToString()) <= 0)
        ////{
        ////    //e.Valid = false;
        ////    result = false;
        ////    e.ErrorText = "Process Qty Not Found.";
        ////}
        //else if (!string.IsNullOrEmpty(dr["TransferWarehouseId"].ToString()))
        //{
        //    //e.Valid = false;
        //    //e.ErrorText = "Transfer Depart Name Not Found.";
        //    if (Convert.ToInt32(dr["TransferWarehouseId"].ToString()) > 0)
        //    {
        //        if (string.IsNullOrEmpty(dr["TransferDate"].ToString()))
        //        {
        //            //e.Valid = false;
        //            result = false;
        //            e.ErrorText = "Transfer Date Not Found.";
        //        }
        //        if ((string.IsNullOrEmpty(dr["ProcessQty"].ToString()) ? 0 : Convert.ToDecimal(dr["ProcessQty"].ToString())) > 0 || (string.IsNullOrEmpty(dr["RejectQty"].ToString()) ? 0 : Convert.ToDecimal(dr["RejectQty"].ToString())) > 0)
        //        {
        //            //e.Valid = false;
        //            //result = false;
        //            //e.ErrorText = "Process Qty Not Found.";
        //        }
        //        else
        //        {
        //            result = false;
        //            e.ErrorText = "Process / Reject Qty Not Found.";
        //        }
        //    }
        //}
        //else if (!string.IsNullOrEmpty(dr["TransferDate"].ToString()))
        //{
        //    //e.Valid = false;
        //    //e.ErrorText = "Transfer Depart Name Not Found.";
        //    if (string.IsNullOrEmpty(dr["TransferWarehouseId"].ToString()))
        //    {
        //        //e.Valid = false;
        //        result = false;
        //        e.ErrorText = "Transfer Depart Name Not Found.";
        //    }
        //}

        //if (!string.IsNullOrEmpty(dr["TransferWarehouseId"].ToString()) && !string.IsNullOrEmpty(dr["WarehouseId"].ToString()))
        //{
        //    if (dr["TransferWarehouseId"].ToString() == dr["WarehouseId"].ToString())
        //    {
        //        result = false;
        //        e.ErrorText = "From Depart and Transfer Depart will not Same";

        //    }
        //}

        //else if (string.IsNullOrEmpty(dr["TransferDate"].ToString()))
        //{
        //    e.Valid = false;
        //    e.ErrorText = "Transfer Date Not Found.";
        //}
        //else
        //{
        //    e.Valid = true;
        //    gvDetail.GetDataRow(e.RowHandle)["ProcessMasterId"] = drMaster["ProcessMasterId"];
        //}

        if (string.IsNullOrEmpty(dr["SOrderId"].ToString()))
        {
            //e.Valid = false;
            result = false;
            e.ErrorText = "Sales Order Number Missing.";
        }
         else if (string.IsNullOrEmpty(dr["ProductId"].ToString()))
        {
            //e.Valid = false;
            result = false;
            e.ErrorText = "Article Name is Missing.";
        }
        else if ((string.IsNullOrEmpty(dr["ProcessQty"].ToString()) ? 0 : Convert.ToDecimal(dr["ProcessQty"].ToString())) <= 0 )
        {
            if ((string.IsNullOrEmpty(dr["RejectQty"].ToString()) ? 0 : Convert.ToDecimal(dr["RejectQty"].ToString())) <= 0)
            {
                result = false;
                e.ErrorText = "Quantity Missing.";
            }
            //e.Valid = false;
            
        }
        //else if (string.IsNullOrEmpty(dr["ProcessQty"].ToString()))
        //{
        //    //e.Valid = false;
        //    result = false;
        //    e.ErrorText = "Quantity Missing.";
        //}
        //else if (Convert.ToDecimal(dr["ProcessQty"].ToString()) <= 0)
        //{
        //    //e.Valid = false;
        //    result = false;
        //    e.ErrorText = "Quantity Missing.";
        //}
        else if (string.IsNullOrEmpty(dr["WarehouseId"].ToString()))
        {
            result = false;
            e.ErrorText = "From Department Name is Missing.";
        }
        else if (string.IsNullOrEmpty(dr["TransferWarehouseId"].ToString()))
        {
            result = false;
            e.ErrorText = "Transfer Department Name is Missing.";
        }
        else if (Convert.ToDecimal(dr["WarehouseId"].ToString()) <= 0)
        {
            result = false;
            e.ErrorText = "From Department Name is Missing.";
        }
        else if (Convert.ToDecimal(dr["TransferWarehouseId"].ToString()) <= 0)
        {
            result = false;
            e.ErrorText = "Transfer Department Name is Missing.";
        }
        else if (Convert.ToDecimal(dr["TransferWarehouseId"].ToString()) == Convert.ToDecimal(dr["WarehouseId"].ToString()))
        {
            result = false;
            e.ErrorText = "Same Department Transfer Not Allowed.";
        }


        else if (dr.RowState == DataRowState.Detached || dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Modified)
        {
            if (dsMain.Tables["ProcessDetail"].Select("ProductId ='" + dr["ProductId"].ToString() + "' And SOrderId = '" + dr["SOrderId"].ToString() + "' and WarehouseId = '" + dr["WarehouseId"].ToString() + "' and TransferWarehouseId = '" + dr["TransferWarehouseId"].ToString() + "' and ProcessDetailId <>  " + dr["ProcessDetailId"].ToString() + " ").Length > 0)
            {
                e.ErrorText = "Same Sale Order and Same Item and Same Department Already Exists.";
                //MessageBox.Show("Same Sale Order and Same Item Already Exists", "Same SO and Items can not be repeated.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
            }
        }
        
        if (bsProducts.List.Count > 0)
        {
            DataView dv = (DataView)bsProducts.List;
            DataTable dtProduct = dv.ToTable();
            DataRow drProduct = dtProduct.Select("ProductId = '" + dr["ProductId"].ToString() + "'")[0];
            if ((string.IsNullOrEmpty(dr["ProcessQty"].ToString())? 0 : Convert.ToDecimal(dr["ProcessQty"].ToString())) > Convert.ToDecimal(drProduct["OrderQty"]))
            {
                e.ErrorText = "Quantity Should not be greater then Order Qty.";
                result = false;
            }
        }
        
        e.Valid = result;
        if (result)
        {
            gvDetail.GetDataRow(e.RowHandle)["ProcessMasterId"] = drMaster["ProcessMasterId"];
        }
    }

    #endregion

    private void btnAdd_Click(object sender, EventArgs e)
    {
        if (Validation())
        {
            //int ProductId = -1;
            //ProductId = manageProduct.GetProductIdByCode(txtPCode.Text);
            //if (ProductId <= 0)
            //{
            //    MessageBox.Show("Article not Found. Please Select Article Name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    btnPSearch.Focus();
            //    return;
            //}
            try
            {
                
                dataAcess.BeginTransaction();
                if (dataAcess.getDBCommand().Transaction == null)
                {
                    dataAcess.SetDBTransaction();
                }
                DataTable dtProcess = manageProcessing.InsertProcessMaster(dtp.Value, -1,  (string.IsNullOrEmpty(txtProcessQty.Text) ? 0 : Convert.ToDecimal(txtProcessQty.Text)), -1 , -1 , "" , txtRemarks.Text, dataAcess);
                if (dtProcess.Rows.Count > 0)
                {
                    ProcessMasterId = Convert.ToInt32(dtProcess.Rows[0]["Id"].ToString());
                }
                else
                {
                    throw new Exception("Data not Inserted.");
                }
                if (ProcessMasterId > 0)
                {
                    //Detail Works
                    foreach (DataRow drDetail in dsMain.Tables["ProcessDetail"].Rows)
                    {
                        if (drDetail.RowState != DataRowState.Deleted)
                        {

                            int ProductId = -1;
                            string SOrderNo = string.Empty;
                            SOrderNo = dsMain.Tables["SOrder"].Select("SOrderId = '" + drDetail["SOrderId"].ToString() +"'")[0]["SOrderNo"].ToString();
                            ProductId = (string.IsNullOrEmpty(drDetail["ProductId"].ToString()) ? -1 : Convert.ToInt32(drDetail["ProductId"]));


                            //******Validation for Database level , check quantity exsits or not.
                            decimal ValidQty = manageProcessing.GetProcessingQtyBalance(ProductId, dtp.Value, (string.IsNullOrEmpty(drDetail["WarehouseId"].ToString()) ? -1 : Convert.ToInt32(drDetail["WarehouseId"])),
                                SOrderNo, ProductId, dataAcess);

                            if ((string.IsNullOrEmpty(drDetail["ProcessQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ProcessQty"])) > ValidQty)
                            {

                                dataAcess.TransRollback();
                                throw new Exception("Invalid Process Qty Enterd in " + SOrderNo + " . and Article Name :" + manageProduct.GetProduct(ProductId).Rows[0]["ProductName"].ToString() +
                                    " and Warehouse Name :" + manageWarehouse.GetWarehouse((string.IsNullOrEmpty(drDetail["WarehouseId"].ToString()) ? -1 : Convert.ToInt32(drDetail["WarehouseId"]))).Rows[0]["Name"].ToString());

                            }
                            //*******************************************************************

                            int DetailId = manageProcessing.InsertUpdateProcessMasterDetail(Convert.ToInt32(drDetail["ProcessDetailId"]), ProcessMasterId,
                                (string.IsNullOrEmpty(drDetail["SOrderId"].ToString()) ? -1 : Convert.ToInt32(drDetail["SOrderId"])),
                                ProductId, (string.IsNullOrEmpty(drDetail["WarehouseId"].ToString()) ? -1 : Convert.ToInt32(drDetail["WarehouseId"])), dtp.Value, 0, (string.IsNullOrEmpty(drDetail["ProcessQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ProcessQty"])),
                                                                       (string.IsNullOrEmpty(drDetail["RejectQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["RejectQty"])) , (string.IsNullOrEmpty(drDetail["TransferWarehouseId"].ToString()) ? -1 : Convert.ToInt32(drDetail["TransferWarehouseId"])), null, -1, drDetail["Remarks"].ToString(), dataAcess);
                            
                            ////pehele yeh From Depart se Out hoga  Process Qty
                            //manageProcessing.InsertUpdateProductionLedger((string.IsNullOrEmpty(drDetail["WarehouseId"].ToString()) ? -1 : Convert.ToInt32(drDetail["WarehouseId"])) , ProductId, -1, SOrderNo, dtp.Value, txtCode.Text, DetailId, "O",
                            //(string.IsNullOrEmpty(drDetail["ProcessQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ProcessQty"])), -1, drDetail["Remarks"].ToString(), false, dataAcess);


                            ////then jis Dart ko Transfer kara ha usko In kry ga. Process Qty
                            //manageProcessing.InsertUpdateProductionLedger((string.IsNullOrEmpty(drDetail["TransferWarehouseId"].ToString()) ? -1 : Convert.ToInt32(drDetail["TransferWarehouseId"])), ProductId, -1, SOrderNo, dtp.Value, txtCode.Text,
                            //    DetailId , "I" , (string.IsNullOrEmpty(drDetail["ProcessQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ProcessQty"])) ,-1 , drDetail["Remarks"].ToString() , false , dataAcess);

                            if ((string.IsNullOrEmpty(drDetail["ProcessQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ProcessQty"])) > 0)
                            {
                                //pehele yeh From Depart se Out hoga  Process Qty
                                manageProcessing.InsertUpdateProductionLedger((string.IsNullOrEmpty(drDetail["WarehouseId"].ToString()) ? -1 : Convert.ToInt32(drDetail["WarehouseId"])), ProductId, -1, SOrderNo, dtp.Value, txtCode.Text, DetailId, "O",
                                (string.IsNullOrEmpty(drDetail["ProcessQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ProcessQty"])), -1, drDetail["Remarks"].ToString(), false, dataAcess);


                                //then jis Dart ko Transfer kara ha usko In kry ga. Process Qty
                                manageProcessing.InsertUpdateProductionLedger((string.IsNullOrEmpty(drDetail["TransferWarehouseId"].ToString()) ? -1 : Convert.ToInt32(drDetail["TransferWarehouseId"])), ProductId, -1, SOrderNo, dtp.Value, txtCode.Text,
                                    DetailId, "I", (string.IsNullOrEmpty(drDetail["ProcessQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ProcessQty"])), -1, drDetail["Remarks"].ToString(), false, dataAcess);
                            }

                            if ((string.IsNullOrEmpty(drDetail["RejectQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["RejectQty"])) > 0)
                            {
                                //pehele yeh From Depart se Out hoga  Reject Qty
                                manageProcessing.InsertUpdateProductionLedger((string.IsNullOrEmpty(drDetail["WarehouseId"].ToString()) ? -1 : Convert.ToInt32(drDetail["WarehouseId"])), ProductId, -1, SOrderNo, dtp.Value, txtCode.Text, DetailId, "O",
                                (string.IsNullOrEmpty(drDetail["RejectQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["RejectQty"])), -1, drDetail["Remarks"].ToString(), true, dataAcess);


                                //then jis Dart ko Transfer kara ha usko In kry ga. Reject Qty
                                manageProcessing.InsertUpdateProductionLedger((string.IsNullOrEmpty(drDetail["TransferWarehouseId"].ToString()) ? -1 : Convert.ToInt32(drDetail["TransferWarehouseId"])), ProductId, -1, SOrderNo, dtp.Value, txtCode.Text,
                                    DetailId, "I", (string.IsNullOrEmpty(drDetail["RejectQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["RejectQty"])), -1, drDetail["Remarks"].ToString(), true, dataAcess);
                            }

                        }
                    }
                    //jase hi koi new Proccess Line create hogi toh by defult jahan se start hogi chain wahan ki entrry detail mai and Production Ledger mai ker dy gy.
                    //int DetailId = manageProcessing.InsertUpdateProcessMasterDetail(-1, ProcessMasterId, Convert.ToInt32(cmbWarehouse.SelectedValue), dtp.Value,
                    //                                                  (string.IsNullOrEmpty(txtProcessQty.Text) ? 0 : Convert.ToDecimal(txtProcessQty.Text)),
                    //                                                   0, 0, -1, null, -1, "", dataAcess);
                    //int ProductionLedgerId = manageProcessing.InsertUpdateProductionLedger(Convert.ToInt32(cmbWarehouse.SelectedValue), ProductId, -1, txtSOrderNo.Text, dtp.Value, dtProcess.Rows[0]["Code"].ToString(), DetailId, "I", (string.IsNullOrEmpty(txtProcessQty.Text) ? 0 : Convert.ToDecimal(txtProcessQty.Text)), -1, "", false, dataAcess);

                    //if (Convert.ToDecimal(txtDoneQty.Text) + Convert.ToDecimal(txtProcessQty.Text) == Convert.ToDecimal(txtOrderQty.Text))
                    //{
                    //    //its means k is SO ka yeh Product , Complete Process line mai ja chuka hai ab iski same info again isert nh ho sakti Salman.
                    //    manageSalesOrder.UpdateSODetail_ProcessingComplete(txtSOrderNo.Text, manageProduct.GetProductIdByCode(txtPCode.Text), dataAcess);
                    //}

                    ////yeh Method is liye banaya hai k agr Sales Order Detail k all Item Processing Closed Mark hogye hain toh Sales Master ko bhi Processing Closed Mark maar do , q k bar bar search mai uska naam nh aye ga .
                    //manageSalesOrder.Check_And_Update_SOMaster_ProcessingClosed(txtSOrderNo.Text, dataAcess);

                }
                dataAcess.TransCommit();
                MessageBox.Show("Process Data Insert Sucessfully.", "Record Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
                //LoadProcess();

            }
            catch (SqlException sqlex)
            {
                dataAcess.TransRollback();
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataAcess.ConnectionClose();
            }

        }
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Validation())
        {
            //int ProductId = -1;
            //ProductId = manageProduct.GetProductIdByCode(txtPCode.Text);
            //if (ProductId <= 0)
            //{
            //    MessageBox.Show("Product Identity not Found. Please Select Product Name");
            //    btnPSearch.Focus();
            //    return;
            //}
            try
            {
                dataAcess.BeginTransaction();
                if (dataAcess.getDBCommand().Transaction == null)
                {
                    dataAcess.SetDBTransaction();
                }

                foreach (int id in DeletedIds)
                {
                    manageProcessing.DeleteProcessDetailByDetailId(id, dataAcess);
                }
                //manageProduct.DeleteFormulaDetailByMasterId(FormulaId, dataAcess);
                manageProcessing.UpdateProcessMaster(ProcessMasterId, dtp.Value, -1, 0 , -1 , -1  , "" , txtRemarks.Text, dataAcess);
                //Detail Works
                //DeleteProductionLedgerByTransNo
                manageProcessing.DeleteProductionLedgerByTransNo(txtCode.Text, dataAcess);
                foreach (DataRow drDetail in dsMain.Tables["ProcessDetail"].Rows)
                {
                    if (drDetail.RowState != DataRowState.Deleted)
                    {
                        int ProductId = -1;
                        string SOrderNo = string.Empty;
                        SOrderNo = dsMain.Tables["SOrder"].Select("SOrderId = '" + drDetail["SOrderId"].ToString() + "'")[0]["SOrderNo"].ToString();
                        ProductId = (string.IsNullOrEmpty(drDetail["ProductId"].ToString()) ? -1 : Convert.ToInt32(drDetail["ProductId"]));



                        //******Validation for Database level , check quantity exsits or not.
                        decimal ValidQty = manageProcessing.GetProcessingQtyBalance(ProductId, dtp.Value, (string.IsNullOrEmpty(drDetail["WarehouseId"].ToString()) ? -1 : Convert.ToInt32(drDetail["WarehouseId"])),
                            SOrderNo, ProductId, dataAcess);

                        if ((string.IsNullOrEmpty(drDetail["ProcessQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ProcessQty"])) > ValidQty)
                        {

                            dataAcess.TransRollback();
                            throw new Exception("Invalid Process Qty Enterd in " + SOrderNo + " . and Article Name :" + manageProduct.GetProduct(ProductId).Rows[0]["ProductName"].ToString() +
                                " and Warehouse Name :" + manageWarehouse.GetWarehouse((string.IsNullOrEmpty(drDetail["WarehouseId"].ToString()) ? -1 : Convert.ToInt32(drDetail["WarehouseId"]))).Rows[0]["Name"].ToString());

                        }
                        //*******************************************************************


                        //int DetailId = manageProcessing.InsertUpdateProcessMasterDetail(Convert.ToInt32(drDetail["ProcessDetailId"]), ProcessMasterId,
                        //       (string.IsNullOrEmpty(drDetail["SOrderId"].ToString()) ? -1 : Convert.ToInt32(drDetail["SOrderId"])),
                        //       ProductId, -1, dtp.Value, 0, (string.IsNullOrEmpty(drDetail["ProcessQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ProcessQty"])),
                        //                                              0, -1, null, -1, drDetail["Remarks"].ToString(), dataAcess);
                        int DetailId = manageProcessing.InsertUpdateProcessMasterDetail(Convert.ToInt32(drDetail["ProcessDetailId"]), ProcessMasterId,
                              (string.IsNullOrEmpty(drDetail["SOrderId"].ToString()) ? -1 : Convert.ToInt32(drDetail["SOrderId"])),
                              ProductId, (string.IsNullOrEmpty(drDetail["WarehouseId"].ToString()) ? -1 : Convert.ToInt32(drDetail["WarehouseId"])), dtp.Value, 0, (string.IsNullOrEmpty(drDetail["ProcessQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ProcessQty"])),
                                                                     (string.IsNullOrEmpty(drDetail["RejectQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["RejectQty"])) , (string.IsNullOrEmpty(drDetail["TransferWarehouseId"].ToString()) ? -1 : Convert.ToInt32(drDetail["TransferWarehouseId"])), null, -1, drDetail["Remarks"].ToString(), dataAcess);

                        ////pehele yeh From Depart se Out hoga  Process Qty
                        //manageProcessing.InsertUpdateProductionLedger(Convert.ToInt32(cmbWarehouse.SelectedValue), ProductId, -1, SOrderNo, dtp.Value, txtCode.Text, DetailId, "O",
                        //(string.IsNullOrEmpty(drDetail["ProcessQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ProcessQty"])), -1, drDetail["Remarks"].ToString(), false, dataAcess);


                        ////then jis Dart ko Transfer kara ha usko In kry ga. Process Qty
                        //manageProcessing.InsertUpdateProductionLedger(Convert.ToInt32(cmbTransferWarehouse.SelectedValue), ProductId, -1, SOrderNo, dtp.Value, txtCode.Text,
                        //    DetailId, "I", (string.IsNullOrEmpty(drDetail["ProcessQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ProcessQty"])), -1, drDetail["Remarks"].ToString(), false, dataAcess);

                        if ((string.IsNullOrEmpty(drDetail["ProcessQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ProcessQty"])) > 0)
                        {
                            //pehele yeh From Depart se Out hoga  Process Qty
                            manageProcessing.InsertUpdateProductionLedger((string.IsNullOrEmpty(drDetail["WarehouseId"].ToString()) ? -1 : Convert.ToInt32(drDetail["WarehouseId"])), ProductId, -1, SOrderNo, dtp.Value, txtCode.Text, DetailId, "O",
                            (string.IsNullOrEmpty(drDetail["ProcessQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ProcessQty"])), -1, drDetail["Remarks"].ToString(), false, dataAcess);


                            //then jis Dart ko Transfer kara ha usko In kry ga. Process Qty
                            manageProcessing.InsertUpdateProductionLedger((string.IsNullOrEmpty(drDetail["TransferWarehouseId"].ToString()) ? -1 : Convert.ToInt32(drDetail["TransferWarehouseId"])), ProductId, -1, SOrderNo, dtp.Value, txtCode.Text,
                                DetailId, "I", (string.IsNullOrEmpty(drDetail["ProcessQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ProcessQty"])), -1, drDetail["Remarks"].ToString(), false, dataAcess);
                        }

                        if ((string.IsNullOrEmpty(drDetail["RejectQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["RejectQty"])) > 0)
                        {
                            //pehele yeh From Depart se Out hoga  Reject Qty
                            manageProcessing.InsertUpdateProductionLedger((string.IsNullOrEmpty(drDetail["WarehouseId"].ToString()) ? -1 : Convert.ToInt32(drDetail["WarehouseId"])), ProductId, -1, SOrderNo, dtp.Value, txtCode.Text, DetailId, "O",
                            (string.IsNullOrEmpty(drDetail["RejectQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["RejectQty"])), -1, drDetail["Remarks"].ToString(), true, dataAcess);


                            //then jis Dart ko Transfer kara ha usko In kry ga. Reject Qty
                            manageProcessing.InsertUpdateProductionLedger((string.IsNullOrEmpty(drDetail["TransferWarehouseId"].ToString()) ? -1 : Convert.ToInt32(drDetail["TransferWarehouseId"])), ProductId, -1, SOrderNo, dtp.Value, txtCode.Text,
                                DetailId, "I", (string.IsNullOrEmpty(drDetail["RejectQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["RejectQty"])), -1, drDetail["Remarks"].ToString(), true, dataAcess);
                        }



                        //int DetailId = manageProcessing.InsertUpdateProcessMasterDetail(Convert.ToInt32(drDetail["ProcessDetailId"]),
                        //                                              ProcessMasterId,
                        //                                              (string.IsNullOrEmpty(drDetail["WarehouseId"].ToString()) ? -1 : Convert.ToInt32(drDetail["WarehouseId"])),
                        //                                              Convert.ToDateTime(drDetail["ReceivedDate"].ToString()),
                        //                                              (string.IsNullOrEmpty(drDetail["ReceivedQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ReceivedQty"])),
                        //                                               (string.IsNullOrEmpty(drDetail["ProcessQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ProcessQty"])),
                        //                                               (string.IsNullOrEmpty(drDetail["RejectQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["RejectQty"])),
                        //                                               (string.IsNullOrEmpty(drDetail["TransferWarehouseId"].ToString()) ? -1 : Convert.ToInt32(drDetail["TransferWarehouseId"])),
                        //                                               (string.IsNullOrEmpty(drDetail["TransferDate"].ToString()) ? null as DateTime? : DateTime.Parse(drDetail["TransferDate"].ToString())),
                        //                                               -1, drDetail["Remarks"].ToString(), dataAcess);
                        //if (!string.IsNullOrEmpty(drDetail["TransferWarehouseId"].ToString()) && !string.IsNullOrEmpty(drDetail["TransferDate"].ToString()))
                        //{
                        //    if ((string.IsNullOrEmpty(drDetail["ProcessQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ProcessQty"])) > 0)
                        //    {
                        //        //pehele yeh From Depart se Out hoga  Process Qty
                        //        manageProcessing.InsertUpdateProductionLedger((string.IsNullOrEmpty(drDetail["WarehouseId"].ToString()) ? -1 : Convert.ToInt32(drDetail["WarehouseId"])),
                        //        ProductId, -1, txtSOrderNo.Text, Convert.ToDateTime(drDetail["TransferDate"].ToString()), txtCode.Text, DetailId, "O",
                        //        (string.IsNullOrEmpty(drDetail["ProcessQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ProcessQty"])), -1, drDetail["Remarks"].ToString(), false, dataAcess);


                        //        //then jis Dart ko Transfer kara ha usko In kry ga. Process Qty
                        //        manageProcessing.InsertUpdateProductionLedger((string.IsNullOrEmpty(drDetail["TransferWarehouseId"].ToString()) ? -1 : Convert.ToInt32(drDetail["TransferWarehouseId"])),
                        //       ProductId, -1, txtSOrderNo.Text, Convert.ToDateTime(drDetail["TransferDate"].ToString()), txtCode.Text, DetailId, "I",
                        //       (string.IsNullOrEmpty(drDetail["ProcessQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ProcessQty"])), -1, drDetail["Remarks"].ToString(), false, dataAcess);
                        //    }

                        //    //******************
                        //    if ((string.IsNullOrEmpty(drDetail["RejectQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["RejectQty"])) > 0)
                        //    {
                        //        //pehele yeh From Depart se Out hoga  Reject Wali Qty
                        //        manageProcessing.InsertUpdateProductionLedger((string.IsNullOrEmpty(drDetail["WarehouseId"].ToString()) ? -1 : Convert.ToInt32(drDetail["WarehouseId"])),
                        //        ProductId, -1, txtSOrderNo.Text, Convert.ToDateTime(drDetail["TransferDate"].ToString()), txtCode.Text, DetailId, "O",
                        //        (string.IsNullOrEmpty(drDetail["RejectQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["RejectQty"])), -1, drDetail["Remarks"].ToString(), true, dataAcess);


                        //        //then jis Dart ko Transfer kara ha usko In kry ga. Reject wali Qty
                        //        manageProcessing.InsertUpdateProductionLedger((string.IsNullOrEmpty(drDetail["TransferWarehouseId"].ToString()) ? -1 : Convert.ToInt32(drDetail["TransferWarehouseId"])),
                        //       ProductId, -1, txtSOrderNo.Text, Convert.ToDateTime(drDetail["TransferDate"].ToString()), txtCode.Text, DetailId, "I",
                        //       (string.IsNullOrEmpty(drDetail["RejectQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["RejectQty"])), -1, drDetail["Remarks"].ToString(), true, dataAcess);
                        //    }
                        //}
                    }
                }
                dataAcess.TransCommit();
                MessageBox.Show("Process Data Update Sucessfully.", "Record Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //ClearFeilds();
                LoadProcess();
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
                dataAcess.TransRollback();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataAcess.ConnectionClose();
            }
        }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        ClearFeilds();
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            frmSearch search = new frmSearch();
            search.getattributes("GetProcessSearch", null, "Process Line");
            search.ShowDialog();
            if (!string.IsNullOrEmpty(MainForm.Searched_Id))
            {
                txtCode.Text = MainForm.Searched_Id;
                MainForm.Searched_Id = string.Empty;
            }
            else
            {
                txtCode.Text = string.Empty;
                txtCode.Focus();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void txtFormulaId_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtCode.Text))
        {
            ProcessMasterId = manageProcessing.GetProcessMasterIdByCode(txtCode.Text);
            if (ProcessMasterId > 0)
            {
                LoadProcess();
            }
        }
        else
        {
            ClearFeilds();
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        //MessageBox.Show("We are Applogize for Delete Functionality. Works in Progree", "Pending", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Processing Line Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        switch (result)
        {
            case DialogResult.No:
                {

                    break;
                }
            case DialogResult.Yes:
                {
                    DeleteProcessingLine();
                    break;
                }

        }
    }

    private void DeleteProcessingLine()
    {
        if (string.IsNullOrEmpty(txtCode.Text))
        {
            return;
        }
        try
        {
         
            dataAcess.BeginTransaction();

            int status = manageProcessing.DeleteProcessLine(manageProcessing.GetProcessMasterIdByCode(txtCode.Text), dataAcess);
            dataAcess.TransCommit();
            if (status > 0)
            {
                MessageBox.Show("Process Line " + txtCode.Text + " is Deleted.", "Processing Delete Successful.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }

        }
        catch (SqlException sqlex)
        {
            dataAcess.TransRollback();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            dataAcess.ConnectionClose();
        }
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
        //PrintInvoice(false);
    }

    private void PrintInvoice(bool IsDirectPrint = true)
    {
        try
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                return;
            }

            string path = Application.StartupPath + "/rpt/Production/rptProcessLine.rpt";
            ReportDocument document = new ReportDocument();
            document.Load(path);
            DataTable dtReport = new DataTable();
            dtReport = manageProcessing.GetReportProcessing(txtCode.Text);
            document.SetDataSource(dtReport);
            Utility.SetReportDefaultParameter(ref document);

            if (IsDirectPrint)
            {
                //  document.PrintToPrinter(1, true, 0, 0);
            }
            else
            {
                frmReportViewer report = new frmReportViewer(document);
                report.MdiParent = this.MdiParent;
                report.WindowState = FormWindowState.Maximized;
                report.Show();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }




    }

    private void btnPSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtSOrderNo.Text))
            {
                MessageBox.Show("Please Select Sale Order Number.", "Sale Order is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmSearch search = new frmSearch();
            Smartworks.ColumnField[] gSalesOrderProduct = new Smartworks.ColumnField[1];
            gSalesOrderProduct[0] = new Smartworks.ColumnField("@SaleOrderNo", txtSOrderNo.Text);
            search.getattributes("GetProductSearchForSalesOrderAndProcessing", gSalesOrderProduct, "Products");
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

    private void txtPCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(txtPCode.Text))
            {
                DataTable dtProduct = new DataTable();
                dtProduct = manageProduct.GetProduct(manageProduct.GetProductIdByCode(txtPCode.Text));
                if (dtProduct.Rows.Count > 0)
                {
                    txtPName.Text = dtProduct.Rows[0]["ProductName"].ToString();
                    if (!string.IsNullOrEmpty(dtProduct.Rows[0]["Picture"].ToString()))
                    {
                        try
                        {
                            pbitem.Image = Base64ToImage(dtProduct.Rows[0]["Picture"].ToString());
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
                    DataTable dtOrderQty = new DataTable();
                    dtOrderQty = manageSalesOrder.GetOrderQtyBySOAndDetailProductIdForProcessing(manageSalesOrder.GetSalesOrderMasterIdByCode(txtSOrderNo.Text), Convert.ToInt32(dtProduct.Rows[0]["ProductId"]), txtSOrderNo.Text);
                    if (dtOrderQty.Rows.Count > 0)
                    {
                        txtOrderQty.Text = dtOrderQty.Rows[0]["OrderQty"].ToString();
                        txtDoneQty.Text = dtOrderQty.Rows[0]["DoneQty"].ToString();

                    }
                    //filhaal isko commnet kerdia hai Salman q k Production wala kaam alag hai and Processing wala kaam alag hai.
                    //DataTable dtOrderQty = new DataTable();
                    //dtOrderQty = manageSalesOrder.GetOrderQtyBySOAndDetailProductId(manageSalesOrder.GetSalesOrderMasterIdByCode(txtSOrderNo.Text)
                    //    , Convert.ToInt32(dtProduct.Rows[0]["ProductId"]), ProductionId);
                    //if (dtOrderQty.Rows.Count > 0)
                    //{
                    //    txtOrderQty.Text = dtOrderQty.Rows[0]["OrderQty"].ToString();
                    //    txtDoneQty.Text = dtOrderQty.Rows[0]["ProcessQty"].ToString();
                    //}

                }
            }
            else
            {
                txtPName.Text = string.Empty;
                pbitem.Image = FIL.Properties.Resources.User;
                //cmbFormula.DataSource = null;
                txtOrderQty.Text = "0";
                txtProcessQty.Text = "";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void btnSOSearch_Click(object sender, EventArgs e)
    {
        try
        {
            frmSearch search = new frmSearch();
            search.getattributes("GetSearchSalesOrdersProcessing", null, "Sale Orders");
            search.ShowDialog();
            if (!string.IsNullOrEmpty(MainForm.Searched_Id))
            {
                txtSOrderNo.Text = MainForm.Searched_Id;
                MainForm.Searched_Id = string.Empty;
            }
            else
            {
                txtSOrderNo.Text = string.Empty;
                txtSOrderNo.Focus();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void txtSOrderNo_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtSOrderNo.Text))
        {
            DataTable dtOrder = manageSalesOrder.GetSaleOrderMaster(manageSalesOrder.GetSalesOrderMasterIdByCode(txtSOrderNo.Text));
            if (dtOrder.Rows.Count > 0)
            {
                dtpOrder.Value = Convert.ToDateTime(dtOrder.Rows[0]["OrderDate"]);
                txtPCode.Text = string.Empty;
            }
            // dtpOrder.Value = Convert.ToDateTime(manangeSalesOrder.GetSalesOrderStructure(manangeSalesOrder.GetSalesOrderMasterIdByCode(txtSOrderNo.Text)).Tables[0].Rows[0]["OrderDate"].ToString());
        }
    }


    private void txtProcessQty_KeyPress(object sender, KeyPressEventArgs e)
    {
        Utility clsUtlity = new Utility();
        clsUtlity.setOnlyNumberic((TextBox)sender, false, e);
    }

    private void txtProcessQty_TextChanged(object sender, EventArgs e)
    {
        if (IsProcessLoaded)
        {
            return;
        }
        if (!string.IsNullOrEmpty(txtProcessQty.Text))
        {
            if (!string.IsNullOrEmpty(txtOrderQty.Text))
            {
                decimal OrderQty = 0;
                decimal DoneQty = 0;
                decimal ProcessQty = 0;
                OrderQty = (string.IsNullOrEmpty(txtOrderQty.Text) ? 0 : Convert.ToDecimal(txtOrderQty.Text));
                DoneQty = (string.IsNullOrEmpty(txtDoneQty.Text) ? 0 : Convert.ToDecimal(txtDoneQty.Text));
                ProcessQty = OrderQty - DoneQty;
                if (Convert.ToDecimal(txtProcessQty.Text) > ProcessQty)
                {
                    txtProcessQty.Text = ProcessQty.ToString();
                }

            }
            else
            {
                txtProcessQty.Text = "0";
            }
        }
        else
        {
            txtProcessQty.Text = "0";
        }
    }

    #region Navigation


    private void btnMinInvioceNo_Click(object sender, EventArgs e)
    {
        txtCode.Text = manageProcessing.GetMinInvioceNo();
        if (!string.IsNullOrEmpty(txtCode.Text))
        {

            btnNextInvioceNo.Enabled = true;
            btnPrevInvioceNo.Enabled = false;
        }
    }

    private void btnMaxInvioceNo_Click(object sender, EventArgs e)
    {
        txtCode.Text = manageProcessing.GetMaxInvioceNo();
        if (!string.IsNullOrEmpty(txtCode.Text))
        {

            btnNextInvioceNo.Enabled = false;
            btnPrevInvioceNo.Enabled = true;
        }
    }

    private void btnPrevInvioceNo_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtCode.Text))
        {
            string LastInvioceNo = manageProcessing.GetMinInvioceNo();
            txtCode.Text = manageProcessing.GetPrevInvioceNo(txtCode.Text);


            if (LastInvioceNo == txtCode.Text)
            {
                btnPrevInvioceNo.Enabled = false;
            }
            else
            {
                btnNextInvioceNo.Enabled = true;
            }
        }
    }

    private void btnNextInvioceNo_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtCode.Text))
        {
            string LastInvioceNo = manageProcessing.GetMaxInvioceNo();
            txtCode.Text = manageProcessing.GetNextInvioceNo(txtCode.Text);

            if (LastInvioceNo == txtCode.Text)
            {
                btnNextInvioceNo.Enabled = false;
            }
            else
            {
                btnPrevInvioceNo.Enabled = true;
            }
        }
    }
    #endregion

    private void frmProduction_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F6)
        {
            ClearFeilds();
        }
        else if (e.KeyCode == Keys.F3)
        {
            if (btnAdd.Enabled)
            {
                btnAdd.PerformClick();
            }
            else if (btnUpdate.Enabled)
            {
                btnUpdate.PerformClick();
            }
        }
        else if (e.KeyCode == Keys.Enter)
        {
            if (!GCDetail.Focus())
            {
                SendKeys.Send("{TAB}");
            }
        }
        else if (e.KeyCode == Keys.F2)
        {
            btnSearch.PerformClick();
        }
    }

    private void cmbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void gvDetail_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
    {
        try
        {
            if (e.Value == null)
            {
                return;
            }
            string CustomProductName = string.Empty;
            if (e.Column.FieldName == "ProductId")
            {
                if (!string.IsNullOrEmpty(e.Value.ToString()))
                {
                    bsDisplayProducts.Filter = "ProductId = " + e.Value.ToString() + "";
                    if (bsDisplayProducts.List.Count > 0)
                    {
                        DataView dv = (DataView)bsDisplayProducts.List;
                        e.DisplayText = dv[0]["ProductName"].ToString();

                    }
                    bsDisplayProducts.Filter = "ProductId = " + -1 + "";
                }
            }
        }
        catch (Exception ex)
        {
            bsDisplayProducts.Filter = "ProductId = " + -1 + "";
        }
    }

    private void gvDetail_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
    {
        try
        {
            DataRow dr = (DataRow)gvDetail.GetRow(e.RowHandle); //.GetFocusedDataRow();
            if (dr != null)
            {
                bsProducts.Filter = "SOrderId = " + dr["SOrderId"].ToString() + "";
            }
            //e.Row
           // 
            //bsPendingSOProducts.Filter = "ProductId = '" + -1 + "' and SOrderId  = '" + -1 + "'";
        }
        catch (Exception ex)
        {
        }
    }

    private void gvDetail_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
    {
        try
        {
            DataRow dr = default(DataRow);
            dr = gvDetail.GetDataRow(e.RowHandle);
            if (Convert.ToInt32(dr["ProcessDetailId"].ToString()) > 0)
            {
                DeletedIds.Add(Convert.ToInt32(dr["ProcessDetailId"].ToString()));
            }
        }
        catch (Exception ex)
        {
        }
    }








}
