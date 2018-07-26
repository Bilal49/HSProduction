using CrystalDecisions.CrystalReports.Engine;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frmProductFormula : Form
    {
        Smartworks.DAL dataAcess = new Smartworks.DAL();
        ProductManager manageProduct = new ProductManager();
        Utility clsUtility = new Utility();
        BindingSource bsProduct = new BindingSource();
        BindingSource bsActualProduct = new BindingSource();
        BindingSource bsProductUnit = new BindingSource();
        BindingSource bsWarehouse = new BindingSource();
        BindingSource bsColor = new BindingSource();
        RepositoryItemGridLookUpEdit repositoryGridLookup = new RepositoryItemGridLookUpEdit();
        RepositoryItemGridLookUpEdit repositoryActualProductGridLookup = new RepositoryItemGridLookUpEdit();
        RepositoryItemGridLookUpEdit repositoryUnitGridLookup = new RepositoryItemGridLookUpEdit();
        RepositoryItemGridLookUpEdit repositoryWarehouseGridLookup = new RepositoryItemGridLookUpEdit();
        RepositoryItemGridLookUpEdit repositoryColorGridLookup = new RepositoryItemGridLookUpEdit();

        /*for Sub Detail Grid View*/
        BindingSource bsProductSubDetail = new BindingSource();
        BindingSource bsProductSize = new BindingSource();
        RepositoryItemGridLookUpEdit repositoryProdcutSubDetail = new RepositoryItemGridLookUpEdit();
        RepositoryItemGridLookUpEdit repositoryProdcutSize = new RepositoryItemGridLookUpEdit();
        /*************************/
        DataSet dsMain = null;
        DataSet dsGrid = null;
        DataRow drMaster;
        DataView dvProduct;
        DataViewManager dvm;
        int FormulaId = -1;
        public frmProductFormula()
        {
            InitializeComponent();
        }
        private void frmProductFormula_Load(object sender, EventArgs e)
        {
            try
            {
                ButtonRights(true);
                FillDropDown();
                setupGrip();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #region Method

        private void FillDropDown()
        {

            DataTable dtProduct = new DataTable();
            dtProduct = manageProduct.GetProductListForSemiAndFinish();

            DataRow drProduct = dtProduct.NewRow();
            drProduct["ProductId"] = -1;
            drProduct["ProductName"] = "--Select Product Name--";
            dtProduct.Rows.InsertAt(drProduct, 0);

            LastNoManager manageLast = new LastNoManager();
            DataTable dtLastNo = manageLast.GetLastNoList();
            DataRow drLast = dtLastNo.NewRow();
            drLast["LastNoId"] = -1;
            drLast["LastNo"] = "--Last No--";
            dtLastNo.Rows.InsertAt(drLast, 0);

            cmbLastNo.DataSource = dtLastNo;
            cmbLastNo.DisplayMember = "LastNo";
            cmbLastNo.ValueMember = "LastNoId";
            //cmbProduct.DataSource = dtProduct;
            //cmbProduct.DisplayMember = "ProductName";
            //cmbProduct.ValueMember = "ProductId";
        }
        private void setupGrip()
        {
            dsMain = new DataSet();
            dsMain = manageProduct.GetProductFormulaStructure(FormulaId);

            dsMain.Tables[0].TableName = "FormulaMaster";
            dsMain.Tables[1].TableName = "FormulaDetail";
            dsMain.Tables[2].TableName = "FormulaSubDetail";
            dsMain.Tables[3].TableName = "Products";
            dsMain.Tables[4].TableName = "MesurementUnit";
            dsMain.Tables[5].TableName = "FormulaConfig";
            dsMain.Tables[6].TableName = "Warehouse";
            dsMain.Tables[7].TableName = "Color";
            dsMain.Tables[8].TableName = "ProductSize";

            dsGrid = new DataSet();
            dsGrid.Tables.Add(dsMain.Tables["Warehouse"].Copy());
            dsGrid.Tables.Add(dsMain.Tables["FormulaDetail"].Copy());
            dsGrid.Tables.Add(dsMain.Tables["FormulaSubDetail"].Copy());


            dsMain.Tables["FormulaMaster"].Columns["FormulaMasterId"].AutoIncrement = true;
            dsMain.Tables["FormulaMaster"].Columns["FormulaMasterId"].AutoIncrementSeed = -1;
            dsMain.Tables["FormulaMaster"].Columns["FormulaMasterId"].AutoIncrementStep = -1;

            dsMain.Tables["FormulaDetail"].Columns["FormulaDetailId"].AutoIncrement = true;
            dsMain.Tables["FormulaDetail"].Columns["FormulaDetailId"].AutoIncrementSeed = -1;
            dsMain.Tables["FormulaDetail"].Columns["FormulaDetailId"].AutoIncrementStep = -1;





            dsGrid.Tables["FormulaDetail"].Columns["FormulaDetailId"].AutoIncrement = true;
            dsGrid.Tables["FormulaDetail"].Columns["FormulaDetailId"].AutoIncrementSeed = -1;
            dsGrid.Tables["FormulaDetail"].Columns["FormulaDetailId"].AutoIncrementStep = -1;

            dsGrid.Tables["FormulaSubDetail"].Columns["FomulaSubDetailId"].AutoIncrement = true;
            dsGrid.Tables["FormulaSubDetail"].Columns["FomulaSubDetailId"].AutoIncrementSeed = -1;
            dsGrid.Tables["FormulaSubDetail"].Columns["FomulaSubDetailId"].AutoIncrementStep = -1;



            dsMain.Relations.Add("MasterRelation", dsMain.Tables["FormulaMaster"].Columns["FormulaMasterId"], dsMain.Tables["FormulaDetail"].Columns["FormulaMasterId"]);

            dsGrid.Relations.Add("WarehouseRelation", dsGrid.Tables["Warehouse"].Columns["WarehouseId"], dsGrid.Tables["FormulaDetail"].Columns["WarehouseId"]);
            //for sub detail Relation
            dsGrid.Relations.Add("SubDetailRelation", dsGrid.Tables["FormulaDetail"].Columns["FormulaDetailId"], dsGrid.Tables["FormulaSubDetail"].Columns["FormulaDetailId"]);

            drMaster = dsMain.Tables["FormulaMaster"].NewRow();
            dsMain.Tables["FormulaMaster"].Rows.Add(drMaster);
            dvm = new DataViewManager(dsMain);
            dvProduct = dvm.CreateDataView(dsMain.Tables["Products"]);

            GCDetail.DataSource = dsGrid; //dsGrid.Tables["Warehouse"]; //dsMain.Tables["FormulaDetail"];
            GCDetail.DataMember = "Warehouse";
            GCDetail.ForceInitialize();


            gvDetail.Columns.ColumnByName("colWarehouseId").Visible = false;

            gvDetail.Columns.ColumnByName("colWarehouseName").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colWarehouseName").Caption = "";
            gvDetail.Columns.ColumnByName("colWarehouseName").Width = GCDetail.Width - 150;
            gvDetail.OptionsView.ShowViewCaption = false;
            gvDetail.Columns.ColumnByName("colWarehouseName").AppearanceCell.Font = new Font("Arial", 10f, FontStyle.Bold);
            //gvDetail.Columns.ColumnByName("colWarehouseName").AppearanceCell.BackColor = Color.LightGreen;
            gvDetail.DetailHeight = 500;
            //gvDetail.Appearance.Row.Font = new Font("Arial", 12f);
            //gvDetail.Columns.ColumnByName("colWarehouseName").
            //GridSetting();

            if (dsGrid.Tables["FormulaDetail"].Rows.Count == 0)
            {
                if (dsMain.Tables["FormulaConfig"].Rows.Count > 0)
                {
                    foreach (DataRow drConfig in dsMain.Tables["FormulaConfig"].Rows)
                    {
                        DataRow drDetail = dsGrid.Tables["FormulaDetail"].NewRow();
                        drDetail["FormulaMasterId"] = drMaster["FormulaMasterId"];
                        drDetail["WarehouseId"] = drConfig["WarehouseId"];
                        drDetail["ProductId"] = drConfig["ProductId"];
                        drDetail["UnitId"] = drConfig["UnitId"];
                        drDetail["Qty"] = 0;
                        dsGrid.Tables["FormulaDetail"].Rows.Add(drDetail);
                    }
                }
            }
        }

        private void GridSetting()
        {


            //(e.View as GridView).Columns["ticket_number"].Visible = false;
            gvDetail.Columns.ColumnByName("colFormulaDetailId").OptionsColumn.ReadOnly = true;
            gvDetail.Columns.ColumnByName("colFormulaMasterId").OptionsColumn.ReadOnly = true;

            gvDetail.Columns.ColumnByName("colFormulaDetailId").Visible = false;
            gvDetail.Columns.ColumnByName("colFormulaMasterId").Visible = false;

            gvDetail.Columns.ColumnByName("colProductId").Caption = "Raw Material Name";
            gvDetail.Columns.ColumnByName("colActualProductId").Caption = "Material Name";
            gvDetail.Columns.ColumnByName("colUnitId").Caption = "Unit Name";
            gvDetail.Columns.ColumnByName("colQty").Caption = "Quantity";
            gvDetail.Columns.ColumnByName("colWarehouseId").Caption = "Warehouse";
            gvDetail.Columns.ColumnByName("colRemarks").Caption = "Calculation";

            gvDetail.Columns.ColumnByName("colWarehouseId").VisibleIndex = 0;
            gvDetail.Columns.ColumnByName("colProductId").VisibleIndex = 1;
            gvDetail.Columns.ColumnByName("colActualProductId").VisibleIndex = 2;
            gvDetail.Columns.ColumnByName("colUnitId").VisibleIndex = 3;
            gvDetail.Columns.ColumnByName("colQty").VisibleIndex = 4;
            gvDetail.Columns.ColumnByName("colRemarks").VisibleIndex = 5;

            gvDetail.Columns.ColumnByName("colWarehouseId").Width = 120;
            gvDetail.Columns.ColumnByName("colProductId").Width = 250;
            gvDetail.Columns.ColumnByName("colActualProductId").Width = 250;
            gvDetail.Columns.ColumnByName("colUnitId").Width = 60;
            gvDetail.Columns.ColumnByName("colQty").Width = 50;
            gvDetail.Columns.ColumnByName("colRemarks").Width = 120;

            bsProduct.DataSource = dsMain;
            bsProduct.DataMember = "Products";

            bsActualProduct.DataSource = dsMain;
            bsActualProduct.DataMember = "Products";


            bsProductUnit.DataSource = dsMain;
            bsProductUnit.DataMember = "MesurementUnit";

            bsWarehouse.DataSource = dsMain;
            bsWarehouse.DataMember = "Warehouse";


            repositoryGridLookup.DataSource = bsProduct;
            repositoryGridLookup.DisplayMember = "ProductName";
            repositoryGridLookup.ValueMember = "ProductId";
            repositoryGridLookup.PopupFormSize = new Size(500, 200);
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
                repositoryGridLookup.View.Columns.ColumnByName("colMesurementUnitId").Visible = false;

                repositoryGridLookup.View.Columns.ColumnByName("colProductCode").Caption = "Code";
                repositoryGridLookup.View.Columns.ColumnByName("colProductName").Caption = "Product Name";
                repositoryGridLookup.View.Columns.ColumnByName("colProductNature").Caption = "Product Name";
                repositoryGridLookup.View.Columns.ColumnByName("colCategoryName").Caption = "Category";


                repositoryGridLookup.View.Columns.ColumnByName("colProductCode").Width = 80;
                repositoryGridLookup.View.Columns.ColumnByName("colProductName").Width = 150;
                repositoryGridLookup.View.Columns.ColumnByName("colProductNature").Width = 80;
                repositoryGridLookup.View.Columns.ColumnByName("colCategoryName").Width = 100;

                repositoryGridLookup.View.Columns.ColumnByName("colProductCode").VisibleIndex = 0;
                repositoryGridLookup.View.Columns.ColumnByName("colProductName").VisibleIndex = 1;
                repositoryGridLookup.View.Columns.ColumnByName("colProductNature").VisibleIndex = 2;
                repositoryGridLookup.View.Columns.ColumnByName("colCategoryName").VisibleIndex = 3;
            }

            //*************************************************
            repositoryUnitGridLookup.DataSource = bsProductUnit;
            repositoryUnitGridLookup.DisplayMember = "MesurementName";
            repositoryUnitGridLookup.ValueMember = "MesurementId";
            repositoryUnitGridLookup.PopupFormSize = new Size(130, 100);
            repositoryUnitGridLookup.NullText = "";
            repositoryUnitGridLookup.ShowFooter = false;
            repositoryUnitGridLookup.View.OptionsView.ColumnAutoWidth = false;
            repositoryUnitGridLookup.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            repositoryUnitGridLookup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            repositoryUnitGridLookup.ImmediatePopup = true;
            repositoryUnitGridLookup.PopulateViewColumns();
            GCDetail.RepositoryItems.Add(repositoryUnitGridLookup);

            (GCDetail.MainView as GridView).Columns.ColumnByName("colUnitId").ColumnEdit = repositoryUnitGridLookup;

            if (repositoryUnitGridLookup.View.Columns.Count > 0)
            {
                repositoryUnitGridLookup.View.Columns.ColumnByName("colMesurementId").Visible = false;
                repositoryUnitGridLookup.View.Columns.ColumnByName("colMesurementName").Caption = "Product Unit";
                repositoryUnitGridLookup.View.Columns.ColumnByName("colMesurementName").Width = 150;
                repositoryUnitGridLookup.View.Columns.ColumnByName("colMesurementName").VisibleIndex = 0;
            }

            //************************************************************
            repositoryWarehouseGridLookup.DataSource = bsWarehouse;
            repositoryWarehouseGridLookup.DisplayMember = "WarehouseName";
            repositoryWarehouseGridLookup.ValueMember = "WarehouseId";
            repositoryWarehouseGridLookup.PopupFormSize = new Size(130, 100);
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
                repositoryWarehouseGridLookup.View.Columns.ColumnByName("colWarehouseName").Caption = "Department";
                repositoryWarehouseGridLookup.View.Columns.ColumnByName("colWarehouseName").Width = 150;
                repositoryWarehouseGridLookup.View.Columns.ColumnByName("colWarehouseName").VisibleIndex = 0;
            }


            //*********************************************
            repositoryActualProductGridLookup.DataSource = bsProduct;
            repositoryActualProductGridLookup.DisplayMember = "ProductName";
            repositoryActualProductGridLookup.ValueMember = "ProductId";
            repositoryActualProductGridLookup.PopupFormSize = new Size(500, 200);
            repositoryActualProductGridLookup.NullText = "";
            repositoryActualProductGridLookup.ShowFooter = false;
            repositoryActualProductGridLookup.View.OptionsView.ColumnAutoWidth = false;
            repositoryActualProductGridLookup.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            repositoryActualProductGridLookup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            repositoryActualProductGridLookup.ImmediatePopup = true;
            repositoryActualProductGridLookup.PopulateViewColumns();
            GCDetail.RepositoryItems.Add(repositoryActualProductGridLookup);

            (GCDetail.MainView as GridView).Columns.ColumnByName("colActualProductId").ColumnEdit = repositoryActualProductGridLookup;

            if (repositoryActualProductGridLookup.View.Columns.Count > 0)
            {
                repositoryActualProductGridLookup.View.Columns.ColumnByName("colProductId").Visible = false;
                repositoryActualProductGridLookup.View.Columns.ColumnByName("colMesurementUnitId").Visible = false;

                repositoryActualProductGridLookup.View.Columns.ColumnByName("colProductCode").Caption = "Code";
                repositoryActualProductGridLookup.View.Columns.ColumnByName("colProductName").Caption = "Product Name";
                repositoryActualProductGridLookup.View.Columns.ColumnByName("colProductNature").Caption = "Product Name";
                repositoryActualProductGridLookup.View.Columns.ColumnByName("colCategoryName").Caption = "Category";


                repositoryActualProductGridLookup.View.Columns.ColumnByName("colProductCode").Width = 80;
                repositoryActualProductGridLookup.View.Columns.ColumnByName("colProductName").Width = 150;
                repositoryActualProductGridLookup.View.Columns.ColumnByName("colProductNature").Width = 80;
                repositoryActualProductGridLookup.View.Columns.ColumnByName("colCategoryName").Width = 100;

                repositoryActualProductGridLookup.View.Columns.ColumnByName("colProductCode").VisibleIndex = 0;
                repositoryActualProductGridLookup.View.Columns.ColumnByName("colProductName").VisibleIndex = 1;
                repositoryActualProductGridLookup.View.Columns.ColumnByName("colProductNature").VisibleIndex = 2;
                repositoryActualProductGridLookup.View.Columns.ColumnByName("colCategoryName").VisibleIndex = 3;
            }
        }


        private void gvDetail_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView gridViewWelds = sender as GridView;
            GridView gridViewTests = gridViewWelds.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;

            gridViewTests.MasterRowExpanded += gvSubDetail_MasterRowExpanded;
            gridViewTests.MasterRowExpanding += gvSubDetail_MasterRowExpanding;
            gridViewTests.RowStyle += gvDetailCustom_RowStyle;
            //gridViewTests.ShownEditor += ShownEditor;
            gridViewTests.DetailHeight = 500;

            //gvSubDetail_MasterRowExpanding
            //gridViewTests.MasterRowExpanded += new CustomMasterRowEventArgs(gvSubDetail_MasterRowExpanded);
            //gridViewTests.MasterRowExpanded += new CustomMasterRowEventHandler(gridViewTests_MasterRowExpanded);
            gridViewTests.BeginUpdate();
            //gridViewTests.Columns["Id"].Visible = false;
            //gridViewTests.Columns["Id"].OptionsColumn.ShowInCustomizationForm = false;
            //gridViewTests.Columns["WeldId"].Visible = false;
            //gridViewTests.Columns["WeldId"].OptionsColumn.ShowInCustomizationForm = false;
            gridViewTests.Columns.ColumnByName("colFormulaDetailId").OptionsColumn.ReadOnly = true;
            gridViewTests.Columns.ColumnByName("colFormulaMasterId").OptionsColumn.ReadOnly = true;

            gridViewTests.Columns.ColumnByName("colFormulaDetailId").Visible = false;
            gridViewTests.Columns.ColumnByName("colFormulaMasterId").Visible = false;
            gridViewTests.Columns.ColumnByName("colWarehouseId").Visible = false;


            gridViewTests.Columns.ColumnByName("colProductId").Caption = "Material Description";
            gridViewTests.Columns.ColumnByName("colActualProductId").Caption = "Article";
            gridViewTests.Columns.ColumnByName("colColorId").Caption = "Colour";
            gridViewTests.Columns.ColumnByName("colUnitId").Caption = "Unit";
            gridViewTests.Columns.ColumnByName("colQty").Caption = "Estimated Req.";
            //gridViewTests.Columns.ColumnByName("colWarehouseId").Caption = "Warehouse";
            gridViewTests.Columns.ColumnByName("colRemarks").Caption = "Remarks";

            //gridViewTests.Columns.ColumnByName("colWarehouseId").VisibleIndex = 0;
            gridViewTests.Columns.ColumnByName("colProductId").VisibleIndex = 1;
            gridViewTests.Columns.ColumnByName("colActualProductId").VisibleIndex = 2;
            gridViewTests.Columns.ColumnByName("colColorId").VisibleIndex = 3;
            gridViewTests.Columns.ColumnByName("colUnitId").VisibleIndex = 4;
            gridViewTests.Columns.ColumnByName("colRemarks").VisibleIndex = 5;
            gridViewTests.Columns.ColumnByName("colQty").VisibleIndex = 6;

            //gridViewTests.Columns.ColumnByName("colWarehouseId").Width = 120;
            gridViewTests.Columns.ColumnByName("colProductId").Width = 250;
            gridViewTests.Columns.ColumnByName("colActualProductId").Width = 250;
            gridViewTests.Columns.ColumnByName("colColorId").Width = 120;
            gridViewTests.Columns.ColumnByName("colUnitId").Width = 80;
            gridViewTests.Columns.ColumnByName("colQty").Width = 100;
            gridViewTests.Columns.ColumnByName("colRemarks").Width = 120;

            bsProduct.DataSource = dsMain;
            bsProduct.DataMember = "Products";

            bsActualProduct.DataSource = dsMain;
            bsActualProduct.DataMember = "Products";


            bsProductUnit.DataSource = dsMain;
            bsProductUnit.DataMember = "MesurementUnit";

            bsWarehouse.DataSource = dsMain;
            bsWarehouse.DataMember = "Warehouse";

            bsColor.DataSource = dsMain;
            bsColor.DataMember = "Color";


            repositoryGridLookup.DataSource = bsProduct;
            repositoryGridLookup.DisplayMember = "ProductName";
            repositoryGridLookup.ValueMember = "ProductId";
            repositoryGridLookup.PopupFormSize = new Size(600, 200);
            repositoryGridLookup.NullText = "";
            repositoryGridLookup.ShowFooter = false;
            repositoryGridLookup.View.OptionsView.ColumnAutoWidth = false;
            repositoryGridLookup.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            repositoryGridLookup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            repositoryGridLookup.ImmediatePopup = true;
            repositoryGridLookup.PopulateViewColumns();
            GCDetail.RepositoryItems.Add(repositoryGridLookup);

            gridViewTests.Columns.ColumnByName("colProductId").ColumnEdit = repositoryGridLookup;
            //(GCDetail.MainView as GridView).Columns.ColumnByName("colProductId").ColumnEdit = repositoryGridLookup;

            if (repositoryGridLookup.View.Columns.Count > 0)
            {
                repositoryGridLookup.View.Columns.ColumnByName("colProductId").Visible = false;
                repositoryGridLookup.View.Columns.ColumnByName("colMesurementUnitId").Visible = false;

                repositoryGridLookup.View.Columns.ColumnByName("colProductCode").Caption = "Code";
                repositoryGridLookup.View.Columns.ColumnByName("colProductName").Caption = "Product Name";
                repositoryGridLookup.View.Columns.ColumnByName("colProductNature").Caption = "Product Name";
                repositoryGridLookup.View.Columns.ColumnByName("colCategoryName").Caption = "Category";


                repositoryGridLookup.View.Columns.ColumnByName("colProductCode").Width = 80;
                repositoryGridLookup.View.Columns.ColumnByName("colProductName").Width = 250;
                repositoryGridLookup.View.Columns.ColumnByName("colProductNature").Width = 80;
                repositoryGridLookup.View.Columns.ColumnByName("colCategoryName").Width = 100;

                repositoryGridLookup.View.Columns.ColumnByName("colProductCode").VisibleIndex = 0;
                repositoryGridLookup.View.Columns.ColumnByName("colProductName").VisibleIndex = 1;
                repositoryGridLookup.View.Columns.ColumnByName("colProductNature").VisibleIndex = 2;
                repositoryGridLookup.View.Columns.ColumnByName("colCategoryName").VisibleIndex = 3;
            }

            //*************************************************
            repositoryUnitGridLookup.DataSource = bsProductUnit;
            repositoryUnitGridLookup.DisplayMember = "MesurementName";
            repositoryUnitGridLookup.ValueMember = "MesurementId";
            repositoryUnitGridLookup.PopupFormSize = new Size(130, 100);
            repositoryUnitGridLookup.NullText = "";
            repositoryUnitGridLookup.ShowFooter = false;
            repositoryUnitGridLookup.View.OptionsView.ColumnAutoWidth = false;
            repositoryUnitGridLookup.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            repositoryUnitGridLookup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            repositoryUnitGridLookup.ImmediatePopup = true;
            repositoryUnitGridLookup.PopulateViewColumns();
            GCDetail.RepositoryItems.Add(repositoryUnitGridLookup);

            gridViewTests.Columns.ColumnByName("colUnitId").ColumnEdit = repositoryUnitGridLookup;
            //(GCDetail.MainView as GridView).Columns.ColumnByName("colUnitId").ColumnEdit = repositoryUnitGridLookup;

            if (repositoryUnitGridLookup.View.Columns.Count > 0)
            {
                repositoryUnitGridLookup.View.Columns.ColumnByName("colMesurementId").Visible = false;
                repositoryUnitGridLookup.View.Columns.ColumnByName("colMesurementName").Caption = "Product Unit";
                repositoryUnitGridLookup.View.Columns.ColumnByName("colMesurementName").Width = 150;
                repositoryUnitGridLookup.View.Columns.ColumnByName("colMesurementName").VisibleIndex = 0;
            }

            //************************************************************
            repositoryWarehouseGridLookup.DataSource = bsWarehouse;
            repositoryWarehouseGridLookup.DisplayMember = "WarehouseName";
            repositoryWarehouseGridLookup.ValueMember = "WarehouseId";
            repositoryWarehouseGridLookup.PopupFormSize = new Size(130, 100);
            repositoryWarehouseGridLookup.NullText = "";
            repositoryWarehouseGridLookup.ShowFooter = false;
            repositoryWarehouseGridLookup.View.OptionsView.ColumnAutoWidth = false;
            repositoryWarehouseGridLookup.PopulateViewColumns();
            GCDetail.RepositoryItems.Add(repositoryWarehouseGridLookup);

            gridViewTests.Columns.ColumnByName("colWarehouseId").ColumnEdit = repositoryWarehouseGridLookup;
            //(GCDetail.MainView as GridView).Columns.ColumnByName("colWarehouseId").ColumnEdit = repositoryWarehouseGridLookup;

            if (repositoryWarehouseGridLookup.View.Columns.Count > 0)
            {
                repositoryWarehouseGridLookup.View.Columns.ColumnByName("colWarehouseId").Visible = false;
                repositoryWarehouseGridLookup.View.Columns.ColumnByName("colWarehouseName").Caption = "Department";
                repositoryWarehouseGridLookup.View.Columns.ColumnByName("colWarehouseName").Width = 150;
                repositoryWarehouseGridLookup.View.Columns.ColumnByName("colWarehouseName").VisibleIndex = 0;
            }


            //*********************************************
            repositoryActualProductGridLookup.DataSource = bsProduct;
            repositoryActualProductGridLookup.DisplayMember = "ProductName";
            repositoryActualProductGridLookup.ValueMember = "ProductId";
            repositoryActualProductGridLookup.PopupFormSize = new Size(550, 200);
            repositoryActualProductGridLookup.NullText = "";
            repositoryActualProductGridLookup.ShowFooter = false;
            repositoryActualProductGridLookup.View.OptionsView.ColumnAutoWidth = false;
            repositoryActualProductGridLookup.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            repositoryActualProductGridLookup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            repositoryActualProductGridLookup.ImmediatePopup = true;
            repositoryActualProductGridLookup.PopulateViewColumns();
            GCDetail.RepositoryItems.Add(repositoryActualProductGridLookup);

            gridViewTests.Columns.ColumnByName("colActualProductId").ColumnEdit = repositoryActualProductGridLookup;
            // (GCDetail.MainView as GridView).Columns.ColumnByName("colActualProductId").ColumnEdit = repositoryActualProductGridLookup;

            if (repositoryActualProductGridLookup.View.Columns.Count > 0)
            {
                repositoryActualProductGridLookup.View.Columns.ColumnByName("colProductId").Visible = false;
                repositoryActualProductGridLookup.View.Columns.ColumnByName("colMesurementUnitId").Visible = false;

                repositoryActualProductGridLookup.View.Columns.ColumnByName("colProductCode").Caption = "Code";
                repositoryActualProductGridLookup.View.Columns.ColumnByName("colProductName").Caption = "Product Name";
                repositoryActualProductGridLookup.View.Columns.ColumnByName("colProductNature").Caption = "Product Name";
                repositoryActualProductGridLookup.View.Columns.ColumnByName("colCategoryName").Caption = "Category";


                repositoryActualProductGridLookup.View.Columns.ColumnByName("colProductCode").Width = 80;
                repositoryActualProductGridLookup.View.Columns.ColumnByName("colProductName").Width = 250;
                repositoryActualProductGridLookup.View.Columns.ColumnByName("colProductNature").Width = 80;
                repositoryActualProductGridLookup.View.Columns.ColumnByName("colCategoryName").Width = 100;

                repositoryActualProductGridLookup.View.Columns.ColumnByName("colProductCode").VisibleIndex = 0;
                repositoryActualProductGridLookup.View.Columns.ColumnByName("colProductName").VisibleIndex = 1;
                repositoryActualProductGridLookup.View.Columns.ColumnByName("colProductNature").VisibleIndex = 2;
                repositoryActualProductGridLookup.View.Columns.ColumnByName("colCategoryName").VisibleIndex = 3;
            }


            //******************************

            repositoryColorGridLookup.DataSource = bsColor;
            repositoryColorGridLookup.DisplayMember = "ColorName";
            repositoryColorGridLookup.ValueMember = "ColorId";
            repositoryColorGridLookup.PopupFormSize = new Size(130, 100);
            repositoryColorGridLookup.NullText = "";
            repositoryColorGridLookup.ShowFooter = false;
            repositoryColorGridLookup.View.OptionsView.ColumnAutoWidth = false;
            repositoryColorGridLookup.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            repositoryColorGridLookup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            repositoryColorGridLookup.ImmediatePopup = true;
            repositoryColorGridLookup.PopulateViewColumns();
            GCDetail.RepositoryItems.Add(repositoryColorGridLookup);

            gridViewTests.Columns.ColumnByName("colColorId").ColumnEdit = repositoryColorGridLookup;
            //(GCDetail.MainView as GridView).Columns.ColumnByName("colWarehouseId").ColumnEdit = repositoryWarehouseGridLookup;

            if (repositoryColorGridLookup.View.Columns.Count > 0)
            {
                repositoryColorGridLookup.View.Columns.ColumnByName("colColorId").Visible = false;
                repositoryColorGridLookup.View.Columns.ColumnByName("colColorName").Caption = "Colour";
                repositoryColorGridLookup.View.Columns.ColumnByName("colColorName").Width = 150;
                repositoryColorGridLookup.View.Columns.ColumnByName("colColorName").VisibleIndex = 0;
            }

            gridViewTests.EndUpdate();
        }


        private void gvSubDetail_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            try
            {
                GridView gridViewWelds = sender as GridView;
                GridView gridViewTests = gridViewWelds.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
                gridViewTests.RowStyle += gvSubCustom_RowStyle;
                gridViewTests.DetailHeight = 500;
                gridViewTests.BeginUpdate();

                gridViewTests.Columns.ColumnByName("colFomulaSubDetailId").OptionsColumn.ReadOnly = true;
                gridViewTests.Columns.ColumnByName("colFormulaDetailId").OptionsColumn.ReadOnly = true;
                gridViewTests.Columns.ColumnByName("colFormulaMasterId").OptionsColumn.ReadOnly = true;

                gridViewTests.Columns.ColumnByName("colFomulaSubDetailId").Visible = false;
                gridViewTests.Columns.ColumnByName("colFormulaDetailId").Visible = false;
                gridViewTests.Columns.ColumnByName("colFormulaMasterId").Visible = false;

                //abhi Faraz seth se bat hui toh Qty wala column kaam nh aye ga master qty hi sab per apply hogi.

                gridViewTests.Columns.ColumnByName("colQty").Visible = false;


                gridViewTests.Columns.ColumnByName("colProductId").Caption = "Materail Name";
                gridViewTests.Columns.ColumnByName("colSizeId").Caption = "Size";
                //gridViewTests.Columns.ColumnByName("colQty").Caption = "Quantity";


                gridViewTests.Columns.ColumnByName("colProductId").VisibleIndex = 2;
                gridViewTests.Columns.ColumnByName("colSizeId").VisibleIndex = 1;
                //gridViewTests.Columns.ColumnByName("colQty").VisibleIndex = 3;


                gridViewTests.Columns.ColumnByName("colProductId").Width = 200;
                gridViewTests.Columns.ColumnByName("colSizeId").Width = 100;
                //gridViewTests.Columns.ColumnByName("colQty").Width = 80;

                bsProductSubDetail.DataSource = dsMain;
                bsProductSubDetail.DataMember = "Products";

                bsProductSize.DataSource = dsMain;
                bsProductSize.DataMember = "ProductSize";


                repositoryProdcutSubDetail.DataSource = bsProductSubDetail;
                repositoryProdcutSubDetail.DisplayMember = "ProductName";
                repositoryProdcutSubDetail.ValueMember = "ProductId";
                repositoryProdcutSubDetail.PopupFormSize = new Size(600, 200);
                repositoryProdcutSubDetail.NullText = "";
                repositoryProdcutSubDetail.ShowFooter = false;
                repositoryProdcutSubDetail.View.OptionsView.ColumnAutoWidth = false;
                repositoryProdcutSubDetail.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
                repositoryProdcutSubDetail.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                repositoryProdcutSubDetail.ImmediatePopup = true;
                repositoryProdcutSubDetail.PopulateViewColumns();
                GCDetail.RepositoryItems.Add(repositoryProdcutSubDetail);

                gridViewTests.Columns.ColumnByName("colProductId").ColumnEdit = repositoryProdcutSubDetail;


                if (repositoryProdcutSubDetail.View.Columns.Count > 0)
                {
                    repositoryProdcutSubDetail.View.Columns.ColumnByName("colProductId").Visible = false;
                    repositoryProdcutSubDetail.View.Columns.ColumnByName("colMesurementUnitId").Visible = false;

                    repositoryProdcutSubDetail.View.Columns.ColumnByName("colProductCode").Caption = "Code";
                    repositoryProdcutSubDetail.View.Columns.ColumnByName("colProductName").Caption = "Product Name";
                    repositoryProdcutSubDetail.View.Columns.ColumnByName("colProductNature").Caption = "Product Name";
                    repositoryProdcutSubDetail.View.Columns.ColumnByName("colCategoryName").Caption = "Category";


                    repositoryProdcutSubDetail.View.Columns.ColumnByName("colProductCode").Width = 80;
                    repositoryProdcutSubDetail.View.Columns.ColumnByName("colProductName").Width = 250;
                    repositoryProdcutSubDetail.View.Columns.ColumnByName("colProductNature").Width = 80;
                    repositoryProdcutSubDetail.View.Columns.ColumnByName("colCategoryName").Width = 100;

                    repositoryProdcutSubDetail.View.Columns.ColumnByName("colProductCode").VisibleIndex = 0;
                    repositoryProdcutSubDetail.View.Columns.ColumnByName("colProductName").VisibleIndex = 1;
                    repositoryProdcutSubDetail.View.Columns.ColumnByName("colProductNature").VisibleIndex = 2;
                    repositoryProdcutSubDetail.View.Columns.ColumnByName("colCategoryName").VisibleIndex = 3;
                }


                //******Product Size *******************

                repositoryProdcutSize.DataSource = bsProductSize;
                repositoryProdcutSize.DisplayMember = "SizeName";
                repositoryProdcutSize.ValueMember = "SizeId";
                repositoryProdcutSize.PopupFormSize = new Size(250, 200);
                repositoryProdcutSize.NullText = "";
                repositoryProdcutSize.ShowFooter = false;
                repositoryProdcutSize.View.OptionsView.ColumnAutoWidth = false;
                repositoryProdcutSize.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
                repositoryProdcutSize.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                repositoryProdcutSize.ImmediatePopup = true;
                repositoryProdcutSize.PopulateViewColumns();
                GCDetail.RepositoryItems.Add(repositoryProdcutSize);

                gridViewTests.Columns.ColumnByName("colSizeId").ColumnEdit = repositoryProdcutSize;


                if (repositoryProdcutSize.View.Columns.Count > 0)
                {
                    repositoryProdcutSize.View.Columns.ColumnByName("colSizeId").Visible = false;
                    repositoryProdcutSize.View.Columns.ColumnByName("colSizeName").Caption = "Size";
                    repositoryProdcutSize.View.Columns.ColumnByName("colSizeName").Width = 80;
                }
                gridViewTests.EndUpdate();

                /**********Auto Size Sole Detect Work*/
                //ActualProductId
                try
                {
                    DataRow drDetail = gridViewWelds.GetDataRow(e.RowHandle);
                    if (drDetail != null)
                    {
                        int ActualProductId = Convert.ToInt32(drDetail["ActualProductId"]);
                        if (dsMain.Tables["Products"].Select("ProductId = '" + ActualProductId + "'").Length > 0)
                        {
                            string ActualProductName = dsMain.Tables["Products"].Select("ProductId = '" + ActualProductId + "'")[0]["ProductName"].ToString();

                            foreach (DataRow drSizes in dsMain.Tables["ProductSize"].Rows)
                            {
                                string ProductSizeName = ActualProductName + " " + drSizes["SizeName"].ToString();
                                if (dsMain.Tables["Products"].Select("ProductName = '" + ProductSizeName + "'").Length > 0)
                                {
                                    int ProductIdSize = Convert.ToInt32(dsMain.Tables["Products"].Select("ProductName = '" + ProductSizeName + "'")[0]["ProductId"]);
                                    if (dsGrid.Tables["FormulaSubDetail"].Select("FormulaDetailId = '" + drDetail["FormulaDetailId"].ToString() + "' And  ProductId = '" + ProductIdSize + "' And SizeId ='" + drSizes["SizeId"].ToString() + "' ").Length == 0)
                                    {
                                        //FormulaSubDetail
                                        DataRow drSizeNew = dsGrid.Tables["FormulaSubDetail"].NewRow();
                                        drSizeNew["FomulaSubDetailId"] = -1;
                                        drSizeNew["FormulaDetailId"] = drDetail["FormulaDetailId"];
                                        drSizeNew["ProductId"] = ProductIdSize;
                                        drSizeNew["SizeId"] = drSizes["SizeId"];
                                        drSizeNew["Qty"] = drDetail["Qty"];
                                        dsGrid.Tables["FormulaSubDetail"].Rows.Add(drSizeNew);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception sex)
                {
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void gvSubDetail_MasterRowExpanding(object sender, MasterRowCanExpandEventArgs e)
        {
            try
            {
                int index = e.RowHandle;
                if (index < 0)
                {
                    return;
                }
                //int WarehouseId = Convert.ToInt32(dsGrid.Tables["Warehouse"].Rows[index]["WarehouseId"]);
                //if (dsGrid.Tables["FormulaDetail"].Select("WarehouseId = '" + WarehouseId + "'").Length <= 0)
                //{
                //    DataRow drNew = dsGrid.Tables["FormulaDetail"].NewRow();
                //    drNew["WarehouseId"] = WarehouseId;
                //    drNew["Qty"] = 0;
                //    dsGrid.Tables["FormulaDetail"].Rows.Add(drNew);
                //    e.Allow = true;
                //}
                e.Allow = true;
            }
            catch (Exception ex)
            { }

        }


        private void gvDetailCustom_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    DataRow drDetail = View.GetDataRow(e.RowHandle);
                    int FormulaDetailId = Convert.ToInt32(drDetail["FormulaDetailId"]);
                    if (dsGrid.Tables["FormulaSubDetail"].Rows.Count> 0)
                    {
                        if (dsGrid.Tables["FormulaSubDetail"].Select("FormulaDetailId = '" + FormulaDetailId + "'").Length > 0)
                        {
                            e.Appearance.BackColor = Color.FromArgb(150, Color.LimeGreen); //Color.LightCoral
                            e.Appearance.BackColor2 = Color.LightGreen;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void gvSubCustom_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    //int DetailId = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, View.Columns["PDId"])); //View.GetRowCellDisplayText(e.RowHandle, View.Columns["PMDId"]);
                    //if (DetailId > 0)
                    //{
                    e.Appearance.BackColor = Color.FromArgb(150, Color.LightGreen); //Color.LightCoral
                    e.Appearance.BackColor2 = Color.White;
                    //}
                }
            }
            catch (Exception ex)
            {
            }

        }


        //gvDetail_MasterRowExpanding
        private void ButtonRights(bool Enable)
        {
            btnAdd.Enabled = Enable;
            btnUpdate.Enabled = !Enable;
            btnDelete.Enabled = !Enable;
            txtFormulaId.ReadOnly = !Enable;

        }

        private bool Validation()
        {
            bool result = true;
            //if (Convert.ToInt32(cmbProduct.SelectedValue) <= 0)
            //{
            //    MessageBox.Show("Please Select Product Name", "Product Name is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    result = false;
            //    cmbProduct.Focus();
            //    return result;
            //}

            if (string.IsNullOrEmpty(txtPCode.Text))
            {
                MessageBox.Show("Please Select Product Name", "Product Name is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                btnPSearch.Focus();
                return result;
            }

            if (string.IsNullOrEmpty(txtFormulaName.Text))
            {
                MessageBox.Show("Please Enter Product Formula Name", "Formula Name is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtFormulaName.Focus();
                return result;
            }

            if (dsGrid.Tables["FormulaDetail"].Rows.Count <= 0)
            {
                MessageBox.Show("Please Enter Formula Detail", "Formula Details Not Found.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtFormulaName.Focus();
                return result;
            }

            return result;
        }

        private void ClearFeilds()
        {
            txtFormulaId.Text = string.Empty;
            txtFormulaName.Text = string.Empty;
            txtPCode.Text = string.Empty;
            cmbLastNo.SelectedValue = -1;
            //cmbProduct.SelectedValue = -1;
            txtRemarks.Text = string.Empty;
            chkActive.Checked = true;
            pbitem.Image = FIL.Properties.Resources.User;
            FormulaId = -1;
            dsMain.Tables["FormulaDetail"].Rows.Clear();
            dsMain.Tables["FormulaMaster"].Rows.Clear();

            dsMain.RejectChanges();
            drMaster = dsMain.Tables["FormulaMaster"].NewRow();
            dsMain.Tables["FormulaMaster"].Rows.Add(drMaster);
            // GCDetail.DataSource = dsMain.Tables["FormulaDetail"];
            //GridSetting();

            ButtonRights(true);
            btnNextInvioceNo.Enabled = false;
            btnPrevInvioceNo.Enabled = false;
            setupGrip();
            //cmbProduct.Focus();

        }

        //public Image Base64ToImage(string base64String)
        //{
        //    // Convert Base64 String to byte[]
        //    byte[] imageBytes = Convert.FromBase64String(base64String);
        //    MemoryStream ms = new MemoryStream(imageBytes, 0,
        //      imageBytes.Length);

        //    // Convert byte[] to Image
        //    ms.Write(imageBytes, 0, imageBytes.Length);
        //    Image image = Image.FromStream(ms, true);
        //    return image;
        //}

        private void LoadProductFormula()
        {
            setupGrip();
            DataTable dtProduct = new DataTable();
            dtProduct = manageProduct.GetProduct(Convert.ToInt32(dsMain.Tables["FormulaMaster"].Rows[0]["ProductId"]));
            if (dtProduct.Rows.Count > 0)
            {
                txtPCode.Text = dtProduct.Rows[0]["ProductCode"].ToString();
            }
            //cmbProduct.SelectedValue = dsMain.Tables["FormulaMaster"].Rows[0]["ProductId"];
            txtFormulaName.Text = dsMain.Tables["FormulaMaster"].Rows[0]["FormulaName"].ToString();
            txtRemarks.Text = dsMain.Tables["FormulaMaster"].Rows[0]["Remarks"].ToString();
            chkActive.Checked = Convert.ToBoolean(dsMain.Tables["FormulaMaster"].Rows[0]["IsActive"]);
            cmbLastNo.SelectedValue = dsMain.Tables["FormulaMaster"].Rows[0]["LastNoId"];
            ButtonRights(false);
        }

        #endregion

        #region Grid Events
        private void gvDetail_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            object cellValue = view.GetRowCellValue(e.RowHandle, gvDetail.Columns[0]);
            MessageBox.Show(cellValue.ToString());

            if (e.Value != null)
            {
                switch (e.Column.Name.ToString())
                {
                    case "colProductId":
                        {
                            try
                            {

                                dvProduct.RowFilter = "ProductId='" + e.Value.ToString() + "'";
                            }
                            catch
                            {
                            }
                            break;
                        }

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
                        {
                            dr["ProductId"] = dvProduct[0]["ProductId"];
                            dr["UnitId"] = dvProduct[0]["MesurementUnitId"];
                            if (string.IsNullOrEmpty(dr["Qty"].ToString()))
                            {
                                dr["Qty"] = "0";
                            }
                            break;
                        }
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
                    if (!string.IsNullOrEmpty(dr["ProductId"].ToString()))
                    {
                        dvProduct.RowFilter = "ProductId='" + dr["ProductId"].ToString() + "'";
                    }
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
            DataRow dr = default(DataRow);
            dr = gvDetail.GetDataRow(e.RowHandle);

            if (decimal.Parse(dr["ProductId"].ToString()) <= 0)
            {
                e.Valid = false;
                e.ErrorText = "Account Name Not Found.";
            }

            if (dr.RowState == DataRowState.Detached)
            {
                if (dsMain.Tables["FormulaDetail"].Select("ProductId =" + dr["ProductId"].ToString()).Length > 0)
                {
                    //MessageBox.Show("Account Already Exists", "Same Account can not be repeated.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //e.Valid = false;
                    //e.ErrorText = "Already Exists" + Environment.NewLine + "Same Raw Material can not be repeated.";
                }
            }
            else
            {
                e.Valid = true;
                gvDetail.GetDataRow(e.RowHandle)["FormulaMasterId"] = drMaster["FormulaMasterId"];
            }
        }

        #endregion


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                try
                {
                    int ProductId = -1;
                    ProductId = manageProduct.GetProductIdByCode(txtPCode.Text);
                    if (ProductId <= 0)
                    {
                        MessageBox.Show("Product Identity not Found. Please Select Product Name");
                        btnPSearch.Focus();
                        return;
                    }
                    dataAcess.BeginTransaction();
                    if (dataAcess.getDBCommand().Transaction == null)
                    {
                        dataAcess.SetDBTransaction();
                    }
                    FormulaId = manageProduct.InsertProductFormulaMaster(txtFormulaName.Text, ProductId, txtRemarks.Text, Convert.ToInt32(cmbLastNo.SelectedValue), chkActive.Checked, MainForm.User_Id, DateTime.Now, "", dataAcess);
                    foreach (DataRow dr in dsGrid.Tables["FormulaDetail"].Rows)
                    {
                        try
                        {

                            if (dr.RowState != DataRowState.Deleted)
                            {
                                if (string.IsNullOrEmpty(dr["Qty"].ToString()))
                                {
                                    dr["Qty"] = 0;
                                }
                                if ((Convert.ToDecimal(dr["Qty"]) > 0) || !string.IsNullOrEmpty(dr["ActualProductId"].ToString()))
                                {
                                    int DetailId = manageProduct.InsertProductFormulaDetail(FormulaId, (string.IsNullOrEmpty(dr["ProductId"].ToString()) ? -1 : Convert.ToInt32(dr["ProductId"])), (string.IsNullOrEmpty(dr["UnitId"].ToString()) ? -1 : Convert.ToInt32(dr["UnitId"])), (string.IsNullOrEmpty(dr["Qty"].ToString()) ? 0 : Convert.ToDecimal(dr["Qty"])),
                                           Convert.ToInt32(dr["WarehouseId"]), (string.IsNullOrEmpty(dr["ActualProductId"].ToString()) ? -1 : Convert.ToInt32(dr["ActualProductId"])), dr["Remarks"].ToString(), (string.IsNullOrEmpty(dr["ColorId"].ToString()) ? -1 : Convert.ToInt32(dr["ColorId"])), dataAcess);

                                    if (DetailId > 0)
                                    {
                                        //Insert Formula Sub Detail
                                        if (dsGrid.Tables["FormulaSubDetail"].Select("FormulaDetailId = '" + dr["FormulaDetailId"] + "'").Length > 0)
                                        {
                                            foreach (DataRow drSubDetail in dsGrid.Tables["FormulaSubDetail"].Select("FormulaDetailId = '" + dr["FormulaDetailId"] + "'"))
                                            {
                                                manageProduct.InsertProductFormulaSubDetail(DetailId, FormulaId,
                                                    (string.IsNullOrEmpty(drSubDetail["ProductId"].ToString()) ? -1 : Convert.ToInt32(drSubDetail["ProductId"])),
                                                    (string.IsNullOrEmpty(drSubDetail["SizeId"].ToString()) ? -1 : Convert.ToInt32(drSubDetail["SizeId"])),
                                                    (string.IsNullOrEmpty(drSubDetail["Qty"].ToString()) ? -1 : Convert.ToInt32(drSubDetail["Qty"])),
                                                    dataAcess);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    if (chkActive.Checked)
                    {
                        manageProduct.UpdateUnActiveOtherReceipy(FormulaId, ProductId, dataAcess);
                    }
                    dataAcess.TransCommit();
                    MessageBox.Show("Product Formula Insert Successfull", "Record Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFormulaId.Text = FormulaId.ToString();
                    ButtonRights(false);
                    //ClearFeilds();
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


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                int ProductId = -1;
                ProductId = manageProduct.GetProductIdByCode(txtPCode.Text);
                if (ProductId <= 0)
                {
                    MessageBox.Show("Product Identity not Found. Please Select Product Name");
                    btnPSearch.Focus();
                    return;
                }
                try
                {

                    dataAcess.BeginTransaction();
                    if (dataAcess.getDBCommand().Transaction == null)
                    {
                        dataAcess.SetDBTransaction();
                    }
                    manageProduct.DeleteFormulaDetailByMasterId(FormulaId, dataAcess);
                    manageProduct.UpdateProductFormulaMaster(FormulaId, txtFormulaName.Text, ProductId, txtRemarks.Text, Convert.ToInt32(cmbLastNo.SelectedValue), chkActive.Checked, MainForm.User_Id, DateTime.Now, "", dataAcess);

                    foreach (DataRow dr in dsGrid.Tables["FormulaDetail"].Rows)
                    {
                        if (dr.RowState != DataRowState.Deleted)
                        {
                            if (string.IsNullOrEmpty(dr["Qty"].ToString()))
                            {
                                dr["Qty"] = 0;
                            }
                            if ((Convert.ToDecimal(dr["Qty"]) > 0) || !string.IsNullOrEmpty(dr["ActualProductId"].ToString()))
                            {
                                int DetailId = manageProduct.InsertProductFormulaDetail(FormulaId, (string.IsNullOrEmpty(dr["ProductId"].ToString()) ? -1 : Convert.ToInt32(dr["ProductId"])), (string.IsNullOrEmpty(dr["UnitId"].ToString()) ? -1 : Convert.ToInt32(dr["UnitId"])), (string.IsNullOrEmpty(dr["Qty"].ToString()) ? 0 : Convert.ToDecimal(dr["Qty"])),
                               Convert.ToInt32(dr["WarehouseId"]), (string.IsNullOrEmpty(dr["ActualProductId"].ToString()) ? -1 : Convert.ToInt32(dr["ActualProductId"])), dr["Remarks"].ToString(), (string.IsNullOrEmpty(dr["ColorId"].ToString()) ? -1 : Convert.ToInt32(dr["ColorId"])), dataAcess);

                                if (DetailId > 0)
                                {
                                    //Insert Formula Sub Detail
                                    if (dsGrid.Tables["FormulaSubDetail"].Select("FormulaDetailId = '" + dr["FormulaDetailId"] + "'").Length > 0)
                                    {
                                        foreach (DataRow drSubDetail in dsGrid.Tables["FormulaSubDetail"].Select("FormulaDetailId = '" + dr["FormulaDetailId"] + "'"))
                                        {
                                            manageProduct.InsertProductFormulaSubDetail(DetailId, FormulaId,
                                                (string.IsNullOrEmpty(drSubDetail["ProductId"].ToString()) ? -1 : Convert.ToInt32(drSubDetail["ProductId"])),
                                                (string.IsNullOrEmpty(drSubDetail["SizeId"].ToString()) ? -1 : Convert.ToInt32(drSubDetail["SizeId"])),
                                                (string.IsNullOrEmpty(drSubDetail["Qty"].ToString()) ? -1 : Convert.ToInt32(drSubDetail["Qty"])),
                                                dataAcess);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (chkActive.Checked)
                    {
                        manageProduct.UpdateUnActiveOtherReceipy(FormulaId, ProductId, dataAcess);
                    }
                    dataAcess.TransCommit();
                    MessageBox.Show("Product Formula Update Successfull", "Record Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //txtFormulaId.Text = FormulaId.ToString();
                    //ClearFeilds();
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
                search.getattributes("GetProductFormulaSearch", null, "Product Formula");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtFormulaId.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;


                }
                else
                {
                    txtFormulaId.Text = string.Empty;
                    txtFormulaId.Focus();
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
                FormulaId = manageProduct.GetFormulaIdByCode(Convert.ToInt32(txtFormulaId.Text));
                if (FormulaId > 0)
                {
                    LoadProductFormula();
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
            if (FormulaId <= 0)
            {
                MessageBox.Show("Product Receipy does not found.", "Product Formula Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Are you sure want to Delete it.", "Product Formula Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeleteProductFormula(FormulaId);
                        break;
                    }
            }
        }

        private void DeleteProductFormula(int pFormulaId)
        {
            int status = manageProduct.DeleteProductFormula(pFormulaId);

            if (status > 0 )
            {
                MessageBox.Show("Product Formula Delete Successfull.", "Product Formula Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }
            else
            {
                MessageBox.Show("Error While Delete Product Formula ." + Environment.NewLine + "Formula Alredy are in Used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (string.IsNullOrEmpty(txtFormulaId.Text))
                {
                    return;
                }
                
                string path = Application.StartupPath + "/rpt/Production/rptProductFormula.rpt";
                //string path = Application.StartupPath + "/rpt/Production/TestImage.rpt";
                ReportDocument document = new ReportDocument();
                document.Load(path);
                DataTable dtReport = new DataTable();
                //dtReport = manageProduct.GetTestReportProduct(654);
                dtReport = manageProduct.GetReportProductFormula(manageProduct.GetFormulaIdByCode(Convert.ToInt32(txtFormulaId.Text)));
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

        private void btnPSearch_Click(object sender, EventArgs e)
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

        private void txtPCode_TextChanged(object sender, EventArgs e)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gvDetail_MasterRowExpanding(object sender, MasterRowCanExpandEventArgs e)
        {
            try
            {
                int index = e.RowHandle;
                if (index < 0)
                {
                    return;
                }
                int WarehouseId = Convert.ToInt32(dsGrid.Tables["Warehouse"].Rows[index]["WarehouseId"]);
                if (dsGrid.Tables["FormulaDetail"].Select("WarehouseId = '" + WarehouseId + "'").Length <= 0)
                {
                    DataRow drNew = dsGrid.Tables["FormulaDetail"].NewRow();
                    drNew["WarehouseId"] = WarehouseId;
                    drNew["Qty"] = 0;
                    dsGrid.Tables["FormulaDetail"].Rows.Add(drNew);
                    e.Allow = true;
                }

                //e.Allow = true;

                //       dsGrid = new DataSet();
                //dsGrid.Tables.Add(dsMain.Tables["Warehouse"].Copy());
                //dsGrid.Tables.Add(dsMain.Tables["FormulaDetail"].Copy());
            }
            catch (Exception ex)
            { }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (dsMain.Tables.Contains("Products"))
                {
                    dsMain.Tables["Products"].Rows.Clear();
                    DataTable dtProduct = manageProduct.GetUpdatedProducts();
                    foreach (DataRow dr in dtProduct.Rows)
                    {
                        dsMain.Tables["Products"].ImportRow(dr);
                    }
                }

                FillDropDown();
                txtPCode_TextChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void frmProductFormula_KeyDown(object sender, KeyEventArgs e)
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

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (FormulaId <= 0)
            {
                MessageBox.Show("Please Select Receipy to Copy.", "Error to Copy. Data not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataSet dsCopy = new DataSet();
            dsCopy = manageProduct.GetProductFormulaStructure(FormulaId);


            dsCopy.Tables[0].TableName = "FormulaMaster";
            dsCopy.Tables[1].TableName = "FormulaDetail";
            dsCopy.Tables[2].TableName = "FormulaSubDetail";
            dsCopy.Tables[3].TableName = "Products";
            dsCopy.Tables[4].TableName = "MesurementUnit";
            dsCopy.Tables[5].TableName = "FormulaConfig";
            dsCopy.Tables[6].TableName = "Warehouse";
            dsCopy.Tables[7].TableName = "Color";
            dsCopy.Tables[8].TableName = "ProductSize";


            dsCopy.Tables["FormulaDetail"].Columns["FormulaDetailId"].AutoIncrement = true;
            dsCopy.Tables["FormulaDetail"].Columns["FormulaDetailId"].AutoIncrementSeed = -1;
            dsCopy.Tables["FormulaDetail"].Columns["FormulaDetailId"].AutoIncrementStep = -1;

            dsCopy.Tables["FormulaSubDetail"].Columns["FomulaSubDetailId"].AutoIncrement = true;
            dsCopy.Tables["FormulaSubDetail"].Columns["FomulaSubDetailId"].AutoIncrementSeed = -1;
            dsCopy.Tables["FormulaSubDetail"].Columns["FomulaSubDetailId"].AutoIncrementStep = -1;


            FormulaId = -1;
            txtPCode.Text = string.Empty;
            txtFormulaId.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtFormulaName.Text = string.Empty;
            cmbLastNo.SelectedIndex = 0;
            dsGrid = new DataSet();
            dsGrid.Tables.Add(dsCopy.Tables["Warehouse"].Copy());
            dsGrid.Tables.Add(dsCopy.Tables["FormulaDetail"].Copy());
            dsGrid.Tables.Add(dsCopy.Tables["FormulaSubDetail"].Copy());

            dsGrid.Relations.Add("WarehouseRelation", dsGrid.Tables["Warehouse"].Columns["WarehouseId"], dsGrid.Tables["FormulaDetail"].Columns["WarehouseId"]);
            //for sub detail Relation
            dsGrid.Relations.Add("SubDetailRelation", dsGrid.Tables["FormulaDetail"].Columns["FormulaDetailId"], dsGrid.Tables["FormulaSubDetail"].Columns["FormulaDetailId"]);

            foreach (DataRow drDetail in dsGrid.Tables["FormulaSubDetail"].Rows)
            {
                drDetail.BeginEdit();
                drDetail["FomulaSubDetailId"] = -1;
                drDetail.EndEdit();
            }

            for (int i = 0; i <= dsGrid.Tables["FormulaDetail"].Rows.Count - 1; i++)
            {
                DataRow drDetail = dsGrid.Tables["FormulaDetail"].Rows[i];
                drDetail.BeginEdit();
                drDetail["FormulaMasterId"] = -1;
                drDetail["FormulaDetailId"] = (i + 1) * -1;
                drDetail.EndEdit();
            }
            //foreach (DataRow drDetail in dsGrid.Tables["FormulaDetail"].Rows)
            //{
            //    drDetail.BeginEdit();
            //    drDetail["FormulaDetailId"] = -1;
            //    drDetail["FormulaMasterId"] = -1;
            //    drDetail.EndEdit();
            //}

            GCDetail.DataSource = dsGrid; //dsGrid.Tables["Warehouse"]; //dsMain.Tables["FormulaDetail"];
            GCDetail.DataMember = "Warehouse";
            GCDetail.ForceInitialize();


            gvDetail.Columns.ColumnByName("colWarehouseId").Visible = false;

            gvDetail.Columns.ColumnByName("colWarehouseName").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colWarehouseName").Caption = "";
            gvDetail.Columns.ColumnByName("colWarehouseName").Width = GCDetail.Width - 150;
            gvDetail.OptionsView.ShowViewCaption = false;
            gvDetail.Columns.ColumnByName("colWarehouseName").AppearanceCell.Font = new Font("Arial", 10f, FontStyle.Bold);

            gvDetail.DetailHeight = 500;


            ButtonRights(true);


        }


        private void ShownEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            view.GridControl.BeginInvoke(new MethodInvoker(() =>
            {
                PopupBaseEdit edit = view.ActiveEditor as PopupBaseEdit;
                if (edit == null) return;
                if (!string.IsNullOrEmpty(edit.Text))
                {
                    edit.ShowPopup();
                }
            }));
        }






    }
}
