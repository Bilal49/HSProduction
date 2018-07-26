using CrystalDecisions.CrystalReports.Engine;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using FIL.App_Code.PurchaseManager;
using FIL.App_Code.SaleMasterManager;
using FIL.App_Code.VoucherMananger;
using FIL.Report_Form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FIL
{
    public partial class frmPurchaseInvoice : Form
    {
        Smartworks.DAL dataAcess = new Smartworks.DAL();
        PurchaseManager managePurchase = new PurchaseManager();
        PurchaseOrderManager managePurchaseOrder = new PurchaseOrderManager();
        VendorManager manageVendor = new VendorManager();
        AccountManager manageAccount = new AccountManager();
        ProductManager manageProduct = new ProductManager();
        DataSet dset;
        RepositoryItemGridLookUpEdit repositoryGridLookup = new RepositoryItemGridLookUpEdit();
        //RepositoryItemGridLookUpEdit repositoryWarehouseGridLookup = new RepositoryItemGridLookUpEdit();
        BindingSource bsProducts = new BindingSource();
        //BindingSource bsWarehouse = new BindingSource();
        DataRow drMaster;
        DataView dvProducts;
        DataViewManager dvm;
        int RecevingPOId = -1;
        int PurchaseInvoiceId = -1;
        bool IsPurchaseInvoiceLoading = false;
        List<int> DeletedIds = new List<int>();

        public frmPurchaseInvoice()
        {
            InitializeComponent();
        }

        private void frmDirectSales_Load(object sender, EventArgs e)
        {
            ButtonRights(true);
            //FillDropDown();
            //setGridSetup();
            txtPINo.Text = GetNewNextNumber();
            //GCDetail.Enabled = false;
            btnNextInvioceNo.Enabled = false;
            btnPrevInvioceNo.Enabled = false;

        }

        #region All Methods


        private String GetNewNextNumber()
        {
            string NewInvoiceNo = "";
            NewInvoiceNo = managePurchase.GetMaxInvioceNo(MainForm.FYear);
            if (!string.IsNullOrEmpty(NewInvoiceNo))
            {
                NewInvoiceNo = managePurchase.GetNextInvioceNo(NewInvoiceNo);
            }
            else
            {
                NewInvoiceNo = "PI-000001";
            }
            return NewInvoiceNo;
        }
        private void ButtonRights(bool Enable)
        {
            btnAdd.Enabled = Enable;
            btnUpdate.Enabled = !Enable;
            btnDelete.Enabled = !Enable;
            btnPost.Enabled = !Enable;
            txtRPONo.ReadOnly = !Enable;
            btnSearch.Enabled = Enable;
            btnRPOSearch.Enabled = Enable;
            txtVendorCode.Enabled = Enable;
            btnPost.Enabled = !Enable;
            btnUnPost.Enabled = !Enable;
        }

        private void PostControl(bool Posted)
        {
            btnAdd.Enabled = !Posted;
            btnUpdate.Enabled = !Posted;
            btnDelete.Enabled = !Posted;
            btnPost.Enabled = !Posted;
            txtRPONo.ReadOnly = !Posted;
            btnSearch.Enabled = !Posted;
            btnRPOSearch.Enabled = !Posted;
            txtVendorCode.Enabled = !Posted;
            btnPost.Enabled = !Posted;
            lblPosted.Visible = Posted;
            GCDetail.Enabled = !Posted;

        }

        private void setGridSetup(bool IsRecevingPOLoaded, int TranId)
        {
            dset = new DataSet();
            if (IsRecevingPOLoaded)
            {
                //age Receving Purchase Order Load hoga yani koi new entry ker raha hu ,  ya phr koi RPO load ker raha hu toh yeh wala structure aye ga .
                //dono k structure same rakhy hain. lakin data ka farq hai 

                dset = managePurchase.GetPurchaseStructureRPOId(TranId);
            }
            else
            {
                //age koi  Purchase Invoice dekh raha hu ya Edit mode per hu ya koi cheez Update kerni hai toh yeh wala structure load hoga. 
                //dono k structure same rakhy hain. lakin data ka farq hai 

                dset = managePurchase.GetPurchaseStructure(TranId);
            }

            dset.Tables[0].TableName = "PurchaseMaster";
            dset.Tables[1].TableName = "PurchaseDetail";
            dset.Tables[2].TableName = "Product";


            dset.Tables["PurchaseMaster"].Columns["PurchaseMasterId"].AutoIncrement = true;
            dset.Tables["PurchaseMaster"].Columns["PurchaseMasterId"].AutoIncrementSeed = -1;
            dset.Tables["PurchaseMaster"].Columns["PurchaseMasterId"].AutoIncrementStep = -1;

            dset.Tables["PurchaseDetail"].Columns["PurchaseDetailId"].AutoIncrement = true;
            dset.Tables["PurchaseDetail"].Columns["PurchaseDetailId"].AutoIncrementSeed = -1;
            dset.Tables["PurchaseDetail"].Columns["PurchaseDetailId"].AutoIncrementStep = -1;


            dset.Relations.Add("MasterRelation", dset.Tables["PurchaseMaster"].Columns["PurchaseMasterId"], dset.Tables["PurchaseDetail"].Columns["PurchaseMasterId"]);
            if (dset.Tables["PurchaseMaster"].Rows.Count > 0)
            {
                drMaster = dset.Tables["PurchaseMaster"].Rows[0];
            }
            else
            {
                drMaster = dset.Tables["PurchaseMaster"].NewRow();
                dset.Tables["PurchaseMaster"].Rows.Add(drMaster);
            }
            dvm = new DataViewManager(dset);
            dvProducts = dvm.CreateDataView(dset.Tables["Product"]);
            GCDetail.DataSource = dset.Tables["PurchaseDetail"];
            GridSetting();


        }
        private void GridSetting()
        {


            gvDetail.Columns.ColumnByName("colPurchaseDetailId").OptionsColumn.ReadOnly = true;
            gvDetail.Columns.ColumnByName("colPurchaseMasterId").OptionsColumn.ReadOnly = true;
            gvDetail.Columns.ColumnByName("colRPODetailId").OptionsColumn.ReadOnly = true;

            gvDetail.Columns.ColumnByName("colPurchaseDetailId").Visible = false;
            gvDetail.Columns.ColumnByName("colPurchaseMasterId").Visible = false;
            gvDetail.Columns.ColumnByName("colRPODetailId").Visible = false;
            gvDetail.Columns.ColumnByName("colBarcode").Visible = false;
            gvDetail.Columns.ColumnByName("colProductCategoryId").Visible = false;
            gvDetail.Columns.ColumnByName("colCategoryName").Visible = false;
            gvDetail.Columns.ColumnByName("colAddedBy").Visible = false;
            gvDetail.Columns.ColumnByName("colAddedOn").Visible = false;
            gvDetail.Columns.ColumnByName("colAddedIpAddr").Visible = false;
            gvDetail.Columns.ColumnByName("colUpdatedBy").Visible = false;
            gvDetail.Columns.ColumnByName("colUpdatedOn").Visible = false;
            gvDetail.Columns.ColumnByName("colUpdatedIpAddr").Visible = false;
            gvDetail.Columns.ColumnByName("colReturnedQty").Visible = false;


            //  ProductId  OrderQty Price  Amount DiscountPercent DiscountAmount GSTPercent GSTAmount TotalAmount

            gvDetail.Columns.ColumnByName("colProductId").Caption = "Product Name";
            gvDetail.Columns.ColumnByName("colReceivedQty").Caption = "Received Qty";
            gvDetail.Columns.ColumnByName("colPrice").Caption = "Price";
            gvDetail.Columns.ColumnByName("colAmount").Caption = "Amount";
            //gvDetail.Columns.ColumnByName("colGSTPercent").Caption = "GST %";
            //gvDetail.Columns.ColumnByName("colGSTAmount").Caption = "GST Amount";
            gvDetail.Columns.ColumnByName("colDiscountPercent").Caption = "Disc %";
            gvDetail.Columns.ColumnByName("colDiscountAmount").Caption = "Disc Amount";
            gvDetail.Columns.ColumnByName("colDiscountedAmount").Caption = "Discounted";
            gvDetail.Columns.ColumnByName("colTotalAmount").Caption = "Total Amount";


            gvDetail.Columns.ColumnByName("colProductId").OptionsColumn.AllowEdit = false;


            gvDetail.Columns.ColumnByName("colBalanceQty").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colBalanceQty").OptionsColumn.AllowFocus = false;

            gvDetail.Columns.ColumnByName("colAmount").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colAmount").OptionsColumn.AllowFocus = false;

            gvDetail.Columns.ColumnByName("colDiscountedAmount").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colDiscountedAmount").OptionsColumn.AllowFocus = false;

            gvDetail.Columns.ColumnByName("colTotalAmount").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colTotalAmount").OptionsColumn.AllowFocus = false;

            gvDetail.Columns.ColumnByName("colReceivedQty").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colReceivedQty").OptionsColumn.AllowFocus = false;

            gvDetail.Columns.ColumnByName("colPrice").OptionsColumn.AllowEdit = true;
            gvDetail.Columns.ColumnByName("colPrice").OptionsColumn.AllowFocus = true;

            

            //gvDetail.Columns.ColumnByName("colBalanceQty").OptionsColumn.AllowEdit = false;
            //gvDetail.Columns.ColumnByName("colBalanceQty").OptionsColumn.AllowFocus = false;

            //gvDetail.Columns.ColumnByName("colTotalReceived").OptionsColumn.AllowEdit = false;
            //gvDetail.Columns.ColumnByName("colTotalReceived").OptionsColumn.AllowFocus = false;



            gvDetail.Columns.ColumnByName("colProductId").VisibleIndex = 0;
            gvDetail.Columns.ColumnByName("colReceivedQty").VisibleIndex = 1;
            gvDetail.Columns.ColumnByName("colPrice").VisibleIndex = 5;
            gvDetail.Columns.ColumnByName("colAmount").VisibleIndex = 6;
            gvDetail.Columns.ColumnByName("colDiscountPercent").VisibleIndex = 7;
            gvDetail.Columns.ColumnByName("colDiscountAmount").VisibleIndex = 8;
            gvDetail.Columns.ColumnByName("colDiscountedAmount").VisibleIndex = 9;
            //gvDetail.Columns.ColumnByName("colGSTPercent").VisibleIndex = 10;
            //gvDetail.Columns.ColumnByName("colGSTAmount").VisibleIndex = 11;
            gvDetail.Columns.ColumnByName("colTotalAmount").VisibleIndex = 12;


            gvDetail.Columns.ColumnByName("colProductId").Width = 300;
            gvDetail.Columns.ColumnByName("colReceivedQty").Width = 80;
            gvDetail.Columns.ColumnByName("colPrice").Width = 50;
            gvDetail.Columns.ColumnByName("colAmount").Width = 80;
            gvDetail.Columns.ColumnByName("colDiscountPercent").Width = 50;
            //gvDetail.Columns.ColumnByName("colGSTPercent").Width = 50;
            //gvDetail.Columns.ColumnByName("colGSTAmount").Width = 120;
            //gvDetail.Columns.ColumnByName("colDiscountAmount").Width = 80;
            gvDetail.Columns.ColumnByName("colDiscountedAmount").Width = 80;
            gvDetail.Columns.ColumnByName("colTotalAmount").Width = 100;

            bsProducts.DataSource = dset;
            bsProducts.DataMember = "Product";

            //bsWarehouse.DataSource = dset;
            //bsWarehouse.DataMember = "Warehouse";


            repositoryGridLookup.DataSource = bsProducts;
            repositoryGridLookup.DisplayMember = "ProductName";
            repositoryGridLookup.ValueMember = "ProductId";
            repositoryGridLookup.PopupFormSize = new Size(450, 250);
            repositoryGridLookup.NullText = "";
            repositoryGridLookup.ShowFooter = false;
            repositoryGridLookup.View.OptionsView.ColumnAutoWidth = false;
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

                repositoryGridLookup.View.Columns.ColumnByName("colProductName").Caption = "Name";
                repositoryGridLookup.View.Columns.ColumnByName("colProductCode").Caption = "Code";
                repositoryGridLookup.View.Columns.ColumnByName("colCostPrice").Caption = "Cost Price";
                repositoryGridLookup.View.Columns.ColumnByName("colQtyInhand").Caption = "QtyInHand";
                repositoryGridLookup.View.Columns.ColumnByName("colCategoryName").Caption = "Category Name";


                repositoryGridLookup.View.Columns.ColumnByName("colProductName").Width = 150;
                repositoryGridLookup.View.Columns.ColumnByName("colProductCode").Width = 80;
                repositoryGridLookup.View.Columns.ColumnByName("colCostPrice").Width = 70;
                repositoryGridLookup.View.Columns.ColumnByName("colQtyInhand").Width = 40;
                repositoryGridLookup.View.Columns.ColumnByName("colCategoryName").Width = 100;


                repositoryGridLookup.View.Columns.ColumnByName("colProductCode").VisibleIndex = 0;
                repositoryGridLookup.View.Columns.ColumnByName("colProductName").VisibleIndex = 1;
                repositoryGridLookup.View.Columns.ColumnByName("colCostPrice").VisibleIndex = 2;
                repositoryGridLookup.View.Columns.ColumnByName("colQtyInhand").VisibleIndex = 3;
                repositoryGridLookup.View.Columns.ColumnByName("colCategoryName").VisibleIndex = 4;
            }
            gvDetail.Columns.ColumnByName("colProductId").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            GCDetail.Enabled = true;
            gvDetail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            gvDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            gvDetail.OptionsBehavior.Editable = true;
            txtDiscountPercent.Enabled = true;
            txtDiscount.Enabled = true;
        }

        //private void FillDropDown()
        //{
        //    WarehouseManager manageWarehouse = new WarehouseManager();
        //    DataTable dtWarehouse = new DataTable();
        //    dtWarehouse = manageWarehouse.GetWarehouseList();
        //    DataRow drWarehouse = dtWarehouse.NewRow();
        //    drWarehouse["WarehouseId"] = -1;
        //    drWarehouse["Warehouse"] = "---Select Warehouse---";
        //    dtWarehouse.Rows.InsertAt(drWarehouse, 0);
        //    cmbWarehouse.DataSource = dtWarehouse;
        //    cmbWarehouse.DisplayMember = "Warehouse";
        //    cmbWarehouse.ValueMember = "WarehouseId";
        //}

        private void ClearFeilds()
        {
            txtPINo.Text = string.Empty;
            txtRPONo.Text = string.Empty;
            dtpDate.Value = DateTime.Now;
            dtpRPODate.Value = DateTime.Now;
            dtpDueDate.Value = DateTime.Now;
            txtVendorCode.Text = string.Empty;
            txtVendorName.Text = string.Empty;
            txtVendorAccCode.Text = string.Empty;
            txtVendorAccName.Text = string.Empty;
            txtEmployeeCode.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtVoucherNo.Text = string.Empty;

            txtTotalAmount.Text = "0";
            txtGSTPerc.Text = "0";
            txtGSTAmount.Text = "0";
            txtDiscount.Text = "0";
            txtDiscountPercent.Text = "0";
            txtNetTotal.Text = "0";
            PurchaseInvoiceId = -1;
            RecevingPOId = -1;
            chkPrice.Checked = false;

            DeletedIds = new List<int>();
            PostControl(false);

            if (dset != null)
            {
                dset.Tables["PurchaseDetail"].Rows.Clear();
                dset.Tables["PurchaseMaster"].Rows.Clear();
                dset.RejectChanges();
                drMaster = dset.Tables["PurchaseMaster"].NewRow();
                dset.Tables["PurchaseMaster"].Rows.Add(drMaster);
                GCDetail.DataSource = dset.Tables["PurchaseDetail"];
                GridSetting();
            }
            //GCDetail.Enabled = false;
            txtDiscountPercent.Enabled = false;
            txtDiscount.Enabled = false;
            
            ButtonRights(true);
            txtPINo.Text = GetNewNextNumber();
            txtRPONo.Focus();
            btnNextInvioceNo.Enabled = false;
            btnPrevInvioceNo.Enabled = false;
        }
        private void LoadRecevingPOrder(int RPOMasterId)
        {
            try
            {
                setGridSetup(true, RPOMasterId);

                if (dset.Tables["PurchaseMaster"].Rows.Count > 0)
                {
                    txtRPONo.Text = drMaster["RPONo"].ToString();
                    dtpDate.Value = Convert.ToDateTime(drMaster["RPODate"].ToString());
                    dtpDueDate.Value = DateTime.Now; //Convert.ToDateTime(drMaster["DueDate"].ToString());
                    txtVendorCode.Text = drMaster["VendorCode"].ToString();
                    txtEmployeeCode.Text = drMaster["EmployeeCode"].ToString();
                    txtRemarks.Text = string.Empty; //drMaster["Remarks"].ToString();
                    txtVoucherNo.Text = string.Empty; //drMaster["VoucherNo"].ToString();

                    txtTotalAmount.Text = drMaster["TAmount"].ToString();
                    txtDiscountPercent.Text = drMaster["TDiscountPerc"].ToString();
                    txtDiscount.Text = drMaster["TDiscount"].ToString();
                    txtGSTPerc.Text = "0"; //drMaster["GSTPercent"].ToString();
                    txtGSTAmount.Text = "0"; //drMaster["GSTAmount"].ToString();
                    txtNetTotal.Text = drMaster["NetAmount"].ToString();
                    //ButtonRights(false);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPurchaseInvoice()
        {
            try
            {
                setGridSetup(false, PurchaseInvoiceId);

                if (dset.Tables["PurchaseMaster"].Rows.Count > 0)
                {
                    txtRPONo.Text = drMaster["RPONo"].ToString();
                    dtpDate.Value = Convert.ToDateTime(drMaster["ReceivedOn"].ToString());
                    dtpDueDate.Value = Convert.ToDateTime(drMaster["DueDate"].ToString());
                    txtVendorCode.Text = drMaster["VendorCode"].ToString();
                    txtEmployeeCode.Text = drMaster["EmployeeCode"].ToString();
                    txtRemarks.Text = drMaster["Remarks"].ToString();
                    txtVoucherNo.Text = drMaster["VoucherNo"].ToString();
                    txtTotalAmount.Text = drMaster["TAmount"].ToString();
                    txtDiscountPercent.Text = drMaster["TDiscountPerc"].ToString();
                    txtDiscount.Text = drMaster["TDiscount"].ToString();
                    txtGSTPerc.Text = drMaster["GSTPercent"].ToString();
                    txtGSTAmount.Text = drMaster["GSTAmount"].ToString();
                    txtNetTotal.Text = drMaster["NetAmount"].ToString();
                    ButtonRights(false);
                    btnUnPost.Enabled = false;
                    bool Posted = Convert.ToBoolean(drMaster["Posted"].ToString());
                    if (Posted)
                    {
                        PostControl(Posted);
                        btnUnPost.Enabled = true;
                    }
                    else
                    {
                        PostControl(false);
                        ButtonRights(false);
                        btnUnPost.Enabled = false;
                    }
                    //for Navigation Works*******
                    try
                    {
                        string FirstTransNo = managePurchase.GetMinInvioceNo(MainForm.FYear);
                        string LastTransNo = managePurchase.GetMaxInvioceNo(MainForm.FYear);
                        if (LastTransNo == txtPINo.Text)
                        {
                            btnNextInvioceNo.Enabled = false;
                        }
                        else
                        {
                            btnNextInvioceNo.Enabled = true;
                        }
                        if (FirstTransNo == txtPINo.Text)
                        {
                            btnPrevInvioceNo.Enabled = false;
                        }
                        else
                        {
                            btnPrevInvioceNo.Enabled = true;
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    //***************************
                }

            }
            catch (Exception ex)
            {
                IsPurchaseInvoiceLoading = false;
                MessageBox.Show(ex.Message, "Error!!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void txtPINo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPINo.Text))
            {
                PurchaseInvoiceId = managePurchase.GetPurchaseMasterIdByCode(txtPINo.Text , MainForm.FYear);
                if (PurchaseInvoiceId > 0)
                {
                    IsPurchaseInvoiceLoading = true;
                    LoadPurchaseInvoice();
                    IsPurchaseInvoiceLoading = false;
                }
            }
        }

        private void gvDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                DataRow dr = gvDetail.GetFocusedDataRow();
                switch (e.Column.Name.ToString())
                {
                    case "colProductId":

                        dr["ProductCategoryId"] = dvProducts[0]["ProductCategoryId"];
                        dr["Barcode"] = dvProducts[0]["Barcode"];
                        dr["Price"] = dvProducts[0]["CostPrice"];
                        dr["DiscountPercent"] = dvProducts[0]["DiscountPerc"];
                        dr["WarehouseId"] = -1;
                        //dr["StockType"] = "Stock";

                        //Math.Round(decimal.Parse(dr["DiscountAmount"].ToString()), 2);
                        if (string.IsNullOrEmpty(dr["ReceivedQty"].ToString()))
                        {
                            dr["ReceivedQty"] = 1;
                        }

                        dr["Amount"] = Math.Round((decimal.Parse(dr["Price"].ToString()) * decimal.Parse(dr["ReceivedQty"].ToString())), 2);
                        dr["DiscountAmount"] = Math.Round((decimal.Parse(dr["Amount"].ToString()) * decimal.Parse(dr["DiscountPercent"].ToString()) / 100), 2);
                        dr["DiscountedAmount"] = Math.Round((decimal.Parse(dr["Amount"].ToString()) - decimal.Parse(dr["DiscountAmount"].ToString())), 2);
                        
                        //if (string.IsNullOrEmpty(dr["GSTPercent"].ToString()))
                        //{
                        //    dr["GSTPercent"] = "0";
                        //    dr["GSTAmount"] = "0";
                        //}
                        //dr["GSTAmount"] = "0.00"; // Math.Round(((decimal.Parse(dr["DiscountedAmount"].ToString()) * decimal.Parse(dr["GSTPercent"].ToString()) / 100)), 2);
                        //dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()), 2);
                        dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) , 2); //+ decimal.Parse(dr["GSTAmount"].ToString())

                        break;


                    case "colDiscountAmount":
                        if (string.IsNullOrEmpty(dr["DiscountAmount"].ToString()))
                        {
                            dr["DiscountAmount"] = "0.00";
                        }
                        if (decimal.Parse(dr["DiscountAmount"].ToString()) < 0)
                        {
                            dr["DiscountAmount"] = "0.00";
                        }

                        dr["DiscountAmount"] = Math.Round(decimal.Parse(dr["DiscountAmount"].ToString()), 2);
                        dr["DiscountPercent"] = Math.Round((decimal.Parse(dr["DiscountAmount"].ToString()) / decimal.Parse(dr["Amount"].ToString())) * 100, 2);
                        dr["DiscountedAmount"] = Math.Round(decimal.Parse(dr["Amount"].ToString()) - decimal.Parse(dr["DiscountAmount"].ToString()), 2);


                        dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) , 2); //+ decimal.Parse(dr["GSTAmount"].ToString())
                        break;
                    case "colDiscountPercent":
                        if (string.IsNullOrEmpty(dr["DiscountPercent"].ToString()))
                        {
                            dr["DiscountPercent"] = dvProducts[0]["DiscountPerc"];
                        }
                        if (decimal.Parse(dr["DiscountPercent"].ToString()) < 0)
                        {
                            dr["DiscountPercent"] = dvProducts[0]["DiscountPerc"];
                        }

                        dr["DiscountAmount"] = Math.Round((decimal.Parse(dr["Amount"].ToString()) * decimal.Parse(dr["DiscountPercent"].ToString())) / 100, 2);
                        dr["DiscountedAmount"] = Math.Round(decimal.Parse(dr["Amount"].ToString()) - decimal.Parse(dr["DiscountAmount"].ToString()), 2);

                        dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) , 2);  //+ decimal.Parse(dr["GSTAmount"].ToString())
                        break;
                    case "colReceivedQty":
                        if (string.IsNullOrEmpty(dr["ReceivedQty"].ToString()))
                        {
                            dr["ReceivedQty"] = 1;  //Default Quantity is 1;
                        }
                        if (decimal.Parse(dr["ReceivedQty"].ToString()) < 0)
                        {
                            dr["ReceivedQty"] = 1;  //Qty Should be greater then zero;
                        }

                        dr["BalanceQty"] = (string.IsNullOrEmpty(dr["OrderQty"].ToString()) ? 0 : Convert.ToDecimal(dr["OrderQty"])) - ((string.IsNullOrEmpty(dr["ReceivedQty"].ToString()) ? 0 : Convert.ToDecimal(dr["ReceivedQty"])) + (string.IsNullOrEmpty(dr["TotalReceived"].ToString()) ? 0 : Convert.ToDecimal(dr["TotalReceived"])));

                        dr["Amount"] = Math.Round((decimal.Parse(dr["Price"].ToString()) * decimal.Parse(dr["ReceivedQty"].ToString())), 2);

                        if (dr["DiscountPercent"] != null)
                        {
                            if (decimal.Parse(dr["DiscountPercent"].ToString()) > 0)
                            {
                                dr["DiscountAmount"] = Math.Round((decimal.Parse(dr["Amount"].ToString()) * decimal.Parse(dr["DiscountPercent"].ToString())) / 100, 2);
                                dr["DiscountedAmount"] = Math.Round(decimal.Parse(dr["Amount"].ToString()) - decimal.Parse(dr["DiscountAmount"].ToString()), 2);

                                dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()), 2); //+ decimal.Parse(dr["GSTAmount"].ToString())
                            }
                        }
                        dr["DiscountedAmount"] = Math.Round(decimal.Parse(dr["Amount"].ToString()) - decimal.Parse(dr["DiscountAmount"].ToString()), 2);

                        dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) , 2);  //+ decimal.Parse(dr["GSTAmount"].ToString())
                        break;
                    case "colPrice":
                        if (string.IsNullOrEmpty(dr["Price"].ToString()))
                        {
                            dr["Price"] = dvProducts[0]["CostPrice"];
                        }
                        if (decimal.Parse(dr["Price"].ToString()) < 0)
                        {
                            dr["Price"] = dvProducts[0]["CostPrice"];
                        }
                        dr["Amount"] = Math.Round(decimal.Parse(dr["Price"].ToString()) * decimal.Parse(dr["ReceivedQty"].ToString()), 2);

                        if (dr["DiscountPercent"] != null)
                        {
                            if (decimal.Parse(dr["DiscountPercent"].ToString()) > 0)
                            {
                                dr["DiscountAmount"] = Math.Round(decimal.Parse(dr["Amount"].ToString()) * decimal.Parse(dr["DiscountPercent"].ToString()) / 100, 2);
                                dr["DiscountedAmount"] = Math.Round(decimal.Parse(dr["Amount"].ToString()) - decimal.Parse(dr["DiscountAmount"].ToString()), 2);
                                //dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()), 2);
                                dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()), 2);
                            }
                        }

                        dr["DiscountAmount"] = Math.Round(decimal.Parse(dr["Amount"].ToString()) * decimal.Parse(dr["DiscountPercent"].ToString()) / 100, 2);
                        dr["DiscountedAmount"] = Math.Round(decimal.Parse(dr["Amount"].ToString()) - decimal.Parse(dr["DiscountAmount"].ToString()), 2);

                        dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) , 2); //+ decimal.Parse(dr["GSTAmount"].ToString())
                        break;

                    case "colGSTPercent":

                        if (string.IsNullOrEmpty(dr["GSTPercent"].ToString()))
                        {
                            dr["GSTPercent"] = "0.00";
                        }
                        if (decimal.Parse(dr["GSTPercent"].ToString()) < 0)
                        {
                            dr["GSTPercent"] = "0.00";
                        }
                        decimal Amount = 0;
                        if (!string.IsNullOrEmpty(dr["Amount"].ToString()))
                        {
                            Amount = decimal.Parse(dr["Amount"].ToString());
                        }
                        if (Amount > 0)
                        {
                            dr["GSTAmount"] = Amount + (Amount / 100) * decimal.Parse(dr["GSTPercent"].ToString());
                        }
                        dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()), 2);
                        break;
                    case "colGSTAmount":
                        if (string.IsNullOrEmpty(dr["GSTAmount"].ToString()))
                        {
                            dr["GSTAmount"] = "0.00";
                        }
                        if (decimal.Parse(dr["GSTAmount"].ToString()) < 0)
                        {
                            dr["GSTAmount"] = "0.00";
                        }
                        dr["GSTPercent"] = Math.Round((decimal.Parse(dr["GSTAmount"].ToString()) / decimal.Parse(dr["Amount"].ToString())) * 100, 2);
                        dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()), 2);

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CalculateSummary();

        }

        private void gvDetail_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Value != null)
            {
                switch (e.Column.Name.ToString())
                {
                    case "colProductId":
                        {
                            dvProducts.RowFilter = "ProductId='" + e.Value.ToString() + "'";
                            break;
                        }
                }
            }
        }

        private void CalculateSummary()
        {

            decimal Total = 0;
            try
            {
                foreach (DataRow dr in dset.Tables["PurchaseDetail"].Rows)
                {
                    if (dr.RowState != DataRowState.Deleted)
                    {

                        try
                        {
                            Total = Total + Decimal.Parse(dr["TotalAmount"].ToString());
                        }
                        catch
                        {
                            dr.BeginEdit();
                        }
                    }
                }

                txtTotalAmount.Text = Math.Round(Total, 2).ToString();
                txtNetTotal.Text = Math.Round(Total, 0).ToString();
                txtDiscountPercent_Leave(null, null);
            }
            catch (Exception ex)
            {
                txtTotalAmount.Text = Math.Round(Total, 2).ToString();
            }
        }

        private void txtDiscountPercent_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtGSTAmount.Text))
                {
                    txtGSTAmount.Text = "0";
                }
                if (!string.IsNullOrEmpty(txtDiscountPercent.Text))
                {
                    if (decimal.Parse(txtDiscountPercent.Text) > 100)
                    {
                        txtDiscount.Text = "0";
                        txtDiscountPercent.Text = "0";
                        txtNetTotal.Text = Math.Round(decimal.Parse(txtTotalAmount.Text), 0).ToString() + decimal.Parse(txtGSTAmount.Text);
                        txtDiscountPercent.Focus();
                        //MessageBox.Show(Messages.Percentage, Messages.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        txtDiscountPercent.Text = Math.Round(decimal.Parse(txtDiscountPercent.Text), 2).ToString();
                        txtDiscount.Text = Math.Round(((decimal.Parse(txtTotalAmount.Text) * decimal.Parse(txtDiscountPercent.Text)) / 100), 0).ToString();
                        txtNetTotal.Text = Math.Round((decimal.Parse(txtTotalAmount.Text) + decimal.Parse(txtGSTAmount.Text) - decimal.Parse(txtDiscount.Text)), 0).ToString();
                    }
                }
                else
                {
                    txtDiscountPercent.Text = "0";
                    txtDiscountPercent.Text = Math.Round(decimal.Parse(txtDiscountPercent.Text), 2).ToString();
                    txtDiscount.Text = Math.Round(((decimal.Parse(txtTotalAmount.Text) * decimal.Parse(txtDiscountPercent.Text)) / 100), 0).ToString();
                    txtNetTotal.Text = Math.Round((decimal.Parse(txtTotalAmount.Text) + decimal.Parse(txtGSTAmount.Text) - decimal.Parse(txtDiscount.Text)), 0).ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            try
            {


                if (!string.IsNullOrEmpty(txtDiscount.Text))
                {
                    if (decimal.Parse(txtDiscount.Text) > decimal.Parse(txtTotalAmount.Text))
                    {
                        txtDiscount.Text = "0";
                        txtDiscountPercent.Text = "0";
                        txtNetTotal.Text = Math.Round(decimal.Parse(txtTotalAmount.Text), 0) + decimal.Parse(txtGSTAmount.Text).ToString();
                        txtDiscount.Focus();
                        //MessageBox.Show(Messages.DiscountGreaterThanAmount, Messages.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (decimal.Parse(txtTotalAmount.Text) > 0)
                        {
                            txtDiscount.Text = Math.Round(decimal.Parse(txtDiscount.Text), 0).ToString();
                            txtDiscountPercent.Text = Math.Round(((decimal.Parse(txtDiscount.Text) / decimal.Parse(txtTotalAmount.Text)) * 100), 2).ToString();
                            txtNetTotal.Text = Math.Round((decimal.Parse(txtTotalAmount.Text) + decimal.Parse(txtGSTAmount.Text) - decimal.Parse(txtDiscount.Text)), 0).ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtGSTPerc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDiscount.Text))
                {
                    txtDiscount.Text = "0";
                }
                if (!string.IsNullOrEmpty(txtGSTPerc.Text))
                {
                    if (decimal.Parse(txtGSTPerc.Text) > 100)
                    {
                        txtGSTPerc.Text = "0";//Math.Round(decimal.Parse(txtDiscountPercent.Text), 2).ToString();
                        txtGSTAmount.Text = "0"; //Math.Round(((decimal.Parse(txtTotalAmount.Text) * decimal.Parse(txtDiscountPercent.Text)) / 100), 0).ToString();
                        txtNetTotal.Text = Math.Round((decimal.Parse(txtTotalAmount.Text) + decimal.Parse(txtGSTAmount.Text) - decimal.Parse(txtDiscount.Text)), 0).ToString();


                    }
                    else
                    {
                        txtGSTAmount.Text = Math.Round((decimal.Parse(txtTotalAmount.Text) / 100) * decimal.Parse(txtGSTPerc.Text), 2).ToString();
                        txtNetTotal.Text = Math.Round((decimal.Parse(txtTotalAmount.Text) + decimal.Parse(txtGSTAmount.Text) - decimal.Parse(txtDiscount.Text)), 0).ToString();
                    }
                }
                else
                {
                    txtGSTPerc.Text = "0";//Math.Round(decimal.Parse(txtDiscountPercent.Text), 2).ToString();
                    txtGSTAmount.Text = "0"; //Math.Round(((decimal.Parse(txtTotalAmount.Text) * decimal.Parse(txtDiscountPercent.Text)) / 100), 0).ToString();
                    txtNetTotal.Text = Math.Round((decimal.Parse(txtTotalAmount.Text) + decimal.Parse(txtGSTAmount.Text) - decimal.Parse(txtDiscount.Text)), 0).ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gvDetail_RowCountChanged(object sender, EventArgs e)
        {
            CalculateSummary();
            txtDiscountPercent_Leave(null, null);
        }

        private void gvDetail_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gvDetail.GetFocusedDataRow();
            if ((dr != null))
            {
                try
                {
                    if (!string.IsNullOrEmpty(dr["ProductId"].ToString()))
                    {
                        dvProducts.RowFilter = "ProductId='" + dr["ProductId"].ToString() + "'";
                    }
                }
                catch (Exception ex)
                { }

            }
        }

        private void gvDetail_GotFocus(object sender, EventArgs e)
        {
            gvDetail_FocusedRowChanged(null, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(0, gvDetail.FocusedRowHandle));
        }

        private void gvDetail_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            if (e.ErrorText.Contains("is already present"))
            {
                e.ErrorText = "Item Alredy Exits.";
            }
            MessageBox.Show(e.ErrorText, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void gvDetail_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;

            switch (gvDetail.FocusedColumn.Name)
            {
                case "colProductId":
                    gvDetail.FocusedColumn = gvDetail.Columns.ColumnByName("colProductId");
                    break;
                case "colDiscountAmount":
                    e.ErrorText = "error"; //Messages.DiscountGreaterThanAmount;
                    //MessageBox.Show(Messages.DiscountGreaterThanAmount + Strings.Chr(13) + Messages.PreviousValue, Messages.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "colDiscountPercent":
                    e.ErrorText = "error"; //Messages.Percentage;
                    //MessageBox.Show(Messages.Percentage + Strings.Chr(13) + Messages.PreviousValue, Messages.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "colGSTAmount":
                    e.ErrorText = "error"; //Messages.DiscountGreaterThanAmount;
                    MessageBox.Show(e.ErrorText, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "colGSTPercent":
                    e.ErrorText = "error"; //Messages.Percentage;
                    //MessageBox.Show(e.ErrorText + Strings.Chr(13) + Messages.PreviousValue, Messages.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "colOrderQty":
                    gvDetail.FocusedColumn = gvDetail.Columns.ColumnByName("colOrderQty");

                    break;


                case "colPrice":

                    break;
                case "colExpiryDate":
                    break;
            }

            gvDetail.HideEditor();
        }

        private void gvDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow dr = default(DataRow);
            dr = gvDetail.GetDataRow(e.RowHandle);

            if (decimal.Parse(dr["ProductId"].ToString()) <= 0)
            {
                e.Valid = false;
            }

            else if (decimal.Parse(dr["ReceivedQty"].ToString()) <= 0)
            {
                //Quantity = "Less than one";
                e.Valid = false;
            }
            else if (dr.RowState == DataRowState.Detached)
            {
                if (dset.Tables["POrderDetail"].Select("ProductId =" + dr["ProductId"].ToString()).Length > 0)
                {
                    MessageBox.Show("Item Already Exists", "Same Items can not be repeated.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Valid = false;
                }
            }
            else
            {
                e.Valid = true;
                gvDetail.GetDataRow(e.RowHandle)["PurchaseMasterId"] = drMaster["PurchaseMasterId"]; //SalesMasterId;
            }
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
                            case "colProductId":
                                if (string.IsNullOrEmpty(e.Value.ToString()))
                                {
                                    e.Valid = false;
                                }
                                else if (decimal.Parse(e.Value.ToString()) <= 0)
                                {
                                    e.Valid = false;
                                }
                                break;
                            case "colOrderQty":
                                if (string.IsNullOrEmpty(e.Value.ToString()))
                                {
                                    e.Valid = false;
                                }
                                else if (decimal.Parse(e.Value.ToString()) <= 0)
                                {
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

        private bool Validations()
        {
            bool result = true;
            if (string.IsNullOrEmpty(txtRPONo.Text))
            {
                MessageBox.Show("Please Select Receving PO Number.", "RPO Code is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRPONo.Focus();
                result = false;
                return result;
            }

            if (string.IsNullOrEmpty(txtVendorCode.Text))
            {
                MessageBox.Show("Vendor Code does not Found.", "Vendor Code is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVendorCode.Focus();
                result = false;
                return result;

            }

            if (string.IsNullOrEmpty(txtVendorAccCode.Text))
            {
                MessageBox.Show("Vendor COA Code does not Found.", "Vendor COA Code is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVendorCode.Focus();
                result = false;
                return result;

            }

            if (dset.Tables["PurchaseDetail"].Rows.Count <= 0)
            {
                MessageBox.Show("Purchase Details not Found.", "Purchase Detail is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                return result;
            }

            if (PurchaseInvoiceId < 0)
            {
                //Sift Insert Case mai hi Check kry ga k Invoies bni hui hai k nh , Update case mai nh,
                //wase toh Search per RPO number ana hi nh chyea , iska kaam abhi pending hai jab tk isko validate ki hua hai.
                if (managePurchaseOrder.IsRPOPurchaseInvoiceCreated(txtRPONo.Text))
                {
                    MessageBox.Show("Purchase Invoice alredy created against " + txtRPONo.Text + " Receving PO Number.", "Invoice Alredy Created.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    result = false;
                    return result;
                }
            }

            if (dtpDate.Value.Date < MainForm.FicalYearStart.Date || dtpDate.Value.Date > MainForm.FicalYearEnd.Date)
            {
                MessageBox.Show("Invalid Date Selection. Selected Date is Out of Rang of Fical Year", "Invalid Date Selection.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
            }


            return result;

        }

        private void DeletePurchaseInvoice()
        {
            if (string.IsNullOrEmpty(txtPINo.Text))
            {
                return;
            }
            try
            {


                dataAcess.BeginTransaction();
                if (dataAcess.getDBCommand().Transaction == null)
                {
                    dataAcess.SetDBTransaction();
                }
                managePurchase.DeletePurchaseByInvoiceNo(txtPINo.Text, dataAcess);
                dataAcess.TransCommit();
                MessageBox.Show("Purchase Invoice " + txtRPONo.Text + " is Deleted.", "Invoice Delete Successful.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validations())
            {
                try
                {
                    //ProductManager PM = new ProductManager();
                    dataAcess.BeginTransaction();
                    if (dataAcess.getDBCommand().Transaction == null)
                    {
                        dataAcess.SetDBTransaction();
                    }
                    DataTable dtPI = new DataTable();
                    dtPI = managePurchase.InsertPurchaseMaster(txtRPONo.Text, dtpDate.Value, dtpDueDate.Value, txtVendorCode.Text, txtEmployeeCode.Text, (string.IsNullOrEmpty(txtTotalAmount.Text) ? 0 : Convert.ToDecimal(txtTotalAmount.Text)),
                        (string.IsNullOrEmpty(txtDiscountPercent.Text) ? 0 : Convert.ToDecimal(txtDiscountPercent.Text)), (string.IsNullOrEmpty(txtDiscount.Text) ? 0 : Convert.ToDecimal(txtDiscount.Text)), (string.IsNullOrEmpty(txtGSTPerc.Text) ? 0 : Convert.ToDecimal(txtGSTPerc.Text)), (string.IsNullOrEmpty(txtGSTAmount.Text) ? 0 : Convert.ToDecimal(txtGSTAmount.Text)),
                        0, txtRemarks.Text, "", MainForm.User_Id, DateTime.Now, "", false, false, dataAcess);
                    if (dtPI.Rows.Count > 0)
                    {
                        PurchaseInvoiceId = Convert.ToInt32(dtPI.Rows[0]["PurchaseMasterId"]);
                        if (PurchaseInvoiceId > 0)
                        {
                            foreach (DataRow drDetail in dset.Tables["PurchaseDetail"].Rows)
                            {
                                if (drDetail.RowState != DataRowState.Deleted)
                                {
                                    int DetailId = managePurchase.InsertPurchaseDetail(Convert.ToInt32(drDetail["PurchaseDetailId"]), PurchaseInvoiceId, Convert.ToInt32(drDetail["RPODetailId"]), Convert.ToInt32(drDetail["ProductId"]), Convert.ToInt32(drDetail["ReceivedQty"]), Convert.ToDecimal(drDetail["Price"]), Convert.ToDecimal(drDetail["DiscountPercent"]), Convert.ToDecimal(drDetail["DiscountAmount"]), 0, MainForm.User_Id, DateTime.Now, "", dataAcess);
                                    if (chkPrice.Checked)
                                    {
                                        manageProduct.UpdateProductCostPrice(Convert.ToInt32(drDetail["ProductId"]), Convert.ToDecimal(drDetail["Price"]), dataAcess);
                                    }
                                }
                            }
                        }
                    }
                    managePurchaseOrder.setRPOIsClosed(txtRPONo.Text,  dataAcess);
                    dataAcess.TransCommit();

                    //Save ya Update per Post wala kaam off kerna hai q k yahn just Print ka option chyea.
                    //if (MessageBox.Show("Purchase Invoice " + txtPINo.Text + " has Saved." + Environment.NewLine + " Do you want to Post this Purchase Invoice. ", "Invoice Saved Successful.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    //{
                    //    //yahan Posting wala kaam aye ga.
                    //    PostPurchaseInvoice();
                    //}


                    if (MessageBox.Show("Purchase Invoice " + txtPINo.Text + " has Saved." + Environment.NewLine + " Do you want to Print this Purchase Invoice. ", "Invoice Saved Successful.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        PrintInvoice(false);
                    }
                    ButtonRights(false);
                    ClearFeilds();
                }
                catch (SqlException sqlex)
                {
                    dataAcess.TransRollback();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dataAcess.ConnectionClose();
                }
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validations())
            {
                try
                {
                    dataAcess.BeginTransaction();
                    if (dataAcess.getDBCommand().Transaction == null)
                    {
                        dataAcess.SetDBTransaction();
                    }
                    managePurchase.UpdatePurchaseMaster(PurchaseInvoiceId, txtRPONo.Text, dtpDate.Value, dtpDueDate.Value, txtVendorCode.Text, txtEmployeeCode.Text, Convert.ToDecimal(txtTotalAmount.Text), Convert.ToDecimal(txtDiscountPercent.Text), Convert.ToDecimal(txtDiscount.Text), 0, Convert.ToDecimal(txtGSTPerc.Text), Convert.ToDecimal(txtGSTAmount.Text), txtRemarks.Text, txtVoucherNo.Text, MainForm.User_Id, DateTime.Now, "", false, false, dataAcess);
                    if (PurchaseInvoiceId > 0)
                    {
                        foreach (DataRow drDetail in dset.Tables["PurchaseDetail"].Rows)
                        {
                            if (drDetail.RowState != DataRowState.Deleted)
                            {
                                int DetailId = managePurchase.InsertPurchaseDetail(Convert.ToInt32(drDetail["PurchaseDetailId"]), PurchaseInvoiceId, Convert.ToInt32(drDetail["RPODetailId"]), Convert.ToInt32(drDetail["ProductId"]), Convert.ToInt32(drDetail["ReceivedQty"]), Convert.ToDecimal(drDetail["Price"]), Convert.ToDecimal(drDetail["DiscountPercent"]), Convert.ToDecimal(drDetail["DiscountAmount"]), 0, MainForm.User_Id, DateTime.Now, "", dataAcess);
                                if (chkPrice.Checked)
                                {
                                    manageProduct.UpdateProductCostPrice(Convert.ToInt32(drDetail["ProductId"]), Convert.ToDecimal(drDetail["Price"]), dataAcess);
                                }
                            }
                        }
                    }
                    dataAcess.TransCommit();

                    //yehan per just Print wala kaam chyea.
                    //if (MessageBox.Show("Purchase Invoice " + txtPINo.Text + " has Updated." + Environment.NewLine + " Do you want to Post this Purchase Invoice. ", "Invoice Update Successful.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    //{
                    //    //yahan Posting wala kaam aye ga.
                    //    PostPurchaseInvoice();
                    //}
                    if (MessageBox.Show("Purchase Invoice " + txtPINo.Text + " has Updated." + Environment.NewLine + " Do you want to Print this Purchase Invoice. ", "Invoice Update Successful.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        PrintInvoice(false);
                    }
                    ButtonRights(false);
                    ClearFeilds();
                }
                catch (SqlException sqlex)
                {
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

        private void btnCSearch_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearch search = new frmSearch();
                Smartworks.ColumnField[] sRPO = new Smartworks.ColumnField[1];
                sRPO[0] = new Smartworks.ColumnField("@IsClose", 0);
                search.getattributes("GetRecevingPOSearch", sRPO, "Receiving PO");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtRPONo.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                search.getattributes("GetSearchPurchaseInvoice", null, "Purchase Invoices");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtPINo.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void txtVendorCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtVendorCode.Text))
            {
                int VendorId = manageVendor.GetVendorIdByCode(txtVendorCode.Text);
                if (VendorId > 0)
                {
                    LoadVendor(VendorId);
                }
            }
            else
            {
                txtVendorName.Text = string.Empty;
            }
        }

        private void txtVendorAccCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtVendorAccCode.Text))
                {
                    txtVendorAccName.Text = manageAccount.GetChartOfAccounts(manageAccount.GetCOAIdByCode(txtVendorAccCode.Text)).Rows[0]["AccountName"].ToString();
                }
                else
                {
                    txtVendorAccName.Text = string.Empty;
                }

            }
            catch (Exception ex)
            {
                txtVendorAccName.Text = string.Empty;
            }
        }
        private void LoadVendor(int VendorId)
        {
            DataTable dtVendor = manageVendor.GetVendor(VendorId);
            if (dtVendor.Rows.Count > 0)
            {
                txtVendorCode.Text = dtVendor.Rows[0]["Code"].ToString();
                txtVendorName.Text = dtVendor.Rows[0]["VendorName"].ToString();
                if (!string.IsNullOrEmpty(dtVendor.Rows[0]["COAId"].ToString()))
                {
                    txtVendorAccCode.Text = manageAccount.GetChartOfAccounts(Convert.ToInt32(dtVendor.Rows[0]["COAId"])).Rows[0]["AccountCode"].ToString();
                }
            }
        }



        private void gvDetail_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            try
            {
                DataRow dr = default(DataRow);
                dr = gvDetail.GetDataRow(e.RowHandle);
                if (Convert.ToInt32(dr["POrderDetailId"].ToString()) > 0)
                {
                    DeletedIds.Add(Convert.ToInt32(dr["POrderDetailId"].ToString()));
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Receiving PO Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeletePurchaseInvoice();
                        break;
                    }

            }
        }

        private void btnMinInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(managePurchase.GetMinInvioceNo(MainForm.FYear)))
            {
                txtPINo.Text = managePurchase.GetMinInvioceNo(MainForm.FYear);
            }
            
            //btnNextInvioceNo.Enabled = true;
            //btnPrevInvioceNo.Enabled = false;

        }

        private void btnPrevInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPINo.Text))
            {
                string LastInvioceNo = managePurchase.GetMinInvioceNo(MainForm.FYear);
                if (LastInvioceNo != txtPINo.Text.Trim())
                {
                    txtPINo.Text = managePurchase.GetPrevInvioceNo(txtPINo.Text);
                    if (LastInvioceNo == txtPINo.Text)
                    {
                        btnPrevInvioceNo.Enabled = false;
                        btnNextInvioceNo.Enabled = true;
                    }
                    else
                    {
                        btnNextInvioceNo.Enabled = true;
                    }
                }
                else
                {
                    btnPrevInvioceNo.Enabled = false;
                }

            }
        }
        private void btnNextInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPINo.Text))
            {
                string LastInvioceNo = managePurchase.GetMaxInvioceNo(MainForm.FYear);
                if (LastInvioceNo != txtPINo.Text.Trim())
                {
                    txtPINo.Text = managePurchase.GetNextInvioceNo(txtPINo.Text);
                    if (LastInvioceNo == txtPINo.Text)
                    {
                        btnNextInvioceNo.Enabled = false;
                        btnPrevInvioceNo.Enabled = true;
                    }
                    else
                    {
                        btnPrevInvioceNo.Enabled = true;
                    }
                }
                else
                {
                    btnNextInvioceNo.Enabled = false;
                }

            }
        }
        private void btnMaxInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(managePurchase.GetMaxInvioceNo(MainForm.FYear)))
            {
                txtPINo.Text = managePurchase.GetMaxInvioceNo(MainForm.FYear);
                if (!string.IsNullOrEmpty(txtPINo.Text))
                {
                    //btnNextInvioceNo.Enabled = false;
                    //btnPrevInvioceNo.Enabled = true;
                }
            }
            
        }

        private void frmDirectPurchase_KeyDown(object sender, KeyEventArgs e)
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

                if (GCDetail.Focus())
                {

                }
                else
                {
                    SendKeys.Send("{TAB}");
                }
            }
            else if (e.KeyCode == Keys.F2)
            {
                btnSearch.PerformClick();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintInvoice(false);
        }

        private void PrintInvoice(bool IsDirectPrint = true)
        {
            try
            {
                //abhi purchase Invoice ka koi format nh hai iski koi report nh banayi hui.
                return;
                if (string.IsNullOrEmpty(txtPINo.Text))
                {
                    return;
                }

                string path = Application.StartupPath + "/rpt/Purchaserpt/rptPurchaseOrder.rpt";
                ReportDocument document = new ReportDocument();
                document.Load(path);
                DataTable dtReport = new DataTable();
                dtReport = managePurchaseOrder.GetPurchaseOrderReport(null, null, "", "", "", "", PurchaseInvoiceId);
                document.SetDataSource(dtReport);
                Utility.SetReportDefaultParameter(ref document);

                if (IsDirectPrint)
                {
                    document.PrintToPrinter(1, true, 0, 0);
                }
                else
                {
                    frmReportPurchaseOrder report = new frmReportPurchaseOrder(document);
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

        private void btnESearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetEmployeeSearch", null, "Employee");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtEmployeeCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtEmployeeCode.Text = string.Empty;
                    txtEmployeeCode.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtEmployeeCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmployeeCode.Text))
            {
                DataTable dtEmployee = dataAcess.getDataTable("SELECT  * FROM dbo.Employee WHERE Code = '" + txtEmployeeCode.Text + "' ");
                if (dtEmployee.Rows.Count > 0)
                {
                    txtEmployeeName.Text = dtEmployee.Rows[0]["EmployeeName"].ToString();
                }
                else
                {
                    txtEmployeeName.Text = string.Empty;
                }
            }
            else
            {
                txtEmployeeName.Text = string.Empty;
            }
        }

        private void GCDetail_Click(object sender, EventArgs e)
        {

        }

        private void txtPONo_TextChanged(object sender, EventArgs e)
        {
            if (IsPurchaseInvoiceLoading)
            {
                return;
            }
            if (!string.IsNullOrEmpty(txtRPONo.Text))
            {
                RecevingPOId = managePurchaseOrder.GetPendingRecivingPOIdByCode(txtRPONo.Text);
                if (RecevingPOId > 0)
                {
                    LoadRecevingPOrder(RecevingPOId);
                }
            }
            else
            {
                txtRPONo.Text = string.Empty;
                //ClearFeilds();
            }
        }
        Utility clsUtility = new Utility();
        private void txtDiscountPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.setOnlyNumberic((TextBox)sender, true, e);
        }

        private void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {
            txtGSTPerc_Leave(null, null);
            txtDiscountPercent_Leave(null, null);
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Post it?", "Invoice Posting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        PostPurchaseInvoice();
                        break;
                    }

            }
        }

        private void PostPurchaseInvoice()
        {
            if (PurchaseInvoiceId < 0)
            {
                return;
            }
            //sp_PostPurchaseInvoice
            try
            {
                dataAcess.BeginTransaction();
                managePurchase.PostPurchaseInvoice(PurchaseInvoiceId, MainForm.User_Id, DateTime.Now, "", dataAcess);
                dataAcess.TransCommit();
                MessageBox.Show("Invoice Post Sucessfully...", "Invoice Posted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }
            catch (SqlException sqlex)
            {
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

        private void UNPostPurchaseInvoice()
        {
            if (PurchaseInvoiceId < 0)
            {
                return;
            }
            //sp_PostPurchaseInvoice
            try
            {
                dataAcess.BeginTransaction();
                managePurchase.UNPostPurchaseInvoice(PurchaseInvoiceId, MainForm.User_Id, DateTime.Now, "", dataAcess);
                dataAcess.TransCommit();
                MessageBox.Show("Invoice UNPost Sucessfully...", "Invoice UNPosted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }
            catch (SqlException sqlex)
            {
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

        private void btnUnPost_Click(object sender, EventArgs e)
        {
            if (PurchaseInvoiceId <= 0)
            {
                MessageBox.Show("Purchase Invoice Record does not found.", "Make sure Record Exists in form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult result = MessageBox.Show("Are you sure want to UN-Post Purchase Invoice?", "Purchase Invoice UN-Post", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        if (dtpDate.Value.Date < MainForm.FicalYearStart.Date || dtpDate.Value.Date > MainForm.FicalYearEnd.Date)
                        {
                            MessageBox.Show("Selected Entry does found in Current Running Year.", "Invalid Fiscal Year Entry UnPosted.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        UNPostPurchaseInvoice();
                        break;
                    }

            }
        }







    }
}
