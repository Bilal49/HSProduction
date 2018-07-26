using CrystalDecisions.CrystalReports.Engine;
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
    public partial class frmProductAssumption : Form
    {
        Smartworks.DAL dataAcess = new Smartworks.DAL();
        ProductManager manageProduct = new ProductManager();
        SalesOrderManager manageSalesOrder = new SalesOrderManager();
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

        DataSet dsMain = null;
        DataSet dsGrid = null;
        DataRow drMaster;
        DataView dvProduct;
        DataViewManager dvm;
        int FormulaId = -1;
        public frmProductAssumption()
        {
            InitializeComponent();
        }
        private void frmProductFormula_Load(object sender, EventArgs e)
        {
            try
            {
                //setupGrip();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #region Method

        private void setupGrip()
        {
            dsMain = new DataSet();

            dsMain = manageProduct.GetProductAssumptionStructure(FormulaId, (string.IsNullOrEmpty(txtQty.Text) ? 1 : Convert.ToInt32(txtQty.Text)), txtSONo.Text,
                 (string.IsNullOrEmpty(txtS39.Text) ? 0 : Convert.ToInt32(txtS39.Text)),
                 (string.IsNullOrEmpty(txtS40.Text) ? 0 : Convert.ToInt32(txtS40.Text)),
                 (string.IsNullOrEmpty(txtS41.Text) ? 0 : Convert.ToInt32(txtS41.Text)),
                 (string.IsNullOrEmpty(txtS42.Text) ? 0 : Convert.ToInt32(txtS42.Text)),
                 (string.IsNullOrEmpty(txtS43.Text) ? 0 : Convert.ToInt32(txtS43.Text)),
                 (string.IsNullOrEmpty(txtS44.Text) ? 0 : Convert.ToInt32(txtS44.Text)),
                 (string.IsNullOrEmpty(txtS45.Text) ? 0 : Convert.ToInt32(txtS45.Text)),
                 (string.IsNullOrEmpty(txtS46.Text) ? 0 : Convert.ToInt32(txtS46.Text)),
                 (string.IsNullOrEmpty(txtS47.Text) ? 0 : Convert.ToInt32(txtS47.Text))
                 );



            dsMain.Tables[0].TableName = "FormulaMaster";
            dsMain.Tables[1].TableName = "FormulaDetail";
            dsMain.Tables[2].TableName = "FormulaSubDetail";
            dsMain.Tables[3].TableName = "Products";
            dsMain.Tables[4].TableName = "MesurementUnit";
            dsMain.Tables[5].TableName = "FormulaConfig";
            dsMain.Tables[6].TableName = "Warehouse";
            dsMain.Tables[7].TableName = "Color";
            dsMain.Tables[8].TableName = "ProductSize";


            dsMain.Tables["FormulaMaster"].Columns["FormulaMasterId"].AutoIncrement = true;
            dsMain.Tables["FormulaMaster"].Columns["FormulaMasterId"].AutoIncrementSeed = -1;
            dsMain.Tables["FormulaMaster"].Columns["FormulaMasterId"].AutoIncrementStep = -1;

            dsMain.Tables["FormulaDetail"].Columns["FormulaDetailId"].AutoIncrement = true;
            dsMain.Tables["FormulaDetail"].Columns["FormulaDetailId"].AutoIncrementSeed = -1;
            dsMain.Tables["FormulaDetail"].Columns["FormulaDetailId"].AutoIncrementStep = -1;

            dsGrid = new DataSet();
            dsGrid.Tables.Add(dsMain.Tables["Warehouse"].Copy());
            dsGrid.Tables.Add(dsMain.Tables["FormulaDetail"].Copy());
            dsGrid.Tables.Add(dsMain.Tables["FormulaSubDetail"].Copy());

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
            GCDetail.Enabled = true;


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

            //if (dsMain.Tables["FormulaDetail"].Rows.Count == 0)
            //{
            //    if (dsMain.Tables["FormulaConfig"].Rows.Count > 0)
            //    {
            //        foreach (DataRow drConfig in dsMain.Tables["FormulaConfig"].Rows)
            //        {
            //            DataRow drDetail = dsMain.Tables["FormulaDetail"].NewRow();
            //            drDetail["FormulaMasterId"] = drMaster["FormulaMasterId"];
            //            drDetail["WarehouseId"] = drConfig["WarehouseId"];
            //            drDetail["ProductId"] = drConfig["ProductId"];
            //            drDetail["UnitId"] = drConfig["UnitId"];
            //            drDetail["Qty"] = 0;
            //            dsMain.Tables["FormulaDetail"].Rows.Add(drDetail);
            //        }
            //    }
            //}


            //if (dsGrid.Tables["FormulaDetail"].Rows.Count == 0)
            //{
            //    if (dsMain.Tables["FormulaConfig"].Rows.Count > 0)
            //    {
            //        foreach (DataRow drConfig in dsMain.Tables["FormulaConfig"].Rows)
            //        {
            //            DataRow drDetail = dsGrid.Tables["FormulaDetail"].NewRow();
            //            drDetail["FormulaMasterId"] = drMaster["FormulaMasterId"];
            //            drDetail["WarehouseId"] = drConfig["WarehouseId"];
            //            drDetail["ProductId"] = drConfig["ProductId"];
            //            drDetail["UnitId"] = drConfig["UnitId"];
            //            drDetail["Qty"] = 0;
            //            dsGrid.Tables["FormulaDetail"].Rows.Add(drDetail);
            //        }
            //    }
            //}



            //CardView cardView1 = new CardView(GCDetail);
            //GCDetail.LevelTree.Nodes.Add("CategoriesProducts", cardView1);
            ////Specify text to be displayed within detail tabs.
            //cardView1.ViewCaption = "Category Products";

            ////Hide the CategoryID column for the master View
            //gvDetail.Columns["WarehouseId"].VisibleIndex = -1;

        }

        private void GridSetting()
        {


            //(e.View as GridView).Columns["ticket_number"].Visible = false;
            gvDetail.Columns.ColumnByName("colFormulaDetailId").OptionsColumn.ReadOnly = true;
            gvDetail.Columns.ColumnByName("colFormulaMasterId").OptionsColumn.ReadOnly = true;

            gvDetail.Columns.ColumnByName("colFormulaDetailId").Visible = false;
            gvDetail.Columns.ColumnByName("colFormulaMasterId").Visible = false;

            gvDetail.Columns.ColumnByName("colProductId").Caption = "Raw Material Name";
            gvDetail.Columns.ColumnByName("colActualProductId").Caption = "Article";
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
            //gridViewTests.MasterRowExpanded += new CustomMasterRowEventHandler(gridViewTests_MasterRowExpanded);

            gridViewTests.MasterRowExpanded += gvSubDetail_MasterRowExpanded;
            gridViewTests.MasterRowExpanding += gvSubDetail_MasterRowExpanding;
            gridViewTests.RowStyle += gvDetailCustom_RowStyle;
            gridViewTests.DetailHeight = 500;

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
            gridViewTests.Columns.ColumnByName("colRemarks").Caption = "Calculation";

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



                gridViewTests.Columns.ColumnByName("colProductId").Caption = "Materail Name";
                gridViewTests.Columns.ColumnByName("colSizeId").Caption = "Size";
                gridViewTests.Columns.ColumnByName("colQty").Caption = "Quantity";


                gridViewTests.Columns.ColumnByName("colProductId").VisibleIndex = 2;
                gridViewTests.Columns.ColumnByName("colSizeId").VisibleIndex = 1;
                gridViewTests.Columns.ColumnByName("colQty").VisibleIndex = 3;


                gridViewTests.Columns.ColumnByName("colProductId").Width = 200;
                gridViewTests.Columns.ColumnByName("colSizeId").Width = 100;
                gridViewTests.Columns.ColumnByName("colQty").Width = 80;

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
                    if (dsGrid.Tables["FormulaSubDetail"].Rows.Count > 0)
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



        private bool Validation()
        {
            bool result = true;

            if (string.IsNullOrEmpty(txtPCode.Text))
            {
                MessageBox.Show("Please Select Product Name", "Product Name is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                btnPSearch.Focus();
                return result;
            }

            if (string.IsNullOrEmpty(txtQty.Text))
            {
                MessageBox.Show("Please Enter Product Quantity", "Quantity is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtQty.Focus();
                return result;
            }

            return result;
        }

        private void ClearFeilds()
        {
            txtQty.Text = string.Empty;
            txtQty.ReadOnly = false;
            txtPCode.Text = string.Empty;
            txtFormulaId.Text = string.Empty;
            txtFormulaName.Text = string.Empty;
            txtSONo.Text = string.Empty;
            pbitem.Image = FIL.Properties.Resources.User;

            txtS39.Text = string.Empty;
            txtS40.Text = string.Empty;
            txtS41.Text = string.Empty;
            txtS42.Text = string.Empty;
            txtS43.Text = string.Empty;
            txtS44.Text = string.Empty;
            txtS45.Text = string.Empty;
            txtS46.Text = string.Empty;
            txtS47.Text = string.Empty;

            txtS39.ReadOnly = false;
            txtS40.ReadOnly = false;
            txtS41.ReadOnly = false;
            txtS42.ReadOnly = false;
            txtS43.ReadOnly = false;
            txtS44.ReadOnly = false;
            txtS45.ReadOnly = false;
            txtS46.ReadOnly = false;
            txtS47.ReadOnly = false;

            FormulaId = -1;
            dsMain.Tables["FormulaDetail"].Rows.Clear();
            dsMain.Tables["FormulaMaster"].Rows.Clear();

            dsMain.RejectChanges();
            drMaster = dsMain.Tables["FormulaMaster"].NewRow();
            dsMain.Tables["FormulaMaster"].Rows.Add(drMaster);
            GCDetail.Enabled = false;
            GCDetail.DataSource = null;
            //setupGrip();
            btnPSearch.Focus();

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

        private void LoadProductFormula()
        {
            setupGrip();
            //DataTable dtProduct = new DataTable();
            //dtProduct = manageProduct.GetProduct(Convert.ToInt32(dsMain.Tables["FormulaMaster"].Rows[0]["ProductId"]));
            //if (dtProduct.Rows.Count > 0)
            //{
            //    txtPCode.Text = dtProduct.Rows[0]["ProductCode"].ToString();
            //}
            //txtFormulaName.Text = dsMain.Tables["FormulaMaster"].Rows[0]["FormulaName"].ToString();
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


        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFeilds();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("We are Applogize for Delete Functionality. Works in Progree", "Pending", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintInvoice(false);
        }

        private void PrintInvoice(bool IsDirectPrint = true)
        {
            try
            {
                //if (string.IsNullOrEmpty(txtFormulaId.Text))
                //{
                //    return;
                //}

                string path = Application.StartupPath + "/rpt/Production/rptProductAssumption.rpt";
                ReportDocument document = new ReportDocument();
                document.Load(path);
                DataTable dtReport = new DataTable();
                dtReport = manageProduct.GetReportProductAssumption(FormulaId, (string.IsNullOrEmpty(txtQty.Text) ? 1 : Convert.ToInt32(txtQty.Text)), txtSONo.Text,
                    (string.IsNullOrEmpty(txtS39.Text) ? 0 : Convert.ToInt32(txtS39.Text)),
                 (string.IsNullOrEmpty(txtS40.Text) ? 0 : Convert.ToInt32(txtS40.Text)),
                 (string.IsNullOrEmpty(txtS41.Text) ? 0 : Convert.ToInt32(txtS41.Text)),
                 (string.IsNullOrEmpty(txtS42.Text) ? 0 : Convert.ToInt32(txtS42.Text)),
                 (string.IsNullOrEmpty(txtS43.Text) ? 0 : Convert.ToInt32(txtS43.Text)),
                 (string.IsNullOrEmpty(txtS44.Text) ? 0 : Convert.ToInt32(txtS44.Text)),
                 (string.IsNullOrEmpty(txtS45.Text) ? 0 : Convert.ToInt32(txtS45.Text)),
                 (string.IsNullOrEmpty(txtS46.Text) ? 0 : Convert.ToInt32(txtS46.Text)),
                 (string.IsNullOrEmpty(txtS47.Text) ? 0 : Convert.ToInt32(txtS47.Text)));
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
                        //DataRow drProduct = dsMain.Tables["Products"].NewRow();
                        //drProduct[""] = dr[""];
                        //dsMain.Tables["Products"].

                        // ProductId , ProductCode , ProductName ,  ProductNature , PC.CategoryName , Product.MesurementUnitId
                    }

                    //dsMain.Tables["Products"] = manageProduct.GetUpdatedProducts();
                    //= manageProduct.GetUpdatedProducts();

                }
            }
            catch (Exception ex)
            {
            }

        }

        private void btnSearch_Click_1(object sender, EventArgs e)
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
                //else
                //{
                //    txtFormulaId.Text = string.Empty;
                //    txtFormulaId.Focus();
                //}
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
                //if (!string.IsNullOrEmpty(txtSONo.Text))
                //{
                //    ClearFeilds();
                //}
                txtSONo.Text = string.Empty;
                FormulaId = manageProduct.GetFormulaIdByCode(Convert.ToInt32(txtFormulaId.Text));
                if (FormulaId > 0)
                {
                    LoadProductFormula();
                    DataTable dtProduct = new DataTable();
                    dtProduct = manageProduct.GetProduct(Convert.ToInt32(dsMain.Tables["FormulaMaster"].Rows[0]["ProductId"]));
                    if (dtProduct.Rows.Count > 0)
                    {
                        txtPCode.Text = dtProduct.Rows[0]["ProductCode"].ToString();
                    }
                    txtFormulaName.Text = dsMain.Tables["FormulaMaster"].Rows[0]["FormulaName"].ToString();
                    txtQty.Text = string.Empty;
                    txtQty.ReadOnly = false;
                    txtS39.Text = string.Empty;
                    txtS40.Text = string.Empty;
                    txtS41.Text = string.Empty;
                    txtS42.Text = string.Empty;
                    txtS43.Text = string.Empty;
                    txtS44.Text = string.Empty;
                    txtS45.Text = string.Empty;
                    txtS46.Text = string.Empty;
                    txtS47.Text = string.Empty;

                    txtS39.ReadOnly = false;
                    txtS40.ReadOnly = false;
                    txtS41.ReadOnly = false;
                    txtS42.ReadOnly = false;
                    txtS43.ReadOnly = false;
                    txtS44.ReadOnly = false;
                    txtS45.ReadOnly = false;
                    txtS46.ReadOnly = false;
                    txtS47.ReadOnly = false;
                }
            }
            else
            {
                FormulaId = -1;
                txtFormulaName.Text = string.Empty;
                txtPCode.Text = string.Empty;
                //ClearFeilds();
            }
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFormulaId.Text) || !string.IsNullOrEmpty(txtSONo.Text))
            {
                setupGrip();
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility clsUtlity = new Utility();
            clsUtlity.setOnlyNumberic((TextBox)sender, false, e);
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
            if (!string.IsNullOrEmpty(txtSONo.Text))
            {
                try
                {
                    //if (!string.IsNullOrEmpty(txtFormulaId.Text))
                    //{
                    //    ClearFeilds();
                    //}
                    txtFormulaId.Text = string.Empty;
                    txtPCode.Text = string.Empty;
                    CustomerManager manageCustomer = new CustomerManager();
                    txtCustomerName.Text = manageCustomer.GetCustomer(manageCustomer.GetCustomerIdByCode(manageSalesOrder.GetSaleOrderMaster(manageSalesOrder.GetSalesOrderMasterIdByCode(txtSONo.Text)).Rows[0]["CustomerCode"].ToString())).Rows[0]["CustomerName"].ToString();
                    txtQty.Text = string.Empty;  //manageSalesOrder.Get
                    txtQty.ReadOnly = true;
                    txtS39.Text = string.Empty;
                    txtS40.Text = string.Empty;
                    txtS41.Text = string.Empty;
                    txtS42.Text = string.Empty;
                    txtS43.Text = string.Empty;
                    txtS44.Text = string.Empty;
                    txtS45.Text = string.Empty;
                    txtS46.Text = string.Empty;
                    txtS47.Text = string.Empty;

                    txtS39.ReadOnly = true;
                    txtS40.ReadOnly = true;
                    txtS41.ReadOnly = true;
                    txtS42.ReadOnly = true;
                    txtS43.ReadOnly = true;
                    txtS44.ReadOnly = true;
                    txtS45.ReadOnly = true;
                    txtS46.ReadOnly = true;
                    txtS47.ReadOnly = true;

                    LoadProductFormula();
                }
                catch (Exception ex)
                {
                    txtCustomerName.Text = string.Empty;
                }
            }
            else
            {
                txtCustomerName.Text = string.Empty;
            }
        }

        private void txtS39_TextChanged(object sender, EventArgs e)
        {
            int TotalQty = 0;
            int S39 = 0, S40 = 0, S41 = 0, S42 = 0, S43 = 0, S44 = 0, S45 = 0, S46 = 0, S47 = 0;
            if (!string.IsNullOrEmpty(txtS39.Text))
            {
                S39 = Convert.ToInt32(txtS39.Text);
            }
            if (!string.IsNullOrEmpty(txtS40.Text))
            {
                S40 = Convert.ToInt32(txtS40.Text);
            }
            if (!string.IsNullOrEmpty(txtS41.Text))
            {
                S41 = Convert.ToInt32(txtS41.Text);
            }
            if (!string.IsNullOrEmpty(txtS42.Text))
            {
                S42 = Convert.ToInt32(txtS42.Text);
            }
            if (!string.IsNullOrEmpty(txtS43.Text))
            {
                S43 = Convert.ToInt32(txtS43.Text);
            }
            if (!string.IsNullOrEmpty(txtS45.Text))
            {
                S45 = Convert.ToInt32(txtS45.Text);
            }
            if (!string.IsNullOrEmpty(txtS46.Text))
            {
                S46 = Convert.ToInt32(txtS46.Text);
            }
            if (!string.IsNullOrEmpty(txtS47.Text))
            {
                S47 = Convert.ToInt32(txtS47.Text);
            }
            TotalQty = S39 + S40 + S41 + S42 + S43 + S44 + S45 + S46 + S47;
            txtQty.Text = TotalQty.ToString();
        }

        Utility clsUtility = new Utility();
        private void txtS39_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.setOnlyNumberic((TextBox)sender, false, e);

        }




    }
}
