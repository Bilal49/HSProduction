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
    public partial class frmProductOpening : Form
    {
        Smartworks.DAL dataAcess = new Smartworks.DAL();


        ProductManager manageProduct = new ProductManager();
        WarehouseManager manageWarehouse = new WarehouseManager();
        DataSet dset;
        RepositoryItemGridLookUpEdit repositoryGridLookup = new RepositoryItemGridLookUpEdit();
        BindingSource bsProducts = new BindingSource();
        DataRow drMaster;
        DataView dvProducts;
        DataViewManager dvm;
        int ProductOpeningBalanceId = -1;
        List<int> DeletedIds = new List<int>();

        public frmProductOpening()
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
            txtPOBId.ReadOnly = !Enable;
            btnPost.Enabled = !Enable;
            btnUnPost.Enabled = false;
            //btnOrderBySearch.Enabled = Enable;
            // txtOrderByCode.Enabled = Enable;
        }

        private void setGridSetup()
        {
            dset = new DataSet();

            dset = manageProduct.GetProductOpeningStructure(ProductOpeningBalanceId);
            dset.Tables[0].TableName = "ProductOpeningMaster";
            dset.Tables[1].TableName = "ProductOpeningDetail";
            dset.Tables[2].TableName = "Product";

            dset.Tables["ProductOpeningMaster"].Columns["ProdOpenBalMasterId"].AutoIncrement = true;
            dset.Tables["ProductOpeningMaster"].Columns["ProdOpenBalMasterId"].AutoIncrementSeed = -1;
            dset.Tables["ProductOpeningMaster"].Columns["ProdOpenBalMasterId"].AutoIncrementStep = -1;

            dset.Tables["ProductOpeningDetail"].Columns["ProdOpenBalDetailId"].AutoIncrement = true;
            dset.Tables["ProductOpeningDetail"].Columns["ProdOpenBalDetailId"].AutoIncrementSeed = -1;
            dset.Tables["ProductOpeningDetail"].Columns["ProdOpenBalDetailId"].AutoIncrementStep = -1;


            dset.Relations.Add("MasterRelation", dset.Tables["ProductOpeningMaster"].Columns["ProdOpenBalMasterId"], dset.Tables["ProductOpeningDetail"].Columns["ProdOpenBalMasterId"]);

            if (dset.Tables["ProductOpeningMaster"].Rows.Count > 0)
            {
                drMaster = dset.Tables["ProductOpeningMaster"].Rows[0];
            }
            else
            {
                drMaster = dset.Tables["ProductOpeningMaster"].NewRow();
                dset.Tables["ProductOpeningMaster"].Rows.Add(drMaster);
            }

            dvm = new DataViewManager(dset);
            dvProducts = dvm.CreateDataView(dset.Tables["Product"]);

            GCDetail.DataSource = dset.Tables["ProductOpeningDetail"];

            GridSetting();
        }
        private void GridSetting()
        {

            gvDetail.Columns.ColumnByName("colProdOpenBalDetailId").OptionsColumn.ReadOnly = true;
            gvDetail.Columns.ColumnByName("colProdOpenBalMasterId").OptionsColumn.ReadOnly = true;

            gvDetail.Columns.ColumnByName("colProdOpenBalDetailId").Visible = false;
            gvDetail.Columns.ColumnByName("colProdOpenBalMasterId").Visible = false;
            gvDetail.Columns.ColumnByName("colProductCategoryId").Visible = false;
            gvDetail.Columns.ColumnByName("colCategoryName").Visible = false;

            gvDetail.Columns.ColumnByName("colStockType").Visible = false;
            gvDetail.Columns.ColumnByName("colBatchNo").Visible = false;
            gvDetail.Columns.ColumnByName("colWarehouseId").Visible = false;

            gvDetail.Columns.ColumnByName("colPrice").Visible = false;
            gvDetail.Columns.ColumnByName("colExpiryDate").Visible = false;
            gvDetail.Columns.ColumnByName("colAmount").Visible = false;





            gvDetail.Columns.ColumnByName("colProductId").Caption = "Product Name";
            gvDetail.Columns.ColumnByName("colOpeningBalance").Caption = "Quantity";

            gvDetail.Columns.ColumnByName("colProductId").VisibleIndex = 0;
            gvDetail.Columns.ColumnByName("colOpeningBalance").VisibleIndex = 1;

            gvDetail.Columns.ColumnByName("colProductId").Width = 300;
            gvDetail.Columns.ColumnByName("colOpeningBalance").Width = 50;


            bsProducts.DataSource = dset;
            bsProducts.DataMember = "Product";

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

            gvDetail.Columns.ColumnByName("colProductId").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
        }

        private void ClearFeilds()
        {
            txtPOBId.Text = string.Empty;
            dtp.Value = DateTime.Now;
            cmbWarehouse.SelectedValue = -1;
            txtRemarks.Text = string.Empty;
            ProductOpeningBalanceId = -1;
            DeletedIds = new List<int>();
            dset.Tables["ProductOpeningDetail"].Rows.Clear();
            dset.Tables["ProductOpeningMaster"].Rows.Clear();
            dset.RejectChanges();
            drMaster = dset.Tables["ProductOpeningMaster"].NewRow();
            dset.Tables["ProductOpeningMaster"].Rows.Add(drMaster);
            GCDetail.DataSource = dset.Tables["ProductOpeningDetail"];
            GridSetting();
            FreezeControl(false);
            ButtonRights(true);
            dtp.Focus();
        }

        private void LoadInvoice()
        {
            try
            {
                setGridSetup();

                if (dset.Tables["ProductOpeningMaster"].Rows.Count > 0)
                {
                    dtp.Value = Convert.ToDateTime(drMaster["Date"]);
                    cmbWarehouse.SelectedValue = drMaster["WarehouseId"].ToString();
                    txtRemarks.Text = drMaster["Remarks"].ToString();
                    ButtonRights(false);
                    if (Convert.ToBoolean(drMaster["Posted"]))
                    {
                        FreezeControl(true);
                    }
                    else
                    {
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
            cmbWarehouse.Enabled = !IsApproved;
            txtRemarks.Enabled = !IsApproved;
            gvDetail.OptionsBehavior.Editable = !IsApproved;
            btnAdd.Enabled = !IsApproved;
            btnUpdate.Enabled = !IsApproved;
            btnDelete.Enabled = !IsApproved;
            btnPost.Enabled = !IsApproved;
            lblPosted.Visible = IsApproved;
            btnUnPost.Enabled = IsApproved;
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
                            dr["OpeningBalance"] = 1;
                        }
                        break;
                    case "colOpeningBalance":
                        if (string.IsNullOrEmpty(dr["Qty"].ToString()))
                        {
                            dr["OpeningBalance"] = 1;
                        }
                        if (decimal.Parse(dr["OpeningBalance"].ToString()) < 0)
                        {
                            dr["OpeningBalance"] = 1;  //Qty Should be greater then zero;
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

                case "colOpeningBalance":
                    gvDetail.FocusedColumn = gvDetail.Columns.ColumnByName("colOpeningBalance");

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

            else if (decimal.Parse(dr["OpeningBalance"].ToString()) <= 0)
            {
                //Quantity = "Less than one";
                e.Valid = false;
                return;
            }



            else if (dr.RowState == DataRowState.Detached)
            {
                if (dset.Tables["ProductOpeningDetail"].Select("ProductId =" + dr["ProductId"].ToString()).Length > 0)
                {
                    MessageBox.Show("Item Already Exists", "Same Items can not be repeated.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Valid = false;
                    return;
                }
            }


            e.Valid = true;
            gvDetail.GetDataRow(e.RowHandle)["ProdOpenBalMasterId"] = drMaster["ProdOpenBalMasterId"]; //SalesMasterId;

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
                            case "colOpeningBalance":
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
            if (dset.Tables["ProductOpeningDetail"].Rows.Count <= 0)
            {
                MessageBox.Show("Please Enter Detail of Product Opening.", "Detail is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
            }

            return result;

        }

        private void DeletePOB()
        {
            if (string.IsNullOrEmpty(txtPOBId.Text))
            {
                return;
            }
            try
            {
                dataAcess.BeginTransaction();
                manageProduct.DeleteProductOpeningBalanceMaster(ProductOpeningBalanceId, dataAcess);
                dataAcess.TransCommit();
                MessageBox.Show("Product Opening  " + txtPOBId.Text + " is Deleted.", "Product Opening Delete Successful.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    dataAcess.BeginTransaction();
                    if (dataAcess.getDBCommand().Transaction == null)
                    {
                        dataAcess.SetDBTransaction();
                    }

                    ProductOpeningBalanceId = manageProduct.InsertProductOpeningBalance(Convert.ToDateTime(dtp.Value.ToString()), false, 0, "", "H", txtRemarks.Text, MainForm.User_Id, DateTime.Now, "", dataAcess);
                    if (ProductOpeningBalanceId > 0)
                    {
                        for (int i = 0; i < dset.Tables["ProductOpeningDetail"].Rows.Count; i++)
                        {
                            DataRow drDetail = dset.Tables["ProductOpeningDetail"].Rows[i];
                            int DetailId = manageProduct.InsertUpdateProductOpeningDetail(Convert.ToInt32(drDetail["ProdOpenBalDetailId"]), ProductOpeningBalanceId, Convert.ToInt32(drDetail["ProductId"]), "Stock", "Opening", Convert.ToInt32(cmbWarehouse.SelectedValue), Convert.ToDecimal(drDetail["OpeningBalance"]), 0, null, dataAcess);
                        }
                        dataAcess.TransCommit();
                        MessageBox.Show("Product Opening Balance Record Insert Sucessfully", "Record Saved Successful.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                search.getattributes("GetSearchProductOpening", null, "Product Opening");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtPOBId.Text = MainForm.Searched_Id;
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
                        manageProduct.DeleteProductOpeningBalanceByDetailId(id, dataAcess);
                    }
                    manageProduct.UpdateProductOpeningBalance(ProductOpeningBalanceId, Convert.ToDateTime(dtp.Value), false, 0, "", "H", txtRemarks.Text, MainForm.User_Id, DateTime.Now, "", dataAcess);
                    for (int i = 0; i < dset.Tables["ProductOpeningDetail"].Rows.Count; i++)
                    {
                        if (dset.Tables["ProductOpeningDetail"].Rows[i].RowState != DataRowState.Deleted)
                        {
                            DataRow drDetail = dset.Tables["ProductOpeningDetail"].Rows[i];
                            int DetailId = manageProduct.InsertUpdateProductOpeningDetail(Convert.ToInt32(drDetail["ProdOpenBalDetailId"]), ProductOpeningBalanceId, Convert.ToInt32(drDetail["ProductId"]), "Stock", "Opening", Convert.ToInt32(cmbWarehouse.SelectedValue), Convert.ToDecimal(drDetail["OpeningBalance"]), 0, null, dataAcess);
                        }
                    }
                    dataAcess.TransCommit();
                    MessageBox.Show("Product Opening Balance Record Update Sucessfully", "Record Updated Successful.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (Convert.ToInt32(dr["ProdOpenBalDetailId"].ToString()) > 0)
                {
                    DeletedIds.Add(Convert.ToInt32(dr["ProdOpenBalDetailId"].ToString()));
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Product Opening Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {

                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeletePOB();
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // PrintInvoice(false);
            DialogResult result = MessageBox.Show("Are you sure want to Post Opening Data?", "Product Opening Posting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {

                        break;
                    }
                case DialogResult.Yes:
                    {
                        PostingProductOpening();
                        break;
                    }

            }
        }

        private void PostingProductOpening()
        {
            if (dset.Tables["ProductOpeningDetail"].Rows.Count <= 0)
            {
                MessageBox.Show("Please Enter Detail of Product Opening.", "Detail is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (ProductOpeningBalanceId > 0)
                {
                    dataAcess.BeginTransaction();
                    if (dataAcess.getDBCommand().Transaction == null)
                    {
                        dataAcess.SetDBTransaction();
                    }
                    for (int i = 0; i < dset.Tables["ProductOpeningDetail"].Rows.Count; i++)
                    {
                        DataRow drDetail = dset.Tables["ProductOpeningDetail"].Rows[i];
                        manageProduct.InsertUpdateProductLedger(Convert.ToInt32(drDetail["ProductId"]), Convert.ToDateTime(dtp.Value), txtPOBId.Text, Convert.ToInt32(drDetail["ProdOpenBalDetailId"]), "I", Convert.ToDecimal(drDetail["OpeningBalance"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "Opening", null, Convert.ToInt32(cmbWarehouse.SelectedValue), -1, dataAcess);
                    }
                    if (!manageProduct.UpdatePOBPosted(ProductOpeningBalanceId, dataAcess))
                    {
                        throw new Exception("Record does not Posted");
                    }
                    dataAcess.TransCommit();
                    MessageBox.Show("Product Opening Balance POST Sucessfully", "Record POSTED Successfull.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void PrintInvoice(bool IsDirectPrint = true)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPOBId.Text))
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

        private void txtRequisitionNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPOBId.Text))
            {
                ProductOpeningBalanceId = manageProduct.GetPOBIdByCode(txtPOBId.Text);
                if (ProductOpeningBalanceId > 0)
                {
                    LoadInvoice();
                }

            }
        }

        private void btnUnPost_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to UnPost Opening Data?", "Product Opening UnPosting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {

                        break;
                    }
                case DialogResult.Yes:
                    {
                        UNPostingProductOpening();
                        break;
                    }

            }
        }

        private void UNPostingProductOpening()
        {
            if (dset.Tables["ProductOpeningDetail"].Rows.Count <= 0)
            {
                MessageBox.Show("Detail of Product Opening Not Found.", "Detail is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (ProductOpeningBalanceId > 0)
                {
                    dataAcess.BeginTransaction();
                    if (dataAcess.getDBCommand().Transaction == null)
                    {
                        dataAcess.SetDBTransaction();
                    }
                    manageProduct.DeleteProductLedgerByTransNo(ProductOpeningBalanceId.ToString(), dataAcess);
                    //for (int i = 0; i < dset.Tables["ProductOpeningDetail"].Rows.Count; i++)
                    //{
                    //    DataRow drDetail = dset.Tables["ProductOpeningDetail"].Rows[i];
                    //    manageProduct.InsertUpdateProductLedger(Convert.ToInt32(drDetail["ProductId"]), Convert.ToDateTime(dtp.Value), txtPOBId.Text, Convert.ToInt32(drDetail["ProdOpenBalDetailId"]), "I", Convert.ToDecimal(drDetail["OpeningBalance"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "Opening", null, Convert.ToInt32(cmbWarehouse.SelectedValue), -1, dataAcess);
                    //}
                    if (!manageProduct.UpdatePOB_UnPosted(ProductOpeningBalanceId, dataAcess))
                    {
                        throw new Exception("Record does not Posted");
                    }
                    dataAcess.TransCommit();
                    MessageBox.Show("Product Opening Balance UNPOST Sucessfully", "Record UNPOSTED Successfull.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


    }
}
