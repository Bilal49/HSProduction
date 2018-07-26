using CrystalDecisions.CrystalReports.Engine;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using FIL;
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


    public partial class frmStockAdjustment : Form
    {
        Smartworks.DAL dataAcess = new Smartworks.DAL();


        ProductManager manageProduct = new ProductManager();
        WarehouseManager manageWarehouse = new WarehouseManager();
        DataSet dset;
        RepositoryItemGridLookUpEdit repositoryGridLookup = new RepositoryItemGridLookUpEdit();
        RepositoryItemGridLookUpEdit repositoryFagIO = new RepositoryItemGridLookUpEdit();
        BindingSource bsProducts = new BindingSource();
        BindingSource bsFlagIO = new BindingSource();
        DataRow drMaster;
        DataView dvProducts;
        DataViewManager dvm;
        int StockAdjusmentId = -1;
        List<int> DeletedIds = new List<int>();

        public frmStockAdjustment()
        {
            InitializeComponent();
        }

        private void frmDirectSales_Load(object sender, EventArgs e)
        {
            ButtonRights(true);
            FillDropDown();
            setGridSetup();
        }

        #region All Methods



        private void FillDropDown()
        {
            DataTable dtFWarehouse = new DataTable();
            dtFWarehouse = manageWarehouse.GetWarehouseList();
            DataRow drFWarehouse = dtFWarehouse.NewRow();
            drFWarehouse["WarehouseId"] = -1;
            drFWarehouse["Warehouse"] = "---Select Warehouse---";
            dtFWarehouse.Rows.InsertAt(drFWarehouse, 0);
            cmbWarehouse.DataSource = dtFWarehouse;
            cmbWarehouse.DisplayMember = "Warehouse";
            cmbWarehouse.ValueMember = "WarehouseId";

        }
        private void ButtonRights(bool Enable)
        {
            btnAdd.Enabled = Enable;
            btnUpdate.Enabled = !Enable;
            btnDelete.Enabled = !Enable;
            txtAdjustNo.ReadOnly = !Enable;
           
          
        }

        private void setGridSetup()
        {
            dset = new DataSet();

            ////**** FlagIO ***
            //DataTable dtFlagIO = new DataTable();
            //dtFlagIO.TableName = "FlagIO";
            //dtFlagIO.Columns.Add(new DataColumn("FlagIO", System.Type.GetType("System.String")));
            //DataRow drInn = dtFlagIO.NewRow();
            //drInn["FlagIO"] = "I";
            //dtFlagIO.Rows.Add(drInn);

            //DataRow drOut = dtFlagIO.NewRow();
            //drOut["FlagIO"] = "O";
            //dtFlagIO.Rows.Add(drOut);


            dset = manageProduct.GetAdjustmentStructure(StockAdjusmentId);
            dset.Tables[0].TableName = "AdjustmentMaster";
            dset.Tables[1].TableName = "AdjustmentDetail";
            dset.Tables[2].TableName = "Product";
            dset.Tables[3].TableName = "Warehouse";
            dset.Tables[4].TableName = "FlagIO";
            //dset.Tables.Add(dtFlagIO);

            dset.Tables["AdjustmentMaster"].Columns["AdjustId"].AutoIncrement = true;
            dset.Tables["AdjustmentMaster"].Columns["AdjustId"].AutoIncrementSeed = -1;
            dset.Tables["AdjustmentMaster"].Columns["AdjustId"].AutoIncrementStep = -1;

            dset.Tables["AdjustmentDetail"].Columns["AdjustDetailId"].AutoIncrement = true;
            dset.Tables["AdjustmentDetail"].Columns["AdjustDetailId"].AutoIncrementSeed = -1;
            dset.Tables["AdjustmentDetail"].Columns["AdjustDetailId"].AutoIncrementStep = -1;


            dset.Relations.Add("MasterRelation", dset.Tables["AdjustmentMaster"].Columns["AdjustId"], dset.Tables["AdjustmentDetail"].Columns["AdjustId"]);

            if (dset.Tables["AdjustmentMaster"].Rows.Count > 0)
            {
                drMaster = dset.Tables["AdjustmentMaster"].Rows[0];
            }
            else
            {
                drMaster = dset.Tables["AdjustmentMaster"].NewRow();
                dset.Tables["AdjustmentMaster"].Rows.Add(drMaster);
            }

            dvm = new DataViewManager(dset);
            dvProducts = dvm.CreateDataView(dset.Tables["Product"]);

            GCDetail.DataSource = dset.Tables["AdjustmentDetail"];

            GridSetting();
        }
        private void GridSetting()
        {

            gvDetail.Columns.ColumnByName("colAdjustDetailId").OptionsColumn.ReadOnly = true;
            gvDetail.Columns.ColumnByName("colAdjustId").OptionsColumn.ReadOnly = true;

            gvDetail.Columns.ColumnByName("colAdjustDetailId").Visible = false;
            gvDetail.Columns.ColumnByName("colAdjustId").Visible = false;
            gvDetail.Columns.ColumnByName("colProductCategoryId").Visible = false;
            gvDetail.Columns.ColumnByName("colCategoryName").Visible = false;

            gvDetail.Columns.ColumnByName("colStockType").Visible = false;
            gvDetail.Columns.ColumnByName("colWarehouseId").Visible = false;


            gvDetail.Columns.ColumnByName("colProductId").Caption = "Product Name";
            gvDetail.Columns.ColumnByName("colFlagIO").Caption = "I/O";
            gvDetail.Columns.ColumnByName("colQty").Caption = "Quantity";

            gvDetail.Columns.ColumnByName("colProductId").VisibleIndex = 0;
            gvDetail.Columns.ColumnByName("colFlagIO").VisibleIndex = 1;
            gvDetail.Columns.ColumnByName("colQty").VisibleIndex = 2;

            gvDetail.Columns.ColumnByName("colProductId").Width = 300;
            gvDetail.Columns.ColumnByName("colFlagIO").Width = 50;
            gvDetail.Columns.ColumnByName("colQty").Width = 50;


            bsProducts.DataSource = dset;
            bsProducts.DataMember = "Product";

            bsFlagIO.DataSource = dset;
            bsFlagIO.DataMember = "FlagIO";

            repositoryGridLookup.DataSource = bsProducts;
            repositoryGridLookup.DisplayMember = "ProductName";
            repositoryGridLookup.ValueMember = "ProductId";
            repositoryGridLookup.PopupFormMinSize = new Size(450, 150);
            repositoryGridLookup.NullText = "";
            repositoryGridLookup.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            repositoryGridLookup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            repositoryGridLookup.ShowFooter = true;
            repositoryGridLookup.ImmediatePopup = true;
            repositoryGridLookup.View.OptionsView.ColumnAutoWidth = false;
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

            repositoryFagIO.DataSource = bsFlagIO;
            repositoryFagIO.DisplayMember = "FlagIO";
            repositoryFagIO.ValueMember = "FlagIO";
            repositoryFagIO.PopupFormMinSize = new Size(150, 150);
            repositoryFagIO.NullText = "";
            repositoryFagIO.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            repositoryFagIO.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            repositoryFagIO.ShowFooter = true;
            repositoryFagIO.ImmediatePopup = true;
            repositoryFagIO.View.OptionsView.ColumnAutoWidth = false;
            repositoryFagIO.PopulateViewColumns();
            GCDetail.RepositoryItems.Add(repositoryFagIO);

            (GCDetail.MainView as GridView).Columns.ColumnByName("colFlagIO").ColumnEdit = repositoryFagIO;

            if (repositoryFagIO.View.Columns.Count > 0)
            {
                repositoryFagIO.View.Columns.ColumnByName("colFlagIO").Caption = "I/O";
                repositoryFagIO.View.Columns.ColumnByName("colFlagIO").Width = 50;
            }

            gvDetail.Columns.ColumnByName("colProductId").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
        }

        private void ClearFeilds()
        {
            txtAdjustNo.Text = string.Empty;
            dtp.Value = DateTime.Now;
            cmbWarehouse.SelectedValue = -1;
            txtRemarks.Text = string.Empty;
            StockAdjusmentId = -1;
            DeletedIds = new List<int>();
            dset.Tables["AdjustmentDetail"].Rows.Clear();
            dset.Tables["AdjustmentMaster"].Rows.Clear();
            dset.RejectChanges();
            

            drMaster = dset.Tables["AdjustmentMaster"].NewRow();
            dset.Tables["AdjustmentMaster"].Rows.Add(drMaster);
            GCDetail.DataSource = dset.Tables["AdjustmentDetail"];
            GridSetting();
            txtAdjustNo.ReadOnly = false;
            ButtonRights(true);
            dtp.Focus();
        }

        private void LoadInvoice()
        {
            try
            {
                setGridSetup();

                if (dset.Tables["AdjustmentMaster"].Rows.Count > 0)
                {
                    txtAdjustNo.Text = drMaster["AdjustNo"].ToString();
                    dtp.Value = Convert.ToDateTime(drMaster["Date"]);
                    cmbWarehouse.SelectedValue = drMaster["WarehouseId"].ToString();
                    txtRemarks.Text = drMaster["Remarks"].ToString();
                    txtAdjustNo.ReadOnly = true;
                    ButtonRights(false);
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
                switch (e.Column.Name.ToString())
                {
                    case "colProductId":
                        dr["ProductCategoryId"] = dvProducts[0]["ProductCategoryId"];

                        if (string.IsNullOrEmpty(dr["Qty"].ToString()))
                        {
                            dr["Qty"] = 1;
                        }
                        break;
                    case "colQty":
                        if (string.IsNullOrEmpty(dr["Qty"].ToString()))
                        {
                            dr["Qty"] = 1;
                        }
                        if (decimal.Parse(dr["Qty"].ToString()) < 0)
                        {
                            dr["Qty"] = 1;  //Qty Should be greater then zero;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {

            }


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
                            catch { }

                            break;
                        }
                }
            }
        }

        private void gvDetail_RowCountChanged(object sender, EventArgs e)
        {


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
                e.ErrorText = "Item Alredy Exits."; //Messages.ItemAlreadyPresentinList;
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

                case "colQty":
                    gvDetail.FocusedColumn = gvDetail.Columns.ColumnByName("colQty");

                    break; // TODO: might not be correct. Was : Exit Select
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
                return;
            }

            else if (decimal.Parse(dr["Qty"].ToString()) <= 0)
            {
                //Quantity = "Less than one";
                e.Valid = false;
                return;
            }
            else if (string.IsNullOrEmpty(dr["FlagIO"].ToString()))
            {
                //Quantity = "Less than one";
                e.Valid = false;
                return;
            }



            else if (dr.RowState == DataRowState.Detached)
            {
                if (dset.Tables["AdjustmentDetail"].Select("ProductId =" + dr["ProductId"].ToString()).Length > 0)
                {
                    MessageBox.Show("Item Already Exists", "Same Items can not be repeated.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Valid = false;
                    return;
                }
            }


            e.Valid = true;
            gvDetail.GetDataRow(e.RowHandle)["AdjustId"] = drMaster["AdjustId"]; //SalesMasterId;

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
                            case "colQty":
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
            if (Convert.ToInt32(cmbWarehouse.SelectedValue) <= 0)
            {
                MessageBox.Show("Please Select Warehouse Name.", "Warehouse is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbWarehouse.Focus();
                result = false;
            }
            if (dset.Tables["AdjustmentDetail"].Rows.Count <= 0)
            {
                MessageBox.Show("Please Enter Detail of Product Adjustment.", "Detail is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
            }

            return result;

        }

        private void DeleteStockAdjustment()
        {
            if (string.IsNullOrEmpty(txtAdjustNo.Text))
            {
                return;
            }
            try
            {
                dataAcess.BeginTransaction();
                //hum pehele ProductLedger se Clear kry gy than again insert.
                manageProduct.DeleteProductLedgerByTransNo(txtAdjustNo.Text, true, dataAcess);
                manageProduct.DeleteAdjustmentMaster(StockAdjusmentId, dataAcess);
                dataAcess.TransCommit();
                MessageBox.Show("Stock Adjustment  " + txtAdjustNo.Text + " is Deleted.", "Adjustment Delete Successful.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    DataTable dtStockAdjust;
                    dataAcess.BeginTransaction();
                    if (dataAcess.getDBCommand().Transaction == null)
                    {
                        dataAcess.SetDBTransaction();
                    }
                    dtStockAdjust = manageProduct.InsertStockAdjusmentMaster(dtp.Value, Convert.ToInt32(cmbWarehouse.SelectedValue), txtRemarks.Text, MainForm.User_Id, DateTime.Now, "", dataAcess);
                    if (dtStockAdjust.Rows.Count > 0)
                    {
                        StockAdjusmentId = Convert.ToInt32(dtStockAdjust.Rows[0]["Id"]);
                        //txtAdjustNo.Text = dtStockAdjust.Rows[0]["AdjustmentNo"].ToString();
                    }
                    else
                    {
                        throw new Exception("Adjustment Refrence not found");
                    }
                    if (StockAdjusmentId > 0)
                    {
                        for (int i = 0; i < dset.Tables["AdjustmentDetail"].Rows.Count; i++)
                        {
                            DataRow drDetail = dset.Tables["AdjustmentDetail"].Rows[i];
                            if (drDetail.RowState != DataRowState.Deleted)
                            {
                                int DetailId = manageProduct.InsertUpdateStockAdjustmentDetail(Convert.ToInt32(drDetail["AdjustDetailId"]), StockAdjusmentId,
                                    Convert.ToInt32(drDetail["ProductId"]), "Stock", Convert.ToInt32(cmbWarehouse.SelectedValue),
                                    Convert.ToDecimal(drDetail["Qty"]), drDetail["FlagIO"].ToString() , dataAcess);

                                manageProduct.InsertProductLedger(Convert.ToInt32(drDetail["ProductId"]), dtp.Value, dtStockAdjust.Rows[0]["AdjustmentNo"].ToString(), DetailId, drDetail["FlagIO"].ToString(), Convert.ToDecimal(drDetail["Qty"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "",
                                    null, "Adjustment from Adjustment Form", Convert.ToInt32(cmbWarehouse.SelectedValue), -1, "", dataAcess);
                            }
                        }
                        dataAcess.TransCommit();
                        MessageBox.Show("Stock Adjusment Record Insert Sucessfully", "Record Saved Successful.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFeilds();


                    }
                    else
                    {
                        throw new Exception("Master Data does Not Insert.");
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
                search.getattributes("GetSearchAdjustment", null, "Stock Adjustment");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtAdjustNo.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                    //LoadInvoice();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    foreach (int id in DeletedIds)
                    {
                        manageProduct.DeleteAdjustDetailByDetailId(id, dataAcess);
                    }
                    //hum pehele ProductLedger se Clear kry gy than again insert.
                    manageProduct.DeleteProductLedgerByTransNo(txtAdjustNo.Text, true, dataAcess);

                    manageProduct.UpdateStockAdjusmentMaster(StockAdjusmentId, dtp.Value,Convert.ToInt32(cmbWarehouse.SelectedValue) ,txtRemarks.Text, MainForm.User_Id, DateTime.Now, "", dataAcess);
                    for (int i = 0; i < dset.Tables["AdjustmentDetail"].Rows.Count; i++)
                    {
                        if (dset.Tables["AdjustmentDetail"].Rows[i].RowState != DataRowState.Deleted)
                        {
                            DataRow drDetail = dset.Tables["AdjustmentDetail"].Rows[i];
                            int DetailId = manageProduct.InsertUpdateStockAdjustmentDetail(Convert.ToInt32(drDetail["AdjustDetailId"]), StockAdjusmentId,
                                    Convert.ToInt32(drDetail["ProductId"]), "Stock", Convert.ToInt32(cmbWarehouse.SelectedValue),
                                    Convert.ToDecimal(drDetail["Qty"]), drDetail["FlagIO"].ToString(), dataAcess);

                            manageProduct.InsertProductLedger(Convert.ToInt32(drDetail["ProductId"]), dtp.Value, txtAdjustNo.Text , DetailId, drDetail["FlagIO"].ToString(), Convert.ToDecimal(drDetail["Qty"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "",
                                    null, "Adjustment from Adjustment Form", Convert.ToInt32(cmbWarehouse.SelectedValue), -1, "", dataAcess);
                        }
                    }
                    dataAcess.TransCommit();
                    MessageBox.Show("Stock Adjustment Record Update Sucessfully", "Record Updated Successful.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (Convert.ToInt32(dr["AdjustDetailId"].ToString()) > 0)
                {
                    DeletedIds.Add(Convert.ToInt32(dr["AdjustDetailId"].ToString()));
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Adjustment Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {

                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeleteStockAdjustment();
                        break;
                    }

            }
        }

        private void frmRequisition_KeyDown(object sender, KeyEventArgs e)
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

        private void txtRequisitionNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAdjustNo.Text))
            {
                StockAdjusmentId = manageProduct.GetAdjustmentIdByCode(txtAdjustNo.Text);
                if (StockAdjusmentId > 0)
                {
                    LoadInvoice();
                }

            }
        }
    }

