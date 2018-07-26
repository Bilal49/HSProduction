using CrystalDecisions.CrystalReports.Engine;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;

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
    public partial class frmStockRequisition : Form
    {
        Smartworks.DAL dataAcess = new Smartworks.DAL();


        StockRequisitionManager manageRequisition = new StockRequisitionManager();
        WarehouseManager manageWarehouse = new WarehouseManager();
        DataSet dset;
        RepositoryItemGridLookUpEdit repositoryGridLookup = new RepositoryItemGridLookUpEdit();

        BindingSource bsProducts = new BindingSource();
        DataRow drMaster;
        DataView dvProducts;
        DataViewManager dvm;

        int StockReqMasterId = -1;
        List<int> DeletedIds = new List<int>();

        public frmStockRequisition()
        {
            InitializeComponent();
        }

        private void frmDirectSales_Load(object sender, EventArgs e)
        {
            ButtonRights(true);
            FillDropDown();
            txtRequisitionNo.Text = GetNewNextNumber();
            setGridSetup();
            btnNextInvioceNo.Enabled = false;
            btnPrevInvioceNo.Enabled = false;

        }

        #region All Methods

        private String GetNewNextNumber()
        {
            string NewInvoiceNo = "";
            NewInvoiceNo = manageRequisition.GetMaxInvioceNo();
            if (!string.IsNullOrEmpty(NewInvoiceNo))
            {
                NewInvoiceNo = manageRequisition.GetNextInvioceNo(NewInvoiceNo);
            }
            else
            {
                NewInvoiceNo = "REQ-000001";
            }
            return NewInvoiceNo;
        }

        private void FillDropDown()
        {
            DataTable dtFWarehouse = new DataTable();
            dtFWarehouse = manageWarehouse.GetWarehouseList();
            DataRow drFWarehouse = dtFWarehouse.NewRow();
            drFWarehouse["WarehouseId"] = -1;
            drFWarehouse["Warehouse"] = "---Select Warehouse---";
            dtFWarehouse.Rows.InsertAt(drFWarehouse, 0);
            cmbFWarehouse.DataSource = dtFWarehouse;
            cmbFWarehouse.DisplayMember = "Warehouse";
            cmbFWarehouse.ValueMember = "WarehouseId";


            DataTable dtTWarehouse = new DataTable();
            dtTWarehouse = manageWarehouse.GetWarehouseList();
            DataRow drTWarehouse = dtTWarehouse.NewRow();
            drTWarehouse["WarehouseId"] = -1;
            drTWarehouse["Warehouse"] = "---Select Warehouse---";
            dtTWarehouse.Rows.InsertAt(drTWarehouse, 0);
            cmbTWarehouse.DataSource = dtTWarehouse;
            cmbTWarehouse.DisplayMember = "Warehouse";
            cmbTWarehouse.ValueMember = "WarehouseId";
        }
        private void ButtonRights(bool Enable)
        {
            btnAdd.Enabled = Enable;
            btnUpdate.Enabled = !Enable;
            btnDelete.Enabled = !Enable;
            txtRequisitionNo.ReadOnly = !Enable;
            //btnOrderBySearch.Enabled = Enable;
           // txtOrderByCode.Enabled = Enable;
        }

        private void setGridSetup()
        {
            dset = new DataSet();
            dset = manageRequisition.GetRequisitionStructure(StockReqMasterId);
            dset.Tables[0].TableName = "REQMaster";
            dset.Tables[1].TableName = "REQDetail";
            dset.Tables[2].TableName = "Product";

            dset.Tables["REQMaster"].Columns["StockReqMasterId"].AutoIncrement = true;
            dset.Tables["REQMaster"].Columns["StockReqMasterId"].AutoIncrementSeed = -1;
            dset.Tables["REQMaster"].Columns["StockReqMasterId"].AutoIncrementStep = -1;

            dset.Tables["REQDetail"].Columns["StockReqDetailId"].AutoIncrement = true;
            dset.Tables["REQDetail"].Columns["StockReqDetailId"].AutoIncrementSeed = -1;
            dset.Tables["REQDetail"].Columns["StockReqDetailId"].AutoIncrementStep = -1;


            dset.Relations.Add("MasterRelation", dset.Tables["REQMaster"].Columns["StockReqMasterId"], dset.Tables["REQDetail"].Columns["StockReqMasterId"]);

            if (dset.Tables["REQMaster"].Rows.Count > 0)
            {
                drMaster = dset.Tables["REQMaster"].Rows[0];
            }
            else
            {
                drMaster = dset.Tables["REQMaster"].NewRow();
                dset.Tables["REQMaster"].Rows.Add(drMaster);
            }

            //drMaster = dset.Tables["REQMaster"].NewRow();
            //dset.Tables["REQMaster"].Rows.Add(drMaster);

            dvm = new DataViewManager(dset);
            dvProducts = dvm.CreateDataView(dset.Tables["Product"]);


            GCDetail.DataSource = dset.Tables["REQDetail"];

            GridSetting();
        }
        private void GridSetting()
        {
            //gvDetail.Columns.ColumnByName["colTotalAmount"].OptionsColumn.ReadOnly = True
            gvDetail.Columns.ColumnByName("colStockReqDetailId").OptionsColumn.ReadOnly = true;
            gvDetail.Columns.ColumnByName("colStockReqMasterId").OptionsColumn.ReadOnly = true;

            gvDetail.Columns.ColumnByName("colStockReqDetailId").Visible = false;
            gvDetail.Columns.ColumnByName("colStockReqMasterId").Visible = false;
            gvDetail.Columns.ColumnByName("colProductCategoryId").Visible = false;
            gvDetail.Columns.ColumnByName("colCategoryName").Visible = false;





            gvDetail.Columns.ColumnByName("colProductId").Caption = "Product Name";
            gvDetail.Columns.ColumnByName("colQty").Caption = "Quantity";

            gvDetail.Columns.ColumnByName("colProductId").VisibleIndex = 0;
            gvDetail.Columns.ColumnByName("colQty").VisibleIndex = 1;

            gvDetail.Columns.ColumnByName("colProductId").Width = 300;
            gvDetail.Columns.ColumnByName("colQty").Width = 50;


            bsProducts.DataSource = dset;
            bsProducts.DataMember = "Product";

            repositoryGridLookup.DataSource = bsProducts;
            repositoryGridLookup.DisplayMember = "ProductName";
            repositoryGridLookup.ValueMember = "ProductId";
            repositoryGridLookup.PopupFormMinSize = new Size(450, 150);
            repositoryGridLookup.NullText = "";
            repositoryGridLookup.ShowFooter = true;
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

            gvDetail.Columns.ColumnByName("colProductId").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
        }

        private void ClearFeilds()
        {
            txtRequisitionNo.Text = string.Empty;
            dtp.Value = DateTime.Now;
            txtOrderByCode.Text = string.Empty;
            txtOrderByName.Text = string.Empty;
            txtDeliveredByCode.Text = string.Empty;
            txtDeliveredByName.Text = string.Empty;
            cmbFWarehouse.SelectedValue = -1;
            cmbTWarehouse.SelectedValue = -1;
            txtRemarks.Text = string.Empty;
            StockReqMasterId = -1;
            DeletedIds = new List<int>();
            dset.Tables["REQDetail"].Rows.Clear();
            dset.Tables["REQMaster"].Rows.Clear();

            dset.RejectChanges();

            drMaster = dset.Tables["REQMaster"].NewRow();
            dset.Tables["REQMaster"].Rows.Add(drMaster);
            GCDetail.DataSource = dset.Tables["REQDetail"];
            GridSetting();
            txtRequisitionNo.Text = GetNewNextNumber();
            ButtonRights(true);
            btnNextInvioceNo.Enabled = false;
            btnPrevInvioceNo.Enabled = false;
        }


        private void LoadInvoice()
        {
            try
            {
                setGridSetup();

                if (dset.Tables["REQMaster"].Rows.Count > 0)
                {
                    dtp.Value = Convert.ToDateTime(drMaster["Date"]);
                    txtOrderByCode.Text = drMaster["OrderedBy"].ToString();
                    txtDeliveredByCode.Text = drMaster["DeliveredBy"].ToString();
                    cmbFWarehouse.SelectedValue = drMaster["FromWarehouseId"].ToString();
                    cmbTWarehouse.SelectedValue = drMaster["ToWarehouseId"].ToString();
                    txtRemarks.Text = drMaster["Remarks"].ToString();
                    if (Convert.ToBoolean(drMaster["IsApproved"]))
                    {
                        lblApproval.Visible = true;
                        FreezeControl(true);

                    }
                    else
                    {
                        lblApproval.Visible = false; 
                        FreezeControl(false);
                        ButtonRights(false);
                    }
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FreezeControl(bool IsApproved)
        {
            dtp.Enabled = !IsApproved;
            txtOrderByCode.Enabled = !IsApproved;
            txtDeliveredByCode.Enabled = !IsApproved;
            cmbFWarehouse.Enabled = !IsApproved;
            cmbTWarehouse.Enabled = !IsApproved;
            txtRemarks.Enabled = !IsApproved;
            gvDetail.OptionsBehavior.Editable = !IsApproved;
            btnAdd.Enabled = !IsApproved;
            btnUpdate.Enabled = !IsApproved;
            btnDelete.Enabled = !IsApproved;
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
                            dvProducts.RowFilter = "ProductId='" + e.Value.ToString() + "'";
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



            else if (dr.RowState == DataRowState.Detached)
            {
                if (dset.Tables["REQDetail"].Select("ProductId =" + dr["ProductId"].ToString()).Length > 0)
                {
                    MessageBox.Show("Item Already Exists", "Same Items can not be repeated.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Valid = false;
                    return;
                }
            }


            e.Valid = true;
            gvDetail.GetDataRow(e.RowHandle)["StockReqMasterId"] = drMaster["StockReqMasterId"]; //SalesMasterId;

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
            if (string.IsNullOrEmpty(txtOrderByCode.Text))
            {
                MessageBox.Show("Please Enter Order By Employee Code.", "Order By Code is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOrderByCode.Focus();
                result = false;

            }
            if (string.IsNullOrEmpty(txtDeliveredByCode.Text))
            {
                MessageBox.Show("Please Enter Delivered By Employee Code.", "Delivered By Code is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDeliveredByCode.Focus();
                result = false;

            }

            if (Convert.ToInt32(cmbFWarehouse.SelectedValue) <= 0)
            {
                MessageBox.Show("Please Select From Warehouse Name.", "From Warehouse is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbFWarehouse.Focus();
                result = false;
            }

            if (Convert.ToInt32(cmbTWarehouse.SelectedValue) <= 0)
            {
                MessageBox.Show("Please Select To Warehouse Name.", "To Warehouse is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTWarehouse.Focus();
                result = false;
            }

            if (dset.Tables["REQDetail"].Rows.Count <= 0)
            {
                MessageBox.Show("Please Enter Detail of Stock Requisition.", "Detail is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
            }

            if (Convert.ToInt32(cmbFWarehouse.SelectedValue) == Convert.ToInt32(cmbTWarehouse.SelectedValue))
            {
                MessageBox.Show("From Warehouse Name and To Warehouse Name Must be Different.", "Invalid Transfer Request.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
            }
            return result;

        }

        private void DeleteRequisition()
        {
            if (string.IsNullOrEmpty(txtRequisitionNo.Text))
            {
                return;
            }
            try
            {
                dataAcess.BeginTransaction();
                manageRequisition.DeleteRequisitionMaster(StockReqMasterId, dataAcess);
                dataAcess.TransCommit();
                MessageBox.Show("Requisition " + txtRequisitionNo.Text + " is Deleted.", "Requisition Delete Successful.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClear_Click(null, null);
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
                    DataTable dtReqMaster;
                    dataAcess.BeginTransaction();
                    if (dataAcess.getDBCommand().Transaction == null)
                    {
                        dataAcess.SetDBTransaction();
                    }

                    dtReqMaster = manageRequisition.InsertStockRequisition(Convert.ToDateTime(dtp.Value.ToString()), txtOrderByCode.Text, txtDeliveredByCode.Text, Convert.ToInt32(cmbFWarehouse.SelectedValue), Convert.ToInt32(cmbTWarehouse.SelectedValue), txtRemarks.Text, "H", false, false, "Requisition", dataAcess);
                    if (dtReqMaster.Rows.Count > 0)
                    {
                        StockReqMasterId = Convert.ToInt32(dtReqMaster.Rows[0]["Id"]);
                        for (int i = 0; i < dset.Tables["REQDetail"].Rows.Count; i++)
                        {
                            DataRow drDetail = dset.Tables["REQDetail"].Rows[i];
                            int DetailId = manageRequisition.InsertUpdateRequisitionDetail(Convert.ToInt32(drDetail["StockReqDetailId"]), StockReqMasterId, Convert.ToInt32(drDetail["ProductId"]), Convert.ToDecimal(drDetail["Qty"]), dataAcess);
                        }
                        dataAcess.TransCommit();

                        if (MessageBox.Show("Requisition " + dtReqMaster.Rows[0]["StockReqNo"].ToString() + " has Saved." + Environment.NewLine + " Do you want to Print. ", "Requisition Saved Successful.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            //PrintInvoice();
                        }
                        //yahan clear kerna zarori hai warna at a time approve ka form open oh and app approved hojye toh yeh koi change na ker sky.
                        ClearFeilds();
                        //ButtonRights(false);
                        //LoadInvoice();

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

        private void btnCSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetEmployeeSearch", null, "Employee");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtOrderByCode.Text = MainForm.Searched_Id;
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
                search.getattributes("GetSearchStockRequisition", null, "Stock Requisitions");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtRequisitionNo.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                    //LoadInvoice();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtOrderByCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOrderByCode.Text))
            {

                DataTable dtEmployee = dataAcess.getDataTable("SELECT  * FROM dbo.Employee WHERE Code = '" + txtOrderByCode.Text + "' ");
                if (dtEmployee.Rows.Count > 0)
                {
                    txtOrderByName.Text = dtEmployee.Rows[0]["EmployeeName"].ToString();
                }
                else
                {
                    txtOrderByName.Text = string.Empty;
                }

            }
            else
            {
                txtOrderByName.Text = string.Empty;
            }
        }

        private void txtDeliveredByCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDeliveredByCode.Text))
            {

                DataTable dtEmployee = dataAcess.getDataTable("SELECT  * FROM dbo.Employee WHERE Code = '" + txtDeliveredByCode.Text + "' ");
                if (dtEmployee.Rows.Count > 0)
                {
                    txtDeliveredByName.Text = dtEmployee.Rows[0]["EmployeeName"].ToString();
                }
                else
                {
                    txtDeliveredByName.Text = string.Empty;
                }

            }
            else
            {
                txtDeliveredByName.Text = string.Empty;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validations())
            {
                try
                {
                    DataTable dtReqMaster;
                    dataAcess.BeginTransaction();
                    if (dataAcess.getDBCommand().Transaction == null)
                    {
                        dataAcess.SetDBTransaction();
                    }
                    foreach (int id in DeletedIds)
                    {
                        manageRequisition.DeleteRequisitionDetailByDetailId(id, dataAcess);
                    }
                    manageRequisition.UpdateStockRequisition(StockReqMasterId, Convert.ToDateTime(dtp.Value), txtOrderByCode.Text, txtDeliveredByCode.Text, Convert.ToInt32(cmbFWarehouse.SelectedValue), Convert.ToInt32(cmbTWarehouse.SelectedValue), txtRemarks.Text, "H", false, false, dataAcess);
                    for (int i = 0; i < dset.Tables["REQDetail"].Rows.Count; i++)
                    {
                        if (dset.Tables["REQDetail"].Rows[i].RowState != DataRowState.Deleted)
                        {
                            DataRow drDetail = dset.Tables["REQDetail"].Rows[i];
                            int DetailId = manageRequisition.InsertUpdateRequisitionDetail(Convert.ToInt32(drDetail["StockReqDetailId"]), StockReqMasterId, Convert.ToInt32(drDetail["ProductId"]), Convert.ToDecimal(drDetail["Qty"]), dataAcess);
                        }
                    }
                    dataAcess.TransCommit();

                    if (MessageBox.Show("Requisition " + txtRequisitionNo.Text + " has Saved." + Environment.NewLine + " Do you want to Print. ", "Requisition Update Successful.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        //PrintInvoice();
                    }
                    //yahan clear kerna zarori hai warna at a time approve ka form open oh and app approved hojye toh yeh koi change na ker sky.
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

        private void gvDetail_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            try
            {
                DataRow dr = default(DataRow);
                dr = gvDetail.GetDataRow(e.RowHandle);
                if (Convert.ToInt32(dr["StockReqDetailId"].ToString()) > 0)
                {
                    DeletedIds.Add(Convert.ToInt32(dr["StockReqDetailId"].ToString()));
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Requisition Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeleteRequisition();
                        break;
                    }

            }
        }

        private void btnMinInvioceNo_Click(object sender, EventArgs e)
        {
            txtRequisitionNo.Text = manageRequisition.GetMinInvioceNo();
            if (!string.IsNullOrEmpty(txtRequisitionNo.Text))
            {
                LoadInvoice();
                btnNextInvioceNo.Enabled = true;
                btnPrevInvioceNo.Enabled = false;
            }
        }

        private void btnPrevInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRequisitionNo.Text))
            {
                string LastInvioceNo = manageRequisition.GetMinInvioceNo();
                txtRequisitionNo.Text = manageRequisition.GetPrevInvioceNo(txtRequisitionNo.Text);

                LoadInvoice();
                if (LastInvioceNo == txtRequisitionNo.Text)
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
            if (!string.IsNullOrEmpty(txtRequisitionNo.Text))
            {
                string LastInvioceNo = manageRequisition.GetMaxInvioceNo();
                txtRequisitionNo.Text = manageRequisition.GetNextInvioceNo(txtRequisitionNo.Text);
                LoadInvoice();
                if (LastInvioceNo == txtRequisitionNo.Text)
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
            txtRequisitionNo.Text = manageRequisition.GetMaxInvioceNo();
            if (!string.IsNullOrEmpty(txtRequisitionNo.Text))
            {
                LoadInvoice();
                btnNextInvioceNo.Enabled = false;
                btnPrevInvioceNo.Enabled = true;
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // PrintInvoice(false);
        }

        private void PrintInvoice(bool IsDirectPrint = true)
        {
            try
            {
                if (string.IsNullOrEmpty(txtRequisitionNo.Text))
                {
                    return;
                }

                string path = Application.StartupPath + "/rpt/rptRequisitionInvoice.rpt";
                ReportDocument document = new ReportDocument();
                document.Load(path);
                DataTable dtReport = new DataTable();
                //dtReport = RequisitionManager.GetRequisitionInvoiceReport(null, null, "", "", "", "", txtRequisitionNo.Text);
                document.SetDataSource(dtReport);
                Utility.SetReportDefaultParameter(ref document);

                if (IsDirectPrint)
                {
                    document.PrintToPrinter(1, true, 0, 0);
                }
                else
                {
                    //frmReportRequisitionInvoice report = new frmReportRequisitionInvoice(document);
                    //report.MdiParent = this.MdiParent;
                    //report.WindowState = FormWindowState.Maximized;
                    //report.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void btnDeliveredBySearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetEmployeeSearch", null, "Employee");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtDeliveredByCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtRequisitionNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRequisitionNo.Text))
            {
                StockReqMasterId = manageRequisition.GetReqMasterIdByCode(txtRequisitionNo.Text);
                if (StockReqMasterId > 0)
                {
                    LoadInvoice();
                }

            }
        }


    }
}
