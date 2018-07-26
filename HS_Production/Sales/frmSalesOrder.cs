using CrystalDecisions.CrystalReports.Engine;
using DevExpress.XtraEditors.Controls;
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
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FIL
{
    public partial class frmSalesOrder : Form
    {
        Smartworks.DAL dataAcess = new Smartworks.DAL();

        SalesOrderManager manageSalesOrder = new SalesOrderManager();

        DataSet dset;
        RepositoryItemGridLookUpEdit repositoryGridLookup = new RepositoryItemGridLookUpEdit();
        //RepositoryItemGridLookUpEdit repositoryWarehouseGridLookup = new RepositoryItemGridLookUpEdit();
        BindingSource bsProducts = new BindingSource();
        //BindingSource bsWarehouse = new BindingSource();
        DataRow drMaster;
        DataView dvProducts;
        DataViewManager dvm;
        int SalesOrderId = -1;
        List<int> DeletedIds = new List<int>();

        public frmSalesOrder()
        {
            InitializeComponent();
        }

        private void frmDirectSales_Load(object sender, EventArgs e)
        {
            ButtonRights(true);
            setGridSetup();
            txtSONo.Text = GetNewNextNumber();
            btnNextInvioceNo.Enabled = false;
            btnPrevInvioceNo.Enabled = false;

        }

        #region All Methods

        private String GetNewNextNumber()
        {
            string NewInvoiceNo = "";
            NewInvoiceNo = manageSalesOrder.GetMaxInvioceNo();
            if (!string.IsNullOrEmpty(NewInvoiceNo))
            {
                NewInvoiceNo = manageSalesOrder.GetNextInvioceNo(NewInvoiceNo);
            }
            else
            {
                NewInvoiceNo = "SO-000001";
            }
            return NewInvoiceNo;
        }
        private void ButtonRights(bool Enable)
        {
            btnAdd.Enabled = Enable;
            btnUpdate.Enabled = !Enable;
            btnDelete.Enabled = !Enable;
            txtSONo.ReadOnly = !Enable;
            btnCSearch.Enabled = Enable;
            txtCustomerCode.Enabled = Enable;
        }

        private void setGridSetup()
        {
            dset = new DataSet();
            dset = manageSalesOrder.GetSalesOrderStructure(SalesOrderId);
            dset.Tables[0].TableName = "SOrderMaster";
            dset.Tables[1].TableName = "SOrderDetail";
            dset.Tables[2].TableName = "Product";
            dset.Tables[3].TableName = "Warehouse";

            dset.Tables["SOrderMaster"].Columns["SOrderId"].AutoIncrement = true;
            dset.Tables["SOrderMaster"].Columns["SOrderId"].AutoIncrementSeed = -1;
            dset.Tables["SOrderMaster"].Columns["SOrderId"].AutoIncrementStep = -1;

            dset.Tables["SOrderDetail"].Columns["SOrderDetailId"].AutoIncrement = true;
            dset.Tables["SOrderDetail"].Columns["SOrderDetailId"].AutoIncrementSeed = -1;
            dset.Tables["SOrderDetail"].Columns["SOrderDetailId"].AutoIncrementStep = -1;


            dset.Relations.Add("MasterRelation", dset.Tables["SOrderMaster"].Columns["SOrderId"], dset.Tables["SOrderDetail"].Columns["SOrderId"]);
            if (dset.Tables["SOrderMaster"].Rows.Count > 0)
            {
                drMaster = dset.Tables["SOrderMaster"].Rows[0];
            }
            else
            {
                drMaster = dset.Tables["SOrderMaster"].NewRow();
                dset.Tables["SOrderMaster"].Rows.Add(drMaster);
            }
            dvm = new DataViewManager(dset);
            dvProducts = dvm.CreateDataView(dset.Tables["Product"]);
            GCDetail.DataSource = dset.Tables["SOrderDetail"];
            GridSetting();
        }

        private void GridSetting()
        {

            gvDetail.Columns.ColumnByName("colSOrderDetailId").OptionsColumn.ReadOnly = true;
            gvDetail.Columns.ColumnByName("colSOrderId").OptionsColumn.ReadOnly = true;

            gvDetail.Columns.ColumnByName("colSOrderDetailId").Visible = false;
            gvDetail.Columns.ColumnByName("colSOrderId").Visible = false;
            gvDetail.Columns.ColumnByName("colBarcode").Visible = false;
            gvDetail.Columns.ColumnByName("colProductCategoryId").Visible = false;
            gvDetail.Columns.ColumnByName("colCategoryName").Visible = false;
            gvDetail.Columns.ColumnByName("colAddedBy").Visible = false;
            gvDetail.Columns.ColumnByName("colAddedOn").Visible = false;
            gvDetail.Columns.ColumnByName("colAddedIpAddr").Visible = false;
            gvDetail.Columns.ColumnByName("colUpdatedBy").Visible = false;
            gvDetail.Columns.ColumnByName("colUpdatedOn").Visible = false;
            gvDetail.Columns.ColumnByName("colUpdatedIpAddr").Visible = false;
            //gvDetail.Columns.ColumnByName("colWarehouseId").Visible = false;


            //gvDetail.Columns.ColumnByName("colPrice").Visible = false;
            //gvDetail.Columns.ColumnByName("colAmount").Visible = false;
            //gvDetail.Columns.ColumnByName("colDiscountPercent").Visible = false;
            //gvDetail.Columns.ColumnByName("colDiscountAmount").Visible = false;
            //gvDetail.Columns.ColumnByName("colGSTPercent").Visible = false;
            //gvDetail.Columns.ColumnByName("colGSTAmount").Visible = false;
            //gvDetail.Columns.ColumnByName("colDiscountedAmount").Visible = false;
            //gvDetail.Columns.ColumnByName("colTotalAmount").Visible = false;


            gvDetail.Columns.ColumnByName("colProductId").Caption = "Product Name";
            gvDetail.Columns.ColumnByName("colPicture").Caption = "Image";

            gvDetail.Columns.ColumnByName("colS39").Caption = "39";
            gvDetail.Columns.ColumnByName("colS40").Caption = "40";
            gvDetail.Columns.ColumnByName("colS41").Caption = "41";
            gvDetail.Columns.ColumnByName("colS42").Caption = "42";
            gvDetail.Columns.ColumnByName("colS43").Caption = "43";
            gvDetail.Columns.ColumnByName("colS44").Caption = "44";
            gvDetail.Columns.ColumnByName("colS45").Caption = "45";
            gvDetail.Columns.ColumnByName("colS46").Caption = "46";
            gvDetail.Columns.ColumnByName("colS47").Caption = "47";

            gvDetail.Columns.ColumnByName("colS39").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvDetail.Columns.ColumnByName("colS40").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvDetail.Columns.ColumnByName("colS41").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvDetail.Columns.ColumnByName("colS42").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvDetail.Columns.ColumnByName("colS43").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvDetail.Columns.ColumnByName("colS44").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvDetail.Columns.ColumnByName("colS45").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvDetail.Columns.ColumnByName("colS46").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvDetail.Columns.ColumnByName("colS47").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;


            gvDetail.Columns.ColumnByName("colS39").AppearanceHeader.Font = new Font("Arial", 10.0f, FontStyle.Bold);
            gvDetail.Columns.ColumnByName("colS40").AppearanceHeader.Font = new Font("Arial", 10.0f, FontStyle.Bold);
            gvDetail.Columns.ColumnByName("colS41").AppearanceHeader.Font = new Font("Arial", 10.0f, FontStyle.Bold);
            gvDetail.Columns.ColumnByName("colS42").AppearanceHeader.Font = new Font("Arial", 10.0f, FontStyle.Bold);
            gvDetail.Columns.ColumnByName("colS43").AppearanceHeader.Font = new Font("Arial", 10.0f, FontStyle.Bold);
            gvDetail.Columns.ColumnByName("colS44").AppearanceHeader.Font = new Font("Arial", 10.0f, FontStyle.Bold);
            gvDetail.Columns.ColumnByName("colS45").AppearanceHeader.Font = new Font("Arial", 10.0f, FontStyle.Bold);
            gvDetail.Columns.ColumnByName("colS46").AppearanceHeader.Font = new Font("Arial", 10.0f, FontStyle.Bold);
            gvDetail.Columns.ColumnByName("colS47").AppearanceHeader.Font = new Font("Arial", 10.0f, FontStyle.Bold);

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


            gvDetail.Columns.ColumnByName("colOrderQty").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colOrderQty").OptionsColumn.AllowFocus = false;

            gvDetail.Columns.ColumnByName("colDiscountedAmount").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colDiscountedAmount").OptionsColumn.AllowFocus = false;

            gvDetail.Columns.ColumnByName("colTotalAmount").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colTotalAmount").OptionsColumn.AllowFocus = false;

            gvDetail.Columns.ColumnByName("colPicture").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colPicture").OptionsColumn.AllowFocus = false;


            gvDetail.Columns.ColumnByName("colProductId").VisibleIndex = 0;
            gvDetail.Columns.ColumnByName("colPicture").VisibleIndex = 1;
            gvDetail.Columns.ColumnByName("colS39").VisibleIndex = 2;
            gvDetail.Columns.ColumnByName("colS40").VisibleIndex = 3;
            gvDetail.Columns.ColumnByName("colS41").VisibleIndex = 4;
            gvDetail.Columns.ColumnByName("colS42").VisibleIndex = 5;
            gvDetail.Columns.ColumnByName("colS43").VisibleIndex = 6;
            gvDetail.Columns.ColumnByName("colS44").VisibleIndex = 7;
            gvDetail.Columns.ColumnByName("colS45").VisibleIndex = 8;
            gvDetail.Columns.ColumnByName("colS46").VisibleIndex = 9;
            gvDetail.Columns.ColumnByName("colS47").VisibleIndex = 10;
            gvDetail.Columns.ColumnByName("colOrderQty").VisibleIndex = 11;

            gvDetail.Columns.ColumnByName("colPrice").VisibleIndex = 12;
            gvDetail.Columns.ColumnByName("colAmount").VisibleIndex = 13;
            gvDetail.Columns.ColumnByName("colDiscountPercent").VisibleIndex = 14;
            gvDetail.Columns.ColumnByName("colDiscountAmount").VisibleIndex = 15;
            gvDetail.Columns.ColumnByName("colDiscountedAmount").VisibleIndex = 16;
            gvDetail.Columns.ColumnByName("colGSTPercent").VisibleIndex = 17;
            gvDetail.Columns.ColumnByName("colGSTAmount").VisibleIndex = 18;
            gvDetail.Columns.ColumnByName("colTotalAmount").VisibleIndex = 19;


            gvDetail.Columns.ColumnByName("colProductId").Width = 300;
            gvDetail.Columns.ColumnByName("colS39").Width = 40;
            gvDetail.Columns.ColumnByName("colS40").Width = 40;
            gvDetail.Columns.ColumnByName("colS41").Width = 40;
            gvDetail.Columns.ColumnByName("colS42").Width = 40;
            gvDetail.Columns.ColumnByName("colS43").Width = 40;
            gvDetail.Columns.ColumnByName("colS44").Width = 40;
            gvDetail.Columns.ColumnByName("colS45").Width = 40;
            gvDetail.Columns.ColumnByName("colS46").Width = 40;
            gvDetail.Columns.ColumnByName("colS47").Width = 40;
            gvDetail.Columns.ColumnByName("colOrderQty").Width = 60;

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

            RepositoryItemPictureEdit pictureEdit = GCDetail.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
            pictureEdit.SizeMode = PictureSizeMode.Stretch;
            pictureEdit.NullText = "";
            pictureEdit.Appearance.Image = null;
            pictureEdit.EnableLODImages = true;
            gvDetail.Columns.ColumnByName("colPicture").ColumnEdit = pictureEdit;

            gvDetail.Columns.ColumnByName("colProductId").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

            gvDetail.OptionsView.RowAutoHeight = false;
            //gvDetail.OptionsView.RowHe
        }

        private void ClearFeilds()
        {
            txtSONo.Text = string.Empty;
            dtpDate.Value = DateTime.Now;
            dtpDueDate.Value = DateTime.Now;
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtEmployeeCode.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtPONo.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtTotalAmount.Text = "0";
            txtDiscount.Text = "0";
            txtDiscountPercent.Text = "0";
            txtGSTPerc.Text = "0";
            txtGSTAmount.Text = "0";
            txtNetTotal.Text = "0";
            chkClose.Checked = false;
            chkProduction.Checked = false;
            chkIsDispatched.Checked = false;
            SalesOrderId = -1;
            DeletedIds = new List<int>();


            dset.Tables["SOrderDetail"].Rows.Clear();
            dset.Tables["SOrderMaster"].Rows.Clear();

            dset.RejectChanges();


            drMaster = dset.Tables["SOrderMaster"].NewRow();
            dset.Tables["SOrderMaster"].Rows.Add(drMaster);
            GCDetail.DataSource = dset.Tables["SOrderDetail"];
            GridSetting();
            
            ButtonRights(true);
            txtSONo.Text = GetNewNextNumber();
            btnNextInvioceNo.Enabled = false;
            btnPrevInvioceNo.Enabled = false;
        }
        private void LoadSOrder()
        {
            try
            {
                setGridSetup();

                if (dset.Tables["SOrderMaster"].Rows.Count > 0)
                {
                    txtCustomerCode.Text = drMaster["CustomerCode"].ToString();
                    txtEmployeeCode.Text = drMaster["EmployeeCode"].ToString();
                    dtpDate.Value = Convert.ToDateTime(drMaster["OrderDate"]);
                    dtpDueDate.Value = Convert.ToDateTime(drMaster["DueDate"]);
                    txtPONo.Text = drMaster["PONo"].ToString();
                    txtRemarks.Text = drMaster["Remarks"].ToString();
                    txtTotalAmount.Text = drMaster["TAmount"].ToString();
                    txtGSTPerc.Text = drMaster["GSTPercent"].ToString();
                    txtGSTAmount.Text = drMaster["GSTAmount"].ToString();
                    txtDiscountPercent.Text = drMaster["TDiscountPerc"].ToString();
                    txtDiscount.Text = drMaster["TDiscount"].ToString();
                    txtNetTotal.Text = Math.Round(decimal.Parse(drMaster["NetAmount"].ToString()), 0).ToString();
                    chkClose.Checked = Convert.ToBoolean(drMaster["Closed"]);
                    chkProduction.Checked = Convert.ToBoolean(drMaster["ProductionClosed"]);
                    chkIsDispatched.Checked = Convert.ToBoolean(drMaster["IsDispatched"]);
                    ButtonRights(false);

                    //for Navigation Works*******
                    try
                    {
                        string FirstTransNo = manageSalesOrder.GetMinInvioceNo();
                        string LastTransNo = manageSalesOrder.GetMaxInvioceNo();
                        if (LastTransNo == txtSONo.Text)
                        {
                            btnNextInvioceNo.Enabled = false;
                        }
                        else
                        {
                            btnNextInvioceNo.Enabled = true;
                        }
                        if (FirstTransNo == txtSONo.Text)
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
                        //dr["WarehouseId"] = -1;
                        //dr["StockType"] = "Stock";

                        //Math.Round(decimal.Parse(dr["DiscountAmount"].ToString()), 2);
                        if (string.IsNullOrEmpty(dr["S39"].ToString()))
                        {
                            dr["S39"] = 0;
                        }
                        if (string.IsNullOrEmpty(dr["S40"].ToString()))
                        {
                            dr["S40"] = 0;
                        }
                        if (string.IsNullOrEmpty(dr["S41"].ToString()))
                        {
                            dr["S41"] = 0;
                        }
                        if (string.IsNullOrEmpty(dr["S42"].ToString()))
                        {
                            dr["S42"] = 0;
                        }
                        if (string.IsNullOrEmpty(dr["S43"].ToString()))
                        {
                            dr["S43"] = 0;
                        }
                        if (string.IsNullOrEmpty(dr["S44"].ToString()))
                        {
                            dr["S44"] = 0;
                        }
                        if (string.IsNullOrEmpty(dr["S45"].ToString()))
                        {
                            dr["S45"] = 0;
                        }
                        if (string.IsNullOrEmpty(dr["S46"].ToString()))
                        {
                            dr["S46"] = 0;
                        }
                        if (string.IsNullOrEmpty(dr["S47"].ToString()))
                        {
                            dr["S47"] = 0;
                        }

                        if (string.IsNullOrEmpty(dr["OrderQty"].ToString()))
                        {
                            dr["OrderQty"] = 0;
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

                        try
                        {
                            dr["Picture"] = dvProducts[0]["Picture"]; // Base64ToImage(dvProducts[0]["Picture"].ToString());
                            //DataGridViewRow dgv = e.RowHandle;
                            //RepositoryItemPictureEdit
                            //colPicture
                        }
                        catch (Exception imgex)
                        {

                        }

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


                    case "colS39":

                        decimal totalQty = 0;
                        totalQty = (string.IsNullOrEmpty(dr["S39"].ToString()) ? 0 : Convert.ToDecimal(dr["S39"].ToString())) +
                            (string.IsNullOrEmpty(dr["S40"].ToString()) ? 0 : Convert.ToDecimal(dr["S40"].ToString())) +
                            (string.IsNullOrEmpty(dr["S41"].ToString()) ? 0 : Convert.ToDecimal(dr["S41"].ToString())) +
                            (string.IsNullOrEmpty(dr["S42"].ToString()) ? 0 : Convert.ToDecimal(dr["S42"].ToString())) +
                            (string.IsNullOrEmpty(dr["S43"].ToString()) ? 0 : Convert.ToDecimal(dr["S43"].ToString())) +
                            (string.IsNullOrEmpty(dr["S44"].ToString()) ? 0 : Convert.ToDecimal(dr["S44"].ToString())) +
                            (string.IsNullOrEmpty(dr["S45"].ToString()) ? 0 : Convert.ToDecimal(dr["S45"].ToString())) +
                            (string.IsNullOrEmpty(dr["S46"].ToString()) ? 0 : Convert.ToDecimal(dr["S46"].ToString())) +
                            (string.IsNullOrEmpty(dr["S47"].ToString()) ? 0 : Convert.ToDecimal(dr["S47"].ToString()));
                        dr["OrderQty"] = totalQty;


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
                    case "colS40":

                        totalQty = (string.IsNullOrEmpty(dr["S39"].ToString()) ? 0 : Convert.ToDecimal(dr["S39"].ToString())) +

                            (string.IsNullOrEmpty(dr["S40"].ToString()) ? 0 : Convert.ToDecimal(dr["S40"].ToString())) +
                            (string.IsNullOrEmpty(dr["S41"].ToString()) ? 0 : Convert.ToDecimal(dr["S41"].ToString())) +
                            (string.IsNullOrEmpty(dr["S42"].ToString()) ? 0 : Convert.ToDecimal(dr["S42"].ToString())) +
                            (string.IsNullOrEmpty(dr["S43"].ToString()) ? 0 : Convert.ToDecimal(dr["S43"].ToString())) +
                            (string.IsNullOrEmpty(dr["S44"].ToString()) ? 0 : Convert.ToDecimal(dr["S44"].ToString())) +
                            (string.IsNullOrEmpty(dr["S45"].ToString()) ? 0 : Convert.ToDecimal(dr["S45"].ToString())) +
                            (string.IsNullOrEmpty(dr["S46"].ToString()) ? 0 : Convert.ToDecimal(dr["S46"].ToString())) +
                            (string.IsNullOrEmpty(dr["S47"].ToString()) ? 0 : Convert.ToDecimal(dr["S47"].ToString()));
                        dr["OrderQty"] = totalQty;
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
                    case "colS41":

                        totalQty = (string.IsNullOrEmpty(dr["S39"].ToString()) ? 0 : Convert.ToDecimal(dr["S39"].ToString())) +

                            (string.IsNullOrEmpty(dr["S40"].ToString()) ? 0 : Convert.ToDecimal(dr["S40"].ToString())) +
                            (string.IsNullOrEmpty(dr["S41"].ToString()) ? 0 : Convert.ToDecimal(dr["S41"].ToString())) +
                            (string.IsNullOrEmpty(dr["S42"].ToString()) ? 0 : Convert.ToDecimal(dr["S42"].ToString())) +
                            (string.IsNullOrEmpty(dr["S43"].ToString()) ? 0 : Convert.ToDecimal(dr["S43"].ToString())) +
                            (string.IsNullOrEmpty(dr["S44"].ToString()) ? 0 : Convert.ToDecimal(dr["S44"].ToString())) +
                            (string.IsNullOrEmpty(dr["S45"].ToString()) ? 0 : Convert.ToDecimal(dr["S45"].ToString())) +
                            (string.IsNullOrEmpty(dr["S46"].ToString()) ? 0 : Convert.ToDecimal(dr["S46"].ToString())) +
                            (string.IsNullOrEmpty(dr["S47"].ToString()) ? 0 : Convert.ToDecimal(dr["S47"].ToString()));
                        dr["OrderQty"] = totalQty;
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
                    case "colS42":

                        totalQty = (string.IsNullOrEmpty(dr["S39"].ToString()) ? 0 : Convert.ToDecimal(dr["S39"].ToString())) +

                            (string.IsNullOrEmpty(dr["S40"].ToString()) ? 0 : Convert.ToDecimal(dr["S40"].ToString())) +
                            (string.IsNullOrEmpty(dr["S41"].ToString()) ? 0 : Convert.ToDecimal(dr["S41"].ToString())) +
                            (string.IsNullOrEmpty(dr["S42"].ToString()) ? 0 : Convert.ToDecimal(dr["S42"].ToString())) +
                            (string.IsNullOrEmpty(dr["S43"].ToString()) ? 0 : Convert.ToDecimal(dr["S43"].ToString())) +
                            (string.IsNullOrEmpty(dr["S44"].ToString()) ? 0 : Convert.ToDecimal(dr["S44"].ToString())) +
                            (string.IsNullOrEmpty(dr["S45"].ToString()) ? 0 : Convert.ToDecimal(dr["S45"].ToString())) +
                            (string.IsNullOrEmpty(dr["S46"].ToString()) ? 0 : Convert.ToDecimal(dr["S46"].ToString())) +
                            (string.IsNullOrEmpty(dr["S47"].ToString()) ? 0 : Convert.ToDecimal(dr["S47"].ToString()));
                        dr["OrderQty"] = totalQty;
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
                    case "colS43":

                        totalQty = (string.IsNullOrEmpty(dr["S39"].ToString()) ? 0 : Convert.ToDecimal(dr["S39"].ToString())) +

                            (string.IsNullOrEmpty(dr["S40"].ToString()) ? 0 : Convert.ToDecimal(dr["S40"].ToString())) +
                            (string.IsNullOrEmpty(dr["S41"].ToString()) ? 0 : Convert.ToDecimal(dr["S41"].ToString())) +
                            (string.IsNullOrEmpty(dr["S42"].ToString()) ? 0 : Convert.ToDecimal(dr["S42"].ToString())) +
                            (string.IsNullOrEmpty(dr["S43"].ToString()) ? 0 : Convert.ToDecimal(dr["S43"].ToString())) +
                            (string.IsNullOrEmpty(dr["S44"].ToString()) ? 0 : Convert.ToDecimal(dr["S44"].ToString())) +
                            (string.IsNullOrEmpty(dr["S45"].ToString()) ? 0 : Convert.ToDecimal(dr["S45"].ToString())) +
                            (string.IsNullOrEmpty(dr["S46"].ToString()) ? 0 : Convert.ToDecimal(dr["S46"].ToString())) +
                            (string.IsNullOrEmpty(dr["S47"].ToString()) ? 0 : Convert.ToDecimal(dr["S47"].ToString()));
                        dr["OrderQty"] = totalQty;
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
                    case "colS44":

                        totalQty = (string.IsNullOrEmpty(dr["S39"].ToString()) ? 0 : Convert.ToDecimal(dr["S39"].ToString())) +

                            (string.IsNullOrEmpty(dr["S40"].ToString()) ? 0 : Convert.ToDecimal(dr["S40"].ToString())) +
                            (string.IsNullOrEmpty(dr["S41"].ToString()) ? 0 : Convert.ToDecimal(dr["S41"].ToString())) +
                            (string.IsNullOrEmpty(dr["S42"].ToString()) ? 0 : Convert.ToDecimal(dr["S42"].ToString())) +
                            (string.IsNullOrEmpty(dr["S43"].ToString()) ? 0 : Convert.ToDecimal(dr["S43"].ToString())) +
                            (string.IsNullOrEmpty(dr["S44"].ToString()) ? 0 : Convert.ToDecimal(dr["S44"].ToString())) +
                            (string.IsNullOrEmpty(dr["S45"].ToString()) ? 0 : Convert.ToDecimal(dr["S45"].ToString())) +
                            (string.IsNullOrEmpty(dr["S46"].ToString()) ? 0 : Convert.ToDecimal(dr["S46"].ToString())) +
                            (string.IsNullOrEmpty(dr["S47"].ToString()) ? 0 : Convert.ToDecimal(dr["S47"].ToString()));
                        dr["OrderQty"] = totalQty;
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
                    case "colS45":

                        totalQty = (string.IsNullOrEmpty(dr["S39"].ToString()) ? 0 : Convert.ToDecimal(dr["S39"].ToString())) +

                            (string.IsNullOrEmpty(dr["S40"].ToString()) ? 0 : Convert.ToDecimal(dr["S40"].ToString())) +
                            (string.IsNullOrEmpty(dr["S41"].ToString()) ? 0 : Convert.ToDecimal(dr["S41"].ToString())) +
                            (string.IsNullOrEmpty(dr["S42"].ToString()) ? 0 : Convert.ToDecimal(dr["S42"].ToString())) +
                            (string.IsNullOrEmpty(dr["S43"].ToString()) ? 0 : Convert.ToDecimal(dr["S43"].ToString())) +
                            (string.IsNullOrEmpty(dr["S44"].ToString()) ? 0 : Convert.ToDecimal(dr["S44"].ToString())) +
                            (string.IsNullOrEmpty(dr["S45"].ToString()) ? 0 : Convert.ToDecimal(dr["S45"].ToString())) +
                            (string.IsNullOrEmpty(dr["S46"].ToString()) ? 0 : Convert.ToDecimal(dr["S46"].ToString())) +
                            (string.IsNullOrEmpty(dr["S47"].ToString()) ? 0 : Convert.ToDecimal(dr["S47"].ToString()));
                        dr["OrderQty"] = totalQty;
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
                    case "colS46":

                        totalQty = (string.IsNullOrEmpty(dr["S39"].ToString()) ? 0 : Convert.ToDecimal(dr["S39"].ToString())) +

                            (string.IsNullOrEmpty(dr["S40"].ToString()) ? 0 : Convert.ToDecimal(dr["S40"].ToString())) +
                            (string.IsNullOrEmpty(dr["S41"].ToString()) ? 0 : Convert.ToDecimal(dr["S41"].ToString())) +
                            (string.IsNullOrEmpty(dr["S42"].ToString()) ? 0 : Convert.ToDecimal(dr["S42"].ToString())) +
                            (string.IsNullOrEmpty(dr["S43"].ToString()) ? 0 : Convert.ToDecimal(dr["S43"].ToString())) +
                            (string.IsNullOrEmpty(dr["S44"].ToString()) ? 0 : Convert.ToDecimal(dr["S44"].ToString())) +
                            (string.IsNullOrEmpty(dr["S45"].ToString()) ? 0 : Convert.ToDecimal(dr["S45"].ToString())) +
                            (string.IsNullOrEmpty(dr["S46"].ToString()) ? 0 : Convert.ToDecimal(dr["S46"].ToString())) +
                            (string.IsNullOrEmpty(dr["S47"].ToString()) ? 0 : Convert.ToDecimal(dr["S47"].ToString()));
                        dr["OrderQty"] = totalQty;
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
                    case "colS47":

                        totalQty = (string.IsNullOrEmpty(dr["S39"].ToString()) ? 0 : Convert.ToDecimal(dr["S39"].ToString())) +

                            (string.IsNullOrEmpty(dr["S40"].ToString()) ? 0 : Convert.ToDecimal(dr["S40"].ToString())) +
                            (string.IsNullOrEmpty(dr["S41"].ToString()) ? 0 : Convert.ToDecimal(dr["S41"].ToString())) +
                            (string.IsNullOrEmpty(dr["S42"].ToString()) ? 0 : Convert.ToDecimal(dr["S42"].ToString())) +
                            (string.IsNullOrEmpty(dr["S43"].ToString()) ? 0 : Convert.ToDecimal(dr["S43"].ToString())) +
                            (string.IsNullOrEmpty(dr["S44"].ToString()) ? 0 : Convert.ToDecimal(dr["S44"].ToString())) +
                            (string.IsNullOrEmpty(dr["S45"].ToString()) ? 0 : Convert.ToDecimal(dr["S45"].ToString())) +
                            (string.IsNullOrEmpty(dr["S46"].ToString()) ? 0 : Convert.ToDecimal(dr["S46"].ToString())) +
                            (string.IsNullOrEmpty(dr["S47"].ToString()) ? 0 : Convert.ToDecimal(dr["S47"].ToString()));
                        dr["OrderQty"] = totalQty;
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

            decimal TotalQty = 0;
            decimal TotalAmount = 0;
            try
            {
                foreach (DataRow dr in dset.Tables["SOrderDetail"].Rows)
                {
                    if (dr.RowState != DataRowState.Deleted)
                    {

                        try
                        {
                            TotalQty = TotalQty + Decimal.Parse(dr["OrderQty"].ToString());
                            TotalAmount = TotalAmount + Decimal.Parse(dr["TotalAmount"].ToString());
                        }
                        catch
                        {
                            dr.BeginEdit();
                        }
                    }
                }

                txtTotalQty.Text = Math.Round(TotalQty, 0).ToString();
                txtTotalAmount.Text = Math.Round(TotalAmount, 2).ToString();

                txtNetTotal.Text = Math.Round(TotalAmount, 0).ToString();
                txtDiscountPercent_Leave(null, null);

            }
            catch (Exception ex)
            {
                txtTotalQty.Text = Math.Round(TotalQty, 2).ToString();
            }
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
                    txtNetTotal.Text = Math.Round((decimal.Parse(txtTotalAmount.Text) + decimal.Parse((string.IsNullOrEmpty(txtGSTAmount.Text) ? "0" : txtGSTAmount.Text).ToString()) - decimal.Parse(txtDiscount.Text)), 0).ToString();
                }
            }
            else
            {
                txtDiscountPercent.Text = "0";
                txtDiscountPercent.Text = Math.Round(decimal.Parse(txtDiscountPercent.Text), 2).ToString();
                txtDiscount.Text = Math.Round(((decimal.Parse(txtTotalAmount.Text) * decimal.Parse(txtDiscountPercent.Text)) / 100), 0).ToString();
                txtNetTotal.Text = Math.Round((decimal.Parse(txtTotalAmount.Text) + decimal.Parse((string.IsNullOrEmpty(txtGSTAmount.Text) ? "0" : txtGSTAmount.Text).ToString()) - decimal.Parse(txtDiscount.Text)), 0).ToString();

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
                        txtNetTotal.Text = Math.Round((decimal.Parse(txtTotalAmount.Text) + decimal.Parse((string.IsNullOrEmpty(txtGSTAmount.Text) ? "0" : txtGSTAmount.Text).ToString()) - decimal.Parse(txtDiscount.Text)), 0).ToString();
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
            // MessageBox.Show(e.ErrorText, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                if (dset.Tables["SOrderDetail"].Select("ProductId =" + dr["ProductId"].ToString()).Length > 0)
                {
                    MessageBox.Show("Item Already Exists", "Same Items can not be repeated.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Valid = false;
                }
            }
            else
            {
                e.Valid = true;
                gvDetail.GetDataRow(e.RowHandle)["SOrderId"] = drMaster["SOrderId"]; //SalesMasterId;
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
            if (string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                MessageBox.Show("Please Select Party Code.", "Party Code is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerCode.Focus();
                result = false;
                return result;

            }
            if (string.IsNullOrEmpty(txtPONo.Text))
            {
                MessageBox.Show("Please Select Party Order Number.", "Party Order Number is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPONo.Focus();
                result = false;
                return result;
            }
            if (dset.Tables["SOrderDetail"].Rows.Count <= 0)
            {
                MessageBox.Show("Please Enter Detail of Sales Order.", "Detail is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void DeleteSalesOrder()
        {
            if (string.IsNullOrEmpty(txtSONo.Text))
            {
                return;
            }
            try
            {
                //if (managePurchaseOrder.IsPurchaseOrderInUsed(txtSONo.Text))
                //{
                //    MessageBox.Show("Purchase Order " + txtSONo.Text + " Can not be Deleted becuase Reference in Use.", "Error to Delete Purchase Order.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                ProductManager PM = new ProductManager();
                dataAcess.BeginTransaction();

                int status = manageSalesOrder.DeleteSOrderMaster(manageSalesOrder.GetSalesOrderMasterIdByCode(txtSONo.Text), dataAcess);
                dataAcess.TransCommit();
                if (status > 0)
                {
                    MessageBox.Show("Sale Order " + txtSONo.Text + " is Deleted.", "Order Delete Successful.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validations())
            {
                try
                {


                    ProductManager PM = new ProductManager();
                    dataAcess.BeginTransaction();
                    if (dataAcess.getDBCommand().Transaction == null)
                    {
                        dataAcess.SetDBTransaction();
                    }
                    SalesOrderId = manageSalesOrder.InsertSOMaster(Convert.ToDateTime(dtpDate.Value.ToString()), Convert.ToDateTime(dtpDueDate.Value), "H", txtCustomerCode.Text, "", txtEmployeeCode.Text, -1, -1, -1, 0, Convert.ToDecimal(txtTotalQty.Text), (string.IsNullOrEmpty(txtTotalAmount.Text) ? 0 : Convert.ToDecimal(txtTotalAmount.Text)),
                        string.IsNullOrEmpty(txtDiscountPercent.Text) ? 0 : Convert.ToDecimal(txtDiscountPercent.Text),
                        string.IsNullOrEmpty(txtDiscount.Text) ? 0 : Convert.ToDecimal(txtDiscount.Text), chkClose.Checked, chkProduction.Checked,
                        txtRemarks.Text, txtPONo.Text, string.IsNullOrEmpty(txtGSTPerc.Text) ? 0 : Convert.ToDecimal(txtGSTPerc.Text),
                        string.IsNullOrEmpty(txtGSTAmount.Text) ? 0 : Convert.ToDecimal(txtGSTAmount.Text), MainForm.User_Id,
                        DateTime.Now, "", chkIsDispatched.Checked, dataAcess);
                    if (SalesOrderId > 0)
                    {
                        for (int i = 0; i < dset.Tables["SOrderDetail"].Rows.Count; i++)
                        {
                            int DetailId = manageSalesOrder.InsertUpdateSODetail(Convert.ToInt32(dset.Tables["SOrderDetail"].Rows[i]["SOrderDetailId"]), SalesOrderId,
                                Convert.ToInt32(dset.Tables["SOrderDetail"].Rows[i]["ProductId"]), "Stock",
                                Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["S39"]),
                                Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["S40"]),
                                Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["S41"]),
                                Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["S42"]),
                                Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["S43"]),
                                Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["S44"]),
                                Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["S45"]),
                                Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["S46"]),
                                Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["S47"]),
                                Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["OrderQty"]), 0,
                                Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["Price"]),
                                Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["DiscountPercent"]),
                                Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["DiscountAmount"]),
                                Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["GSTPercent"]),
                                Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["GSTAmount"]),
                                MainForm.User_Id, DateTime.Now, "", dataAcess);
                        }
                    }
                    dataAcess.TransCommit();
                    if (MessageBox.Show("Sales Order " + txtSONo.Text + " has Saved." + Environment.NewLine + " Do you want to Print. ", "Order Saved Successful.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
                search.getattributes("GetCustomerSearch", null, "Party Names");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    DataTable dtVendor = dataAcess.getDataTable("SELECT  * FROM dbo.Customer WHERE Code = '" + MainForm.Searched_Id + "' ");
                    txtCustomerCode.Text = dtVendor.Rows[0]["Code"].ToString();
                    txtCustomerName.Text = dtVendor.Rows[0]["CustomerName"].ToString();
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
                search.getattributes("GetSearchSalesOrders", null, "Sales Orders");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtSONo.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                    //LoadPOrder(); 
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

                DataTable dtVendor = dataAcess.getDataTable("SELECT  * FROM dbo.Customer WHERE Code = '" + txtCustomerCode.Text + "' ");
                if (dtVendor.Rows.Count > 0)
                {
                    txtCustomerName.Text = dtVendor.Rows[0]["CustomerName"].ToString();
                }
            }
            else
            {
                txtCustomerName.Text = string.Empty;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validations())
            {
                try
                {
                    ProductManager PM = new ProductManager();
                    dataAcess.BeginTransaction();
                    if (dataAcess.getDBCommand().Transaction == null)
                    {
                        dataAcess.SetDBTransaction();
                    }
                    foreach (int id in DeletedIds)
                    {
                        manageSalesOrder.DeleteSOrderDetailByDetailId(id, dataAcess);
                    }
                    manageSalesOrder.UpdateSOMaster(SalesOrderId, Convert.ToDateTime(dtpDate.Value.ToString()), Convert.ToDateTime(dtpDueDate.Value), "H",
                        txtCustomerCode.Text, "", txtEmployeeCode.Text, -1, -1, -1, 0, Convert.ToDecimal(txtTotalQty.Text), string.IsNullOrEmpty(txtTotalAmount.Text) ? 0 : Convert.ToDecimal(txtTotalAmount.Text),
                        string.IsNullOrEmpty(txtDiscountPercent.Text) ? 0 : Convert.ToDecimal(txtDiscountPercent.Text), string.IsNullOrEmpty(txtDiscount.Text) ? 0 : Convert.ToDecimal(txtDiscount.Text),
                        chkClose.Checked, chkProduction.Checked, txtRemarks.Text, txtPONo.Text, string.IsNullOrEmpty(txtGSTPerc.Text) ? 0 : Convert.ToDecimal(txtGSTPerc.Text), string.IsNullOrEmpty(txtGSTAmount.Text) ? 0 : Convert.ToDecimal(txtGSTAmount.Text),
                        MainForm.User_Id, DateTime.Now, "", chkIsDispatched.Checked, dataAcess);
                    for (int i = 0; i < dset.Tables["SOrderDetail"].Rows.Count; i++)
                    {
                        if (dset.Tables["SOrderDetail"].Rows[i].RowState != DataRowState.Deleted)
                        {
                            DataRow drDetail = dset.Tables["SOrderDetail"].Rows[i];
                            int DetailId = manageSalesOrder.InsertUpdateSODetail(Convert.ToInt32(dset.Tables["SOrderDetail"].Rows[i]["SOrderDetailId"]), SalesOrderId,
                                 Convert.ToInt32(dset.Tables["SOrderDetail"].Rows[i]["ProductId"]), "Stock",
                                 Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["S39"]),
                                 Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["S40"]),
                                 Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["S41"]),
                                 Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["S42"]),
                                 Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["S43"]),
                                 Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["S44"]),
                                 Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["S45"]),
                                 Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["S46"]),
                                 Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["S47"]),
                                 Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["OrderQty"]), 0,
                                 Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["Price"]),
                                 Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["DiscountPercent"]),
                                 Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["DiscountAmount"]),
                                 Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["GSTPercent"]),
                                 Convert.ToDecimal(dset.Tables["SOrderDetail"].Rows[i]["GSTAmount"]),
                                 MainForm.User_Id, DateTime.Now, "", dataAcess);
                        }
                    }

                    dataAcess.TransCommit();
                    if (MessageBox.Show("Sale Order " + txtSONo.Text + " has Saved." + Environment.NewLine + " Do you want to Print. ", "Sale Order Saved Successful.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
                if (Convert.ToInt32(dr["SOrderDetailId"].ToString()) > 0)
                {
                    DeletedIds.Add(Convert.ToInt32(dr["SOrderDetailId"].ToString()));
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Sales Order Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {

                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeleteSalesOrder();
                        break;
                    }

            }
        }

        private void btnMinInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(manageSalesOrder.GetMinInvioceNo()))
            {
                txtSONo.Text = manageSalesOrder.GetMinInvioceNo();
                if (!string.IsNullOrEmpty(txtSONo.Text))
                {
                    //btnNextInvioceNo.Enabled = true;
                    //btnPrevInvioceNo.Enabled = false;
                }
            }
            
        }

        private void btnPrevInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSONo.Text))
            {
                string LastInvioceNo = manageSalesOrder.GetMinInvioceNo();
                txtSONo.Text = manageSalesOrder.GetPrevInvioceNo(txtSONo.Text);


                if (LastInvioceNo == txtSONo.Text)
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
            if (!string.IsNullOrEmpty(txtSONo.Text))
            {
                string LastInvioceNo = manageSalesOrder.GetMaxInvioceNo();
                txtSONo.Text = manageSalesOrder.GetNextInvioceNo(txtSONo.Text);

                if (LastInvioceNo == txtSONo.Text)
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
            if (!string.IsNullOrEmpty(manageSalesOrder.GetMaxInvioceNo()))
            {
                txtSONo.Text = manageSalesOrder.GetMaxInvioceNo();
                if (!string.IsNullOrEmpty(txtSONo.Text))
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
                if (string.IsNullOrEmpty(txtSONo.Text))
                {
                    return;
                }

                string path = Application.StartupPath + "/rpt/Sales/rptSalesOrder.rpt";
                ReportDocument document = new ReportDocument();
                document.Load(path);
                DataTable dtReport = new DataTable();
                dtReport = manageSalesOrder.GetSalesOrderReport(null, null, "", "", "", "", SalesOrderId);
                document.SetDataSource(dtReport);
                Utility.SetReportDefaultParameter(ref document);

                if (IsDirectPrint)
                {
                    document.PrintToPrinter(1, true, 0, 0);
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
            if (!string.IsNullOrEmpty(txtSONo.Text))
            {
                SalesOrderId = manageSalesOrder.GetSalesOrderMasterIdByCode(txtSONo.Text);
                if (SalesOrderId > 0)
                {
                    LoadSOrder();
                }
            }
            else
            {
                ClearFeilds();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void gvDetail_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //try
            //{
            //    GridView view = sender as GridView;

            //    if (e.RowHandle == view.FocusedRowHandle) return;
            //    if (e.Column.FieldName != "Picture") return;

            //    string ImageData = dvProducts[0]["Picture"].ToString();

            //    if (!string.IsNullOrEmpty(ImageData))
            //    {
            //        Image image = Base64ToImage(ImageData); //Image.FromFile("c:\\important.png");
            //        e.Graphics.DrawImage(image, e.Bounds.Location);
            //    }
            //}
            //catch (Exception ex)
            //{
            //}

        }

        private void gvDetail_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            //if (e.Column.FieldName == "GenderImage")
            //{
            //    string gender = gridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, gridView1.Columns["Gender"]).ToString();
            //    e.Value = (gender == "M") ? imageCollection1.Images[0] : imageCollection1.Images[1];
            //}

            try
            {
                if (e.Column.FieldName != "Picture") return;

                string ImageData = dvProducts[0]["Picture"].ToString();

                if (!string.IsNullOrEmpty(ImageData))
                {
                    Image image = Base64ToImage(ImageData); //Image.FromFile("c:\\important.png");
                    e.Value = image;
                    //e.Graphics.DrawImage(image, e.Bounds.Location);
                }

                //RepositoryItemPictureEdit pictureEdit = gridControl1.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
                //pictureEdit.SizeMode = PictureSizeMode.Zoom;
                //pictureEdit.NullText = "";
                //gridView1.Columns["Picture"].ColumnEdit = pictureEdit;

            }
            catch (Exception ex)
            {
            }
        }

        private void txtGSTPerc_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtGSTPerc.Text))
            {
                if (decimal.Parse(txtGSTPerc.Text) > 100)
                {
                    txtGSTAmount.Text = "0";
                    txtGSTPerc.Text = "0";
                    txtNetTotal.Text = Math.Round(decimal.Parse(txtTotalAmount.Text), 0).ToString(); //+ decimal.Parse(tbxFreightCharges.Text);
                    txtGSTPerc.Focus();
                    //MessageBox.Show(Messages.Percentage, Messages.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    txtGSTPerc.Text = Math.Round(decimal.Parse(txtGSTPerc.Text), 2).ToString();
                    txtGSTAmount.Text = Math.Round(((decimal.Parse(txtTotalAmount.Text) * decimal.Parse(txtGSTPerc.Text)) / 100), 0).ToString();
                    txtNetTotal.Text = Math.Round((decimal.Parse(txtTotalAmount.Text) + decimal.Parse((string.IsNullOrEmpty(txtGSTAmount.Text) ? "0" : txtGSTAmount.Text).ToString()) - decimal.Parse(txtDiscount.Text)), 0).ToString();
                }
            }
            else
            {
                txtGSTPerc.Text = "0";
                txtGSTPerc.Text = Math.Round(decimal.Parse(txtGSTPerc.Text), 2).ToString();
                txtGSTAmount.Text = Math.Round(((decimal.Parse(txtTotalAmount.Text) * decimal.Parse(txtGSTPerc.Text)) / 100), 0).ToString();
                txtNetTotal.Text = Math.Round((decimal.Parse(txtTotalAmount.Text) + decimal.Parse((string.IsNullOrEmpty(txtGSTAmount.Text) ? "0" : txtGSTAmount.Text).ToString()) - decimal.Parse(txtDiscount.Text)), 0).ToString();

            }
        }

        private void txtGSTAmount_Leave(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(txtGSTAmount.Text))
            //{
            //    if (decimal.Parse(txtGSTAmount.Text) > decimal.Parse(txtTotalAmount.Text))
            //    {
            //        txtGSTAmount.Text = "0";
            //        txtGSTPerc.Text = "0";
            //        txtNetTotal.Text = Math.Round(decimal.Parse(txtTotalAmount.Text), 0).ToString(); ;
            //        txtGSTAmount.Focus();
            //        //MessageBox.Show(Messages.DiscountGreaterThanAmount, Messages.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    else
            //    {
            //        if (decimal.Parse(txtTotalAmount.Text) > 0)
            //        {
            //            txtGSTAmount.Text = Math.Round(decimal.Parse(txtGSTAmount.Text), 0).ToString();
            //            txtGSTPerc.Text = Math.Round(((decimal.Parse(txtGSTAmount.Text) / decimal.Parse(txtTotalAmount.Text)) * 100), 2).ToString();
            //            txtNetTotal.Text = Math.Round((decimal.Parse(txtTotalAmount.Text) + decimal.Parse(txtGSTAmount.Text) - decimal.Parse(txtDiscount.Text) ), 0).ToString();
            //        }
            //    }
            //}

        }

        private void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {

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
