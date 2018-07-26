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
    public partial class frmPackingList : Form
    {
        Smartworks.DAL dataAcess = new Smartworks.DAL();

        SalesOrderManager manageSalesOrder = new SalesOrderManager();
        PackingListManager managePackingList = new PackingListManager();
        ProcessingManager manageProcessing = new ProcessingManager();

        DataSet dset;
        RepositoryItemGridLookUpEdit repositoryGridLookup = new RepositoryItemGridLookUpEdit();
        RepositoryItemGridLookUpEdit repositorySalesOrder = new RepositoryItemGridLookUpEdit();
        RepositoryItemGridLookUpEdit repositoryGrade = new RepositoryItemGridLookUpEdit();
        //RepositoryItemGridLookUpEdit repositoryWarehouseGridLookup = new RepositoryItemGridLookUpEdit();

        BindingSource bsSalesOrder = new BindingSource();
        BindingSource bsProducts = new BindingSource();
        BindingSource bsDisplayProducts = new BindingSource();
        BindingSource bsPendingSOProducts = new BindingSource();
        BindingSource bsGrade = new BindingSource();

        //BindingSource bsWarehouse = new BindingSource();
        DataRow drMaster;
        DataView dvProducts;
        DataViewManager dvm;
        int PackingListMasterId = -1;
        List<int> DeletedIds = new List<int>();
        bool IsPackingListLoad = false;
        public frmPackingList()
        {
            InitializeComponent();
        }

        private void frmDirectSales_Load(object sender, EventArgs e)
        {
            FillDropDown();
            ButtonRights(true);
            setGridSetup(false, PackingListMasterId);
            txtPackingNo.Text = GetNewNextNumber();
            btnNextInvioceNo.Enabled = false;
            btnPrevInvioceNo.Enabled = false;

        }

        #region All Methods

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

        private String GetNewNextNumber()
        {
            string NewInvoiceNo = "";
            NewInvoiceNo = managePackingList.GetMaxPLNo();
            if (!string.IsNullOrEmpty(NewInvoiceNo))
            {
                NewInvoiceNo = managePackingList.GetNextPLNo(NewInvoiceNo);
            }
            else
            {
                NewInvoiceNo = "PL-000001";
            }
            return NewInvoiceNo;
        }
        private void ButtonRights(bool Enable)
        {
            btnAdd.Enabled = Enable;
            btnUpdate.Enabled = !Enable;
            btnDelete.Enabled = !Enable;
            txtPackingNo.ReadOnly = !Enable;
            txtSONo.Enabled = Enable;
            btnSOSearch.Enabled = Enable;
            // btnCSearch.Enabled = Enable;
            btnCustomerSearch.Enabled = Enable;
            txtCustomerCode.Enabled = Enable;
        }

        private void setGridSetup(bool IsSaleOrderLoaded, int TranId)
        {
            dset = new DataSet();
            if (IsSaleOrderLoaded)
            {
                //age Sales Order Load hoga yani koi new entry ker raha hu ya phr koi SO load ker raha hu toh yeh wala structure aye ga .
                //dono k structure same rakhy hain. lakin data ka farq hai 

                dset = managePackingList.GetPackingListStructureBySOId(TranId);
            }
            else
            {
                //age koi Packing List dekh raha hu ya Edit mode per hu ya koi cheez Update kerni hai toh yeh wala structure load hoga. 
                //dono k structure same rakhy hain. lakin data ka farq hai 

                dset = managePackingList.GetPackingListStructure(TranId);
            }


            //dset = managePackingList.GetPackingListStructure(PackingListMasterId);
            dset.Tables[0].TableName = "PackingListMaster";
            dset.Tables[1].TableName = "PackingListDetail";
            dset.Tables[2].TableName = "Product";
            dset.Tables[3].TableName = "Warehouse";
            dset.Tables[4].TableName = "SOPendingQty";
            dset.Tables[5].TableName = "PendingSO";
            dset.Tables[6].TableName = "Grade";

            dset.Tables["PackingListMaster"].Columns["PackingListId"].AutoIncrement = true;
            dset.Tables["PackingListMaster"].Columns["PackingListId"].AutoIncrementSeed = -1;
            dset.Tables["PackingListMaster"].Columns["PackingListId"].AutoIncrementStep = -1;

            dset.Tables["PackingListDetail"].Columns["PLDetailId"].AutoIncrement = true;
            dset.Tables["PackingListDetail"].Columns["PLDetailId"].AutoIncrementSeed = -1;
            dset.Tables["PackingListDetail"].Columns["PLDetailId"].AutoIncrementStep = -1;


            dset.Relations.Add("MasterRelation", dset.Tables["PackingListMaster"].Columns["PackingListId"], dset.Tables["PackingListDetail"].Columns["PackingListId"]);
            if (dset.Tables["PackingListMaster"].Rows.Count > 0)
            {
                drMaster = dset.Tables["PackingListMaster"].Rows[0];
            }
            else
            {
                drMaster = dset.Tables["PackingListMaster"].NewRow();
                dset.Tables["PackingListMaster"].Rows.Add(drMaster);
            }
            dvm = new DataViewManager(dset);
            dvProducts = dvm.CreateDataView(dset.Tables["Product"]);
            GCDetail.DataSource = dset.Tables["PackingListDetail"];
            GridSetting();
        }

        private void GridSetting()
        {

            gvDetail.Columns.ColumnByName("colPLDetailId").OptionsColumn.ReadOnly = true;
            gvDetail.Columns.ColumnByName("colPackingListId").OptionsColumn.ReadOnly = true;

            gvDetail.Columns.ColumnByName("colPLDetailId").Visible = false;
            gvDetail.Columns.ColumnByName("colPackingListId").Visible = false;
            gvDetail.Columns.ColumnByName("colBarcode").Visible = false;
            gvDetail.Columns.ColumnByName("colProductCategoryId").Visible = false;
            gvDetail.Columns.ColumnByName("colCategoryName").Visible = false;
            gvDetail.Columns.ColumnByName("colAddedBy").Visible = false;
            gvDetail.Columns.ColumnByName("colAddedOn").Visible = false;
            gvDetail.Columns.ColumnByName("colAddedIpAddr").Visible = false;
            gvDetail.Columns.ColumnByName("colUpdatedBy").Visible = false;
            gvDetail.Columns.ColumnByName("colUpdatedOn").Visible = false;
            gvDetail.Columns.ColumnByName("colUpdatedIpAddr").Visible = false;


            gvDetail.Columns.ColumnByName("colSOrderId").Caption = "SO #";

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
            gvDetail.Columns.ColumnByName("colGradeId").Caption = "Grade";


            //gvDetail.Columns.ColumnByName("colS39").AppearanceHeader.ForeColor = Color.White;
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



            gvDetail.Columns.ColumnByName("colSOrderId").VisibleIndex = 0;
            gvDetail.Columns.ColumnByName("colProductId").VisibleIndex = 1;
            gvDetail.Columns.ColumnByName("colPicture").VisibleIndex = 2;
            gvDetail.Columns.ColumnByName("colGradeId").VisibleIndex = 3;
            gvDetail.Columns.ColumnByName("colS39").VisibleIndex = 4;
            gvDetail.Columns.ColumnByName("colS40").VisibleIndex = 5;
            gvDetail.Columns.ColumnByName("colS41").VisibleIndex = 6;
            gvDetail.Columns.ColumnByName("colS42").VisibleIndex = 7;
            gvDetail.Columns.ColumnByName("colS43").VisibleIndex = 8;
            gvDetail.Columns.ColumnByName("colS44").VisibleIndex = 9;
            gvDetail.Columns.ColumnByName("colS45").VisibleIndex = 10;
            gvDetail.Columns.ColumnByName("colS46").VisibleIndex = 11;
            gvDetail.Columns.ColumnByName("colS47").VisibleIndex = 12;
            gvDetail.Columns.ColumnByName("colOrderQty").VisibleIndex = 13;


            gvDetail.Columns.ColumnByName("colSOrderId").Width = 100;
            gvDetail.Columns.ColumnByName("colProductId").Width = 300;
            gvDetail.Columns.ColumnByName("colGradeId").Width = 100;
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

            gvDetail.Columns.ColumnByName("colOrderQty").OptionsColumn.AllowEdit = false;

            gvDetail.Columns.ColumnByName("colPicture").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colPicture").OptionsColumn.AllowFocus = false;



            bsSalesOrder.DataSource = dset;
            bsSalesOrder.DataMember = "PendingSO";

            bsProducts.DataSource = dset;
            bsProducts.DataMember = "Product";
            bsProducts.Filter = "SOrderId = " + -1 + "";

            bsDisplayProducts.DataSource = dset;
            bsDisplayProducts.DataMember = "Product";
            bsDisplayProducts.Filter = "ProductId = " + -1 + "";



            bsPendingSOProducts.DataSource = dset;
            bsPendingSOProducts.DataMember = "SOPendingQty";
            bsPendingSOProducts.Filter = "ProductId = -1 ";

            bsGrade.DataSource = dset;
            bsGrade.DataMember = "Grade";


            repositorySalesOrder.DataSource = bsSalesOrder;
            repositorySalesOrder.DisplayMember = "SOrderNo";
            repositorySalesOrder.ValueMember = "SOrderId";
            repositorySalesOrder.PopupFormSize = new Size(350,250);
            repositorySalesOrder.NullText = "";
            repositorySalesOrder.ShowFooter = false;
            repositorySalesOrder.View.OptionsView.ColumnAutoWidth = false;
            repositorySalesOrder.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            repositorySalesOrder.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            repositorySalesOrder.ImmediatePopup = true;
            repositorySalesOrder.PopulateViewColumns();
            GCDetail.RepositoryItems.Add(repositorySalesOrder);

            (GCDetail.MainView as GridView).Columns.ColumnByName("colSOrderId").ColumnEdit = repositorySalesOrder;

            if (repositorySalesOrder.View.Columns.Count > 0)
            {

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

                repositoryGridLookup.View.Columns.ColumnByName("colProductName").Caption = "Name";
                repositoryGridLookup.View.Columns.ColumnByName("colProductCode").Caption = "Code";
                repositoryGridLookup.View.Columns.ColumnByName("colCostPrice").Caption = "Cost Price";
                repositoryGridLookup.View.Columns.ColumnByName("colQtyInhand").Caption = "QtyInHand";
                repositoryGridLookup.View.Columns.ColumnByName("colCategoryName").Caption = "Category Name";
                //repositoryGridLookup.View.Columns.ColumnByName("colSOrderNo").Caption = "SOrderNo";

                repositoryGridLookup.View.Columns.ColumnByName("colProductName").Width = 150;
                repositoryGridLookup.View.Columns.ColumnByName("colProductCode").Width = 80;
                repositoryGridLookup.View.Columns.ColumnByName("colCostPrice").Width = 70;
                repositoryGridLookup.View.Columns.ColumnByName("colQtyInhand").Width = 40;
                repositoryGridLookup.View.Columns.ColumnByName("colCategoryName").Width = 100;
                //repositoryGridLookup.View.Columns.ColumnByName("colSOrderNo").Width = 100;


                //repositoryGridLookup.View.Columns.ColumnByName("colSOrderNo").VisibleIndex = 0;
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

            //RepositoryItemPictureEdit pictureEdit = GCDetail.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
            //pictureEdit.SizeMode = PictureSizeMode.Stretch;
            //pictureEdit.NullText = "";
            //pictureEdit.Appearance.Image = null;
            //pictureEdit.EnableLODImages = true;
            //gvDetail.Columns.ColumnByName("colPicture").ColumnEdit = pictureEdit;

          
            repositoryGrade.DataSource = bsGrade;
            repositoryGrade.DisplayMember = "Grade";
            repositoryGrade.ValueMember = "GradeId";
            repositoryGrade.PopupFormSize = new Size(150, 100);
            repositoryGrade.NullText = "";
            repositoryGrade.ShowFooter = false;
            repositoryGrade.View.OptionsView.ColumnAutoWidth = false;
            repositoryGrade.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            repositoryGrade.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            repositoryGrade.ImmediatePopup = true;
            repositoryGrade.PopulateViewColumns();
            GCDetail.RepositoryItems.Add(repositoryGrade);

            (GCDetail.MainView as GridView).Columns.ColumnByName("colGradeId").ColumnEdit = repositoryGrade;

            if (repositoryGrade.View.Columns.Count > 0)
            {

                repositoryGrade.View.Columns.ColumnByName("colGradeId").Visible = false;

                repositoryGrade.View.Columns.ColumnByName("colGrade").Caption = "Grade";

                repositoryGrade.View.Columns.ColumnByName("colGrade").Width = 150;

                repositoryGrade.View.Columns.ColumnByName("colGrade").VisibleIndex = 0;
            }


            gvDetail.Columns.ColumnByName("colSOrderId").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gvDetail.Columns.ColumnByName("colProductId").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

            gvDetail.OptionsView.RowAutoHeight = true;
        }

        private void ClearFeilds()
        {
            txtPackingNo.Text = string.Empty;
            dtpDate.Value = DateTime.Now;
            dtpSODate.Value = DateTime.Now;
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtEmployeeCode.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtSONo.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            cmbWarehouse.SelectedIndex = 0;
            txtGatePass.Text = string.Empty;
            PackingListMasterId = -1;
            DeletedIds = new List<int>();
            dset.Tables["PackingListDetail"].Rows.Clear();
            dset.Tables["PackingListMaster"].Rows.Clear();


            dset.RejectChanges();


            drMaster = dset.Tables["PackingListMaster"].NewRow();
            dset.Tables["PackingListMaster"].Rows.Add(drMaster);
            GCDetail.DataSource = dset.Tables["PackingDetail"];
            GridSetting();
            ButtonRights(true);
            txtPackingNo.Text = GetNewNextNumber();
            btnNextInvioceNo.Enabled = false;
            btnPrevInvioceNo.Enabled = false;
            setGridSetup(false, PackingListMasterId);
        }
        private void LoadPackingList()
        {
            try
            {
                setGridSetup(false, PackingListMasterId);

                if (dset.Tables["PackingListMaster"].Rows.Count > 0)
                {
                    dtpDate.Value = Convert.ToDateTime(drMaster["Date"]);
                    txtSONo.Text = drMaster["SOrderNo"].ToString();
                    cmbWarehouse.SelectedValue = drMaster["WarehouseId"];
                    dtpSODate.Value = Convert.ToDateTime(drMaster["SODate"]);
                    txtCustomerCode.Text = drMaster["CustomerCode"].ToString();
                    txtEmployeeCode.Text = drMaster["EmployeeCode"].ToString();
                    txtRemarks.Text = drMaster["Remarks"].ToString();
                    txtGatePass.Text = drMaster["GatePassNo"].ToString();
                    txtTotalQty.Text = drMaster["TQuantity"].ToString();
                    ButtonRights(false);

                    //for Navigation Works*******
                    try
                    {
                        string FirstTransNo = managePackingList.GetMinPLNo();
                        string LastTransNo = managePackingList.GetMaxPLNo();
                        if (LastTransNo == txtPackingNo.Text)
                        {
                            btnNextInvioceNo.Enabled = false;
                        }
                        else
                        {
                            btnNextInvioceNo.Enabled = true;
                        }
                        if (FirstTransNo == txtPackingNo.Text)
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

        private void LoadSalesOrder()
        {
            try
            {
                //SalesOrderManager manageSaleOrder = new SalesOrderManager();
                int SalesOrderId = -1;
                SalesOrderId = manageSalesOrder.GetSalesOrderMasterIdByCode(txtSONo.Text);
                if (SalesOrderId > 0)
                {
                    setGridSetup(true, SalesOrderId);

                    dtpSODate.Value = Convert.ToDateTime(drMaster["Date"].ToString());
                    txtCustomerCode.Text = drMaster["CustomerCode"].ToString();
                }

                //setGridSetup(true , )
            }
            catch (Exception ex)
            {
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
                if (dr == null)
                {
                    return;
                }
                decimal totalQty = 0;
                switch (e.Column.Name.ToString())
                {

                    //bsProducts.Filter = "SOrderId = " + -1 +"";
                    case "colSOrderId":
                        bsProducts.Filter = "SOrderId = " + dr["SOrderId"].ToString() + "";
                        break;
                    case "colProductId":

                        //bsProducts.Filter = "SOrderId = " + dr["SOrderId"].ToString() + "";
                        bsPendingSOProducts.Filter = "ProductId = '" + dr["ProductId"].ToString() + "' and SOrderId  = '" + dr["SOrderId"].ToString() + "'";
                        if (bsPendingSOProducts.List.Count > 0)
                        {
                            DataView dv = (DataView)bsPendingSOProducts.List;
                            dr["S39"] = dv[0]["S39"];
                            dr["S40"] = dv[0]["S40"];
                            dr["S41"] = dv[0]["S41"];
                            dr["S42"] = dv[0]["S42"];
                            dr["S43"] = dv[0]["S43"];
                            dr["S44"] = dv[0]["S44"];
                            dr["S45"] = dv[0]["S45"];
                            dr["S46"] = dv[0]["S46"];
                            dr["S47"] = dv[0]["S47"];
                            dr["GradeId"] = 1;// by default "A" wali value aye gi.

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

                            try
                            {
                                dr["Picture"] = dvProducts[0]["Picture"]; 
                               
                            }
                            catch (Exception imgex)
                            {

                            }
                        }
                        break;


                    case "colS39":

                        if (string.IsNullOrEmpty(dr["ProductId"].ToString()) || string.IsNullOrEmpty(dr["SOrderId"].ToString()))
                        {
                            MessageBox.Show("Sale Order Number or Product Name not Found.", "Make Sure Sale Order and Product Name Exists.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dr["S39"] = 0;
                            return;
                        }

                        bsPendingSOProducts.Filter = "ProductId = '" + dr["ProductId"].ToString() + "' and SOrderId  = '" + dr["SOrderId"].ToString() + "'";
                        if (bsPendingSOProducts.List.Count > 0)
                        {
                            DataView dv = (DataView)bsPendingSOProducts.List;
                            decimal S39 = 0;
                            S39 = Convert.ToDecimal(dv[0]["S39"]);
                            //tempraroy yeh Condition Comment ker raha hu q k Order k aginst mai maal dispatch nh hua
                            //if ((string.IsNullOrEmpty(dr["S39"].ToString()) ? 0 : Convert.ToDecimal(dr["S39"].ToString())) > S39)
                            //{
                            //    MessageBox.Show("The Pending Qty Should be Equal or Less Pending SO Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //    dr["S39"] = S39;
                            //}
                        }
                        else
                        {
                            dr["S39"] = 0;
                        }

                        //decimal totalQty = 0;
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

                        break;
                    case "colS40":

                        //if (dset.Tables["SOPendingQty"].Select("ProductId = '" + dr["ProductId"].ToString() + "'").Count() > 0)
                        //{
                        //    decimal S40 = 0;
                        //    S40 = Convert.ToDecimal(dset.Tables["SOPendingQty"].Select("ProductId = '" + dr["ProductId"].ToString() + "'")[0]["S40"]);
                        //    if ((string.IsNullOrEmpty(dr["S40"].ToString()) ? 0 : Convert.ToDecimal(dr["S40"].ToString())) > S40)
                        //    {
                        //        MessageBox.Show("The Pending Qty Should be Equal or Less Pending SO Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //        dr["S40"] = S40;
                        //    }
                        //}
                        if (string.IsNullOrEmpty(dr["ProductId"].ToString()) || string.IsNullOrEmpty(dr["SOrderId"].ToString()))
                        {
                            MessageBox.Show("Sale Order Number or Product Name not Found.", "Make Sure Sale Order and Product Name Exists.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dr["S40"] = 0;
                            return;
                        }
                        bsPendingSOProducts.Filter = "ProductId = '" + dr["ProductId"].ToString() + "' and SOrderId  = '" + dr["SOrderId"].ToString() + "'";
                        if (bsPendingSOProducts.List.Count > 0)
                        {
                            DataView dv = (DataView)bsPendingSOProducts.List;
                            decimal S40 = 0;
                            S40 = Convert.ToDecimal(dv[0]["S40"]);
                            //tempraroy yeh Condition Comment ker raha hu q k Order k aginst mai maal dispatch nh hua
                            //if ((string.IsNullOrEmpty(dr["S40"].ToString()) ? 0 : Convert.ToDecimal(dr["S40"].ToString())) > S40)
                            //{
                            //    MessageBox.Show("The Pending Qty Should be Equal or Less Pending SO Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //    dr["S40"] = S40;
                            //}
                        }
                        else
                        {
                            dr["S40"] = 0;
                        }

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

                        break;
                    case "colS41":

                        if (string.IsNullOrEmpty(dr["ProductId"].ToString()) || string.IsNullOrEmpty(dr["SOrderId"].ToString()))
                        {
                            MessageBox.Show("Sale Order Number or Product Name not Found.", "Make Sure Sale Order and Product Name Exists.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dr["S41"] = 0;
                            return;
                        }

                        //if (dset.Tables["SOPendingQty"].Select("ProductId = '" + dr["ProductId"].ToString() + "'").Count() > 0)
                        //{
                        //    decimal S41 = 0;
                        //    S41 = Convert.ToDecimal(dset.Tables["SOPendingQty"].Select("ProductId = '" + dr["ProductId"].ToString() + "'")[0]["S41"]);
                        //    if ((string.IsNullOrEmpty(dr["S41"].ToString()) ? 0 : Convert.ToDecimal(dr["S41"].ToString())) > S41)
                        //    {
                        //        MessageBox.Show("The Pending Qty Should be Equal or Less Pending SO Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //        dr["S41"] = S41;
                        //    }
                        //}

                        bsPendingSOProducts.Filter = "ProductId = '" + dr["ProductId"].ToString() + "' and SOrderId  = '" + dr["SOrderId"].ToString() + "'";
                        if (bsPendingSOProducts.List.Count > 0)
                        {
                            DataView dv = (DataView)bsPendingSOProducts.List;
                            decimal S41 = 0;
                            S41 = Convert.ToDecimal(dv[0]["S41"]);
                            //tempraroy yeh Condition Comment ker raha hu q k Order k aginst mai maal dispatch nh hua
                            //if ((string.IsNullOrEmpty(dr["S41"].ToString()) ? 0 : Convert.ToDecimal(dr["S41"].ToString())) > S41)
                            //{
                            //    MessageBox.Show("The Pending Qty Should be Equal or Less Pending SO Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //    dr["S41"] = S41;
                            //}
                        }
                        else
                        {
                            dr["S41"] = 0;
                        }



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

                        break;
                    case "colS42":

                        if (string.IsNullOrEmpty(dr["ProductId"].ToString()) || string.IsNullOrEmpty(dr["SOrderId"].ToString()))
                        {
                            MessageBox.Show("Sale Order Number or Product Name not Found.", "Make Sure Sale Order and Product Name Exists.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dr["S42"] = 0;
                            return;
                        }

                        //if (dset.Tables["SOPendingQty"].Select("ProductId = '" + dr["ProductId"].ToString() + "'").Count() > 0)
                        //{
                        //    decimal S42 = 0;
                        //    S42 = Convert.ToDecimal(dset.Tables["SOPendingQty"].Select("ProductId = '" + dr["ProductId"].ToString() + "'")[0]["S42"]);
                        //    if ((string.IsNullOrEmpty(dr["S42"].ToString()) ? 0 : Convert.ToDecimal(dr["S42"].ToString())) > S42)
                        //    {
                        //        MessageBox.Show("The Pending Qty Should be Equal or Less Pending SO Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //        dr["S42"] = S42;
                        //    }
                        //}

                        bsPendingSOProducts.Filter = "ProductId = '" + dr["ProductId"].ToString() + "' and SOrderId  = '" + dr["SOrderId"].ToString() + "'";
                        if (bsPendingSOProducts.List.Count > 0)
                        {
                            DataView dv = (DataView)bsPendingSOProducts.List;
                            decimal S42 = 0;
                            S42 = Convert.ToDecimal(dv[0]["S42"]);
                            //tempraroy yeh Condition Comment ker raha hu q k Order k aginst mai maal dispatch nh hua
                            //if ((string.IsNullOrEmpty(dr["S42"].ToString()) ? 0 : Convert.ToDecimal(dr["S42"].ToString())) > S42)
                            //{
                            //    MessageBox.Show("The Pending Qty Should be Equal or Less Pending SO Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //    dr["S42"] = S42;
                            //}
                        }
                        else
                        {
                            dr["S42"] = 0;
                        }


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

                        break;
                    case "colS43":

                        if (string.IsNullOrEmpty(dr["ProductId"].ToString()) || string.IsNullOrEmpty(dr["SOrderId"].ToString()))
                        {
                            MessageBox.Show("Sale Order Number or Product Name not Found.", "Make Sure Sale Order and Product Name Exists.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dr["S43"] = 0;
                            return;
                        }
                        //if (dset.Tables["SOPendingQty"].Select("ProductId = '" + dr["ProductId"].ToString() + "'").Count() > 0)
                        //{
                        //    decimal S43 = 0;
                        //    S43 = Convert.ToDecimal(dset.Tables["SOPendingQty"].Select("ProductId = '" + dr["ProductId"].ToString() + "'")[0]["S43"]);
                        //    if ((string.IsNullOrEmpty(dr["S43"].ToString()) ? 0 : Convert.ToDecimal(dr["S43"].ToString())) > S43)
                        //    {
                        //        MessageBox.Show("The Pending Qty Should be Equal or Less Pending SO Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //        dr["S43"] = S43;
                        //    }
                        //}

                        bsPendingSOProducts.Filter = "ProductId = '" + dr["ProductId"].ToString() + "' and SOrderId  = '" + dr["SOrderId"].ToString() + "'";
                        if (bsPendingSOProducts.List.Count > 0)
                        {
                            DataView dv = (DataView)bsPendingSOProducts.List;
                            decimal S43 = 0;
                            S43 = Convert.ToDecimal(dv[0]["S43"]);
                            //tempraroy yeh Condition Comment ker raha hu q k Order k aginst mai maal dispatch nh hua
                            //if ((string.IsNullOrEmpty(dr["S43"].ToString()) ? 0 : Convert.ToDecimal(dr["S43"].ToString())) > S43)
                            //{
                            //    MessageBox.Show("The Pending Qty Should be Equal or Less Pending SO Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //    dr["S43"] = S43;
                            //}
                        }
                        else
                        {
                            dr["S43"] = 0;
                        }

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
                        break;
                    case "colS44":

                        if (string.IsNullOrEmpty(dr["ProductId"].ToString()) || string.IsNullOrEmpty(dr["SOrderId"].ToString()))
                        {
                            MessageBox.Show("Sale Order Number or Product Name not Found.", "Make Sure Sale Order and Product Name Exists.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dr["S44"] = 0;
                            return;
                        }

                        //if (dset.Tables["SOPendingQty"].Select("ProductId = '" + dr["ProductId"].ToString() + "'").Count() > 0)
                        //{
                        //    decimal S44 = 0;
                        //    S44 = Convert.ToDecimal(dset.Tables["SOPendingQty"].Select("ProductId = '" + dr["ProductId"].ToString() + "'")[0]["S44"]);
                        //    if ((string.IsNullOrEmpty(dr["S44"].ToString()) ? 0 : Convert.ToDecimal(dr["S44"].ToString())) > S44)
                        //    {
                        //        MessageBox.Show("The Pending Qty Should be Equal or Less Pending SO Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //        dr["S44"] = S44;
                        //    }
                        //}
                        bsPendingSOProducts.Filter = "ProductId = '" + dr["ProductId"].ToString() + "' and SOrderId  = '" + dr["SOrderId"].ToString() + "'";
                        if (bsPendingSOProducts.List.Count > 0)
                        {
                            DataView dv = (DataView)bsPendingSOProducts.List;
                            decimal S44 = 0;
                            S44 = Convert.ToDecimal(dv[0]["S44"]);
                            //tempraroy yeh Condition Comment ker raha hu q k Order k aginst mai maal dispatch nh hua
                            //if ((string.IsNullOrEmpty(dr["S44"].ToString()) ? 0 : Convert.ToDecimal(dr["S44"].ToString())) > S44)
                            //{
                            //    MessageBox.Show("The Pending Qty Should be Equal or Less Pending SO Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //    dr["S44"] = S44;
                            //}
                        }
                        else
                        {
                            dr["S44"] = 0;
                        }

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

                        break;
                    case "colS45":

                        if (string.IsNullOrEmpty(dr["ProductId"].ToString()) || string.IsNullOrEmpty(dr["SOrderId"].ToString()))
                        {
                            MessageBox.Show("Sale Order Number or Product Name not Found.", "Make Sure Sale Order and Product Name Exists.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dr["S45"] = 0;
                            return;
                        }

                        //if (dset.Tables["SOPendingQty"].Select("ProductId = '" + dr["ProductId"].ToString() + "'").Count() > 0)
                        //{
                        //    decimal S45 = 0;
                        //    S45 = Convert.ToDecimal(dset.Tables["SOPendingQty"].Select("ProductId = '" + dr["ProductId"].ToString() + "'")[0]["S45"]);
                        //    if ((string.IsNullOrEmpty(dr["S45"].ToString()) ? 0 : Convert.ToDecimal(dr["S45"].ToString())) > S45)
                        //    {
                        //        MessageBox.Show("The Pending Qty Should be Equal or Less Pending SO Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //        dr["S45"] = S45;
                        //    }
                        //}

                        bsPendingSOProducts.Filter = "ProductId = '" + dr["ProductId"].ToString() + "' and SOrderId  = '" + dr["SOrderId"].ToString() + "'";
                        if (bsPendingSOProducts.List.Count > 0)
                        {
                            DataView dv = (DataView)bsPendingSOProducts.List;
                            decimal S45 = 0;
                            S45 = Convert.ToDecimal(dv[0]["S45"]);
                            //tempraroy yeh Condition Comment ker raha hu q k Order k aginst mai maal dispatch nh hua
                            //if ((string.IsNullOrEmpty(dr["S45"].ToString()) ? 0 : Convert.ToDecimal(dr["S45"].ToString())) > S45)
                            //{
                            //    MessageBox.Show("The Pending Qty Should be Equal or Less Pending SO Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //    dr["S45"] = S45;
                            //}
                        }
                        else
                        {
                            dr["S45"] = 0;
                        }

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

                        break;
                    case "colS46":
                        if (string.IsNullOrEmpty(dr["ProductId"].ToString()) || string.IsNullOrEmpty(dr["SOrderId"].ToString()))
                        {
                            MessageBox.Show("Sale Order Number or Product Name not Found.", "Make Sure Sale Order and Product Name Exists.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dr["S46"] = 0;
                            return;
                        }

                        //if (dset.Tables["SOPendingQty"].Select("ProductId = '" + dr["ProductId"].ToString() + "'").Count() > 0)
                        //{
                        //    decimal S46 = 0;
                        //    S46 = Convert.ToDecimal(dset.Tables["SOPendingQty"].Select("ProductId = '" + dr["ProductId"].ToString() + "'")[0]["S46"]);
                        //    if ((string.IsNullOrEmpty(dr["S46"].ToString()) ? 0 : Convert.ToDecimal(dr["S46"].ToString())) > S46)
                        //    {
                        //        MessageBox.Show("The Pending Qty Should be Equal or Less Pending SO Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //        dr["S46"] = S46;
                        //    }
                        //}

                        bsPendingSOProducts.Filter = "ProductId = '" + dr["ProductId"].ToString() + "' and SOrderId  = '" + dr["SOrderId"].ToString() + "'";
                        if (bsPendingSOProducts.List.Count > 0)
                        {
                            DataView dv = (DataView)bsPendingSOProducts.List;
                            decimal S46 = 0;
                            S46 = Convert.ToDecimal(dv[0]["S46"]);
                            //tempraroy yeh Condition Comment ker raha hu q k Order k aginst mai maal dispatch nh hua
                            //if ((string.IsNullOrEmpty(dr["S46"].ToString()) ? 0 : Convert.ToDecimal(dr["S46"].ToString())) > S46)
                            //{
                            //    MessageBox.Show("The Pending Qty Should be Equal or Less Pending SO Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //    dr["S46"] = S46;
                            //}
                        }
                        else
                        {
                            dr["S46"] = 0;
                        }
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

                        break;
                    case "colS47":

                        if (string.IsNullOrEmpty(dr["ProductId"].ToString()) || string.IsNullOrEmpty(dr["SOrderId"].ToString()))
                        {
                            MessageBox.Show("Sale Order Number or Product Name not Found.", "Make Sure Sale Order and Product Name Exists.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dr["S47"] = 0;
                            return;
                        }
                        //if (dset.Tables["SOPendingQty"].Select("ProductId = '" + dr["ProductId"].ToString() + "'").Count() > 0)
                        //{
                        //    decimal S47 = 0;
                        //    S47 = Convert.ToDecimal(dset.Tables["SOPendingQty"].Select("ProductId = '" + dr["ProductId"].ToString() + "'")[0]["S47"]);
                        //    if ((string.IsNullOrEmpty(dr["S47"].ToString()) ? 0 : Convert.ToDecimal(dr["S47"].ToString())) > S47)
                        //    {
                        //        MessageBox.Show("The Pending Qty Should be Equal or Less Pending SO Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //        dr["S47"] = S47;
                        //    }
                        //}

                        bsPendingSOProducts.Filter = "ProductId = '" + dr["ProductId"].ToString() + "' and SOrderId  = '" + dr["SOrderId"].ToString() + "'";
                        if (bsPendingSOProducts.List.Count > 0)
                        {
                            DataView dv = (DataView)bsPendingSOProducts.List;
                            decimal S47 = 0;
                            S47 = Convert.ToDecimal(dv[0]["S47"]);
                            //tempraroy yeh Condition Comment ker raha hu q k Order k aginst mai maal dispatch nh hua
                            //if ((string.IsNullOrEmpty(dr["S47"].ToString()) ? 0 : Convert.ToDecimal(dr["S47"].ToString())) > S47)
                            //{
                            //    MessageBox.Show("The Pending Qty Should be Equal or Less Pending SO Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //    dr["S47"] = S47;
                            //}
                        }
                        else
                        {
                            dr["S47"] = 0;
                        }

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
            //decimal TotalAmount = 0;
            try
            {
                foreach (DataRow dr in dset.Tables["PackingListDetail"].Rows)
                {
                    if (dr.RowState != DataRowState.Deleted)
                    {

                        try
                        {
                            TotalQty = TotalQty + Decimal.Parse(dr["OrderQty"].ToString());
                            //TotalAmount = TotalAmount + Decimal.Parse(dr["TotalAmount"].ToString());
                        }
                        catch
                        {
                            dr.BeginEdit();
                        }
                    }
                }

                txtTotalQty.Text = Math.Round(TotalQty, 0).ToString();
                //txtTotalAmount.Text = Math.Round(TotalAmount, 2).ToString();

                //txtNetTotal.Text = Math.Round(TotalAmount, 0).ToString();
                //txtDiscountPercent_Leave(null, null);

            }
            catch (Exception ex)
            {
                txtTotalQty.Text = Math.Round(TotalQty, 2).ToString();
            }
        }
        private void gvDetail_RowCountChanged(object sender, EventArgs e)
        {
            CalculateSummary();
            //txtDiscountPercent_Leave(null, null);
        }

        private void gvDetail_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gvDetail.GetFocusedDataRow();
            if ((dr != null))
            {
                try
                {
                    //if (!string.IsNullOrEmpty(dr["ProductId"].ToString()))
                    //{
                    //    //dvProducts.RowFilter = "ProductId='" + dr["ProductId"].ToString() + "'";
                    //    bsProducts.Filter = "SOrderId = " + -1 + "";
                    //    bsPendingSOProducts.Filter = "ProductId = '" + -1 + "' and SOrderId  = '" + -1 + "'";
                    //}
                    
                    bsProducts.Filter = "SOrderId = " + (string.IsNullOrEmpty(dr["SOrderId"].ToString()) ? -1 : Convert.ToInt32(dr["SOrderId"].ToString())) + "";
                    bsPendingSOProducts.Filter = "ProductId = '" + (string.IsNullOrEmpty(dr["ProductId"].ToString()) ? -1 : Convert.ToInt32(dr["ProductId"].ToString())) + "' and SOrderId  = '" + (string.IsNullOrEmpty(dr["SOrderId"].ToString()) ? -1 : Convert.ToInt32(dr["SOrderId"].ToString())) + "'";
                    dvProducts.RowFilter = "ProductId='" + dr["ProductId"].ToString() + "'";
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

                case "colOrderQty":
                    gvDetail.FocusedColumn = gvDetail.Columns.ColumnByName("colOrderQty");

                    break;
            }

            gvDetail.HideEditor();
        }

        private void gvDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow dr = default(DataRow);
            dr = gvDetail.GetDataRow(e.RowHandle);

            if (string.IsNullOrEmpty(dr["SOrderId"].ToString()))
            {
                e.ErrorText = "Sale Order Number not Found";
                e.Valid = false;
            }
            else if (Convert.ToInt32(dr["SOrderId"]) <= 0)
            {
                e.ErrorText = "Sale Order Number not Found";
                e.Valid = false;
            }

            else if (decimal.Parse(dr["ProductId"].ToString()) <= 0)
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
                if (dset.Tables["PackingListDetail"].Select("ProductId ='" + dr["ProductId"].ToString() + "' and SOrderId = '" + dr["SOrderId"].ToString() + "'").Length > 0)
                {
                    MessageBox.Show("Item Already Exists with Same Sale Order", "Same Items can not be repeated.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Valid = false;
                }
            }
            else
            {
                e.Valid = true;
                gvDetail.GetDataRow(e.RowHandle)["PackingListId"] = drMaster["PackingListId"]; //SalesMasterId;
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
            if (Convert.ToInt32(cmbWarehouse.SelectedValue) < 0)
            {
                MessageBox.Show("Please Select Warehouse Name.", "Warehouse is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbWarehouse.Focus();
                result = false;
                return result;
            }

            //if (string.IsNullOrEmpty(txtSONo.Text))
            //{
            //    MessageBox.Show("Please Select Sales Order Number.", "Sales Order Number is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtSONo.Focus();
            //    result = false;
            //    return result;
            //}

            if (string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                MessageBox.Show("Please Select Customer Code.", "Customer Code is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerCode.Focus();
                result = false;
                return result;

            }
            if (dset.Tables["PackingListDetail"].Rows.Count <= 0)
            {
                MessageBox.Show("Packing List Detail does not Found.", "Detail not Found.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void DeletePackingList()
        {
            if (string.IsNullOrEmpty(txtPackingNo.Text))
            {
                return;
            }
            try
            {
                ProductManager PM = new ProductManager();
                dataAcess.BeginTransaction();

                int status = managePackingList.DeletePackingListMaster(managePackingList.GetPackingListMasterIdByCode(txtPackingNo.Text), dataAcess);
                dataAcess.TransCommit();
                if (status > 0)
                {
                    MessageBox.Show("Packing List " + txtPackingNo.Text + " is Deleted.", "Packing List Delete Successful.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    DataTable dtPackingList = new DataTable();
                    dataAcess.BeginTransaction();
                    if (dataAcess.getDBCommand().Transaction == null)
                    {
                        dataAcess.SetDBTransaction();
                    }
                    dtPackingList = managePackingList.InsertPackingListMaster("", Convert.ToDateTime(dtpDate.Value.ToString()), DateTime.Now, Convert.ToInt32(cmbWarehouse.SelectedValue.ToString()), txtCustomerCode.Text , txtEmployeeCode.Text, (string.IsNullOrEmpty(txtTotalQty.Text) ? 0 : Convert.ToDecimal(txtTotalQty.Text)), false, txtRemarks.Text, txtGatePass.Text, MainForm.User_Id, DateTime.Now, "", dataAcess);
                    if (dtPackingList.Rows.Count > 0)
                    {
                        PackingListMasterId = Convert.ToInt32(dtPackingList.Rows[0]["Id"]);
                    }
                    else
                    {
                        throw new Exception("Id does not found");
                    }
                    if (PackingListMasterId > 0)
                    {
                        //DeleteProductionLedgerByTransNo
                        manageProcessing.DeleteProductionLedgerByTransNo(txtPackingNo.Text, dataAcess);

                        for (int i = 0; i < dset.Tables["PackingListDetail"].Rows.Count; i++)
                        {
                            if (dset.Tables["PackingListDetail"].Rows[i].RowState != DataRowState.Deleted)
                            {


                                int DetailId = managePackingList.InsertUpdatePackingListDetail(
                                    Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["PLDetailId"]), PackingListMasterId,
                                    Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["SOrderId"]),
                                    Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["ProductId"]),
                                    Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S39"]),
                                    Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S40"]),
                                    Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S41"]),
                                    Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S42"]),
                                    Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S43"]),
                                    Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S44"]),
                                    Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S45"]),
                                    Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S46"]),
                                    Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S47"]),
                                    Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["OrderQty"]),
                                    MainForm.User_Id, DateTime.Now, "", Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["GradeId"]) ,  dataAcess);

                                /* yahan ek masla hai Salman , k hum ne Product ledger mai ek Article pura out ker dia yani e:g AF-0009 k 100 pair, lakin sawal yeh hai k hum ne 
                                 yahan yeh nh btaya k kis size k kitne pair like 39 k 10 pair , 40 k 10 , 42 k 50 etc... toh mjy jo dout ho raha hai wo yeh k hum ko  yeh product ledger ki entry 8 baar kerni hogi as per Size
                                 lakin agr hum 8 baar kry toh sab ki Detail id toh ek hi hai , yahan Product ledger Update mai masla hoga or age chal ker takleef hogi. 20-03-18 */

                                //PM.InsertUpdateProductLedger(Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["ProductId"]),
                                //    Convert.ToDateTime(dtpDate.Value), dtPackingList.Rows[0]["PackingListNo"].ToString(),
                                //    DetailId, "O", Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["OrderQty"]), 
                                //    Convert.ToDecimal(0), Convert.ToDecimal(0),Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(0),
                                //    MainForm.User_Id, DateTime.Now.Date, "", "", null, Convert.ToInt32(cmbWarehouse.SelectedValue), -1, dataAcess);

                                int SizeId = -1;

                                //for Size 39
                                SizeId = PM.GetProductSizeIdByString("39");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S39"]) > 0)
                                    {
                                        PM.InsertProductLedger(Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["ProductId"]), Convert.ToDateTime(dtpDate.Value), txtPackingNo.Text.ToString(), DetailId, "O",
                                                                   Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S39"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 39 Out from Packing List", Convert.ToInt32(cmbWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["GradeId"]) == 2) ? "B" : "A"), dataAcess);
                                    }
                                }

                                //for Size 40
                                SizeId = PM.GetProductSizeIdByString("40");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S40"]) > 0)
                                    {
                                        PM.InsertProductLedger(Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["ProductId"]), Convert.ToDateTime(dtpDate.Value), txtPackingNo.Text.ToString(), DetailId, "O",
                                                                   Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S40"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 40 Out from Packing List", Convert.ToInt32(cmbWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["GradeId"]) == 2) ? "B" : "A"), dataAcess);
                                    }
                                }

                                //for Size 41
                                SizeId = PM.GetProductSizeIdByString("41");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S41"]) > 0)
                                    {
                                        PM.InsertProductLedger(Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["ProductId"]), Convert.ToDateTime(dtpDate.Value), txtPackingNo.Text.ToString(), DetailId, "O",
                                                                   Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S41"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 41 Out from Packing List", Convert.ToInt32(cmbWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["GradeId"]) == 2) ? "B" : "A"), dataAcess);
                                    }
                                }

                                //for Size 42
                                SizeId = PM.GetProductSizeIdByString("42");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S42"]) > 0)
                                    {
                                        PM.InsertProductLedger(Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["ProductId"]), Convert.ToDateTime(dtpDate.Value), txtPackingNo.Text.ToString(), DetailId, "O",
                                                                   Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S42"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 42 Out from Packing List", Convert.ToInt32(cmbWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["GradeId"]) == 2) ? "B" : "A"), dataAcess);
                                    }
                                }


                                //for Size 43
                                SizeId = PM.GetProductSizeIdByString("43");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S43"]) > 0)
                                    {
                                        PM.InsertProductLedger(Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["ProductId"]), Convert.ToDateTime(dtpDate.Value), txtPackingNo.Text.ToString(), DetailId, "O",
                                                                   Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S43"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 43 Out from Packing List", Convert.ToInt32(cmbWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["GradeId"]) == 2) ? "B" : "A"), dataAcess);
                                    }
                                }

                                //for Size 44
                                SizeId = PM.GetProductSizeIdByString("44");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S44"]) > 0)
                                    {
                                        PM.InsertProductLedger(Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["ProductId"]), Convert.ToDateTime(dtpDate.Value), txtPackingNo.Text.ToString(), DetailId, "O",
                                                                   Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S44"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 44 Out from Packing List", Convert.ToInt32(cmbWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["GradeId"]) == 2) ? "B" : "A"), dataAcess);
                                    }
                                }

                                //for Size 45
                                SizeId = PM.GetProductSizeIdByString("45");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S45"]) > 0)
                                    {
                                        PM.InsertProductLedger(Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["ProductId"]), Convert.ToDateTime(dtpDate.Value), txtPackingNo.Text.ToString(), DetailId, "O",
                                                                   Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S45"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 45 Out from Packing List", Convert.ToInt32(cmbWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["GradeId"]) == 2) ? "B" : "A"), dataAcess);
                                    }
                                }


                                //for Size 46
                                SizeId = PM.GetProductSizeIdByString("46");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S46"]) > 0)
                                    {
                                        PM.InsertProductLedger(Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["ProductId"]), Convert.ToDateTime(dtpDate.Value), txtPackingNo.Text.ToString(), DetailId, "O",
                                                                   Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S46"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 46 Out from Packing List", Convert.ToInt32(cmbWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["GradeId"]) == 2) ? "B" : "A"), dataAcess);
                                    }
                                }

                                //for Size 47
                                SizeId = PM.GetProductSizeIdByString("47");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S47"]) > 0)
                                    {
                                        PM.InsertProductLedger(Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["ProductId"]), Convert.ToDateTime(dtpDate.Value), txtPackingNo.Text.ToString(), DetailId, "O",
                                                                   Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S47"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 47 Out from Packing List", Convert.ToInt32(cmbWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["GradeId"]) == 2) ? "B" : "A"), dataAcess);
                                    }
                                }

                                //for Stock Out for Process Lining .
                                //yahan Warehouse Depart se Out hoga  Process Qty
                                manageProcessing.InsertUpdateProductionLedger(Convert.ToInt32(cmbWarehouse.SelectedValue), Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["ProductId"]) , -1 ,
                                    manageSalesOrder.GetSaleOrderNoBySOrderId(Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["SOrderId"]) ,dataAcess) ,  dtpDate.Value,  txtPackingNo.Text , DetailId, "O",
                                 Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["OrderQty"]), -1 , "Stock Out from Packing List", false, dataAcess);

                            }
                        }
                    }
                    dataAcess.TransCommit();
                    if (MessageBox.Show("Packing List " + txtPackingNo.Text + " has Saved." + Environment.NewLine + " Do you want to Print. ", "Packing List Saved Successful.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
                search.getattributes("GetSearchPackingList", null, "Packing List");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtPackingNo.Text = MainForm.Searched_Id;
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
                    if (managePackingList.IsPackingListClosed(PackingListMasterId))
                    {
                        MessageBox.Show("Sale Invoice is Create against " + txtPackingNo.Text + " Number", "Can't Modify or Changed in Packing List.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    ProductManager PM = new ProductManager();
                    dataAcess.BeginTransaction();
                    if (dataAcess.getDBCommand().Transaction == null)
                    {
                        dataAcess.SetDBTransaction();
                    }
                    foreach (int id in DeletedIds)
                    {
                        managePackingList.DeletePackingListDetailByDetailId(id, dataAcess);
                    }
                    //hum pehele ProductLedger se Clear kry gy than again insert.
                    PM.DeleteProductLedgerByTransNo(txtPackingNo.Text, dataAcess);

                    //DeleteProductionLedgerByTransNo
                    manageProcessing.DeleteProductionLedgerByTransNo(txtPackingNo.Text, dataAcess);

                    managePackingList.UpdatePackingList(PackingListMasterId, txtSONo.Text, Convert.ToDateTime(dtpDate.Value.ToString()), Convert.ToDateTime(dtpSODate.Value), Convert.ToInt32(cmbWarehouse.SelectedValue.ToString()), txtCustomerCode.Text, txtEmployeeCode.Text, (string.IsNullOrEmpty(txtTotalQty.Text) ? 0 : Convert.ToDecimal(txtTotalQty.Text)), false, txtRemarks.Text, txtGatePass.Text, MainForm.User_Id, DateTime.Now, "", dataAcess);
                    for (int i = 0; i < dset.Tables["PackingListDetail"].Rows.Count; i++)
                    {
                        if (dset.Tables["PackingListDetail"].Rows[i].RowState != DataRowState.Deleted)
                        {
                            DataRow drDetail = dset.Tables["PackingListDetail"].Rows[i];
                            int DetailId = managePackingList.InsertUpdatePackingListDetail(
                                 Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["PLDetailId"]), PackingListMasterId,
                                 Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["SOrderId"]),
                                 Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["ProductId"]),
                                 Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S39"]),
                                 Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S40"]),
                                 Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S41"]),
                                 Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S42"]),
                                 Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S43"]),
                                 Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S44"]),
                                 Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S45"]),
                                 Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S46"]),
                                 Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S47"]),
                                 Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["OrderQty"]),
                                 MainForm.User_Id, DateTime.Now, "", Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["GradeId"]), dataAcess);

                            int SizeId = -1;

                            //for Size 39
                            SizeId = PM.GetProductSizeIdByString("39");
                            if (SizeId > 0)
                            {
                                if (Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S39"]) > 0)
                                {
                                    PM.InsertProductLedger(Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["ProductId"]), Convert.ToDateTime(dtpDate.Value), txtPackingNo.Text.ToString(), DetailId, "O",
                                        Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S39"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 39 Out from Packing List", Convert.ToInt32(cmbWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["GradeId"])==2) ? "B" : "A"), dataAcess);
                                }
                            }

                            //for Size 40
                            SizeId = PM.GetProductSizeIdByString("40");
                            if (SizeId > 0)
                            {
                                if (Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S40"]) > 0)
                                {
                                    PM.InsertProductLedger(Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["ProductId"]), Convert.ToDateTime(dtpDate.Value), txtPackingNo.Text.ToString(), DetailId, "O",
                                                               Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S40"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 40 Out from Packing List", Convert.ToInt32(cmbWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["GradeId"]) == 2) ? "B" : "A"), dataAcess);
                                }
                            }

                            //for Size 41
                            SizeId = PM.GetProductSizeIdByString("41");
                            if (SizeId > 0)
                            {
                                if (Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S41"]) > 0)
                                {
                                    PM.InsertProductLedger(Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["ProductId"]), Convert.ToDateTime(dtpDate.Value), txtPackingNo.Text.ToString(), DetailId, "O",
                                                               Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S41"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 41 Out from Packing List", Convert.ToInt32(cmbWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["GradeId"]) == 2) ? "B" : "A"), dataAcess);
                                }
                            }

                            //for Size 42
                            SizeId = PM.GetProductSizeIdByString("42");
                            if (SizeId > 0)
                            {
                                if (Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S42"]) > 0)
                                {
                                    PM.InsertProductLedger(Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["ProductId"]), Convert.ToDateTime(dtpDate.Value), txtPackingNo.Text.ToString(), DetailId, "O",
                                                               Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S42"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 42 Out from Packing List", Convert.ToInt32(cmbWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["GradeId"]) == 2) ? "B" : "A"), dataAcess);
                                }
                            }


                            //for Size 43
                            SizeId = PM.GetProductSizeIdByString("43");
                            if (SizeId > 0)
                            {
                                if (Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S43"]) > 0)
                                {
                                    PM.InsertProductLedger(Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["ProductId"]), Convert.ToDateTime(dtpDate.Value), txtPackingNo.Text.ToString(), DetailId, "O",
                                                               Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S43"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 43 Out from Packing List", Convert.ToInt32(cmbWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["GradeId"]) == 2) ? "B" : "A"), dataAcess);
                                }
                            }

                            //for Size 44
                            SizeId = PM.GetProductSizeIdByString("44");
                            if (SizeId > 0)
                            {
                                if (Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S44"]) > 0)
                                {
                                    PM.InsertProductLedger(Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["ProductId"]), Convert.ToDateTime(dtpDate.Value), txtPackingNo.Text.ToString(), DetailId, "O",
                                                               Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S44"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 44 Out from Packing List", Convert.ToInt32(cmbWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["GradeId"]) == 2) ? "B" : "A"), dataAcess);
                                }
                            }

                            //for Size 45
                            SizeId = PM.GetProductSizeIdByString("45");
                            if (SizeId > 0)
                            {
                                if (Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S45"]) > 0)
                                {
                                    PM.InsertProductLedger(Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["ProductId"]), Convert.ToDateTime(dtpDate.Value), txtPackingNo.Text.ToString(), DetailId, "O",
                                                               Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S45"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 45 Out from Packing List", Convert.ToInt32(cmbWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["GradeId"]) == 2) ? "B" : "A"), dataAcess);
                                }
                            }


                            //for Size 46
                            SizeId = PM.GetProductSizeIdByString("46");
                            if (SizeId > 0)
                            {
                                if (Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S46"]) > 0)
                                {
                                    PM.InsertProductLedger(Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["ProductId"]), Convert.ToDateTime(dtpDate.Value), txtPackingNo.Text.ToString(), DetailId, "O",
                                                               Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S46"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 46 Out from Packing List", Convert.ToInt32(cmbWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["GradeId"]) == 2) ? "B" : "A"), dataAcess);
                                }
                            }

                            //for Size 47
                            SizeId = PM.GetProductSizeIdByString("47");
                            if (SizeId > 0)
                            {
                                if (Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S47"]) > 0)
                                {
                                    PM.InsertProductLedger(Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["ProductId"]), Convert.ToDateTime(dtpDate.Value), txtPackingNo.Text.ToString(), DetailId, "O",
                                                               Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["S47"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 47 Out from Packing List", Convert.ToInt32(cmbWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["GradeId"]) == 2) ? "B" : "A"), dataAcess);
                                }
                            }

                            //for Stock Out for Process Lining .
                            //yahan Warehouse Depart se Out hoga  Process Qty
                            manageProcessing.InsertUpdateProductionLedger(Convert.ToInt32(cmbWarehouse.SelectedValue), Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["ProductId"]), -1,
                                manageSalesOrder.GetSaleOrderNoBySOrderId(Convert.ToInt32(dset.Tables["PackingListDetail"].Rows[i]["SOrderId"]), dataAcess), dtpDate.Value, txtPackingNo.Text, DetailId, "O",
                             Convert.ToDecimal(dset.Tables["PackingListDetail"].Rows[i]["OrderQty"]), -1, "Stock Out from Packing List", false, dataAcess);

                        }
                    }
                    dataAcess.TransCommit();
                    if (MessageBox.Show("Packing List " + txtPackingNo.Text + " has Saved." + Environment.NewLine + " Do you want to Print. ", "Packing List Update Successful.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
                if (Convert.ToInt32(dr["PLDetailId"].ToString()) > 0)
                {
                    DeletedIds.Add(Convert.ToInt32(dr["PLDetailId"].ToString()));
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Packing List Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {

                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeletePackingList();
                        break;
                    }

            }
        }

        private void btnMinInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(managePackingList.GetMinPLNo()))
            {
                txtPackingNo.Text = managePackingList.GetMinPLNo();
                if (!string.IsNullOrEmpty(txtPackingNo.Text))
                {
                    //btnNextInvioceNo.Enabled = true;
                    //btnPrevInvioceNo.Enabled = false;
                }
            }
            
        }

        private void btnPrevInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPackingNo.Text))
            {
                string LastInvioceNo = managePackingList.GetMinPLNo();
                txtPackingNo.Text = managePackingList.GetPrevPLNo(txtPackingNo.Text);


                if (LastInvioceNo == txtPackingNo.Text)
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
            if (!string.IsNullOrEmpty(txtPackingNo.Text))
            {
                string LastInvioceNo = managePackingList.GetMaxPLNo();
                txtPackingNo.Text = managePackingList.GetNextPLNo(txtPackingNo.Text);

                if (LastInvioceNo == txtPackingNo.Text)
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
            if (!string.IsNullOrEmpty(managePackingList.GetMaxPLNo()))
            {
                txtPackingNo.Text = managePackingList.GetMaxPLNo();
                if (!string.IsNullOrEmpty(txtPackingNo.Text))
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
                if (string.IsNullOrEmpty(txtPackingNo.Text))
                {
                    return;
                }

                string path = Application.StartupPath + "/rpt/Sales/rptPackingList.rpt";
                ReportDocument document = new ReportDocument();
                document.Load(path);
                DataTable dtReport = new DataTable();
                dtReport = managePackingList.GetReportPackingList(PackingListMasterId);
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
            if (!string.IsNullOrEmpty(txtPackingNo.Text))
            {
                PackingListMasterId = managePackingList.GetPackingListMasterIdByCode(txtPackingNo.Text);
                if (PackingListMasterId > 0)
                {
                    IsPackingListLoad = true;
                    LoadPackingList();
                    IsPackingListLoad = false;
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

            //try
            //{
            //    if (e.Column.FieldName != "Picture") return;

            //    string ImageData = dvProducts[0]["Picture"].ToString();

            //    if (!string.IsNullOrEmpty(ImageData))
            //    {
            //        Image image = Base64ToImage(ImageData); //Image.FromFile("c:\\important.png");
            //        e.Value = image;
            //        //e.Graphics.DrawImage(image, e.Bounds.Location);
            //    }

            //    //RepositoryItemPictureEdit pictureEdit = gridControl1.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
            //    //pictureEdit.SizeMode = PictureSizeMode.Zoom;
            //    //pictureEdit.NullText = "";
            //    //gridView1.Columns["Picture"].ColumnEdit = pictureEdit;

            //}
            //catch (Exception ex)
            //{
            //}
        }

        //private void txtGSTPerc_Leave(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(txtGSTPerc.Text))
        //    {
        //        if (decimal.Parse(txtGSTPerc.Text) > 100)
        //        {
        //            txtGSTAmount.Text = "0";
        //            txtGSTPerc.Text = "0";
        //            txtNetTotal.Text = Math.Round(decimal.Parse(txtTotalAmount.Text), 0).ToString(); //+ decimal.Parse(tbxFreightCharges.Text);
        //            txtGSTPerc.Focus();
        //            //MessageBox.Show(Messages.Percentage, Messages.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //        else
        //        {
        //            txtGSTPerc.Text = Math.Round(decimal.Parse(txtGSTPerc.Text), 2).ToString();
        //            txtGSTAmount.Text = Math.Round(((decimal.Parse(txtTotalAmount.Text) * decimal.Parse(txtGSTPerc.Text)) / 100), 0).ToString();
        //            txtNetTotal.Text = Math.Round((decimal.Parse(txtTotalAmount.Text) + decimal.Parse((string.IsNullOrEmpty(txtGSTAmount.Text) ? "0" : txtGSTAmount.Text).ToString()) - decimal.Parse(txtDiscount.Text)), 0).ToString();
        //        }
        //    }
        //    else
        //    {
        //        txtGSTPerc.Text = "0";
        //        txtGSTPerc.Text = Math.Round(decimal.Parse(txtGSTPerc.Text), 2).ToString();
        //        txtGSTAmount.Text = Math.Round(((decimal.Parse(txtTotalAmount.Text) * decimal.Parse(txtGSTPerc.Text)) / 100), 0).ToString();
        //        txtNetTotal.Text = Math.Round((decimal.Parse(txtTotalAmount.Text) + decimal.Parse((string.IsNullOrEmpty(txtGSTAmount.Text) ? "0" : txtGSTAmount.Text).ToString()) - decimal.Parse(txtDiscount.Text)), 0).ToString();

        //    }
        //}

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

        private void btnSOSearch_Click(object sender, EventArgs e)
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

        private void txtSONo_TextChanged(object sender, EventArgs e)
        {
            if (IsPackingListLoad)
            {
                return;
            }
            if (!string.IsNullOrEmpty(txtSONo.Text))
            {
                LoadSalesOrder();
            }
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
                //e.Row
                bsProducts.Filter = "SOrderId = " + -1 + "";
                bsPendingSOProducts.Filter = "ProductId = '" + -1 + "' and SOrderId  = '" + -1 + "'";
            }
            catch (Exception ex)
            {
            }
        }

        private void btnCustomerSearch_Click(object sender, EventArgs e)
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




    }
}
