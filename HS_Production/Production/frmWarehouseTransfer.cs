using CrystalDecisions.CrystalReports.Engine;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using FIL.App_Code.EmployeeManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace FIL
{
    public partial class frmWarehouseTransfer : Form
    {
        Smartworks.DAL dataAcess = new Smartworks.DAL();
        ProductManager manageProduct = new ProductManager();
        BindingSource bsProduct = new BindingSource();

        RepositoryItemGridLookUpEdit repositoryGridLookup = new RepositoryItemGridLookUpEdit();

        WarehouseManager managewarehouse = new WarehouseManager();
        SalesOrderManager manageSalesOrder = new SalesOrderManager();
        EmployeeManager manageEmployee = new EmployeeManager();
        DataSet dsMain = null;
        DataRow drMaster;
        DataView dvProduct;
        DataViewManager dvm;
        int WTMasterId = -1;
        List<int> DeletedIds = new List<int>();
        public frmWarehouseTransfer()
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
                txtWTCode.Text = GetNewNextNumber();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private String GetNewNextNumber()
        {
            string NewInvoiceNo = "";
            NewInvoiceNo = managewarehouse.GetMaxInvioceNo();
            if (!string.IsNullOrEmpty(NewInvoiceNo))
            {
                NewInvoiceNo = manageSalesOrder.GetNextInvioceNo(NewInvoiceNo);
            }
            else
            {
                NewInvoiceNo = "WT-000001";
            }
            return NewInvoiceNo;
        }

        #region Method

        private void FillDropDown()
        {
            DataTable dtFWarehouse = new DataTable();
            dtFWarehouse = managewarehouse.GetWarehouseList();

            DataRow drFwarehouse = dtFWarehouse.NewRow();
            drFwarehouse["WarehouseId"] = -1;
            drFwarehouse["Warehouse"] = "--Select Department--";
            dtFWarehouse.Rows.InsertAt(drFwarehouse, 0);

            cmbFWarehouse.DataSource = dtFWarehouse;
            cmbFWarehouse.DisplayMember = "Warehouse";
            cmbFWarehouse.ValueMember = "WarehouseId";



            DataTable dtTWarehouse = new DataTable();
            dtTWarehouse = managewarehouse.GetWarehouseList();

            DataRow drTwarehouse = dtTWarehouse.NewRow();
            drTwarehouse["WarehouseId"] = -1;
            drTwarehouse["Warehouse"] = "--Select Department--";
            dtTWarehouse.Rows.InsertAt(drTwarehouse, 0);

            cmbTWarehouse.DataSource = dtTWarehouse;
            cmbTWarehouse.DisplayMember = "Warehouse";
            cmbTWarehouse.ValueMember = "WarehouseId";
        }
        private void setupGrip()
        {
            dsMain = new DataSet();
            dsMain = managewarehouse.GetWarehouseTrasnferStructure(WTMasterId);

            dsMain.Tables[0].TableName = "WTMaster";
            dsMain.Tables[1].TableName = "WTDetail";
            dsMain.Tables[2].TableName = "Products";


            dsMain.Tables["WTMaster"].Columns["WTMasterId"].AutoIncrement = true;
            dsMain.Tables["WTMaster"].Columns["WTMasterId"].AutoIncrementSeed = -1;
            dsMain.Tables["WTMaster"].Columns["WTMasterId"].AutoIncrementStep = -1;

            dsMain.Tables["WTDetail"].Columns["WTDetailId"].AutoIncrement = true;
            dsMain.Tables["WTDetail"].Columns["WTDetailId"].AutoIncrementSeed = -1;
            dsMain.Tables["WTDetail"].Columns["WTDetailId"].AutoIncrementStep = -1;


            dsMain.Relations.Add("MasterRelation", dsMain.Tables["WTMaster"].Columns["WTMasterId"], dsMain.Tables["WTDetail"].Columns["WTMasterId"]);
            if (dsMain.Tables["WTMaster"].Rows.Count > 0)
            {
                drMaster = dsMain.Tables["WTMaster"].Rows[0];
            }
            else
            {
                drMaster = dsMain.Tables["WTMaster"].NewRow();
                dsMain.Tables["WTMaster"].Rows.Add(drMaster);
            }
            //drMaster = dsMain.Tables["WTMaster"].NewRow();
            //dsMain.Tables["WTMaster"].Rows.Add(drMaster);

            dvm = new DataViewManager(dsMain);
            dvProduct = dvm.CreateDataView(dsMain.Tables["Products"]);
            GCDetail.DataSource = dsMain.Tables["WTDetail"];
            GridSetting();
        }

        private void GridSetting()
        {
            gvDetail.Columns.ColumnByName("colWTDetailId").OptionsColumn.ReadOnly = true;
            gvDetail.Columns.ColumnByName("colWTMasterId").OptionsColumn.ReadOnly = true;

            gvDetail.Columns.ColumnByName("colWTDetailId").Visible = false;
            gvDetail.Columns.ColumnByName("colWTMasterId").Visible = false;

            gvDetail.Columns.ColumnByName("colProductId").Caption = "Material Name";
            gvDetail.Columns.ColumnByName("colQtyToTransfer").Caption = "Quantity";


            gvDetail.Columns.ColumnByName("colProductId").VisibleIndex = 0;
            gvDetail.Columns.ColumnByName("colQtyToTransfer").VisibleIndex = 1;



            gvDetail.Columns.ColumnByName("colProductId").Width = 250;
            gvDetail.Columns.ColumnByName("colQtyToTransfer").Width = 50;


            bsProduct.DataSource = dsMain;
            bsProduct.DataMember = "Products";



            repositoryGridLookup.DataSource = bsProduct;
            repositoryGridLookup.DisplayMember = "ProductName";
            repositoryGridLookup.ValueMember = "ProductId";
            repositoryGridLookup.PopupFormSize = new Size(500, 200);
            repositoryGridLookup.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            repositoryGridLookup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            repositoryGridLookup.ImmediatePopup = true;
            repositoryGridLookup.NullText = "";
            repositoryGridLookup.ShowFooter = false;
            repositoryGridLookup.View.OptionsView.ColumnAutoWidth = false;
            repositoryGridLookup.PopulateViewColumns();
            GCDetail.RepositoryItems.Add(repositoryGridLookup);

            (GCDetail.MainView as GridView).Columns.ColumnByName("colProductId").ColumnEdit = repositoryGridLookup;

            if (repositoryGridLookup.View.Columns.Count > 0)
            {
                repositoryGridLookup.View.Columns.ColumnByName("colProductId").Visible = false;
                //repositoryGridLookup.View.Columns.ColumnByName("colMesurementUnitId").Visible = false;

                repositoryGridLookup.View.Columns.ColumnByName("colProductCode").Caption = "Code";
                repositoryGridLookup.View.Columns.ColumnByName("colProductName").Caption = "Product Name";
                // repositoryGridLookup.View.Columns.ColumnByName("colProductNature").Caption = "Product Name";
                repositoryGridLookup.View.Columns.ColumnByName("colCategoryName").Caption = "Category";


                repositoryGridLookup.View.Columns.ColumnByName("colProductCode").Width = 80;
                repositoryGridLookup.View.Columns.ColumnByName("colProductName").Width = 150;
                //repositoryGridLookup.View.Columns.ColumnByName("colProductNature").Width = 80;
                repositoryGridLookup.View.Columns.ColumnByName("colCategoryName").Width = 100;

                repositoryGridLookup.View.Columns.ColumnByName("colProductCode").VisibleIndex = 0;
                repositoryGridLookup.View.Columns.ColumnByName("colProductName").VisibleIndex = 1;
                //repositoryGridLookup.View.Columns.ColumnByName("colProductNature").VisibleIndex = 2;
                repositoryGridLookup.View.Columns.ColumnByName("colCategoryName").VisibleIndex = 3;
            }
        }
        private void ButtonRights(bool Enable)
        {
            btnAdd.Enabled = Enable;
            btnUpdate.Enabled = !Enable;
            btnDelete.Enabled = !Enable;
            txtWTCode.ReadOnly = !Enable;

        }

        private bool Validation()
        {
            bool result = true;
            //if (string.IsNullOrEmpty(txtEmployeeCode.Text))
            //{
            //    MessageBox.Show("Please Select Employee Name", "Employee Name is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    result = false;
            //    txtEmployeeCode.Focus();
            //    return result;
            //}

            if (Convert.ToInt32(cmbFWarehouse.SelectedValue) <= 0)
            {
                MessageBox.Show("Please Select From Department Name", "Department Name is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                cmbFWarehouse.Focus();
                return result;
            }
            if (Convert.ToInt32(cmbTWarehouse.SelectedValue) <= 0)
            {
                MessageBox.Show("Please Select To Department Name", "Department Name is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                cmbTWarehouse.Focus();
                return result;
            }

            if (Convert.ToInt32(cmbTWarehouse.SelectedValue) == Convert.ToInt32(cmbFWarehouse.SelectedValue))
            {
                MessageBox.Show("Please Select To Department Name", "Department Name is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                cmbTWarehouse.Focus();
                return result;
            }


            //yeh condition comment kerdi hai q k bhot se general expense wale item and sampling order and Pen lining wagira mai yeh condition fail hai.
            //if (string.IsNullOrEmpty(txtSONo.Text))
            //{
            //    MessageBox.Show("Please Enter Sales Order No.", "Sales Order No is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    result = false;
            //    txtSONo.Focus();
            //    return result;
            //}

            //if (string.IsNullOrEmpty(txtPCode.Text))
            //{
            //    MessageBox.Show("Please Enter Article Code.", "Article Code is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    result = false;
            //    txtPCode.Focus();
            //    return result;
            //}





            if (dsMain.Tables["WTDetail"].Rows.Count <= 0)
            {
                MessageBox.Show("Please Enter Transfer Detail", "Transfer Details Not Found.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                return result;
            }

            if (chkProcess.Checked)
            {
                if (string.IsNullOrEmpty(txtProcessQty.Text))
                {
                    MessageBox.Show("Please Enter Process Quantity.", "Process Qty is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    result = false;
                    return result;
                }

                if (string.IsNullOrEmpty(txtSONo.Text))
                {
                    MessageBox.Show("Please Enter Sales Order No.", "Sales Order is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    result = false;
                    return result;
                }

                if (string.IsNullOrEmpty(txtPCode.Text))
                {
                    MessageBox.Show("Please Enter Product Code.", "Product is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    result = false;
                    return result;
                }
            }

            return result;
        }

        private void ClearFeilds()
        {
            txtWTCode.Text = string.Empty;
            cmbTWarehouse.SelectedValue = -1;
            cmbFWarehouse.SelectedValue = -1;
            txtRemarks.Text = string.Empty;
            txtEmployeeCode.Text = string.Empty;
            chkProcess.Checked = false;
            txtProcessQty.Text = string.Empty;
            txtSONo.Text = string.Empty;
            txtBatchNo.Text = string.Empty;
            WTMasterId = -1;
            dsMain.Tables["WTDetail"].Rows.Clear();
            dsMain.Tables["WTMaster"].Rows.Clear();

            dsMain.RejectChanges();
            drMaster = dsMain.Tables["WTMaster"].NewRow();
            dsMain.Tables["WTMaster"].Rows.Add(drMaster);
            GCDetail.DataSource = dsMain.Tables["WTDetail"];
            DeletedIds = new List<int>();
            GridSetting();
            ButtonRights(true);
            btnNextInvioceNo.Enabled = false;
            btnPrevInvioceNo.Enabled = false;
            setupGrip();
            cmbFWarehouse.Focus();
            txtWTCode.Text = GetNewNextNumber();

        }

        bool IsLoad = false;
        private void LoadWarehouseTransfer()
        {
            IsLoad = true;
            setupGrip();
            cmbFWarehouse.SelectedValue = Convert.ToInt32(drMaster["WarehouseFrom"]);
            cmbTWarehouse.SelectedValue = Convert.ToInt32(drMaster["WarehouseTo"]);
            txtEmployeeCode.Text = manageEmployee.GetEmployee(Convert.ToInt32(drMaster["RequestedBy"])).Rows[0]["Code"].ToString();
            txtRemarks.Text = drMaster["Narration"].ToString();
            dtpDate.Value = Convert.ToDateTime(drMaster["TransferDate"]);
            txtSONo.Text = drMaster["SOrderNo"].ToString();
           
            if (!string.IsNullOrEmpty(drMaster["ProductId"].ToString()))
            {
                DataTable dtProduct = manageProduct.GetProduct(Convert.ToInt32(drMaster["ProductId"].ToString()));
                if (dtProduct.Rows.Count > 0)
                {
                    txtPCode.Text = dtProduct.Rows[0]["ProductCode"].ToString();//manageProduct.GetProduct(Convert.ToInt32(drMaster["ProductId"].ToString())).Rows[0]["ProductCode"].ToString();
                }

            }
            if (!string.IsNullOrEmpty(drMaster["IsStartProcessing"].ToString()))
            {
                if (Convert.ToBoolean(drMaster["IsStartProcessing"]))
                {
                    chkProcess.Checked = true;
                    txtProcessQty.Text = drMaster["ProcessQty"].ToString();
                }
            }
            txtBatchNo.Text = drMaster["BatchNo"].ToString();
            IsLoad = false;
            ButtonRights(false);
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
                            catch (Exception ex)
                            { }

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
                            if (string.IsNullOrEmpty(dr["QtyToTransfer"].ToString()))
                            {
                                dr["QtyToTransfer"] = "0";
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
                e.ErrorText = "Account Name Not Found.";
            }

            else if (dr.RowState == DataRowState.Detached)
            {
                if (dsMain.Tables["WTDetail"].Select("ProductId =" + dr["ProductId"].ToString()).Length > 0)
                {
                    //MessageBox.Show("Account Already Exists", "Same Account can not be repeated.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Valid = false;
                    e.ErrorText = "Already Exists" + Environment.NewLine + "Same Raw Material can not be repeated.";
                }
            }
            else
            {
                e.Valid = true;

            }
            gvDetail.GetDataRow(e.RowHandle)["WTMasterId"] = drMaster["WTMasterId"];
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                try
                {
                    ProcessingManager manageProcessing = new ProcessingManager();
                    DataTable dtWTMaster = new DataTable();
                    int EmployeeId = manageEmployee.GetEmployeeIdByCode(txtEmployeeCode.Text);
                    if (EmployeeId < 0)
                    {
                        MessageBox.Show("Employee does not found.", "Employee Identity not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    int ProductId = -1;
                    if (!string.IsNullOrEmpty(txtPCode.Text))
                    {
                        ProductId = manageProduct.GetProductIdByCode(txtPCode.Text);
                    }
                    dataAcess.BeginTransaction();
                    if (dataAcess.getDBCommand().Transaction == null)
                    {
                        dataAcess.SetDBTransaction();
                    }
                    dtWTMaster = managewarehouse.InsertWTMaster(EmployeeId, Convert.ToInt32(cmbFWarehouse.SelectedValue), Convert.ToInt32(cmbTWarehouse.SelectedValue), dtpDate.Value, txtSONo.Text, ProductId, txtRemarks.Text, false, false, "H", MainForm.User_Id, DateTime.Now, "", chkProcess.Checked, (string.IsNullOrEmpty(txtProcessQty.Text) ? 0 : Convert.ToDecimal(txtProcessQty.Text)) , txtBatchNo.Text  , dataAcess);
                    if (dtWTMaster.Rows.Count == 0)
                    {
                        MessageBox.Show("Department Transfer Insert Error", "Can not Insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw new Exception();
                    }
                    else
                    {
                        WTMasterId = Convert.ToInt32(dtWTMaster.Rows[0]["Id"]);
                    }
                    foreach (DataRow dr in dsMain.Tables["WTDetail"].Rows)
                    {
                        int DetailId = managewarehouse.InsertUpdateWTDetail(Convert.ToInt32(dr["WTDetailId"]), WTMasterId, Convert.ToInt32(dr["ProductId"]), "H", "Stock", "", "Stock", Convert.ToDecimal(dr["QtyToTransfer"]), MainForm.User_Id, DateTime.Now, "", dataAcess);
                        manageProduct.InsertProductLedger(Convert.ToInt32(dr["ProductId"]), dtpDate.Value, dtWTMaster.Rows[0]["TransferNo"].ToString(), DetailId, "O", Convert.ToDecimal(dr["QtyToTransfer"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Transfer Out from Warehouse Transfer", Convert.ToInt32(cmbFWarehouse.SelectedValue), -1, "", dataAcess);
                        manageProduct.InsertProductLedger(Convert.ToInt32(dr["ProductId"]), dtpDate.Value, dtWTMaster.Rows[0]["TransferNo"].ToString(), DetailId, "I", Convert.ToDecimal(dr["QtyToTransfer"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, " Transfer Inn from Warehouse Transfer ", Convert.ToInt32(cmbTWarehouse.SelectedValue), -1,"", dataAcess);
                    }
                    if (chkProcess.Checked)
                    {

                        manageProcessing.InsertUpdateProductionLedger(Convert.ToInt32(cmbTWarehouse.SelectedValue), ProductId, -1, txtSONo.Text, dtpDate.Value, txtWTCode.Text,
                        WTMasterId, "I", (string.IsNullOrEmpty(txtProcessQty.Text.ToString()) ? 0 : Convert.ToDecimal(txtProcessQty.Text)), -1, "Entry From Department Transfer", false, dataAcess);
                    }
                    dataAcess.TransCommit();
                    MessageBox.Show("Warehouse Transfer Insert Successfull", "Record Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ButtonRights(false);
                    ClearFeilds();
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
                try
                {
                    ProcessingManager manageProcessing = new ProcessingManager();
                    int EmployeeId = manageEmployee.GetEmployeeIdByCode(txtEmployeeCode.Text);
                    if (EmployeeId < 0)
                    {
                        MessageBox.Show("Employee does not found.", "Employee Identity not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    int ProductId = -1;
                    if (!string.IsNullOrEmpty(txtPCode.Text))
                    {
                        ProductId = manageProduct.GetProductIdByCode(txtPCode.Text);
                    }
                    dataAcess.BeginTransaction();
                    if (dataAcess.getDBCommand().Transaction == null)
                    {
                        dataAcess.SetDBTransaction();
                    }

                    foreach (int id in DeletedIds)
                    {
                        //manageProduct.DeleteProductFromLedgerByTransNoAndDetailId(txtWTCode.Text, id, dataAcess);
                        managewarehouse.DeleteWTDetailByDetailId(id, dataAcess);
                    }
                    //hum pehele ProductLedger se Clear kry gy than again insert.
                    manageProduct.DeleteProductLedgerByTransNo(txtWTCode.Text , true, dataAcess);
                    manageProcessing.DeleteProductionLedgerByTransNo(txtWTCode.Text , true, dataAcess);

                    managewarehouse.UpdateWTMaster(WTMasterId, EmployeeId, Convert.ToInt32(cmbFWarehouse.SelectedValue), Convert.ToInt32(cmbTWarehouse.SelectedValue), dtpDate.Value, txtSONo.Text, ProductId, txtRemarks.Text, false, false, "H", MainForm.User_Id, DateTime.Now, "", chkProcess.Checked, (string.IsNullOrEmpty(txtProcessQty.Text) ? 0 : Convert.ToDecimal(txtProcessQty.Text)), txtBatchNo.Text ,  dataAcess);
                    foreach (DataRow dr in dsMain.Tables["WTDetail"].Rows)
                    {
                        if (dr.RowState != DataRowState.Deleted)
                        {
                            int DetailId = managewarehouse.InsertUpdateWTDetail(Convert.ToInt32(dr["WTDetailId"]), Convert.ToInt32(dr["WTMasterId"]), Convert.ToInt32(dr["ProductId"]), "H", "Stock", "", "Stock", Convert.ToDecimal(dr["QtyToTransfer"]), MainForm.User_Id, DateTime.Now, "", dataAcess);
                            manageProduct.InsertProductLedger(Convert.ToInt32(dr["ProductId"]), dtpDate.Value, txtWTCode.Text, DetailId, "O", Convert.ToDecimal(dr["QtyToTransfer"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Transfer Out from Warehouse Transfer", Convert.ToInt32(cmbFWarehouse.SelectedValue), -1, "", dataAcess);
                            manageProduct.InsertProductLedger(Convert.ToInt32(dr["ProductId"]), dtpDate.Value, txtWTCode.Text, DetailId, "I", Convert.ToDecimal(dr["QtyToTransfer"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Transfer Inn from Warehouse Transfer", Convert.ToInt32(cmbTWarehouse.SelectedValue), -1, "", dataAcess);
                        }
                    }
                    if (chkProcess.Checked)
                    {

                        manageProcessing.InsertUpdateProductionLedger(Convert.ToInt32(cmbTWarehouse.SelectedValue), ProductId, -1, txtSONo.Text, dtpDate.Value, txtWTCode.Text,
                        WTMasterId, "I", (string.IsNullOrEmpty(txtProcessQty.Text.ToString()) ? 0 : Convert.ToDecimal(txtProcessQty.Text)), -1, "Entry From Department Transfer", false, dataAcess);
                    }
                    dataAcess.TransCommit();
                    MessageBox.Show("Warehouse Transfer Update Successfull", "Record Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFeilds();
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
                search.getattributes("GetWTSearch", null, "Warehouse Transfer");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtWTCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtFormulaId_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtWTCode.Text))
            {
                WTMasterId = managewarehouse.GetWTMasterIdByCode(txtWTCode.Text);
                if (WTMasterId > 0)
                {
                    LoadWarehouseTransfer();
                }
            }
            else
            {
                ClearFeilds();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Transfer Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeleteWTMaster();
                        break;
                    }
            }
        }

        private void DeleteWTMaster()
        {
            try
            {
                dataAcess.BeginTransaction();
                manageProduct.DeleteProductLedgerByTransNo(txtWTCode.Text, dataAcess);
                managewarehouse.DeleteWTMaster(WTMasterId, dataAcess);
                dataAcess.TransCommit();
                MessageBox.Show("Warehousr Transfer Delete Sucessfully", "Record Deleted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
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
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //PrintInvoice(false);
        }

        private void PrintInvoice(bool IsDirectPrint = true)
        {
            try
            {
                if (string.IsNullOrEmpty(txtWTCode.Text))
                {
                    return;
                }

                string path = Application.StartupPath + "/rpt/Production/rptProductFormula.rpt";
                ReportDocument document = new ReportDocument();
                document.Load(path);
                DataTable dtReport = new DataTable();
                dtReport = manageProduct.GetReportProductFormula(manageProduct.GetFormulaIdByCode(Convert.ToInt32(txtWTCode.Text)));
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

        private void btnSNo_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearch search = new frmSearch();
                search.getattributes("GetSearchSalesOrdersAllYear", null, "Sales Orders");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtSONo.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
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
                    DataTable dtSOrder = manageSalesOrder.GetSaleOrderMaster(manageSalesOrder.GetSalesOrderMasterIdByCode(txtSONo.Text));
                    if (dtSOrder.Rows.Count > 0)
                    {
                        CustomerManager manageCustomer = new CustomerManager();
                        txtPONo.Text = dtSOrder.Rows[0]["PONo"].ToString();
                        txtCName.Text = manageCustomer.GetCustomer(manageCustomer.GetCustomerIdByCode(dtSOrder.Rows[0]["CustomerCode"].ToString())).Rows[0]["CustomerName"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    txtCName.Text = string.Empty;
                }
            }
            else
            {
                txtCName.Text = string.Empty;
                txtPCode.Text = string.Empty;
            }
        }

        private void btnMaxInvioceNo_Click(object sender, EventArgs e)
        {
            txtWTCode.Text = managewarehouse.GetMaxInvioceNo();
            if (!string.IsNullOrEmpty(txtWTCode.Text))
            {
                btnNextInvioceNo.Enabled = false;
                btnPrevInvioceNo.Enabled = true;
            }
        }

        private void btnMinInvioceNo_Click(object sender, EventArgs e)
        {
            txtWTCode.Text = managewarehouse.GetMinInvioceNo();
            if (!string.IsNullOrEmpty(txtWTCode.Text))
            {
                btnNextInvioceNo.Enabled = true;
                btnPrevInvioceNo.Enabled = false;
            }
        }

        private void btnNextInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtWTCode.Text))
            {
                string LastInvioceNo = managewarehouse.GetMaxInvioceNo();
                txtWTCode.Text = managewarehouse.GetNextInvioceNo(txtWTCode.Text);

                if (LastInvioceNo == txtWTCode.Text)
                {
                    btnNextInvioceNo.Enabled = false;
                }
                else
                {
                    btnPrevInvioceNo.Enabled = true;
                }
            }
        }

        private void btnPrevInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtWTCode.Text))
            {
                string LastInvioceNo = managewarehouse.GetMinInvioceNo();
                txtWTCode.Text = managewarehouse.GetPrevInvioceNo(txtWTCode.Text);


                if (LastInvioceNo == txtWTCode.Text)
                {
                    btnPrevInvioceNo.Enabled = false;
                }
                else
                {
                    btnNextInvioceNo.Enabled = true;
                }
            }
        }

        private void gvDetail_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            try
            {
                DataRow dr = default(DataRow);
                dr = gvDetail.GetDataRow(e.RowHandle);
                if (Convert.ToInt32(dr["WTDetailId"].ToString()) > 0)
                {
                    DeletedIds.Add(Convert.ToInt32(dr["WTDetailId"].ToString()));
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnPSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSONo.Text))
                {
                    MessageBox.Show("Please Select Sale Order Number.", "Sale Order is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                frmSearch search = new frmSearch();
                Smartworks.ColumnField[] gSalesOrderProduct = new Smartworks.ColumnField[1];
                gSalesOrderProduct[0] = new Smartworks.ColumnField("@SaleOrderNo", txtSONo.Text);
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
                    }
                }
                else
                {
                    txtPName.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmWarehouseTransfer_KeyDown(object sender, KeyEventArgs e)
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
                //SendKeys.Send("{TAB}");
                if (GetFocusControl() != GCDetail.Name)
                {
                    SendKeys.Send("{TAB}");
                }
                //if (GCDetail.Focus())
                //{

                //}
                //else
                //{

                //}
            }
            else if (e.KeyCode == Keys.F2)
            {
                btnSearch.PerformClick();
            }

        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        internal static extern IntPtr GetFocus();

        private string GetFocusControl()
        {
            Control focusControl = null;
            IntPtr focusHandle = GetFocus();
            if (focusHandle != IntPtr.Zero)
                focusControl = Control.FromHandle(focusHandle);
            if (focusControl != null)
            {
                if (focusControl.Name.ToString().Length == 0)
                    return focusControl.Parent.Parent.Name.ToString();
                else
                    return focusControl.Name.ToString();
            }
            else
            {
                return string.Empty;
            }

        }

        private void chkProcess_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProcess.Checked)
            {
                if (!IsLoad)
                {
                    if (string.IsNullOrEmpty(txtSONo.Text))
                    {
                        MessageBox.Show("Sales Order No Not found. Please Select SO First", "SO is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        chkProcess.Checked = false;
                        txtProcessQty.ReadOnly = true;
                        return;
                    }
                    if (string.IsNullOrEmpty(txtPCode.Text))
                    {
                        MessageBox.Show("Article Name Not found. Please Select Article First", "Article is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        chkProcess.Checked = false;
                        txtProcessQty.ReadOnly = true;
                        return;
                    }
                }
                txtProcessQty.ReadOnly = false;
                
            }
            else
            {
                txtProcessQty.ReadOnly = true;
                txtProcessQty.Text = string.Empty;
            }
        }

        private void txtProcessQty_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProcessQty.Text))
            {
                decimal OrderQty = manageSalesOrder.GetOrderQtyBySONoandProductCode(txtSONo.Text, txtPCode.Text);
                if (Convert.ToDecimal(txtProcessQty.Text) > OrderQty)
                {
                    MessageBox.Show("Process Qty Should not be greater then Order Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProcessQty.Text = OrderQty.ToString();
                }
            }

        }
        Utility clsUtility = new Utility();
        private void txtProcessQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.setOnlyNumberic((TextBox)sender, false, e);
        }

        private void txtBatchNo_TextChanged(object sender, EventArgs e)
        {
            if (IsLoad)
            {
                return;
            }
            if (!string.IsNullOrEmpty(txtBatchNo.Text))
            {
                if (string.IsNullOrEmpty(txtSONo.Text) || string.IsNullOrEmpty(txtPCode.Text))
                {
                    MessageBox.Show("Sales Order # or Article Code Not Found.", "Make sure Sales Order No and Article Code are Selected",MessageBoxButtons.OK ,MessageBoxIcon.Warning);
                    txtBatchNo.Text = string.Empty;
                    return;
                }
            }
            
        }


    }
}
