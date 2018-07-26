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
    public partial class frmProduction : Form
    {
        Smartworks.DAL dataAcess = new Smartworks.DAL();
        ProductManager manageProduct = new ProductManager();
        WarehouseManager manageWarehouse = new WarehouseManager();
        LastNoManager manageLastNo = new LastNoManager();
        SalesOrderManager manageSalesOrder = new SalesOrderManager();
        ProductionManager manageProduction = new ProductionManager();
        ProcessingManager manageProcessing = new ProcessingManager();
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
        DataSet dsMain = null;
        DataSet dsGrid = null;
        DataSet dsSubGrid = null;
        DataRow drMaster;
        DataView dvProduct;
        DataViewManager dvm;
        int ProductionId = -1;
        public frmProduction()
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
                txtCode.Text = GetNewNextNumber();
                btnNextInvioceNo.Enabled = false;
                btnPrevInvioceNo.Enabled = false;
                //xtraTabControl1.TabPages[0].Focus();
                xtraTabControl1.SelectedTabPage = xtraTabPage1;
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
            NewInvoiceNo = manageProduction.GetMaxInvioceNo();
            if (!string.IsNullOrEmpty(NewInvoiceNo))
            {
                NewInvoiceNo = manageProduction.GetNextInvioceNo(NewInvoiceNo);
            }
            else
            {
                NewInvoiceNo = "PD-000001";
            }
            return NewInvoiceNo;
        }

        private void FillDropDown()
        {
            DataTable dtWarehouse = new DataTable();
            dtWarehouse = manageWarehouse.GetWarehouseListSequance();
            DataRow drWarehouse = dtWarehouse.NewRow();
            drWarehouse["WarehouseId"] = -1;
            drWarehouse["Warehouse"] = "--Select Department--";
            dtWarehouse.Rows.InsertAt(drWarehouse, 0);
            cmbWarehouse.DataSource = dtWarehouse;
            cmbWarehouse.DisplayMember = "Warehouse";
            cmbWarehouse.ValueMember = "WarehouseId";


            DataTable dtToWarehouse = new DataTable();
            dtToWarehouse = manageWarehouse.GetWarehouseListSequance();
            DataRow drToWarehouse = dtToWarehouse.NewRow();
            drToWarehouse["WarehouseId"] = -1;
            drToWarehouse["Warehouse"] = "--Select Department--";
            dtToWarehouse.Rows.InsertAt(drToWarehouse, 0);
            cmbToWarehouse.DataSource = dtToWarehouse;
            cmbToWarehouse.DisplayMember = "Warehouse";
            cmbToWarehouse.ValueMember = "WarehouseId";


            DataTable dtFinalWarehouse = new DataTable();
            dtFinalWarehouse = manageWarehouse.GetWarehouseListSequance();
            DataRow drFinalWarehouse = dtFinalWarehouse.NewRow();
            drFinalWarehouse["WarehouseId"] = -1;
            drFinalWarehouse["Warehouse"] = "--Select Warehouse--";
            dtFinalWarehouse.Rows.InsertAt(drFinalWarehouse, 0);
            cmbFinalWarehouse.DataSource = dtFinalWarehouse;
            cmbFinalWarehouse.DisplayMember = "Warehouse";
            cmbFinalWarehouse.ValueMember = "WarehouseId";

            DataTable dtLastNo = new DataTable();
            dtLastNo = manageLastNo.GetLastNoList();
            DataRow drLastNo = dtLastNo.NewRow();
            drLastNo["LastNoId"] = -1;
            drLastNo["LastNo"] = "--Select Last#--";
            dtLastNo.Rows.InsertAt(drLastNo, 0);
            cmbLastNo.DataSource = dtLastNo;
            cmbLastNo.DisplayMember = "LastNo";
            cmbLastNo.ValueMember = "LastNoId";


            DataTable dtStatus = new DataTable();
            dtStatus = manageProduction.GetProductionStatusList();
            DataRow drProductionStatus = dtStatus.NewRow();
            drProductionStatus["ProductionStatusId"] = -1;
            drProductionStatus["ProductionStatus"] = "--Select Status--";
            dtStatus.Rows.InsertAt(drProductionStatus, 0);
            cmbStatus.DataSource = dtStatus;
            cmbStatus.DisplayMember = "ProductionStatus";
            cmbStatus.ValueMember = "ProductionStatusId";


        }


        private void FillGrid(int FormulaId, decimal Quantity, int WarehouseId, string SOrderNo, int ArticleId, DateTime Dated, string BatchNo)
        {
            dsGrid = new DataSet();
            DataTable dtFormulaDetail = new DataTable();
            if (ProductionId > 0)
            {
                //for Existing Production Table
                dtFormulaDetail = manageProduction.GetProductionDetailByMasterId(ProductionId, WarehouseId);
                if (!dsGrid.Tables.Contains("Warehouse"))
                {
                    dsGrid.Tables.Add(dsMain.Tables["Warehouse"].Clone());
                }

                if (WarehouseId > 0)
                {
                    DataRow drWarehouse = null;
                    if (dsMain.Tables["Warehouse"].Select("WarehouseId = '" + WarehouseId + "'").Length > 0)
                    {
                        drWarehouse = dsMain.Tables["Warehouse"].Select("WarehouseId = '" + WarehouseId + "'")[0];
                    }
                    if (drWarehouse != null)
                    {
                        if (dsGrid.Tables["Warehouse"].Select("WarehouseId = '" + WarehouseId + "'").Length == 0)
                        {
                            dsGrid.Tables["Warehouse"].ImportRow(drWarehouse);
                        }
                    }
                }
                else
                {
                    if (!dsGrid.Tables.Contains("Warehouse"))
                    {
                        dsGrid.Tables.Add(dsMain.Tables["Warehouse"].Copy());
                    }
                    else
                    {
                        dsGrid.Tables["Warehouse"].Rows.Clear();
                        foreach (DataRow drWarehouse in dsMain.Tables["Warehouse"].Rows)
                        {
                            dsGrid.Tables["Warehouse"].ImportRow(drWarehouse);
                        }
                    }

                }

                if (WarehouseId > 0)
                {
                    if (dsMain.Tables["ProductionDetail"].Select("WarehouseId = '" + WarehouseId + "'").Length > 0)
                    {
                        dsGrid.Tables.Add(dsMain.Tables["ProductionDetail"].Select("WarehouseId = '" + WarehouseId + "'").CopyToDataTable());
                        dsGrid.Tables[dsGrid.Tables.Count - 1].TableName = "ProductionDetail";
                    }
                    else
                    {
                        dsGrid.Tables.Add(dsMain.Tables["ProductionDetail"].Clone());
                    }

                }
                else
                {
                    dsGrid.Tables.Add(dsMain.Tables["ProductionDetail"].Copy());
                }


                if (dsMain.Tables["ProductionDetail"].Select("WarehouseId = '" + WarehouseId + "'").Length == 0)
                {
                    dtFormulaDetail = manageProduct.GetFormulaDetailForProduction(FormulaId, Quantity, WarehouseId, SOrderNo, ArticleId, Dated, BatchNo);
                    if (dtFormulaDetail.Rows.Count > 0)
                    {
                        foreach (DataRow drConfig in dtFormulaDetail.Rows)
                        {
                            DataRow drDetail = dsGrid.Tables["ProductionDetail"].NewRow();
                            drDetail["PMId"] = drMaster["PMId"];
                            drDetail["WarehouseId"] = drConfig["WarehouseId"];
                            drDetail["ProductId"] = drConfig["ProductId"];
                            drDetail["ActualProductId"] = drConfig["ActualProductId"];
                            drDetail["UnitId"] = drConfig["UnitId"];
                            drDetail["AssumeQty"] = drConfig["Qty"];
                            drDetail["AvailableQty"] = drConfig["AvailableQty"];
                            drDetail["ConsumeQty"] = 0;
                            drDetail["BalanceQty"] = (Convert.ToDecimal(drDetail["AvailableQty"]) - Convert.ToDecimal(drDetail["ConsumeQty"])).ToString();
                            drDetail["Rate"] = 0;
                            drDetail["Amount"] = Convert.ToDecimal(drDetail["ConsumeQty"]) * Convert.ToDecimal(drDetail["Rate"]);
                            if (dsGrid.Tables["ProductionDetail"].Select("WarehouseId = '" + drConfig["WarehouseId"].ToString() + "' and ActualProductId ='" + drConfig["ActualProductId"].ToString() + "'").Length == 0)
                            {
                                //yahan mjy ek dout yeh hai k Warehouse k 7 7 Actual Product Id ka filter bhi lagy ga Salman.
                                dsGrid.Tables["ProductionDetail"].Rows.Add(drDetail);
                            }

                        }
                    }
                }


            }
            else
            {
                //new Record Inserting
                dtFormulaDetail = manageProduct.GetFormulaDetailForProduction(FormulaId, Quantity, WarehouseId, SOrderNo, ArticleId, Dated, BatchNo);
                if (WarehouseId > 0)
                {
                    DataRow drWarehouse = null;
                    if (dsMain.Tables["Warehouse"].Select("WarehouseId = '" + WarehouseId + "'").Length > 0)
                    {
                        drWarehouse = dsMain.Tables["Warehouse"].Select("WarehouseId = '" + WarehouseId + "'")[0];
                    }
                    if (drWarehouse != null)
                    {
                        dsGrid.Tables.Add(dsMain.Tables["Warehouse"].Clone());
                        dsGrid.Tables["Warehouse"].ImportRow(drWarehouse);
                    }
                    else
                    {
                        dsGrid.Tables.Add(dsMain.Tables["Warehouse"].Clone());
                    }

                }
                else
                {
                    //ab hum ko Depart Select kerna lazmi hai.
                    dsGrid.Tables.Add(dsMain.Tables["Warehouse"].Copy());
                }
                dsGrid.Tables.Add(dsMain.Tables["ProductionDetail"].Copy());
            }



            //dsGrid.Tables.Add(dsMain.Tables["ProductionDetail"].Copy());

            dsGrid.Relations.Add("WarehouseRelation", dsGrid.Tables["Warehouse"].Columns["WarehouseId"], dsGrid.Tables["ProductionDetail"].Columns["WarehouseId"]);

            GCDetail.DataSource = dsGrid; //dsGrid.Tables["Warehouse"]; //dsMain.Tables["FormulaDetail"];
            GCDetail.DataMember = "Warehouse";
            GCDetail.ForceInitialize();
            GCDetail.Enabled = true;
            gvDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            gvDetail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;

            gvDetail.Columns.ColumnByName("colWarehouseId").Visible = false;

            gvDetail.Columns.ColumnByName("colWarehouseName").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colWarehouseName").Caption = "";
            gvDetail.Columns.ColumnByName("colWarehouseName").Width = GCDetail.Width - 150;
            gvDetail.OptionsView.ShowViewCaption = false;
            gvDetail.Columns.ColumnByName("colWarehouseName").AppearanceCell.Font = new Font("Arial", 10f, FontStyle.Bold);
            //gvDetail.Columns.ColumnByName("colWarehouseName").AppearanceCell.BackColor = Color.LightGreen;
            gvDetail.DetailHeight = 500;

            if (ProductionId < 0)
            {
                if (dsGrid.Tables["ProductionDetail"].Rows.Count == 0)
                {
                    if (dtFormulaDetail.Rows.Count > 0)
                    {
                        foreach (DataRow drConfig in dtFormulaDetail.Rows)
                        {
                            DataRow drDetail = dsGrid.Tables["ProductionDetail"].NewRow();
                            drDetail["PMId"] = drMaster["PMId"];
                            drDetail["WarehouseId"] = drConfig["WarehouseId"];
                            drDetail["ProductId"] = drConfig["ProductId"];
                            drDetail["ActualProductId"] = drConfig["ActualProductId"];
                            drDetail["UnitId"] = drConfig["UnitId"];
                            drDetail["AssumeQty"] = drConfig["Qty"];
                            drDetail["AvailableQty"] = drConfig["AvailableQty"];
                            drDetail["ConsumeQty"] = 0;
                            drDetail["BalanceQty"] = (Convert.ToDecimal(drDetail["AvailableQty"]) - Convert.ToDecimal(drDetail["ConsumeQty"])).ToString();
                            drDetail["Rate"] = 0;
                            drDetail["Amount"] = Convert.ToDecimal(drDetail["ConsumeQty"]) * Convert.ToDecimal(drDetail["Rate"]);
                            dsGrid.Tables["ProductionDetail"].Rows.Add(drDetail);
                        }
                    }
                }
            }
            else
            {
                //if (dtFormulaDetail.Rows.Count > 0)
                //{
                //    foreach (DataRow drConfig in dtFormulaDetail.Rows)
                //    {
                //        dsGrid.Tables["ProductionDetail"].ImportRow(drConfig);
                //        //DataRow drDetail = dsGrid.Tables["ProductionDetail"].NewRow();
                //        //drDetail["PMId"] = drMaster["PMId"];
                //        //drDetail["WarehouseId"] = drConfig["WarehouseId"];
                //        //if (!string.IsNullOrEmpty(drConfig["ActualProductId"].ToString()))
                //        //{
                //        //    if (Convert.ToInt32(drConfig["ActualProductId"].ToString()) < 0)
                //        //    {
                //        //        drDetail["ProductId"] = drConfig["ProductId"];
                //        //    }
                //        //    else
                //        //    {
                //        //        drDetail["ProductId"] = drConfig["ActualProductId"];
                //        //    }
                //        //}
                //        //else
                //        //{
                //        //    drDetail["ProductId"] = drConfig["ProductId"];
                //        //}

                //        //drDetail["UnitId"] = drConfig["UnitId"];
                //        //drDetail["AssumeQty"] = drConfig["Qty"];
                //        //drDetail["AvailableQty"] = drConfig["AvailableQty"];
                //        //drDetail["ConsumeQty"] = 0;
                //        //drDetail["BalanceQty"] = (Convert.ToDecimal(drDetail["AvailableQty"]) - Convert.ToDecimal(drDetail["ConsumeQty"])).ToString();
                //        //drDetail["Rate"] = 0;
                //        //drDetail["Amount"] = Convert.ToDecimal(drDetail["ConsumeQty"]) * Convert.ToDecimal(drDetail["Rate"]);
                //        //dsGrid.Tables["ProductionDetail"].Rows.Add(drDetail);
                //    }
                //}
            }
        }
        private void setupGrip()
        {
            dsMain = new DataSet();
            dsMain = manageProduction.GetProductionStructure(ProductionId);

            dsMain.Tables[0].TableName = "ProductionMaster";
            dsMain.Tables[1].TableName = "ProductionDetail";
            dsMain.Tables[2].TableName = "Products";
            dsMain.Tables[3].TableName = "MesurementUnit";
            dsMain.Tables[4].TableName = "FormulaConfig";
            dsMain.Tables[5].TableName = "Warehouse";
            dsMain.Tables[6].TableName = "Color";
            dsMain.Tables[7].TableName = "ProductionSubDetail";

            dsGrid = new DataSet();
            dsGrid.Tables.Add(dsMain.Tables["Warehouse"].Copy());
            dsGrid.Tables.Add(dsMain.Tables["ProductionDetail"].Copy());


            dsMain.Tables["ProductionMaster"].Columns["PMId"].AutoIncrement = true;
            dsMain.Tables["ProductionMaster"].Columns["PMId"].AutoIncrementSeed = -1;
            dsMain.Tables["ProductionMaster"].Columns["PMId"].AutoIncrementStep = -1;

            dsMain.Tables["ProductionDetail"].Columns["PDId"].AutoIncrement = true;
            dsMain.Tables["ProductionDetail"].Columns["PDId"].AutoIncrementSeed = -1;
            dsMain.Tables["ProductionDetail"].Columns["PDId"].AutoIncrementStep = -1;



            dsMain.Relations.Add("MasterRelation", dsMain.Tables["ProductionMaster"].Columns["PMId"], dsMain.Tables["ProductionDetail"].Columns["PMId"]);

            dsGrid.Relations.Add("WarehouseRelation", dsGrid.Tables["Warehouse"].Columns["WarehouseId"], dsGrid.Tables["ProductionDetail"].Columns["WarehouseId"]);

            drMaster = dsMain.Tables["ProductionMaster"].NewRow();
            dsMain.Tables["ProductionMaster"].Rows.Add(drMaster);
            dvm = new DataViewManager(dsMain);
            dvProduct = dvm.CreateDataView(dsMain.Tables["Products"]);

            dsSubGrid = new DataSet();
            dsSubGrid.Tables.Add(dsMain.Tables["ProductionSubDetail"].Copy());
            GCSubDetail.DataSource = dsSubGrid;
            GCSubDetail.DataMember = "ProductionSubDetail";
            GCSubDetail.ForceInitialize();
            SubDetailGridSetting();



            //GCDetail.DataSource = dsMain;
            //GCDetail.DataMember = "ProcessDetail";
            //GCDetail.ForceInitialize();
            //GridSetting();


            //GCDetail.DataSource = dsGrid; //dsGrid.Tables["Warehouse"]; //dsMain.Tables["FormulaDetail"];
            //GCDetail.DataMember = "Warehouse";
            //GCDetail.ForceInitialize();


            //gvDetail.Columns.ColumnByName("colWarehouseId").Visible = false;

            //gvDetail.Columns.ColumnByName("colWarehouseName").OptionsColumn.AllowEdit = false;
            //gvDetail.Columns.ColumnByName("colWarehouseName").Caption = "";
            //gvDetail.Columns.ColumnByName("colWarehouseName").Width = GCDetail.Width - 150;
            //gvDetail.OptionsView.ShowViewCaption = false;
            //gvDetail.Columns.ColumnByName("colWarehouseName").AppearanceCell.Font = new Font("Arial", 10f, FontStyle.Bold);
            ////gvDetail.Columns.ColumnByName("colWarehouseName").AppearanceCell.BackColor = Color.LightGreen;
            //gvDetail.DetailHeight = 500;
            ////gvDetail.Appearance.Row.Font = new Font("Arial", 12f);
            ////gvDetail.Columns.ColumnByName("colWarehouseName").
            ////GridSetting();

            ////if (dsMain.Tables["FormulaDetail"].Rows.Count == 0)
            ////{
            ////    if (dsMain.Tables["FormulaConfig"].Rows.Count > 0)
            ////    {
            ////        foreach (DataRow drConfig in dsMain.Tables["FormulaConfig"].Rows)
            ////        {
            ////            DataRow drDetail = dsMain.Tables["FormulaDetail"].NewRow();
            ////            drDetail["FormulaMasterId"] = drMaster["FormulaMasterId"];
            ////            drDetail["WarehouseId"] = drConfig["WarehouseId"];
            ////            drDetail["ProductId"] = drConfig["ProductId"];
            ////            drDetail["UnitId"] = drConfig["UnitId"];
            ////            drDetail["Qty"] = 0;
            ////            dsMain.Tables["FormulaDetail"].Rows.Add(drDetail);
            ////        }
            ////    }
            ////}



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

        private void SubDetailGridSetting()
        {
            gvSubDetail.Columns.ColumnByName("colSubDetailId").OptionsColumn.ReadOnly = true;
            gvSubDetail.Columns.ColumnByName("colPMId").OptionsColumn.ReadOnly = true;

            gvSubDetail.Columns.ColumnByName("colSubDetailId").Visible = false;
            gvSubDetail.Columns.ColumnByName("colPMId").Visible = false;
            gvSubDetail.Columns.ColumnByName("colStatusId").Visible = false;

            //gvSubDetail.Columns.ColumnByName("colReceivedDate").Visible = false;
            gvSubDetail.Columns.ColumnByName("colTransferDate").Visible = false;

            gvSubDetail.Columns.ColumnByName("colSOrderId").Visible = false;
            gvSubDetail.Columns.ColumnByName("colProductId").Visible = false;
            gvSubDetail.Columns.ColumnByName("colWarehouseId").Visible = false;
            gvSubDetail.Columns.ColumnByName("colTransferWarehouseId").Visible = false;



            gvSubDetail.Columns.ColumnByName("colFromDepart").Caption = "From Depart";
            gvSubDetail.Columns.ColumnByName("colProcessQty").Caption = "Quantity";
            gvSubDetail.Columns.ColumnByName("colSOrderNo").Caption = "Sale Order #";
            gvSubDetail.Columns.ColumnByName("colProductName").Caption = "Article Name";
            gvSubDetail.Columns.ColumnByName("colToDepart").Caption = "Transfer Depart";
            gvSubDetail.Columns.ColumnByName("colRemarks").Caption = "Remarks";
            gvSubDetail.Columns.ColumnByName("colReceivedDate").Caption = "Dated";


            gvSubDetail.Columns.ColumnByName("colSOrderNo").VisibleIndex = 0;
            gvSubDetail.Columns.ColumnByName("colProductName").VisibleIndex = 1;
            gvSubDetail.Columns.ColumnByName("colReceivedDate").VisibleIndex = 2;
            gvSubDetail.Columns.ColumnByName("colFromDepart").VisibleIndex = 3;
            gvSubDetail.Columns.ColumnByName("colProcessQty").VisibleIndex = 4;
            gvSubDetail.Columns.ColumnByName("colToDepart").VisibleIndex = 5;
            gvSubDetail.Columns.ColumnByName("colRemarks").VisibleIndex = 6;


            gvSubDetail.Columns.ColumnByName("colSOrderNo").Width = 150;
            gvSubDetail.Columns.ColumnByName("colProductName").Width = 250;
            gvSubDetail.Columns.ColumnByName("colReceivedDate").Width = 150;
            gvSubDetail.Columns.ColumnByName("colFromDepart").Width = 100;
            gvSubDetail.Columns.ColumnByName("colProcessQty").Width = 80;
            gvSubDetail.Columns.ColumnByName("colToDepart").Width = 100;
            gvSubDetail.Columns.ColumnByName("colRemarks").Width = 150;


            gvSubDetail.Columns.ColumnByName("colFromDepart").OptionsColumn.AllowEdit = false;
            gvSubDetail.Columns.ColumnByName("colProcessQty").OptionsColumn.AllowEdit = false;
            gvSubDetail.Columns.ColumnByName("colReceivedDate").OptionsColumn.AllowEdit = false;
            gvSubDetail.Columns.ColumnByName("colReceivedDate").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gvSubDetail.Columns.ColumnByName("colReceivedDate").DisplayFormat.FormatString = "dd-MMM-yyyy";
            gvSubDetail.Columns.ColumnByName("colSOrderNo").OptionsColumn.AllowEdit = false;
            gvSubDetail.Columns.ColumnByName("colProductName").OptionsColumn.AllowEdit = false;
            gvSubDetail.Columns.ColumnByName("colToDepart").OptionsColumn.AllowEdit = false;
            gvSubDetail.Columns.ColumnByName("colRemarks").OptionsColumn.AllowEdit = false;

            gvSubDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;

        }


        private void gvDetail_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView gridViewWelds = sender as GridView;
            GridView gridViewTests = gridViewWelds.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            gridViewTests.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            gridViewTests.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            //gridViewTests.CellValueChanged += Custom_CellValueChanged;
            //gridViewTests.MasterRowExpanded += new CustomMasterRowEventHandler(gridViewTests_MasterRowExpanded);
            gridViewTests.BeginUpdate();
            //gridViewTests.Columns["Id"].Visible = false;
            //gridViewTests.Columns["Id"].OptionsColumn.ShowInCustomizationForm = false;
            //gridViewTests.Columns["WeldId"].Visible = false;
            //gridViewTests.Columns["WeldId"].OptionsColumn.ShowInCustomizationForm = false;
            gridViewTests.Columns.ColumnByName("colPDId").OptionsColumn.ReadOnly = true;
            gridViewTests.Columns.ColumnByName("colPMId").OptionsColumn.ReadOnly = true;

            gridViewTests.Columns.ColumnByName("colPMId").Visible = false;
            gridViewTests.Columns.ColumnByName("colPDId").Visible = false;
            gridViewTests.Columns.ColumnByName("colWarehouseId").Visible = false;
            gridViewTests.Columns.ColumnByName("colRate").Visible = false;
            gridViewTests.Columns.ColumnByName("colAmount").Visible = false;

            gridViewTests.Columns.ColumnByName("colProductId").OptionsColumn.AllowEdit = true;
            gridViewTests.Columns.ColumnByName("colActualProductId").OptionsColumn.AllowEdit = true;
            gridViewTests.Columns.ColumnByName("colUnitId").OptionsColumn.AllowEdit = true;
            gridViewTests.Columns.ColumnByName("colAssumeQty").OptionsColumn.AllowEdit = false;
            gridViewTests.Columns.ColumnByName("colAvailableQty").OptionsColumn.AllowEdit = false;
            gridViewTests.Columns.ColumnByName("colBalanceQty").OptionsColumn.AllowEdit = false;
            gridViewTests.Columns.ColumnByName("colAmount").OptionsColumn.AllowEdit = false;


            gridViewTests.Columns.ColumnByName("colProductId").Caption = "Material Description";
            gridViewTests.Columns.ColumnByName("colActualProductId").Caption = "Article";
            gridViewTests.Columns.ColumnByName("colColorId").Caption = "Colour";
            gridViewTests.Columns.ColumnByName("colUnitId").Caption = "Unit";
            gridViewTests.Columns.ColumnByName("colAssumeQty").Caption = "Required.";
            gridViewTests.Columns.ColumnByName("colAvailableQty").Caption = "Issue.";
            gridViewTests.Columns.ColumnByName("colConsumeQty").Caption = "Consume.";
            gridViewTests.Columns.ColumnByName("colBalanceQty").Caption = "Balance.";
            //gridViewTests.Columns.ColumnByName("colWarehouseId").Caption = "Warehouse";
            gridViewTests.Columns.ColumnByName("colRemarks").Caption = "Remarks";

            //gridViewTests.Columns.ColumnByName("colWarehouseId").VisibleIndex = 0;
            gridViewTests.Columns.ColumnByName("colProductId").VisibleIndex = 1;
            gridViewTests.Columns.ColumnByName("colActualProductId").VisibleIndex = 2;
            gridViewTests.Columns.ColumnByName("colColorId").VisibleIndex = 3;
            gridViewTests.Columns.ColumnByName("colUnitId").VisibleIndex = 4;
            gridViewTests.Columns.ColumnByName("colAssumeQty").VisibleIndex = 5;
            gridViewTests.Columns.ColumnByName("colAvailableQty").VisibleIndex = 6;
            gridViewTests.Columns.ColumnByName("colConsumeQty").VisibleIndex = 7;
            gridViewTests.Columns.ColumnByName("colBalanceQty").VisibleIndex = 8;
            gridViewTests.Columns.ColumnByName("colRemarks").VisibleIndex = 9;
            //gridViewTests.Columns.ColumnByName("colQty").VisibleIndex = 6;

            //gridViewTests.Columns.ColumnByName("colWarehouseId").Width = 120;
            gridViewTests.Columns.ColumnByName("colProductId").Width = 250;
            gridViewTests.Columns.ColumnByName("colActualProductId").Width = 250;
            gridViewTests.Columns.ColumnByName("colColorId").Width = 100;
            gridViewTests.Columns.ColumnByName("colUnitId").Width = 80;
            gridViewTests.Columns.ColumnByName("colAssumeQty").Width = 60;
            gridViewTests.Columns.ColumnByName("colAvailableQty").Width = 60;
            gridViewTests.Columns.ColumnByName("colConsumeQty").Width = 60;
            gridViewTests.Columns.ColumnByName("colBalanceQty").Width = 60;
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
            repositoryWarehouseGridLookup.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            repositoryWarehouseGridLookup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            repositoryWarehouseGridLookup.ImmediatePopup = true;
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

        private void ButtonRights(bool Enable)
        {
            btnAdd.Enabled = Enable;
            btnUpdate.Enabled = !Enable;
            btnPost.Enabled = !Enable;
            btnDelete.Enabled = !Enable;
            txtCode.ReadOnly = !Enable;
            btnUnPost.Enabled = !Enable;

        }

        private bool Validation()
        {
            bool result = true;

            if (string.IsNullOrEmpty(txtSOrderNo.Text))
            {
                MessageBox.Show("Please Select Sales Order Number", "Sales Order is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                btnSOSearch.Focus();
                return result;
            }

            if (string.IsNullOrEmpty(txtPCode.Text))
            {
                MessageBox.Show("Please Select Product Name", "Product Name is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                btnPSearch.Focus();
                return result;
            }

            if (string.IsNullOrEmpty(txtProcessQty.Text))
            {
                MessageBox.Show("Please Enter Process Quantity", "Process Quantity is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtProcessQty.Focus();
                return result;
            }

            if (Convert.ToDecimal(txtProcessQty.Text) <= 0)
            {
                MessageBox.Show("Please Enter Process Quantity", "Process Quantity is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtProcessQty.Focus();
                return result;

            }

            if (Convert.ToInt32(cmbFormula.SelectedValue) <= 0)
            {
                MessageBox.Show("Please Select Article Recipe", "Article Recipe is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                cmbFormula.Focus();
                return result;
            }

            if (Convert.ToInt32(cmbWarehouse.SelectedValue) <= 0)
            {
                MessageBox.Show("Please Select From Depart Name", "From Depart Name is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                cmbWarehouse.Focus();
                return result;
            }

            if (Convert.ToInt32(cmbToWarehouse.SelectedValue) <= 0)
            {
                MessageBox.Show("Please Select To Depart Name", "To Depart Name is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                cmbToWarehouse.Focus();
                return result;
            }


            if (Convert.ToInt32(cmbWarehouse.SelectedValue) == Convert.ToInt32(cmbToWarehouse.SelectedValue))
            {
                if (chkIsComplete.Checked)
                {
                    //agr end per Finish se Finish jata hai and chk mark kia hua hai toh ok hai sab, else error dega.
                }
                else
                {
                    MessageBox.Show("Transfer Depart and Received Depart will not be Same.", "Same Depart Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    result = false;
                    cmbToWarehouse.Focus();
                    return result;
                }

            }

            //if (string.IsNullOrEmpty(txtBatchNo.Text))
            //{
            //    MessageBox.Show("Please Enter Production Batch No.", "Batch No. is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    result = false;
            //    txtBatchNo.Focus();
            //    return result;
            //}

            if (Convert.ToInt32(cmbStatus.SelectedValue) <= 0)
            {
                MessageBox.Show("Please Select Production Status.", "Status is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                cmbStatus.Focus();
                return result;
            }
            if (Convert.ToInt32(cmbFinalWarehouse.SelectedValue) <= 0)
            {
                MessageBox.Show("Please Select Final Department Name.", "Final Store is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                cmbFinalWarehouse.Focus();
                return result;
            }


            //if (string.IsNullOrEmpty(txtFormulaName.Text))
            //{
            //    MessageBox.Show("Please Enter Product Formula Name", "Formula Name is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    result = false;
            //    txtFormulaName.Focus();
            //    return result;
            //}


            if (string.IsNullOrEmpty(txtTotalQty.Text))
            {
                MessageBox.Show("Total Quantity of Size not Found.", "Enter Size of Production Articles", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtTotalQty.Focus();
                return result;
            }

            if (!string.IsNullOrEmpty(txtProcessQty.Text) && !string.IsNullOrEmpty(txtTotalQty.Text))
            {
                if (Convert.ToDecimal(txtProcessQty.Text) != Convert.ToDecimal(txtTotalQty.Text))
                {
                    MessageBox.Show("Total Quantity of Size And Process Quantity should be Same.", "Different Quantity values does not accepted.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    result = false;
                    txtTotalQty.Focus();
                    return result;
                }
            }

            if (dsGrid.Tables["ProductionDetail"].Rows.Count <= 0)
            {
                MessageBox.Show("Please Enter Production Detail", "Production Details Not Found.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                cmbFormula.Focus();
                return result;
            }

            if (chkIsComplete.Checked)
            {
                if ((string.IsNullOrEmpty(txtActualTotalQty.Text) ? 0 : Convert.ToInt32(txtActualTotalQty.Text)) <= 0)
                {
                    MessageBox.Show("Please Enter Detail of Actual Production Sizes.", "Actaul Production Size Details Not Found.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    result = false;
                    txtA39.Focus();
                    return result;
                }

                if ((string.IsNullOrEmpty(txtActualTotalQty.Text) ? 0 : Convert.ToInt32(txtActualTotalQty.Text)) > (string.IsNullOrEmpty(txtActaulQty.Text) ? 0 : Convert.ToInt32(txtActaulQty.Text)))
                {
                    MessageBox.Show("Actual Quantity Shuold Not Greater then Actaul Process Quantity.", "Actaul Quantity Invalid.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    result = false;
                    txtA39.Focus();
                    return result;
                }
            }

            if ((string.IsNullOrEmpty(txtActualTotalQty.Text) ? 0 : Convert.ToInt32(txtActualTotalQty.Text)) > (string.IsNullOrEmpty(txtTotalQty.Text) ? 0 : Convert.ToInt32(txtTotalQty.Text)))
            {
                MessageBox.Show("Total Acutal Quantity Shoulde not greater then Total Quantity.", "Invalid Actaul Quantity.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtA39.Focus();
                return result;
            }

            return result;
        }

        private bool ValidateProcessData()
        {
            bool Result = true;
            try
            {
                int ProductId = -1;
                int WarehouseId = -1;
                decimal ActualQty = 0;
                string SOrderNo = string.Empty;
                SOrderNo = txtSOrderNo.Text;
                ProductId = manageProduct.GetProductIdByCode(txtPCode.Text);
                WarehouseId = Convert.ToInt32(cmbWarehouse.SelectedValue);
                ActualQty = (string.IsNullOrEmpty(txtActaulQty.Text) ? 0 : Convert.ToInt32(txtActaulQty.Text));

                decimal ValidQty = manageProcessing.GetProcessingQtyBalance(ProductId, dtpProcess.Value, WarehouseId, SOrderNo, ProductId);

                if (ActualQty > ValidQty)
                {
                    MessageBox.Show("Invalid Process Qty Enterd in " + SOrderNo + " . and Article Name :" + txtPName.Text + " and Warehouse Name :" + cmbWarehouse.Text.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Result = false;
                    return Result;
                }

                DataRow drSubDetailRow = null;
                IEnumerable<DataRow> selectedRows = dsSubGrid.Tables["ProductionSubDetail"].AsEnumerable().Where(
                    row => (row.Field<Int32>("WarehouseId") == Convert.ToInt32(cmbWarehouse.SelectedValue)
                        && row.Field<Int32>("TransferWarehouseId") == Convert.ToInt32(cmbToWarehouse.SelectedValue)
                        && row.Field<DateTime>("ReceivedDate").Date == dtpProcess.Value.Date));
                if (selectedRows.Count() > 0)
                {
                    //drSubDetailRow = selectedRows()[0];
                    foreach (DataRow dr in selectedRows)
                    {
                        drSubDetailRow = dr;
                    }
                    if (drSubDetailRow != null)
                    {
                        drSubDetailRow["ProcessQty"] = ActualQty;
                    }
                }
                else
                {
                    drSubDetailRow = dsSubGrid.Tables["ProductionSubDetail"].NewRow();
                    drSubDetailRow["SubDetailId"] = -1;
                    drSubDetailRow["PMId"] = -1;
                    drSubDetailRow["SOrderId"] = manageSalesOrder.GetSalesOrderMasterIdByCode(txtSOrderNo.Text);
                    drSubDetailRow["SOrderNo"] = txtSOrderNo.Text;
                    drSubDetailRow["ProductId"] = ProductId;
                    drSubDetailRow["ProductName"] = txtPName.Text;
                    drSubDetailRow["WarehouseId"] = Convert.ToInt32(cmbWarehouse.SelectedValue);
                    drSubDetailRow["FromDepart"] = cmbWarehouse.Text.ToString();
                    drSubDetailRow["ReceivedDate"] = dtpProcess.Value;
                    drSubDetailRow["ProcessQty"] = ActualQty;
                    drSubDetailRow["TransferWarehouseId"] = Convert.ToInt32(cmbToWarehouse.SelectedValue);
                    drSubDetailRow["ToDepart"] = cmbToWarehouse.Text.ToString();
                    drSubDetailRow["TransferDate"] = dtpProcess.Value;
                    drSubDetailRow["StatusId"] = -1;
                    drSubDetailRow["Remarks"] = "";
                    dsSubGrid.Tables["ProductionSubDetail"].Rows.Add(drSubDetailRow);
                }
                
                //if (dsSubGrid.Tables["ProductionSubDetail"].Select("WarehouseId = '" + Convert.ToInt32(cmbWarehouse.SelectedValue) + "' And TransferWarehouseId = '" + Convert.ToInt32(cmbToWarehouse.SelectedValue) + "' and ReceivedDate  = '"+ dtpProcess.Value.Date +"' ").Length > 0)
                //{
                //    drSubDetailRow = dsSubGrid.Tables["ProductionSubDetail"].Select("WarehouseId = '" + Convert.ToInt32(cmbWarehouse.SelectedValue) + "' And TransferWarehouseId = '" + Convert.ToInt32(cmbToWarehouse.SelectedValue) + "' and ReceivedDate  = '" + dtpProcess.Value.Date + "'  ")[0];
                //}
                //else
                //{
                //    drSubDetailRow = dsSubGrid.Tables["ProductionSubDetail"].NewRow();
                //    drSubDetailRow["SubDetailId"] = -1;
                //    drSubDetailRow["PMId"] = -1;
                //    drSubDetailRow["SOrderId"] = manageSalesOrder.GetSalesOrderMasterIdByCode(txtSOrderNo.Text);
                //    drSubDetailRow["SOrderNo"] = txtSOrderNo.Text;
                //    drSubDetailRow["ProductId"] = ProductId;
                //    drSubDetailRow["ProductName"] = txtPName.Text;
                //    drSubDetailRow["WarehouseId"] = Convert.ToInt32(cmbWarehouse.SelectedValue);
                //    drSubDetailRow["FromDepart"] = cmbWarehouse.Text.ToString();
                //    drSubDetailRow["ReceivedDate"] = dtpProcess.Value;
                //    drSubDetailRow["ProcessQty"] = ActualQty;
                //    drSubDetailRow["TransferWarehouseId"] = Convert.ToInt32(cmbToWarehouse.SelectedValue);
                //    drSubDetailRow["ToDepart"] = cmbToWarehouse.Text.ToString();
                //    drSubDetailRow["TransferDate"] = dtpProcess.Value;
                //    drSubDetailRow["StatusId"] = -1;
                //    drSubDetailRow["Remarks"] = "";
                //    dsSubGrid.Tables["ProductionSubDetail"].Rows.Add(drSubDetailRow);
                //}
            }
            catch (Exception ex)
            {
                Result = false;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }

            return Result;
        }

        private void ClearFeilds()
        {

            //Clrear bhi Squance se kerna hai warna error ary hain Salman.
            txtA39.Text = string.Empty;
            txtA40.Text = string.Empty;
            txtA41.Text = string.Empty;
            txtA42.Text = string.Empty;
            txtA43.Text = string.Empty;
            txtA44.Text = string.Empty;
            txtA45.Text = string.Empty;
            txtA46.Text = string.Empty;
            txtA47.Text = string.Empty;


            txtS39.Text = string.Empty;
            txtS40.Text = string.Empty;
            txtS41.Text = string.Empty;
            txtS42.Text = string.Empty;
            txtS43.Text = string.Empty;
            txtS44.Text = string.Empty;
            txtS45.Text = string.Empty;
            txtS46.Text = string.Empty;
            txtS47.Text = string.Empty;

            //txtFormulaName.Text = string.Empty;
            txtSOrderNo.Text = string.Empty;
            txtPCode.Text = string.Empty;
            txtOrderQty.Text = string.Empty;
            txtDoneQty.Text = string.Empty;
            txtProcessQty.Text = string.Empty;
            dtpOrder.Value = DateTime.Now;
            dtp.Value = DateTime.Now;
            cmbFormula.SelectedValue = -1;
            cmbLastNo.SelectedValue = -1;
            cmbStatus.SelectedValue = -1;
            cmbWarehouse.SelectedValue = -1;
            cmbToWarehouse.SelectedValue = -1;
            cmbFinalWarehouse.SelectedValue = -1;
            txtConstruction.Text = string.Empty;
            txtModelSize.Text = string.Empty;
            txtSizeRange.Text = string.Empty;
            txtBatchNo.Text = string.Empty;
            txtRemarks.Text = string.Empty;


           

            

            pbitem.Image = FIL.Properties.Resources.User;
            ProductionId = -1;
            txtProcessQty.ReadOnly = false;
            cmbFormula.Enabled = true;
            txtBatchNo.Enabled = true;
            dsMain.Tables["ProductionDetail"].Rows.Clear();
            dsMain.Tables["ProductionMaster"].Rows.Clear();

            dsMain.RejectChanges();
            drMaster = dsMain.Tables["ProductionMaster"].NewRow();
            dsMain.Tables["ProductionMaster"].Rows.Add(drMaster);
            // GCDetail.DataSource = dsMain.Tables["FormulaDetail"];
            //GridSetting();

            //dsSubGrid = new DataSet();
            //dsSubGrid.Tables.Add(dsMain.Tables["ProductionSubDetail"].Copy());
            //GCSubDetail.DataSource = dsSubGrid;
            //GCSubDetail.DataMember = "ProductionSubDetail";
            //GCSubDetail.ForceInitialize();
            //SubDetailGridSetting();
            dsSubGrid.Tables["ProductionSubDetail"].Rows.Clear();

            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            txtCode.Text = GetNewNextNumber();
            //**** for post control clear 
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnPost.Enabled = true;
            btnDelete.Enabled = true;
            cmbWarehouse.Enabled = true;
            cmbFinalWarehouse.Enabled = true;
            lblPosted.Visible = false;

            txtActaulQty.Text = string.Empty;
            cmbToWarehouse.SelectedIndex = 0;
            dtpProcess.Value = DateTime.Now;
            chkIsComplete.Checked = false;
            //****
            ButtonRights(true);
            btnNextInvioceNo.Enabled = false;
            btnPrevInvioceNo.Enabled = false;
            IsProductionLoad = false;

            //setupGrip();
            //cmbFormula.Focus();

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
        bool IsProductionLoad = false;
        private void LoadProduction()
        {
            IsProductionLoad = true;
            setupGrip();

            txtSOrderNo.Text = dsMain.Tables["ProductionMaster"].Rows[0]["SOrderNo"].ToString();

            DataTable dtProduct = new DataTable();
            dtProduct = manageProduct.GetProduct(Convert.ToInt32(dsMain.Tables["ProductionMaster"].Rows[0]["ProductId"]));
            if (dtProduct.Rows.Count > 0)
            {
                txtPCode.Text = dtProduct.Rows[0]["ProductCode"].ToString();
            }
            txtProcessQty.Text = dsMain.Tables["ProductionMaster"].Rows[0]["ProcessQty"].ToString();
            cmbFormula.SelectedValue = dsMain.Tables["ProductionMaster"].Rows[0]["PFMId"];
            dtp.Value = Convert.ToDateTime(dsMain.Tables["ProductionMaster"].Rows[0]["Date"]);
            txtConstruction.Text = dsMain.Tables["ProductionMaster"].Rows[0]["Construction"].ToString();
            cmbWarehouse.SelectedValue = dsMain.Tables["ProductionMaster"].Rows[0]["WarehouseId"].ToString();
            txtSizeRange.Text = dsMain.Tables["ProductionMaster"].Rows[0]["SizeRange"].ToString();
            txtBatchNo.Text = dsMain.Tables["ProductionMaster"].Rows[0]["BatchNo"].ToString();
            cmbLastNo.SelectedValue = dsMain.Tables["ProductionMaster"].Rows[0]["LastNoId"].ToString();
            txtModelSize.Text = dsMain.Tables["ProductionMaster"].Rows[0]["ModelSize"].ToString();
            txtRemarks.Text = dsMain.Tables["ProductionMaster"].Rows[0]["Remarks"].ToString();
            cmbStatus.SelectedValue = dsMain.Tables["ProductionMaster"].Rows[0]["StatusId"].ToString();
            cmbFinalWarehouse.SelectedValue = dsMain.Tables["ProductionMaster"].Rows[0]["TransferWarehouseId"].ToString();

            txtS39.Text = dsMain.Tables["ProductionMaster"].Rows[0]["S39"].ToString();
            txtS40.Text = dsMain.Tables["ProductionMaster"].Rows[0]["S40"].ToString();
            txtS41.Text = dsMain.Tables["ProductionMaster"].Rows[0]["S41"].ToString();
            txtS42.Text = dsMain.Tables["ProductionMaster"].Rows[0]["S42"].ToString();
            txtS43.Text = dsMain.Tables["ProductionMaster"].Rows[0]["S43"].ToString();
            txtS44.Text = dsMain.Tables["ProductionMaster"].Rows[0]["S44"].ToString();
            txtS45.Text = dsMain.Tables["ProductionMaster"].Rows[0]["S45"].ToString();
            txtS46.Text = dsMain.Tables["ProductionMaster"].Rows[0]["S46"].ToString();
            txtS47.Text = dsMain.Tables["ProductionMaster"].Rows[0]["S47"].ToString();

            txtA39.Text = dsMain.Tables["ProductionMaster"].Rows[0]["A39"].ToString();
            txtA40.Text = dsMain.Tables["ProductionMaster"].Rows[0]["A40"].ToString();
            txtA41.Text = dsMain.Tables["ProductionMaster"].Rows[0]["A41"].ToString();
            txtA42.Text = dsMain.Tables["ProductionMaster"].Rows[0]["A42"].ToString();
            txtA43.Text = dsMain.Tables["ProductionMaster"].Rows[0]["A43"].ToString();
            txtA44.Text = dsMain.Tables["ProductionMaster"].Rows[0]["A44"].ToString();
            txtA45.Text = dsMain.Tables["ProductionMaster"].Rows[0]["A45"].ToString();
            txtA46.Text = dsMain.Tables["ProductionMaster"].Rows[0]["A46"].ToString();
            txtA47.Text = dsMain.Tables["ProductionMaster"].Rows[0]["A47"].ToString();


            txtActaulQty.Text = dsMain.Tables["ProductionMaster"].Rows[0]["ActualQty"].ToString();
            cmbToWarehouse.SelectedValue = Convert.ToInt32(dsMain.Tables["ProductionMaster"].Rows[0]["ToWarehouseId"]);
            dtpProcess.Value = Convert.ToDateTime(dsMain.Tables["ProductionMaster"].Rows[0]["ProcessDate"]);
            chkIsComplete.Checked = Convert.ToBoolean(dsMain.Tables["ProductionMaster"].Rows[0]["IsCompleteStage"]);
            //

            //txtProcessQty.ReadOnly = true;
            cmbFormula.Enabled = false;
            txtBatchNo.Enabled = false;
            IsProductionLoad = false;
            cmbFormula_SelectedIndexChanged(null, null);
            ButtonRights(false);
            btnUnPost.Enabled = false;
            if (Convert.ToBoolean(dsMain.Tables["ProductionMaster"].Rows[0]["Posted"]))
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnPost.Enabled = false;
                btnDelete.Enabled = false;
                cmbWarehouse.Enabled = false;
                cmbFinalWarehouse.Enabled = false;
                txtProcessQty.ReadOnly = true;
                lblPosted.Visible = true;
                btnUnPost.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnPost.Enabled = true;
                btnDelete.Enabled = true;
                cmbWarehouse.Enabled = true;
                cmbFinalWarehouse.Enabled = true;
                lblPosted.Visible = false;
                txtProcessQty.ReadOnly = false;
                ButtonRights(false);
                btnUnPost.Enabled = false;
            }




            //for Navigation Works*******
            try
            {
                string FirstTransNo = manageProduction.GetMinInvioceNo();
                string LastTransNo = manageProduction.GetMaxInvioceNo();
                if (LastTransNo == txtCode.Text)
                {
                    btnNextInvioceNo.Enabled = false;
                }
                else
                {
                    btnNextInvioceNo.Enabled = true;
                }
                if (FirstTransNo == txtCode.Text)
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

        }


        private void InsertFinishArticleOnProductLedger(string TransNo, int TranDetailId, Smartworks.DAL cdataAcess)
        {
            int ProductId = 0;
            ProductId = manageProduct.GetProductIdByCode(txtPCode.Text);

            //for Size 39
            if ((string.IsNullOrEmpty(txtA39.Text) ? 0 : Convert.ToInt32(txtA39.Text)) > 0)
            {
                manageProduct.InsertProductLedger(ProductId, dtpProcess.Value, TransNo, TranDetailId, "I", (string.IsNullOrEmpty(txtA39.Text) ? 0 : Convert.ToInt32(txtA39.Text)), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now, "", "", null, "Stage Complete from Production Size 39",
                    Convert.ToInt32(cmbFinalWarehouse.SelectedValue), manageProduct.GetProductSizeIdByString("39"), "A", cdataAcess);
            }

            //for Size 40
            if ((string.IsNullOrEmpty(txtA40.Text) ? 0 : Convert.ToInt32(txtA40.Text)) > 0)
            {
                manageProduct.InsertProductLedger(ProductId, dtpProcess.Value, TransNo, TranDetailId, "I", (string.IsNullOrEmpty(txtA40.Text) ? 0 : Convert.ToInt32(txtA40.Text)), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now, "", "", null, "Stage Complete from Production Size 40",
                    Convert.ToInt32(cmbFinalWarehouse.SelectedValue), manageProduct.GetProductSizeIdByString("40"), "A", cdataAcess);
            }

            //for Size 41
            if ((string.IsNullOrEmpty(txtA41.Text) ? 0 : Convert.ToInt32(txtA41.Text)) > 0)
            {
                manageProduct.InsertProductLedger(ProductId, dtpProcess.Value, TransNo, TranDetailId, "I", (string.IsNullOrEmpty(txtA41.Text) ? 0 : Convert.ToInt32(txtA41.Text)), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now, "", "", null, "Stage Complete from Production Size 41",
                    Convert.ToInt32(cmbFinalWarehouse.SelectedValue), manageProduct.GetProductSizeIdByString("41"), "A", cdataAcess);
            }

            //for Size 42
            if ((string.IsNullOrEmpty(txtA42.Text) ? 0 : Convert.ToInt32(txtA42.Text)) > 0)
            {
                manageProduct.InsertProductLedger(ProductId, dtpProcess.Value, TransNo, TranDetailId, "I", (string.IsNullOrEmpty(txtA42.Text) ? 0 : Convert.ToInt32(txtA42.Text)), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now, "", "", null, "Stage Complete from Production Size 42",
                    Convert.ToInt32(cmbFinalWarehouse.SelectedValue), manageProduct.GetProductSizeIdByString("42"), "A", cdataAcess);
            }

            //for Size 43
            if ((string.IsNullOrEmpty(txtA43.Text) ? 0 : Convert.ToInt32(txtA43.Text)) > 0)
            {
                manageProduct.InsertProductLedger(ProductId, dtpProcess.Value, TransNo, TranDetailId, "I", (string.IsNullOrEmpty(txtA43.Text) ? 0 : Convert.ToInt32(txtA43.Text)), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now, "", "", null, "Stage Complete from Production Size 43",
                    Convert.ToInt32(cmbFinalWarehouse.SelectedValue), manageProduct.GetProductSizeIdByString("43"), "A", cdataAcess);
            }


            //for Size 44
            if ((string.IsNullOrEmpty(txtA44.Text) ? 0 : Convert.ToInt32(txtA44.Text)) > 0)
            {
                manageProduct.InsertProductLedger(ProductId, dtpProcess.Value, TransNo, TranDetailId, "I", (string.IsNullOrEmpty(txtA44.Text) ? 0 : Convert.ToInt32(txtA44.Text)), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now, "", "", null, "Stage Complete from Production Size 44",
                    Convert.ToInt32(cmbFinalWarehouse.SelectedValue), manageProduct.GetProductSizeIdByString("44"), "A", cdataAcess);
            }

            //for Size 45
            if ((string.IsNullOrEmpty(txtA45.Text) ? 0 : Convert.ToInt32(txtA45.Text)) > 0)
            {
                manageProduct.InsertProductLedger(ProductId, dtpProcess.Value, TransNo, TranDetailId, "I", (string.IsNullOrEmpty(txtA45.Text) ? 0 : Convert.ToInt32(txtA45.Text)), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now, "", "", null, "Stage Complete from Production Size 45",
                    Convert.ToInt32(cmbFinalWarehouse.SelectedValue), manageProduct.GetProductSizeIdByString("45"), "A", cdataAcess);
            }

            //for Size 46
            if ((string.IsNullOrEmpty(txtA46.Text) ? 0 : Convert.ToInt32(txtA46.Text)) > 0)
            {
                manageProduct.InsertProductLedger(ProductId, dtpProcess.Value, TransNo, TranDetailId, "I", (string.IsNullOrEmpty(txtA46.Text) ? 0 : Convert.ToInt32(txtA46.Text)), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now, "", "", null, "Stage Complete from Production Size 46",
                    Convert.ToInt32(cmbFinalWarehouse.SelectedValue), manageProduct.GetProductSizeIdByString("46"), "A", cdataAcess);
            }

            //for Size 47
            if ((string.IsNullOrEmpty(txtA47.Text) ? 0 : Convert.ToInt32(txtA47.Text)) > 0)
            {
                manageProduct.InsertProductLedger(ProductId, dtpProcess.Value, TransNo, TranDetailId, "I", (string.IsNullOrEmpty(txtA47.Text) ? 0 : Convert.ToInt32(txtA47.Text)), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now, "", "", null, "Stage Complete from Production Size 47",
                    Convert.ToInt32(cmbFinalWarehouse.SelectedValue), manageProduct.GetProductSizeIdByString("47"), "A", cdataAcess);
            }


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
        private void Custom_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                GridView gridViewWelds = sender as GridView;
                //GridView gridViewTests = gridViewWelds.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
                DataRow dr = gridViewWelds.GetFocusedDataRow();
                switch (e.Column.Name.ToString())
                {
                    //             gridViewTests.Columns.ColumnByName("colProductId").VisibleIndex = 1;
                    //gridViewTests.Columns.ColumnByName("colActualProductId").VisibleIndex = 2;
                    //gridViewTests.Columns.ColumnByName("colColorId").VisibleIndex = 3;
                    //gridViewTests.Columns.ColumnByName("colUnitId").VisibleIndex = 4;
                    //gridViewTests.Columns.ColumnByName("colAssumeQty").VisibleIndex = 5;
                    //gridViewTests.Columns.ColumnByName("colAvailableQty").VisibleIndex = 6;
                    //gridViewTests.Columns.ColumnByName("colConsumeQty").VisibleIndex = 7;
                    //gridViewTests.Columns.ColumnByName("colBalanceQty").VisibleIndex = 8;
                    //gridViewTests.Columns.ColumnByName("colRemarks").VisibleIndex = 9;

                    //drDetail["UnitId"] = drConfig["UnitId"];
                    //drDetail["AssumeQty"] = drConfig["Qty"];
                    //drDetail["AvailableQty"] = drConfig["AvailableQty"];
                    //drDetail["ConsumeQty"] = 0;
                    //drDetail["BalanceQty"] = (Convert.ToDecimal(drDetail["AvailableQty"]) - Convert.ToDecimal(drDetail["ConsumeQty"])).ToString();
                    //drDetail["Rate"] = 0;
                    //drDetail["Amount"] = Convert.ToDecimal(drDetail["ConsumeQty"]) * Convert.ToDecimal(drDetail["Rate"]);
                    //dsGrid.Tables["ProductionDetail"].Rows.Add(drDetail);

                    //Black Pl-03-08

                    case "colActualProductId":
                        {
                            dr["AvailableQty"] = manageProduct.GetActualProductAvailableQtyForProduction(Convert.ToInt32(dr["ActualProductId"]), dtp.Value, Convert.ToInt32(dr["WarehouseId"]), txtSOrderNo.Text, manageProduct.GetProductIdByCode(txtPCode.Text), ((txtBatchNo.SelectedIndex > 0) ? txtBatchNo.SelectedValue.ToString() : ""));
                            dr["BalanceQty"] = (string.IsNullOrEmpty(dr["AvailableQty"].ToString()) ? 0 : Convert.ToDecimal(dr["AvailableQty"])) - (string.IsNullOrEmpty(dr["ConsumeQty"].ToString()) ? 0 : Convert.ToDecimal(dr["ConsumeQty"].ToString()));
                            break;
                        }
                    case "colConsumeQty":
                        {
                            dr["BalanceQty"] = (string.IsNullOrEmpty(dr["AvailableQty"].ToString()) ? 0 : Convert.ToDecimal(dr["AvailableQty"])) - Convert.ToDecimal(dr["ConsumeQty"].ToString());
                            break;
                        }
                    case "colRate":
                        {
                            dr["Amount"] = Convert.ToDecimal(dr["ConsumeQty"]) * Convert.ToDecimal(dr["Rate"]);
                            break;
                        }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Custom_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    int DetailId = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, View.Columns["PDId"])); //View.GetRowCellDisplayText(e.RowHandle, View.Columns["PMDId"]);
                    if (DetailId > 0)
                    {
                        e.Appearance.BackColor = Color.FromArgb(150, Color.LightGreen); //Color.LightCoral
                        e.Appearance.BackColor2 = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
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
                int ProductId = -1;
                ProductId = manageProduct.GetProductIdByCode(txtPCode.Text);
                if (ProductId <= 0)
                {
                    MessageBox.Show("Article not Found. Please Select Article Name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnPSearch.Focus();
                    return;
                }
                if (!ValidateProcessData())
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
                    DataTable dtProduction = new DataTable();

                    dtProduction = manageProduction.InsertProductionMaster(dtp.Value, ProductId, (string.IsNullOrEmpty(txtProcessQty.Text) ? 0 : Convert.ToDecimal(txtProcessQty.Text)), txtConstruction.Text, ((txtBatchNo.SelectedIndex > 0) ? txtBatchNo.Text : ""),
                        Convert.ToInt32(cmbLastNo.SelectedValue), txtSizeRange.Text, txtModelSize.Text, Convert.ToInt32(cmbFormula.SelectedValue),
                        Convert.ToInt32(cmbStatus.SelectedValue), Convert.ToInt32(cmbWarehouse.SelectedValue), txtSOrderNo.Text, txtRemarks.Text, false,
                        Convert.ToInt32(cmbFinalWarehouse.SelectedValue),
                        (string.IsNullOrEmpty(txtS39.Text) ? 0 : Convert.ToInt32(txtS39.Text)), (string.IsNullOrEmpty(txtS40.Text) ? 0 : Convert.ToInt32(txtS40.Text)),
                        (string.IsNullOrEmpty(txtS41.Text) ? 0 : Convert.ToInt32(txtS41.Text)), (string.IsNullOrEmpty(txtS42.Text) ? 0 : Convert.ToInt32(txtS42.Text)),
                        (string.IsNullOrEmpty(txtS43.Text) ? 0 : Convert.ToInt32(txtS43.Text)), (string.IsNullOrEmpty(txtS44.Text) ? 0 : Convert.ToInt32(txtS44.Text)),
                        (string.IsNullOrEmpty(txtS45.Text) ? 0 : Convert.ToInt32(txtS45.Text)), (string.IsNullOrEmpty(txtS46.Text) ? 0 : Convert.ToInt32(txtS46.Text)),
                        (string.IsNullOrEmpty(txtS47.Text) ? 0 : Convert.ToInt32(txtS47.Text)),
                        (string.IsNullOrEmpty(txtA39.Text) ? 0 : Convert.ToInt32(txtA39.Text)), (string.IsNullOrEmpty(txtA40.Text) ? 0 : Convert.ToInt32(txtA40.Text)),
                        (string.IsNullOrEmpty(txtA41.Text) ? 0 : Convert.ToInt32(txtA41.Text)), (string.IsNullOrEmpty(txtA42.Text) ? 0 : Convert.ToInt32(txtA42.Text)),
                        (string.IsNullOrEmpty(txtA43.Text) ? 0 : Convert.ToInt32(txtA43.Text)), (string.IsNullOrEmpty(txtA44.Text) ? 0 : Convert.ToInt32(txtA44.Text)),
                        (string.IsNullOrEmpty(txtA45.Text) ? 0 : Convert.ToInt32(txtA45.Text)), (string.IsNullOrEmpty(txtA46.Text) ? 0 : Convert.ToInt32(txtA46.Text)),
                        (string.IsNullOrEmpty(txtA47.Text) ? 0 : Convert.ToInt32(txtA47.Text)),
                        MainForm.User_Id, DateTime.Now, "",
                        Convert.ToInt32(cmbToWarehouse.SelectedValue), (string.IsNullOrEmpty(txtActaulQty.Text) ? 0 : Convert.ToInt32(txtActaulQty.Text)), dtpProcess.Value,
                        chkIsComplete.Checked, dataAcess);
                    if (dtProduction.Rows.Count > 0)
                    {
                        ProductionId = Convert.ToInt32(dtProduction.Rows[0]["Id"]);
                    }
                    else
                    {
                        MessageBox.Show("Error While Save Production Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw new Exception("ProductionId does not found.");
                    }
                    if (ProductionId > 0)
                    {
                        //Detail Works
                        foreach (DataRow drDetail in dsGrid.Tables["ProductionDetail"].Rows)
                        {
                            if (drDetail.RowState != DataRowState.Deleted)
                            {
                                int DetailId = manageProduction.InsertUpdateProductionDetail(Convert.ToInt32(drDetail["PDId"]),
                                                                              ProductionId,
                                                                              (string.IsNullOrEmpty(drDetail["ProductId"].ToString()) ? -1 : Convert.ToInt32(drDetail["ProductId"])),
                                                                              (string.IsNullOrEmpty(drDetail["ActualProductId"].ToString()) ? -1 : Convert.ToInt32(drDetail["ActualProductId"])),
                                                                              Convert.ToInt32(drDetail["WarehouseId"]),
                                                                              Convert.ToInt32(drDetail["UnitId"]),
                                                                              (string.IsNullOrEmpty(drDetail["ColorId"].ToString()) ? -1 : Convert.ToInt32(drDetail["ColorId"])),
                                                                              (string.IsNullOrEmpty(drDetail["AssumeQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["AssumeQty"])),
                                                                              (string.IsNullOrEmpty(drDetail["AvailableQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["AvailableQty"])),
                                                                              (string.IsNullOrEmpty(drDetail["ConsumeQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ConsumeQty"])),
                                                                              (string.IsNullOrEmpty(drDetail["BalanceQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["BalanceQty"])),
                                                                              (string.IsNullOrEmpty(drDetail["Rate"].ToString()) ? 0 : Convert.ToDecimal(drDetail["Rate"])),
                                                                              (string.IsNullOrEmpty(drDetail["Amount"].ToString()) ? 0 : Convert.ToDecimal(drDetail["Amount"])),
                                                                              drDetail["Remarks"].ToString(),
                                                                              dataAcess);

                                if ((string.IsNullOrEmpty(drDetail["ConsumeQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ConsumeQty"])) > 0)
                                {

                                    //hum hand to hand Product ledger mai Update / Insert bhi kry gy.
                                    manageProduct.InsertUpdateProductLedgerByFlagIO((string.IsNullOrEmpty(drDetail["ActualProductId"].ToString()) ? -1 : Convert.ToInt32(drDetail["ActualProductId"]))
                                        , dtpProcess.Value, dtProduction.Rows[0]["Code"].ToString(), DetailId, "O", (string.IsNullOrEmpty(drDetail["ConsumeQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ConsumeQty"])), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "",
                                 null, "Inventory Out from Production Form", Convert.ToInt32(cmbWarehouse.SelectedValue), -1, dataAcess);

                                    if (!chkIsComplete.Checked)
                                    {
                                        //hum hand to hand Product ledger mai Update / Insert bhi kry gy.
                                        manageProduct.InsertUpdateProductLedgerByFlagIO((string.IsNullOrEmpty(drDetail["ActualProductId"].ToString()) ? -1 : Convert.ToInt32(drDetail["ActualProductId"]))
                                            , dtpProcess.Value, dtProduction.Rows[0]["Code"].ToString(), DetailId, "I", (string.IsNullOrEmpty(drDetail["ConsumeQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ConsumeQty"])), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "",
                                     null, "Inventory Inn from Production Form", Convert.ToInt32(cmbToWarehouse.SelectedValue), -1, dataAcess);

                                    }
                                    else
                                    {
                                        //yani chk Complete per Checked laga hua hai , iska matlb Pair Complete ho ker Finish Depart mai rakhy hai ,packing list auto set hojye gi.
                                    }
                                }
                            }
                        }

                        //Processing Work Flow 
                        if ((string.IsNullOrEmpty(txtActaulQty.Text) ? 0 : Convert.ToInt32(txtActaulQty.Text)) > 0)
                        {
                            foreach (DataRow drSubDetail in dsSubGrid.Tables["ProductionSubDetail"].Rows)
                            {
                                // Convert.ToInt32(drSubDetail["SubDetailId"])
                                int SubDetailId = manageProduction.InsertUpdateProductionSubDetail(Convert.ToInt32(drSubDetail["SubDetailId"]), ProductionId, Convert.ToInt32(drSubDetail["SOrderId"]),
                                   Convert.ToInt32(drSubDetail["ProductId"]), Convert.ToInt32(drSubDetail["WarehouseId"]),
                                   Convert.ToDateTime(drSubDetail["ReceivedDate"]), Convert.ToDecimal(drSubDetail["ProcessQty"]),
                                   Convert.ToInt32(drSubDetail["TransferWarehouseId"]), Convert.ToDateTime(drSubDetail["TransferDate"]),
                                   -1, "");
                                //manageProcessing.InsertUpdateProductionLedger(Convert.ToInt32(drSubDetail["WarehouseId"]), Convert.ToInt32(drSubDetail["ProductId"]),-1 ,drSubDetail["SOrderNo"].ToString()

                                //pehele yeh From Depart se Out hoga  Process Qty
                                manageProcessing.InsertUpdateProductionLedger(Convert.ToInt32(drSubDetail["WarehouseId"]), Convert.ToInt32(drSubDetail["ProductId"]), -1,
                                  drSubDetail["SOrderNo"].ToString(), Convert.ToDateTime(drSubDetail["ReceivedDate"]), dtProduction.Rows[0]["Code"].ToString(), SubDetailId, "O",
                                Convert.ToInt32(drSubDetail["ProcessQty"]), -1, "", false, dataAcess);

                                //then jis Dart ko Transfer kara ha usko In kry ga. Process Qty
                                manageProcessing.InsertUpdateProductionLedger(Convert.ToInt32(drSubDetail["TransferWarehouseId"]), Convert.ToInt32(drSubDetail["ProductId"]), -1,
                                  drSubDetail["SOrderNo"].ToString(), Convert.ToDateTime(drSubDetail["ReceivedDate"]), dtProduction.Rows[0]["Code"].ToString(), SubDetailId, "I",
                                Convert.ToInt32(drSubDetail["ProcessQty"]), -1, "", false, dataAcess);
                                //manageProcessing.InsertUpdateProductionLedger(Convert.ToInt32(cmbToWarehouse.SelectedValue), ProductId, -1, txtSOrderNo.Text, dtpProcess.Value, dtProduction.Rows[0]["Code"].ToString(),
                                //    ProductionId, "I", Convert.ToInt32(txtActaulQty.Text), -1, "", false, dataAcess);
                            }

                        }

                        if (chkIsComplete.Checked)
                        {
                            //agr Stage Complete hogya toh Final Depart mai Finish Goods ki Entry Challi jye gi then wahan se Packing List bane gi.
                            InsertFinishArticleOnProductLedger(dtProduction.Rows[0]["Code"].ToString(), ProductionId, dataAcess);
                            //
                        }

                    }
                    dataAcess.TransCommit();
                    MessageBox.Show("Production Process Insert Sucessfully.", "Record Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //ClearFeilds();
                    txtFormulaId_TextChanged(null, null);

                }
                catch (SqlException sqlex)
                {
                    dataAcess.TransCommit();
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
                if (!ValidateProcessData())
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

                    //hum pehele ProductLedger se Finish Article Remove kry gy.
                    manageProduct.DeleteFinishFromProductLedgerByTransNo(txtCode.Text, dataAcess);

                    //kuch delete nh kary gy Salman , warna sara ledger out hojye ga, is k liye InsertUpdateByFlagIO wala method create kar hai.
                    //manageProduct.DeleteProductLedgerByTransNo(txtCode.Text, true, dataAcess);

                    //manageProduct.DeleteFormulaDetailByMasterId(FormulaId, dataAcess);
                    manageProduction.UpdateProductionMaster(ProductionId, dtp.Value, ProductId, (string.IsNullOrEmpty(txtProcessQty.Text) ? 0 : Convert.ToDecimal(txtProcessQty.Text)),
                        txtConstruction.Text, ((txtBatchNo.SelectedIndex > 0) ? txtBatchNo.Text : ""), Convert.ToInt32(cmbLastNo.SelectedValue), txtSizeRange.Text,
                        txtModelSize.Text, Convert.ToInt32(cmbFormula.SelectedValue), Convert.ToInt32(cmbStatus.SelectedValue),
                        Convert.ToInt32(cmbWarehouse.SelectedValue), txtSOrderNo.Text, txtRemarks.Text, false, Convert.ToInt32(cmbFinalWarehouse.SelectedValue),
                         (string.IsNullOrEmpty(txtS39.Text) ? 0 : Convert.ToInt32(txtS39.Text)), (string.IsNullOrEmpty(txtS40.Text) ? 0 : Convert.ToInt32(txtS40.Text)),
                        (string.IsNullOrEmpty(txtS41.Text) ? 0 : Convert.ToInt32(txtS41.Text)), (string.IsNullOrEmpty(txtS42.Text) ? 0 : Convert.ToInt32(txtS42.Text)),
                        (string.IsNullOrEmpty(txtS43.Text) ? 0 : Convert.ToInt32(txtS43.Text)), (string.IsNullOrEmpty(txtS44.Text) ? 0 : Convert.ToInt32(txtS44.Text)),
                        (string.IsNullOrEmpty(txtS45.Text) ? 0 : Convert.ToInt32(txtS45.Text)), (string.IsNullOrEmpty(txtS46.Text) ? 0 : Convert.ToInt32(txtS46.Text)),
                        (string.IsNullOrEmpty(txtS47.Text) ? 0 : Convert.ToInt32(txtS47.Text)),
                        (string.IsNullOrEmpty(txtA39.Text) ? 0 : Convert.ToInt32(txtA39.Text)), (string.IsNullOrEmpty(txtA40.Text) ? 0 : Convert.ToInt32(txtA40.Text)),
                        (string.IsNullOrEmpty(txtA41.Text) ? 0 : Convert.ToInt32(txtA41.Text)), (string.IsNullOrEmpty(txtA42.Text) ? 0 : Convert.ToInt32(txtA42.Text)),
                        (string.IsNullOrEmpty(txtA43.Text) ? 0 : Convert.ToInt32(txtA43.Text)), (string.IsNullOrEmpty(txtA44.Text) ? 0 : Convert.ToInt32(txtA44.Text)),
                        (string.IsNullOrEmpty(txtA45.Text) ? 0 : Convert.ToInt32(txtA45.Text)), (string.IsNullOrEmpty(txtA46.Text) ? 0 : Convert.ToInt32(txtA46.Text)),
                        (string.IsNullOrEmpty(txtA47.Text) ? 0 : Convert.ToInt32(txtA47.Text)),
                        MainForm.User_Id, DateTime.Now, "",
                        Convert.ToInt32(cmbToWarehouse.SelectedValue), (string.IsNullOrEmpty(txtActaulQty.Text) ? 0 : Convert.ToInt32(txtActaulQty.Text)), dtpProcess.Value, chkIsComplete.Checked, dataAcess);
                    //Detail Works
                    foreach (DataRow drDetail in dsGrid.Tables["ProductionDetail"].Rows)
                    {
                        if (drDetail.RowState != DataRowState.Deleted)
                        {
                            int DetailId = manageProduction.InsertUpdateProductionDetail(Convert.ToInt32(drDetail["PDId"]),
                                                                          ProductionId,
                                                                          (string.IsNullOrEmpty(drDetail["ProductId"].ToString()) ? -1 : Convert.ToInt32(drDetail["ProductId"])),
                                                                          (string.IsNullOrEmpty(drDetail["ActualProductId"].ToString()) ? -1 : Convert.ToInt32(drDetail["ActualProductId"])),
                                                                          Convert.ToInt32(drDetail["WarehouseId"]),
                                                                          Convert.ToInt32(drDetail["UnitId"]),
                                                                          (string.IsNullOrEmpty(drDetail["ColorId"].ToString()) ? -1 : Convert.ToInt32(drDetail["ColorId"])),
                                                                          (string.IsNullOrEmpty(drDetail["AssumeQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["AssumeQty"])),
                                                                          (string.IsNullOrEmpty(drDetail["AvailableQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["AvailableQty"])),
                                                                          (string.IsNullOrEmpty(drDetail["ConsumeQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ConsumeQty"])),
                                                                          (string.IsNullOrEmpty(drDetail["BalanceQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["BalanceQty"])),
                                                                          (string.IsNullOrEmpty(drDetail["Rate"].ToString()) ? 0 : Convert.ToDecimal(drDetail["Rate"])),
                                                                          (string.IsNullOrEmpty(drDetail["Amount"].ToString()) ? 0 : Convert.ToDecimal(drDetail["Amount"])),
                                                                          drDetail["Remarks"].ToString(),
                                                                          dataAcess);

                            if ((string.IsNullOrEmpty(drDetail["ConsumeQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ConsumeQty"])) > 0)
                            {

                                //hum hand to hand Product ledger mai Update / Insert bhi kry gy.
                                manageProduct.InsertUpdateProductLedgerByFlagIO((string.IsNullOrEmpty(drDetail["ActualProductId"].ToString()) ? -1 : Convert.ToInt32(drDetail["ActualProductId"]))
                                    , dtpProcess.Value, txtCode.Text.ToString(), DetailId, "O", (string.IsNullOrEmpty(drDetail["ConsumeQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ConsumeQty"])), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "",
                             null, "Inventory Out from Production Form", Convert.ToInt32(cmbWarehouse.SelectedValue), -1, dataAcess);

                                if (!chkIsComplete.Checked)
                                {
                                    //hum hand to hand Product ledger mai Update / Insert bhi kry gy.
                                    manageProduct.InsertUpdateProductLedgerByFlagIO((string.IsNullOrEmpty(drDetail["ActualProductId"].ToString()) ? -1 : Convert.ToInt32(drDetail["ActualProductId"]))
                                        , dtpProcess.Value, txtCode.Text.ToString(), DetailId, "I", (string.IsNullOrEmpty(drDetail["ConsumeQty"].ToString()) ? 0 : Convert.ToDecimal(drDetail["ConsumeQty"])), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "",
                                 null, "Inventory Inn from Production Form", Convert.ToInt32(cmbToWarehouse.SelectedValue), -1, dataAcess);

                                }
                            }
                        }
                    }



                    //Processing Work Flow 
                    if ((string.IsNullOrEmpty(txtActaulQty.Text) ? 0 : Convert.ToInt32(txtActaulQty.Text)) > 0)
                    {
                        foreach (DataRow drSubDetail in dsSubGrid.Tables["ProductionSubDetail"].Rows)
                        {
                            // Convert.ToInt32(drSubDetail["SubDetailId"])
                            int SubDetailId = manageProduction.InsertUpdateProductionSubDetail(Convert.ToInt32(drSubDetail["SubDetailId"]), ProductionId, Convert.ToInt32(drSubDetail["SOrderId"]),
                               Convert.ToInt32(drSubDetail["ProductId"]), Convert.ToInt32(drSubDetail["WarehouseId"]),
                               Convert.ToDateTime(drSubDetail["ReceivedDate"]), Convert.ToDecimal(drSubDetail["ProcessQty"]),
                               Convert.ToInt32(drSubDetail["TransferWarehouseId"]), Convert.ToDateTime(drSubDetail["TransferDate"]),
                               -1, "");
                            //manageProcessing.InsertUpdateProductionLedger(Convert.ToInt32(drSubDetail["WarehouseId"]), Convert.ToInt32(drSubDetail["ProductId"]),-1 ,drSubDetail["SOrderNo"].ToString()

                            //pehele yeh From Depart se Out hoga  Process Qty
                            manageProcessing.InsertUpdateProductionLedger(Convert.ToInt32(drSubDetail["WarehouseId"]), Convert.ToInt32(drSubDetail["ProductId"]), -1,
                              drSubDetail["SOrderNo"].ToString(), Convert.ToDateTime(drSubDetail["ReceivedDate"]), txtCode.Text.ToString(), SubDetailId, "O",
                            Convert.ToInt32(drSubDetail["ProcessQty"]), -1, "", false, dataAcess);

                            //then jis Dart ko Transfer kara ha usko In kry ga. Process Qty
                            manageProcessing.InsertUpdateProductionLedger(Convert.ToInt32(drSubDetail["TransferWarehouseId"]), Convert.ToInt32(drSubDetail["ProductId"]), -1,
                              drSubDetail["SOrderNo"].ToString(), Convert.ToDateTime(drSubDetail["ReceivedDate"]), txtCode.Text.ToString(), SubDetailId, "I",
                            Convert.ToInt32(drSubDetail["ProcessQty"]), -1, "", false, dataAcess);
                            //manageProcessing.InsertUpdateProductionLedger(Convert.ToInt32(cmbToWarehouse.SelectedValue), ProductId, -1, txtSOrderNo.Text, dtpProcess.Value, dtProduction.Rows[0]["Code"].ToString(),
                            //    ProductionId, "I", Convert.ToInt32(txtActaulQty.Text), -1, "", false, dataAcess);
                        }
                    }

                    //agr Stage Complete hogya toh Final Depart mai Finish Goods ki Entry Challi jye gi then wahan se Packing List bane gi.
                    if (chkIsComplete.Checked)
                    {
                        InsertFinishArticleOnProductLedger(txtCode.Text, ProductionId, dataAcess);
                    }

                    dataAcess.TransCommit();
                    MessageBox.Show("Production Process Update Sucessfully.", "Record Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //ClearFeilds();
                    txtFormulaId_TextChanged(null, null);
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
                search.getattributes("GetProductionSearch", null, "Production Process");
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
                ProductionId = manageProduction.GetProductionIdByCode(txtCode.Text);
                if (ProductionId > 0)
                {
                    LoadProduction();
                }
            }
            else
            {
                ClearFeilds();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //agr delete per kaam kerna hoto yeh yaad rakhna salman k Product ledger mai Add/ Update per entry hand to hand ho rhi hai .
            //or Post k upper Final Finish Article Inn ho rhy hai , agr koi Invoice UnPost ker k Delete ki gyi toh dimaag mai yeh point yaad rakhna.

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
                if (string.IsNullOrEmpty(txtCode.Text))
                {
                    return;
                }

                if (ProductionId <= 0)
                {
                    MessageBox.Show("Record Not Found", "Production Record does not found.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string path = Application.StartupPath + "/rpt/Production/rptProductionProcessWithAmount.rpt";
                ReportDocument document = new ReportDocument();
                document.Load(path);
                DataTable dtReport = new DataTable();
                dtReport = manageProduction.GetProductionReportBySOandFinishProductId(txtSOrderNo.Text, manageProduct.GetProductIdByCode(txtPCode.Text) , txtCode.Text );
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
                if (string.IsNullOrEmpty(txtSOrderNo.Text))
                {
                    MessageBox.Show("Please Select Sale Order Number.", "Sale Order is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                frmSearch search = new frmSearch();
                Smartworks.ColumnField[] gSalesOrderProduct = new Smartworks.ColumnField[1];
                gSalesOrderProduct[0] = new Smartworks.ColumnField("@SaleOrderNo", txtSOrderNo.Text);
                search.getattributes("GetProductSearchForSalesOrder", gSalesOrderProduct, "Products");
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

                        DataTable dtFormula = new DataTable();
                        dtFormula = manageProduct.GetProductFormulaByFinishProductId(Convert.ToInt32(dtProduct.Rows[0]["ProductId"]));
                        DataRow drFormula = dtFormula.NewRow();
                        drFormula["FormulaMasterId"] = -1;
                        drFormula["FormulaName"] = "--Select Receipy--";
                        dtFormula.Rows.InsertAt(drFormula, 0);

                        cmbFormula.DataSource = dtFormula;
                        cmbFormula.DisplayMember = "FormulaName";
                        cmbFormula.ValueMember = "FormulaMasterId";

                        DataTable dtOrderQty = new DataTable();
                        dtOrderQty = manageSalesOrder.GetOrderQtyBySOAndDetailProductId(manageSalesOrder.GetSalesOrderMasterIdByCode(txtSOrderNo.Text)
                            , Convert.ToInt32(dtProduct.Rows[0]["ProductId"]), ProductionId);
                        if (dtOrderQty.Rows.Count > 0)
                        {
                            txtOrderQty.Text = dtOrderQty.Rows[0]["OrderQty"].ToString();
                            txtDoneQty.Text = dtOrderQty.Rows[0]["ProcessQty"].ToString();
                        }

                        DataTable dtBatch = manageWarehouse.GetAllBatchBySONoAndProductId(txtSOrderNo.Text, Convert.ToInt32(dtProduct.Rows[0]["ProductId"]));
                        DataRow drBatch = dtBatch.NewRow();
                        drBatch["BatchNo"] = "-1";
                        drBatch["BatchNo"] = "--Select BatchNo--";
                        dtBatch.Rows.InsertAt(drBatch, 0);

                        txtBatchNo.DataSource = dtBatch;
                        txtBatchNo.DisplayMember = "BatchNo";
                        txtBatchNo.ValueMember = "BatchNo";

                    }
                }
                else
                {
                    txtPName.Text = string.Empty;
                    pbitem.Image = FIL.Properties.Resources.User;
                    cmbFormula.DataSource = null;
                    txtBatchNo.DataSource = null;
                    txtOrderQty.Text = "0";
                    txtProcessQty.Text = "";
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

                //yeh temprary comment ker raha hu Salman, q k mjy runtime per receipy se kuch alag cheezain add kerni hai production Detail mai.
                //if (dsGrid.Tables["FormulaDetail"].Select("WarehouseId = '" + WarehouseId + "'").Length <= 0)
                //{
                //    DataRow drNew = dsGrid.Tables["FormulaDetail"].NewRow();
                //    drNew["WarehouseId"] = WarehouseId;
                //    drNew["Qty"] = 0;
                //    dsGrid.Tables["FormulaDetail"].Rows.Add(drNew);
                //    e.Allow = true;
                //}

                e.Allow = true;

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

        private void btnSOSearch_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearch search = new frmSearch();
                search.getattributes("GetSearchSalesOrdersProduction", null, "Sale Orders");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtSOrderNo.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;


                }
                //else
                //{
                //    txtSOrderNo.Text = string.Empty;
                //    txtSOrderNo.Focus();
                //}
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

        private void txtProcessQty_KeyDown(object sender, KeyEventArgs e)
        {

            //clsUtlity.setOnlyNumberic((TextBox)sender, false, e);
        }



        private void txtProcessQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility clsUtlity = new Utility();
            clsUtlity.setOnlyNumberic((TextBox)sender, false, e);
        }

        private void txtProcessQty_TextChanged(object sender, EventArgs e)
        {
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
            txtActaulQty.Text = txtProcessQty.Text;
            cmbFormula_SelectedIndexChanged(null, null);
        }

        #region Navigation


        private void btnMinInvioceNo_Click(object sender, EventArgs e)
        {
            txtCode.Text = manageProduction.GetMinInvioceNo();
            if (!string.IsNullOrEmpty(txtCode.Text))
            {
                //btnNextInvioceNo.Enabled = true;
                //btnPrevInvioceNo.Enabled = false;
            }
        }

        private void btnMaxInvioceNo_Click(object sender, EventArgs e)
        {
            txtCode.Text = manageProduction.GetMaxInvioceNo();
            if (!string.IsNullOrEmpty(txtCode.Text))
            {

                //btnNextInvioceNo.Enabled = false;
                //btnPrevInvioceNo.Enabled = true;
            }
        }

        private void btnPrevInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCode.Text))
            {
                string LastInvioceNo = manageProduction.GetMinInvioceNo();
                txtCode.Text = manageSalesOrder.GetPrevInvioceNo(txtCode.Text);


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
                string LastInvioceNo = manageProduction.GetMaxInvioceNo();
                txtCode.Text = manageSalesOrder.GetNextInvioceNo(txtCode.Text);

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

        private void cmbFormula_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsProductionLoad)
            {
                return;
            }
            if (lblPosted.Visible)
            {
                return;
            }
            if (Convert.ToInt32(cmbFormula.SelectedIndex) > 0 && Convert.ToInt32(cmbWarehouse.SelectedIndex) > 0)
            {
                FillGrid(Convert.ToInt32(cmbFormula.SelectedValue), (string.IsNullOrEmpty(txtProcessQty.Text) ? 1 : Convert.ToDecimal(txtProcessQty.Text)), Convert.ToInt32(cmbWarehouse.SelectedValue), txtSOrderNo.Text, manageProduct.GetProductIdByCode(txtPCode.Text), dtp.Value, ((txtBatchNo.SelectedIndex > 0) ? txtBatchNo.SelectedValue.ToString() : ""));

                try
                {
                    DataTable dtFormulaMaster = manageProduct.GetProductFormulaMaster(Convert.ToInt32(cmbFormula.SelectedValue));
                    if (dtFormulaMaster.Rows.Count > 0)
                    {
                        cmbLastNo.SelectedValue = dtFormulaMaster.Rows[0]["LastNoId"].ToString();
                    }
                }
                catch (Exception pex)
                {
                }
            }
            else
            {
                GCDetail.DataSource = null;
                GCDetail.Enabled = false;
            }
        }

        private void gvDetail_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
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

        private void GCDetail_ViewRegistered(object sender, DevExpress.XtraGrid.ViewOperationEventArgs e)
        {
            if (e.View.LevelName == "WarehouseRelation")
            {
                (e.View as GridView).CellValueChanged += Custom_CellValueChanged;
                (e.View as GridView).RowStyle += Custom_RowStyle;
            }

        }

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
            cmbFormula_SelectedIndexChanged(null, null);
        }

        private void cmbToWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbToWarehouse.SelectedIndex > 0)
            {
                if (cmbWarehouse.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select From Department First.", "From Department does not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbToWarehouse.SelectedIndex = 0;
                }
            }

        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            if (ProductionId <= 0)
            {
                MessageBox.Show("Production Process Record does not found.", "Make sure Record Exists in form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtTotalQty.Text))
            {
                MessageBox.Show("Total Quantity of Size not Found.", "Enter Size of Production Articles", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(txtProcessQty.Text) && !string.IsNullOrEmpty(txtTotalQty.Text))
            {
                if (Convert.ToDecimal(txtProcessQty.Text) != Convert.ToDecimal(txtTotalQty.Text))
                {
                    MessageBox.Show("Total Quantity of Size And Process Quantity should be Same.", "Different Quantity values does not accepted.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            DialogResult result = MessageBox.Show("Are you sure want to Post Production Process?", "Production Post", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        PostProduction();
                        break;
                    }

            }

        }

        private void PostProduction()
        {
            try
            {
                dataAcess.BeginTransaction();
                manageProduction.POSTProduction(ProductionId, MainForm.User_Id, DateTime.Now, "", dataAcess);
                dataAcess.TransCommit();
                MessageBox.Show("Production Post Sucessfully.", "Record Posted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }
            catch (SqlException sqlex)
            {
                dataAcess.TransRollback();
                MessageBox.Show(sqlex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataAcess.ConnectionClose();
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
            if (!string.IsNullOrEmpty(txtS44.Text))
            {
                S44 = Convert.ToInt32(txtS44.Text);
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
            if (TotalQty > (string.IsNullOrEmpty(txtProcessQty.Text) ? 0 : Convert.ToDecimal(txtProcessQty.Text)))
            {
                MessageBox.Show("Please Enter Proper Sizing of Process Qty, Total Qty should not greater then Process Quantity.", "Invalid Size Qty Total", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotalQty.Text = "0";
                txtS39.Text = "0";
                txtS40.Text = "0";
                txtS41.Text = "0";
                txtS42.Text = "0";
                txtS43.Text = "0";
                txtS44.Text = "0";
                txtS45.Text = "0";
                txtS46.Text = "0";
                txtS47.Text = "0";
                return;
            }
            txtTotalQty.Text = TotalQty.ToString();
        }
        Utility clsUtility = new Utility();
        private void txtS39_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.setOnlyNumberic((TextBox)sender, false, e);
        }

        private void btnUnPost_Click(object sender, EventArgs e)
        {
            if (ProductionId <= 0)
            {
                MessageBox.Show("Production Process Record does not found.", "Make sure Record Exists in form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult result = MessageBox.Show("Are you sure want to UN-Post Production Process?", "Production UN-Post", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        UNPostProduction();
                        break;
                    }

            }
        }

        private void UNPostProduction()
        {
            try
            {
                dataAcess.BeginTransaction();
                manageProduction.UNPOSTProduction(ProductionId, MainForm.User_Id, DateTime.Now, "", dataAcess);
                dataAcess.TransCommit();
                MessageBox.Show("Production UN-Post Sucessfully.", "Record UN-Posted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }
            catch (SqlException sqlex)
            {
                dataAcess.TransRollback();
                MessageBox.Show(sqlex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataAcess.ConnectionClose();
            }

        }

        private void txtA39_TextChanged(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(txtA39.Text) ? 0 : Convert.ToInt32(txtA39.Text)) > (string.IsNullOrEmpty(txtS39.Text) ? 0 : Convert.ToInt32(txtS39.Text)))
            {
                txtA39.Text = (string.IsNullOrEmpty(txtS39.Text) ? 0 : Convert.ToInt32(txtS39.Text)).ToString();
            }

            if ((string.IsNullOrEmpty(txtA40.Text) ? 0 : Convert.ToInt32(txtA40.Text)) > (string.IsNullOrEmpty(txtS40.Text) ? 0 : Convert.ToInt32(txtS40.Text)))
            {
                txtA40.Text = (string.IsNullOrEmpty(txtS40.Text) ? 0 : Convert.ToInt32(txtS40.Text)).ToString();
            }

            if ((string.IsNullOrEmpty(txtA41.Text) ? 0 : Convert.ToInt32(txtA41.Text)) > (string.IsNullOrEmpty(txtS41.Text) ? 0 : Convert.ToInt32(txtS41.Text)))
            {
                txtA41.Text = (string.IsNullOrEmpty(txtS41.Text) ? 0 : Convert.ToInt32(txtS41.Text)).ToString();
            }

            if ((string.IsNullOrEmpty(txtA42.Text) ? 0 : Convert.ToInt32(txtA42.Text)) > (string.IsNullOrEmpty(txtS42.Text) ? 0 : Convert.ToInt32(txtS42.Text)))
            {
                txtA42.Text = (string.IsNullOrEmpty(txtS42.Text) ? 0 : Convert.ToInt32(txtS42.Text)).ToString();
            }

            if ((string.IsNullOrEmpty(txtA43.Text) ? 0 : Convert.ToInt32(txtA43.Text)) > (string.IsNullOrEmpty(txtS43.Text) ? 0 : Convert.ToInt32(txtS43.Text)))
            {
                txtA43.Text = (string.IsNullOrEmpty(txtS43.Text) ? 0 : Convert.ToInt32(txtS43.Text)).ToString();
            }

            if ((string.IsNullOrEmpty(txtA44.Text) ? 0 : Convert.ToInt32(txtA44.Text)) > (string.IsNullOrEmpty(txtS44.Text) ? 0 : Convert.ToInt32(txtS44.Text)))
            {
                txtA44.Text = (string.IsNullOrEmpty(txtS44.Text) ? 0 : Convert.ToInt32(txtS44.Text)).ToString();
            }

            if ((string.IsNullOrEmpty(txtA45.Text) ? 0 : Convert.ToInt32(txtA45.Text)) > (string.IsNullOrEmpty(txtS45.Text) ? 0 : Convert.ToInt32(txtS45.Text)))
            {
                txtA45.Text = (string.IsNullOrEmpty(txtS45.Text) ? 0 : Convert.ToInt32(txtS45.Text)).ToString();
            }

            if ((string.IsNullOrEmpty(txtA46.Text) ? 0 : Convert.ToInt32(txtA46.Text)) > (string.IsNullOrEmpty(txtS46.Text) ? 0 : Convert.ToInt32(txtS46.Text)))
            {
                txtA46.Text = (string.IsNullOrEmpty(txtS46.Text) ? 0 : Convert.ToInt32(txtS46.Text)).ToString();
            }

            if ((string.IsNullOrEmpty(txtA47.Text) ? 0 : Convert.ToInt32(txtA47.Text)) > (string.IsNullOrEmpty(txtS47.Text) ? 0 : Convert.ToInt32(txtS47.Text)))
            {
                txtA47.Text = (string.IsNullOrEmpty(txtS47.Text) ? 0 : Convert.ToInt32(txtS47.Text)).ToString();
            }
            CalculateActualTotalQty();
        }

        private void CalculateActualTotalQty()
        {
            int TotalQty = 0;
            int A39 = 0, A40 = 0, A41 = 0, A42 = 0, A43 = 0, A44 = 0, A45 = 0, A46 = 0, A47 = 0;
            if (!string.IsNullOrEmpty(txtA39.Text))
            {
                A39 = Convert.ToInt32(txtA39.Text);
            }
            if (!string.IsNullOrEmpty(txtA40.Text))
            {
                A40 = Convert.ToInt32(txtA40.Text);
            }
            if (!string.IsNullOrEmpty(txtA41.Text))
            {
                A41 = Convert.ToInt32(txtA41.Text);
            }
            if (!string.IsNullOrEmpty(txtA42.Text))
            {
                A42 = Convert.ToInt32(txtA42.Text);
            }
            if (!string.IsNullOrEmpty(txtA43.Text))
            {
                A43 = Convert.ToInt32(txtA43.Text);
            }
            if (!string.IsNullOrEmpty(txtA44.Text))
            {
                A44 = Convert.ToInt32(txtA44.Text);
            }
            if (!string.IsNullOrEmpty(txtA45.Text))
            {
                A45 = Convert.ToInt32(txtA45.Text);
            }
            if (!string.IsNullOrEmpty(txtA46.Text))
            {
                A46 = Convert.ToInt32(txtA46.Text);
            }
            if (!string.IsNullOrEmpty(txtA47.Text))
            {
                A47 = Convert.ToInt32(txtA47.Text);
            }
            TotalQty = A39 + A40 + A41 + A42 + A43 + A44 + A45 + A46 + A47;
            txtActualTotalQty.Text = TotalQty.ToString();
        }




    }
}
