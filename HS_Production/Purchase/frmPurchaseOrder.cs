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
    public partial class frmPurchaseOrder : Form
    {
        Smartworks.DAL dataAcess = new Smartworks.DAL();
        PurchaseOrderManager managePurchaseOrder = new PurchaseOrderManager();
       
        DataSet dset;
        RepositoryItemGridLookUpEdit repositoryGridLookup = new RepositoryItemGridLookUpEdit();
        RepositoryItemGridLookUpEdit repositoryColotGridLookup = new RepositoryItemGridLookUpEdit();
        //RepositoryItemGridLookUpEdit repositoryWarehouseGridLookup = new RepositoryItemGridLookUpEdit();
        BindingSource bsProducts = new BindingSource();
        BindingSource bsColor = new BindingSource();
        //BindingSource bsWarehouse = new BindingSource();
        DataRow drMaster;
        DataView dvProducts;
        DataViewManager dvm;
        int PurchaseOrderId = -1;
        List<int> DeletedIds = new List<int>();

        public frmPurchaseOrder()
        {
            InitializeComponent();
        }

        private void frmDirectSales_Load(object sender, EventArgs e)
        {
            ButtonRights(true);
            setGridSetup();
            txtPONo.Text = GetNewNextNumber();
            btnNextInvioceNo.Enabled = false;
            btnPrevInvioceNo.Enabled = false;

        }

        #region All Methods

        private String GetNewNextNumber()
        {
            string NewInvoiceNo = "";
            NewInvoiceNo = managePurchaseOrder.GetMaxInvioceNo();
            if (!string.IsNullOrEmpty(NewInvoiceNo))
            {
                NewInvoiceNo = managePurchaseOrder.GetNextInvioceNo(NewInvoiceNo);
            }
            else
            {
                NewInvoiceNo = "PO-000001";
            }
            return NewInvoiceNo;
        }
        private void ButtonRights(bool Enable)
        {
            btnAdd.Enabled = Enable;
            btnUpdate.Enabled = !Enable;
            btnDelete.Enabled = !Enable;
            txtPONo.ReadOnly = !Enable;
            //btnVSearch.Enabled = Enable;
            txtVendorCode.Enabled = Enable;
        }

        private void setGridSetup()
        {
            dset = new DataSet();
            dset = managePurchaseOrder.GetPurchaseOrderStructure(PurchaseOrderId);
            dset.Tables[0].TableName = "POrderMaster";
            dset.Tables[1].TableName = "POrderDetail";
            dset.Tables[2].TableName = "Product";
            dset.Tables[3].TableName = "Warehouse";
            dset.Tables[4].TableName = "Color";

            dset.Tables["POrderMaster"].Columns["POrderId"].AutoIncrement = true;
            dset.Tables["POrderMaster"].Columns["POrderId"].AutoIncrementSeed = -1;
            dset.Tables["POrderMaster"].Columns["POrderId"].AutoIncrementStep = -1;

            dset.Tables["POrderDetail"].Columns["POrderDetailId"].AutoIncrement = true;
            dset.Tables["POrderDetail"].Columns["POrderDetailId"].AutoIncrementSeed = -1;
            dset.Tables["POrderDetail"].Columns["POrderDetailId"].AutoIncrementStep = -1;


            dset.Relations.Add("MasterRelation", dset.Tables["POrderMaster"].Columns["POrderId"], dset.Tables["POrderDetail"].Columns["POrderId"]);
           if(dset.Tables["POrderMaster"].Rows.Count > 0)
           {
               drMaster = dset.Tables["POrderMaster"].Rows[0];
           }
           else
           {
               drMaster = dset.Tables["POrderMaster"].NewRow();
               dset.Tables["POrderMaster"].Rows.Add(drMaster);
           }
            dvm = new DataViewManager(dset);
            dvProducts = dvm.CreateDataView(dset.Tables["Product"]);
            GCDetail.DataSource = dset.Tables["POrderDetail"];
            GridSetting();
            CalculateTotalQty();
        }

        private void GridSetting()
        {
            
            gvDetail.Columns.ColumnByName("colPOrderDetailId").OptionsColumn.ReadOnly = true;
            gvDetail.Columns.ColumnByName("colPOrderId").OptionsColumn.ReadOnly = true;

            gvDetail.Columns.ColumnByName("colPOrderDetailId").Visible = false;
            gvDetail.Columns.ColumnByName("colPOrderId").Visible = false;
            gvDetail.Columns.ColumnByName("colBarcode").Visible = false;
            gvDetail.Columns.ColumnByName("colProductCategoryId").Visible = false;
            gvDetail.Columns.ColumnByName("colCategoryName").Visible = false;
            gvDetail.Columns.ColumnByName("colAddedBy").Visible = false;
            gvDetail.Columns.ColumnByName("colAddedOn").Visible = false;
            gvDetail.Columns.ColumnByName("colAddedIpAddr").Visible = false;
            gvDetail.Columns.ColumnByName("colUpdatedBy").Visible = false;
            gvDetail.Columns.ColumnByName("colUpdatedOn").Visible = false;
            gvDetail.Columns.ColumnByName("colUpdatedIpAddr").Visible = false;
            gvDetail.Columns.ColumnByName("colWarehouseId").Visible = false;

            //  ProductId  OrderQty Price  Amount DiscountPercent DiscountAmount GSTPercent GSTAmount TotalAmount

            gvDetail.Columns.ColumnByName("colProductId").Caption = "Product Name";
            gvDetail.Columns.ColumnByName("colColorId").Caption = "Color";
            gvDetail.Columns.ColumnByName("colOrderQty").Caption = "Quantity";
            gvDetail.Columns.ColumnByName("colPrice").Caption = "Price";
            gvDetail.Columns.ColumnByName("colAmount").Caption = "Amount";
            gvDetail.Columns.ColumnByName("colGSTPercent").Caption = "GST %";
            gvDetail.Columns.ColumnByName("colGSTAmount").Caption = "GST Amount";
            gvDetail.Columns.ColumnByName("colAmount").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colAmount").OptionsColumn.AllowFocus = false;

            gvDetail.Columns.ColumnByName("colDiscountPercent").Caption = "Disc %";
            gvDetail.Columns.ColumnByName("colDiscountAmount").Caption = "Disc Amount";
            gvDetail.Columns.ColumnByName("colDiscountedAmount").Caption = "Discounted";
            gvDetail.Columns.ColumnByName("colTotalAmount").Caption = "Total Amount";


            gvDetail.Columns.ColumnByName("colDiscountedAmount").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colDiscountedAmount").OptionsColumn.AllowFocus = false;

            gvDetail.Columns.ColumnByName("colTotalAmount").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colTotalAmount").OptionsColumn.AllowFocus = false;




            gvDetail.Columns.ColumnByName("colProductId").VisibleIndex = 0;
            gvDetail.Columns.ColumnByName("colColorId").VisibleIndex = 1;
            gvDetail.Columns.ColumnByName("colOrderQty").VisibleIndex = 2;
            gvDetail.Columns.ColumnByName("colPrice").VisibleIndex = 3;
            gvDetail.Columns.ColumnByName("colAmount").VisibleIndex = 4;
            gvDetail.Columns.ColumnByName("colDiscountPercent").VisibleIndex = 5;
            gvDetail.Columns.ColumnByName("colDiscountAmount").VisibleIndex = 6;
            gvDetail.Columns.ColumnByName("colDiscountedAmount").VisibleIndex = 7;
            gvDetail.Columns.ColumnByName("colGSTPercent").VisibleIndex = 8;
            gvDetail.Columns.ColumnByName("colGSTAmount").VisibleIndex = 9;
            gvDetail.Columns.ColumnByName("colTotalAmount").VisibleIndex = 10;


            gvDetail.Columns.ColumnByName("colProductId").Width = 300;
            gvDetail.Columns.ColumnByName("colColorId").Width = 150;
            gvDetail.Columns.ColumnByName("colOrderQty").Width = 50;
            gvDetail.Columns.ColumnByName("colPrice").Width = 50;
            gvDetail.Columns.ColumnByName("colAmount").Width = 100;
            gvDetail.Columns.ColumnByName("colDiscountPercent").Width = 80;
            gvDetail.Columns.ColumnByName("colGSTPercent").Width = 50;
            gvDetail.Columns.ColumnByName("colGSTAmount").Width = 80;
            //gvDetail.Columns.ColumnByName("colDiscountAmount").Width = 80;
            gvDetail.Columns.ColumnByName("colDiscountedAmount").Width = 80;
            gvDetail.Columns.ColumnByName("colTotalAmount").Width = 120;

            bsProducts.DataSource = dset;
            bsProducts.DataMember = "Product";

            bsColor.DataSource = dset;
            bsColor.DataMember = "Color";

            

            //bsWarehouse.DataSource = dset;
            //bsWarehouse.DataMember = "Warehouse";


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

            repositoryColotGridLookup.DataSource = bsColor;
            repositoryColotGridLookup.DisplayMember = "ColorName";
            repositoryColotGridLookup.ValueMember = "ColorId";
            repositoryColotGridLookup.PopupFormSize = new Size(250, 250);
            repositoryColotGridLookup.NullText = "";
            repositoryColotGridLookup.ShowFooter = false;
            repositoryColotGridLookup.View.OptionsView.ColumnAutoWidth = false;
            repositoryColotGridLookup.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            repositoryColotGridLookup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            repositoryColotGridLookup.ImmediatePopup = true;
            repositoryColotGridLookup.PopulateViewColumns();
            GCDetail.RepositoryItems.Add(repositoryColotGridLookup);

            (GCDetail.MainView as GridView).Columns.ColumnByName("colColorId").ColumnEdit = repositoryColotGridLookup;

            if (repositoryColotGridLookup.View.Columns.Count > 0)
            {
                repositoryColotGridLookup.View.Columns.ColumnByName("colColorId").Visible = false;
                repositoryColotGridLookup.View.Columns.ColumnByName("colColorName").Caption = "Color";
                repositoryColotGridLookup.View.Columns.ColumnByName("colColorName").Width = 150;
                repositoryColotGridLookup.View.Columns.ColumnByName("colColorName").VisibleIndex = 0;
            }
            gvDetail.Columns.ColumnByName("colProductId").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
        }

        private void ClearFeilds()
        {
            txtPONo.Text = string.Empty;
            dtpDate.Value = DateTime.Now;
            dtpDueDate.Value = DateTime.Now;
            txtVendorCode.Text = string.Empty;
            txtVendorName.Text = string.Empty;
            txtEmployeeCode.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtTotalAmount.Text = "0";
            txtDiscount.Text = "0";
            txtDiscountPercent.Text = "0";
            txtNetTotal.Text = "0";
            PurchaseOrderId =  -1;
            chkClose.Checked = false;   
            DeletedIds = new List<int>();


            dset.Tables["POrderDetail"].Rows.Clear();
            dset.Tables["POrderMaster"].Rows.Clear();

            dset.RejectChanges();


            drMaster = dset.Tables["POrderMaster"].NewRow();
            dset.Tables["POrderMaster"].Rows.Add(drMaster);
            GCDetail.DataSource = dset.Tables["POrderDetail"];
            GridSetting();
            ButtonRights(true);
            txtPONo.Text = GetNewNextNumber();
            btnNextInvioceNo.Enabled = false;
            btnPrevInvioceNo.Enabled = false;
        }
        private void LoadPOrder()
        {
            try
            {
                setGridSetup();
                
                if (dset.Tables["POrderMaster"].Rows.Count > 0)
                {   
                    txtVendorCode.Text = drMaster["VendorCode"].ToString();
                    txtEmployeeCode.Text = drMaster["EmployeeCode"].ToString();
                    dtpDate.Value = Convert.ToDateTime(drMaster["OrderDate"]);
                    dtpDueDate.Value = Convert.ToDateTime(drMaster["DueDate"]);
                    txtRemarks.Text = drMaster["Remarks"].ToString();
                    txtTotalAmount.Text = drMaster["TAmount"].ToString();
                    txtDiscountPercent.Text = drMaster["TDiscountPerc"].ToString();
                    txtDiscount.Text = drMaster["TDiscount"].ToString();
                    txtNetTotal.Text = Math.Round(decimal.Parse(drMaster["NetAmount"].ToString()), 0).ToString();
                    chkClose.Checked = Convert.ToBoolean(drMaster["Closed"]);
                    ButtonRights(false);
                    //for Navigation Works*******
                    try
                    {
                        string FirstTransNo = managePurchaseOrder.GetMinInvioceNo();
                        string LastTransNo = managePurchaseOrder.GetMaxInvioceNo();
                        if (LastTransNo == txtPONo.Text)
                        {
                            btnNextInvioceNo.Enabled = false;
                        }
                        else
                        {
                            btnNextInvioceNo.Enabled = true;
                        }
                        if (FirstTransNo == txtPONo.Text)
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
                MessageBox.Show(ex.Message, "Error!!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void gvDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                DataRow dr = gvDetail.GetFocusedDataRow();
                decimal DiscountedAmount = 0;
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
                        if (string.IsNullOrEmpty(dr["OrderQty"].ToString()))
                        {
                            dr["OrderQty"] = 1;
                        }

                        dr["Amount"] = Math.Round((decimal.Parse(dr["Price"].ToString()) * decimal.Parse(dr["OrderQty"].ToString())), 2);
                        dr["DiscountAmount"] = Math.Round((decimal.Parse(dr["Amount"].ToString()) * decimal.Parse(dr["DiscountPercent"].ToString()) / 100), 2);
                        dr["DiscountedAmount"] = Math.Round((decimal.Parse(dr["Amount"].ToString()) - decimal.Parse(dr["DiscountAmount"].ToString())), 2);
                        if (string.IsNullOrEmpty(dr["GSTPercent"].ToString()))
                        {
                            dr["GSTPercent"] = "0";
                            dr["GSTAmount"] = "0";
                        }
                       //dr["GSTAmount"] = "0.00"; // Math.Round(((decimal.Parse(dr["DiscountedAmount"].ToString()) * decimal.Parse(dr["GSTPercent"].ToString()) / 100)), 2);
                        //dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()), 2);
                        dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()), 2);

                        break;

                    case "colDiscountPercent":
                        //if (string.IsNullOrEmpty(dr["DiscountPercent"].ToString()))
                        //{
                        //    dr["DiscountPercent"] = dvProducts[0]["DiscountPerc"];
                        //}
                        //if (decimal.Parse(dr["DiscountPercent"].ToString()) < 0)
                        //{
                        //    dr["DiscountPercent"] = dvProducts[0]["DiscountPerc"];
                        //}

                        //dr["DiscountAmount"] = Math.Round((decimal.Parse(dr["Amount"].ToString()) * decimal.Parse(dr["DiscountPercent"].ToString())) / 100, 2);
                        //dr["DiscountedAmount"] = Math.Round(decimal.Parse(dr["Amount"].ToString()) - decimal.Parse(dr["DiscountAmount"].ToString()), 2);

                        //dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()), 2);
                        //break;
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

                        /****GST Work**/
                        if (string.IsNullOrEmpty(dr["GSTPercent"].ToString()))
                        {
                            dr["GSTPercent"] = "0.00";
                        }
                        if (decimal.Parse(dr["GSTPercent"].ToString()) < 0)
                        {
                            dr["GSTPercent"] = "0.00";
                        }
                        
                        if (!string.IsNullOrEmpty(dr["DiscountedAmount"].ToString()))
                        {
                            DiscountedAmount = decimal.Parse(dr["DiscountedAmount"].ToString());
                        }
                        if (DiscountedAmount > 0)
                        {
                            dr["GSTAmount"] = ((DiscountedAmount / 100) * decimal.Parse(dr["GSTPercent"].ToString()));
                        }
                        /*************/

                        dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()), 2);
                        break;
                    case "colDiscountAmount":
                        //if (string.IsNullOrEmpty(dr["DiscountAmount"].ToString()))
                        //{
                        //    dr["DiscountAmount"] = "0.00";
                        //}
                        //if (decimal.Parse(dr["DiscountAmount"].ToString()) < 0)
                        //{
                        //    dr["DiscountAmount"] = "0.00";
                        //}

                        //dr["DiscountAmount"] = Math.Round(decimal.Parse(dr["DiscountAmount"].ToString()), 2);
                        //dr["DiscountPercent"] = Math.Round((decimal.Parse(dr["DiscountAmount"].ToString()) / decimal.Parse(dr["Amount"].ToString())) * 100, 2);
                        //dr["DiscountedAmount"] = Math.Round(decimal.Parse(dr["Amount"].ToString()) - decimal.Parse(dr["DiscountAmount"].ToString()), 2);

                        
                        //dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()), 2);
                        //break;
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


                        dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()), 2);
                        break;
                    case "colGSTPercent":

                        //if (string.IsNullOrEmpty(dr["GSTPercent"].ToString()))
                        //{
                        //    dr["GSTPercent"] = "0.00";
                        //}
                        //if (decimal.Parse(dr["GSTPercent"].ToString()) < 0)
                        //{
                        //    dr["GSTPercent"] = "0.00";
                        //}
                        //decimal Amount = 0;
                        //if (!string.IsNullOrEmpty(dr["Amount"].ToString()))
                        //{
                        //    Amount = decimal.Parse(dr["Amount"].ToString());
                        //}
                        //if (Amount > 0)
                        //{
                        //    dr["GSTAmount"] = Amount + (Amount / 100) * decimal.Parse(dr["GSTPercent"].ToString());
                        //}
                        //dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()), 2);
                        //break;
                         if (string.IsNullOrEmpty(dr["GSTPercent"].ToString()))
                        {
                            dr["GSTPercent"] = "0.00";
                        }
                        if (decimal.Parse(dr["GSTPercent"].ToString()) < 0)
                        {
                            dr["GSTPercent"] = "0.00";
                        }
                        //decimal DiscountedAmount = 0;
                        if (!string.IsNullOrEmpty(dr["DiscountedAmount"].ToString()))
                        {
                            DiscountedAmount = decimal.Parse(dr["DiscountedAmount"].ToString());
                        }
                        if (DiscountedAmount > 0)
                        {
                            dr["GSTAmount"] = ((DiscountedAmount / 100) * decimal.Parse(dr["GSTPercent"].ToString()));
                        }
                        dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()), 2);
                        break;
                    case "colGSTAmount":
                        //if (string.IsNullOrEmpty(dr["GSTAmount"].ToString()))
                        //{
                        //    dr["GSTAmount"] = "0.00";
                        //}
                        //if (decimal.Parse(dr["GSTAmount"].ToString()) < 0)
                        //{
                        //    dr["GSTAmount"] = "0.00";
                        //}
                        //dr["GSTPercent"] = Math.Round((decimal.Parse(dr["GSTAmount"].ToString()) / decimal.Parse(dr["Amount"].ToString())) * 100, 2);
                        //dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()), 2);

                        //break;
                         if (string.IsNullOrEmpty(dr["GSTAmount"].ToString()))
                        {
                            dr["GSTAmount"] = "0.00";
                        }
                        if (decimal.Parse(dr["GSTAmount"].ToString()) < 0)
                        {
                            dr["GSTAmount"] = "0.00";
                        }
                        dr["GSTPercent"] = Math.Round((decimal.Parse(dr["GSTAmount"].ToString()) / decimal.Parse(dr["DiscountedAmount"].ToString())) * 100, 2);
                        dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()), 2);

                        break;
                    
                    case "colOrderQty":
                        if (string.IsNullOrEmpty(dr["OrderQty"].ToString()))
                        {
                            dr["OrderQty"] = 1;  //Default Quantity is 1;
                        }
                        if (decimal.Parse(dr["OrderQty"].ToString()) < 0)
                        {
                            dr["OrderQty"] = 1;  //Qty Should be greater then zero;
                        }
                        dr["Amount"] = Math.Round((decimal.Parse(dr["Price"].ToString()) * decimal.Parse(dr["OrderQty"].ToString())), 2);

                        if (dr["DiscountPercent"] != null)
                        {
                            if (decimal.Parse(dr["DiscountPercent"].ToString()) > 0)
                            {
                                dr["DiscountAmount"] = Math.Round((decimal.Parse(dr["Amount"].ToString()) * decimal.Parse(dr["DiscountPercent"].ToString())) / 100, 2);
                                dr["DiscountedAmount"] = Math.Round(decimal.Parse(dr["Amount"].ToString()) - decimal.Parse(dr["DiscountAmount"].ToString()), 2);
                                
                                dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()), 2);
                            }
                        }
                        dr["DiscountedAmount"] = Math.Round(decimal.Parse(dr["Amount"].ToString()) - decimal.Parse(dr["DiscountAmount"].ToString()), 2);
                        
                        dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()), 2);
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
                        dr["Amount"] = Math.Round(decimal.Parse(dr["Price"].ToString()) * decimal.Parse(dr["OrderQty"].ToString()), 2);

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
                        
                        dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()), 2);
                        break;

                  
                }
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message);
            }
            CalculateSummary();
            CalculateTotalQty();
        }

        private void gvDetail_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Value != null)
            {
                switch (e.Column.Name.ToString())
                {
                    case "colProductId":
                        {
                            try
                            {
                                dvProducts.RowFilter = "ProductId='" + e.Value.ToString() + "'";
                            }
                            catch
                            { 
                            }
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
                foreach (DataRow dr in dset.Tables["POrderDetail"].Rows)
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

        private void CalculateTotalQty()
        {
            int totQty = 0;
            try
            {
                 //dset.Tables[1].TableName = "";
                foreach (DataRow dr in dset.Tables["POrderDetail"].Rows)
                {
                    if (dr.RowState != DataRowState.Deleted)
                    {
                        totQty = totQty + (string.IsNullOrEmpty(dr["OrderQty"].ToString()) ? 0 : Convert.ToInt32(dr["OrderQty"]));
                    }
                }
            }
            catch(Exception ex)
            {

            }
            txtTotalQty.Text = totQty.ToString();
        }

        private void txtDiscountPercent_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDiscountPercent.Text))
            {
                if (decimal.Parse(txtDiscountPercent.Text) > 100)
                {
                    txtDiscount.Text = "0";
                    txtDiscountPercent.Text = "0";
                    txtNetTotal.Text = Math.Round(decimal.Parse(txtTotalAmount.Text), 0).ToString(); //+ decimal.Parse(tbxFreightCharges.Text);
                    txtDiscountPercent.Focus();
                    //MessageBox.Show(Messages.Percentage, Messages.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    txtDiscountPercent.Text = Math.Round(decimal.Parse(txtDiscountPercent.Text), 2).ToString();
                    txtDiscount.Text = Math.Round(((decimal.Parse(txtTotalAmount.Text) * decimal.Parse(txtDiscountPercent.Text)) / 100), 0).ToString();
                    txtNetTotal.Text = Math.Round((decimal.Parse(txtTotalAmount.Text) - decimal.Parse(txtDiscount.Text)), 0).ToString();
                }
            }
            else
            {
                txtDiscountPercent.Text = "0";
                txtDiscountPercent.Text = Math.Round(decimal.Parse(txtDiscountPercent.Text), 2).ToString();
                txtDiscount.Text = Math.Round(((decimal.Parse(txtTotalAmount.Text) * decimal.Parse(txtDiscountPercent.Text)) / 100), 0).ToString();
                txtNetTotal.Text = Math.Round((decimal.Parse(txtTotalAmount.Text) - decimal.Parse(txtDiscount.Text)), 0).ToString();

            }
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDiscount.Text))
            {
                if (decimal.Parse(txtDiscount.Text) > decimal.Parse(txtTotalAmount.Text))
                {
                    txtDiscount.Text = "0";
                    txtDiscountPercent.Text = "0";
                    txtNetTotal.Text = Math.Round(decimal.Parse(txtTotalAmount.Text), 0).ToString(); ;
                    txtDiscount.Focus();
                    //MessageBox.Show(Messages.DiscountGreaterThanAmount, Messages.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (decimal.Parse(txtTotalAmount.Text) > 0)
                    {
                        txtDiscount.Text = Math.Round(decimal.Parse(txtDiscount.Text), 0).ToString();
                        txtDiscountPercent.Text = Math.Round(((decimal.Parse(txtDiscount.Text) / decimal.Parse(txtTotalAmount.Text)) * 100), 2).ToString();
                        txtNetTotal.Text = Math.Round((decimal.Parse(txtTotalAmount.Text) - decimal.Parse(txtDiscount.Text)), 0).ToString();
                    }
                }
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
                CalculateTotalQty();
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

            else if (decimal.Parse(dr["OrderQty"].ToString()) <= 0)
            {
                //Quantity = "Less than one";
                e.Valid = false;
            }
            else if (dr.RowState == DataRowState.Detached)
            {
                //if (dset.Tables["POrderDetail"].Select("ProductId =" + dr["ProductId"].ToString()).Length > 0)
                //{
                //    MessageBox.Show("Item Already Exists", "Same Items can not be repeated.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    e.Valid = false;
                //}
            }
            else
            {
                e.Valid = true;
                gvDetail.GetDataRow(e.RowHandle)["POrderId"] = drMaster["POrderId"]; //SalesMasterId;
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
            if (string.IsNullOrEmpty(txtVendorCode.Text))
            {
                MessageBox.Show("Please Select Party Code.", "Party Code is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVendorCode.Focus();
                result = false;

            }
            if (dset.Tables["POrderDetail"].Rows.Count <= 0)
            {
                MessageBox.Show("Please Enter Detail of Purchase Order.", "Detail is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
            }

            //if (dtpDate.Value.Date < MainForm.FicalYearStart.Date || dtpDate.Value.Date > MainForm.FicalYearEnd.Date)
            //{
            //    MessageBox.Show("Invalid Date Selection. Selected Date is Out of Rang of Fical Year", "Invalid Date Selection.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    result = false;
            //}
            return result;

        }

        private void DeletePurchaseOrder()
        {
            if (string.IsNullOrEmpty(txtPONo.Text))
            {
                return;
            }
            try
            {
                if (managePurchaseOrder.IsPurchaseOrderInUsed(txtPONo.Text))
                {
                    MessageBox.Show("Purchase Order " + txtPONo.Text + " Can not be Deleted becuase Reference in Use.", "Error to Delete Purchase Order.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                //ProductManager PM = new ProductManager();
                //VendorManager VendorM = new VendorManager();
                dataAcess.BeginTransaction();
                //PM.DeleteProductLedgerByTransNo(txtPONo.Text, dataAcess);

                int status =  managePurchaseOrder.DeletePOrderMaster(managePurchaseOrder.GetPurchaseOrderMasterIdByCode(txtPONo.Text), dataAcess);
                dataAcess.TransCommit();
                if (status > 0)
                {
                    MessageBox.Show("Purchase Order " + txtPONo.Text + " is Deleted.", "Invoice Delete Successful.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear_Click(null, null);
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validations())
            {
                try
                {
                   
                    int POrderId = -1;
                   
                    ProductManager PM = new ProductManager();
                    VendorManager VendorM = new VendorManager();
                    dataAcess.BeginTransaction();
                    if (dataAcess.getDBCommand().Transaction == null)
                    {
                        dataAcess.SetDBTransaction();
                    }
                    int VendorId = VendorM.GetVendorIdByCode(txtVendorCode.Text);
                    POrderId = managePurchaseOrder.InsertPOMaster(Convert.ToDateTime(dtpDate.Value.ToString()), Convert.ToDateTime(dtpDueDate.Value), "H", txtVendorCode.Text, "", txtEmployeeCode.Text, -1, -1, 0, decimal.Parse(txtTotalAmount.Text), decimal.Parse(txtDiscountPercent.Text), decimal.Parse(txtDiscount.Text) , chkClose.Checked, txtRemarks.Text, "", MainForm.User_Id, DateTime.Now, "", dataAcess);
                    if (POrderId > 0)
                    {
                        for (int i = 0; i < dset.Tables["POrderDetail"].Rows.Count; i++)
                        {
                            int DetailId = managePurchaseOrder.InsertUpdatePODetail(Convert.ToInt32(dset.Tables["POrderDetail"].Rows[i]["POrderDetailId"]), POrderId, Convert.ToInt32(dset.Tables["POrderDetail"].Rows[i]["ProductId"]), (string.IsNullOrEmpty(dset.Tables["POrderDetail"].Rows[i]["ColorId"].ToString()) ? -1 : Convert.ToInt32(dset.Tables["POrderDetail"].Rows[i]["ColorId"])), "Stock", -1, Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["OrderQty"]), Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["Price"]), Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["DiscountPercent"]), Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["DiscountAmount"]), Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["GSTPercent"]), Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["GSTAmount"]), MainForm.User_Id, DateTime.Now, "", dataAcess);
                        }
                    }
                    dataAcess.TransCommit();
                    if (MessageBox.Show("Purchase Order " + txtPONo.Text + " has Saved." + Environment.NewLine + " Do you want to Print. ", "Order Saved Successful.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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

        private void btnCSearch_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearch search = new frmSearch();
                search.getattributes("GetVendorSearch", null, "Party Names");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    DataTable dtVendor = dataAcess.getDataTable("SELECT  * FROM dbo.Vendor WHERE Code = '" + MainForm.Searched_Id + "' ");
                    txtVendorCode.Text = dtVendor.Rows[0]["Code"].ToString();
                    txtVendorName.Text = dtVendor.Rows[0]["VendorName"].ToString();
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
                search.getattributes("GetSearchPurchaseOrders", null, "Purchase Orders");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtPONo.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                    //LoadPOrder(); 
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

                DataTable dtVendor = dataAcess.getDataTable("SELECT  * FROM dbo.Vendor WHERE Code = '" + txtVendorCode.Text + "' ");
                if (dtVendor.Rows.Count > 0)
                {
                    txtVendorName.Text = dtVendor.Rows[0]["VendorName"].ToString();
                }
                
            }
            else
            {
                txtVendorName.Text = string.Empty;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validations())
            {
                try
                {
                    ProductManager PM = new ProductManager();
                    VendorManager VendorM = new VendorManager();
                    dataAcess.BeginTransaction();
                    if (dataAcess.getDBCommand().Transaction == null)
                    {
                        dataAcess.SetDBTransaction();
                    }
                    int VendorId = VendorM.GetVendorIdByCode(txtVendorCode.Text);
                    foreach (int id in DeletedIds)
                    {  
                        managePurchaseOrder.DeletePOrderDetailByDetailId(id, dataAcess);
                    }
                    managePurchaseOrder.UpdatePOMaster(PurchaseOrderId, Convert.ToDateTime(dtpDate.Value), Convert.ToDateTime(dtpDueDate.Value), "H", txtVendorCode.Text, "", 
                        txtEmployeeCode.Text, -1, -1, 0, decimal.Parse(txtTotalAmount.Text), decimal.Parse(txtDiscountPercent.Text), decimal.Parse(txtDiscount.Text),
                        chkClose.Checked, txtRemarks.Text, "", MainForm.User_Id, DateTime.Now, "", dataAcess);
                    for (int i = 0; i < dset.Tables["POrderDetail"].Rows.Count; i++)
                    {
                        if (dset.Tables["POrderDetail"].Rows[i].RowState != DataRowState.Deleted)
                        {
                            DataRow drDetail = dset.Tables["POrderDetail"].Rows[i];
                            int DetailId = managePurchaseOrder.InsertUpdatePODetail(Convert.ToInt32(drDetail["POrderDetailId"]), PurchaseOrderId, Convert.ToInt32(drDetail["ProductId"]), (string.IsNullOrEmpty(dset.Tables["POrderDetail"].Rows[i]["ColorId"].ToString()) ? -1 : Convert.ToInt32(dset.Tables["POrderDetail"].Rows[i]["ColorId"])) , "Stock", -1, Convert.ToDecimal(drDetail["OrderQty"]), Convert.ToDecimal(drDetail["Price"]), Convert.ToDecimal(drDetail["DiscountPercent"]), Convert.ToDecimal(drDetail["DiscountAmount"]), Convert.ToDecimal(drDetail["GSTPercent"]), Convert.ToDecimal(drDetail["GSTAmount"]), MainForm.User_Id, DateTime.Now.Date, "", dataAcess);
                        }
                    }

                    dataAcess.TransCommit();
                    if (MessageBox.Show("Purchase Order " + txtPONo.Text + " has Saved." + Environment.NewLine + " Do you want to Print. ", "Purchase Order Saved Successful.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Purchase Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeletePurchaseOrder();
                        break;
                    }

            }
        }

        private void btnMinInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(managePurchaseOrder.GetMinInvioceNo()))
            {
                txtPONo.Text = managePurchaseOrder.GetMinInvioceNo();
                if (!string.IsNullOrEmpty(txtPONo.Text))
                {
                    //LoadPOrder();
                    //btnNextInvioceNo.Enabled = true;
                    //btnPrevInvioceNo.Enabled = false;
                }
            }
            
        }

        private void btnPrevInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPONo.Text))
            {
                string LastInvioceNo = managePurchaseOrder.GetMinInvioceNo();
                txtPONo.Text = managePurchaseOrder.GetPrevInvioceNo(txtPONo.Text);

                //LoadPOrder();
                if (LastInvioceNo == txtPONo.Text)
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
            if (!string.IsNullOrEmpty(txtPONo.Text))
            {
                string LastInvioceNo = managePurchaseOrder.GetMaxInvioceNo();
                txtPONo.Text = managePurchaseOrder.GetNextInvioceNo(txtPONo.Text);
                //LoadPOrder();
                if (LastInvioceNo == txtPONo.Text)
                {
                    btnNextInvioceNo.Enabled = false;
                }
                else
                {
                    btnPrevInvioceNo.Enabled = true;
                }
            }
        }
        private void btnMaxInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(managePurchaseOrder.GetMaxInvioceNo()))
            {
                txtPONo.Text = managePurchaseOrder.GetMaxInvioceNo();
                if (!string.IsNullOrEmpty(txtPONo.Text))
                {
                    // LoadPOrder();
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
                if (string.IsNullOrEmpty(txtPONo.Text))
                {
                    return;
                }

                string path = Application.StartupPath + "/rpt/Purchaserpt/rptPurchaseOrder.rpt";
                ReportDocument document = new ReportDocument();
                document.Load(path);
                DataTable dtReport = new DataTable();
                dtReport = managePurchaseOrder.GetPurchaseOrderReport(null, null, "", "","" ,"" ,PurchaseOrderId);
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
            if (!string.IsNullOrEmpty(txtPONo.Text))
            {
                PurchaseOrderId = managePurchaseOrder.GetPurchaseOrderMasterIdByCode(txtPONo.Text);
                if (PurchaseOrderId > 0)
                {
                    LoadPOrder();
                }
            }
            else
            {
                ClearFeilds();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                ProductManager manageProduct = new ProductManager();
                if (dset.Tables.Contains("Products"))
                {
                    dset.Tables["Products"].Rows.Clear();
                    DataTable dtProduct = manageProduct.GetUpdatedProducts();
                    foreach (DataRow dr in dtProduct.Rows)
                    {
                        dset.Tables["Products"].ImportRow(dr);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
