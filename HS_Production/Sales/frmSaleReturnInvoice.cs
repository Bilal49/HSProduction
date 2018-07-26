using CrystalDecisions.CrystalReports.Engine;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using FIL.App_Code.SaleMasterManager;
using FIL.App_Code.SalesManager;
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
    public partial class frmSaleReturnInvoice : Form
    {
        Smartworks.DAL dataAcess = new Smartworks.DAL();
        SalesManager SalesManager = new SalesManager();
        AccountManager manageAccount = new AccountManager();
        SalesReturnManager manageSalesReturn = new SalesReturnManager();
        //PackingListManager managePackingList = new PackingListManager();
        ProductManager manageProduct = new ProductManager();
        DataSet dset;
        RepositoryItemGridLookUpEdit repositoryGridLookup = new RepositoryItemGridLookUpEdit();
        RepositoryItemGridLookUpEdit repositoryGrade = new RepositoryItemGridLookUpEdit();
        private delegate void OnloadFunctions();
        BindingSource bsProducts = new BindingSource();
        BindingSource bsGrade = new BindingSource();
        DataRow drMaster;
        DataView dvProducts;
        DataViewManager dvm;
        int SalesReturnMasterId = -1;
        List<int> DeletedIds = new List<int>();
        bool IsSalesReturnLoad = false;
        public frmSaleReturnInvoice()
        {
            InitializeComponent();
        }

        private void frmDirectSales_Load(object sender, EventArgs e)
        {
            ButtonRights(true);
            FillDropDown();
            txtReturnInvoiceNo.Text = GetNewNextNumber();
            btnNextInvioceNo.Enabled = false;
            btnPrevInvioceNo.Enabled = false;

        }

        #region All Methods

        private String GetNewNextNumber()
        {
            string NewInvoiceNo = "";
            NewInvoiceNo = manageSalesReturn.GetMaxSaleReturnInvioceNo(MainForm.FYear);
            if (!string.IsNullOrEmpty(NewInvoiceNo))
            {
                NewInvoiceNo = SalesManager.GetNextSaleInvioceNo(NewInvoiceNo);
            }
            else
            {
                NewInvoiceNo = "SR-000001";
            }
            return NewInvoiceNo;
        }
        private void ButtonRights(bool Enable)
        {
            btnAdd.Enabled = Enable;
            btnUpdate.Enabled = !Enable;
            btnDelete.Enabled = !Enable;
            btnPrint.Enabled = !Enable;
            txtReturnInvoiceNo.ReadOnly = !Enable;
            txtSInvoiceNo.Enabled = Enable;
            btnSISeach.Enabled = Enable;
            //btnCSearch.Enabled = Enable;
            txtCustomerCode.Enabled = Enable;
            btnPost.Enabled = !Enable;
        }

        private void FillDropDown()
        {
            WarehouseManager managewarehouse = new WarehouseManager();
            DataTable dtFWarehouse = new DataTable();
            dtFWarehouse = managewarehouse.GetWarehouseList();

            DataRow drFwarehouse = dtFWarehouse.NewRow();
            drFwarehouse["WarehouseId"] = -1;
            drFwarehouse["Warehouse"] = "--Select Department--";
            dtFWarehouse.Rows.InsertAt(drFwarehouse, 0);

            cmbWarehouse.DataSource = dtFWarehouse;
            cmbWarehouse.DisplayMember = "Warehouse";
            cmbWarehouse.ValueMember = "WarehouseId";
        }

        private void PostControl(bool Posted)
        {
            btnAdd.Enabled = !Posted;
            btnUpdate.Enabled = !Posted;
            btnDelete.Enabled = !Posted;
            btnPost.Enabled = !Posted;
            txtSInvoiceNo.ReadOnly = !Posted;
            btnSearch.Enabled = !Posted;
            btnSISeach.Enabled = !Posted;
            txtCustomerCode.Enabled = !Posted;
            btnPost.Enabled = !Posted;
            lblPosted.Visible = Posted;
            GCDetail.Enabled = !Posted;

        }

        private void setGridSetup(bool IsSalesInvoiceLoaded, int TranId)
        {
            dset = new DataSet();

            if (IsSalesInvoiceLoaded)
            {
                //agr Sales Retrun Invoice Load hoga yani koi new entry ker raha hu ya phr koi SR load ker raha hu toh yeh wala structure aye ga .
                //dono k structure same rakhy hain. lakin data ka farq hai 

                dset = manageSalesReturn.GetSalesReturnStructureBySalesInvoiceId(TranId);
            }
            else
            {
                //age koi Sales dekh raha hu ya Edit mode per hu ya koi cheez Update kerni hai toh yeh wala structure load hoga. 
                //dono k structure same rakhy hain. lakin data ka farq hai 

                dset = manageSalesReturn.GetSalesReturnStructure(TranId);
            }


            //dset = SalesManager.GetSalesStructure();
            dset.Tables[0].TableName = "SalesReturnMaster";
            dset.Tables[1].TableName = "SalesReturnDetail";
            dset.Tables[2].TableName = "Product";
            dset.Tables[3].TableName = "Grade";


            dset.Tables["SalesReturnMaster"].Columns["SalesReturnMasterId"].AutoIncrement = true;
            dset.Tables["SalesReturnMaster"].Columns["SalesReturnMasterId"].AutoIncrementSeed = -1;
            dset.Tables["SalesReturnMaster"].Columns["SalesReturnMasterId"].AutoIncrementStep = -1;

            dset.Tables["SalesReturnDetail"].Columns["SalesReturnDetailId"].AutoIncrement = true;
            dset.Tables["SalesReturnDetail"].Columns["SalesReturnDetailId"].AutoIncrementSeed = -1;
            dset.Tables["SalesReturnDetail"].Columns["SalesReturnDetailId"].AutoIncrementStep = -1;


            dset.Relations.Add("MasterRelation", dset.Tables["SalesReturnMaster"].Columns["SalesReturnMasterId"], dset.Tables["SalesReturnDetail"].Columns["SalesReturnMasterId"]);

            if (dset.Tables["SalesReturnMaster"].Rows.Count > 0)
            {
                drMaster = dset.Tables["SalesReturnMaster"].Rows[0];
            }
            else
            {
                drMaster = dset.Tables["SalesReturnMaster"].NewRow();
                dset.Tables["SalesReturnMaster"].Rows.Add(drMaster);
            }

            dvm = new DataViewManager(dset);
            dvProducts = dvm.CreateDataView(dset.Tables["Product"]);


            GCDetail.DataSource = dset.Tables["SalesReturnDetail"];
            GCDetail.Enabled = true;
            GridSetting();
            CalculateTotalQty();



        }

        private void GridSetting()
        {
            //gvDetail.Columns.ColumnByName["colTotalAmount"].OptionsColumn.ReadOnly = True
            gvDetail.Columns.ColumnByName("colSalesReturnDetailId").OptionsColumn.ReadOnly = true;
            gvDetail.Columns.ColumnByName("colSalesReturnMasterId").OptionsColumn.ReadOnly = true;

            gvDetail.Columns.ColumnByName("colSalesReturnDetailId").Visible = false;
            gvDetail.Columns.ColumnByName("colSalesReturnMasterId").Visible = false;
            //gvDetail.Columns.ColumnByName("colUnitId").Visible = false;
            //gvDetail.Columns.ColumnByName("colBarcode").Visible = false;
            gvDetail.Columns.ColumnByName("colStockType").Visible = false;
            gvDetail.Columns.ColumnByName("colBatchNo").Visible = false;
            //gvDetail.Columns.ColumnByName("colExpiryDate").Visible = false;
            gvDetail.Columns.ColumnByName("colWarehouseId").Visible = false;
            gvDetail.Columns.ColumnByName("colGSTPercent").Visible = false;
            gvDetail.Columns.ColumnByName("colGSTAmount").Visible = false;
            gvDetail.Columns.ColumnByName("colAddedBy").Visible = false;
            gvDetail.Columns.ColumnByName("colAddedOn").Visible = false;
            gvDetail.Columns.ColumnByName("colAddedIpAddr").Visible = false;
            gvDetail.Columns.ColumnByName("colUpdatedBy").Visible = false;
            gvDetail.Columns.ColumnByName("colUpdatedOn").Visible = false;
            gvDetail.Columns.ColumnByName("colUpdatedIpAddr").Visible = false;
            gvDetail.Columns.ColumnByName("colProductCategoryId").Visible = false;
            gvDetail.Columns.ColumnByName("colCategoryName").Visible = false;
            gvDetail.Columns.ColumnByName("colSalesDetailId").Visible = false;




            gvDetail.Columns.ColumnByName("colProductId").Caption = "Product Name";
            gvDetail.Columns.ColumnByName("colQuantity").Caption = "Quantity";
            gvDetail.Columns.ColumnByName("colPendingQty").Caption = "Valid Qty";
            gvDetail.Columns.ColumnByName("colPrice").Caption = "Price";
            gvDetail.Columns.ColumnByName("colAmount").Caption = "Amount";
            gvDetail.Columns.ColumnByName("colAmount").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colAmount").OptionsColumn.AllowFocus = false;

            gvDetail.Columns.ColumnByName("colPendingQty").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colPendingQty").OptionsColumn.AllowFocus = false;

            gvDetail.Columns.ColumnByName("colDiscountPercent").Caption = "Disc %";
            gvDetail.Columns.ColumnByName("colDiscountAmount").Caption = "Disc Amount";
            gvDetail.Columns.ColumnByName("colDiscountedAmount").Caption = "Discounted";
            gvDetail.Columns.ColumnByName("colTotalAmount").Caption = "Total Amount";
            gvDetail.Columns.ColumnByName("colPrice").Caption = "Retail Price";
            gvDetail.Columns.ColumnByName("colGrade").Caption = "Grade";


            gvDetail.Columns.ColumnByName("colProductId").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colProductId").OptionsColumn.AllowFocus = false;

            gvDetail.Columns.ColumnByName("colQuantity").OptionsColumn.AllowEdit = true;
            gvDetail.Columns.ColumnByName("colQuantity").OptionsColumn.AllowFocus = true;



            gvDetail.Columns.ColumnByName("colDiscountedAmount").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colDiscountedAmount").OptionsColumn.AllowFocus = false;

            gvDetail.Columns.ColumnByName("colTotalAmount").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colTotalAmount").OptionsColumn.AllowFocus = false;





            gvDetail.Columns.ColumnByName("colProductId").VisibleIndex = 0;
            gvDetail.Columns.ColumnByName("colQuantity").VisibleIndex = 1;
            gvDetail.Columns.ColumnByName("colPendingQty").VisibleIndex = 2;
            gvDetail.Columns.ColumnByName("colPrice").VisibleIndex = 3;
            gvDetail.Columns.ColumnByName("colAmount").VisibleIndex = 4;
            gvDetail.Columns.ColumnByName("colDiscountPercent").VisibleIndex = 5;
            gvDetail.Columns.ColumnByName("colDiscountAmount").VisibleIndex = 6;
            gvDetail.Columns.ColumnByName("colDiscountedAmount").VisibleIndex = 7;
            gvDetail.Columns.ColumnByName("colTotalAmount").VisibleIndex = 8;
            gvDetail.Columns.ColumnByName("colGrade").VisibleIndex = 9;



            gvDetail.Columns.ColumnByName("colProductId").Width = 300;
            gvDetail.Columns.ColumnByName("colQuantity").Width = 50;
            gvDetail.Columns.ColumnByName("colPrice").Width = 50;
            gvDetail.Columns.ColumnByName("colAmount").Width = 100;
            gvDetail.Columns.ColumnByName("colDiscountPercent").Width = 80;
            gvDetail.Columns.ColumnByName("colDiscountAmount").Width = 80;
            gvDetail.Columns.ColumnByName("colDiscountedAmount").Width = 80;
            gvDetail.Columns.ColumnByName("colTotalAmount").Width = 120;
            gvDetail.Columns.ColumnByName("colPendingQty").Width = 80;
            gvDetail.Columns.ColumnByName("colGrade").Width = 80;



            bsProducts.DataSource = dset;
            bsProducts.DataMember = "Product";

            bsGrade.DataSource = dset;
            bsGrade.DataMember = "Grade";

            repositoryGridLookup.DataSource = bsProducts;
            repositoryGridLookup.DisplayMember = "ProductName";
            repositoryGridLookup.ValueMember = "ProductId";
            repositoryGridLookup.PopupFormMinSize = new Size(450, 150);
            repositoryGridLookup.NullText = "";
            repositoryGridLookup.ShowFooter = true;
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
                repositoryGridLookup.View.Columns.ColumnByName("colRetailPrice").Caption = "Retail Price";
                repositoryGridLookup.View.Columns.ColumnByName("colQtyInhand").Caption = "QtyInHand";
                repositoryGridLookup.View.Columns.ColumnByName("colCategoryName").Caption = "Category Name";


                repositoryGridLookup.View.Columns.ColumnByName("colProductName").Width = 150;
                repositoryGridLookup.View.Columns.ColumnByName("colProductCode").Width = 80;
                repositoryGridLookup.View.Columns.ColumnByName("colRetailPrice").Width = 70;
                repositoryGridLookup.View.Columns.ColumnByName("colQtyInhand").Width = 40;
                repositoryGridLookup.View.Columns.ColumnByName("colCategoryName").Width = 100;


                repositoryGridLookup.View.Columns.ColumnByName("colProductCode").VisibleIndex = 0;
                repositoryGridLookup.View.Columns.ColumnByName("colProductName").VisibleIndex = 1;
                repositoryGridLookup.View.Columns.ColumnByName("colRetailPrice").VisibleIndex = 2;
                repositoryGridLookup.View.Columns.ColumnByName("colQtyInhand").VisibleIndex = 3;
                repositoryGridLookup.View.Columns.ColumnByName("colCategoryName").VisibleIndex = 4;

            }

            //Grade

            repositoryGrade.DataSource = bsGrade;
            repositoryGrade.DisplayMember = "Grade";
            repositoryGrade.ValueMember = "Grade";
            repositoryGrade.PopupFormMinSize = new Size(20, 20);
            repositoryGrade.NullText = "";
            repositoryGrade.ShowFooter = true;
            repositoryGrade.View.OptionsView.ColumnAutoWidth = false;
            repositoryGrade.ImmediatePopup = true;
            repositoryGrade.PopulateViewColumns();
            GCDetail.RepositoryItems.Add(repositoryGrade);

            (GCDetail.MainView as GridView).Columns.ColumnByName("colGrade").ColumnEdit = repositoryGrade;

            if (repositoryGrade.View.Columns.Count > 0)
            {

                repositoryGrade.View.Columns.ColumnByName("colGradeId").Visible = false;

                repositoryGrade.View.Columns.ColumnByName("colGrade").Caption = "Grade";

                repositoryGrade.View.Columns.ColumnByName("colGrade").Width = 100;

                repositoryGrade.View.Columns.ColumnByName("colGrade").VisibleIndex = 0;
            }



            gvDetail.Columns.ColumnByName("colProductId").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
        }

        private void ClearFeilds()
        {
            txtReturnInvoiceNo.Text = string.Empty;
            txtSInvoiceNo.Text = string.Empty;
            dtp.Value = DateTime.Now;
            dtpInvoice.Value = DateTime.Now;
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtVoucherNo.Text = string.Empty;
            txtCustomerAccCode.Text = string.Empty;
            txtCustomerAccName.Text = string.Empty;
            txtEmployeeCode.Text = string.Empty;
            cmbWarehouse.SelectedIndex = 0;
            //txtCBalance.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtTotalAmount.Text = "0";
            txtDiscount.Text = "0";
            txtDiscountPercent.Text = "0";
            txtGSTPerc.Text = "0";
            txtGSTAmount.Text = "0";
            txtNetTotal.Text = "0";
            SalesReturnMasterId = -1;
            txtTotalQty.Text = "0";
            DeletedIds = new List<int>();
            PostControl(false);
            txtReturnInvoiceNo.Text = GetNewNextNumber();
            //setGridSetup();
            if (dset != null)
            {
                dset.Tables["SalesReturnDetail"].Rows.Clear();
                dset.Tables["SalesReturnMaster"].Rows.Clear();

                dset.RejectChanges();

                drMaster = dset.Tables["SalesReturnMaster"].NewRow();
                dset.Tables["SalesReturnMaster"].Rows.Add(drMaster);
                GCDetail.DataSource = dset.Tables["SalesReturnDetail"];
                GCDetail.Enabled = false;
                GridSetting();
            }

            //dset.AcceptChanges();


            ButtonRights(true);
            btnNextInvioceNo.Enabled = false;
            btnPrevInvioceNo.Enabled = false;
        }


        private void LoadInvoice()
        {
            try
            {
                setGridSetup(false, SalesReturnMasterId);

                if (dset.Tables["SalesReturnMaster"].Rows.Count > 0)
                {
                    IsSalesReturnLoad = true;
                    txtSInvoiceNo.Text = drMaster["SalesInvoiceNo"].ToString();
                    txtCustomerCode.Text = drMaster["CustomerCode"].ToString();
                    dtp.Value = Convert.ToDateTime(drMaster["Date"]);
                    cmbWarehouse.SelectedValue = drMaster["WarehouseId"].ToString();
                    txtEmployeeCode.Text = drMaster["ReceivedBy"].ToString();
                    txtRemarks.Text = drMaster["Remarks"].ToString();
                    txtVoucherNo.Text = drMaster["VoucherNo"].ToString();
                    txtTotalAmount.Text = drMaster["TAmount"].ToString();
                    txtDiscountPercent.Text = drMaster["TDiscountPerc"].ToString();
                    txtDiscount.Text = drMaster["TDiscount"].ToString();
                    txtGSTPerc.Text = drMaster["GSTPercent"].ToString();
                    txtGSTAmount.Text = drMaster["GSTAmount"].ToString();
                    txtNetTotal.Text = Math.Round(decimal.Parse(drMaster["NetAmount"].ToString()), 2).ToString();
                    IsSalesReturnLoad = false;
                    ButtonRights(false);
                    bool Posted = Convert.ToBoolean(drMaster["Posted"].ToString());
                    if (Posted)
                    {
                        PostControl(Posted);
                    }

                    //for Navigation Works*******
                    try
                    {
                        string FirstTransNo = manageSalesReturn.GetMinSaleReturnInvioceNo(MainForm.FYear);
                        string LastTransNo = manageSalesReturn.GetMaxSaleReturnInvioceNo(MainForm.FYear);
                        if (LastTransNo == txtReturnInvoiceNo.Text)
                        {
                            btnNextInvioceNo.Enabled = false;
                        }
                        else
                        {
                            btnNextInvioceNo.Enabled = true;
                        }
                        if (FirstTransNo == txtReturnInvoiceNo.Text)
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
                IsSalesReturnLoad = false;
                MessageBox.Show(ex.Message, "Error!!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CalculateTotalQty()
        {
            decimal Qty = 0;
            try
            {
                foreach (DataRow dr in dset.Tables["SalesReturnDetail"].Rows)
                {
                    if (dr.RowState != DataRowState.Deleted)
                    {
                        Qty = Qty + (string.IsNullOrEmpty(dr["Quantity"].ToString()) ? 0 : Convert.ToDecimal(dr["Quantity"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                Qty = 0;
            }
            txtTotalQty.Text = Math.Round(Qty, 0).ToString();

            //
        }
        #endregion
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
                        dr["WarehouseId"] = -1;
                        dr["StockType"] = "Stock";
                        if (dr["StockType"].ToString() == "Stock")
                        {
                            dr["Price"] = dvProducts[0]["RetailPrice"];
                            dr["DiscountPercent"] = dvProducts[0]["DiscountPerc"];
                        }
                        else
                        {
                            dr["Price"] = 0;
                            dr["DiscountPercent"] = 0;
                        }
                        dr["UnitId"] = -1; //dvProducts[0]["UnitId"];
                        //dvStockType.RowFilter = "ProductId='" + dr["ProductId"].ToString() + "'";
                        //AddStockTypes()
                        //AddWarehouses()
                        //dvWarehouse.RowFilter = "WarehouseId='" + dr("WarehouseId").ToString() + "'"
                        // dr["Warehouse"] = -1; //dvWarehouse(0)("Warehouse")
                        //dvProdBatchBalance.RowFilter = "ProductId='" + dr("ProductId").ToString() + "' AND WarehouseId='" + dr("WarehouseId").ToString() + "' AND StockType='" + dr("StockType").ToString() + "'"
                        //AddBatchNumbers()
                        //If dvProdBatchBalance.Count > 0 Then
                        //    dr("BatchNo") = dvProdBatchBalance(0)("BatchNo")
                        //    dvProdBatchBalance.RowFilter = "ProductId='" + dr("ProductId").ToString() + "' AND WarehouseId='" + dr("WarehouseId").ToString() + "' AND StockType='" + dr("StockType").ToString() + "' AND BatchNo='" + dr("BatchNo").ToString() + "'"
                        //    dr("BatchBalance") = dvProdBatchBalance(0)("BatchBalance")
                        //End If
                        //'CalculateGST(dr)

                        //If dr("DiscountPercent") IsNot DBNull.Value Then
                        //    If Decimal.Parse(dr("DiscountPercent")) > 0 Then
                        //        dr("DiscountAmount") = Decimal.Parse(FormatNumber(dr("Amount") * dr("DiscountPercent") / 100, 2))
                        //        dr("DiscountedAmount") = Decimal.Parse(FormatNumber(dr("Amount") - dr("DiscountAmount"), 2))
                        //        'CalculateGST(dr)
                        //        dr("TotalAmount") = dr("DiscountedAmount") + dr("GSTAmount")
                        //    End If
                        //End If
                        //Math.Round(decimal.Parse(dr["DiscountAmount"].ToString()), 2);
                        if (string.IsNullOrEmpty(dr["Quantity"].ToString()))
                        {
                            dr["Quantity"] = 1;
                        }

                        dr["Amount"] = Math.Round((decimal.Parse(dr["Price"].ToString()) * decimal.Parse(dr["Quantity"].ToString())), 2);
                        dr["DiscountAmount"] = Math.Round((decimal.Parse(dr["Amount"].ToString()) * decimal.Parse(dr["DiscountPercent"].ToString()) / 100), 2);
                        dr["DiscountedAmount"] = Math.Round((decimal.Parse(dr["Amount"].ToString()) - decimal.Parse(dr["DiscountAmount"].ToString())), 2);
                        dr["GSTAmount"] = "0.00"; // Math.Round(((decimal.Parse(dr["DiscountedAmount"].ToString()) * decimal.Parse(dr["GSTPercent"].ToString()) / 100)), 2);
                        dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()), 2);

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
                        dr["DiscountPercent"] = (decimal.Parse(dr["DiscountAmount"].ToString()) / decimal.Parse(dr["Amount"].ToString())) * 100; //decimal.Parse((decimal.Parse(dr["DiscountAmount"].ToString()) / decimal.Parse(dr["Amount"].ToString())) * 100);
                        dr["DiscountedAmount"] = Math.Round(decimal.Parse(dr["Amount"].ToString()) - decimal.Parse(dr["DiscountAmount"].ToString()), 2);

                        dr["GSTAmount"] = "0.00";//Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) * decimal.Parse(dr["GSTPercent"].ToString()) / 100, 2);
                        dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()));
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
                        dr["GSTAmount"] = "0.00"; //Math.Round((decimal.Parse(dr["DiscountedAmount"].ToString()) * decimal.Parse(dr["GSTPercent"].ToString())) / 100, 2);
                        dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()), 2);
                        break;
                    case "colQuantity":
                        if (string.IsNullOrEmpty(dr["Quantity"].ToString()))
                        {
                            dr["Quantity"] = 1;  //Default Quantity is 1;
                        }
                        if (decimal.Parse(dr["Quantity"].ToString()) < 0)
                        {
                            dr["Quantity"] = 1;  //Qty Should be greater then zero;
                        }

                        if (Convert.ToInt32(dr["Quantity"]) > (string.IsNullOrEmpty(dr["PendingQty"].ToString()) ? 0 : Convert.ToInt32(dr["PendingQty"])))
                        {
                            //agr Valid return Qty se ziyda return kry ga toh wapis valid Qty tk ajye ga.
                            dr["Quantity"] = (string.IsNullOrEmpty(dr["PendingQty"].ToString()) ? 0 : Convert.ToInt32(dr["PendingQty"]));
                        }
                        dr["Amount"] = Math.Round((decimal.Parse(dr["Price"].ToString()) * decimal.Parse(dr["Quantity"].ToString())), 2);

                        if (dr["DiscountPercent"] != null)
                        {
                            if (decimal.Parse(dr["DiscountPercent"].ToString()) > 0)
                            {
                                dr["DiscountAmount"] = Math.Round((decimal.Parse(dr["Amount"].ToString()) * decimal.Parse(dr["DiscountPercent"].ToString())) / 100, 2);
                                dr["DiscountedAmount"] = Math.Round(decimal.Parse(dr["Amount"].ToString()) - decimal.Parse(dr["DiscountAmount"].ToString()), 2);
                                dr["TotalAmount"] = decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString());
                            }
                        }
                        dr["DiscountedAmount"] = Math.Round(decimal.Parse(dr["Amount"].ToString()) - decimal.Parse(dr["DiscountAmount"].ToString()), 2);
                        dr["GSTAmount"] = "0.00";//Math.Round((decimal.Parse(dr["DiscountedAmount"].ToString()) * decimal.Parse(dr["GSTPercent"].ToString())) / 100, 2);
                        dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()), 2);
                        break;
                    case "colPrice":
                        if (string.IsNullOrEmpty(dr["Price"].ToString()))
                        {
                            dr["Price"] = dvProducts[0]["RetailPrice"];
                        }
                        if (decimal.Parse(dr["Price"].ToString()) < 0)
                        {
                            dr["Price"] = dvProducts[0]["RetailPrice"];
                        }
                        dr["Amount"] = Math.Round(decimal.Parse(dr["Price"].ToString()) * decimal.Parse(dr["Quantity"].ToString()), 2);

                        if (dr["DiscountPercent"] != null)
                        {
                            if (decimal.Parse(dr["DiscountPercent"].ToString()) > 0)
                            {
                                dr["DiscountAmount"] = Math.Round(decimal.Parse(dr["Amount"].ToString()) * decimal.Parse(dr["DiscountPercent"].ToString()) / 100, 2);
                                dr["DiscountedAmount"] = Math.Round(decimal.Parse(dr["Amount"].ToString()) - decimal.Parse(dr["DiscountAmount"].ToString()), 2);
                                dr["TotalAmount"] = Math.Round(decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString()), 2);
                            }
                        }

                        dr["DiscountAmount"] = Math.Round(decimal.Parse(dr["Amount"].ToString()) * decimal.Parse(dr["DiscountPercent"].ToString()) / 100, 2);
                        dr["DiscountedAmount"] = Math.Round(decimal.Parse(dr["Amount"].ToString()) - decimal.Parse(dr["DiscountAmount"].ToString()), 2);
                        dr["GSTAmount"] = "0.00";//Math.Round((decimal.Parse(dr["DiscountedAmount"].ToString()) * decimal.Parse(dr["GSTPercent"].ToString())) / 100, 2);
                        dr["TotalAmount"] = Math.Round((decimal.Parse(dr["DiscountedAmount"].ToString()) + decimal.Parse(dr["GSTAmount"].ToString())), 2);
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
                foreach (DataRow dr in dset.Tables["SalesReturnDetail"].Rows)
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
            //if (!string.IsNullOrEmpty(txtDiscountPercent.Text))
            //{
            //    if (decimal.Parse(txtDiscountPercent.Text) > 100)
            //    {
            //        txtDiscount.Text = "0";
            //        txtDiscountPercent.Text = "0";
            //        txtNetTotal.Text = Math.Round(decimal.Parse(txtTotalAmount.Text), 0).ToString(); //+ decimal.Parse(tbxFreightCharges.Text);
            //        txtDiscountPercent.Focus();
            //        //MessageBox.Show(Messages.Percentage, Messages.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    else
            //    {
            //        txtDiscountPercent.Text = Math.Round(decimal.Parse(txtDiscountPercent.Text), 2).ToString();
            //        txtDiscount.Text = Math.Round(((decimal.Parse(txtTotalAmount.Text) * decimal.Parse(txtDiscountPercent.Text)) / 100), 0).ToString();
            //        txtNetTotal.Text = Math.Round((decimal.Parse(txtTotalAmount.Text) - decimal.Parse(txtDiscount.Text)), 0).ToString();
            //    }
            //}
            //else
            //{
            //    txtDiscountPercent.Text = "0";
            //    txtDiscountPercent.Text = Math.Round(decimal.Parse(txtDiscountPercent.Text), 2).ToString();
            //    txtDiscount.Text = Math.Round(((decimal.Parse(txtTotalAmount.Text) * decimal.Parse(txtDiscountPercent.Text)) / 100), 0).ToString();
            //    txtNetTotal.Text = Math.Round((decimal.Parse(txtTotalAmount.Text) - decimal.Parse(txtDiscount.Text)), 0).ToString();

            //}

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
            //if (!string.IsNullOrEmpty(txtDiscount.Text))
            //{
            //    if (decimal.Parse(txtDiscount.Text) > decimal.Parse(txtTotalAmount.Text))
            //    {
            //        txtDiscount.Text = "0";
            //        txtDiscountPercent.Text = "0";
            //        txtNetTotal.Text = Math.Round(decimal.Parse(txtTotalAmount.Text), 0).ToString(); ;
            //        txtDiscount.Focus();
            //        //MessageBox.Show(Messages.DiscountGreaterThanAmount, Messages.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    else
            //    {
            //        if (decimal.Parse(txtTotalAmount.Text) > 0)
            //        {
            //            txtDiscount.Text = Math.Round(decimal.Parse(txtDiscount.Text), 0).ToString();
            //            txtDiscountPercent.Text = Math.Round(((decimal.Parse(txtDiscount.Text) / decimal.Parse(txtTotalAmount.Text)) * 100), 2).ToString();
            //            txtNetTotal.Text = Math.Round((decimal.Parse(txtTotalAmount.Text) - decimal.Parse(txtDiscount.Text)), 0).ToString();
            //        }
            //    }
            //}

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
                if (!string.IsNullOrEmpty(dr["ProductId"].ToString()))
                {
                    dvProducts.RowFilter = "ProductId='" + dr["ProductId"].ToString() + "'";
                }
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
                e.ErrorText = "Item Alredy Exits."; //Messages.ItemAlreadyPresentinList;
            }
            //else if (Quantity == "Less than one")
            //{
            //    e.ErrorText = Messages.QtyGreaterThanZero;
            //}
            //else if (Quantity == "Greater than batch balance")
            //{
            //    e.ErrorText = Messages.QtyGreaterThanBatchBalance;
            //}

            MessageBox.Show(e.ErrorText, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //gvDetail.FocusedColumn = gvDetail.Columns.ColumnByName("colQuantity");
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
                    break; // TODO: might not be correct. Was : Exit Select

                    break;
                case "colDiscountPercent":
                    e.ErrorText = "error"; //Messages.Percentage;
                    //MessageBox.Show(Messages.Percentage + Strings.Chr(13) + Messages.PreviousValue, Messages.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break; // TODO: might not be correct. Was : Exit Select

                    break;
                case "colGSTAmount":
                    e.ErrorText = "error"; //Messages.DiscountGreaterThanAmount;
                    MessageBox.Show(e.ErrorText, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break; // TODO: might not be correct. Was : Exit Select

                    break;
                case "colGSTPercent":
                    e.ErrorText = "error"; //Messages.Percentage;

                    break; // TODO: might not be correct. Was : Exit Select

                    break;
                case "colQuantity":
                    gvDetail.FocusedColumn = gvDetail.Columns.ColumnByName("colQuantity");


                    break;




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
            if (decimal.Parse(dr["Quantity"].ToString()) <= 0)
            {
                //Quantity = "Less than one";
                e.Valid = false;
            }

            if (dr.RowState == DataRowState.Detached)
            {
                if (dset.Tables["SalesReturnDetail"].Select("ProductId =" + dr["ProductId"].ToString()).Length > 0)
                {
                    MessageBox.Show("Item Already Exists", "Same Items can not be repeated.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Valid = false;
                }
            }
            else
            {
                e.Valid = true;
                gvDetail.GetDataRow(e.RowHandle)["SalesReturnMasterId"] = drMaster["SalesReturnMasterId"]; //SalesMasterId;
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
                            case "colQuantity":
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
            if (string.IsNullOrEmpty(txtSInvoiceNo.Text))
            {
                MessageBox.Show("Sale Invoice Number not Found.", "Sales Invoice No. is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSInvoiceNo.Focus();
                result = false;
                return result;

            }
            if (cmbWarehouse.SelectedIndex <= 0)
            {
                MessageBox.Show("Please Select Warehouse Name.", "Warehouse Name is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbWarehouse.Focus();
                result = false;
                return result;
            }

            if (string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                MessageBox.Show("Please Select Customer Code", "Customer Code is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerCode.Focus();
                result = false;
                return result;

            }

            if (string.IsNullOrEmpty(txtCustomerAccName.Text))
            {
                MessageBox.Show("Customer COA does not found.", "Customer COA is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerCode.Focus();
                result = false;
                return result;

            }

            if (dset.Tables["SalesReturnDetail"].Rows.Count <= 0)
            {
                MessageBox.Show("Please Enter Detail of Sales Return.", "Return Detail is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                return result;
            }

            if (dtp.Value.Date < MainForm.FicalYearStart.Date || dtp.Value.Date > MainForm.FicalYearEnd.Date)
            {
                MessageBox.Show("Invalid Date Selection. Selected Date is Out of Rang of Fical Year", "Invalid Date Selection.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
            }

            return result;

        }

        private void DeleteSales()
        {
            if (string.IsNullOrEmpty(txtReturnInvoiceNo.Text))
            {
                return;
            }
            try
            {

                //dataAcess.BeginTransaction();
                //managePackingList.UpdatePackingListUnClosed(managePackingList.GetPackingListMasterIdByCode(txtSInvoiceNo.Text), dataAcess);
                //SalesManager.DeleteSalesByInvoiceNo(txtReturnInvoiceNo.Text, dataAcess);
                //dataAcess.TransCommit();
                //MessageBox.Show("Sales Invoice " + txtReturnInvoiceNo.Text + " is Deleted.", "Invoice Delete Successful.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //ClearFeilds();
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
                    DataTable dtSaleRetrunMaster;
                    dataAcess.BeginTransaction();
                    if (dataAcess.getDBCommand().Transaction == null)
                    {
                        dataAcess.SetDBTransaction();
                    }
                    dtSaleRetrunMaster = manageSalesReturn.InsertSalesReturnMaster(txtSInvoiceNo.Text, Convert.ToDateTime(dtp.Value.ToString()), "H", Convert.ToInt32(cmbWarehouse.SelectedValue), txtCustomerCode.Text,
                        txtEmployeeCode.Text, txtEmployeeCode.Text, decimal.Parse(txtTotalAmount.Text), decimal.Parse(txtDiscountPercent.Text), decimal.Parse(txtDiscount.Text), 0, decimal.Parse(txtGSTPerc.Text), decimal.Parse(txtGSTAmount.Text), txtRemarks.Text, "", false, MainForm.User_Id, DateTime.Now, "", dataAcess);
                    if (dtSaleRetrunMaster.Rows.Count > 0)
                    {
                        SalesReturnMasterId = Convert.ToInt32(dtSaleRetrunMaster.Rows[0]["Id"]);
                    }
                    else
                    {
                        throw new Exception("Sales Return Refrence not found");
                    }
                    for (int i = 0; i < dset.Tables["SalesReturnDetail"].Rows.Count; i++)
                    {
                        if (dset.Tables["SalesReturnDetail"].Rows[i].RowState != DataRowState.Deleted)
                        {
                            int DetailId = manageSalesReturn.InsertUpdateSalesReturnDetail(Convert.ToInt32(dset.Tables["SalesReturnDetail"].Rows[i]["SalesReturnDetailId"]),
                                Convert.ToInt32(dtSaleRetrunMaster.Rows[0]["Id"]),
                               Convert.ToInt32(dset.Tables["SalesReturnDetail"].Rows[i]["SalesDetailId"]),
                                Convert.ToInt32(dset.Tables["SalesReturnDetail"].Rows[i]["ProductId"]), "Stock", "-1", -1,
                                Convert.ToDecimal(dset.Tables["SalesReturnDetail"].Rows[i]["Quantity"]),
                                Convert.ToDecimal(dset.Tables["SalesReturnDetail"].Rows[i]["Price"]),
                                Convert.ToDecimal(dset.Tables["SalesReturnDetail"].Rows[i]["DiscountPercent"]),
                                Convert.ToDecimal(dset.Tables["SalesReturnDetail"].Rows[i]["DiscountAmount"]),
                                Convert.ToDecimal(dset.Tables["SalesReturnDetail"].Rows[i]["GSTPercent"]),
                                Convert.ToDecimal(dset.Tables["SalesReturnDetail"].Rows[i]["GSTAmount"]),
                                 MainForm.User_Id, DateTime.Now.Date, "", dset.Tables["SalesReturnDetail"].Rows[i]["Grade"].ToString(),
                                dataAcess);

                            //Insert Product Ledger too..
                            manageProduct.InsertUpdateProductLedger(Convert.ToInt32(dset.Tables["SalesReturnDetail"].Rows[i]["ProductId"]), Convert.ToDateTime(dtp.Value), txtReturnInvoiceNo.Text, DetailId, "I",
                                   Convert.ToDecimal(dset.Tables["SalesReturnDetail"].Rows[i]["Quantity"]), Convert.ToDecimal(dset.Tables["SalesReturnDetail"].Rows[i]["Price"]),
                                   Convert.ToDecimal(dset.Tables["SalesReturnDetail"].Rows[i]["DiscountPercent"]), Convert.ToDecimal(dset.Tables["SalesReturnDetail"].Rows[i]["DiscountAmount"]),
                                   Convert.ToDecimal(dset.Tables["SalesReturnDetail"].Rows[i]["GSTPercent"]), Convert.ToDecimal(dset.Tables["SalesReturnDetail"].Rows[i]["GSTAmount"]),
                                   MainForm.User_Id, DateTime.Now.Date, "", "", null, Convert.ToInt32(cmbWarehouse.SelectedValue), -1, dataAcess);
                        }
                    }


                    dataAcess.TransCommit();

                    txtReturnInvoiceNo.Text = dtSaleRetrunMaster.Rows[0]["InvoiceNo"].ToString();
                    if (MessageBox.Show("Sales Return Invoice " + dtSaleRetrunMaster.Rows[0]["InvoiceNo"].ToString() + " has Saved." + Environment.NewLine + " Do you want to Print. ", "Invoice Saved Successful.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        PrintInvoice(false);
                    }
                    ClearFeilds();
                    //ButtonRights(false);
                    //LoadInvoice();
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
        }

        private void btnCSearch_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearch search = new frmSearch();
                search.getattributes("GetCustomerSearch", null, "Customer");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    DataTable dtCustomer = dataAcess.getDataTable("SELECT  * FROM dbo.Customer WHERE Code = '" + MainForm.Searched_Id + "' ");
                    txtCustomerCode.Text = dtCustomer.Rows[0]["Code"].ToString();
                    txtCustomerName.Text = dtCustomer.Rows[0]["CustomerName"].ToString();
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
                search.getattributes("GetSalesReturnInvoiceSearch", null, "Invoices");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtReturnInvoiceNo.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                    //LoadInvoice();
                    string FirstInvioceNo = manageSalesReturn.GetMaxSaleReturnInvioceNo(MainForm.FYear);
                    string LastInvioceNo = manageSalesReturn.GetMinSaleReturnInvioceNo(MainForm.FYear);
                    if (LastInvioceNo == txtReturnInvoiceNo.Text)
                    {
                        btnPrevInvioceNo.Enabled = false;
                    }
                    else
                    {
                        btnPrevInvioceNo.Enabled = true;
                    }
                    if (FirstInvioceNo == txtReturnInvoiceNo.Text)
                    {
                        btnNextInvioceNo.Enabled = false;
                    }
                    else
                    {
                        btnNextInvioceNo.Enabled = true;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCustomerCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                DataTable dtCustomer = dataAcess.getDataTable("SELECT * , dbo.GetCustomerBalance(Code  ,GetDate() ) as PreviousBalance   FROM dbo.Customer WHERE Code = '" + txtCustomerCode.Text + "' ");
                txtCustomerName.Text = dtCustomer.Rows[0]["CustomerName"].ToString();
                //txtCBalance.Text = dtCustomer.Rows[0]["PreviousBalance"].ToString();

                if (!string.IsNullOrEmpty(dtCustomer.Rows[0]["COAId"].ToString()))
                {
                    txtCustomerAccCode.Text = manageAccount.GetChartOfAccounts(Convert.ToInt32(dtCustomer.Rows[0]["COAId"])).Rows[0]["AccountCode"].ToString();
                }
            }
            else
            {
                txtCustomerName.Text = string.Empty;

                //txtCBalance.Text = string.Empty;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validations())
            {
                try
                {
                    //DataTable dtSaleReturnMaster;
                    dataAcess.BeginTransaction();
                    //int CustomerId = CM.GetCustomerIdByCode(txtCustomerCode.Text);
                    foreach (int id in DeletedIds)
                    {
                        manageProduct.DeleteProductFromLedgerByTransNoAndDetailId(txtReturnInvoiceNo.Text, id, dataAcess);
                        manageSalesReturn.DeleteSalesReturnDetail(id, dataAcess);

                    }
                    SalesReturnMasterId = manageSalesReturn.UpdateSalesReturnMaster(SalesReturnMasterId, txtSInvoiceNo.Text, Convert.ToDateTime(dtp.Value.ToString()), "H", Convert.ToInt32(cmbWarehouse.SelectedValue), txtCustomerCode.Text, txtEmployeeCode.Text, txtEmployeeCode.Text, decimal.Parse(txtTotalAmount.Text), decimal.Parse(txtDiscountPercent.Text),
                        decimal.Parse(txtDiscount.Text), decimal.Parse("0"), decimal.Parse(txtGSTPerc.Text), decimal.Parse(txtGSTAmount.Text), txtRemarks.Text, "", false, MainForm.User_Id, DateTime.Now, "", dataAcess);

                    for (int i = 0; i < dset.Tables["SalesReturnDetail"].Rows.Count; i++)
                    {
                        if (dset.Tables["SalesReturnDetail"].Rows[i].RowState != DataRowState.Deleted)
                        {
                            int DetailId = manageSalesReturn.InsertUpdateSalesReturnDetail(Convert.ToInt32(dset.Tables["SalesReturnDetail"].Rows[0]["SalesReturnDetailId"]),
                            Convert.ToInt32(SalesReturnMasterId),
                            Convert.ToInt32(dset.Tables["SalesReturnDetail"].Rows[i]["SalesDetailId"]),
                            Convert.ToInt32(dset.Tables["SalesReturnDetail"].Rows[i]["ProductId"]), "Stock", "-1", -1,
                            Convert.ToDecimal(dset.Tables["SalesReturnDetail"].Rows[i]["Quantity"]),
                            Convert.ToDecimal(dset.Tables["SalesReturnDetail"].Rows[i]["Price"]),
                            Convert.ToDecimal(dset.Tables["SalesReturnDetail"].Rows[i]["DiscountPercent"]),
                            Convert.ToDecimal(dset.Tables["SalesReturnDetail"].Rows[i]["DiscountAmount"]),
                            Convert.ToDecimal(dset.Tables["SalesReturnDetail"].Rows[i]["GSTPercent"]),
                            Convert.ToDecimal(dset.Tables["SalesReturnDetail"].Rows[i]["GSTAmount"]),
                             MainForm.User_Id, DateTime.Now.Date, "", dset.Tables["SalesReturnDetail"].Rows[i]["Grade"].ToString() ,
                            dataAcess);


                            //Update Product Ledger too..
                            manageProduct.InsertUpdateProductLedger(Convert.ToInt32(dset.Tables["SalesReturnDetail"].Rows[i]["ProductId"]), Convert.ToDateTime(dtp.Value), txtReturnInvoiceNo.Text, DetailId, "I",
                                Convert.ToDecimal(dset.Tables["SalesReturnDetail"].Rows[i]["Quantity"]), Convert.ToDecimal(dset.Tables["SalesReturnDetail"].Rows[i]["Price"]),
                                Convert.ToDecimal(dset.Tables["SalesReturnDetail"].Rows[i]["DiscountPercent"]), Convert.ToDecimal(dset.Tables["SalesReturnDetail"].Rows[i]["DiscountAmount"]),
                                Convert.ToDecimal(dset.Tables["SalesReturnDetail"].Rows[i]["GSTPercent"]), Convert.ToDecimal(dset.Tables["SalesReturnDetail"].Rows[i]["GSTAmount"]),
                                MainForm.User_Id, DateTime.Now.Date, "", "", null, Convert.ToInt32(cmbWarehouse.SelectedValue), -1, dataAcess);
                        }
                    }
                    //managePackingList.UpdatePackingListClosed(managePackingList.GetPackingListMasterIdByCode(txtSInvoiceNo.Text), dataAcess);
                    dataAcess.TransCommit();
                    //txtReturnInvoiceNo.Text = dtSaleMaster.Rows[0]["SalesInvoiceNo"].ToString();
                    if (MessageBox.Show("Sales Return Invoice " + txtReturnInvoiceNo.Text + " has Saved." + Environment.NewLine + " Do you want to Print. ", "Invoice Saved Successful.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        PrintInvoice(false);
                    }
                    ButtonRights(false);
                    //LoadInvoice();
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
        }

        private void gvDetail_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            try
            {
                DataRow dr = default(DataRow);
                dr = gvDetail.GetDataRow(e.RowHandle);
                if (Convert.ToInt32(dr["SalesReturnDetailId"].ToString()) > 0)
                {
                    DeletedIds.Add(Convert.ToInt32(dr["SalesReturnDetailId"].ToString()));
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Invoice Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeleteSales();
                        break;
                    }
            }
        }

        private void btnMinInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(manageSalesReturn.GetMinSaleReturnInvioceNo(MainForm.FYear)))
            {
                txtReturnInvoiceNo.Text = manageSalesReturn.GetMinSaleReturnInvioceNo(MainForm.FYear);
                if (!string.IsNullOrEmpty(txtReturnInvoiceNo.Text))
                {
                    //LoadInvoice();
                    //btnNextInvioceNo.Enabled = true;
                    //btnPrevInvioceNo.Enabled = false;
                }
            }
            

        }

        private void btnPrevInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtReturnInvoiceNo.Text))
            {
                string LastInvioceNo = manageSalesReturn.GetMinSaleReturnInvioceNo(MainForm.FYear);
                txtReturnInvoiceNo.Text = manageSalesReturn.GetPrevSaleReturnInvioceNo(txtReturnInvoiceNo.Text);
                //LoadInvoice();
                if (LastInvioceNo == txtReturnInvoiceNo.Text)
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
            if (!string.IsNullOrEmpty(txtReturnInvoiceNo.Text))
            {

                string LastInvioceNo = manageSalesReturn.GetMaxSaleReturnInvioceNo(MainForm.FYear);
                txtReturnInvoiceNo.Text = manageSalesReturn.GetNextSaleReturnInvioceNo(txtReturnInvoiceNo.Text);
                //LoadInvoice();
                if (LastInvioceNo == txtReturnInvoiceNo.Text)
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
            if (!string.IsNullOrEmpty(manageSalesReturn.GetMaxSaleReturnInvioceNo(MainForm.FYear)))
            {
                txtReturnInvoiceNo.Text = manageSalesReturn.GetMaxSaleReturnInvioceNo(MainForm.FYear);
                if (!string.IsNullOrEmpty(txtReturnInvoiceNo.Text))
                {
                    //LoadInvoice();
                    //btnNextInvioceNo.Enabled = false;
                    //btnPrevInvioceNo.Enabled = true;
                }
            }
            

        }

        private void frmDirectSales_KeyDown(object sender, KeyEventArgs e)
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

        private void btnPrint_Click(object sender, EventArgs e)
        {

            PrintInvoice(false);
        }

        private void PrintInvoice(bool IsDirectPrint = true)
        {
            //Abhi kaam kerna hai is per.
            return;
            try
            {
                if (string.IsNullOrEmpty(txtReturnInvoiceNo.Text))
                {
                    return;
                }
                SalesManager sm = new SalesManager();
                bool IsGSTInvoice = false;
                string path = string.Empty;
                if (!string.IsNullOrEmpty(txtGSTPerc.Text))
                {
                    if (Convert.ToDecimal(txtGSTPerc.Text) > 0)
                    {
                        IsGSTInvoice = true;

                    }
                }
                if (IsGSTInvoice)
                {
                    path = Application.StartupPath + "/rpt/Sales/rptSalesInvoiceGST.rpt";
                }
                else
                {
                    path = Application.StartupPath + "/rpt/Sales/rptSalesInvoice.rpt";
                }

                ReportDocument document = new ReportDocument();
                document.Load(path);
                DataTable dtReport = new DataTable();
                if (IsGSTInvoice)
                {
                    dtReport = sm.GetSalesInvoiceReportWithGST(txtReturnInvoiceNo.Text);
                }
                else
                {
                    dtReport = sm.GetSalesInvoiceReport(txtReturnInvoiceNo.Text);
                }
                document.SetDataSource(dtReport);
                Utility.SetReportDefaultParameter(ref document);

                if (IsDirectPrint)
                {
                    //document.PrintToPrinter(1, true, 0, 0);
                }
                else
                {
                    frmReportSalesInvoice report = new frmReportSalesInvoice(document);
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearch search = new frmSearch();
                Smartworks.ColumnField[] gInvoice = new Smartworks.ColumnField[2];
                gInvoice[0] = new Smartworks.ColumnField("@IsGSTInvoice", false);
                gInvoice[1] = new Smartworks.ColumnField("@FYear", MainForm.FYear);
                search.getattributes("GetSearchInvoices", gInvoice, "Invoices");
                //search.getattributes("GetSearchInvoices", null, "Sales Invoice");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtSInvoiceNo.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtPackingNo_TextChanged(object sender, EventArgs e)
        {
            if (IsSalesReturnLoad)
            {
                return;
            }
            if (!string.IsNullOrEmpty(txtSInvoiceNo.Text))
            {
                LoadSaleInvoice();
            }
        }

        private void LoadSaleInvoice()
        {
            try
            {
                int SalesMasterId = -1;
                SalesMasterId = SalesManager.GetSalesMasterIdByCode(txtSInvoiceNo.Text, false , MainForm.FYear);  
                if (SalesMasterId > 0)
                {
                    setGridSetup(true, SalesMasterId);
                    dtpInvoice.Value = Convert.ToDateTime(drMaster["Date"].ToString());
                    txtCustomerCode.Text = drMaster["CustomerCode"].ToString();
                    txtGSTPerc.Text = "0";
                    txtGSTAmount.Text = "0";
                }
                else
                {
                    ClearFeilds();
                }

                //setGridSetup(true , )
            }
            catch (Exception ex)
            {
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
                //else
                //{
                //    txtEmployeeCode.Text = string.Empty;
                //    txtEmployeeCode.Focus();
                //}

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

        private void txtCustomerAccCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCustomerAccCode.Text))
                {
                    txtCustomerAccName.Text = manageAccount.GetChartOfAccounts(manageAccount.GetCOAIdByCode(txtCustomerAccCode.Text)).Rows[0]["AccountName"].ToString();
                }
                else
                {
                    txtCustomerAccName.Text = string.Empty;
                }

            }
            catch (Exception ex)
            {
                txtCustomerAccName.Text = string.Empty;
            }
        }

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtReturnInvoiceNo.Text))
            {
                SalesReturnMasterId = manageSalesReturn.GetSalesReturnMasterIdByCode(txtReturnInvoiceNo.Text , MainForm.FYear);
                if (SalesReturnMasterId > 0)
                {
                    LoadInvoice();
                }
            }
        }

        private void txtGSTPerc_Leave(object sender, EventArgs e)
        {
            try
            {

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
                        //PostSalesInvoice();
                        break;
                    }

            }
        }

        private void PostSalesInvoice()
        {
            if (SalesReturnMasterId < 0)
            {
                return;
            }
            //sp_PostPurchaseInvoice
            try
            {
                //dataAcess.BeginTransaction();
                //SalesManager.PostSalesInvoice(SalesReturnMasterId, MainForm.User_Id, DateTime.Now, "");
                //dataAcess.TransCommit();
                //MessageBox.Show("Invoice Post Sucessfully...", "Invoice Posted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //ClearFeilds();
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

        private void txtGSTPerc_TextChanged(object sender, EventArgs e)
        {

        }







    }
}
