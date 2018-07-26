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
    public partial class frmReceivingPO : Form
    {
        Smartworks.DAL dataAcess = new Smartworks.DAL();
        PurchaseOrderManager managePurchaseOrder = new PurchaseOrderManager();
        DataSet dset;
        RepositoryItemGridLookUpEdit repositoryGridLookup = new RepositoryItemGridLookUpEdit();
        //RepositoryItemGridLookUpEdit repositoryWarehouseGridLookup = new RepositoryItemGridLookUpEdit();
        BindingSource bsProducts = new BindingSource();
        //BindingSource bsWarehouse = new BindingSource();
        Utility clsUtility = new Utility();
        DataRow drMaster;
        DataView dvProducts;
        DataViewManager dvm;
        int PurchaseOrderId = -1;
        int RecevingPOId = -1;
        bool IsRecevingPOLoading = false;
        List<int> DeletedIds = new List<int>();

        public frmReceivingPO()
        {
            InitializeComponent();
        }

        private void frmDirectSales_Load(object sender, EventArgs e)
        {
            ButtonRights(true);
            FillDropDown();
            //setGridSetup();
            txtReceivingPO.Text = GetNewNextNumber();
            GCDetail.Enabled = false;
            btnNextInvioceNo.Enabled = false;
            btnPrevInvioceNo.Enabled = false;

        }

        #region All Methods


        private String GetNewNextNumber()
        {
            string NewInvoiceNo = "";
            NewInvoiceNo = managePurchaseOrder.GetMaxRPONo();
            if (!string.IsNullOrEmpty(NewInvoiceNo))
            {
                NewInvoiceNo = managePurchaseOrder.GetNextInvioceNo(NewInvoiceNo);
            }
            else
            {
                NewInvoiceNo = "RPO-000001";
            }
            return NewInvoiceNo;
        }
        private void ButtonRights(bool Enable)
        {
            btnAdd.Enabled = Enable;
            btnUpdate.Enabled = !Enable;
            btnDelete.Enabled = !Enable;
            txtPONo.ReadOnly = !Enable;
            btnSearch.Enabled = Enable;
            //btnRPOSearch.Enabled = Enable;
            txtVendorCode.Enabled = Enable;
        }

        private void setGridSetup(bool IsPurchaseOrderLoaded, int TranId)
        {
            dset = new DataSet();
            if (IsPurchaseOrderLoaded)
            {
                //age Purchase Order Load hoga yani koi new entry ker raha hu ya phr koi PO load ker raha hu toh yeh wala structure aye ga .
                //dono k structure same rakhy hain. lakin data ka farq hai 

                dset = managePurchaseOrder.GetReceivingPOStructureByPOId(TranId);
            }
            else
            {
                //age koi Receving PO dekh raha hu ya Edit mode per hu ya koi cheez Update kerni hai toh yeh wala structure load hoga. 
                //dono k structure same rakhy hain. lakin data ka farq hai 

                dset = managePurchaseOrder.GetReceivingPOStructure(TranId);
            }

            dset.Tables[0].TableName = "POrderMaster";
            dset.Tables[1].TableName = "POrderDetail";
            dset.Tables[2].TableName = "Product";
            dset.Tables[3].TableName = "Warehouse";

            dset.Tables["POrderMaster"].Columns["RPOId"].AutoIncrement = true;
            dset.Tables["POrderMaster"].Columns["RPOId"].AutoIncrementSeed = -1;
            dset.Tables["POrderMaster"].Columns["RPOId"].AutoIncrementStep = -1;

            dset.Tables["POrderDetail"].Columns["RPODetailId"].AutoIncrement = true;
            dset.Tables["POrderDetail"].Columns["RPODetailId"].AutoIncrementSeed = -1;
            dset.Tables["POrderDetail"].Columns["RPODetailId"].AutoIncrementStep = -1;


            dset.Relations.Add("MasterRelation", dset.Tables["POrderMaster"].Columns["RPOId"], dset.Tables["POrderDetail"].Columns["RPOId"]);
            if (dset.Tables["POrderMaster"].Rows.Count > 0)
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


        }
        private void GridSetting()
        {


            gvDetail.Columns.ColumnByName("colRPODetailId").OptionsColumn.ReadOnly = true;
            gvDetail.Columns.ColumnByName("colPOrderDetailId").OptionsColumn.ReadOnly = true;
            gvDetail.Columns.ColumnByName("colRPOId").OptionsColumn.ReadOnly = true;

            gvDetail.Columns.ColumnByName("colRPODetailId").Visible = false;
            gvDetail.Columns.ColumnByName("colRPOId").Visible = false;
            gvDetail.Columns.ColumnByName("colPOrderDetailId").Visible = false;
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
            gvDetail.Columns.ColumnByName("colOrderQty").Caption = "Order Qty";
            gvDetail.Columns.ColumnByName("colTotalReceived").Caption = "Total Received";
            gvDetail.Columns.ColumnByName("colReceivedQty").Caption = "Receive Qty";
            gvDetail.Columns.ColumnByName("colBalanceQty").Caption = "Balance Qty";
            gvDetail.Columns.ColumnByName("colPrice").Caption = "Price";
            gvDetail.Columns.ColumnByName("colAmount").Caption = "Amount";
            gvDetail.Columns.ColumnByName("colGSTPercent").Caption = "GST %";
            gvDetail.Columns.ColumnByName("colGSTAmount").Caption = "GST Amount";
            gvDetail.Columns.ColumnByName("colDiscountPercent").Caption = "Disc %";
            gvDetail.Columns.ColumnByName("colDiscountAmount").Caption = "Disc Amount";
            gvDetail.Columns.ColumnByName("colDiscountedAmount").Caption = "Discounted";
            gvDetail.Columns.ColumnByName("colTotalAmount").Caption = "Total Amount";


            gvDetail.Columns.ColumnByName("colProductId").OptionsColumn.AllowEdit = false;

            gvDetail.Columns.ColumnByName("colAmount").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colAmount").OptionsColumn.AllowFocus = false;

            gvDetail.Columns.ColumnByName("colDiscountedAmount").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colDiscountedAmount").OptionsColumn.AllowFocus = false;

           

            gvDetail.Columns.ColumnByName("colTotalAmount").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colTotalAmount").OptionsColumn.AllowFocus = false;

            gvDetail.Columns.ColumnByName("colOrderQty").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colOrderQty").OptionsColumn.AllowFocus = false;

            gvDetail.Columns.ColumnByName("colBalanceQty").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colBalanceQty").OptionsColumn.AllowFocus = false;

            gvDetail.Columns.ColumnByName("colTotalReceived").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colTotalReceived").OptionsColumn.AllowFocus = false;



            gvDetail.Columns.ColumnByName("colProductId").VisibleIndex = 0;
            gvDetail.Columns.ColumnByName("colOrderQty").VisibleIndex = 1;
            gvDetail.Columns.ColumnByName("colTotalReceived").VisibleIndex = 2;
            gvDetail.Columns.ColumnByName("colReceivedQty").VisibleIndex = 3;
            gvDetail.Columns.ColumnByName("colBalanceQty").VisibleIndex = 4;
            gvDetail.Columns.ColumnByName("colPrice").VisibleIndex = 5;
            gvDetail.Columns.ColumnByName("colAmount").VisibleIndex = 6;
            gvDetail.Columns.ColumnByName("colDiscountPercent").VisibleIndex = 7;
            gvDetail.Columns.ColumnByName("colDiscountAmount").VisibleIndex = 8;
            gvDetail.Columns.ColumnByName("colDiscountedAmount").VisibleIndex = 9;
            gvDetail.Columns.ColumnByName("colGSTPercent").VisibleIndex = 10;
            gvDetail.Columns.ColumnByName("colGSTAmount").VisibleIndex = 11;
            gvDetail.Columns.ColumnByName("colTotalAmount").VisibleIndex = 12;


            gvDetail.Columns.ColumnByName("colProductId").Width = 300;
            gvDetail.Columns.ColumnByName("colOrderQty").Width = 80;
            gvDetail.Columns.ColumnByName("colReceivedQty").Width = 80;
            gvDetail.Columns.ColumnByName("colTotalReceived").Width = 80;
            gvDetail.Columns.ColumnByName("colBalanceQty").Width = 80;
            gvDetail.Columns.ColumnByName("colPrice").Width = 50;
            gvDetail.Columns.ColumnByName("colAmount").Width = 80;
            gvDetail.Columns.ColumnByName("colDiscountPercent").Width = 50;
            gvDetail.Columns.ColumnByName("colGSTPercent").Width = 50;
            gvDetail.Columns.ColumnByName("colGSTAmount").Width = 80;
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
            txtDiscountPercent.Enabled = true;
            txtDiscount.Enabled = true;
        }

        private void FillDropDown()
        {
            WarehouseManager manageWarehouse = new WarehouseManager();
            DataTable dtWarehouse = new DataTable();
            dtWarehouse = manageWarehouse.GetWarehouseList();
            DataRow drWarehouse = dtWarehouse.NewRow();
            drWarehouse["WarehouseId"] = -1;
            drWarehouse["Warehouse"] = "---Select Warehouse---";
            dtWarehouse.Rows.InsertAt(drWarehouse, 0);
            cmbWarehouse.DataSource = dtWarehouse;
            cmbWarehouse.DisplayMember = "Warehouse";
            cmbWarehouse.ValueMember = "WarehouseId";
        }

        private void ClearFeilds()
        {
            txtReceivingPO.Text = string.Empty;
            txtPONo.Text = string.Empty;
            dtpDate.Value = DateTime.Now;
            dtpOrderDate.Value = DateTime.Now;
            txtVendorCode.Text = string.Empty;
            txtVendorName.Text = string.Empty;
            txtEmployeeCode.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtTotalAmount.Text = "0";
            txtDiscount.Text = "0";
            txtDiscountPercent.Text = "0";
            txtTDutyAmount.Text = "0";
            txtNetTotal.Text = "0";

            PurchaseOrderId = -1;
            RecevingPOId = -1;
            cmbWarehouse.SelectedValue = -1;
            chkWholeQty.Checked = false;

            DeletedIds = new List<int>();

            if (dset != null)
            {
                dset.Tables["POrderDetail"].Rows.Clear();
                dset.Tables["POrderMaster"].Rows.Clear();

                dset.RejectChanges();
                drMaster = dset.Tables["POrderMaster"].NewRow();
                dset.Tables["POrderMaster"].Rows.Add(drMaster);

                GCDetail.DataSource = dset.Tables["POrderDetail"];
                GridSetting();
            }
            


           
            GCDetail.Enabled = false;
            txtDiscountPercent.Enabled = false;
            txtDiscount.Enabled = false;
            ButtonRights(true);
            txtReceivingPO.Text = GetNewNextNumber();
            txtPONo.Focus();
            btnNextInvioceNo.Enabled = false;
            btnPrevInvioceNo.Enabled = false;
        }
        private void LoadPOrder(int POMasterId)
        {
            try
            {
                setGridSetup(true, POMasterId);

                if (dset.Tables["POrderMaster"].Rows.Count > 0)
                {
                    txtVendorCode.Text = drMaster["VendorCode"].ToString();
                    //txtEmployeeCode.Text = drMaster["EmployeeCode"].ToString();
                    //dtpDate.Value = Convert.ToDateTime(drMaster["OrderDate"]);
                    dtpOrderDate.Value = Convert.ToDateTime(drMaster["OrderDate"]);
                    //txtRemarks.Text = drMaster["Remarks"].ToString();
                    //txtTotalAmount.Text = drMaster["TAmount"].ToString();
                    //txtDiscountPercent.Text = drMaster["TDiscountPerc"].ToString();
                    //txtDiscount.Text = drMaster["TDiscount"].ToString();
                    //txtNetTotal.Text = Math.Round(decimal.Parse(drMaster["NetAmount"].ToString()), 0).ToString();
                    //ButtonRights(false);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecevingPO()
        {
            try
            {
                setGridSetup(false, RecevingPOId);

                if (dset.Tables["POrderMaster"].Rows.Count > 0)
                {
                    txtVendorCode.Text = drMaster["VendorCode"].ToString();
                    txtEmployeeCode.Text = drMaster["EmployeeCode"].ToString();
                    dtpDate.Value = Convert.ToDateTime(drMaster["RPODate"]);
                    dtpOrderDate.Value = Convert.ToDateTime(drMaster["OrderDate"]);
                    txtPONo.Text = drMaster["POrderNo"].ToString();
                    txtRemarks.Text = drMaster["Remarks"].ToString();
                    txtTotalAmount.Text = drMaster["TAmount"].ToString();
                    txtDiscountPercent.Text = drMaster["TDiscountPerc"].ToString();
                    txtDiscount.Text = drMaster["TDiscount"].ToString();
                    txtTDutyAmount.Text = drMaster["TDutyAmount"].ToString();
                    txtNetTotal.Text = Math.Round(decimal.Parse(drMaster["NetAmount"].ToString()), 0).ToString();
                    cmbWarehouse.SelectedValue = Convert.ToInt32(dset.Tables["POrderDetail"].Rows[0]["WarehouseId"]);
                    ButtonRights(false);
                    //for Navigation Works*******
                    try
                    {
                        string FirstTransNo = managePurchaseOrder.GetMinRPONo();
                        string LastTransNo = managePurchaseOrder.GetMaxRPONo();
                        if (LastTransNo == txtReceivingPO.Text)
                        {
                            btnNextInvioceNo.Enabled = false;
                        }
                        else
                        {
                            btnNextInvioceNo.Enabled = true;
                        }
                        if (FirstTransNo == txtReceivingPO.Text)
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

        private void txtReceivingPO_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtReceivingPO.Text))
            {
                RecevingPOId = managePurchaseOrder.GetRecivingPOIdByCode(txtReceivingPO.Text);
                if (RecevingPOId > 0)
                {
                    IsRecevingPOLoading = true;
                    LoadRecevingPO();
                    IsRecevingPOLoading = false;
                }
            }
        }

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
                        if (string.IsNullOrEmpty(dr["ReceivedQty"].ToString()))
                        {
                            dr["ReceivedQty"] = 1;
                        }

                        dr["Amount"] = Math.Round((decimal.Parse(dr["Price"].ToString()) * decimal.Parse(dr["ReceivedQty"].ToString())), 2);
                        dr["DiscountAmount"] = Math.Round((decimal.Parse(dr["Amount"].ToString()) * decimal.Parse(dr["DiscountPercent"].ToString()) / 100), 2);
                        dr["DiscountedAmount"] = Math.Round((decimal.Parse(dr["Amount"].ToString()) - decimal.Parse(dr["DiscountAmount"].ToString())), 2);
                        if (string.IsNullOrEmpty(dr["GSTPercent"].ToString()))
                        {
                            dr["GSTPercent"] = "0";
                            dr["GSTAmount"] = "0";
                        }
                        //dr["GSTAmount"] = "0.00"; // Math.Round(((decimal.Parse(dr["DiscountedAmount"].ToString()) * decimal.Parse(dr["GSTPercent"].ToString()) / 100)), 2);
                        //dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()), 2);
                        dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()) , 2);

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


                        //dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()) , 2);
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

                                dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()) , 2);
                            }
                        }
                        dr["DiscountedAmount"] = Math.Round(decimal.Parse(dr["Amount"].ToString()) - decimal.Parse(dr["DiscountAmount"].ToString()), 2);

                        dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()) , 2);
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
                                dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) , 2);
                            }
                        }

                        dr["DiscountAmount"] = Math.Round(decimal.Parse(dr["Amount"].ToString()) * decimal.Parse(dr["DiscountPercent"].ToString()) / 100, 2);
                        dr["DiscountedAmount"] = Math.Round(decimal.Parse(dr["Amount"].ToString()) - decimal.Parse(dr["DiscountAmount"].ToString()), 2);

                        dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()) , 2);
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

        private void txtDiscountPercent_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTDutyAmount.Text))
            {
                txtTDutyAmount.Text = "0";
            }
            if (!string.IsNullOrEmpty(txtDiscountPercent.Text))
            {
                if (decimal.Parse(txtDiscountPercent.Text) > 100)
                {
                    txtDiscount.Text = "0";
                    txtDiscountPercent.Text = "0";
                    txtNetTotal.Text = Math.Round(decimal.Parse(txtTotalAmount.Text) + decimal.Parse(txtTDutyAmount.Text), 0).ToString(); //+ decimal.Parse(tbxFreightCharges.Text);
                    txtDiscountPercent.Focus();
                    //MessageBox.Show(Messages.Percentage, Messages.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    txtDiscountPercent.Text = Math.Round(decimal.Parse(txtDiscountPercent.Text), 2).ToString();
                    txtDiscount.Text = Math.Round(((decimal.Parse(txtTotalAmount.Text) * decimal.Parse(txtDiscountPercent.Text)) / 100), 0).ToString();
                    txtNetTotal.Text = Math.Round((decimal.Parse(txtTotalAmount.Text) + decimal.Parse(txtTDutyAmount.Text) - decimal.Parse(txtDiscount.Text)), 0).ToString();
                }
            }
            else
            {
                txtDiscountPercent.Text = "0";
                txtDiscountPercent.Text = Math.Round(decimal.Parse(txtDiscountPercent.Text), 2).ToString();
                txtDiscount.Text = Math.Round(((decimal.Parse(txtTotalAmount.Text) * decimal.Parse(txtDiscountPercent.Text)) / 100), 0).ToString();
                txtNetTotal.Text = Math.Round((decimal.Parse(txtTotalAmount.Text) + decimal.Parse(txtTDutyAmount.Text) - decimal.Parse(txtDiscount.Text)), 0).ToString();

            }
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTDutyAmount.Text))
            {
                txtTDutyAmount.Text = "0";
            }
            if (!string.IsNullOrEmpty(txtDiscount.Text))
            {
                if (decimal.Parse(txtDiscount.Text) > decimal.Parse(txtTotalAmount.Text))
                {
                    txtDiscount.Text = "0";
                    txtDiscountPercent.Text = "0";
                    txtNetTotal.Text = Math.Round(decimal.Parse(txtTotalAmount.Text) + decimal.Parse(txtTDutyAmount.Text), 0).ToString(); ;
                    txtDiscount.Focus();
                    //MessageBox.Show(Messages.DiscountGreaterThanAmount, Messages.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (decimal.Parse(txtTotalAmount.Text) > 0)
                    {
                        txtDiscount.Text = Math.Round(decimal.Parse(txtDiscount.Text), 0).ToString();
                        txtDiscountPercent.Text = Math.Round(((decimal.Parse(txtDiscount.Text) / decimal.Parse(txtTotalAmount.Text)) * 100), 2).ToString();
                        txtNetTotal.Text = Math.Round((decimal.Parse(txtTotalAmount.Text) + decimal.Parse(txtTDutyAmount.Text) - decimal.Parse(txtDiscount.Text)), 0).ToString();
                    }
                }
            }
        }

        private void gvDetail_RowCountChanged(object sender, EventArgs e)
        {
            CalculateSummary();
            txtDiscountPercent_Leave(null, null);
            txtTDutyAmount_Leave(null, null);
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
                gvDetail.GetDataRow(e.RowHandle)["RPOId"] = drMaster["RPOId"]; //SalesMasterId;
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
            if (string.IsNullOrEmpty(txtPONo.Text))
            {
                MessageBox.Show("Please Select Purchase Order Number.", "PO Code is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPONo.Focus();
                result = false;
                return result;
            }

            if (Convert.ToInt32(cmbWarehouse.SelectedValue) < 0)
            {
                MessageBox.Show("Please Select Warehouse Name.", "Warehouse is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbWarehouse.Focus();
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
            if (dset.Tables["POrderDetail"].Rows.Count <= 0)
            {
                MessageBox.Show("Please Enter Detail of Purchase Order.", "Detail is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                return result;
            }

            bool IsReceiveQtyValid = false;
            foreach (DataRow dr in dset.Tables["POrderDetail"].Rows)
            {
                if (!string.IsNullOrEmpty(dr["ReceivedQty"].ToString()))
                {
                    if (Convert.ToDecimal(dr["ReceivedQty"]) > 0)
                    {
                        IsReceiveQtyValid = true;
                        break;
                    }
                }
            }

            if (!IsReceiveQtyValid)
            {
                MessageBox.Show("Receive Quantity does not Found in any Detail.", "Enter Recevie Qty Detail.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                return result;
            }


            if (managePurchaseOrder.IsRPOPurchaseInvoiceCreated(txtReceivingPO.Text))
            {
                MessageBox.Show("Purchase Invoice alredy created against " + txtReceivingPO.Text + " Receving PO Number.", "Invoice Alredy Created.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                return result;
            }
           

            //if (dtpDate.Value.Date < MainForm.FicalYearStart.Date || dtpDate.Value.Date > MainForm.FicalYearEnd.Date)
            //{
            //    MessageBox.Show("Invalid Date Selection. Selected Date is Out of Rang of Fical Year", "Invalid Date Selection.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    result = false;
            //}

            return result;

        }

        private void DeleteReceivingPO()
        {
            if (string.IsNullOrEmpty(txtReceivingPO.Text))
            {
                return;
            }
            try
            {
                ProductManager PM = new ProductManager();
                dataAcess.BeginTransaction();
                if (dataAcess.getDBCommand().Transaction == null)
                {
                    dataAcess.SetDBTransaction();
                }
                PM.DeleteProductLedgerByTransNo(txtReceivingPO.Text, dataAcess);
                int status = managePurchaseOrder.DeleteRecivingPOMaster(managePurchaseOrder.GetRecivingPOIdByCode(txtReceivingPO.Text), dataAcess);
                dataAcess.TransCommit();
                if (status > 0)
                {
                    MessageBox.Show("Receving PO " + txtPONo.Text + " is Deleted.", "Receving Delete Successful.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    int RPOrderId = -1;
                    bool IsPOCompleted = true;
                    foreach (DataRow drDetail in dset.Tables["POrderDetail"].Rows)
                    {
                        if (drDetail.RowState != DataRowState.Deleted)
                        {
                            if (Convert.ToInt32(drDetail["BalanceQty"]) > 0)
                            {
                                IsPOCompleted = false;
                                break;
                            }
                        }
                    }
                    //for (int i = 0; i < dset.Tables["POrderDetail"].Rows.Count; i++)
                    //{
                    //    DataRow drDetail = 
                    //}
                    ProductManager PM = new ProductManager();
                    VendorManager VendorM = new VendorManager();
                    dataAcess.BeginTransaction();
                    if (dataAcess.getDBCommand().Transaction == null)
                    {
                        dataAcess.SetDBTransaction();
                    }
                    //int VendorId = VendorM.GetVendorIdByCode(txtVendorCode.Text);
                    RPOrderId = managePurchaseOrder.InsertRecivingPOMaster(txtPONo.Text, Convert.ToDateTime(dtpDate.Value.ToString()), Convert.ToDateTime(dtpOrderDate.Value), "H", txtVendorCode.Text, "", txtEmployeeCode.Text, -1, -1, 0, decimal.Parse(txtTotalAmount.Text), decimal.Parse(txtDiscountPercent.Text), decimal.Parse(txtDiscount.Text), (string.IsNullOrEmpty(txtTDutyAmount.Text) ? 0 : decimal.Parse(txtTDutyAmount.Text)) ,  false, txtRemarks.Text, "", MainForm.User_Id, DateTime.Now, "", dataAcess);
                    if (RPOrderId > 0)
                    {
                        for (int i = 0; i < dset.Tables["POrderDetail"].Rows.Count; i++)
                        {
                            int DetailId = managePurchaseOrder.InsertUpdateRecivingPODetail(Convert.ToInt32(dset.Tables["POrderDetail"].Rows[i]["RPODetailId"]), RPOrderId, Convert.ToInt32(dset.Tables["POrderDetail"].Rows[i]["POrderDetailId"]), Convert.ToInt32(dset.Tables["POrderDetail"].Rows[i]["ProductId"]), "Stock", Convert.ToInt32(cmbWarehouse.SelectedValue), Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["OrderQty"]), Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["TotalReceived"]), Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["ReceivedQty"]), Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["Price"]), Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["DiscountPercent"]), Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["DiscountAmount"]), Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["GSTPercent"]), Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["GSTAmount"]), MainForm.User_Id, DateTime.Now, "", dataAcess);
                            if (Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["ReceivedQty"]) > 0)
                            {
                                //agr koi received qty greater then zero hogi toh yeh ledger mai jye ga.
                                PM.InsertUpdateProductLedger(Convert.ToInt32(dset.Tables["POrderDetail"].Rows[i]["ProductId"]), Convert.ToDateTime(dtpDate.Value), txtReceivingPO.Text, DetailId, "I", Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["ReceivedQty"]), Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["Price"]), Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["DiscountPercent"]), Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["DiscountAmount"]), Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["GSTPercent"]), Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["GSTAmount"]), MainForm.User_Id, DateTime.Now.Date, "", "", null, Convert.ToInt32(cmbWarehouse.SelectedValue), -1, dataAcess);
                            }
                            
                        }
                    }
                    if (IsPOCompleted)
                    {
                        managePurchaseOrder.UpdatePOrderMasterClosedMarked(managePurchaseOrder.GetPurchaseOrderMasterIdByCode(txtPONo.Text), dataAcess);
                    }
                    dataAcess.TransCommit();
                    if (MessageBox.Show("Receiving Purchase Order " + txtReceivingPO.Text + " has Saved." + Environment.NewLine + " Do you want to Print. ", "Receving Saved Successful.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
                search.getattributes("GetRecevingPOSearch", null, "Receiving PO");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtReceivingPO.Text = MainForm.Searched_Id;
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
                Smartworks.ColumnField[] gPO = new Smartworks.ColumnField[1];
                gPO[0] = new Smartworks.ColumnField("@IsClose", 0);
                search.getattributes("GetSearchPurchaseOrders", gPO, "Purchase Orders");
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
                    bool IsPOCompleted = true;
                    foreach (DataRow drDetail in dset.Tables["POrderDetail"].Rows)
                    {
                        if (drDetail.RowState != DataRowState.Deleted)
                        {
                            if (Convert.ToInt32(drDetail["BalanceQty"]) > 0)
                            {
                                IsPOCompleted = false;
                                break;
                            }
                        }
                    }
                    dataAcess.BeginTransaction();
                    if (dataAcess.getDBCommand().Transaction == null)
                    {
                        dataAcess.SetDBTransaction();
                    }
                    int VendorId = VendorM.GetVendorIdByCode(txtVendorCode.Text);
                    foreach (int id in DeletedIds)
                    {
                        PM.DeleteProductFromLedgerByTransNoAndDetailIdForPurchase(txtReceivingPO.Text, id, dataAcess);
                        managePurchaseOrder.DeletePOrderDetailByDetailId(id, dataAcess);
                        //yahan Ledger se bhi remove kerna hai.
                    }
                    managePurchaseOrder.UpdateRecivingPOMaster(RecevingPOId, txtPONo.Text, Convert.ToDateTime(dtpDate.Value), Convert.ToDateTime(dtpOrderDate.Value), "H", txtVendorCode.Text, "", txtEmployeeCode.Text, -1, -1, 0, decimal.Parse(txtTotalAmount.Text), decimal.Parse(txtDiscountPercent.Text), decimal.Parse(txtDiscount.Text), (string.IsNullOrEmpty(txtTDutyAmount.Text) ? 0 : decimal.Parse(txtTDutyAmount.Text)) ,false, txtRemarks.Text, "", MainForm.User_Id, DateTime.Now, "", dataAcess);
                    for (int i = 0; i < dset.Tables["POrderDetail"].Rows.Count; i++)
                    {
                        if (dset.Tables["POrderDetail"].Rows[i].RowState != DataRowState.Deleted)
                        {
                            DataRow drDetail = dset.Tables["POrderDetail"].Rows[i];
                            int DetailId = managePurchaseOrder.InsertUpdateRecivingPODetail(Convert.ToInt32(drDetail["RPODetailId"]), RecevingPOId, Convert.ToInt32(drDetail["POrderDetailId"]), Convert.ToInt32(drDetail["ProductId"]), "Stock", Convert.ToInt32(cmbWarehouse.SelectedValue), Convert.ToDecimal(drDetail["OrderQty"]), Convert.ToDecimal(drDetail["TotalReceived"]), Convert.ToDecimal(drDetail["ReceivedQty"]), Convert.ToDecimal(drDetail["Price"]), Convert.ToDecimal(drDetail["DiscountPercent"]), Convert.ToDecimal(drDetail["DiscountAmount"]), Convert.ToDecimal(drDetail["GSTPercent"]), Convert.ToDecimal(drDetail["GSTAmount"]), MainForm.User_Id, DateTime.Now.Date, "", dataAcess);
                            if (Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["ReceivedQty"]) > 0)
                            {
                                PM.InsertUpdateProductLedger(Convert.ToInt32(dset.Tables["POrderDetail"].Rows[i]["ProductId"]), Convert.ToDateTime(dtpDate.Value), txtReceivingPO.Text, DetailId, "I", Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["ReceivedQty"]), Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["Price"]), Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["DiscountPercent"]), Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["DiscountAmount"]), Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["GSTPercent"]), Convert.ToDecimal(dset.Tables["POrderDetail"].Rows[i]["GSTAmount"]), MainForm.User_Id, DateTime.Now.Date, "", "", null, Convert.ToInt32(cmbWarehouse.SelectedValue), -1, dataAcess);
                            }
                        }
                    }
                    if (IsPOCompleted)
                    {
                        managePurchaseOrder.UpdatePOrderMasterClosedMarked(managePurchaseOrder.GetPurchaseOrderMasterIdByCode(txtPONo.Text), dataAcess);
                    }
                    dataAcess.TransCommit();
                    if (MessageBox.Show("Receiving Purchase Order " + txtReceivingPO.Text + " has Saved." + Environment.NewLine + " Do you want to Print. ", "Receiving Order Saved Successful.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
                        DeleteReceivingPO();
                        break;
                    }

            }
        }

        private void btnMinInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(managePurchaseOrder.GetMinRPONo()))
            {
                txtReceivingPO.Text = managePurchaseOrder.GetMinRPONo();
                //btnNextInvioceNo.Enabled = true;
                //btnPrevInvioceNo.Enabled = false;
            }
            

        }

        private void btnPrevInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtReceivingPO.Text))
            {
                string LastInvioceNo = managePurchaseOrder.GetMinRPONo();
                if (LastInvioceNo != txtReceivingPO.Text.Trim())
                {
                    txtReceivingPO.Text = managePurchaseOrder.GetPrevRPNo(txtReceivingPO.Text);
                    if (LastInvioceNo == txtReceivingPO.Text)
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
            if (!string.IsNullOrEmpty(txtReceivingPO.Text))
            {
                string LastInvioceNo = managePurchaseOrder.GetMaxRPONo();
                if (LastInvioceNo != txtReceivingPO.Text.Trim())
                {
                    txtReceivingPO.Text = managePurchaseOrder.GetNextRPONo(txtReceivingPO.Text);
                    if (LastInvioceNo == txtReceivingPO.Text)
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
            if (!string.IsNullOrEmpty(managePurchaseOrder.GetMaxRPONo()))
            {
                txtReceivingPO.Text = managePurchaseOrder.GetMaxRPONo();
                if (!string.IsNullOrEmpty(txtReceivingPO.Text))
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
                if (RecevingPOId < 0)
                {
                    return;
                }
                if (string.IsNullOrEmpty(txtReceivingPO.Text))
                {
                    return;
                }

                string path = Application.StartupPath + "/rpt/Purchaserpt/rptRecevingPurchaseOrder.rpt";
                ReportDocument document = new ReportDocument();
                document.Load(path);
                DataTable dtReport = new DataTable();
                dtReport = managePurchaseOrder.GetReceivingPurchaseOrderReport(null, null, "", "", "", "", RecevingPOId);
                document.SetDataSource(dtReport);
                Utility.SetReportDefaultParameter(ref document);

                if (IsDirectPrint)
                {
                    document.PrintToPrinter(1, true, 0, 0);
                }
                else
                {
                    frmReportReceivingPurchaseOrder report = new frmReportReceivingPurchaseOrder(document);
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
            if (IsRecevingPOLoading)
            {
                return;
            }
            if (!string.IsNullOrEmpty(txtPONo.Text))
            {
                PurchaseOrderId = managePurchaseOrder.GetPendingPurchaseOrderMasterIdByCode(txtPONo.Text);
                if (PurchaseOrderId > 0)
                {
                    LoadPOrder(PurchaseOrderId);
                }
            }
            else
            {
                txtPONo.Text = string.Empty;
                //ClearFeilds();
            }
        }

        private void chkWholeQty_CheckedChanged(object sender, EventArgs e)
        {
            if (dset.Tables["POrderDetail"].Rows.Count > 0)
            {
                if (chkWholeQty.Checked)
                {
                    foreach (DataRow dr in dset.Tables["POrderDetail"].Rows)
                    {
                        if (Convert.ToInt32(dr["BalanceQty"]) > 0)
                        {

                            dr["ReceivedQty"] = dr["BalanceQty"];

                            dr["BalanceQty"] = (string.IsNullOrEmpty(dr["OrderQty"].ToString()) ? 0 : Convert.ToDecimal(dr["OrderQty"])) - ((string.IsNullOrEmpty(dr["ReceivedQty"].ToString()) ? 0 : Convert.ToDecimal(dr["ReceivedQty"])) + (string.IsNullOrEmpty(dr["TotalReceived"].ToString()) ? 0 : Convert.ToDecimal(dr["TotalReceived"])));

                            dr["Amount"] = Math.Round((decimal.Parse(dr["Price"].ToString()) * decimal.Parse(dr["ReceivedQty"].ToString())), 2);

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
                        }
                    }
                    CalculateSummary();
                }
                else
                {
                    foreach (DataRow dr in dset.Tables["POrderDetail"].Rows)
                    {
                        dr["ReceivedQty"] = "0";
                        //dr["ReceivedQty"] = dr["BalanceQty"];

                        dr["BalanceQty"] = (string.IsNullOrEmpty(dr["OrderQty"].ToString()) ? 0 : Convert.ToDecimal(dr["OrderQty"])) - ((string.IsNullOrEmpty(dr["ReceivedQty"].ToString()) ? 0 : Convert.ToDecimal(dr["ReceivedQty"])) + (string.IsNullOrEmpty(dr["TotalReceived"].ToString()) ? 0 : Convert.ToDecimal(dr["TotalReceived"])));

                        dr["Amount"] = Math.Round((decimal.Parse(dr["Price"].ToString()) * decimal.Parse(dr["ReceivedQty"].ToString())), 2);

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
                    }
                    CalculateSummary();
                }
            }
            else
            {
                chkWholeQty.Checked = false;
            }
        }

        private void txtDiscountPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.setOnlyNumberic((TextBox)sender, true, e);

        }

        private void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTDutyAmount_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTDutyAmount.Text))
            {
                txtTDutyAmount.Text = "0";
            }
            txtDiscountPercent_Leave(null, null);
        }

        private void gvDetail_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    decimal OrderQty = Convert.ToDecimal(View.GetRowCellValue(e.RowHandle, View.Columns["OrderQty"]));
                    decimal TotalReceived = Convert.ToDecimal(View.GetRowCellValue(e.RowHandle, View.Columns["TotalReceived"])); 
                    decimal ReceivedQty = Convert.ToDecimal(View.GetRowCellValue(e.RowHandle, View.Columns["ReceivedQty"]));
                    if (RecevingPOId <= 0)
                    {
                        //yani koi new entry ki bat ker raha hai.
                        if (TotalReceived > 0)
                        {
                            //yani kuch na kuch recived hua hai 
                            if (TotalReceived >= OrderQty) //full received
                            {
                                e.Appearance.BackColor = Color.FromArgb(150, Color.LightGreen);
                                e.Appearance.BackColor2 = Color.White;

                            }
                            else if (TotalReceived < OrderQty) //partial received
                            {
                                e.Appearance.BackColor = Color.FromArgb(150, Color.Orange);
                                e.Appearance.BackColor2 = Color.White;
                            }
                        }
                    }
                    else
                    {
                        //Existing Record ki bat ho rahi hai
                        if (ReceivedQty >= OrderQty) //full received
                        {
                            e.Appearance.BackColor = Color.FromArgb(150, Color.LightGreen);
                            e.Appearance.BackColor2 = Color.White;

                        }
                        else if (ReceivedQty < OrderQty) //partial received
                        {
                            e.Appearance.BackColor = Color.FromArgb(150, Color.Orange);
                            e.Appearance.BackColor2 = Color.White;
                        }
                    }
                    //int DetailId = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, View.Columns["PDId"])); //View.GetRowCellDisplayText(e.RowHandle, View.Columns["PMDId"]);
                    //if (DetailId > 0)
                    //{
                    //    e.Appearance.BackColor = Color.FromArgb(150, Color.LightGreen); //Color.LightCoral
                    //    e.Appearance.BackColor2 = Color.White;
                    //}
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void GCDetail_Click_1(object sender, EventArgs e)
        {

        }


    }
}
