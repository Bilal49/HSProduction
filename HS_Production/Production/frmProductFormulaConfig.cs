using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frmProductFormulaConfig : Form
    {
        Smartworks.DAL dataAcess = new Smartworks.DAL();
        ProductManager manageProduct = new ProductManager();
        BindingSource bsProduct = new BindingSource();
        BindingSource bsProductUnit = new BindingSource();
        BindingSource bsWarehouse = new BindingSource();
        RepositoryItemGridLookUpEdit repositoryGridLookup = new RepositoryItemGridLookUpEdit();
        RepositoryItemGridLookUpEdit repositoryUnitGridLookup = new RepositoryItemGridLookUpEdit();
        RepositoryItemGridLookUpEdit repositoryWarehouseGridLookup = new RepositoryItemGridLookUpEdit();
        DataSet dsMain = null;
        List<int> DeletedIds = new List<int>();
        DataView dvProduct;
        DataViewManager dvm;
        int FormulaId = -1;
        public frmProductFormulaConfig()
        {
            InitializeComponent();
        }
        private void frmProductFormula_Load(object sender, EventArgs e)
        {
            try
            {
                setupGrip();
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
            dsMain = manageProduct.GetProductFormulaConfigStructure();

            dsMain.Tables[0].TableName = "FormulaConfig";
            dsMain.Tables[1].TableName = "Products";
            dsMain.Tables[2].TableName = "MesurementUnit";
            dsMain.Tables[3].TableName = "Warehouse";

            dsMain.Tables["FormulaConfig"].Columns["FormulaConfigId"].AutoIncrement = true;
            dsMain.Tables["FormulaConfig"].Columns["FormulaConfigId"].AutoIncrementSeed = -1;
            dsMain.Tables["FormulaConfig"].Columns["FormulaConfigId"].AutoIncrementStep = -1;

            dvm = new DataViewManager(dsMain);
            dvProduct = dvm.CreateDataView(dsMain.Tables["Products"]);
            GCDetail.DataSource = dsMain.Tables["FormulaConfig"];
            GridSetting();
        }

        private void GridSetting()
        {
            gvDetail.Columns.ColumnByName("colFormulaConfigId").OptionsColumn.ReadOnly = true;

            gvDetail.Columns.ColumnByName("colFormulaConfigId").Visible = false;

            gvDetail.Columns.ColumnByName("colWarehouseId").Caption = "Warehouse";
            gvDetail.Columns.ColumnByName("colProductId").Caption = "Raw Material Name";
            gvDetail.Columns.ColumnByName("colUnitId").Caption = "Unit Name";
            gvDetail.Columns.ColumnByName("colWarehouseSequance").Caption = "Dept Sq";
            gvDetail.Columns.ColumnByName("colProductSequance").Caption = "Raw Sq";



            gvDetail.Columns.ColumnByName("colWarehouseId").VisibleIndex = 0;
            gvDetail.Columns.ColumnByName("colProductId").VisibleIndex = 1;
            gvDetail.Columns.ColumnByName("colUnitId").VisibleIndex = 2;
            gvDetail.Columns.ColumnByName("colWarehouseSequance").VisibleIndex = 3;
            gvDetail.Columns.ColumnByName("colProductSequance").VisibleIndex = 4;


            gvDetail.Columns.ColumnByName("colWarehouseId").Width = 120;
            gvDetail.Columns.ColumnByName("colProductId").Width = 280;
            gvDetail.Columns.ColumnByName("colUnitId").Width = 100;
            gvDetail.Columns.ColumnByName("colWarehouseSequance").Width = 50;
            gvDetail.Columns.ColumnByName("colProductSequance").Width = 50;



            bsProduct.DataSource = dsMain;
            bsProduct.DataMember = "Products";


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

        }
        private bool Validation()
        {
            bool result = true;

            if (dsMain.Tables["FormulaConfig"].Rows.Count <= 0)
            {
                MessageBox.Show("Please Enter Formula Detail", "Formula Details Not Found.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = true;
                return result;
            }
            return result;
        }
        #endregion

        #region Grid Events
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
                            if (string.IsNullOrEmpty(dr["WarehouseSequance"].ToString()))
                            {
                                dr["WarehouseSequance"] = "0";
                            }
                            if (string.IsNullOrEmpty(dr["ProductSequance"].ToString()))
                            {
                                dr["ProductSequance"] = "0";
                            }

                            //if (string.IsNullOrEmpty(dr["Qty"].ToString()))
                            //{
                            //    dr["Qty"] = "0";
                            //}
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
            DataRow dr = gvDetail.GetFocusedDataRow();
            if ((dr != null))
            {
                if (!string.IsNullOrEmpty(dr["ProductId"].ToString()))
                {
                    dvProduct.RowFilter = "ProductId='" + dr["ProductId"].ToString() + "'";
                }
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
            }
            else if (string.IsNullOrEmpty(dr["WarehouseId"].ToString()))
            {
                e.Valid = false;
            }
            else if (decimal.Parse(dr["WarehouseId"].ToString()) <= 0)
            {
                e.Valid = false;
            }
            else if (string.IsNullOrEmpty(dr["UnitId"].ToString()))
            {
                e.Valid = false;
            }
            else if (decimal.Parse(dr["UnitId"].ToString()) <= 0)
            {
                e.Valid = false;
            }

            else if (dr.RowState == DataRowState.Detached)
            {
                if (dsMain.Tables["FormulaConfig"].Select("ProductId =" + dr["ProductId"].ToString()).Length > 0)
                {
                    //MessageBox.Show("Account Already Exists", "Same Account can not be repeated.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Valid = false;
                    e.ErrorText = "Already Exists" + Environment.NewLine + "Same Raw Material can not be repeated.";
                }
            }
            else
            {
                e.Valid = true;
                //yahan thora sa dout hai k id kia generate hogi. let c.
                //gvDetail.GetDataRow(e.RowHandle)["FormulaConfigId"] = 
            }
        }

        #endregion



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
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
                        manageProduct.DeleteFormulaConfigByConfigId(id, dataAcess);
                    }
                    foreach (DataRow dr in dsMain.Tables["FormulaConfig"].Rows)
                    {
                        if (dr.RowState != DataRowState.Deleted)
                        {
                            manageProduct.InsertUpdateFormulaConfig(Convert.ToInt32(dr["FormulaConfigId"]), Convert.ToInt32(dr["WarehouseId"]), Convert.ToInt32(dr["ProductId"]), Convert.ToInt32(dr["UnitId"]), Convert.ToInt32(dr["WarehouseSequance"]), Convert.ToInt32(dr["ProductSequance"]), dataAcess);
                        }
                    }
                    dataAcess.TransCommit();
                    MessageBox.Show("Product Formula Config Update Successfull", "Record Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DeletedIds = new List<int>();
                    setupGrip();
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
        private void btnClear_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvDetail_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            try
            {
                DataRow dr = default(DataRow);
                dr = gvDetail.GetDataRow(e.RowHandle);
                if (Convert.ToInt32(dr["FormulaConfigId"].ToString()) > 0)
                {
                    DeletedIds.Add(Convert.ToInt32(dr["FormulaConfigId"].ToString()));
                }
            }
            catch (Exception ex)
            {
            }
        }


    }
}
